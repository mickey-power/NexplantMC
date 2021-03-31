/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FDataSetDefinition.cs
--  Creator         : iskim
--  Create Date     : 2013.08.26
--  Description     : FAMate OPC Modeler DataSet Definition Form Class 
--  History         : Created by iskim at 2013.08.256
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
    public partial class FDataSetDefinition : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FEventHandler m_fEventHandler = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction
        
        public FDataSetDefinition(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSetDefinition(
            FOpmCore fOpmCore
            )
            :this()
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

        private void designTreeOfDataSetDefinition(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwTree.ImageList.Images.Add("DataSetList_unlock", Properties.Resources.DataSetList_unlock);
                tvwTree.ImageList.Images.Add("DataSetList_lock", Properties.Resources.DataSetList_lock);
                tvwTree.ImageList.Images.Add("DataSet_unlock", Properties.Resources.DataSet_unlock);
                tvwTree.ImageList.Images.Add("DataSet_lock", Properties.Resources.DataSet_lock);
                tvwTree.ImageList.Images.Add("Data_List_unlock", Properties.Resources.Data_List_unlock);
                tvwTree.ImageList.Images.Add("Data_List_lock", Properties.Resources.Data_List_lock);
                tvwTree.ImageList.Images.Add("Data_unlock", Properties.Resources.Data_unlock);
                tvwTree.ImageList.Images.Add("Data_lock", Properties.Resources.Data_lock);
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
                        t.Key == FMenuKey.MenuDsdExpand ||
                        t.Key == FMenuKey.MenuDsdCollapse ||
                        t.Key == FMenuKey.MenuDsdRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuDsdRemove || 
                        t.Key == FMenuKey.MenuDsdMoveUp ||
                        t.Key == FMenuKey.MenuDsdMoveDown ||
                        t.Key == FMenuKey.MenuDsdCopy ||
                        t.Key == FMenuKey.MenuDsdCut ||
                        t.Key == FMenuKey.MenuDsdPasteChild ||
                        t.Key == FMenuKey.MenuDsdPasteSibling
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
                    mnuMenu.Tools[FMenuKey.MenuDsdAppendDataSetList].SharedProps.Visible = ((FOpcDriver)fObject).canAppendChildDataSetList;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDsdPasteChild].SharedProps.Enabled = ((FOpcDriver)fObject).canPasteChildDataSetList;
                }
                else if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    mnuMenu.Tools[FMenuKey.MenuDsdApplyOsmFiles].SharedProps.Visible = true;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDsdInsertBeforeDataSetList].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuDsdInsertAfterDataSetList].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDsdAppendDataSet].SharedProps.Visible = fObject.canAppendChild;                    
                }
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    mnuMenu.Tools[FMenuKey.MenuDsdInsertBeforeDataSet].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuDsdInsertAfterDataSet].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDsdAppendData].SharedProps.Visible = fObject.canAppendChild;                    
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    mnuMenu.Tools[FMenuKey.MenuDsdInsertBeforeData].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuDsdInsertAfterData].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDsdAppendData].SharedProps.Visible = fObject.canAppendChild;                    
                }

                // --

                if (           
                    fObject.fObjectType == FObjectType.DataSetList ||
                    fObject.fObjectType == FObjectType.DataSet ||
                    fObject.fObjectType == FObjectType.Data
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuDsdRemove].SharedProps.Enabled = fObject.canRemove;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDsdMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuDsdMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuDsdCopy].SharedProps.Enabled = fObject.canCopy;
                    mnuMenu.Tools[FMenuKey.MenuDsdCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuDsdPasteChild].SharedProps.Enabled = fObject.canPasteChild;
                    mnuMenu.Tools[FMenuKey.MenuDsdPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;
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
            UltraTreeNode tNodeDsl = null;
            UltraTreeNode tNodeDts = null;
            UltraTreeNode tNodeDat = null;

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
                // Data Set List Load
                // ***
                foreach (FDataSetList fDsl in fOcd.fChildDataSetListCollection)
                {
                    tNodeDsl = new UltraTreeNode(fDsl.uniqueIdToString);
                    tNodeDsl.Tag = fDsl;
                    FCommon.refreshTreeNodeOfObject(fDsl, tvwTree, tNodeDsl);

                    //--

                    //***
                    // Data Set Load
                    // ***
                    foreach (FDataSet fDts in fDsl.fChildDataSetCollection)
                    {
                        tNodeDts = new UltraTreeNode(fDts.uniqueIdToString);
                        tNodeDts.Tag = fDts;
                        FCommon.refreshTreeNodeOfObject(fDts, tvwTree, tNodeDts);

                        // --

                        // ***
                        // Data Load
                        // ***
                        foreach (FData fDat in fDts.fChildDataCollection)
                        {
                            tNodeDat = new UltraTreeNode(fDat.uniqueIdToString);
                            tNodeDat.Tag = fDat;
                            FCommon.refreshTreeNodeOfObject(fDat, tvwTree, tNodeDat);
                            // --
                            tNodeDat.Expanded = false;
                            tNodeDts.Nodes.Add(tNodeDat);
                        }

                        // --

                        tNodeDts.Expanded = false;
                        tNodeDsl.Nodes.Add(tNodeDts);
                    }

                    // --

                    tNodeDsl.Expanded = true;
                    tNodeOcd.Nodes.Add(tNodeDsl);
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
                tNodeDsl = null;
                tNodeDts = null;
                tNodeDat = null;
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
                    foreach (FDataSetList fDsl in ((FOpcDriver)fParent).fChildDataSetListCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDsl.uniqueIdToString);
                        tNodeChild.Tag = fDsl;
                        FCommon.refreshTreeNodeOfObject(fDsl, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.DataSetList)
                {
                    foreach (FDataSet fDst in ((FDataSetList)fParent).fChildDataSetCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDst.uniqueIdToString);
                        tNodeChild.Tag = fDst;
                        FCommon.refreshTreeNodeOfObject(fDst, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.DataSet)
                {
                    foreach (FData fDat in ((FDataSet)fParent).fChildDataCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDat.uniqueIdToString);
                        tNodeChild.Tag = fDat;
                        FCommon.refreshTreeNodeOfObject(fDat, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.Data)
                {
                    foreach (FData fDat in ((FData)fParent).fChildDataCollection)
                    {
                        tNodeChild = new UltraTreeNode(fDat.uniqueIdToString);
                        tNodeChild.Tag = fDat;
                        FCommon.refreshTreeNodeOfObject(fDat, tvwTree, tNodeChild);
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

                if (fNewChild.fObjectType == FObjectType.DataSetList)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                   
                    fRefChild = ((FDataSetList)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.DataSet)
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
                    fRefChild = ((FDataSet)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.Data)
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
                    fRefChild = ((FData)fNewChild).fNextSibling;
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
                FDebug.throwException(ex);
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
                if (tPrevNode == null )
                {
                    return;
                }

                // --

                if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    if (((FDataSetList)fObject).fPreviousSibling == (FDataSetList)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    if (((FDataSet)fObject).fPreviousSibling == (FDataSet)tPrevNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    if (((FData)fObject).fPreviousSibling == (FData)tPrevNode.Tag)
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

                if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    if (((FDataSetList)fObject).fNextSibling == (FDataSetList)tNextNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    if (((FDataSet)fObject).fNextSibling == (FDataSet)tNextNode.Tag)
                    {
                        return;
                    }
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    if (((FData)fObject).fNextSibling == (FData)tNextNode.Tag)
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
                    fNewChild = ((FOpcDriver)fParent).appendChildDataSetList(new FDataSetList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.DataSetList)
                {
                    fNewChild = ((FDataSetList)fParent).appendChildDataSet(new FDataSet(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.DataSet)
                {
                    fNewChild = ((FDataSet)fParent).appendChildData(new FData(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                }
                else if (fParent.fObjectType == FObjectType.Data)
                {
                    fNewChild = new FData(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    if (((FData)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FData)fNewChild).fFormat = FFormat.Ascii;
                    }
                    fNewChild = ((FData)fParent).appendChildData((FData)fNewChild);
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

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertBeforeChildDataSetList(
                        new FDataSetList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FDataSetList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.DataSetList)
                {
                    fNewChild = ((FDataSetList)fParent).insertBeforeChildDataSet(
                        new FDataSet(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FDataSet)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.DataSet)
                {
                    fNewChild = ((FDataSet)fParent).insertBeforeChildData(
                        new FData(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FData)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.Data)
                {
                    fNewChild = new FData(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    // --
                    if (
                        ((FData)fRefChild).fPattern == FPattern.Variable &&
                        (((FData)fRefChild).fPreviousSibling != null && ((FData)fRefChild).fPreviousSibling.fPattern == FPattern.Variable)
                        )
                    {
                        ((FData)fNewChild).fSourceType = ((FData)fRefChild).fSourceType;
                    }
                    // --
                    if (((FData)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FData)fNewChild).fFormat = FFormat.Ascii;
                    }
                    // --
                    fNewChild = ((FData)fParent).insertBeforeChildData((FData)fNewChild, (FData)fRefChild);
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
                    fNewChild = ((FOpcDriver)fParent).insertAfterChildDataSetList(
                        new FDataSetList(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FDataSetList)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.DataSetList)
                {
                    fNewChild = ((FDataSetList)fParent).insertAfterChildDataSet(
                        new FDataSet(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FDataSet)fRefChild
                        );
                }
                else if (fParent.fObjectType == FObjectType.DataSet)
                {
                    fNewChild = new FData(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    // --
                    if (
                        ((FData)fRefChild).fPattern == FPattern.Variable &&
                        (((FData)fRefChild).fNextSibling != null && ((FData)fRefChild).fNextSibling.fPattern == FPattern.Variable)
                        )
                    {
                        ((FData)fNewChild).fSourceType = ((FData)fRefChild).fSourceType;
                    }                    
                    // --
                    fNewChild = ((FDataSet)fParent).insertAfterChildData((FData)fNewChild, (FData)fRefChild);
                }
                else if (fParent.fObjectType == FObjectType.Data)
                {
                    fNewChild = new FData(this.m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    // --
                    if (
                        ((FData)fRefChild).fPattern == FPattern.Variable &&
                        (((FData)fRefChild).fNextSibling != null && ((FData)fRefChild).fNextSibling.fPattern == FPattern.Variable)
                        )
                    {
                        ((FData)fNewChild).fSourceType = ((FData)fRefChild).fSourceType;
                    }
                    // --
                    if (((FData)fParent).fFormat == FFormat.AsciiList)
                    {
                        ((FData)fNewChild).fFormat = FFormat.Ascii;
                    }
                    // --
                    fNewChild = ((FData)fParent).insertAfterChildData((FData)fNewChild, (FData)fRefChild);
                }

                // --

                tNodeNewChild = new UltraTreeNode(fNewChild.uniqueIdToString);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);
                tNodeParent.Nodes.Insert(tNodeRefChild.Index+1, tNodeNewChild);
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
                // Removing OPC Object Validate
                // ***
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FDataSetList)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.DataSetList)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FDataSet)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }                

                // --

                // ***
                // Remove OPC Object가 1개 이상일 경우 사용자에게 Confirm를 받는다.
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
                // OPC Object Remove
                // ***
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fChilds = new FDataSetList[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FDataSetList)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcDriver)fParent).removeChildDataSetList((FDataSetList[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.DataSetList)
                {
                    fChilds = new FDataSet[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FDataSet)tvwTree.SelectedNodes[i].Tag;
                    }
                    // -- 
                    ((FDataSetList)fParent).removeChildDataSet((FDataSet[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.DataSet)
                {
                    fChilds = new FData[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FData)tvwTree.SelectedNodes[i].Tag;
                    }
                    // -- 
                    ((FDataSet)fParent).removeChildData((FData[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.Data)
                {
                    fChilds = new FData[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FData)tvwTree.SelectedNodes[i].Tag;
                    }
                    // -- 
                    ((FData)fParent).removeChildData((FData[])fChilds);
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

                if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    ((FDataSetList)fObject).moveUp();
                }                
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    ((FDataSet)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    ((FData)fObject).moveUp();
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

                if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    ((FDataSetList)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    ((FDataSet)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    ((FData)fObject).moveDown();
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
                    foreach (UltraTreeNode tNodeDsl in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeDsl.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeDts in tNodeDsl.Nodes)
                        {
                            tNodeDts.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeDat in tNodeDts.Nodes)
                            {
                                tNodeDat.Expanded = true;
                                // --
                                foreach (UltraTreeNode tNodeDa in tNodeDat.Nodes)
                                {
                                    tNodeDa.Expanded = true;
                                }
                            }
                        }                        
                    }
                }
                else if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeDts in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeDts.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeDat in tNodeDts.Nodes)
                        {
                            tNodeDat.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeDa in tNodeDat.Nodes)
                            {
                                tNodeDa.Expanded = true;
                            }
                        }
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
                    foreach (UltraTreeNode tNodeDsl in tvwTree.ActiveNode.Nodes)
                    {                        
                        foreach (UltraTreeNode tNodeDts in tNodeDsl.Nodes)
                        {                            
                            foreach (UltraTreeNode tNodeDat in tNodeDts.Nodes)
                            {
                                foreach (UltraTreeNode tNodeDa in tNodeDat.Nodes)
                                {
                                    tNodeDa.Expanded = false;
                                }
                                // --
                                tNodeDat.Expanded = false;
                            }
                            // --
                            tNodeDts.Expanded = false;
                        }
                        // --
                        tNodeDsl.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;                    
                }
                else if (fObject.fObjectType == FObjectType.DataSetList)
                {                                        
                    foreach (UltraTreeNode tNodeDts in tvwTree.ActiveNode.Nodes)
                    {                       
                        foreach (UltraTreeNode tNodeDat in tNodeDts.Nodes)
                        {
                            foreach (UltraTreeNode tNodeDa in tNodeDat.Nodes)
                            {
                                tNodeDa.Expanded = false;
                            }
                            // --
                            tNodeDat.Expanded = false;
                        }
                        // --
                        tNodeDts.Expanded = false;
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
                else if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    ((FDataSetList)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    ((FDataSet)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    ((FData)fObject).copy();
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

        public void procMenuCut(
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
                else if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    ((FDataSetList)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    ((FDataSet)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    ((FData)fObject).cut();
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
                    fChild = ((FOpcDriver)fParent).pasteChildDataSetList();
                }
                else if (fParent.fObjectType == FObjectType.DataSetList)
                {
                    fChild = ((FDataSetList)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.DataSet)
                {
                    fChild = ((FDataSet)fParent).pasteChild();
                }
                else if (fParent.fObjectType == FObjectType.Data)
                {
                    fChild = ((FData)fParent).pasteChild();
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
                if (fRefObject.fObjectType == FObjectType.DataSetList)
                {
                    fNewObject = ((FDataSetList)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.DataSet)
                {
                    fNewObject = ((FDataSet)fRefObject).pasteSibling();
                }
                else if (fRefObject.fObjectType == FObjectType.Data)
                {
                    fNewObject = ((FData)fRefObject).pasteSibling();
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

                fResult = m_fOpmCore.fOpmFileInfo.fOpcDriver.searchDataSetSeries(fBase, searchWord);
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

                if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    ((FDataSetList)fObject).copy();
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

        #region FDataSetDefinition form Event Halndla

        private void FDataSetDefinitition_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfDataSetDefinition();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuOpmPopupMenu]);

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

        private void FDataSetDefinition_Shown(
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

        private void FDataSetDefinition_FormClosing(
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
        
        #region m_fEnvetHandler Object Event Handler

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.DataSetList ||
                    e.fObject.fObjectType == FObjectType.DataSet ||
                    e.fObject.fObjectType == FObjectType.Data
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
                    e.fObject.fObjectType == FObjectType.DataSetList ||
                    e.fObject.fObjectType == FObjectType.DataSet ||
                    e.fObject.fObjectType == FObjectType.Data
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
                    e.fObject.fObjectType == FObjectType.DataSetList ||
                    e.fObject.fObjectType == FObjectType.DataSet ||
                    e.fObject.fObjectType == FObjectType.Data
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
                    e.fObject.fObjectType == FObjectType.DataSetList ||
                    e.fObject.fObjectType == FObjectType.DataSet ||
                    e.fObject.fObjectType == FObjectType.Data
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
                    e.fObject.fObjectType == FObjectType.DataSetList ||
                    e.fObject.fObjectType == FObjectType.DataSet ||
                    e.fObject.fObjectType == FObjectType.Data
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
                    e.fObject.fObjectType == FObjectType.DataSetList ||
                    e.fObject.fObjectType == FObjectType.DataSet ||
                    e.fObject.fObjectType == FObjectType.Data
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
                    e.fObject.fObjectType == FObjectType.DataSetList ||
                    e.fObject.fObjectType == FObjectType.DataSet ||
                    e.fObject.fObjectType == FObjectType.Data
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
                else if (fObject.fObjectType == FObjectType.DataSetList)
                {
                    pgdProp.selectedObject = new FPropDsl(m_fOpmCore, pgdProp, (FDataSetList)fObject);
                }
                else if (fObject.fObjectType == FObjectType.DataSet)
                {
                    pgdProp.selectedObject = new FPropDts(m_fOpmCore, pgdProp, (FDataSet)fObject);
                }
                else if (fObject.fObjectType == FObjectType.Data)
                {
                    pgdProp.selectedObject = new FPropDat(m_fOpmCore, pgdProp, (FData)fObject);
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
                    if (mnuMenu.Tools[FMenuKey.MenuDsdRemove].SharedProps.Enabled == true)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDsdCut].SharedProps.Enabled == true)
                    {
                        procMenuCut(FMenuKey.MenuDsdCut);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDsdCopy].SharedProps.Enabled == true)
                    {
                        procMenuCopy(FMenuKey.MenuDsdCopy);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDsdPasteSibling].SharedProps.Enabled == true)
                    {
                        procMenuPasteSibling(FMenuKey.MenuDsdPasteSibling);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDsdPasteChild].SharedProps.Enabled == true)
                    {
                        procMenuPasteChild(FMenuKey.MenuDsdPasteChild);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDsdMoveUp].SharedProps.Enabled == true)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuDsdMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDsdMoveDown].SharedProps.Enabled == true)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuDsdMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDsdExpand].SharedProps.Enabled == true)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDsdCollapse].SharedProps.Enabled == true)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuDsdRelation].SharedProps.Enabled == true)
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSetList)
                        {
                            #region DataSetList

                            if (((FOpcDriver)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildDataSetListCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildDataSetListCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.DataSetList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSetList)
                        {
                            #region DataSetList

                            if (((FDataSetList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FDataSetList)fRefObject).fNextSibling == null || !((FDataSetList)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (((FDataSetList)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                cnt = ((FDataSetList)fRefObject).fChildDataSetCollection.count;
                                if (cnt == 0)
                                {
                                    e.Effect = DragDropEffects.Move;
                                    return;
                                }
                                else
                                {
                                    fRefObject = ((FDataSetList)fRefObject).fChildDataSetCollection[cnt - 1];
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
                    else if (fRefObject.fObjectType == FObjectType.DataSet)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {   
                            #region DataSet

                            if (((FDataSet)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    (((FDataSet)fRefObject).fNextSibling == null || !((FDataSet)fRefObject).fNextSibling.Equals(fDragDropData.fObject))
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
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (((FDataSet)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FDataSet)fRefObject).Equals(((FData)fDragDropData.fObject).fAncestorDataSet) &&
                                    !((FDataSet)fRefObject).fChildDataCollection[((FDataSet)fRefObject).fChildDataCollection.count - 1].Equals(fDragDropData.fObject)                                    
                                    )
                                {
                                    if (((FDataSet)fRefObject).hasVariableChild)
                                    {
                                        if (((FData)fDragDropData.fObject).fPattern == FPattern.Variable)
                                        {
                                            if (
                                                ((FDataSet)fRefObject).Equals(((FData)fDragDropData.fObject).fParent) &&
                                                (((FData)fDragDropData.fObject).fPreviousSibling == null || ((FData)fDragDropData.fObject).fPreviousSibling.fPattern == FPattern.Fixed) &&
                                                (((FData)fDragDropData.fObject).fNextSibling == null || ((FData)fDragDropData.fObject).fNextSibling.fPattern == FPattern.Fixed)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                            else if (((FDataSet)fRefObject).fChildDataCollection[((FDataSet)fRefObject).fChildDataCollection.count - 1].fPattern == FPattern.Variable)
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
                    }                    
                    else if (fRefObject.fObjectType == FObjectType.Data)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (((FData)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    !fRefObject.Equals(fDragDropData.fObject) &&
                                    !((FData)fDragDropData.fObject).containsObject(fRefObject) &&
                                    ((FData)fRefObject).fAncestorDataSet.Equals(((FData)fDragDropData.fObject).fAncestorDataSet) &&
                                    (((FData)fRefObject).fNextSibling == null || !(((FData)fRefObject).fNextSibling.Equals((FData)fDragDropData.fObject)))
                                    )
                                {
                                    if (
                                        (((FData)fRefObject).fParent.fObjectType == FObjectType.DataSet && ((FDataSet)((FData)fRefObject).fParent).hasVariableChild) ||
                                        (((FData)fRefObject).fParent.fObjectType == FObjectType.Data && ((FData)((FData)fRefObject).fParent).hasVariableChild)
                                        )
                                    {
                                        if (((FData)fDragDropData.fObject).fPattern == FPattern.Variable)
                                        {
                                            if (
                                                ((FData)fDragDropData.fObject).fParent.Equals(((FData)fRefObject).fParent) &&
                                                (((FData)fDragDropData.fObject).fPreviousSibling == null || ((FData)fDragDropData.fObject).fPreviousSibling.fPattern == FPattern.Fixed) &&
                                                (((FData)fDragDropData.fObject).fNextSibling == null || ((FData)fDragDropData.fObject).fNextSibling.fPattern == FPattern.Fixed)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                            else if (
                                                ((FData)fRefObject).fPattern == FPattern.Variable ||
                                                (((FData)fRefObject).fNextSibling != null && ((FData)fRefObject).fNextSibling.fPattern == FPattern.Variable)
                                                )
                                            {
                                                e.Effect = DragDropEffects.Move;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (
                                                ((FData)fRefObject).fPattern == FPattern.Fixed ||
                                                ((FData)fRefObject).fNextSibling == null ||
                                                ((FData)fRefObject).fNextSibling.fPattern == FPattern.Fixed
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

                            if (((FData)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                fFormat = ((FData)fRefObject).fFormat;
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
                        else if (
                            fDragDropData.fObject.fObjectType == FObjectType.OpcDriver ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcDevice ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcSession ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostDevice ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostSession ||
                            fDragDropData.fObject.fObjectType == FObjectType.Equipment
                            )
                        {
                            #region Resource

                            if (((FData)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (!((FData)fRefObject).hasChild)
                                {
                                    if (
                                        ((FData)fRefObject).fPattern == FPattern.Fixed ||
                                        ((FData)fRefObject).fPreviousSibling == null ||
                                        ((FData)fRefObject).fPreviousSibling.fPattern == FPattern.Fixed ||
                                        ((FData)fRefObject).fNextSibling == null ||
                                        ((FData)fRefObject).fNextSibling.fPattern == FPattern.Fixed
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }                                    
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.EquipmentState)
                        {
                            #region EquipmentState

                            if (((FData)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FData)fRefObject).fPattern == FPattern.Fixed ||
                                    ((FData)fRefObject).fPreviousSibling == null ||
                                    ((FData)fRefObject).fPreviousSibling.fPattern == FPattern.Fixed ||
                                    ((FData)fRefObject).fNextSibling == null ||
                                    ((FData)fRefObject).fNextSibling.fPattern == FPattern.Fixed
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }                                
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            if (((FData)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FData)fRefObject).fPattern == FPattern.Fixed ||
                                    ((FData)fRefObject).fPreviousSibling == null ||
                                    ((FData)fRefObject).fPreviousSibling.fPattern == FPattern.Fixed ||
                                    ((FData)fRefObject).fNextSibling == null ||
                                    ((FData)fRefObject).fNextSibling.fPattern == FPattern.Fixed
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }                                
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Column)
                        {
                            #region Column

                            if (((FData)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FColumn)fDragDropData.fObject).fPattern == FPattern.Fixed)
                                {
                                    if (
                                        ((FData)fRefObject).fPattern == FPattern.Fixed ||
                                        ((FData)fRefObject).fPreviousSibling == null ||
                                        ((FData)fRefObject).fPreviousSibling.fPattern == FPattern.Fixed ||
                                        ((FData)fRefObject).fNextSibling == null ||
                                        ((FData)fRefObject).fNextSibling.fPattern == FPattern.Fixed
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (
                                        (((FData)fRefObject).fParent.fObjectType == FObjectType.DataSet && !((FDataSet)((FData)fRefObject).fParent).hasVariableChild) ||
                                        (((FData)fRefObject).fParent.fObjectType == FObjectType.Data && !((FData)((FData)fRefObject).fParent).hasVariableChild) ||                                        
                                        (((FData)fRefObject).fPreviousSibling != null && ((FData)fRefObject).fPreviousSibling.fPattern == FPattern.Variable && ((FData)fRefObject).fPreviousSibling.fSourceType == FDataSourceType.Column) ||
                                        (((FData)fRefObject).fNextSibling != null && ((FData)fRefObject).fNextSibling.fPattern == FPattern.Variable && ((FData)fRefObject).fNextSibling.fSourceType == FDataSourceType.Column)
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                    else if (((FData)fRefObject).fPattern == FPattern.Variable)
                                    {
                                        if (
                                            (((FData)fRefObject).fParent.fObjectType == FObjectType.DataSet && ((FDataSet)((FData)fRefObject).fParent).fVariableChildDataColection.count == 1) ||
                                            (((FData)fRefObject).fParent.fObjectType == FObjectType.Data && ((FData)((FData)fRefObject).fParent).fVariableChildDataColection.count == 1)
                                            )
                                        {
                                            e.Effect = DragDropEffects.Copy;
                                            return;
                                        }
                                    }
                                }                                                                
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (((FData)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FData)fRefObject).fPattern == FPattern.Fixed ||
                                    ((FData)fRefObject).fPreviousSibling == null ||
                                    ((FData)fRefObject).fPreviousSibling.fPattern == FPattern.Fixed ||
                                    ((FData)fRefObject).fNextSibling == null ||
                                    ((FData)fRefObject).fNextSibling.fPattern == FPattern.Fixed
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (((FData)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (
                                    ((FData)fRefObject).fPattern == FPattern.Fixed ||
                                    ((FData)fRefObject).fPreviousSibling == null ||
                                    ((FData)fRefObject).fPreviousSibling.fPattern == FPattern.Fixed ||
                                    ((FData)fRefObject).fNextSibling == null ||
                                    ((FData)fRefObject).fNextSibling.fPattern == FPattern.Fixed
                                    )
                                {
                                    e.Effect = DragDropEffects.Copy;
                                    return;
                                }
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (((FData)fRefObject).equalsModelingFile(fDragDropData.fObject))
                            {
                                if (((FHostItem)fDragDropData.fObject).fPattern == FPattern.Fixed)
                                {
                                    if (
                                        ((FData)fRefObject).fPattern == FPattern.Fixed ||
                                        ((FData)fRefObject).fPreviousSibling == null ||
                                        ((FData)fRefObject).fPreviousSibling.fPattern == FPattern.Fixed ||
                                        ((FData)fRefObject).fNextSibling == null ||
                                        ((FData)fRefObject).fNextSibling.fPattern == FPattern.Fixed
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                }
                                else
                                {
                                    if (
                                        (((FData)fRefObject).fParent.fObjectType == FObjectType.DataSet && !((FDataSet)((FData)fRefObject).fParent).hasVariableChild) ||
                                        (((FData)fRefObject).fParent.fObjectType == FObjectType.Data && !((FData)((FData)fRefObject).fParent).hasVariableChild) ||                                        
                                        (((FData)fRefObject).fPreviousSibling != null && ((FData)fRefObject).fPreviousSibling.fPattern == FPattern.Variable && ((FData)fRefObject).fPreviousSibling.fSourceType == FDataSourceType.Item) ||
                                        (((FData)fRefObject).fNextSibling != null && ((FData)fRefObject).fNextSibling.fPattern == FPattern.Variable && ((FData)fRefObject).fNextSibling.fSourceType == FDataSourceType.Item)
                                        )
                                    {
                                        e.Effect = DragDropEffects.Copy;
                                        return;
                                    }
                                    else if (((FData)fRefObject).fPattern == FPattern.Variable)
                                    {
                                        if (
                                            (((FData)fRefObject).fParent.fObjectType == FObjectType.DataSet && ((FDataSet)((FData)fRefObject).fParent).fVariableChildDataColection.count == 1) ||
                                            (((FData)fRefObject).fParent.fObjectType == FObjectType.Data && ((FData)((FData)fRefObject).fParent).fVariableChildDataColection.count == 1)
                                            )
                                        {
                                            e.Effect = DragDropEffects.Copy;
                                            return;
                                        }
                                    }
                                }
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
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSetList)
                        {
                            #region DataSetList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                cnt = ((FOpcDriver)fRefObject).fChildDataSetListCollection.count;
                                fRefObject = ((FOpcDriver)fRefObject).fChildDataSetListCollection[cnt - 1];
                                ((FDataSetList)fDragDropData.fObject).moveTo((FDataSetList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataSetList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FOpcDriver)fRefObject).pasteChildDataSetList();
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
                    else if (fRefObject.fObjectType == FObjectType.DataSetList)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSetList)
                        {
                            #region DataSetList

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FDataSetList)fDragDropData.fObject).moveTo((FDataSetList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataSetList)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FDataSetList)fRefObject).pasteSibling();
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

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FDataSet)fDragDropData.fObject).moveTo((FDataSetList)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataSet)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FDataSetList)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.DataSet)
                    {
                        if (fDragDropData.fObject.fObjectType == FObjectType.DataSet)
                        {
                            #region DataSet

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FDataSet)fDragDropData.fObject).moveTo((FDataSet)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FDataSet)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FDataSet)fRefObject).pasteSibling();
                                fAction = FDragDropAction.Copy;
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

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FData)fDragDropData.fObject).moveTo((FDataSet)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FDataSet)fRefObject).pasteChild();
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
                    else if (fRefObject.fObjectType == FObjectType.Data)
                    {   
                        if (fDragDropData.fObject.fObjectType == FObjectType.Data)
                        {
                            #region Data

                            if (e.Effect == DragDropEffects.Move)
                            {
                                ((FData)fDragDropData.fObject).moveTo((FData)fRefObject);
                                fAction = FDragDropAction.Move;
                            }
                            else if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fDragDropData.fObject).copy();
                                fDragDropData.fObject = ((FData)fRefObject).pasteSibling();
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
                                ((FData)fRefObject).setDataConversionSet((FDataConversionSet)fDragDropData.fObject);
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (
                            fDragDropData.fObject.fObjectType == FObjectType.OpcDriver ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcDevice ||
                            fDragDropData.fObject.fObjectType == FObjectType.OpcSession ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostDevice ||
                            fDragDropData.fObject.fObjectType == FObjectType.HostSession ||
                            fDragDropData.fObject.fObjectType == FObjectType.Equipment
                            )
                        {
                            #region Resource

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fRefObject).fSourceType = FDataSourceType.Resource;
                                ((FData)fRefObject).fPattern = FPattern.Fixed;
                                ((FData)fRefObject).fixedLength = 1;                                
                                // --
                                if (fDragDropData.fObject.fObjectType == FObjectType.OpcDriver)
                                {
                                    ((FData)fRefObject).sourceResource = FResourceSourceType.EapName;
                                }
                                else if (fDragDropData.fObject.fObjectType == FObjectType.OpcDevice)
                                {
                                    ((FData)fRefObject).sourceResource = FResourceSourceType.OpcDeviceName;
                                }
                                else if (fDragDropData.fObject.fObjectType == FObjectType.OpcSession)
                                {
                                    ((FData)fRefObject).sourceResource = FResourceSourceType.OpcSessionName;
                                }
                                else if (fDragDropData.fObject.fObjectType == FObjectType.HostDevice)
                                {
                                    ((FData)fRefObject).sourceResource = FResourceSourceType.HostDeviceName;
                                }
                                else if (fDragDropData.fObject.fObjectType == FObjectType.HostSession)
                                {
                                    ((FData)fRefObject).sourceResource = FResourceSourceType.HostSessionName;
                                }
                                else if (fDragDropData.fObject.fObjectType == FObjectType.Equipment)
                                {
                                    ((FData)fRefObject).sourceResource = FResourceSourceType.EquipmentName;
                                }                                
                                fAction = FDragDropAction.Set;
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

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fRefObject).fSourceType = FDataSourceType.EquipmentState;
                                ((FData)fRefObject).fPattern = FPattern.Fixed;
                                ((FData)fRefObject).fixedLength = 1;                                
                                ((FData)fRefObject).sourceEquipmentState = fDragDropData.fObject.name;
                                if (!((FData)fRefObject).hasChild)
                                {
                                    ((FData)fRefObject).fFormat = FFormat.Ascii;
                                }                                
                                fAction = FDragDropAction.Set;                                
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Environment)
                        {
                            #region Environment

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fRefObject).fSourceType = FDataSourceType.Environment;
                                ((FData)fRefObject).fPattern = FPattern.Fixed;
                                ((FData)fRefObject).fixedLength = 1;                                
                                ((FData)fRefObject).sourceEnvironment = fDragDropData.fObject.name;
                                if (!((FData)fRefObject).hasChild)
                                {
                                    ((FData)fRefObject).fFormat = ((FEnvironment)fDragDropData.fObject).fFormat;
                                }                               
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.Column)
                        {
                            #region Column

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fRefObject).fSourceType = FDataSourceType.Column;
                                if (((FColumn)fDragDropData.fObject).fPattern == FPattern.Fixed)
                                {
                                    ((FData)fRefObject).fPattern = FPattern.Fixed;
                                    ((FData)fRefObject).fixedLength = ((FColumn)fDragDropData.fObject).fixedLength;
                                }
                                else
                                {
                                    ((FData)fRefObject).fPattern = FPattern.Variable;
                                }  
                                ((FData)fRefObject).sourceColumn = fDragDropData.fObject.name;
                                if (!((FData)fRefObject).hasChild)
                                {
                                    ((FData)fRefObject).fFormat = ((FColumn)fDragDropData.fObject).fFormat;
                                }                                                                  
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcEventItem)
                        {
                            #region OpcEventItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fRefObject).fSourceType = FDataSourceType.Item;
                                ((FData)fRefObject).fPattern = FPattern.Fixed;
                                ((FData)fRefObject).fixedLength = 1;                                
                                ((FData)fRefObject).sourceItem = fDragDropData.fObject.name;
                                if (!((FData)fRefObject).hasChild)
                                {
                                    ((FData)fRefObject).fFormat = (FFormat)((FOpcEventItem)fDragDropData.fObject).fFormat;
                                }                                
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.OpcItem)
                        {
                            #region OpcItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fRefObject).fSourceType = FDataSourceType.Item;
                                ((FData)fRefObject).fPattern = FPattern.Fixed;
                                ((FData)fRefObject).fixedLength = 1;                                
                                ((FData)fRefObject).sourceItem = fDragDropData.fObject.name;
                                if (!((FData)fRefObject).hasChild)
                                {
                                    ((FData)fRefObject).fFormat = (FFormat)((FOpcItem)fDragDropData.fObject).fFormat;
                                }                                
                                fAction = FDragDropAction.Set;
                            }
                            else
                            {
                                return;
                            }

                            #endregion
                        }
                        else if (fDragDropData.fObject.fObjectType == FObjectType.HostItem)
                        {
                            #region HostItem

                            if (e.Effect == DragDropEffects.Copy)
                            {
                                ((FData)fRefObject).fSourceType = FDataSourceType.Item;
                                if (((FHostItem)fDragDropData.fObject).fPattern == FPattern.Fixed)
                                {
                                    ((FData)fRefObject).fPattern = FPattern.Fixed;
                                    ((FData)fRefObject).fixedLength = ((FHostItem)fDragDropData.fObject).fixedLength;
                                }
                                else
                                {
                                    ((FData)fRefObject).fPattern = FPattern.Variable;
                                }                                
                                ((FData)fRefObject).sourceItem = fDragDropData.fObject.name;
                                if (!((FData)fRefObject).hasChild)
                                {
                                    ((FData)fRefObject).fFormat = ((FHostItem)fDragDropData.fObject).fFormat;
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
                    if (fRefObject.fObjectType == FObjectType.Data)
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
                if (e.Tool.Key == FMenuKey.MenuDsdExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuDsdCollapse)
                {
                    procMenuCollapse();
                }                
                else if (e.Tool.Key == FMenuKey.MenuDsdCut)
                {
                    procMenuCut(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuDsdCopy)
                {
                    procMenuCopy(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuDsdPasteSibling)
                {
                    procMenuPasteSibling(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuDsdPasteChild)
                {
                    procMenuPasteChild(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuDsdRemove)
                {
                    procMenuRemoveObject();
                }
                else if (e.Tool.Key == FMenuKey.MenuDsdMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuDsdMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuDsdRelation)
                {
                    procMenuRelation();
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuDsdInsertBeforeDataSetList ||
                    e.Tool.Key == FMenuKey.MenuDsdInsertBeforeDataSet ||
                    e.Tool.Key == FMenuKey.MenuDsdInsertBeforeData
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuDsdInsertAfterDataSetList ||
                    e.Tool.Key == FMenuKey.MenuDsdInsertAfterDataSet ||
                    e.Tool.Key == FMenuKey.MenuDsdInsertAfterData
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuDsdAppendDataSetList ||
                    e.Tool.Key == FMenuKey.MenuDsdAppendDataSet ||
                    e.Tool.Key == FMenuKey.MenuDsdAppendData
                    )
                {
                    procMenuAppendObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuDsdApplyOsmFiles)
                {
                    procMenuApplyOSMFiles();
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
    }
}
