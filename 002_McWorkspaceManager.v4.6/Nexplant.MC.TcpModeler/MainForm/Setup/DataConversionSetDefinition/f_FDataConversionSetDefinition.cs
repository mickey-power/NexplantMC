/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FDataConversionSetDefinition.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.02
--  Description     : FAMate TCP Modeler Data Conversion Set Definition Form Class 
--  History         : Created by spike.lee at 2012.03.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaTcpDriver;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win.UltraWinToolbars;

namespace Nexplant.MC.TcpModeler
{
    public partial class FDataConversionSetDefinition : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDataConversionSetDefinition(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataConversionSetDefinition(
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

        private void designTreeOfConversionSetDefinition(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("TcpDriver", Properties.Resources.TcpDriver);
                tvwTree.ImageList.Images.Add("DataConversionSetList_unlock", Properties.Resources.DataConversionSetList_unlock);
                tvwTree.ImageList.Images.Add("DataConversionSetList_lock", Properties.Resources.DataConversionSetList_lock);
                tvwTree.ImageList.Images.Add("DataConversionSet_unlock", Properties.Resources.DataConversionSet_unlock);
                tvwTree.ImageList.Images.Add("DataConversionSet_lock", Properties.Resources.DataConversionSet_lock);
                tvwTree.ImageList.Images.Add("DataConversion", Properties.Resources.DataConversion);
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
                        t.Key == FMenuKey.MenuDcdExpand ||
                        t.Key == FMenuKey.MenuDcdCollapse ||
                        t.Key == FMenuKey.MenuDcdRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuDcdCut ||
                        t.Key == FMenuKey.MenuDcdCopy ||
                        t.Key == FMenuKey.MenuDcdPasteSibling ||
                        t.Key == FMenuKey.MenuDcdPasteChild ||
                        t.Key == FMenuKey.MenuDcdRemove ||
                        t.Key == FMenuKey.MenuDcdMoveUp ||
                        t.Key == FMenuKey.MenuDcdMoveDown
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
                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    mnuMenu.Tools[FMenuKey.MenuDcdAppendDataConversionSetList].SharedProps.Visible = ((FTcpDriver)fObject).canAppendChildDataConversionSetList;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDcdPasteChild].SharedProps.Enabled = ((FTcpDriver)fObject).canPasteChildDataConversionSetList;
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    mnuMenu.Tools[FMenuKey.MenuDcdInsertBeforeDataConversionSetList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuDcdInsertAfterDataConversionSetList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDcdAppendDataConversionSet].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    mnuMenu.Tools[FMenuKey.MenuDcdInsertBeforeDataConversionSet].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuDcdInsertAfterDataConversionSet].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDcdAppendDataConversion].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    mnuMenu.Tools[FMenuKey.MenuDcdInsertBeforeDataConversion].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuDcdInsertAfterDataConversion].SharedProps.Visible = fObject.canInsertAfter;
                }

                // --

                if (
                    fObject.fObjectType == FObjectType.DataConversionSetList ||
                    fObject.fObjectType == FObjectType.DataConversionSet ||
                    fObject.fObjectType == FObjectType.DataConversion
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuDcdRemove].SharedProps.Enabled = fObject.canRemove;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDcdMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuDcdMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDcdCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuDcdCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuDcdPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                    mnuMenu.Tools[FMenuKey.MenuDcdPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
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
            UltraTreeNode tNodeDcl = null;
            UltraTreeNode tNodeDcs = null;
            UltraTreeNode tNodeDcv = null;

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
                // Data Conversion Set List Load
                // ***
                foreach (FDataConversionSetList fDcl in fTcd.fChildDataConversionSetListCollection)
                {
                    tNodeDcl = new UltraTreeNode(fDcl.uniqueIdToString);
                    tNodeDcl.Tag = fDcl;
                    FCommon.refreshTreeNodeOfObject(fDcl, tvwTree, tNodeDcl);

                    // --

                    // ***
                    // Data Conversion Set Load
                    // ***
                    foreach (FDataConversionSet fDcs in fDcl.fChildDataConversionSetCollection)
                    {
                        tNodeDcs = new UltraTreeNode(fDcs.uniqueIdToString);
                        tNodeDcs.Tag = fDcs;
                        FCommon.refreshTreeNodeOfObject(fDcs, tvwTree, tNodeDcs); 
                        
                        // --

                        // ***
                        // Equipment State Load
                        // ***
                        foreach (FDataConversion fDcv in fDcs.fChildDataConversionCollection)
                        {
                            tNodeDcv = new UltraTreeNode(fDcv.uniqueIdToString);
                            tNodeDcv.Tag = fDcv;
                            FCommon.refreshTreeNodeOfObject(fDcv, tvwTree, tNodeDcv);

                            // --

                            tNodeDcv.Expanded = false;
                            tNodeDcs.Nodes.Add(tNodeDcv);
                        }

                        // --

                        tNodeDcs.Expanded = true;
                        tNodeDcl.Nodes.Add(tNodeDcs);
                    }

                    // --

                    tNodeDcl.Expanded = true;
                    tNodeTcd.Nodes.Add(tNodeDcl);
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
                tNodeDcl = null;
                tNodeDcs = null;
                tNodeDcv = null;
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
                    foreach (FDataConversionSetList fDcl in ((FTcpDriver)fParent).fChildDataConversionSetListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDcl.uniqueIdToString);
                        tNodeChild.Tag = fDcl;
                        FCommon.refreshTreeNodeOfObject(fDcl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSetList)
                {
                    foreach (FDataConversionSet fDcs in ((FDataConversionSetList)fParent).fChildDataConversionSetCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDcs.uniqueIdToString);
                        tNodeChild.Tag = fDcs;
                        FCommon.refreshTreeNodeOfObject(fDcs, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSet)
                {
                    foreach (FDataConversion fDcv in ((FDataConversionSet)fParent).fChildDataConversionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDcv.uniqueIdToString);
                        tNodeChild.Tag = fDcv;
                        FCommon.refreshTreeNodeOfObject(fDcv, tvwTree, tNodeChild);
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

                if (fNewChild.fObjectType == FObjectType.DataConversionSetList)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                        tNodeParent == null ||
                        tNodeParent.Nodes.Count != ((FTcpDriver)fParent).fChildDataConversionSetListCollection.count - 1
                        )
                    {
                        return;
                    }
                    fRefChild = ((FDataConversionSetList)fNewChild).fNextSibling;
                }

                else if (fNewChild.fObjectType == FObjectType.DataConversionSet)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                        tNodeParent == null ||
                        tNodeParent.Nodes.Count != ((FDataConversionSetList)fParent).fChildDataConversionSetCollection.count - 1
                        )
                    {
                        return;
                    }
                    fRefChild = ((FDataConversionSet)fNewChild).fNextSibling;
                }

                else if (fNewChild.fObjectType == FObjectType.DataConversion)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);
                    if (
                        tNodeParent == null ||
                        tNodeParent.Nodes.Count != ((FDataConversionSet)fParent).fChildDataConversionCollection.count - 1
                        )
                    {
                        return;
                    }
                    fRefChild = ((FDataConversion)fNewChild).fNextSibling;
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

                if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    if (((FDataConversionSetList)fObject).fPreviousSibling == (FDataConversionSetList)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    if (((FDataConversionSet)fObject).fPreviousSibling == (FDataConversionSet)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    if (((FDataConversion)fObject).fPreviousSibling == (FDataConversion)tPrevNode.Tag)
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

                if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    if (((FDataConversionSetList)fObject).fNextSibling == (FDataConversionSetList)tNextNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    if (((FDataConversionSet)fObject).fNextSibling == (FDataConversionSet)tNextNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    if (((FDataConversion)fObject).fNextSibling == (FDataConversion)tNextNode.Tag)
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

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).appendChildDataConversionSetList(new FDataConversionSetList(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSetList)
                {
                    fNewChild = ((FDataConversionSetList)fParent).appendChildDataConversionSet(new FDataConversionSet(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSet)
                {
                    fNewChild = ((FDataConversionSet)fParent).appendChildDataConversion(new FDataConversion(this.m_fTcmCore.fTcmFileInfo.fTcpDriver));
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

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).insertBeforeChildDataConversionSetList(
                        new FDataConversionSetList(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FDataConversionSetList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSetList)
                {
                    fNewChild = ((FDataConversionSetList)fParent).insertBeforeChildDataConversionSet(
                        new FDataConversionSet(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FDataConversionSet)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSet)
                {
                    fNewChild = ((FDataConversionSet)fParent).insertBeforeChildDataConversion(
                        new FDataConversion(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FDataConversion)fRefChild
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

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fNewChild = ((FTcpDriver)fParent).insertAfterChildDataConversionSetList(
                        new FDataConversionSetList(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FDataConversionSetList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSetList)
                {
                    fNewChild = ((FDataConversionSetList)fParent).insertAfterChildDataConversionSet(
                        new FDataConversionSet(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FDataConversionSet)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSet)
                {
                    fNewChild = ((FDataConversionSet)fParent).insertAfterChildDataConversion(
                        new FDataConversion(this.m_fTcmCore.fTcmFileInfo.fTcpDriver),
                        (FDataConversion)fRefChild
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
                // Removing TCP Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FDataConversionSetList)fChild).locked)
                        {
                            FDebug.throwFException(m_fTcmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSetList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FDataConversionSet)fChild).locked)
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
                    fChilds = new FDataConversionSetList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FDataConversionSetList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FTcpDriver)fParent).removeChildDataConversionSetList((FDataConversionSetList[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSetList)
                {
                    fChilds = new FDataConversionSet[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FDataConversionSet)tvwTree.SelectedNodes[i].Tag;
                    }
                    // -- 
                    ((FDataConversionSetList)fParent).removeChildDataConversionSet((FDataConversionSet[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSet)
                {
                    fChilds = new FDataConversion[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FDataConversion)tvwTree.SelectedNodes[i].Tag;
                    }
                    // -- 
                    ((FDataConversionSet)fParent).removeChildDataConversion((FDataConversion[])fChilds);
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

                if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    ((FDataConversionSetList)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    ((FDataConversionSet)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    ((FDataConversion)fObject).moveUp();
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

                if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    ((FDataConversionSetList)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    ((FDataConversionSet)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    ((FDataConversion)fObject).moveDown();
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
                    foreach (UltraTreeNode tNodeDcl in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeDcl.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeDcs in tNodeDcl.Nodes)
                        {
                            tNodeDcs.Expanded = true;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeDcs in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeDcs.Expanded = true;
                    }
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
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

                if (fObject.fObjectType == FObjectType.TcpDriver)
                {
                    foreach (UltraTreeNode tNodeDcl in tvwTree.ActiveNode.Nodes)
                    {
                        foreach (UltraTreeNode tNodeDcs in tNodeDcl.Nodes)
                        {
                            tNodeDcs.Expanded = false;
                        }
                        // --                    
                        tNodeDcl.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    foreach (UltraTreeNode tNodeDcs in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeDcs.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
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

                if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    ((FDataConversionSetList)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    ((FDataConversionSet)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    ((FDataConversion)fObject).copy();
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

                if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    ((FDataConversionSetList)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    ((FDataConversionSet)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    ((FDataConversion)fObject).cut();
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

                if (fRefObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    fNewObject = ((FDataConversionSetList)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.DataConversionSet)
                {
                    fNewObject = ((FDataConversionSet)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.DataConversion)
                {
                    fNewObject = ((FDataConversion)fRefObject).pasteSibling();
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

                if (fParent.fObjectType == FObjectType.TcpDriver)
                {
                    fChild = ((FTcpDriver)fParent).pasteChildDataConversionSetList();
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSetList)
                {
                    fChild = ((FDataConversionSetList)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.DataConversionSet)
                {
                    fChild = ((FDataConversionSet)fParent).pasteChild();
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

                fResult = m_fTcmCore.fTcmFileInfo.fTcpDriver.searchDataConversionSetSeries(fBase, searchWord);
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

        #region FDataConversionSetDefinition Form Event Handler

        private void FDataConversionSetDefinition_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfConversionSetDefinition();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuDcdPopupMenu]);

                // --

                m_fEventHandler = new FEventHandler(m_fTcmCore.fTcmFileInfo.fTcpDriver, tvwTree);
                // --
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
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

        private void FDataConversionSetDefinition_Shown(
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

        private void FDataConversionSetDefinition_FormClosing(
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

        #region m_fEnvetHandler Object Event Handler

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.DataConversionSetList ||
                    e.fObject.fObjectType == FObjectType.DataConversionSet ||
                    e.fObject.fObjectType == FObjectType.DataConversion
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
                    e.fObject.fObjectType == FObjectType.DataConversionSetList ||
                    e.fObject.fObjectType == FObjectType.DataConversionSet ||
                    e.fObject.fObjectType == FObjectType.DataConversion
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
                    e.fObject.fObjectType == FObjectType.DataConversionSetList ||
                    e.fObject.fObjectType == FObjectType.DataConversionSet ||
                    e.fObject.fObjectType == FObjectType.DataConversion
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
                    e.fObject.fObjectType == FObjectType.DataConversionSetList ||
                    e.fObject.fObjectType == FObjectType.DataConversionSet ||
                    e.fObject.fObjectType == FObjectType.DataConversion
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
                    e.fObject.fObjectType == FObjectType.DataConversionSetList ||
                    e.fObject.fObjectType == FObjectType.DataConversionSet ||
                    e.fObject.fObjectType == FObjectType.DataConversion
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
                    e.fObject.fObjectType == FObjectType.DataConversionSetList ||
                    e.fObject.fObjectType == FObjectType.DataConversionSet ||
                    e.fObject.fObjectType == FObjectType.DataConversion
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

        private void m_fEventHandler_ObjectModifyCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.TcpDriver ||
                    e.fObject.fObjectType == FObjectType.DataConversionSetList ||
                    e.fObject.fObjectType == FObjectType.DataConversionSet ||
                    e.fObject.fObjectType == FObjectType.DataConversion
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
                else if (fObject.fObjectType == FObjectType.DataConversionSetList)
                {
                    pgdProp.selectedObject = new FPropDcl(m_fTcmCore, pgdProp, (FDataConversionSetList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.DataConversionSet)
                {
                    pgdProp.selectedObject = new FPropDcs(m_fTcmCore, pgdProp, (FDataConversionSet)fObject);
                }
                else if (fObject.fObjectType == FObjectType.DataConversion)
                {
                    pgdProp.selectedObject = new FPropDcv(m_fTcmCore, pgdProp, (FDataConversion)fObject);
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
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdCut].SharedProps.Enabled == true)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdPasteSibling].SharedProps.Enabled == true)
                    {
                        procMenuPasteSibling();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdPasteChild].SharedProps.Enabled == true)
                    {
                        procMenuPasteChild();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuEndMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuEndMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDcdRelation].SharedProps.Enabled == true)
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSetList)
                        {
                            #region DataConversionSetList

                            if (((FTcpDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FTcpDriver)fRefObject).fChildDataConversionSetListCollection.count;
                                fRefObject = ((FTcpDriver)fRefObject).fChildDataConversionSetListCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.DataConversionSetList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSetList)
                        {
                            #region DataConversionSetList

                            if (((FDataConversionSetList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FDataConversionSetList)fRefObject).fNextSibling == null || !((FDataConversionSetList)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (((FDataConversionSetList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FDataConversionSetList)fRefObject).fChildDataConversionSetCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FDataConversionSetList)fRefObject).fChildDataConversionSetCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.DataConversionSet)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (((FDataConversionSet)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FDataConversionSet)fRefObject).fNextSibling == null || !((FDataConversionSet)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversion)
                        {
                            #region DataConversion

                            if (((FDataConversionSet)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FDataConversionSet)fRefObject).fChildDataConversionCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FDataConversionSet)fRefObject).fChildDataConversionCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.DataConversion)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataConversion)
                        {
                            #region DataConversion

                            if (((FDataConversion)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FDataConversion)fRefObject).fNextSibling == null || !((FDataConversion)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSetList)
                        {
                            #region DataConversionSetList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FTcpDriver)fRefObject).fChildDataConversionSetListCollection.count;
                                fRefObject = ((FTcpDriver)fRefObject).fChildDataConversionSetListCollection[cnt - 1];
                                ((FDataConversionSetList)fDragDropData.fObject).moveTo((FDataConversionSetList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataConversionSetList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FTcpDriver)fRefObject).pasteChildDataConversionSetList();
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
                    else if (fRefObject.fObjectType == FObjectType.DataConversionSetList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSetList)
                        {
                            #region DataConversionSetList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FDataConversionSetList)fDragDropData.fObject).moveTo((FDataConversionSetList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataConversionSetList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FDataConversionSetList)fRefObject).pasteSibling();
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

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FDataConversionSet)fDragDropData.fObject).moveTo((FDataConversionSetList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataConversionSet)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FDataConversionSetList)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.DataConversionSet)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataConversionSet)
                        {
                            #region DataConversionSet

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FDataConversionSet)fDragDropData.fObject).moveTo((FDataConversionSet)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataConversionSet)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FDataConversionSet)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataConversion)
                        {
                            #region DataConversion

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FDataConversion)fDragDropData.fObject).moveTo((FDataConversionSet)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataConversion)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FDataConversionSet)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.DataConversion)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataConversion)
                        {
                            #region DataConversion

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FDataConversion)fDragDropData.fObject).moveTo((FDataConversion)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataConversion)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FDataConversion)fRefObject).pasteSibling();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                if (e.Tool.Key == FMenuKey.MenuDcdExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuDcdCollapse)
                {
                    procMenuCollapse();
                }
                else if (e.Tool.Key == FMenuKey.MenuDcdCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuDcdCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuDcdPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuDcdPasteChild)
                {
                    procMenuPasteChild();
                }
                else if (e.Tool.Key == FMenuKey.MenuDcdRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuDcdMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuDcdMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuDcdRelation)
                {
                    procMenuRelation();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuDcdInsertBeforeDataConversionSetList ||
                    e.Tool.Key == FMenuKey.MenuDcdInsertBeforeDataConversionSet ||
                    e.Tool.Key == FMenuKey.MenuDcdInsertBeforeDataConversion
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuDcdInsertAfterDataConversionSetList ||
                    e.Tool.Key == FMenuKey.MenuDcdInsertAfterDataConversionSet ||
                    e.Tool.Key == FMenuKey.MenuDcdInsertAfterDataConversion
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuDcdAppendDataConversionSetList ||
                    e.Tool.Key == FMenuKey.MenuDcdAppendDataConversionSet ||
                    e.Tool.Key == FMenuKey.MenuDcdAppendDataConversion
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
}   // Namespcae end
