/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentStateSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.14
--  Description     : FAMate SECS Modeler Equipment State Selector Form Class 
--  History         : Created by spike.lee at 2012.03.14
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
    public partial class FEquipmentStateSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FEquipmentStateSet m_fEss = null;
        private FEquipmentState m_fOldEst = null;
        private FEquipmentState m_fSelectedEst = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentStateSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateSelector(
            FSsmCore fSsmCore,
            FEquipmentStateSet fEss,
            FEquipmentState fOldEst
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fEss = fEss;
            m_fOldEst = fOldEst;
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
                    m_fEss = null;
                    m_fOldEst = null;
                    m_fSelectedEst = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FEquipmentState fSelectedEquipmentState
        {
            get
            {
                try
                {
                    return m_fSelectedEst;
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
                tvwTree.ImageList.Images.Add("EquipmentStateSet_unlock", Properties.Resources.EquipmentStateSet_unlock);
                tvwTree.ImageList.Images.Add("EquipmentStateSet_lock", Properties.Resources.EquipmentStateSet_lock);
                tvwTree.ImageList.Images.Add("EquipmentState_unlock", Properties.Resources.EquipmentState_unlock);
                tvwTree.ImageList.Images.Add("EquipmentState_lock", Properties.Resources.EquipmentState_lock);
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
            UltraTreeNode tNodeEss = null;
            UltraTreeNode tNodeEst = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeEss = new UltraTreeNode(m_fEss.uniqueIdToString);
                tNodeEss.Tag = m_fEss;
                FCommon.refreshTreeNodeOfObject(m_fEss, tvwTree, tNodeEss);

                // --

                foreach (FEquipmentState fEst in m_fEss.fChildEquipmentStateCollection)
                {
                    tNodeEst = new UltraTreeNode(fEst.uniqueIdToString);
                    tNodeEst.Tag = fEst;
                    FCommon.refreshTreeNodeOfObject(fEst, tvwTree, tNodeEst);
                    // --
                    tNodeEss.Nodes.Add(tNodeEst);
                }

                // --

                tNodeEss.Expanded = true;
                tvwTree.Nodes.Add(tNodeEss);

                // --

                if (m_fOldEst == null)
                {
                    tvwTree.ActiveNode = tNodeEss;
                }
                else
                {
                    tvwTree.ActiveNode = tvwTree.GetNodeByKey(m_fOldEst.uniqueIdToString);
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
                tNodeEss = null;
                tNodeEst = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectEquipmentState(
            )
        {
            try
            {
                m_fSelectedEst = (FEquipmentState)tvwTree.ActiveNode.Tag;
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

        #region FEquipmentStateSelector Form Event Handler

        private void FEquipmentStateSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldEst != null)
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
            try
            {
                if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.EquipmentStateSet)
                {
                    btnOk.Enabled = false;
                }
                else
                {
                    btnOk.Enabled = true;
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
                    selectEquipmentState();
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

                selectEquipmentState();
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

                m_fSelectedEst = null;
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
