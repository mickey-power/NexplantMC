/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FRelationViewer.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.08.01
--  Description     : FAMate OPC Modeler Relation Viewer Form Class 
--  History         : Created by Jeff.Kim at 2013.08.01
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
    public partial class FValidationViewer : Nexplant.MC.Core.FaUIs.FBaseStandardForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FValidationViewer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FValidationViewer(
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

        //------------------------------------------------------------------------------------------------------------------------

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

        private void designTreeOfValidationViewer(
            )
        {
            try
            {
                tvwTree.ImageList = new ImageList();
                // --
                tvwTree.ImageList.Images.Add("OpcDriver", Properties.Resources.OpcDriver);
                // --
                tvwTree.ImageList.Images.Add("Fail_OpcEventItem", Properties.Resources.OpcEventItem_unlock);
                tvwTree.ImageList.Images.Add("Fail_OpcItem", Properties.Resources.OpcItem_unlock);
                // --
                tvwTree.ImageList.Images.Add("Fail_Data", Properties.Resources.Data_unlock);
                // --
                tvwTree.ImageList.Images.Add("OpcEventItem", Properties.Resources.OpcEventItem_unlock);
                tvwTree.ImageList.Images.Add("OpcItem", Properties.Resources.OpcItem_unlock);
                // --
                tvwTree.ImageList.Images.Add("Data", Properties.Resources.Data_unlock);
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

        public void refresh(
            )
        {
            UltraTreeNode tNode = null;
            UltraTreeNode refNode = null;
            UltraTreeNode incNode = null;
            UltraTreeNode dataNode = null;
            Image icon = null;

            try
            {
                tNode = new UltraTreeNode(m_fOpmCore.fOpmFileInfo.fOpcDriver.name);
                tNode.Tag = m_fOpmCore.fOpmFileInfo.fOpcDriver;
                icon = FCommon.getImageOfObject(m_fOpmCore.fOpmFileInfo.fOpcDriver, tvwTree);
                if (icon != null)
                {
                    tNode.Override.ImageSize = new Size(16, 16);
                    tNode.Override.NodeAppearance.Image = icon;
                }

                // --

                refNode = new UltraTreeNode("OpcEventItem");
                refNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Fail_OpcEventItem"];
                addValidationFailedOpcEventItemNode(refNode);
                refNode.Expanded = true;
                // --
                
                incNode = new UltraTreeNode("OpcItem");
                incNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Fail_OpcItem"];
                addValidationFailedOpcItemNode(incNode);
                incNode.Expanded = true;

                // --

                dataNode = new UltraTreeNode("Data");
                dataNode.Override.NodeAppearance.Image = tvwTree.ImageList.Images["Fail_Data"];
                addValidationFailedDataNode(dataNode);
                dataNode.Expanded = true;
                
                // --

                tNode.Text = m_fOpmCore.fOpmFileInfo.fOpcDriver.ToString(FStringOption.Detail);
                tNode.Nodes.Add(refNode);
                tNode.Nodes.Add(incNode);
                tNode.Nodes.Add(dataNode);
                tNode.Expanded = true;

                // --

                tvwTree.beginUpdate();
                // --
                tvwTree.Nodes.Clear();                
                tvwTree.Nodes.Add(tNode);                
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
                refNode = null;
                incNode = null;
                icon = null;
                dataNode = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void addValidationFailedOpcEventItemNode(
            UltraTreeNode tNode
            )
        {
            UltraTreeNode tChildNode = null;            
            Image icon = null;            

            try
            {                
                foreach (FOpcLibraryGroup fOpcLibraryGroup in m_fOpmCore.fOpmFileInfo.fOpcDriver.fChildOpcLibraryGroupCollection)
                {
                    foreach (FOpcLibrary fOpcLibrary in fOpcLibraryGroup.fChildOpcLibraryCollection)
                    {
                        foreach (FOpcMessageList fOpcMessageList in fOpcLibrary.fChildOpcMessageListCollection)
                        {
                            foreach (FOpcMessages fOpcMessages in fOpcMessageList.fChildOpcMessagesCollection)
                            {
                                foreach (FOpcMessage fOpcMessage in fOpcMessages.fChildOpcMessageCollection)
                                {
                                    foreach (FOpcEventItemList fOpcEventItemList in fOpcMessage.fChildOpcEventItemListCollection)
                                    {
                                        foreach (FOpcEventItem fOpcEventItem in fOpcEventItemList.fChildOpcEventItemCollection)
                                        {
                                            bool validationFailed = false;
                                            if (fOpcEventItem.itemName.Contains("DBX"))
                                            {
                                                // --
                                                int length = fOpcEventItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length < 3)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcEventItem.fItemFormat != FTagFormat.Boolean)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcEventItem.itemArray)
                                                {
                                                    validationFailed = true;
                                                }

                                                // --
                                            }
                                            else if (fOpcEventItem.itemName.Contains("DBB"))
                                            {
                                                // --

                                                int length = fOpcEventItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length != 2)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcEventItem.fItemFormat != FTagFormat.Byte &&
                                                    fOpcEventItem.fItemFormat != FTagFormat.Char)
                                                {
                                                    validationFailed = true;
                                                }

                                                // --
                                            }
                                            else if (fOpcEventItem.itemName.Contains("DBW"))
                                            {
                                                // --

                                                int length = fOpcEventItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length != 2)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcEventItem.fItemFormat != FTagFormat.Word)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcEventItem.itemArray)
                                                {
                                                    validationFailed = true;
                                                }

                                                // --
                                            }
                                            else if (fOpcEventItem.itemName.Contains("DBD"))
                                            {
                                                // --

                                                int length = fOpcEventItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length != 2)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcEventItem.fItemFormat != FTagFormat.DWord)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcEventItem.itemArray)
                                                {
                                                    validationFailed = true;
                                                }
                                            }
                                            else if (fOpcEventItem.itemName.Contains("DBS"))
                                            {
                                                // --

                                                int length = fOpcEventItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length != 3)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcEventItem.fItemFormat != FTagFormat.String)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcEventItem.itemArray)
                                                {
                                                    validationFailed = true;
                                                }
                                            }

                                            // --

                                            if (validationFailed)
                                            {
                                                tChildNode = new UltraTreeNode(fOpcEventItem.name);
                                                tChildNode.Tag = fOpcEventItem;

                                                // --

                                                icon = FCommon.getImageOfObject(fOpcEventItem, tvwTree);
                                                if (icon != null)
                                                {
                                                    tChildNode.Override.ImageSize = new Size(16, 16);
                                                    tChildNode.Override.NodeAppearance.Image = icon;
                                                }

                                                // --

                                                tChildNode.Text = fOpcEventItem.ToString(FStringOption.Detail);
                                                tNode.Nodes.Add(tChildNode);
                                                tNode.Expanded = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tChildNode = null;
                icon = null;            
            }            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void addValidationFailedOpcItemNode(
            UltraTreeNode tNode
            )
        {
            UltraTreeNode tChildNode = null;
            Image icon = null;

            try
            {
                foreach (FOpcLibraryGroup fOpcLibraryGroup in m_fOpmCore.fOpmFileInfo.fOpcDriver.fChildOpcLibraryGroupCollection)
                {
                    foreach (FOpcLibrary fOpcLibrary in fOpcLibraryGroup.fChildOpcLibraryCollection)
                    {
                        foreach (FOpcMessageList fOpcMessageList in fOpcLibrary.fChildOpcMessageListCollection)
                        {
                            foreach (FOpcMessages fOpcMessages in fOpcMessageList.fChildOpcMessagesCollection)
                            {
                                foreach (FOpcMessage fOpcMessage in fOpcMessages.fChildOpcMessageCollection)
                                {
                                    foreach (FOpcItemList fOpcItemList in fOpcMessage.fChildOpcItemListCollection)
                                    {
                                        foreach (FOpcItem fOpcItem in fOpcItemList.fChildOpcItemCollection)
                                        {
                                            bool validationFailed = false;
                                            if (fOpcItem.itemName.Contains("DBX"))
                                            {
                                                // --
                                                int length = fOpcItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length < 3)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcItem.fItemFormat != FTagFormat.Boolean)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcItem.itemArray)
                                                {
                                                    validationFailed = true;
                                                }

                                                // --
                                            }
                                            else if (fOpcItem.itemName.Contains("DBB"))
                                            {
                                                // --

                                                int length = fOpcItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length != 2)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcItem.fItemFormat != FTagFormat.Byte &&
                                                    fOpcItem.fItemFormat != FTagFormat.Char)
                                                {
                                                    validationFailed = true;
                                                }

                                                // --
                                            }
                                            else if (fOpcItem.itemName.Contains("DBW"))
                                            {
                                                // --

                                                int length = fOpcItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length != 2)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcItem.fItemFormat != FTagFormat.Word)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcItem.itemArray)
                                                {
                                                    validationFailed = true;
                                                }

                                                // --
                                            }
                                            else if (fOpcItem.itemName.Contains("DBD"))
                                            {
                                                // --

                                                int length = fOpcItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length != 2)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcItem.fItemFormat != FTagFormat.DWord)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcItem.itemArray)
                                                {
                                                    validationFailed = true;
                                                }
                                            }
                                            else if (fOpcItem.itemName.Contains("DBS"))
                                            {
                                                // --

                                                int length = fOpcItem.itemName.Split(new char[] { '.' }).Length;
                                                if (length != 3)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcItem.fItemFormat != FTagFormat.String)
                                                {
                                                    validationFailed = true;
                                                }
                                                else if (fOpcItem.itemArray)
                                                {
                                                    validationFailed = true;
                                                }
                                            }

                                            // --

                                            if (validationFailed)
                                            {
                                                tChildNode = new UltraTreeNode(fOpcItem.name);
                                                tChildNode.Tag = fOpcItem;

                                                // --

                                                icon = FCommon.getImageOfObject(fOpcItem, tvwTree);
                                                if (icon != null)
                                                {
                                                    tChildNode.Override.ImageSize = new Size(16, 16);
                                                    tChildNode.Override.NodeAppearance.Image = icon;
                                                }

                                                // --

                                                tChildNode.Text = fOpcItem.ToString(FStringOption.Detail);
                                                tNode.Nodes.Add(tChildNode);
                                                tNode.Expanded = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tChildNode = null;
                icon = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void addValidationFailedDataNode(
            UltraTreeNode tNode
            )
        {
            try
            {
                foreach (FDataSetList fDataSetList in m_fOpmCore.fOpmFileInfo.fOpcDriver.fChildDataSetListCollection)
                {
                    foreach (FDataSet fDataSet in fDataSetList.fChildDataSetCollection)
                    {
                        foreach (FData fData in fDataSet.fChildDataCollection)
                        {
                            addSubValidationFailedDataNode(tNode, fData);
                        }
                    }
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

        public void addSubValidationFailedDataNode(
            UltraTreeNode tNode,
            FData fParentData
            )
        {
            UltraTreeNode tChildNode = null;
            Image icon = null;
            FIObject fIObject = null;

            try
            {
                // --
                bool validationFailed = false;
                if (fParentData.fSourceType != FDataSourceType.Item)
                {
                    return;
                }

                // --

                fIObject = m_fOpmCore.fOpmFileInfo.fOpcDriver.searchOpcLibrarySeries(
                    m_fOpmCore.fOpmFileInfo.fOpcDriver,
                    fParentData.sourceItem
                    );
                if (fIObject == null)
                {
                    validationFailed = true;
                }

                // --

                if (validationFailed)
                {
                    tChildNode = new UltraTreeNode(fParentData.name);
                    tChildNode.Tag = fParentData;

                    // --

                    icon = FCommon.getImageOfObject(fParentData, tvwTree);
                    if (icon != null)
                    {
                        tChildNode.Override.ImageSize = new Size(16, 16);
                        tChildNode.Override.NodeAppearance.Image = icon;
                    }

                    // --

                    tChildNode.Text = fParentData.ToString(FStringOption.Detail);
                    tNode.Nodes.Add(tChildNode);
                    tNode.Expanded = true;
                }

                // --

                foreach (FData fData in fParentData.fChildDataCollection)
                {
                    // --

                    addSubValidationFailedDataNode(tNode, fData);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tChildNode = null;
                icon = null;
                fIObject = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuGoto(
            )
        {
            UltraTreeNode fSelectedNode = null;
            FIObject fObject = null;            

            try
            {
                if (tvwTree.Nodes.Count > 0)
                {
                    fSelectedNode = tvwTree.ActiveNode;
                    fObject = (FIObject)fSelectedNode.Tag;
                    if (fObject != null)
                    {
                        m_fOpmCore.fOpmContainer.gotoRelation(fObject);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSelectedNode = null;
                fObject = null;   
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuRefresh(
            )
        {
            try
            {
                FCursor.waitCursor();
                // --

                refresh();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FRelationViewer Form Event Handler

        private void FRelationViewer_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                // --
                designTreeOfValidationViewer();
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

        private void FRelationViewer_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
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

        private void tvwTree_DoubleClick(
            object sender, 
            EventArgs e
            )
        {
            try
            {                
                procMenuGoto();
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

        #region  mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender, 
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuRelGoto)
                {
                    procMenuGoto();
                }
                else if (e.Tool.Key == FMenuKey.MenuRefresh)
                {
                    procMenuRefresh();
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

    }   // Class end
}   // Namespace end
