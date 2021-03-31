/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFunctionNameDefinition.cs
--  Creator         : duchoi
--  Create Date     : 2013.07.17
--  Description     : FAMate OPC Modeler Function Name Definition Form Class 
--  History         : Created by duchoi at 2013.07.17
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
    public partial class FFunctionNameDefinition : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Class Construction and Destruction

        public FFunctionNameDefinition(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFunctionNameDefinition(
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

        private void designTreeOfFunctionNameDefinition(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwTree.ImageList.Images.Add("FunctionNameList", Properties.Resources.OmdFunctionNameList);
                tvwTree.ImageList.Images.Add("FunctionName", Properties.Resources.OmdFunctionName);
                tvwTree.ImageList.Images.Add("ParameterName", Properties.Resources.OmdParameterName);
                tvwTree.ImageList.Images.Add("Argument", Properties.Resources.OmdArgument);
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
                        t.Key == FMenuKey.MenuFndExpand ||
                        t.Key == FMenuKey.MenuFndCollapse ||
                        t.Key == FMenuKey.MenuFndRelation
                        )
                    {
                        continue;
                    }
                    else if (                        
                        t.Key == FMenuKey.MenuFndCut ||
                        t.Key == FMenuKey.MenuFndCopy ||         
                        t.Key == FMenuKey.MenuFndPasteSibling||
                        t.Key == FMenuKey.MenuFndPasteChild ||
                        t.Key == FMenuKey.MenuFndRemove ||
                        t.Key == FMenuKey.MenuFndMoveUp ||
                        t.Key == FMenuKey.MenuFndMoveDown 
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
                    mnuMenu.Tools[FMenuKey.MenuFndAppendFunctionNameList].SharedProps.Visible = ((FOpcDriver)fObject).canAppendChildFunctionNameList;
                    // -- 
                    mnuMenu.Tools[FMenuKey.MenuFndPasteChild].SharedProps.Enabled = ((FOpcDriver)fObject).canPasteChildFunctionNameList;
                }
                else if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    mnuMenu.Tools[FMenuKey.MenuFndInsertBeforeFunctionNameList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuFndInsertAfterFunctionNameList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuFndAppendFunctionName].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    mnuMenu.Tools[FMenuKey.MenuFndInsertBeforeFunctionName].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuFndInsertAfterFunctionName].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuFndAppendParameterName].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    mnuMenu.Tools[FMenuKey.MenuFndInsertBeforeParameterName].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuFndInsertAfterParameterName].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuFndAppendArgument].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    mnuMenu.Tools[FMenuKey.MenuFndInsertBeforeArgument].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuFndInsertAfterArgument].SharedProps.Visible = fObject.canInsertAfter;
                }

                if (
                    fObject.fObjectType == FObjectType.FunctionNameList ||
                    fObject.fObjectType == FObjectType.FunctionName ||
                    fObject.fObjectType == FObjectType.ParameterName ||
                    fObject.fObjectType == FObjectType.Argument
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuFndRemove].SharedProps.Enabled = fObject.canRemove;
                    //--
                    mnuMenu.Tools[FMenuKey.MenuFndMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuFndMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuFndCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuFndCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuFndPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                    mnuMenu.Tools[FMenuKey.MenuFndPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
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
            UltraTreeNode tNodeFnl = null;
            UltraTreeNode tNodeFna = null;
            UltraTreeNode tNodePna = null;
            UltraTreeNode tNodeArg = null;

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
                // Function Name list Load
                //***
                foreach (FFunctionNameList fFnl in fOcd.fChildFunctionNameListCollection)
                {
                    tNodeFnl = new UltraTreeNode(fFnl.uniqueIdToString);
                    tNodeFnl.Tag = fFnl;
                    FCommon.refreshTreeNodeOfObject(fFnl, tvwTree, tNodeFnl);

                    // --

                    // ***
                    // Function Name Load
                    // ***
                    foreach (FFunctionName fFna in fFnl.fChildFunctionNameCollection)
                    {
                        tNodeFna = new UltraTreeNode(fFna.uniqueIdToString);
                        tNodeFna.Tag = fFna;
                        FCommon.refreshTreeNodeOfObject(fFna, tvwTree, tNodeFna);

                        // --

                        // ***
                        // Parameter Name Load
                        // ***
                        foreach (FParameterName fPna in fFna.fChildParameterNameCollection)
                        {
                            tNodePna = new UltraTreeNode(fPna.uniqueIdToString);
                            tNodePna.Tag = fPna;
                            FCommon.refreshTreeNodeOfObject(fPna,tvwTree, tNodePna);

                            // --

                            // ***
                            // Argument Load
                            // ***
                            foreach (FArgument fArg in fPna.fChildFArgumentCollection)
                            {
                                tNodeArg = new UltraTreeNode(fArg.uniqueIdToString);
                                tNodeArg.Tag = fArg;
                                FCommon.refreshTreeNodeOfObject(fArg, tvwTree, tNodeArg);
                                // --
                                tNodeArg.Expanded = false;
                                tNodePna.Nodes.Add(tNodeArg);
                            }

                            // --

                            tNodePna.Expanded = false;
                            tNodeFna.Nodes.Add(tNodePna);
                        }

                        // --

                        tNodeFna.Expanded = true;
                        tNodeFnl.Nodes.Add(tNodeFna);
                    }

                    // --

                    tNodeFnl.Expanded = true;
                    tNodeOcd.Nodes.Add(tNodeFnl);
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
                tNodeFnl = null;
                tNodeFna = null;
                tNodePna = null;
                tNodeArg = null;
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
                    foreach (FFunctionNameList fFnl in ((FOpcDriver)fParent).fChildFunctionNameListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fFnl.uniqueIdToString);
                        tNodeChild.Tag = fFnl;
                        FCommon.refreshTreeNodeOfObject(fFnl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.FunctionNameList)
                {
                    foreach (FFunctionName fFna in ((FFunctionNameList)fParent).fChildFunctionNameCollection)
                    {
                        tNodeChild = new UltraTreeNode(fFna.uniqueIdToString);
                        tNodeChild.Tag = fFna;
                        FCommon.refreshTreeNodeOfObject(fFna, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.FunctionName)
                {
                    foreach (FParameterName fPna in ((FFunctionName)fParent).fChildParameterNameCollection)
                    {
                        tNodeChild = new UltraTreeNode(fPna.uniqueIdToString);
                        tNodeChild.Tag = fPna;
                        FCommon.refreshTreeNodeOfObject(fPna, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.ParameterName)
                {
                    foreach (FArgument FArg in ((FParameterName)fParent).fChildFArgumentCollection)
                    {
                        tNodeChild = new UltraTreeNode(FArg.uniqueIdToString);
                        tNodeChild.Tag = FArg;
                        FCommon.refreshTreeNodeOfObject(FArg, tvwTree, tNodeChild);
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

                if (fNewChild.fObjectType == FObjectType.FunctionNameList)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                    
                    fRefChild = ((FFunctionNameList)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.FunctionName)
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
                    fRefChild = ((FFunctionName)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.ParameterName)
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
                    fRefChild = ((FParameterName)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.Argument)
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
                    fRefChild = ((FArgument)fNewChild).fNextSibling;
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

                loadTreeOfChildObject(tNodeNewChild);

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

                tvwTree.endUpdate();
            }
            catch (Exception ex)
            {
                tvwTree.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    if (((FFunctionNameList)fObject).fPreviousSibling == (FFunctionNameList)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    if (((FFunctionName)fObject).fPreviousSibling == (FFunctionName)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    if (((FParameterName)fObject).fPreviousSibling == (FParameterName)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    if (((FArgument)fObject).fPreviousSibling == (FArgument)tPrevNode.Tag)
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
                // --
                if (tNextNode == null)
                {
                    return;
                }

                // --

                if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    if (((FFunctionNameList)fObject).fNextSibling == (FFunctionNameList)tNextNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    if (((FFunctionName)fObject).fNextSibling == (FFunctionName)tNextNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    if (((FParameterName)fObject).fNextSibling == (FParameterName)tNextNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    if (((FArgument)fObject).fNextSibling == (FArgument)tNextNode.Tag)
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

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).appendChildFuntionNameList(new FFunctionNameList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.FunctionNameList)
                {
                    fNewChild = ((FFunctionNameList)fParent).appendChildFuncionName(new FFunctionName(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.FunctionName)
                {
                    fNewChild = ((FFunctionName)fParent).appendChildParameterName(new FParameterName(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.ParameterName)
                {
                    fNewChild = ((FParameterName)fParent).appendChildArgument(new FArgument(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
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
            UltraTreeNode tNodeRefChlid = null;
            UltraTreeNode tNodeNewChlid = null;
            FIObject fParent = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;

            try
            {

                tvwTree.beginUpdate();

                // --

                tNodeRefChlid = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChlid.Parent;
                fRefChild = (FIObject)tNodeRefChlid.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertBeforeChildFunctionNameList(
                        new FFunctionNameList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FFunctionNameList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.FunctionNameList)
                {
                    fNewChild = ((FFunctionNameList)fParent).insertBeforeChildFunctionName(
                        new FFunctionName(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FFunctionName)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.FunctionName)
                {
                    fNewChild = ((FFunctionName)fParent).insertBeforeChildParameterName(
                        new FParameterName(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FParameterName)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.ParameterName)
                {
                    fNewChild = ((FParameterName)fParent).insertBeforeChildArgument(
                        new FArgument(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FArgument)fRefChild
                        );
                }
                // --

                tNodeNewChlid = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChlid.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChlid);
                tNodeParent.Nodes.Insert(tNodeRefChlid.Index, tNodeNewChlid);
                
                // --
                
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChlid;

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
                tNodeNewChlid = null;
                tNodeRefChlid = null;
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
            UltraTreeNode tNodeRefChlid = null;
            UltraTreeNode tNodeNewChlid = null;
            FIObject fParent = null;
            FIObject fRefChild = null;
            FIObject fNewChild = null;

            try
            {

                tvwTree.beginUpdate();

                // --

                tNodeRefChlid = tvwTree.ActiveNode;
                tNodeParent = tNodeRefChlid.Parent;
                fRefChild = (FIObject)tNodeRefChlid.Tag;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertAfterChildFunctionNameList(
                        new FFunctionNameList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FFunctionNameList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.FunctionNameList)
                {
                    fNewChild = ((FFunctionNameList)fParent).insertAfterChildFunctionName(
                        new FFunctionName(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FFunctionName)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.FunctionName)
                {
                    fNewChild = ((FFunctionName)fParent).insertAfterChildParameterName(
                        new FParameterName(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FParameterName)fRefChild
                        );                   
                }
                else if (fParent.fObjectType == FObjectType.ParameterName)
                {
                    fNewChild = ((FParameterName)fParent).insertAfterChildArgument(
                        new FArgument(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FArgument)fRefChild
                        );
                }

                // --

                tNodeNewChlid = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChlid.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChlid);
                tNodeParent.Nodes.Insert(tNodeRefChlid.Index+1, tNodeNewChlid);
                
                // --
               
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChlid;

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
                tNodeNewChlid = null;
                tNodeRefChlid = null;
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
                // removing OPC Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;                       
                    }
                }
                else if (fParent.fObjectType == FObjectType.FunctionNameList)
                {
                    foreach(UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                    }
                }
                else if (fParent.fObjectType == FObjectType.FunctionName)
                {
                    foreach(UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild=(FIObject)tNode.Tag;
                    }
                }
                else if (fParent.fObjectType == FObjectType.ParameterName)
                {
                    foreach(UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                    }
                }

                // --

                // ***
                // Remove OPC Object 가 1개 이상일경우 사용자에게 Confirm를 받는다.
                // ***
                if(tvwTree.SelectedNodes.Count>1)
                {
                    dialogResult = FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fOpmCore.fWsmCore.fUIWizard.generateMessage("Q0004", new object[] { "Object" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        m_fOpmCore.fWsmCore.fWsmContainer
                        );
                    if(dialogResult == System.Windows.Forms.DialogResult.No)
                    {
                        return;
                    }
                }

                // --

                // ***
                // OPC Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fChilds = new FFunctionNameList[tvwTree.SelectedNodes.Count];
                    // --
                    for(int i = 0; i<tvwTree.SelectedNodes.Count;i++)
                    {
                        fChilds[i] = (FFunctionNameList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcDriver)fParent).removeChildFunctionNameList((FFunctionNameList[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.FunctionNameList)
                {
                    fChilds = new FFunctionName[tvwTree.SelectedNodes.Count];
                    // --
                    for(int i = 0; i< tvwTree.SelectedNodes.Count;i++)
                    {
                        fChilds[i] = (FFunctionName)tvwTree.SelectedNodes[i].Tag;
                    }
                    ((FFunctionNameList)fParent).removeChildFunctionName((FFunctionName[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.FunctionName)
                {
                    fChilds = new FParameterName[tvwTree.SelectedNodes.Count];
                    // --
                    for(int i = 0; i<tvwTree.SelectedNodes.Count;i++)
                    {
                        fChilds[i]= (FParameterName)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FFunctionName)fParent).removeChildParameterName((FParameterName[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.ParameterName)
                {
                    fChilds = new FArgument[tvwTree.SelectedNodes.Count];
                    // --
                    for(int i = 0; i<tvwTree.SelectedNodes.Count;i++)
                    {
                        fChilds[i] = (FArgument)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FParameterName)fParent).removeChildArgument((FArgument[])fChilds);
                }

                // --

                tvwTree.beginUpdate();
                
                // --

                foreach(FIObject f in fChilds)
                {
                    tvwTree.GetNodeByKey(f.uniqueIdToString).Remove();
                }

                // --
                refreshObject(fParent);
                // ***
                // 모든 자식 노드가 삭제될 경우 Parent Node가 Active되게 처리
                // (그렇지 않을 경우 Root Node가 Active되나 Active Event가 발생하지 않음)
                // ***
                if(tNodeParent.Nodes.Count == 0)
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

                if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    ((FFunctionNameList)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    ((FFunctionName)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    ((FParameterName)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    ((FArgument)fObject).moveUp();
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

                if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    ((FFunctionNameList)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    ((FFunctionName)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    ((FParameterName)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    ((FArgument)fObject).moveDown();
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

        private void procMenuCopy(
            string menuKey
            )
        {
            UltraTreeNode tNode = null;
            FIObject fObject = null;

            try
            {
                tNode = tvwTree.ActiveNode;
                fObject = (FIObject)tNode.Tag;

                // --                

                if (fObject.fObjectType == FObjectType.OpcDriver)
                {

                }
                else if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    ((FFunctionNameList)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    ((FFunctionName)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    ((FParameterName)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    ((FArgument)fObject).copy();
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
            string menuKey
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

                if (fObject.fObjectType == FObjectType.OpcDriver)
                {

                }
                else if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    ((FFunctionNameList)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    ((FFunctionName)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    ((FParameterName)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    ((FArgument)fObject).cut();
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

        private void procMenuPasteChild(
            string menuKey
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

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fChild = ((FOpcDriver)fParent).pasteChildFunctionNameList();
                }
                else if (fParent.fObjectType == FObjectType.FunctionNameList)
                {
                    fChild = ((FFunctionNameList)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.FunctionName)
                {
                    fChild = ((FFunctionName)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.ParameterName)
                {
                    fChild = ((FParameterName)fParent).pasteChild();
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
                fParent = null;
                tNodeChild = null;
                fChild = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuPasteSibling(
            string menuKey
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
                if (fRefObject.fObjectType == FObjectType.FunctionNameList)
                {
                    fNewObject = ((FFunctionNameList)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.FunctionName)
                {
                    fNewObject = ((FFunctionName)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.ParameterName)
                {
                    fNewObject = ((FParameterName)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.Argument)
                {
                    fNewObject = ((FArgument)fRefObject).pasteSibling();
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

                fResult = m_fOpmCore.fOpmFileInfo.fOpcDriver.searchFunctionNameSeries(fBase, searchWord);
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

        #region FFunctionNameDefinition Form Event Handler

        private void FFunctionNameDefinition_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfFunctionNameDefinition();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuFndPopupMenu]);

                // -- 

                m_fEventHandler = new FEventHandler(m_fOpmCore.fOpmFileInfo.fOpcDriver, tvwTree);
                // --
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
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

        private void FFunctionNameDefinition_Shown(
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

        private void FFunctionNameDefinition_FormClosing(
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
                    e.fObject.fObjectType == FObjectType.FunctionNameList ||
                    e.fObject.fObjectType == FObjectType.FunctionName ||
                    e.fObject.fObjectType == FObjectType.ParameterName ||
                    e.fObject.fObjectType == FObjectType.Argument
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
                    e.fObject.fObjectType == FObjectType.FunctionNameList ||
                    e.fObject.fObjectType == FObjectType.FunctionName ||
                    e.fObject.fObjectType == FObjectType.ParameterName ||
                    e.fObject.fObjectType == FObjectType.Argument
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
                    e.fObject.fObjectType == FObjectType.FunctionNameList ||
                    e.fObject.fObjectType == FObjectType.FunctionName ||
                    e.fObject.fObjectType == FObjectType.ParameterName ||
                    e.fObject.fObjectType == FObjectType.Argument
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
                    e.fObject.fObjectType == FObjectType.FunctionNameList ||
                    e.fObject.fObjectType == FObjectType.FunctionName ||
                    e.fObject.fObjectType == FObjectType.ParameterName ||
                    e.fObject.fObjectType == FObjectType.Argument
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
                    e.fObject.fObjectType == FObjectType.FunctionNameList ||
                    e.fObject.fObjectType == FObjectType.FunctionName ||
                    e.fObject.fObjectType == FObjectType.ParameterName ||
                    e.fObject.fObjectType == FObjectType.Argument
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
                    e.fObject.fObjectType == FObjectType.FunctionNameList ||
                    e.fObject.fObjectType == FObjectType.FunctionName ||
                    e.fObject.fObjectType == FObjectType.ParameterName ||
                    e.fObject.fObjectType == FObjectType.Argument
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
        private void m_fEventHandler_ObjectModifyCompleted(
          object sender,
          FObjectEventArgs e
          )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcDriver ||
                    e.fObject.fObjectType == FObjectType.FunctionNameList ||
                    e.fObject.fObjectType == FObjectType.FunctionName ||
                    e.fObject.fObjectType == FObjectType.ParameterName ||
                    e.fObject.fObjectType == FObjectType.Argument
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

        #region tvwTreeControl Event Handler

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

                //  --

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
                else if (fObject.fObjectType == FObjectType.FunctionNameList)
                {
                    pgdProp.selectedObject = new FPropFnl(m_fOpmCore, pgdProp, (FFunctionNameList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.FunctionName)
                {
                    pgdProp.selectedObject = new FPropFna(m_fOpmCore, pgdProp, (FFunctionName)fObject);
                }
                else if (fObject.fObjectType == FObjectType.ParameterName)
                {
                    pgdProp.selectedObject = new FPropPna(m_fOpmCore, pgdProp, (FParameterName)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Argument)
                {
                    pgdProp.selectedObject = new FPropArg(m_fOpmCore, pgdProp, (FArgument)fObject);
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
                if (e.KeyCode == Keys.Delete)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndCut].SharedProps.Enabled == true)
                    {
                        procMenuCut(FMenuKey.MenuFndCut);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy(FMenuKey.MenuFndCopy);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndPasteSibling].SharedProps.Enabled == true)
                    {
                        procMenuPasteSibling(FMenuKey.MenuFndPasteSibling);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndPasteChild].SharedProps.Enabled == true)
                    {
                        procMenuPasteChild(FMenuKey.MenuFndPasteChild);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuFndMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuFndMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuFndRelation].SharedProps.Enabled == true)
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.FunctionNameList)
                        {
                            #region FunctionNameList

                            if (((FOpcDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildFunctionNameListCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildFunctionNameListCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.FunctionNameList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.FunctionNameList)
                        {
                            #region FunctionNameList

                            if (((FFunctionNameList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FFunctionNameList)fRefObject).fNextSibling == null || !((FFunctionNameList)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (((FFunctionNameList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FFunctionNameList)fRefObject).fChildFunctionNameCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FFunctionNameList)fRefObject).fChildFunctionNameCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.FunctionName)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (((FFunctionName)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FFunctionName)fRefObject).fNextSibling == null || !((FFunctionName)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.ParameterName)
                        {
                            #region ParameterName

                            if (((FFunctionName)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FFunctionName)fRefObject).Equals(((FParameterName)fDragDropData.fObject).fParent) ||
                                    ((FFunctionName)fRefObject).canAppendChild
                                    )
                                {
                                    cnt = ((FFunctionName)fRefObject).fChildParameterNameCollection.count;
                                    if (cnt == 0)
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                    else
                                    {
                                        fRefObject = ((FFunctionName)fRefObject).fChildParameterNameCollection[cnt - 1];
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
                                if (((FFunctionName)fRefObject).canAppendChild)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }                                
                            }

                            #endregion
                        }
                    }
                    else if (fRefObject.fObjectType == FObjectType.ParameterName)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.ParameterName)
                        {
                            #region ParameterName

                            if (((FParameterName)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FParameterName)fRefObject).fParent.Equals(((FParameterName)fDragDropData.fObject).fParent) ||
                                    ((FParameterName)fRefObject).fParent.canAppendChild
                                    )
                                {
                                    if (
                                        !fRefObject.Equals(fDragDropData.fObject) &&
                                        (((FParameterName)fRefObject).fNextSibling == null || !((FParameterName)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
                                        )
                                    {
                                        e.Effect = DragDropEffects.Move;
                                        return;
                                    }
                                }                                
                            }
                            else
                            {
                                if (((FParameterName)fRefObject).fParent.canAppendChild)
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Argument)
                        {
                            #region Argument

                            if (((FParameterName)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FParameterName)fRefObject).fChildFArgumentCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FParameterName)fRefObject).fChildFArgumentCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.Argument)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.Argument)
                        {
                            #region Argument

                            if (((FArgument)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FArgument)fRefObject).fNextSibling == null || !((FArgument)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.FunctionNameList)
                        {
                            #region FunctionNameList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildFunctionNameListCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildFunctionNameListCollection[cnt - 1];
                                ((FFunctionNameList)fDragDropData.fObject).moveTo((FFunctionNameList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FFunctionNameList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcDriver)fRefObject).pasteChildFunctionNameList();
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
                    else if (fRefObject.fObjectType == FObjectType.FunctionNameList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.FunctionNameList)
                        {
                            #region FunctionNameList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FFunctionNameList)fDragDropData.fObject).moveTo((FFunctionNameList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FFunctionNameList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FFunctionNameList)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FFunctionName)fDragDropData.fObject).moveTo((FFunctionNameList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FFunctionName)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FFunctionNameList)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.FunctionName)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.FunctionName)
                        {
                            #region FunctionName

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FFunctionName)fDragDropData.fObject).moveTo((FFunctionName)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FFunctionName)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FFunctionName)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.ParameterName)
                        {
                            #region ParameterName

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FParameterName)fDragDropData.fObject).moveTo((FFunctionName)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FParameterName)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FFunctionName)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.ParameterName)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.ParameterName)
                        {
                            #region ParameterName

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FParameterName)fDragDropData.fObject).moveTo((FParameterName)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FParameterName)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FParameterName)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Argument)
                        {
                            #region Argument                           

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FArgument)fDragDropData.fObject).moveTo((FParameterName)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FArgument)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FParameterName)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.Argument)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.Argument)
                        {
                            #region Argument

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FArgument)fDragDropData.fObject).moveTo((FArgument)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FArgument)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FArgument)fRefObject).pasteSibling();
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                if (e.Tool.Key == FMenuKey.MenuFndExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuFndCollapse)
                {
                    procMenuCollapse();
                }                
                else if (e.Tool.Key == FMenuKey.MenuFndCut)
                {
                    procMenuCut(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuFndCopy)
                {
                    procMenuCopy(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuFndPasteSibling)
                {
                    procMenuPasteSibling(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuFndPasteChild)
                {
                    procMenuPasteChild(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuFndRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuFndMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuFndMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuFndRelation)
                {
                    procMenuRelation();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuFndInsertBeforeFunctionNameList ||
                    e.Tool.Key == FMenuKey.MenuFndInsertBeforeFunctionName ||
                    e.Tool.Key == FMenuKey.MenuFndInsertBeforeParameterName ||
                    e.Tool.Key == FMenuKey.MenuFndInsertBeforeArgument
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuFndInsertAfterFunctionNameList ||
                    e.Tool.Key == FMenuKey.MenuFndInsertAfterFunctionName ||
                    e.Tool.Key == FMenuKey.MenuFndInsertAfterParameterName ||
                    e.Tool.Key == FMenuKey.MenuFndInsertAfterArgument
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuFndAppendFunctionNameList ||
                    e.Tool.Key == FMenuKey.MenuFndAppendFunctionName ||
                    e.Tool.Key == FMenuKey.MenuFndAppendParameterName ||
                    e.Tool.Key == FMenuKey.MenuFndAppendArgument
                    )
                {
                    procMenuAppendObject(e.Tool.Key);
                }
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
