/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcEventItemSelector.cs
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
    public partial class FOpcEventItemSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FComparisonMode m_fComparisonMode = FComparisonMode.Value;
        private FOpcMessage m_fOmg = null;
        private FIOpcOperand m_fOldOei = null;
        private FIOpcOperand m_fSelectedOei = null;
        private FOpcOperandType m_fOperandType;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcEventItemSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcEventItemSelector(
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
            m_fOldOei = fOldOit;
            m_fOperandType = fOperandType;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcEventItemSelector(
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
                    m_fOldOei = null;
                    m_fSelectedOei = null;
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
                    return m_fSelectedOei;
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
                tvwTree.ImageList.Images.Add("OpcEventItemList_unlock", Properties.Resources.OpcEventItemList_unlock);
                tvwTree.ImageList.Images.Add("OpcEventItemList_lock", Properties.Resources.OpcEventItemList_lock);
                tvwTree.ImageList.Images.Add("OpcEventItem_unlock", Properties.Resources.OpcEventItem_unlock);
                tvwTree.ImageList.Images.Add("OpcEventItem_lock", Properties.Resources.OpcEventItem_lock);
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

                foreach (FOpcEventItemList fOel in m_fOmg.fChildOpcEventItemListCollection)
                {
                    loadTreeOfObject(tNodeOmg, fOel);
                }
                
                // --

                tNodeOmg.Expanded = true;
                tvwTree.Nodes.Add(tNodeOmg);

                // --

                if (m_fOldOei == null)
                {
                    tvwTree.ActiveNode = tNodeOmg;
                }
                else
                {
                    tvwTree.ActiveNode = tvwTree.GetNodeByKey(((FOpcEventItem)m_fOldOei).uniqueIdToString);
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
            FOpcEventItemList fOel
            )
        {
            UltraTreeNode tNodeOel = null;

            try
            {

                tNodeOel = new UltraTreeNode(fOel.uniqueIdToString);
                tNodeOel.Tag = fOel;
                FCommon.refreshTreeNodeOfObject(fOel, tvwTree, tNodeOel);

                //  --

                foreach (FOpcEventItem fChild in fOel.fChildOpcEventItemCollection)
                {
                    loadTreeOfObject(tNodeOel, fChild);
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

        private void loadTreeOfObject(
            UltraTreeNode tParentNode,
            FOpcEventItem fOei
            )
        {
            UltraTreeNode tNodeOei = null;

            try
            {

                tNodeOei = new UltraTreeNode(fOei.uniqueIdToString);
                tNodeOei.Tag = fOei;
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

        private void selectItem(
            )
        {
            try
            {
                m_fSelectedOei = (FOpcEventItem)tvwTree.ActiveNode.Tag;
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

        #region FOpcEventItemSelector Form Event Handler

        private void FOpcEventItemSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldOei != null)
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
                else if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.OpcEventItemList)
                {
                    btnOk.Enabled = false;
                }
                else if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.OpcEventItem)
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

                m_fSelectedOei = null;
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
