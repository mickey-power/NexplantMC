/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FItemNameOfOpcSession.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.19
--  Description     : FAMate OPC Modeler Item Name of OPC Session Form Class 
--  History         : Created spike.lee at 2015.07.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Linq;
using System.Windows.Forms;
using Infragistics.Win.UltraWinToolbars;
using Infragistics.Win.UltraWinTree;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.OpcModeler
{
    public partial class FItemNameOfOpcSession : Nexplant.MC.Core.FaUIs.FBaseControlForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FEventHandler m_fEventHandler = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FItemNameOfOpcSession(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FItemNameOfOpcSession(
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

        private void designTreeOfOpcLibraryModeler(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                tvwTree.ImageList.Images.Add("OpcDevice", Properties.Resources.OpcDevice);
                tvwTree.ImageList.Images.Add("OpcDevice_Closed_unlock", Properties.Resources.OpcDevice_Closed_unlock);
                tvwTree.ImageList.Images.Add("OpcDevice_Closed_lock", Properties.Resources.OpcDevice_Closed_lock);
                tvwTree.ImageList.Images.Add("OpcDevice_Opened_unlock", Properties.Resources.OpcDevice_Opened_unlock);
                tvwTree.ImageList.Images.Add("OpcDevice_Opened_lock", Properties.Resources.OpcDevice_Opened_lock);
                tvwTree.ImageList.Images.Add("OpcDevice_Connected_unlock", Properties.Resources.OpcDevice_Connected_unlock);
                tvwTree.ImageList.Images.Add("OpcDevice_Connected_lock", Properties.Resources.OpcDevice_Connected_lock);
                tvwTree.ImageList.Images.Add("OpcDevice_Selected_unlock", Properties.Resources.OpcDevice_Selected_unlock);
                tvwTree.ImageList.Images.Add("OpcDevice_Selected_lock", Properties.Resources.OpcDevice_Selected_lock);
                tvwTree.ImageList.Images.Add("OpcSession_unlock", Properties.Resources.OpcSession_unlock);
                tvwTree.ImageList.Images.Add("OpcSession_lock", Properties.Resources.OpcSession_lock);                
                tvwTree.ImageList.Images.Add("OpcItem_unlock", Properties.Resources.OpcItem_unlock);                
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
                        t.Key == FMenuKey.MenuOsnExpand ||
                        t.Key == FMenuKey.MenuOsnCollapse ||
                        t.Key == FMenuKey.MenuOsnRelation
                        )
                    {
                        continue;
                    }
                    else if (
                        t.Key == FMenuKey.MenuOsnOpenOpcDevice ||
                        t.Key == FMenuKey.MenuOsnCloseOpcDevice ||
                        t.Key == FMenuKey.MenuOsnRefreshItemName ||
                        t.Key == FMenuKey.MenuOsnCut ||
                        t.Key == FMenuKey.MenuOsnCopy ||
                        t.Key == FMenuKey.MenuOsnPasteSibling ||
                        t.Key == FMenuKey.MenuOsnPasteChild ||                        
                        t.Key == FMenuKey.MenuOsnRemove ||
                        t.Key == FMenuKey.MenuOsnMoveUp ||
                        t.Key == FMenuKey.MenuOsnMoveDown
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
                    mnuMenu.Tools[FMenuKey.MenuOsnAppendOpcDevice].SharedProps.Visible = ((FOpcDriver)fObject).canAppendChildOpcDevice;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOsnPasteChild].SharedProps.Enabled = ((FOpcDriver)fObject).canPasteChildOpcDevice;
                }
                else if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    if (((FOpcDevice)fObject).fState == FDeviceState.Closed)
                    {
                        mnuMenu.Tools[FMenuKey.MenuOsnOpenOpcDevice].SharedProps.Enabled = true;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuOsnCloseOpcDevice].SharedProps.Enabled = true;
                    }
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOsnInsertBeforeOpcDevice].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuOsnInsertAfterOpcDevice].SharedProps.Visible = fObject.canInsertAfter;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOsnAppendOpcSession].SharedProps.Visible = fObject.canAppendChild;
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    mnuMenu.Tools[FMenuKey.MenuOsnRefreshItemName].SharedProps.Enabled = ((FOpcSession)fObject).canRefreshItemName;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOsnInsertBeforeOpcSession].SharedProps.Visible = fObject.canInsertBefore;
                    mnuMenu.Tools[FMenuKey.MenuOsnInsertAfterOpcSession].SharedProps.Visible = fObject.canInsertAfter;                    
                }
                else if (fObject.fObjectType == FObjectType.ItemName)
                {
                    
                }
                
                // --

                if (
                    fObject.fObjectType == FObjectType.OpcDevice ||
                    fObject.fObjectType == FObjectType.OpcSession 
                    )
                {
                    mnuMenu.Tools[FMenuKey.MenuOsnPasteSibling].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuOsnPasteChild].SharedProps.Visible = true;                    
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOsnRemove].SharedProps.Enabled = fObject.canRemove;
                    //--
                    mnuMenu.Tools[FMenuKey.MenuOsnMoveUp].SharedProps.Enabled = fObject.canMoveUp;
                    mnuMenu.Tools[FMenuKey.MenuOsnMoveDown].SharedProps.Enabled = fObject.canMoveDown;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuOsnCut].SharedProps.Enabled = fObject.canCut;
                    mnuMenu.Tools[FMenuKey.MenuOsnCopy].SharedProps.Enabled = fObject.canCopy;
                    // --
                    if (fObject.fObjectType == FObjectType.OpcSession)
                    {
                        mnuMenu.Tools[FMenuKey.MenuOsnPasteSibling].SharedProps.Enabled = false;
                    }
                    else
                    {
                        mnuMenu.Tools[FMenuKey.MenuOsnPasteSibling].SharedProps.Enabled = fObject.canPasteSibling;                    
                    }
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
            UltraTreeNode tNodeOdv = null;
            UltraTreeNode tNodeOsn = null;
            UltraTreeNode tNodeItn = null;

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
                // OPC Device Load
                // ***
                foreach (FOpcDevice fOdv in fOcd.fChildOpcDeviceCollection)
                {
                    tNodeOdv = new UltraTreeNode(fOdv.uniqueIdToString);
                    tNodeOdv.Tag = fOdv;
                    FCommon.refreshTreeNodeOfObject(fOdv, tvwTree, tNodeOdv);

                    // ***
                    // OPC Session Load
                    // ***
                    foreach (FOpcSession fOsn in fOdv.fChildOpcSessionCollection)
                    {
                        tNodeOsn = new UltraTreeNode(fOsn.uniqueIdToString);
                        tNodeOsn.Tag = fOsn;
                        FCommon.refreshTreeNodeOfObject(fOsn, tvwTree, tNodeOsn);

                        // ***
                        // OPC Session Item Name Load
                        // ***
                        foreach (FItemName fItn in fOsn.FChildItemNameCollection)
                        {
                            tNodeItn = new UltraTreeNode(fItn.uniqueIdToString);
                            tNodeItn.Tag = fItn;
                            FCommon.refreshTreeNodeOfObject(fItn, tvwTree, tNodeItn);

                            tNodeOsn.Nodes.Add(tNodeItn);
                        }

                        // --

                        tNodeOsn.Expanded = true;
                        tNodeOdv.Nodes.Add(tNodeOsn);
                    }

                    // --

                    tNodeOdv.Expanded = true;
                    tNodeOcd.Nodes.Add(tNodeOdv);
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
                tNodeOdv = null;
                tNodeOsn = null;                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        private void loadTreeOfChildObject(
            UltraTreeNode tNodeParent
            )
        {
            FIObject fParent = null;
            UltraTreeNode tNodeChild = null;
            string psnUniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                fParent = (FIObject)tNodeParent.Tag;
                // --
                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    foreach (FOpcDevice fOdv in ((FOpcDriver)fParent).fChildOpcDeviceCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOdv.uniqueIdToString);
                        tNodeChild.Tag = fOdv;
                        FCommon.refreshTreeNodeOfObject(fOdv, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcDevice)
                {
                    foreach (FOpcSession fOsn in ((FOpcDevice)fParent).fChildOpcSessionCollection)
                    {
                        tNodeChild = new UltraTreeNode(fOsn.uniqueIdToString);
                        tNodeChild.Tag = fOsn;
                        FCommon.refreshTreeNodeOfObject(fOsn, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcSession)
                {
                    foreach (FItemName fItn in ((FOpcSession)fParent).FChildItemNameCollection)
                    {
                        tNodeChild = new UltraTreeNode(fItn.uniqueIdToString);
                        tNodeChild.Tag = fItn;
                        FCommon.refreshTreeNodeOfObject(fItn, tvwTree, tNodeChild);
                        tNodeParent.Nodes.Add(tNodeChild);
                    }                    
                }                
                else if (fParent.fObjectType == FObjectType.ItemName)
                {
                    // --
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

                if (fNewChild.fObjectType == FObjectType.OpcDevice)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                  
                    fRefChild = ((FOpcDevice)fNewChild).fNextSibling;
                }
                else if (fNewChild.fObjectType == FObjectType.OpcSession)
                {
                    tNodeParent = tvwTree.GetNodeByKey(fParent.uniqueIdToString);                    
                    fRefChild = ((FOpcSession)fNewChild).fNextSibling;
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

                if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    if (((FOpcDevice)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcDevice)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    if (((FOpcSession)fObject).fPreviousSibling == null)
                    {
                        if (tPrevNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcSession)fObject).fPreviousSibling == (FIObject)tPrevNode.Tag)
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

                if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    if (((FOpcDevice)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcDevice)fObject).fNextSibling == (FIObject)tNextNode.Tag)
                        {
                            return;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    if (((FOpcSession)fObject).fNextSibling == null)
                    {
                        if (tNextNode == null)
                        {
                            return;
                        }
                    }
                    else
                    {
                        if (((FOpcSession)fObject).fNextSibling == (FIObject)tNextNode.Tag)
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
            string uniqueId = string.Empty;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeParent = tvwTree.ActiveNode;
                fParent = (FIObject)tNodeParent.Tag;

                // --

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).appendChildOpcDevice(new FOpcDevice(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.OpcDevice)
                {
                    fNewChild = ((FOpcDevice)fParent).appendChildOpcSession(new FOpcSession(this.m_fOpmCore.fOpmFileInfo.fOpcDriver));
                    uniqueId = fNewChild.uniqueIdToString;
                }                

                // --

                tNodeNewChild = new UltraTreeNode(uniqueId);
                tNodeNewChild.Tag = fNewChild;
                FCommon.refreshTreeNodeOfObject(fNewChild, tvwTree, tNodeNewChild);                
                tNodeParent.Nodes.Add(tNodeNewChild);
                // --
                tvwTree.SelectedNodes.Clear();
                tvwTree.ActiveNode = tNodeNewChild;

                // --

                loadTreeOfChildObject(tNodeNewChild);

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

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertBeforeChildOpcDevice(
                        new FOpcDevice(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcDevice)fRefChild
                        );
                    // --
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.OpcDevice)
                {
                    fNewChild = ((FOpcDevice)fParent).insertBeforeChildOpcSession(
                        new FOpcSession(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcSession)fRefChild
                        );
                    // --
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.ItemName)
                {
                    // --
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

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    fNewChild = ((FOpcDriver)fParent).insertAfterChildOpcDevice(
                        new FOpcDevice(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcDevice)fRefChild
                        );
                    // --
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.OpcDevice)
                {
                    fNewChild = ((FOpcDevice)fParent).insertAfterChildOpcSession(
                        new FOpcSession(this.m_fOpmCore.fOpmFileInfo.fOpcDriver),
                        (FOpcSession)fRefChild
                        );
                    // --
                    uniqueId = fNewChild.uniqueIdToString;
                }                
                else if (fParent.fObjectType == FObjectType.ItemName)
                {
                    // --
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
            string psnUniqueId = string.Empty;

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
                        if (((FOpcDevice)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.OpcDevice)
                {
                    foreach (UltraTreeNode tNode in tvwTree.SelectedNodes)
                    {
                        fChild = (FIObject)tNode.Tag;
                        if (((FOpcSession)fChild).locked)
                        {
                            FDebug.throwFException(m_fOpmCore.fWsmCore.fUIWizard.generateMessage("E0002", new object[] { "Object" }));
                        }
                    }
                }
                else if (fParent.fObjectType == FObjectType.ItemName)
                {

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
                    fChilds = new FOpcDevice[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcDevice)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcDriver)fParent).removeChildOpcDevice((FOpcDevice[])fChilds);
                }
                else if (fParent.fObjectType == FObjectType.OpcDevice)
                {
                    fChilds = new FOpcSession[tvwTree.SelectedNodes.Count];
                    // --
                    for (int i = 0; i < tvwTree.SelectedNodes.Count; i++)
                    {
                        fChilds[i] = (FOpcSession)tvwTree.SelectedNodes[i].Tag;
                    }
                    // --
                    ((FOpcDevice)fParent).removeChildOpcSession((FOpcSession[])fChilds);
                }                
                else if (fParent.fObjectType == FObjectType.ItemName)
                {
                    // --
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

                if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    ((FOpcDevice)fObject).moveUp();
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    ((FOpcSession)fObject).moveUp();
                }                
                else if (fObject.fObjectType == FObjectType.ItemName)
                {
                    
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

                if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    ((FOpcDevice)fObject).moveDown();
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    ((FOpcSession)fObject).moveDown();
                }                
                else if (fObject.fObjectType == FObjectType.ItemName)
                {
                    
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
                    foreach (UltraTreeNode tNodeOdv in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeOdv.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeOsn in tNodeOdv.Nodes)
                        {
                            tNodeOsn.Expanded = true;
                            // --
                            foreach (UltraTreeNode tNodeOml in tNodeOsn.Nodes)
                            {
                                tNodeOml.Expanded = true;
                            }
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    tvwTree.ActiveNode.Expanded = true;
                    // --
                    foreach (UltraTreeNode tNodeOsn in tvwTree.ActiveNode.Nodes)
                    {
                        tNodeOsn.Expanded = true;
                        // --
                        foreach (UltraTreeNode tNodeOml in tNodeOsn.Nodes)
                        {
                            tNodeOml.Expanded = true;
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    tvwTree.ActiveNode.Expanded = true;                    
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
                    // OPC Driver
                    foreach (UltraTreeNode tNodeOdv in tvwTree.ActiveNode.Nodes)
                    {
                        // OPC Device
                        foreach (UltraTreeNode tNodeOsn in tNodeOdv.Nodes)
                        {
                            tNodeOsn.Expanded = false;
                        }
                        // --
                        tNodeOdv.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    // OPC Session
                    foreach (UltraTreeNode tNodeOsn in tvwTree.ActiveNode.Nodes)
                    {   
                        tNodeOsn.Expanded = false;
                    }
                    // --
                    tvwTree.ActiveNode.Expanded = false;
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
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
 
        private void procMenuOpenOpcDevice(
            )
        {
            FOpcDevice fOpcDevice = null;

            try
            {
                fOpcDevice = (FOpcDevice)tvwTree.ActiveNode.Tag;
                fOpcDevice.open();             
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcDevice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCloseOpcDevice(
            )
        {
            FOpcDevice fOpcDevice = null;

            try
            {
                fOpcDevice = (FOpcDevice)tvwTree.ActiveNode.Tag;
                fOpcDevice.close();                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcDevice = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRefreshItemName(
            )
        {
            FOpcSession fOpcSession = null;

            try
            {
                fOpcSession = (FOpcSession)tvwTree.ActiveNode.Tag;
                fOpcSession.refreshItemNameList();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fOpcSession = null;
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

                if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    ((FOpcDevice)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    ((FOpcSession)fObject).cut();
                }
                else if (fObject.fObjectType == FObjectType.ItemName)
                {
                    
                }

                // -- 

                tvwTree.beginUpdate();
                
                // --
                
                tNode.Remove();
                
                // --

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

                if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    ((FOpcDevice)fObject).copy();
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    ((FOpcSession)fObject).copy();
                }                
                else if (fObject.fObjectType == FObjectType.ItemName)
                {
                    
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

                if (fRefObject.fObjectType == FObjectType.OpcDevice)
                {
                    fNewObject = ((FOpcDevice)fRefObject).pasteSibling();
                    uniqueId = fNewObject.uniqueIdToString;
                }
                else if (fRefObject.fObjectType == FObjectType.OpcSession)
                {
                    fNewObject = ((FOpcSession)fRefObject).pasteSibling();
                    uniqueId = fNewObject.uniqueIdToString;
                }                
                else if (fRefObject.fObjectType == FObjectType.ItemName)
                {
                    
                }

                // --

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

                if (fParent.fObjectType == FObjectType.OpcDriver)
                {
                    uniqueId = fNewChild.uniqueIdToString;
                }
                else if (fParent.fObjectType == FObjectType.OpcDevice)
                {
                    fNewChild = ((FOpcDevice)fParent).pasteChild();
                    uniqueId = fNewChild.uniqueIdToString;
                }                
                else if (fParent.fObjectType == FObjectType.OpcItem)
                {
                    // --
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
     
        private void procMenuSearch(
            string searchWord
            )
        {
            UltraTreeNode tNode = null;
            FIObject fBase = null;
            FIObject fResult = null;                           
            string uniqueId = null;            

            try
            {
                tNode = tvwTree.ActiveNode;
                fBase = (FIObject)tNode.Tag;                                

                // --                              

                fResult = m_fOpmCore.fOpmFileInfo.fOpcDriver.searchItemNameSeries(fBase, searchWord);                
                if (fResult == null)
                {
                    FMessageBox.showInformation("Search", m_fOpmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                    return;
                }

                // --

                tvwTree.beginUpdate();

                // --

                expandTreeForSearch(fResult);
                uniqueId = fResult.uniqueIdToString;
                // --                
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
                // OPC Device와 OPC Session 검색에만 사용된다.
                // *** 
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
            string parentUid = string.Empty;

            try
            {
                if (fObject.fObjectType == FObjectType.OpcDriver)
                {
                    return;
                }
                
                // --

                fParent = m_fOpmCore.fOpmFileInfo.fOpcDriver.getParentOfObject(fObject);
                parentUid = fParent.uniqueIdToString;

                // --                             

                tNodeParent = tvwTree.GetNodeByKey(parentUid);
                if (tNodeParent == null || !tNodeParent.Expanded)
                {
                    expandTreeForSearch(fParent);
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
     
        #region FItemNameOfOpcSession Form Event Handler

        private void FItemNameOfOpcSession_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designTreeOfOpcLibraryModeler();

                // --

                tvwTree.setPopupMenu((PopupMenuTool)mnuMenu.Tools[FMenuKey.MenuOdmPopupMenu]);                

                // --

                m_fEventHandler = new FEventHandler(m_fOpmCore.fOpmFileInfo.fOpcDriver, tvwTree);
                // --
                m_fEventHandler.ObjectModifyCompleted += new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);
                m_fEventHandler.ObjectInsertBeforeCompleted += new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                m_fEventHandler.ObjectInsertAfterCompleted += new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                m_fEventHandler.ObjectAppendCompleted += new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                m_fEventHandler.ObjectRemoveCompleted += new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                m_fEventHandler.ObjectMoveUpCompleted += new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                m_fEventHandler.ObjectMoveDownCompleted += new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                m_fEventHandler.OpcDeviceStateChanged += new FOpcDeviceStateChangedEventHandler(m_fEventHandler_OpcDeviceStateChanged);
                m_fEventHandler.OpcSessionItemNameRefreshed += new FOpcSessionItemNameRefreshedEventHandler(m_fEventHandler_OpcSessionItemNameRefreshed);

                // --

                pgdProp.DynPropNoticeRaised += new FDynPropNoticeRaisedEventHandler(pgdProp_DynPropNoticeRaised);
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

        private void FItemNameOfOpcSession_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

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

        private void FItemNameOfOpcSession_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadTreeOfObject();
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

        private void FItemNameOfOpcSession_FormClosing(
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
                    m_fEventHandler.ObjectModifyCompleted -= new FObjectModifyCompletedEventHandler(m_fEventHandler_ObjectModifyCompleted);
                    m_fEventHandler.ObjectInsertBeforeCompleted -= new FObjectInsertBeforeCompletedEventHandler(m_fEventHandler_ObjectInsertBeforeCompleted);
                    m_fEventHandler.ObjectInsertAfterCompleted -= new FObjectInsertAfterCompletedEventHandler(m_fEventHandler_ObjectInsertAfterCompleted);
                    m_fEventHandler.ObjectAppendCompleted -= new FObjectAppendCompletedEventHandler(m_fEventHandler_ObjectAppendCompleted);
                    m_fEventHandler.ObjectRemoveCompleted -= new FObjectRemoveCompletedEventHandler(m_fEventHandler_ObjectRemoveCompleted);
                    m_fEventHandler.ObjectMoveUpCompleted -= new FObjectMoveUpCompletedEventHandler(m_fEventHandler_ObjectMoveUpCompleted);
                    m_fEventHandler.ObjectMoveDownCompleted -= new FObjectMoveDownCompletedEventHandler(m_fEventHandler_ObjectMoveDownCompleted);
                    m_fEventHandler.OpcDeviceStateChanged -= new FOpcDeviceStateChangedEventHandler(m_fEventHandler_OpcDeviceStateChanged);
                    m_fEventHandler.OpcSessionItemNameRefreshed -= new FOpcSessionItemNameRefreshedEventHandler(m_fEventHandler_OpcSessionItemNameRefreshed);
                    // --
                    m_fEventHandler = null;
                }

                // --

                pgdProp.DynPropNoticeRaised -= new FDynPropNoticeRaisedEventHandler(pgdProp_DynPropNoticeRaised);

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

        private void m_fEventHandler_ObjectInsertBeforeCompleted(
            object sender,
            FObjectEventArgs e
            )
        {
            try
            {
                if (
                    e.fObject.fObjectType == FObjectType.OpcDevice ||
                    e.fObject.fObjectType == FObjectType.OpcSession
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
                    e.fObject.fObjectType == FObjectType.OpcDevice ||
                    e.fObject.fObjectType == FObjectType.OpcSession
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
                    e.fObject.fObjectType == FObjectType.OpcDevice ||
                    e.fObject.fObjectType == FObjectType.OpcSession
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
                    e.fObject.fObjectType == FObjectType.OpcDevice ||
                    e.fObject.fObjectType == FObjectType.OpcSession
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
                    e.fObject.fObjectType == FObjectType.OpcDevice ||
                    e.fObject.fObjectType == FObjectType.OpcSession 
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
                    e.fObject.fObjectType == FObjectType.OpcDevice ||
                    e.fObject.fObjectType == FObjectType.OpcSession
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
                    e.fObject.fObjectType == FObjectType.OpcDevice ||
                    e.fObject.fObjectType == FObjectType.OpcSession
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
        
        //------------------------------------------------------------------------------------------------------------------------

        private void m_fEventHandler_OpcDeviceStateChanged(
            object sender,
            FOpcDeviceStateChangedEventArgs e
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                if (e.fOpcDeviceStateChangedLog.fResultCode != FResultCode.Success)
                {
                    return;
                }

                // --

                tNode = tvwTree.GetNodeByKey(e.fOpcDeviceStateChangedLog.uniqueIdToString);
                if (
                    e.fOpcDeviceStateChangedLog.fState == FDeviceState.Opened ||
                    e.fOpcDeviceStateChangedLog.fState == FDeviceState.Closed
                    )
                {
                    if (tNode != null && tNode.IsActive)
                    {
                        ((FPropOdv)pgdProp.selectedObject).setChangedState(e.fOpcDeviceStateChangedLog.fState);
                        controlMenu();
                    }
                }

                // --

                if (tvwTree.ActiveNode != null)
                {
                    if (((FIObject)tvwTree.ActiveNode.Tag).fObjectType == FObjectType.OpcMessage)
                    {
                        controlMenu();
                    }
                }

                // --

                FCommon.refreshTreeNodeOfObject((FIObject)tNode.Tag, tvwTree, tNode);
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

        private void m_fEventHandler_OpcSessionItemNameRefreshed(
            object sender, 
            FOpcSessionItemNameRefreshedEventArgs e
            )
        {
            UltraTreeNode tNodeOsn = null;

            try
            {
                tNodeOsn = tvwTree.GetNodeByKey(e.fOpcSession.uniqueIdToString);
                // --
                tNodeOsn.Nodes.Clear();
                loadTreeOfChildObject(tNodeOsn);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                tNodeOsn = null;
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
                else if (fObject.fObjectType == FObjectType.OpcDevice)
                {
                    pgdProp.selectedObject = new FPropOdv(m_fOpmCore, pgdProp, (FOpcDevice)fObject);
                }
                else if (fObject.fObjectType == FObjectType.OpcSession)
                {
                    pgdProp.selectedObject = new FPropOsn(m_fOpmCore, pgdProp, (FOpcSession)fObject);
                }                
                else if (fObject.fObjectType == FObjectType.ItemName)
                {
                    pgdProp.selectedObject = new FPropItn(m_fOpmCore, pgdProp, (FItemName)fObject);
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
                fObject = null;
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
                    if (mnuMenu.Tools[FMenuKey.MenuOsnRemove].SharedProps.Enabled)
                    {
                        procMenuRemoveObject();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.X)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOsnCut].SharedProps.Enabled)
                    {
                        procMenuCut();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.C)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOsnCopy].SharedProps.Enabled)
                    {
                        procMenuCopy();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.V)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOsnPasteSibling].SharedProps.Enabled)
                    {
                        procMenuPasteSibling();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.B)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOsnPasteChild].SharedProps.Enabled)
                    {
                        procMenuPasteChild();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.U)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOsnMoveUp].SharedProps.Enabled)
                    {
                        procMenuMoveUpObject(FMenuKey.MenuOdmMoveUp);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.D)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOsnMoveDown].SharedProps.Enabled)
                    {
                        procMenuMoveDownObject(FMenuKey.MenuOdmMoveDown);
                    }
                }
                else if (e.Control && e.KeyCode == Keys.E)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOsnExpand].SharedProps.Enabled)
                    {
                        procMenuExpand();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.L)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOsnCollapse].SharedProps.Enabled)
                    {
                        procMenuCollapse();
                    }
                }
                else if (e.Control && e.KeyCode == Keys.R)
                {
                    if (mnuMenu.Tools[FMenuKey.MenuOsnRelation].SharedProps.Enabled)
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

                if (e.Tool.Key == FMenuKey.MenuOsnOpenOpcDevice)
                {
                    procMenuOpenOpcDevice();
                }
                else if (e.Tool.Key == FMenuKey.MenuOsnCloseOpcDevice)
                {
                    procMenuCloseOpcDevice();
                }                
                // --
                else if (e.Tool.Key == FMenuKey.MenuOsnRefreshItemName)
                {
                    procMenuRefreshItemName();
                }                
                // --
                else if (e.Tool.Key == FMenuKey.MenuOsnExpand)
                {
                    procMenuExpand();
                }
                else if (e.Tool.Key == FMenuKey.MenuOsnCollapse)
                {
                    procMenuCollapse();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuOsnCut)
                {
                    procMenuCut();
                }
                else if (e.Tool.Key == FMenuKey.MenuOsnCopy)
                {
                    procMenuCopy();
                }
                else if (e.Tool.Key == FMenuKey.MenuOsnPasteSibling)
                {
                    procMenuPasteSibling();
                }
                else if (e.Tool.Key == FMenuKey.MenuOsnPasteChild)
                {
                    procMenuPasteChild();
                }                
                // --
                else if (e.Tool.Key == FMenuKey.MenuOsnRemove)
                {
                    procMenuRemoveObject();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuOsnMoveUp)
                {
                    procMenuMoveUpObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuOsnMoveDown)
                {
                    procMenuMoveDownObject(e.Tool.Key);
                }
                else if (e.Tool.Key == FMenuKey.MenuOsnRelation)
                {
                    procMenuRelation();
                }
                // --
                else if (
                    e.Tool.Key == FMenuKey.MenuOdmInsertBeforeOpcDevice ||
                    e.Tool.Key == FMenuKey.MenuOdmInsertBeforeOpcSession
                    )
                {
                    procMenuInsertBeforeObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuOdmInsertAfterOpcDevice ||
                    e.Tool.Key == FMenuKey.MenuOdmInsertAfterOpcSession 
                    )
                {
                    procMenuInsertAfterObject(e.Tool.Key);
                }
                else if (
                    e.Tool.Key == FMenuKey.MenuOdmAppendOpcDevice ||
                    e.Tool.Key == FMenuKey.MenuOdmAppendOpcSession                    
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

        #region pgdProp Control Event Handler

        private void pgdProp_DynPropNoticeRaised(
            object sender, 
            FDynPropNoticeRaisedEventArgs e            
            )
        {
            try
            {
                if (e.fDynProp is FPropOsn)
                {                    
                    if (e.contents == "LibraryChanged")
                    {
                        // changeOpcSessionLibrary(((FPropOsn)e.fDynProp).fOpcSession);                        
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
