/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentStateSetDefinition.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.02
--  Description     : FAMate SECS Modeler Equipment State Set Definition Form Class 
--  History         : Created by spike.lee at 2012.03.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaSecsDriver;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.SecsModeler
{
    public partial class FEquipmentStateSetDefinition : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentStateSetDefinition(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateSetDefinition(
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

        private void designTreeOfEquipmentStateSetDefinition(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("SecsDriver", Properties.Resources.SecsDriver);
                tvwTree.ImageList.Images.Add("EquipmentStateSetList_unlock", Properties.Resources.EquipmentStateSetList_unlock);
                tvwTree.ImageList.Images.Add("EquipmentStateSetList_lock", Properties.Resources.EquipmentStateSetList_lock);
                tvwTree.ImageList.Images.Add("EquipmentStateSet_unlock", Properties.Resources.EquipmentStateSet_unlock);
                tvwTree.ImageList.Images.Add("EquipmentStateSet_lock", Properties.Resources.EquipmentStateSet_lock);
                tvwTree.ImageList.Images.Add("EquipmentState_unlock", Properties.Resources.EquipmentState_unlock);
                tvwTree.ImageList.Images.Add("EquipmentState_lock", Properties.Resources.EquipmentState_lock);
                tvwTree.ImageList.Images.Add("StateValue", Properties.Resources.StateValue);
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
                        t.Key == FMenuKey.MenuEsdExpand ||
                        t.Key == FMenuKey.MenuEsdCollapse ||
                        t.Key == FMenuKey.MenuEsdRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuEsdCut ||
                        t.Key == FMenuKey.MenuEsdCopy ||                        
                        t.Key == FMenuKey.MenuEsdPasteSibling ||
                        t.Key == FMenuKey.MenuEsdPasteChild ||
                        t.Key == FMenuKey.MenuEsdRemove ||
                        t.Key == FMenuKey.MenuEsdMoveUp ||
                        t.Key == FMenuKey.MenuEsdMoveDown                          
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
                    mnuMenu.Tools[FMenuKey.MenuEsdAppendEquipmentStateSetList].SharedProps.Visible = ((FSecsDriver)fObject).canAppendChildEquipmentStateSetList;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEndPasteChild].SharedProps.Enabled = ((FSecsDriver)fObject).canPasteChildEquipmentStateSetList;
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    mnuMenu.Tools[FMenuKey.MenuEsdInsertBeforeEquipmentStateSetList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuEsdInsertAfterEquipmentStateSetList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEsdAppendEquipmentStateSet].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    mnuMenu.Tools[FMenuKey.MenuEsdInsertBeforeEquipmentStateSet].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuEsdInsertAfterEquipmentStateSet].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEsdAppendEquipmentState].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    mnuMenu.Tools[FMenuKey.MenuEsdInsertBeforeEquipmentState].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuEsdInsertAfterEquipmentState].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEsdAppendStateValue].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    mnuMenu.Tools[FMenuKey.MenuEsdInsertBeforeStateValue].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuEsdInsertAfterStateValue].SharedProps.Visible = fObject.canInsertAfter;
                }

                // --

                if (
                    fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    fObject.fObjectType == FObjectType.EquipmentStateSet ||
                    fObject.fObjectType == FObjectType.EquipmentState ||
                    fObject.fObjectType == FObjectType.StateValue
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuEsdRemove].SharedProps.Enabled = fObject.canRemove;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEsdMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuEsdMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuEsdCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuEsdCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuEsdPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                    mnuMenu.Tools[FMenuKey.MenuEsdPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
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
            FSecsDriver fScd = null;
            UltraTreeNode tNodeScd = null;
            UltraTreeNode tNodeEsl = null;
            UltraTreeNode tNodeEss = null;
            UltraTreeNode tNodeEst = null;
            UltraTreeNode tNodeStv = null;

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
                // Equipment State Set List Load
                // ***
                foreach (FEquipmentStateSetList fEsl in fScd.fChildEquipmentStateSetListCollection)
                {
                    tNodeEsl = new UltraTreeNode(fEsl.uniqueIdToString);
                    tNodeEsl.Tag = fEsl;
                    FCommon.refreshTreeNodeOfObject(fEsl, tvwTree, tNodeEsl);

                    // --

                    // ***
                    // Equipment State Set Load
                    // ***
                    foreach (FEquipmentStateSet fEss in fEsl.fChildEquipmentStateSetCollection)
                    {
                        tNodeEss = new UltraTreeNode(fEss.uniqueIdToString);
                        tNodeEss.Tag = fEss;
                        FCommon.refreshTreeNodeOfObject(fEss, tvwTree, tNodeEss);

                        // --

                        // ***
                        // Equipment State Load
                        // ***
                        foreach (FEquipmentState fEst in fEss.fChildEquipmentStateCollection)
                        {
                            tNodeEst = new UltraTreeNode(fEst.uniqueIdToString);
                            tNodeEst.Tag = fEst;
                            FCommon.refreshTreeNodeOfObject(fEst, tvwTree, tNodeEst);

                            // --

                            // ***
                            // State Value load
                            // ***
                            foreach (FStateValue fStv in fEst.fChildStateValueCollection)
                            {
                                tNodeStv = new UltraTreeNode(fStv.uniqueIdToString);
                                tNodeStv.Tag = fStv;
                                FCommon.refreshTreeNodeOfObject(fStv, tvwTree, tNodeStv);

                                // --

                                tNodeStv.Expanded = false;
                                tNodeEst.Nodes.Add(tNodeStv);
                            }

                            // --

                            tNodeEst.Expanded = false;
                            tNodeEss.Nodes.Add(tNodeEst);
                        }

                        // --

                        tNodeEss.Expanded = true;
                        tNodeEsl.Nodes.Add(tNodeEss);                        
                    }

                    // --

                    tNodeEsl.Expanded = true;
                    tNodeScd.Nodes.Add(tNodeEsl);
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
                tNodeEsl = null;
                tNodeEss = null;
                tNodeEst = null;
                tNodeStv = null;
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
                    foreach (FEquipmentStateSetList fEsl in ((FSecsDriver)fParent).fChildEquipmentStateSetListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fEsl.uniqueIdToString);
                        tNodeChild.Tag = fEsl;
                        FCommon.refreshTreeNodeOfObject(fEsl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    foreach (FEquipmentStateSet fEss in ((FEquipmentStateSetList)fParent).fChildEquipmentStateSetCollection)
                    {
                        tNodeChild = new UltraTreeNode(fEss.uniqueIdToString);
                        tNodeChild.Tag = fEss;
                        FCommon.refreshTreeNodeOfObject(fEss, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSet)
                {
                    foreach (FEquipmentState fEst in ((FEquipmentStateSet)fParent).fChildEquipmentStateCollection)
                    {
                        tNodeChild = new UltraTreeNode(fEst.uniqueIdToString);
                        tNodeChild.Tag = fEst;
                        FCommon.refreshTreeNodeOfObject(fEst, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.EquipmentState)
                {
                    foreach (FStateValue fStv in ((FEquipmentState)fParent).fChildStateValueCollection)
                    {
                        tNodeChild = new UltraTreeNode(fStv.uniqueIdToString);
                        tNodeChild.Tag = fStv;
                        FCommon.refreshTreeNodeOfObject(fStv, tvwTree, tNodeChild);
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

                if (fNewChild.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                   
                    fRefChild = ((FEquipmentStateSetList)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.EquipmentStateSet)
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
                    fRefChild = ((FEquipmentStateSet)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.EquipmentState)
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
                    fRefChild = ((FEquipmentState)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.StateValue)
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
                    fRefChild = ((FStateValue)fNewChild).fNextSibling;
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
                if (tPrevNode == null)
                {
                    return;
                }

                // --

                if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    if (((FEquipmentStateSetList)fObject).fPreviousSibling == (FEquipmentStateSetList)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    if (((FEquipmentStateSet)fObject).fPreviousSibling == (FEquipmentStateSet)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    if (((FEquipmentState)fObject).fPreviousSibling == (FEquipmentState)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    if (((FStateValue)fObject).fPreviousSibling == (FStateValue)tPrevNode.Tag)
                    {
                        return;
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
                if (tNextNode == null)
                {
                    return;
                }

                // --

                if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    if (((FEquipmentStateSetList)fObject).fNextSibling == (FEquipmentStateSetList)tNextNode.Tag)
                    {
                        return;
                    }                    
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    if (((FEquipmentStateSet)fObject).fNextSibling == (FEquipmentStateSet)tNextNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    if (((FEquipmentState)fObject).fNextSibling == (FEquipmentState)tNextNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    if (((FStateValue)fObject).fNextSibling == (FStateValue)tNextNode.Tag)
                    {
                        return;
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
                    fNewChild = ((FSecsDriver)fParent).appendChildEquipmentStateSetList(new FEquipmentStateSetList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    fNewChild = ((FEquipmentStateSetList)fParent).appendChildEquipmentStateSet(new FEquipmentStateSet(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSet)
                {
                    fNewChild = ((FEquipmentStateSet)fParent).appendChildEquipmentState(new FEquipmentState(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }
                else if (fParent.fObjectType == FObjectType.EquipmentState)
                {
                    fNewChild = ((FEquipmentState)fParent).appendChildStateValue(new FStateValue(this.m_fSsmCore.fSsmFileInfo.fSecsDriver));
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                // --
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
                    fNewChild = ((FSecsDriver)fParent).insertBeforeChildEquipmentStateSetList(
                        new FEquipmentStateSetList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FEquipmentStateSetList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    fNewChild = ((FEquipmentStateSetList)fParent).insertBeforeChildEquipmentStateSet(
                        new FEquipmentStateSet(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FEquipmentStateSet)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSet)
                {
                    fNewChild = ((FEquipmentStateSet)fParent).insertBeforeChildEquipmentState(
                        new FEquipmentState(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FEquipmentState)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.EquipmentState)
                {
                    fNewChild = ((FEquipmentState)fParent).insertBeforeChildStateValue(
                        new FStateValue(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FStateValue)fRefChild
                        );
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
                    fNewChild = ((FSecsDriver)fParent).insertAfterChildEquipmentStateSetList(
                        new FEquipmentStateSetList(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FEquipmentStateSetList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    fNewChild = ((FEquipmentStateSetList)fParent).insertAfterChildEquipmentStateSet(
                        new FEquipmentStateSet(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FEquipmentStateSet)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSet)
                {
                    fNewChild = ((FEquipmentStateSet)fParent).insertAfterChildEquipmentState(
                        new FEquipmentState(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FEquipmentState)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.EquipmentState)
                {
                    fNewChild = ((FEquipmentState)fParent).insertAfterChildStateValue(
                        new FStateValue(this.m_fSsmCore.fSsmFileInfo.fSecsDriver),
                        (FStateValue)fRefChild
                        );
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
                //Removing SECS Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FEquipmentStateSetList)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FEquipmentStateSet)fChild).locked)
                        {
                            FDebug.throwFException(m_fSsmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSet)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FEquipmentState)fChild).locked)
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
                    fChilds = new FEquipmentStateSetList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FEquipmentStateSetList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FSecsDriver)fParent).removeChildEquipmentStateSetList((FEquipmentStateSetList[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    fChilds = new FEquipmentStateSet[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FEquipmentStateSet)tvwTree.SelectedNodes[i].Tag;
                    }
                    // -- 
                    ((FEquipmentStateSetList)fParent).removeChildEquipmentStateSet((FEquipmentStateSet[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSet)
                {
                    fChilds = new FEquipmentState[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FEquipmentState)tvwTree.SelectedNodes[i].Tag;
                    }
                    // -- 
                    ((FEquipmentStateSet)fParent).removeChildEquipmentState((FEquipmentState[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.EquipmentState)
                {
                    fChilds = new FStateValue[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FStateValue)tvwTree.SelectedNodes[i].Tag;
                    }
                    // -- 
                    ((FEquipmentState)fParent).removeChildStateValue((FStateValue[])fChilds);
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

                if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    ((FEquipmentStateSetList)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    ((FEquipmentStateSet)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    ((FEquipmentState)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    ((FStateValue)fObject).moveUp();
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

                if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    ((FEquipmentStateSetList)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    ((FEquipmentStateSet)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    ((FEquipmentState)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    ((FStateValue)fObject).moveDown();
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
                    foreach (UltraTreeNode tNodeEsl in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeEsl.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeEss in tNodeEsl.Nodes)
                        {
                            tNodeEss.Expanded = true;                                    
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeEss in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeEss.Expanded = true;                        
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    tvwTree.ActiveNode.Expanded = true;
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
                    foreach (UltraTreeNode tNodeEsl in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeEss in tNodeEsl.Nodes)
                        {
                            tNodeEss.Expanded = false;
                        }
                        // --                    
                        tNodeEsl.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    foreach (UltraTreeNode tNodeEss in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeEss.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
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

                if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    ((FEquipmentStateSetList)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    ((FEquipmentStateSet)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    ((FEquipmentState)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    ((FStateValue)fObject).copy();
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

                if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    ((FEquipmentStateSetList)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    ((FEquipmentStateSet)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    ((FEquipmentState)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    ((FStateValue)fObject).cut();
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
                
                if (fRefObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    fNewObject = ((FEquipmentStateSetList)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    fNewObject = ((FEquipmentStateSet)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.EquipmentState)
                {
                    fNewObject = ((FEquipmentState)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.StateValue)
                {
                    fNewObject = ((FStateValue)fRefObject).pasteSibling();
                }
               
                // --

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

                tvwTree.beginUpdate();

                // --

                if (fParent.fObjectType == FObjectType.SecsDriver)
                {
                    fChild = ((FSecsDriver)fParent).pasteChildEquipmentStateSetList();
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    fChild = ((FEquipmentStateSetList)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.EquipmentStateSet)
                {
                    fChild = ((FEquipmentStateSet)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.EquipmentState)
                {
                    fChild = ((FEquipmentState)fParent).pasteChild();
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
            FIObject fResult = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fBase = (FIObject)tNode.Tag;

                // --

                fResult = m_fSsmCore.fSsmFileInfo.fSecsDriver.searchEquipmentStateSetSeries(fBase, searchWord);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
      
        #region FEquipmentStateSetDefinition form Event Halndla

        private void FEquipmentStateSetDefinitition_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfEquipmentStateSetDefinition();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuEsdPopupMenu]);

                // --

                m_fEventHandler = new FEventHandler(m_fSsmCore.fSsmFileInfo.fSecsDriver, tvwTree);
                // --
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
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

        private void FEquipmentStateSetDefinition_Shown(
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

        private void FEquipmentStateSetDefinition_FormClosing(
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

        #region m_fEnvetHandler Object Event Handler

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSet ||
                    e.fObject.fObjectType == FObjectType.EquipmentState ||
                    e.fObject.fObjectType == FObjectType.StateValue
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
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSet ||
                    e.fObject.fObjectType == FObjectType.EquipmentState ||
                    e.fObject.fObjectType == FObjectType.StateValue
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
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSet ||
                    e.fObject.fObjectType == FObjectType.EquipmentState ||
                    e.fObject.fObjectType == FObjectType.StateValue
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
                if(
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSet ||
                    e.fObject.fObjectType == FObjectType.EquipmentState ||
                    e.fObject.fObjectType == FObjectType.StateValue
                    )
                {
                    removeTreeOfObject(e.fObject);
                }
            }
            catch(Exception ex)
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
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSet ||
                    e.fObject.fObjectType == FObjectType.EquipmentState ||
                    e.fObject.fObjectType == FObjectType.StateValue
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
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSet ||
                    e.fObject.fObjectType == FObjectType.EquipmentState ||
                    e.fObject.fObjectType == FObjectType.StateValue
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

        private void m_fEventHandler_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.SecsDriver ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSetList ||
                    e.fObject.fObjectType == FObjectType.EquipmentStateSet ||
                    e.fObject.fObjectType == FObjectType.EquipmentState ||
                    e.fObject.fObjectType == FObjectType.StateValue          
                    )
                {
                    refreshObject(e.fObject);
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
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetList)
                {
                    pgdProp.selectedObject = new FPropEsl(m_fSsmCore, pgdProp, (FEquipmentStateSetList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSet)
                {
                    pgdProp.selectedObject = new FPropEss(m_fSsmCore, pgdProp, (FEquipmentStateSet)fObject);
                }
                else if (fObject.fObjectType == FObjectType.EquipmentState)
                {
                    pgdProp.selectedObject = new FPropEst(m_fSsmCore, pgdProp, (FEquipmentState)fObject);
                }
                else if (fObject.fObjectType == FObjectType.StateValue)
                {
                    pgdProp.selectedObject = new FPropStv(m_fSsmCore, pgdProp, (FStateValue)fObject);
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
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdCut].SharedProps.Enabled == true)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdPasteSibling].SharedProps.Enabled == true)
                    {
                        procMenuPasteSibling();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdPasteChild].SharedProps.Enabled == true)
                    {
                        procMenuPasteChild();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuEndMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuEndMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuEsdRelation].SharedProps.Enabled == true)
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetList)
                        {
                            #region EquipmentStateSetList

                            if (((FSecsDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FSecsDriver)fRefObject).fChildEquipmentStateSetListCollection.count;
                                fRefObject = ((FSecsDriver)fRefObject).fChildEquipmentStateSetListCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateSetList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetList)
                        {
                            #region EquipmentStateSetList

                            if (((FEquipmentStateSetList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FEquipmentStateSetList)fRefObject).fNextSibling == null || !((FEquipmentStateSetList)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet)
                        {
                            #region EquipmentStateSet

                            if (((FEquipmentStateSetList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FEquipmentStateSetList)fRefObject).fChildEquipmentStateSetCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FEquipmentStateSetList)fRefObject).fChildEquipmentStateSetCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateSet)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet)
                        {
                            #region EquipmentStateSet

                            if (((FEquipmentStateSet)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FEquipmentStateSet)fRefObject).fNextSibling == null || !((FEquipmentStateSet)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FEquipmentStateSet)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FEquipmentStateSet)fRefObject).Equals(((FEquipmentState)fDragDropData.fObject).fParent))
                                {
                                    cnt = ((FEquipmentStateSet)fRefObject).fChildEquipmentStateCollection.count;
                                    // --
                                    fRefObject = ((FEquipmentStateSet)fRefObject).fChildEquipmentStateCollection[cnt - 1];
                                    if (!fRefObject.Equals(fDragDropData.fObject))
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (!((FEquipmentState)fDragDropData.fObject).locked)
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
                    else if (fRefObject.fObjectType == FObjectType.EquipmentState)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FEquipmentState)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FEquipmentState)fRefObject).fParent.Equals(((FEquipmentState)fDragDropData.fObject).fParent))
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FEquipmentState)fRefObject).fNextSibling == null || !((FEquipmentState)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                        )
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (!((FEquipmentState)fDragDropData.fObject).locked)
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.StateValue)
                        {
                            #region StateValue

                            if (((FEquipmentState)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FEquipmentState)fRefObject).fChildStateValueCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FEquipmentState)fRefObject).fChildStateValueCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.StateValue)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.StateValue)
                        {
                            #region StateValue

                            if (((FStateValue)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FStateValue)fRefObject).fNextSibling == null || !((FStateValue)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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

                    if (fRefObject.fObjectType == FObjectType.SecsDriver)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetList)
                        {
                            #region EquipmentStateSetList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FSecsDriver)fRefObject).fChildEquipmentStateSetListCollection.count;
                                fRefObject = ((FSecsDriver)fRefObject).fChildEquipmentStateSetListCollection[cnt - 1];
                                ((FEquipmentStateSetList)fDragDropData.fObject).moveTo((FEquipmentStateSetList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FSecsDriver)fRefObject).pasteChildEquipmentStateSetList();
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
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateSetList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSetList)
                        {
                            #region EquipmentStateSetList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FEquipmentStateSetList)fDragDropData.fObject).moveTo((FEquipmentStateSetList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSetList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipmentStateSetList)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet)
                        {
                            #region EquipmentStateSet

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FEquipmentStateSet)fDragDropData.fObject).moveTo((FEquipmentStateSetList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSet)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipmentStateSetList)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.EquipmentStateSet)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentStateSet)
                        {
                            #region EquipmentStateSet

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FEquipmentStateSet)fDragDropData.fObject).moveTo((FEquipmentStateSet)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentStateSet)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipmentStateSet)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FEquipmentState)fDragDropData.fObject).moveTo((FEquipmentStateSet)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentState)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipmentStateSet)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.EquipmentState)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FEquipmentState)fDragDropData.fObject).moveTo((FEquipmentState)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FEquipmentState)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipmentState)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.StateValue)
                        {
                            #region StateValue

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FStateValue)fDragDropData.fObject).moveTo((FEquipmentState)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FStateValue)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FEquipmentState)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.StateValue)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.StateValue)
                        {
                            #region StateValue

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FStateValue)fDragDropData.fObject).moveTo((FStateValue)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FStateValue)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FStateValue)fRefObject).pasteSibling();
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

                if (e.Tool.Key == FMenuKey.MenuEsdExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuEsdCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuEsdCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuEsdCopy)
                {
                    procMenuCopy();
                }               
                else if (e.Tool.Key == FMenuKey.MenuEsdPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuEsdPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuEsdRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuEsdMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuEsdMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuEsdRelation)
                {
                    procMenuRelation();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEsdInsertBeforeEquipmentStateSetList ||
                    e.Tool.Key == FMenuKey.MenuEsdInsertBeforeEquipmentStateSet ||
                    e.Tool.Key == FMenuKey.MenuEsdInsertBeforeEquipmentState ||
                    e.Tool.Key == FMenuKey.MenuEsdInsertBeforeStateValue
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEsdInsertAfterEquipmentStateSetList ||
                    e.Tool.Key == FMenuKey.MenuEsdInsertAfterEquipmentStateSet ||
                    e.Tool.Key == FMenuKey.MenuEsdInsertAfterEquipmentState ||
                    e.Tool.Key == FMenuKey.MenuEsdInsertAfterStateValue
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuEsdAppendEquipmentStateSetList ||
                    e.Tool.Key == FMenuKey.MenuEsdAppendEquipmentStateSet ||
                    e.Tool.Key == FMenuKey.MenuEsdAppendEquipmentState ||
                    e.Tool.Key == FMenuKey.MenuEsdAppendStateValue
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespcae end
