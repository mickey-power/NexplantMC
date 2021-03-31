/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FHostItemSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.11
--  Description     : FAMate OPC Modeler Host Item Selector Form Class 
--  History         : Created by spike.lee at 2011.08.11
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
    public partial class FHostItemSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FComparisonMode m_fComparisonMode = FComparisonMode.Value;
        private FHostMessage m_fHmg = null;        
        private FHostItem m_fOldHit = null;
        private FHostItem m_fSelectedHit = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostItemSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostItemSelector(
            FOpmCore fOpmCore,
            FHostMessage fHmg,
            FHostItem fOldHit
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fHmg = fHmg;
            m_fOldHit = fOldHit;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostItemSelector(
            FOpmCore fOpmCore,
            FComparisonMode fComparisonMode,
            FHostMessage fHmg,
            FHostItem fOldHit
            )
            : this(fOpmCore, fHmg, fOldHit)
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
                    m_fHmg = null;
                    m_fOldHit = null;
                    m_fSelectedHit = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FHostItem fSelectedItem
        {
            get
            {
                try
                {
                    return m_fSelectedHit;
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
                tvwTree.ImageList.Images.Add("HostMessage_Command_unlock", Properties.Resources.HostMessage_Command_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Command_lock", Properties.Resources.HostMessage_Command_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Reply_unlock", Properties.Resources.HostMessage_Reply_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Reply_lock", Properties.Resources.HostMessage_Reply_lock);
                tvwTree.ImageList.Images.Add("HostMessage_Unsolicited_unlock", Properties.Resources.HostMessage_Unsolicited_unlock);
                tvwTree.ImageList.Images.Add("HostMessage_Unsolicited_lock", Properties.Resources.HostMessage_Unsolicited_lock);
                tvwTree.ImageList.Images.Add("HostItem_List_unlock", Properties.Resources.HostItem_List_unlock);
                tvwTree.ImageList.Images.Add("HostItem_List_lock", Properties.Resources.HostItem_List_lock);
                tvwTree.ImageList.Images.Add("HostItem_unlock", Properties.Resources.HostItem_unlock);
                tvwTree.ImageList.Images.Add("HostItem_lock", Properties.Resources.HostItem_lock);
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
            UltraTreeNode tNodeHmg = null;            

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeHmg = new UltraTreeNode(m_fHmg.uniqueIdToString);
                tNodeHmg.Tag = m_fHmg;
                FCommon.refreshTreeNodeOfObject(m_fHmg, tvwTree, tNodeHmg);

                // --

                foreach (FHostItem fHit in m_fHmg.fChildHostItemCollection)
                {
                    loadTreeOfObject(tNodeHmg, fHit);
                }

                // --

                tNodeHmg.Expanded = true;
                tvwTree.Nodes.Add(tNodeHmg);

                // --

                if (m_fOldHit == null)
                {
                    tvwTree.ActiveNode = tNodeHmg;
                }
                else
                {
                    tvwTree.ActiveNode = tvwTree.GetNodeByKey(m_fOldHit.uniqueIdToString);
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
                tNodeHmg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObject(
            UltraTreeNode tParentNode,
            FHostItem fHit
            )
        {
            UltraTreeNode tNodeHit = null;

            try
            {
                tNodeHit = new UltraTreeNode(fHit.uniqueIdToString);
                tNodeHit.Tag = fHit;
                FCommon.refreshTreeNodeOfObject(fHit, tvwTree, tNodeHit);

                // --

                foreach (FHostItem fChild in fHit.fChildHostItemCollection)
                {
                    loadTreeOfObject(tNodeHit, fChild);
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

        private void selectItem(
            )
        {
            try
            {
                m_fSelectedHit = (FHostItem)tvwTree.ActiveNode.Tag;
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

        #region FHostItemSelector Form Event Handler

        private void FHostItemSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldHit != null)
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
            FFormat fFormat;

            try
            {
                if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.HostMessage)
                {
                    btnOk.Enabled = false;
                }
                else
                {
                    fFormat = ((FHostItem)e.TreeNode.Tag).fFormat;
                    // --
                    if (m_fComparisonMode == FComparisonMode.Value)
                    {
                        if (fFormat == FFormat.List || fFormat == FFormat.AsciiList || fFormat == FFormat.Raw || fFormat == FFormat.Unknown)
                        {
                            btnOk.Enabled = false;
                        }
                        else
                        {
                            btnOk.Enabled = true;
                        }
                    }
                    else
                    {
                        btnOk.Enabled = true;
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

                m_fSelectedHit = null;
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
