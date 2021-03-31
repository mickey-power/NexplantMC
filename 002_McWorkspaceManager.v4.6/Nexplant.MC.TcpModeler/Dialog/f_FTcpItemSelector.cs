/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpItemSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.08
--  Description     : FAMate TCP Modeler TCP Item Selector Form Class 
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinTree;
using Infragistics.Win;

namespace Nexplant.MC.TcpModeler
{
    public partial class FTcpItemSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FComparisonMode m_fComparisonMode = FComparisonMode.Value;
        private FTcpMessage m_fTmg = null;
        private FTcpItem m_fOldTit = null;
        private FTcpItem m_fSelectedTit = null;
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpItemSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItemSelector(
            FTcmCore fTcmCore,
            FTcpMessage fTmg,
            FTcpItem fOldTit
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fTmg = fTmg;
            m_fOldTit = fOldTit;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpItemSelector(
            FTcmCore fTcmCore,
            FComparisonMode fComparisonMode,
            FTcpMessage fTmg,
            FTcpItem fOldTit
            )
            : this(fTcmCore, fTmg, fOldTit)
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
                    m_fTcmCore = null;
                    m_fTmg = null;
                    m_fOldTit = null;
                    m_fSelectedTit = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FTcpItem fSelectedItem
        {
            get
            {
                try
                {
                    return m_fSelectedTit;
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
                tvwTree.ImageList.Images.Add("TcpMessage_Command_unlock", Properties.Resources.TcpMessage_Command_unlock);
                tvwTree.ImageList.Images.Add("TcpMessage_Command_lock", Properties.Resources.TcpMessage_Command_lock);
                tvwTree.ImageList.Images.Add("TcpMessage_Reply_unlock", Properties.Resources.TcpMessage_Reply_unlock);
                tvwTree.ImageList.Images.Add("TcpMessage_Reply_lock", Properties.Resources.TcpMessage_Reply_lock);
                tvwTree.ImageList.Images.Add("TcpMessage_Unsolicited_unlock", Properties.Resources.TcpMessage_Unsolicited_unlock);
                tvwTree.ImageList.Images.Add("TcpMessage_Unsolicited_lock", Properties.Resources.TcpMessage_Unsolicited_lock);
                tvwTree.ImageList.Images.Add("TcpItem_List_unlock", Properties.Resources.TcpItem_List_unlock);
                tvwTree.ImageList.Images.Add("TcpItem_List_lock", Properties.Resources.TcpItem_List_lock);
                tvwTree.ImageList.Images.Add("TcpItem_unlock", Properties.Resources.TcpItem_unlock);
                tvwTree.ImageList.Images.Add("TcpItem_lock", Properties.Resources.TcpItem_lock);
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
            UltraTreeNode tNodeTmg = null;

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeTmg = new UltraTreeNode(m_fTmg.uniqueIdToString);
                tNodeTmg.Tag = m_fTmg;
                FCommon.refreshTreeNodeOfObject(m_fTmg, tvwTree, tNodeTmg);

                // --

                foreach (FTcpItem fTit in m_fTmg.fChildTcpItemCollection)
                {
                    loadTreeOfObject(tNodeTmg, fTit);
                }
                
                // --

                tNodeTmg.Expanded = true;
                tvwTree.Nodes.Add(tNodeTmg);

                // --

                if (m_fOldTit == null)
                {
                    tvwTree.ActiveNode = tNodeTmg;
                }
                else
                {
                    tvwTree.ActiveNode = tvwTree.GetNodeByKey(m_fOldTit.uniqueIdToString);
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
                tNodeTmg = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObject(
            UltraTreeNode tParentNode,
            FTcpItem fTit
            )
        {
            UltraTreeNode tNodeTit = null;

            try
            {

                tNodeTit = new UltraTreeNode(fTit.uniqueIdToString);
                tNodeTit.Tag = fTit;
                FCommon.refreshTreeNodeOfObject(fTit, tvwTree, tNodeTit);

                //  --

                foreach (FTcpItem fChild in fTit.fChildTcpItemCollection)
                {
                    loadTreeOfObject(tNodeTit, fChild);
                }

                // --

                tNodeTit.Expanded = true;
                tParentNode.Nodes.Add(tNodeTit);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeTit = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectItem(
            )
        {
            try
            {
                m_fSelectedTit = (FTcpItem)tvwTree.ActiveNode.Tag;
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

        #region FTcpItemSelector Form Event Handler

        private void FTcpItemSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldTit != null)
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
            FFormat fFormat = FFormat.Unknown;

            try
            {
                if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.TcpMessage)
                {
                    btnOk.Enabled = false;
                }
                else if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.TcpItem)
                {
                    fFormat = ((FTcpItem)e.TreeNode.Tag).fFormat;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                m_fSelectedTit = null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
