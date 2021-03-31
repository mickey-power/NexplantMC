/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FDataSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.31
--  Description     : FAMate SECS Modeler Data Selector Form Class 
--  History         : Created by spike.lee at 2012.01.31
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
    public partial class FDataSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FComparisonMode m_fComparisonMode = FComparisonMode.Value;
        private FDataSet m_fDts = null;        
        private FData m_fOldDat = null;
        private FData m_fSelectedDat = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDataSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSelector(
            FSsmCore fSsmCore,
            FDataSet fDts,
            FData fOldDat
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fDts = fDts;
            m_fOldDat = fOldDat;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSelector(
            FSsmCore fSsmCore,
            FComparisonMode fComparisonMode,
            FDataSet fDts,
            FData fOldDat
            )
            : this(fSsmCore, fDts, fOldDat)
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
                    m_fDts = null;
                    m_fOldDat = null;
                    m_fSelectedDat = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FData fSelectedData
        {
            get
            {
                try
                {
                    return m_fSelectedDat;
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

        private void loadTreeOfObject(
            )
        {
            UltraTreeNode tNodeDts = null;            

            try
            {
                tvwTree.beginUpdate();

                // --

                tNodeDts = new UltraTreeNode(m_fDts.uniqueIdToString);
                tNodeDts.Tag = m_fDts;
                FCommon.refreshTreeNodeOfObject(m_fDts, tvwTree, tNodeDts);

                // --

                foreach (FData fDat in m_fDts.fChildDataCollection)
                {
                    loadTreeOfObject(tNodeDts, fDat);
                }

                // --

                tNodeDts.Expanded = true;
                tvwTree.Nodes.Add(tNodeDts);

                // --

                if (m_fOldDat == null)
                {
                    tvwTree.ActiveNode = tNodeDts;
                }
                else
                {
                    tvwTree.ActiveNode = tvwTree.GetNodeByKey(m_fOldDat.uniqueIdToString);
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
                tNodeDts = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObject(
            UltraTreeNode tParentNode,
            FData fDat
            )
        {
            UltraTreeNode tNodeDat = null;

            try
            {
                tNodeDat = new UltraTreeNode(fDat.uniqueIdToString);
                tNodeDat.Tag = fDat;
                FCommon.refreshTreeNodeOfObject(fDat, tvwTree, tNodeDat);

                // --

                foreach (FData fChild in fDat.fChildDataCollection)
                {
                    loadTreeOfObject(tNodeDat, fChild);
                }

                // --

                tNodeDat.Expanded = true;
                tParentNode.Nodes.Add(tNodeDat);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeDat = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectData(
            )
        {
            try
            {
                m_fSelectedDat = (FData)tvwTree.ActiveNode.Tag;
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

        #region FDataSelector Form Event Handler

        private void FDataSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldDat != null)
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
                if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.DataSet)
                {
                    btnOk.Enabled = false;
                }
                else
                {
                    fFormat = ((FData)e.TreeNode.Tag).fFormat;
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
                    selectData();
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

                selectData();
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

                m_fSelectedDat = null;
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
