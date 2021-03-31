/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FDataSEtGenerator.cs
--  Creator         : spike.lee
--  Create Date     : 2017.02.14
--  Description     : FAMate OPC Modeler Data Set Generator Form Class 
--  History         : Created by spike.lee at 2017.02.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win;

namespace Nexplant.MC.OpcModeler
{
    public partial class FDataSetGenerator : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FDataSet m_fDataSet = null;
        private FIObject m_fTargetObject = null;
        private bool m_modifyCheckState = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDataSetGenerator(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSetGenerator(
            FOpmCore fOpmCore,
            FDataSet fDataSet,
            FIObject fTargetObject
            )
            : this()
        {   
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fDataSet = fDataSet;
            m_fTargetObject = fTargetObject;
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
                    m_fDataSet = null;
                    m_fTargetObject = null;
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

        private void designTreeOfObject(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                
                // --
                
                tvwTree.ImageList.Images.Add("OpcMessage_Primary_unlock", Properties.Resources.OpcMessage_Primary_unlock);
                tvwTree.ImageList.Images.Add("OpcMessage_Primary_lock", Properties.Resources.OpcMessage_Primary_lock);
                tvwTree.ImageList.Images.Add("OpcMessage_Secondary_unlock", Properties.Resources.OpcMessage_Secondary_unlock);
                tvwTree.ImageList.Images.Add("OpcMessage_Secondary_lock", Properties.Resources.OpcMessage_Secondary_lock);
                // --
                tvwTree.ImageList.Images.Add("OpcEventItemList_unlock", Properties.Resources.OpcEventItemList_unlock);
                tvwTree.ImageList.Images.Add("OpcEventItemList_lock", Properties.Resources.OpcEventItemList_lock);
                tvwTree.ImageList.Images.Add("OpcEventItem_unlock", Properties.Resources.OpcEventItem_unlock);
                tvwTree.ImageList.Images.Add("OpcEventItem_lock", Properties.Resources.OpcEventItem_lock);
                // --
                tvwTree.ImageList.Images.Add("OpcItemList_unlock", Properties.Resources.OpcItemList_unlock);
                tvwTree.ImageList.Images.Add("OpcItemList_lock", Properties.Resources.OpcItemList_lock);
                tvwTree.ImageList.Images.Add("OpcItem_unlock", Properties.Resources.OpcItem_unlock);
                tvwTree.ImageList.Images.Add("OpcItem_lock", Properties.Resources.OpcItem_lock);

                // --

                tvwTree.ImageList.Images.Add("HostMessage_Command_unlock", Properties.Resources.HostMessage_Command_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Command_lock", Properties.Resources.HostMessage_Command_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Reply_unlock", Properties.Resources.HostMessage_Reply_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Reply_lock", Properties.Resources.HostMessage_Reply_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Unsolicited_unlock", Properties.Resources.HostMessage_Unsolicited_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Unsolicited_lock", Properties.Resources.HostMessage_Unsolicited_lock);
                // --
                tvwTree.ImageList.Images.Add("HostItem_List_unlock", Properties.Resources.HostItem_List_unlock);
                tvwTree.ImageList.Images.Add("HostItem_List_lock", Properties.Resources.HostItem_List_lock);
                tvwTree.ImageList.Images.Add("HostItem_unlock", Properties.Resources.HostItem_unlock);
                tvwTree.ImageList.Images.Add("HostItem_lock", Properties.Resources.HostItem_lock);

                // --

                tvwTree.ImageList.Images.Add("Repository_unlock", Properties.Resources.Repository_unlock);
                tvwTree.ImageList.Images.Add("Repository_lock", Properties.Resources.Repository_lock);
                tvwTree.ImageList.Images.Add("Column_List", Properties.Resources.Column_List);
                tvwTree.ImageList.Images.Add("Column", Properties.Resources.Column);
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
        
        private void loadTreeOfOpcMessage(
            )
        {
            FOpcMessage fOmg = null;
            UltraTreeNode tNodeOmg = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fOmg = (FOpcMessage)m_fTargetObject;

                // --

                tNodeOmg = new UltraTreeNode(fOmg.uniqueIdToString);
                tNodeOmg.Tag = fOmg;
                FCommon.refreshTreeNodeOfObject(fOmg, tvwTree, tNodeOmg);

                // --

                foreach (FOpcEventItemList fOel in fOmg.fChildOpcEventItemListCollection)
                {
                    loadTreeOfOpcEventItemList(tNodeOmg, fOel);
                }
                foreach (FOpcItemList fOil in fOmg.fChildOpcItemListCollection)
                {
                    loadTreeOfOpcItemList(tNodeOmg, fOil);
                }
                
                // --

                tNodeOmg.Expanded = true;
                tvwTree.Nodes.Add(tNodeOmg);

                // --

                tvwTree.ActiveNode = tNodeOmg;                

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
                tNodeOmg = null;
                fOmg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfOpcEventItemList(
            UltraTreeNode tParentNode,
            FOpcEventItemList fOel
            )
        {
            UltraTreeNode tNodeOel = null;

            try
            {

                tNodeOel = new UltraTreeNode(fOel.uniqueIdToString);
                tNodeOel.Tag = fOel;
                tNodeOel.Override.NodeStyle = NodeStyle.CheckBox;                
                tNodeOel.CheckedState = CheckState.Checked;
                FCommon.refreshTreeNodeOfObject(fOel, tvwTree, tNodeOel);

                //  --

                foreach (FOpcEventItem fChild in fOel.fChildOpcEventItemCollection)
                {
                    loadTreeOfOpcEventItem(tNodeOel, fChild);
                }

                // --

                tNodeOel.Expanded = true;
                tParentNode.Nodes.Add(tNodeOel);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeOel = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfOpcEventItem(
            UltraTreeNode tParentNode,
            FOpcEventItem fOei
            )
        {
            UltraTreeNode tNodeOei = null;

            try
            {

                tNodeOei = new UltraTreeNode(fOei.uniqueIdToString);
                tNodeOei.Tag = fOei;
                tNodeOei.Override.NodeStyle = NodeStyle.CheckBox;
                tNodeOei.CheckedState = CheckState.Checked;
                FCommon.refreshTreeNodeOfObject(fOei, tvwTree, tNodeOei);

                //  --

                tNodeOei.Expanded = true;
                tParentNode.Nodes.Add(tNodeOei);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeOei = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfOpcItemList(
            UltraTreeNode tParentNode,
            FOpcItemList fOil
            )
        {
            UltraTreeNode tNodeOil = null;

            try
            {

                tNodeOil = new UltraTreeNode(fOil.uniqueIdToString);
                tNodeOil.Tag = fOil;
                tNodeOil.Override.NodeStyle = NodeStyle.CheckBox;
                tNodeOil.CheckedState = CheckState.Checked;
                FCommon.refreshTreeNodeOfObject(fOil, tvwTree, tNodeOil);

                //  --

                foreach (FOpcItem fChild in fOil.fChildOpcItemCollection)
                {
                    loadTreeOfOpcItem(tNodeOil, fChild);
                }

                // --

                tNodeOil.Expanded = true;
                tParentNode.Nodes.Add(tNodeOil);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeOil = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfOpcItem(
            UltraTreeNode tParentNode,
            FOpcItem fOit
            )
        {
            UltraTreeNode tNodeOit = null;

            try
            {

                tNodeOit = new UltraTreeNode(fOit.uniqueIdToString);
                tNodeOit.Tag = fOit;
                tNodeOit.Override.NodeStyle = NodeStyle.CheckBox;
                tNodeOit.CheckedState = CheckState.Checked;
                FCommon.refreshTreeNodeOfObject(fOit, tvwTree, tNodeOit);

                //  --

                tNodeOit.Expanded = true;
                tParentNode.Nodes.Add(tNodeOit);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeOit = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfHostMessage(
            )
        {
            FHostMessage fHmg = null;
            UltraTreeNode tNodeHmg = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fHmg = (FHostMessage)m_fTargetObject;

                // --

                tNodeHmg = new UltraTreeNode(fHmg.uniqueIdToString);
                tNodeHmg.Tag = fHmg;
                FCommon.refreshTreeNodeOfObject(fHmg, tvwTree, tNodeHmg);

                // --

                foreach (FHostItem fHit in fHmg.fChildHostItemCollection)
                {
                    loadTreeOfHostItem(tNodeHmg, fHit);
                }                

                // --

                tNodeHmg.Expanded = true;
                tvwTree.Nodes.Add(tNodeHmg);

                // --

                tvwTree.ActiveNode = tNodeHmg;

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
                fHmg = null;
                tNodeHmg = null;                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfHostItem(
            UltraTreeNode tParentNode,
            FHostItem fHit
            )
        {
            UltraTreeNode tNodeHit = null;

            try
            {

                tNodeHit = new UltraTreeNode(fHit.uniqueIdToString);
                tNodeHit.Tag = fHit;
                tNodeHit.Override.NodeStyle = NodeStyle.CheckBox;
                tNodeHit.CheckedState = CheckState.Checked;
                FCommon.refreshTreeNodeOfObject(fHit, tvwTree, tNodeHit);

                //  --

                foreach (FHostItem fChild in fHit.fChildHostItemCollection)
                {
                    loadTreeOfHostItem(tNodeHit, fChild);
                }                

                // --

                tNodeHit.Expanded = true;
                tParentNode.Nodes.Add(tNodeHit);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeHit = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfRepository(
            )
        {
            FRepository fRps = null;
            UltraTreeNode tNodeRps = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                fRps = (FRepository)m_fTargetObject;

                // --

                tNodeRps = new UltraTreeNode(fRps.uniqueIdToString);
                tNodeRps.Tag = fRps;
                FCommon.refreshTreeNodeOfObject(fRps, tvwTree, tNodeRps);

                // --

                foreach (FColumn fCol in fRps.fChildColumnCollection)
                {
                    loadTreeOfColumn(tNodeRps, fCol);
                }

                // --

                tNodeRps.Expanded = true;
                tvwTree.Nodes.Add(tNodeRps);

                // --

                tvwTree.ActiveNode = tNodeRps;

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
                fRps = null;
                tNodeRps = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfColumn(
            UltraTreeNode tParentNode,
            FColumn fCol
            )
        {
            UltraTreeNode tNodeCol = null;

            try
            {

                tNodeCol = new UltraTreeNode(fCol.uniqueIdToString);
                tNodeCol.Tag = fCol;
                tNodeCol.Override.NodeStyle = NodeStyle.CheckBox;
                tNodeCol.CheckedState = CheckState.Checked;
                FCommon.refreshTreeNodeOfObject(fCol, tvwTree, tNodeCol);

                //  --

                foreach (FColumn fChild in fCol.fChildColumnCollection)
                {
                    loadTreeOfColumn(tNodeCol, fChild);
                }

                // --

                tNodeCol.Expanded = true;
                tParentNode.Nodes.Add(tNodeCol);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeCol = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void changeParentTreeNodeCheckState(
            UltraTreeNode tNode,
            CheckState checkState
            )
        {
            CheckState chkState = CheckState.Unchecked;

            try
            {
                if (tNode.Key == m_fTargetObject.uniqueIdToString)
                {
                    return;
                }

                // --

                if (checkState == CheckState.Checked)
                {
                    chkState = CheckState.Checked;
                }
                else
                {
                    foreach (UltraTreeNode tChild in tNode.Nodes)
                    {
                        if (tChild.CheckedState == CheckState.Checked)
                        {
                            chkState = CheckState.Checked;
                            break;
                        }
                    }
                }

                // --

                tNode.CheckedState = chkState;

                // --

                changeParentTreeNodeCheckState(tNode.Parent, checkState);
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

        private void changeChildTreeNodeCheckState(
            UltraTreeNode tNode, 
            CheckState checkState
            )
        {
            try
            {
                tNode.CheckedState = checkState;
                // --
                foreach (UltraTreeNode tChildNode in tNode.Nodes)
                {
                    changeChildTreeNodeCheckState(tChildNode, checkState);
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

        private bool validateTreeNode(
            UltraTreeNode tNode
            )
        {
            try
            {
                if (tNode.CheckedState == CheckState.Checked)
                {
                    return true;
                }

                // --

                foreach (UltraTreeNode tChild in tNode.Nodes)
                {
                    if (validateTreeNode(tChild))
                    {
                        return true;
                    }
                }

                // --

                return false;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateDataSetByOpcMessage(
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tNode = tvwTree.Nodes[m_fTargetObject.uniqueIdToString];
                // --
                foreach (UltraTreeNode tChild in tNode.Nodes)
                {
                    generateDataSetByOpcMessage(m_fDataSet, tChild);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateDataSetByOpcMessage(
            FIObject fParent,
            UltraTreeNode tNode            
            )
        {
            FIObject fObject = null;
            FData fDat = null;

            try
            {
                if (tNode.CheckedState == CheckState.Unchecked)
                {
                    return;
                }

                // --

                fObject = (FIObject)tNode.Tag;
                
                // --

                if (fObject.fObjectType == FObjectType.OpcEventItemList)
                {
                    fDat = new FData(m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fDat.fTargetType = FDataTargetType.Item;
                    fDat.fFormat = FFormat.List;
                    fDat.fontBold = fObject.fontBold;
                    fDat.fontColor = fObject.fontColor;
                    fDat.name = fObject.name;
                    fDat.targetItem = fObject.name;                    
                }
                else if (fObject.fObjectType == FObjectType.OpcEventItem)
                {
                    fDat = new FData(m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fDat.fTargetType = FDataTargetType.Item;
                    fDat.fFormat = (FFormat)((FOpcEventItem)fObject).fFormat;
                    fDat.fontBold = fObject.fontBold;
                    fDat.fontColor = fObject.fontColor;
                    fDat.name = fObject.name;
                    fDat.targetItem = fObject.name;
                }
                else if (fObject.fObjectType == FObjectType.OpcItemList)
                {
                    fDat = new FData(m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fDat.fTargetType = FDataTargetType.Item;
                    fDat.fFormat = FFormat.List;
                    fDat.fontBold = fObject.fontBold;
                    fDat.fontColor = fObject.fontColor;
                    fDat.name = fObject.name;
                    fDat.targetItem = fObject.name;
                }
                else if (fObject.fObjectType == FObjectType.OpcItem)
                {
                    fDat = new FData(m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fDat.fTargetType = FDataTargetType.Item;
                    fDat.fFormat = (FFormat)((FOpcItem)fObject).fFormat;
                    fDat.fontBold = fObject.fontBold;
                    fDat.fontColor = fObject.fontColor;
                    fDat.name = fObject.name;
                    fDat.targetItem = fObject.name;
                }

                // --

                if (fDat != null)
                {
                    foreach (UltraTreeNode tChild in tNode.Nodes)
                    {
                        generateDataSetByOpcMessage(fDat, tChild);
                    }

                    // --

                    if (fParent.fObjectType == FObjectType.DataSet)
                    {
                        ((FDataSet)fParent).appendChildData(fDat);
                    }
                    else if (fParent.fObjectType == FObjectType.Data)
                    {
                        ((FData)fParent).appendChildData(fDat);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fDat = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateDataSetByHostMessage(
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tNode = tvwTree.Nodes[m_fTargetObject.uniqueIdToString];
                // --
                foreach (UltraTreeNode tChild in tNode.Nodes)
                {
                    generateDataSetByHostMessage(m_fDataSet, tChild);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateDataSetByHostMessage(
            FIObject fParent,
            UltraTreeNode tNode
            )
        {
            FIObject fObject = null;
            FData fDat = null;

            try
            {
                if (tNode.CheckedState == CheckState.Unchecked)
                {
                    return;
                }

                // --

                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.HostItem)
                {
                    fDat = new FData(m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fDat.fTargetType = FDataTargetType.Item;
                    fDat.fFormat = ((FHostItem)fObject).fFormat;
                    fDat.fontBold = fObject.fontBold;
                    fDat.fontColor = fObject.fontColor;
                    fDat.name = fObject.name;
                    fDat.targetItem = fObject.name;
                }                

                // --

                if (fDat != null)
                {
                    foreach (UltraTreeNode tChild in tNode.Nodes)
                    {
                        generateDataSetByHostMessage(fDat, tChild);
                    }

                    // --

                    if (fParent.fObjectType == FObjectType.DataSet)
                    {
                        ((FDataSet)fParent).appendChildData(fDat);
                    }
                    else if (fParent.fObjectType == FObjectType.Data)
                    {
                        ((FData)fParent).appendChildData(fDat);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fDat = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateDataSetByRepository(
            )
        {
            UltraTreeNode tNode = null;

            try
            {
                tNode = tvwTree.Nodes[m_fTargetObject.uniqueIdToString];
                // --
                foreach (UltraTreeNode tChild in tNode.Nodes)
                {
                    generateDataSetByRepository(m_fDataSet, tChild);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void generateDataSetByRepository(
            FIObject fParent,
            UltraTreeNode tNode
            )
        {
            FIObject fObject = null;
            FData fDat = null;

            try
            {
                if (tNode.CheckedState == CheckState.Unchecked)
                {
                    return;
                }

                // --

                fObject = (FIObject)tNode.Tag;

                // --

                if (fObject.fObjectType == FObjectType.Column)
                {
                    fDat = new FData(m_fOpmCore.fOpmFileInfo.fOpcDriver);
                    fDat.fTargetType = FDataTargetType.Column;
                    fDat.fFormat = ((FColumn)fObject).fFormat;
                    fDat.fontBold = fObject.fontBold;
                    fDat.fontColor = fObject.fontColor;
                    fDat.name = fObject.name;
                    fDat.targetColumn = fObject.name;
                }

                // --

                if (fDat != null)
                {
                    foreach (UltraTreeNode tChild in tNode.Nodes)
                    {
                        generateDataSetByRepository(fDat, tChild);
                    }

                    // --

                    if (fParent.fObjectType == FObjectType.DataSet)
                    {
                        ((FDataSet)fParent).appendChildData(fDat);
                    }
                    else if (fParent.fObjectType == FObjectType.Data)
                    {
                        ((FData)fParent).appendChildData(fDat);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fObject = null;
                fDat = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FDataSetGenerator Form Event Handler

        private void FDataSetGenerator_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --                

                designTreeOfObject();

                // --

                if (m_fTargetObject.fObjectType == FObjectType.OpcMessage)
                {
                    loadTreeOfOpcMessage();
                }
                else if (m_fTargetObject.fObjectType == FObjectType.HostMessage)
                {
                    loadTreeOfHostMessage();
                }
                else if (m_fTargetObject.fObjectType == FObjectType.Repository)
                {
                    loadTreeOfRepository();
                }      
          
                // --

                btnOk.Enabled = validateTreeNode(tvwTree.Nodes[m_fTargetObject.uniqueIdToString]);
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

        #region tvwTree Control Event Handler

        private void tvwTree_BeforeCollapse(
            object sender,
            CancelableNodeEventArgs e
            )
        {
            try
            {
                e.Cancel = true;
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

        private void tvwTree_AfterCheck(
            object sender, 
            NodeEventArgs e
            )
        {
            try
            {
                if (m_modifyCheckState)
                {
                    return;
                }
                m_modifyCheckState = true;

                // --

                foreach (UltraTreeNode tNode in e.TreeNode.Nodes)
                {
                    changeChildTreeNodeCheckState(tNode, e.TreeNode.CheckedState);
                }
                changeParentTreeNodeCheckState(e.TreeNode.Parent, e.TreeNode.CheckedState);

                // --

                m_modifyCheckState = false;

                // --

                btnOk.Enabled = validateTreeNode(tvwTree.Nodes[m_fTargetObject.uniqueIdToString]);
            }
            catch (Exception ex)
            {
                m_modifyCheckState = false;
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                
            }
        }

        #endregion                

        //------------------------------------------------------------------------------------------------------------------------

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fTargetObject.fObjectType == FObjectType.OpcMessage)
                {
                    generateDataSetByOpcMessage();
                }
                else if (m_fTargetObject.fObjectType == FObjectType.HostMessage)
                {
                    generateDataSetByHostMessage();
                }
                else if (m_fTargetObject.fObjectType == FObjectType.Repository)
                {
                    generateDataSetByRepository();
                }

                // --

                this.Close();
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

    }   // Class end
}   // Namespace end
