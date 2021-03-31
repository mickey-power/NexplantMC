/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsLibraryModeler.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.27
--  Description     : FAMate SECS Modeler SECS Library Modeler Form Class 
--  History         : Created by spike.lee at 2011.01.27
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.SecsModeler
{
    public partial class FSecsLibraryModeler : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FEventHandler m_fEventHandler = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsLibraryModeler(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLibraryModeler(
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
                tvwTree.ImageList.Images.Add("SecsLibraryGroup_unlock", Properties.Resources.SecsLibraryGroup_unlock);
                tvwTree.ImageList.Images.Add("SecsLibraryGroup_lock", Properties.Resources.SecsLibraryGroup_lock);
                tvwTree.ImageList.Images.Add("SecsLibrary_unlock", Properties.Resources.SecsLibrary_unlock);
                tvwTree.ImageList.Images.Add("SecsLibrary_lock", Properties.Resources.SecsLibrary_lock);
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
                        t.Key == FMenuKey.MenuSlmExpand || 
                        t.Key == FMenuKey.MenuSlmCollapse ||
                        t.Key == FMenuKey.MenuSlmRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuSlmCut ||
                        t.Key == FMenuKey.MenuSlmCopy ||
                        t.Key == FMenuKey.MenuSlmPasteSibling ||
                        t.Key == FMenuKey.MenuSlmPasteChild ||
                        t.Key == FMenuKey.MenuSlmRemove ||
                        t.Key == FMenuKey.MenuSlmMoveUp ||
                        t.Key == FMenuKey.MenuSlmMoveDown||     
                        t.Key == FMenuKey.MenuSlmConvertToSml                         
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
                    mnuMenu.Tools[FMenuKey.MenuSlmAppendSecsLibraryGroup].SharedProps.Visible = ((FSecsDriver)fObject).canAppendChildSecsLibraryGroup;                    
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmPasteChild].SharedProps.Enabled = ((FSecsDriver)fObject).canPasteChildSecsLibraryGroup;                    
                }
                else if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertBeforeSecsLibraryGroup].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertAfterSecsLibraryGroup].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmAppendSecsLibrary].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertBeforeSecsLibrary].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertAfterSecsLibrary].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmAppendSecsMessageList].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmBatchModifier].SharedProps.Visible = true;
                    //mnuMenu.Tools[FMenuKey.MenuSlmBatchModifier].SharedProps.Enabled = true;
                    mnuMenu.Tools[FMenuKey.MenuSlmGemInspector].SharedProps.Visible = true;
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    mnuMenu.Tools[FMenuKey.MenuSlmResetVersion].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSlmResetVersion].SharedProps.Enabled = fObject.hasChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertBeforeSecsMessageList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertAfterSecsMessageList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmAppendSecsMessages].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmImportStandardSecsMessages].SharedProps.Visible = true;
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    mnuMenu.Tools[FMenuKey.MenuSlmReplace].SharedProps.Visible = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertBeforeSecsMessages].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertAfterSecsMessages].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmConvertToSml].SharedProps.Enabled = true;
                    // --                    
                    mnuMenu.Tools[FMenuKey.MenuSlmAppendPrimarySecsMessage].SharedProps.Visible = ((FSecsMessages)fObject).canAppendChildPrimarySecsMessage;
                    if (((FSecsMessages)fObject).canAppendChildSecondarySecsMessage)
                    {
                        mnuMenu.Tools[FMenuKey.MenuSlmAppendSecondarySecsMessage].SharedProps.Visible = true;
                        // --
                        mnuMenu.Toolbars[0].Tools[FMenuKey.MenuSlmAppendSecondarySecsMessage].InstanceProps.IsFirstInGroup = !((FSecsMessages)fObject).canAppendChildPrimarySecsMessage;
                        ((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuSlmPopupMenu]).Tools[FMenuKey.MenuSlmAppendSecondarySecsMessage].InstanceProps.IsFirstInGroup = !((FSecsMessages)fObject).canAppendChildPrimarySecsMessage;
                    }                  
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    mnuMenu.Tools[FMenuKey.MenuSlmReplace].SharedProps.Visible = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmAppendSecsItem].SharedProps.Visible = fObject.canAppendChild;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmConvertToSml].SharedProps.Enabled = true;
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    mnuMenu.Tools[FMenuKey.MenuSlmReplace].SharedProps.Visible = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertBeforeSecsItem].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuSlmInsertAfterSecsItem].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmAppendSecsItem].SharedProps.Visible = fObject.canAppendChild;                    
                }

                if(
                    fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    fObject.fObjectType == FObjectType.SecsLibrary ||
                    fObject.fObjectType == FObjectType.SecsMessageList ||
                    fObject.fObjectType == FObjectType.SecsMessages ||
                    fObject.fObjectType == FObjectType.SecsMessage ||
                    fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuSlmPasteSibling].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSlmPasteChild].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSlmPastePrimarySecsMessage].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuSlmPasteSecondarySecsMessage].SharedProps.Visible = false;                    
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmRemove].SharedProps.Enabled = fObject.canRemove;
                    //--
                    mnuMenu.Tools[FMenuKey.MenuSlmMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuSlmMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // -- 
                    mnuMenu.Tools[FMenuKey.MenuSlmCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuSlmCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuSlmPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
                    mnuMenu.Tools[FMenuKey.MenuSlmPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                }

                if (fObject.fObjectType == FObjectType.SecsMessages)
                {

                    if (
                        ((FSecsMessages)fObject).canPastePrimarySecsMessage ||
                        ((FSecsMessages)fObject).canPasteSecondarySecsMessage
                        )
                    {
                        mnuMenu.Tools[FMenuKey.MenuSlmPasteSibling].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuSlmPasteChild].SharedProps.Visible = false;
                        mnuMenu.Tools[FMenuKey.MenuSlmPastePrimarySecsMessage].SharedProps.Visible = true;
                        mnuMenu.Tools[FMenuKey.MenuSlmPasteSecondarySecsMessage].SharedProps.Visible = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSlmPastePrimarySecsMessage].SharedProps.Enabled = ((FSecsMessages)fObject).canPastePrimarySecsMessage;
                    mnuMenu.Tools[FMenuKey.MenuSlmPasteSecondarySecsMessage].SharedProps.Enabled = ((FSecsMessages)fObject).canPasteSecondarySecsMessage; 
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
                //    mnuMenu.Tools[FMenuKey.MenuSlmReplace].SharedProps.Enabled = true;
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

        private void loadTreeOfObject(
            )
        {
            FSecsDriver fScd = null;
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeSlg = null;
            UltraTreeNode tNodeSlb = null;
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
                // SECS Library Group Load
                // ***
                foreach (FSecsLibraryGroup fSlg in fScd.fChildSecsLibraryGroupCollection)
                {
                    tNodeSlg = new UltraTreeNode(fSlg.uniqueIdToString);
                    tNodeSlg.Tag = fSlg;
                    FCommon.refreshTreeNodeOfObject(fSlg, tvwTree, tNodeSlg);

                    // --

                    // ***
                    // SECS Library Load
                    // ***
                    foreach (FSecsLibrary fSlb in fSlg.fChildSecsLibraryCollection)
                    {
                        tNodeSlb = new UltraTreeNode(fSlb.uniqueIdToString);
                        tNodeSlb.Tag = fSlb;
                        FCommon.refreshTreeNodeOfObject(fSlb, tvwTree, tNodeSlb);

                        // --

                        // ***
                        // SECS Message List Load
                        // ***
                        foreach (FSecsMessageList fSml in fSlb.fChildSecsMessageListCollection)
                        {
                            tNodeSml = new UltraTreeNode(fSml.uniqueIdToString);
                            tNodeSml.Tag = fSml;
                            FCommon.refreshTreeNodeOfObject(fSml, tvwTree, tNodeSml);

                            // --

                            // ***
                            // SECS Messages Load
                            // ***
                            foreach (FSecsMessages fSms in fSml.fChildSecsMessagesCollection)
                            {
                                tNodeSms = new UltraTreeNode(fSms.uniqueIdToString);
                                tNodeSms.Tag = fSms;
                                FCommon.refreshTreeNodeOfObject(fSms, tvwTree, tNodeSms);

                                // --

                                // ***
                                // SECS Message Load
                                // ***
                                foreach (FSecsMessage fSmg in fSms.fChildSecsMessageCollection)
                                {
                                    tNodeSmg = new UltraTreeNode(fSmg.uniqueIdToString);
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
                            tNodeSlb.Nodes.Add(tNodeSml);
                        }

                        tNodeSlb.Expanded = true;
                        tNodeSlg.Nodes.Add(tNodeSlb);
                    }

                    // --

                    tNodeSlg.Expanded = true;
                    tNodeScd.Nodes.Add(tNodeSlg);                    
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
                tNodeSlg = null;
                tNodeSlb = null;
                tNodeSml = null;
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

            try
            {
                tvwTree.beginUpdate();

                // --

                fParent = (FIObject)tNodeParent.Tag;               
                // --
                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    foreach (FSecsLibraryGroup fSlg in ((FSecsDriver)fParent).fChildSecsLibraryGroupCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSlg.uniqueIdToString);
                        tNodeChild.Tag = fSlg;
                        FCommon.refreshTreeNodeOfObject(fSlg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    foreach (FSecsLibrary fSlb in ((FSecsLibraryGroup)fParent).fChildSecsLibraryCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSlb.uniqueIdToString);
                        tNodeChild.Tag = fSlb;
                        FCommon.refreshTreeNodeOfObject(fSlb, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsLibrary)
                {
                    foreach (FSecsMessageList fSml in ((FSecsLibrary)fParent).fChildSecsMessageListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSml.uniqueIdToString);
                        tNodeChild.Tag = fSml;
                        FCommon.refreshTreeNodeOfObject(fSml, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    foreach (FSecsMessages fSms in ((FSecsMessageList)fParent).fChildSecsMessagesCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSms.uniqueIdToString);
                        tNodeChild.Tag = fSms;
                        FCommon.refreshTreeNodeOfObject(fSms, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    foreach (FSecsMessage fSmg in ((FSecsMessages)fParent).fChildSecsMessageCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSmg.uniqueIdToString);
                        tNodeChild.Tag = fSmg;
                        FCommon.refreshTreeNodeOfObject(fSmg, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    foreach (FSecsItem fSit in ((FSecsMessage)fParent).fChildSecsItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSit.uniqueIdToString);
                        tNodeChild.Tag = fSit;
                        FCommon.refreshTreeNodeOfObject(fSit, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    foreach (FSecsItem fSit in ((FSecsItem)fParent).fChildSecsItemCollection)
                    {
                        tNodeChild = new UltraTreeNode(fSit.uniqueIdToString);
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

                if (fNewChild.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                   
                    fRefChild = ((FSecsLibraryGroup)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsLibrary)
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
                    fRefChild = ((FSecsLibrary)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsMessageList)
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
                    fRefChild = ((FSecsMessageList)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsMessages)
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
                    fRefChild = ((FSecsMessages)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsMessage)
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
                    fRefChild = ((FSecsMessage)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.SecsItem)
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
                    fRefChild = ((FSecsItem)fNewChild).fNextSibling;                    
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

                if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    if (((FSecsLibraryGroup)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsLibraryGroup)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    if (((FSecsLibrary)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsLibrary)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    if (((FSecsMessageList)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsMessageList)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    if (((FSecsMessages)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsMessages)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
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
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    if (((FSecsItem)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsItem)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
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

                if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    if (((FSecsLibraryGroup)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsLibraryGroup)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    if (((FSecsLibrary)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsLibrary)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsMessageList)
                {
                    if (((FSecsMessageList)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsMessageList)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsMessages)
                {
                    if (((FSecsMessages)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsMessages)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsMessage)
                {
                    if (((FSecsMessage)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsMessage)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.SecsItem)
                {
                    if (((FSecsItem)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FSecsItem)fObject).fNextSibling == (FIObject)tNextNode.Tag)
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

                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    fNewChild = ((FSecsDriver)fParent).appendChildSecsLibraryGroup(new FSecsLibraryGroup(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    fNewChild = ((FSecsLibraryGroup)fParent).appendChildSecsLibrary(new FSecsLibrary(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.SecsLibrary)
                {
                    fNewChild = ((FSecsLibrary)fParent).appendChildSecsMessageList(new FSecsMessageList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    fNewChild = ((FSecsMessageList)fParent).appendChildSecsMessages(new FSecsMessages(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    if (menuKey == FMenuKey.MenuSlmAppendPrimarySecsMessage)
                    {
                        fNewChild = ((FSecsMessages)fParent).appendChildPrimarySecsMessage(new FSecsMessage(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    }
                    else
                    {
                        fNewChild = ((FSecsMessages)fParent).appendChildSecondarySecsMessage(new FSecsMessage(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    fNewChild = ((FSecsMessage)fParent).appendChildSecsItem(new FSecsItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    fNewChild = new FSecsItem(this.m_fSsmCore.fSsmFileInfo.fSecsDriver);
                    if (((FSecsItem)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FSecsItem)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FSecsItem)fParent).appendChildSecsItem((FSecsItem)fNewChild);
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
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
                    fNewChild = ((FSecsDriver)fParent).insertBeforeChildSecsLibraryGroup(
                        new FSecsLibraryGroup(this.m_fSsmCore.fSsmFileInfo.fSecsDriver), 
                        (FSecsLibraryGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    fNewChild = ((FSecsLibraryGroup)fParent).insertBeforeChildSecsLibrary(
                        new FSecsLibrary(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsLibrary)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.SecsLibrary)
                {
                    fNewChild = ((FSecsLibrary)fParent).insertBeforeChildSecsMessageList(
                        new FSecsMessageList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsMessageList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    fNewChild = ((FSecsMessageList)fParent).insertBeforeChildSecsMessages(
                        new FSecsMessages(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsMessages)fRefChild
                        );
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

                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    fNewChild = ((FSecsDriver)fParent).insertAfterChildSecsLibraryGroup(
                        new FSecsLibraryGroup(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsLibraryGroup)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    fNewChild = ((FSecsLibraryGroup)fParent).insertAfterChildSecsLibrary(
                        new FSecsLibrary(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsLibrary)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.SecsLibrary)
                {
                    fNewChild = ((FSecsLibrary)fParent).insertAfterChildSecsMessageList(
                        new FSecsMessageList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsMessageList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    fNewChild = ((FSecsMessageList)fParent).insertAfterChildSecsMessages(
                        new FSecsMessages(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FSecsMessages)fRefChild
                        );
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
                // Removing SECS Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FSecsLibraryGroup)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }                                    
                }
                else if (fParent.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FSecsLibrary)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.SecsLibrary)
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
                    fChilds = new FSecsLibraryGroup[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsLibraryGroup)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsDriver)fParent).removeChildSecsLibraryGroup((FSecsLibraryGroup[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    fChilds = new FSecsLibrary[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsLibrary)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsLibraryGroup)fParent).removeChildSecsLibrary((FSecsLibrary[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.SecsLibrary)
                {
                    fChilds = new FSecsMessageList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FSecsMessageList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsLibrary)fParent).removeChildSecsMessageList((FSecsMessageList[])fChilds);
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
                tvwTree.beginUpdate();

                // --

                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                //--

                if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    ((FSecsLibraryGroup)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    ((FSecsLibrary)fObject).moveUp();
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

                if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    ((FSecsLibraryGroup)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    ((FSecsLibrary)fObject).moveDown();
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
                    foreach (UltraTreeNode tNodeSlg in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeSlg.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeSlb in tNodeSlg.Nodes)
                        {
                            tNodeSlb.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeSml in tNodeSlb.Nodes)
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
                else if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeSlb in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeSlb.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeSml in tNodeSlb.Nodes)
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
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
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
                    foreach (UltraTreeNode tNodeSlg in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeSlb in tNodeSlg.Nodes)
                        {
                            foreach (UltraTreeNode tNodeSml in tNodeSlb.Nodes)
                            {
                                foreach (UltraTreeNode tNodeSms in tNodeSml.Nodes)
                                {
                                    tNodeSms.Expanded = false;
                                }
                                // --
                                tNodeSml.Expanded = false;
                            }
                            // --
                            tNodeSlb.Expanded = false;
                        }
                        // --
                        tNodeSlg.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    foreach (UltraTreeNode tNodeSlb in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeSml in tNodeSlb.Nodes)
                        {
                            foreach (UltraTreeNode tNodeSms in tNodeSml.Nodes)
                            {
                                tNodeSms.Expanded = false;
                            }
                            // --
                            tNodeSml.Expanded = false;
                        }
                        // --
                        tNodeSlb.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
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
            FSmlViewer fSmlViewer= null;
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

        private void procMenuBatchModifier(
            )
        {
            FBatchModifier dialog = null;
            FIObject fObject = null;

            try
            {
                fObject = (FIObject)tvwTree.ActiveNode.Tag;
                
                // --

                dialog = new FBatchModifier(
                    m_fSsmCore,
                    fObject as FSecsLibrary
                    );
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                {
                    return;
                }

                // --
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
                    m_fSsmCore.fSsmContainer.showGemInspector(fObject as FSecsLibrary);
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

                if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    ((FSecsLibraryGroup)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    ((FSecsLibrary)fObject).cut();
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

                if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    ((FSecsLibraryGroup)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    ((FSecsLibrary)fObject).copy();
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
                if (fRefObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    fNewObject = ((FSecsLibraryGroup)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.SecsLibrary)
                {
                    fNewObject = ((FSecsLibrary)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.SecsMessageList)
                {
                    fNewObject = ((FSecsMessageList)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.SecsMessages)
                {
                    fNewObject = ((FSecsMessages)fRefObject).pasteSibling();
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

                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    fChild = ((FSecsDriver)fParent).pasteChildSecsLibraryGroup();
                }
                else if (fParent.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    fChild = ((FSecsLibraryGroup)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.SecsLibrary)
                {
                    fChild = ((FSecsLibrary)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.SecsMessageList)
                {
                    fChild = ((FSecsMessageList)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    // ***
                    // 사용하지 않음
                    // ***
                }
                else if (fParent.fObjectType == FObjectType.SecsMessage)
                {
                    fChild = ((FSecsMessage)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.SecsItem)
                {
                    fChild = ((FSecsItem)fParent).pasteChild();
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

        private void procMenuPastePrimarySecsMessage(
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
            
                if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    fChild = ((FSecsMessages)fParent).pastePrimarySecsMessage();
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

        private void procMenuPasteSecondarySecsMessage(
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

                if (fParent.fObjectType == FObjectType.SecsMessages)
                {
                    fChild = ((FSecsMessages)fParent).pasteSecondarySecsMessage();
                }
                
                // --

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
            FIObject fResult= null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fBase = (FIObject)tNode.Tag;                
                
                // --

                fResult = m_fSsmCore.fSsmFileInfo.fSecsDriver.searchSecsLibrarySeries(fBase, searchWord);
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fSsmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
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
            FIObject fObject
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeParent = null;

            try
            {
                if (fObject.fObjectType == FObjectType.SecsDriver)
                {
                    return;
                }
                
                // --

                fParent = m_fSsmCore.fSsmFileInfo.fSecsDriver.getParentOfObject(fObject);

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

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuStandardSecsMessages(
            )
        {            
            FIObject selectedObject = null;
            FIObject fChild = null;
            UltraTreeNode tNodeChild = null;
            UltraTreeNode tNodeParent = null;
            FStandardSecsLibrarySelector fStandardSecsLibrarySelector = null;

            try
            {
                tNodeParent = tvwTree.ActiveNode;
                selectedObject = (FIObject)tNodeParent.Tag;               

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
                        fChild = ((FSecsMessageList)selectedObject).pasteChild();
                        tNodeChild = new UltraTreeNode(fChild.uniqueIdToString);
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
                selectedObject = null;
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

        #region FSecsLibraryModeler Form Event Handler

        private void FSecsLibraryModeler_Load(
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

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuSlmPopupMenu]);                

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

        private void FSecsLibraryModeler_Shown(
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

        private void FSecsLibraryModeler_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
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

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.SecsLibrary ||
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
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
                    e.fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.SecsLibrary ||
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
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
                    e.fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.SecsLibrary ||
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    addTreeOfObject(e.fParentObject, e.fObject);
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
                    e.fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.SecsLibrary ||
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    removeTreeOfObject(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.DataConversion)
                {
                    foreach (FIObject fObject in e.fParentObject.fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.SecsItem)
                        {
                            refreshObject(fObject);
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

        private void m_fEventHandler_ObjectMoveUpCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.SecsLibrary ||
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    moveUpTreeOfObject(e.fObject);
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
                    e.fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.SecsLibrary ||
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    moveDownTreeOfObject(e.fObject);
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
                    e.fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.SecsLibrary ||
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    moveToTreeOfObject(e.fObject, e.fRefObject);
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
                    e.fObject.fObjectType == FObjectType.SecsLibraryGroup ||
                    e.fObject.fObjectType == FObjectType.SecsLibrary ||
                    e.fObject.fObjectType == FObjectType.SecsMessageList ||
                    e.fObject.fObjectType == FObjectType.SecsMessages ||
                    e.fObject.fObjectType == FObjectType.SecsMessage ||
                    e.fObject.fObjectType == FObjectType.SecsItem
                    )
                {
                    refreshObject(e.fObject);
                }
                else if (e.fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    foreach (FIObject fObject in ((FDataConversionSet)e.fObject).fReferenceObjectCollection)
                    {
                        if (fObject.fObjectType == FObjectType.SecsItem)
                        {
                            refreshObject(fObject);
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
                else if (fObject.fObjectType == FObjectType.SecsLibraryGroup)
                {
                    pgdProp.selectedObject = new FPropSlg(m_fSsmCore, pgdProp, (FSecsLibraryGroup)fObject);
                }
                else if (fObject.fObjectType == FObjectType.SecsLibrary)
                {
                    pgdProp.selectedObject = new FPropSlb(m_fSsmCore, pgdProp, (FSecsLibrary)fObject);
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
                    if (mnuMenu.Tools[FMenuKey.MenuSlmRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSlmCut].SharedProps.Enabled == true)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSlmCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    fObject = (FIObject)this.tvwTree.ActiveNode.Tag;

                    if (fObject.fObjectType == FObjectType.SecsMessages)
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSlmPasteSibling].SharedProps.Enabled == true)
                        {
                            procMenuPasteSibling();
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuSlmPastePrimarySecsMessage].SharedProps.Enabled == true)
                        {
                            procMenuPastePrimarySecsMessage();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSlmPasteSibling].SharedProps.Enabled == true)
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
                        if (mnuMenu.Tools[FMenuKey.MenuSlmPasteChild].SharedProps.Enabled == true)
                        {
                            procMenuPasteChild();
                        }
                        else if (mnuMenu.Tools[FMenuKey.MenuSlmPasteSecondarySecsMessage].SharedProps.Enabled == true)
                        {
                            procMenuPasteSecondarySecsMessage();
                        }
                    }
                    else
                    {
                        if (mnuMenu.Tools[FMenuKey.MenuSlmPasteChild].SharedProps.Enabled == true)
                        {
                            procMenuPasteChild();
                        }
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSlmMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuSlmMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSlmMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuSlmMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSlmExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSlmCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuSlmRelation].SharedProps.Enabled == true)
                    {
                        procMenuRelation();
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
            FFormat fFormat = FFormat.Unknown;

            try
            {                
                // --

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
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsLibraryGroup)
                        {
                            #region SecsLibraryGroup

                            if (((FSecsDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FSecsDriver)fRefObject).fChildSecsLibraryGroupCollection.count;
                                fRefObject = ((FSecsDriver)fRefObject).fChildSecsLibraryGroupCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.SecsLibraryGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsLibraryGroup)
                        {
                            #region SecsLibraryGroup

                            if (((FSecsLibraryGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FSecsLibraryGroup)fRefObject).fNextSibling == null || !((FSecsLibraryGroup)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsLibrary)
                        {
                            #region SecsLibrary

                            if (((FSecsLibraryGroup)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FSecsLibraryGroup)fRefObject).fChildSecsLibraryCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FSecsLibraryGroup)fRefObject).fChildSecsLibraryCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.SecsLibrary)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsLibrary)
                        {
                            #region SecsLibrary
                            
                            if (((FSecsLibrary)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FSecsLibrary)fRefObject).fNextSibling == null || !((FSecsLibrary)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessageList)
                        {
                            #region SecsMessageList

                            if (((FSecsLibrary)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // SECS Message List는 다른 SECS Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
                                    ((FSecsLibrary)fRefObject).Equals(((FSecsMessageList)fDragDropData.fObject).fParent)
                                    )
                                {
                                    cnt = ((FSecsLibrary)fRefObject).fChildSecsMessageListCollection.count;
                                    fRefObject = ((FSecsLibrary)fRefObject).fChildSecsMessageListCollection[cnt - 1];
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessageList)
                        {
                            #region SecsMessageList

                            if (!fRefObject.Equals(fDragDropData.fObject))
                            {
                                if (((FSecsMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                                {
                                    // ***
                                    // SECS Message List는 다른 SECS Library로 Move 할 수 없다.
                                    // ***
                                    if (
                                        fDragDropData.sessionUniqueId == string.Empty &&
                                        ((FSecsMessageList)fRefObject).fParent.Equals(((FSecsMessageList)fDragDropData.fObject).fParent)
                                        )
                                    {
                                        if (
                                            ((FSecsMessageList)fRefObject).fNextSibling == null ||
                                            !((FSecsMessageList)fRefObject).fNextSibling.Equals(fDragDropData.fObject)
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessages)
                        {
                            #region SecsMessages

                            if (((FSecsMessageList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // SECS Messages는 다른 SECS Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsMessages)
                        {
                            #region SecsMessages

                            if (((FSecsMessages)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                // ***
                                // SECS Messages는 다른 SECS Library로 Move 할 수 없다.
                                // ***
                                if (
                                    fDragDropData.sessionUniqueId == string.Empty &&
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsItem)
                        {
                            #region SecsItem

                            if (((FSecsItem)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    fDragDropData.sessionUniqueId == string.Empty &&
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsLibraryGroup)
                        {
                            #region SecsLibraryGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FSecsDriver)fRefObject).fChildSecsLibraryGroupCollection.count;
                                fRefObject = ((FSecsDriver)fRefObject).fChildSecsLibraryGroupCollection[cnt - 1];
                                ((FSecsLibraryGroup)fDragDropData.fObject).moveTo((FSecsLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsLibraryGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsDriver)fRefObject).pasteChildSecsLibraryGroup();
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
                    else if (fRefObject.fObjectType == FObjectType.SecsLibraryGroup)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsLibraryGroup)
                        {
                            #region SecsLibraryGroup

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsLibraryGroup)fDragDropData.fObject).moveTo((FSecsLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsLibraryGroup)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsLibraryGroup)fRefObject).pasteSibling();
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

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsLibrary)fDragDropData.fObject).moveTo((FSecsLibraryGroup)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsLibrary)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsLibraryGroup)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.SecsLibrary)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.SecsLibrary)
                        {
                            #region SecsLibrary

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FSecsLibrary)fDragDropData.fObject).moveTo((FSecsLibrary)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsLibrary)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsLibrary)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
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
                                ((FSecsMessageList)fDragDropData.fObject).moveTo((FSecsLibrary)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FSecsMessageList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsLibrary)fRefObject).pasteChild();
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
                        else
                        {
                            return;
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.SecsItem)
                    {
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
                                tNode = new UltraTreeNode(fSms.uniqueIdToString);
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
                                tNode = new UltraTreeNode(fSms.uniqueIdToString);
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
                        fRefObject.fObjectType == FObjectType.SecsMessage ||
                        fRefObject.fObjectType == FObjectType.SecsItem
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

                if (e.Tool.Key == FMenuKey.MenuSlmExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmBatchModifier)
                {
                    procMenuBatchModifier();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmGemInspector)
                {
                    procMenuSecsLibraryGemInspector();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmResetVersion)
                {
                    procMenuResetVersion();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmReplace)
                {
                    procMenuReplace();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmPastePrimarySecsMessage)
                {
                    procMenuPastePrimarySecsMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmPasteSecondarySecsMessage)
                {
                    procMenuPasteSecondarySecsMessage();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmRelation)
                {
                    procMenuRelation();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmConvertToSml)
                {
                    procMenuSmlViewer();
                }
                else if (e.Tool.Key == FMenuKey.MenuSlmImportStandardSecsMessages)
                {
                    procMenuStandardSecsMessages();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSlmInsertBeforeSecsLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuSlmInsertBeforeSecsLibrary ||
                    e.Tool.Key == FMenuKey.MenuSlmInsertBeforeSecsMessageList ||
                    e.Tool.Key == FMenuKey.MenuSlmInsertBeforeSecsMessages ||
                    e.Tool.Key == FMenuKey.MenuSlmInsertBeforeSecsItem
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSlmInsertAfterSecsLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuSlmInsertAfterSecsLibrary ||
                    e.Tool.Key == FMenuKey.MenuSlmInsertAfterSecsMessageList ||
                    e.Tool.Key == FMenuKey.MenuSlmInsertAfterSecsMessages ||
                    e.Tool.Key == FMenuKey.MenuSlmInsertAfterSecsItem
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuSlmAppendSecsLibraryGroup ||
                    e.Tool.Key == FMenuKey.MenuSlmAppendSecsLibrary ||
                    e.Tool.Key == FMenuKey.MenuSlmAppendSecsMessageList ||
                    e.Tool.Key == FMenuKey.MenuSlmAppendSecsMessages ||
                    e.Tool.Key == FMenuKey.MenuSlmAppendPrimarySecsMessage ||
                    e.Tool.Key == FMenuKey.MenuSlmAppendSecondarySecsMessage ||
                    e.Tool.Key == FMenuKey.MenuSlmAppendSecsItem
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
