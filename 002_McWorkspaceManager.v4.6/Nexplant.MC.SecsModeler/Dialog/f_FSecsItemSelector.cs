/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsItemSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.08
--  Description     : FAMate SECS Modeler SECS Item Selector Form Class 
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win;

namespace Nexplant.MC.SecsModeler
{
    public partial class FSecsItemSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FComparisonMode m_fComparisonMode = FComparisonMode.Value;
        private FSecsMessage m_fSmg = null;        
        private FSecsItem m_fOldSit = null;
        private FSecsItem m_fSelectedSit = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsItemSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsItemSelector(
            FSsmCore fSsmCore,
            FSecsMessage fSmg,
            FSecsItem fOldSit
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fSmg = fSmg;
            m_fOldSit = fOldSit;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsItemSelector(
            FSsmCore fSsmCore,
            FComparisonMode fComparisonMode,
            FSecsMessage fSmg,
            FSecsItem fOldSit
            )
            : this(fSsmCore, fSmg, fOldSit)
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
                    m_fSsmCore = null;
                    m_fSmg = null;
                    m_fOldSit = null;
                    m_fSelectedSit = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FSecsItem fSelectedItem
        {
            get
            {
                try
                {
                    return m_fSelectedSit;
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
                tvwTree.ImageList.Images.Add("SecsMessage_Primary_unlock", Properties.Resources.SecsMessage_Primary_unlock);
                tvwTree.ImageList.Images.Add("SecsMessage_Primary_lock", Properties.Resources.SecsMessage_Primary_lock);
                tvwTree.ImageList.Images.Add("SecsMessage_Secondary_unlock", Properties.Resources.SecsMessage_Secondary_unlock);
                tvwTree.ImageList.Images.Add("SecsMessage_Secondary_lock", Properties.Resources.SecsMessage_Secondary_lock);
                tvwTree.ImageList.Images.Add("SecsItem_List_unlock", Properties.Resources.SecsItem_List_unlock);
                tvwTree.ImageList.Images.Add("SecsItem_List_lock", Properties.Resources.SecsItem_List_lock);
                tvwTree.ImageList.Images.Add("SecsItem_unlock", Properties.Resources.SecsItem_unlock);
                tvwTree.ImageList.Images.Add("SecsItem_lock", Properties.Resources.SecsItem_lock);
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
            UltraTreeNode tNodeSmg = null;            

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeSmg = new UltraTreeNode(m_fSmg.uniqueIdToString);
                tNodeSmg.Tag = m_fSmg;
                FCommon.refreshTreeNodeOfObject(m_fSmg, tvwTree, tNodeSmg);

                // --

                foreach (FSecsItem fSit in m_fSmg.fChildSecsItemCollection)
                {
                    loadTreeOfObject(tNodeSmg, fSit);
                }

                // --

                tNodeSmg.Expanded = true;
                tvwTree.Nodes.Add(tNodeSmg);

                // --

                if (m_fOldSit == null)
                {
                    tvwTree.ActiveNode = tNodeSmg;
                }
                else
                {
                    tvwTree.ActiveNode = tvwTree.GetNodeByKey(m_fOldSit.uniqueIdToString);
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
                tNodeSmg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObject(
            UltraTreeNode tParentNode,
            FSecsItem fSit
            )
        {
            UltraTreeNode tNodeSit = null;

            try
            {
                tNodeSit = new UltraTreeNode(fSit.uniqueIdToString);
                tNodeSit.Tag = fSit;
                FCommon.refreshTreeNodeOfObject(fSit, tvwTree, tNodeSit);

                // --

                foreach (FSecsItem fChild in fSit.fChildSecsItemCollection)
                {
                    loadTreeOfObject(tNodeSit, fChild);
                }

                // --

                tNodeSit.Expanded = true;
                tParentNode.Nodes.Add(tNodeSit);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeSit = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectItem(
            )
        {
            try
            {
                m_fSelectedSit = (FSecsItem)tvwTree.ActiveNode.Tag;
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

        #region FSecsItemSelector Form Event Handler

        private void FSecsItemSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldSit != null)
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.SecsMessage)
                {
                    btnOk.Enabled = false;
                }
                else
                {
                    fFormat = ((FSecsItem)e.TreeNode.Tag).fFormat;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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

                m_fSelectedSit = null;
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

    }   // Class end
}   // Namespace end
