/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcItemSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.08
--  Description     : FAMate OPC Modeler OPC Item Selector Form Class 
--  History         : Created by spike.lee at 2011.08.08
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
    public partial class FOpcItemSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FComparisonMode m_fComparisonMode = FComparisonMode.Value;
        private FOpcMessage m_fOmg = null;
        private FIOpcOperand m_fOldOit = null;
        private FIOpcOperand m_fSelectedOit = null;
        private FOpcOperandType m_fOperandType;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcItemSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcItemSelector(
            FOpmCore fOpmCore,
            FOpcMessage fOmg,
            FIOpcOperand fOldOit,
            FOpcOperandType fOperandType
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fOmg = fOmg;
            m_fOldOit = fOldOit;
            m_fOperandType = fOperandType;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcItemSelector(
            FOpmCore fOpmCore,
            FComparisonMode fComparisonMode,
            FOpcMessage fOmg,
            FIOpcOperand fOldOit,
            FOpcOperandType fOperandType
            )
            : this(fOpmCore, fOmg, fOldOit, fOperandType)
        {
            m_fComparisonMode = fComparisonMode;
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
                    m_fOmg = null;
                    m_fOldOit = null;
                    m_fSelectedOit = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FIOpcOperand fSelectedItem
        {
            get
            {
                try
                {
                    return m_fSelectedOit;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return null;
            }
        }

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
                tvwTree.ImageList.Images.Add("OpcItemList_unlock", Properties.Resources.OpcItemList_unlock);
                tvwTree.ImageList.Images.Add("OpcItemList_lock", Properties.Resources.OpcItemList_lock);
                tvwTree.ImageList.Images.Add("OpcItem_unlock", Properties.Resources.OpcItem_unlock);
                tvwTree.ImageList.Images.Add("OpcItem_lock", Properties.Resources.OpcItem_lock);
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
        
        private void loadTreeOfObject(
            )
        {
            UltraTreeNode tNodeOmg = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeOmg = new UltraTreeNode(m_fOmg.uniqueIdToString);
                tNodeOmg.Tag = m_fOmg;
                FCommon.refreshTreeNodeOfObject(m_fOmg, tvwTree, tNodeOmg);

                // --

                foreach (FOpcItemList fOil in m_fOmg.fChildOpcItemListCollection)
                {
                    loadTreeOfObject(tNodeOmg, fOil);
                }
                
                // --

                tNodeOmg.Expanded = true;
                tvwTree.Nodes.Add(tNodeOmg);

                // --

                if (m_fOldOit == null)
                {
                    tvwTree.ActiveNode = tNodeOmg;
                }
                else
                {
                    tvwTree.ActiveNode = tvwTree.GetNodeByKey(((FOpcItem)m_fOldOit).uniqueIdToString);
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
                tNodeOmg = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObject(
            UltraTreeNode tParentNode,
            FOpcItemList fOil
            )
        {
            UltraTreeNode tNodeOil = null;

            try
            {

                tNodeOil = new UltraTreeNode(fOil.uniqueIdToString);
                tNodeOil.Tag = fOil;
                FCommon.refreshTreeNodeOfObject(fOil, tvwTree, tNodeOil);

                //  --

                foreach (FOpcItem fChild in fOil.fChildOpcItemCollection)
                {
                    loadTreeOfObject(tNodeOil, fChild);
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

        private void loadTreeOfObject(
            UltraTreeNode tParentNode,
            FOpcItem fOit
            )
        {
            UltraTreeNode tNodeOit = null;

            try
            {

                tNodeOit = new UltraTreeNode(fOit.uniqueIdToString);
                tNodeOit.Tag = fOit;
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

        private void selectItem(
            )
        {
            try
            {
                m_fSelectedOit = (FOpcItem)tvwTree.ActiveNode.Tag;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FOpcItemSelector Form Event Handler

        private void FOpcItemSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldOit != null)
                {
                    btnReset.Enabled = true;
                }

                // --

                designTreeOfObject();

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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tvwTree Control Event Handler

        private void tvwTree_AfterActivate(
            object sender, 
            NodeEventArgs e
            )
        {
            try
            {
                if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.OpcMessage)
                {
                    btnOk.Enabled = false;
                }
                else if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.OpcItemList)
                {
                    btnOk.Enabled = false;
                }
                else if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.OpcItem)
                {
                    btnOk.Enabled = true;
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

        private void tvwTree_MouseDoubleClick(
            object sender, 
            MouseEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (btnOk.Enabled)
                {
                    selectItem();
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

        //------------------------------------------------------------------------------------------------------------------------

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

                selectItem();
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

        #region btnReset Control Event Handler

        private void btnReset_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSelectedOit = null;
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
