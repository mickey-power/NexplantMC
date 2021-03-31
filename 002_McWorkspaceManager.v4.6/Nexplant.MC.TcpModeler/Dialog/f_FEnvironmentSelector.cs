/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEnvironmentSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.08
--  Description     : FAMate TCP Modeler Environment Selector Form Class 
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
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.TcpModeler
{
    public partial class FEnvironmentSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FComparisonMode m_fComparisonMode = FComparisonMode.Value;
        private FEnvironmentList m_fOldEnl = null;
        private FEnvironment m_fOldEnv = null;
        private FEnvironment m_fSelectedEnv = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEnvironmentSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironmentSelector(
            FTcmCore fTcmCore,            
            FEnvironment fOldEnv
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fOldEnv = fOldEnv;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEnvironmentSelector(
            FTcmCore fTcmCore,
            FComparisonMode fComparisonMode,
            FEnvironment fOldEnv
            )
            : this(fTcmCore, fOldEnv)
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
                    m_fOldEnl = null;
                    m_fOldEnv = null;
                    m_fSelectedEnv = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FEnvironment fSelectedEnvironment
        {
            get
            {
                try
                {
                    return m_fSelectedEnv;
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

        private void designGridOfEnvironmentList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEnvironmentList.dataSource;
                // --
                uds.Band.Columns.Add("Environment List");
                uds.Band.Columns.Add("Description");

                // --

                grdEnvironmentList.DisplayLayout.Bands[0].Columns["Environment List"].CellAppearance.Image = Properties.Resources.EnvironmentList_unlock;
                // --
                grdEnvironmentList.DisplayLayout.Bands[0].Columns["Environment List"].Width = 150;
                grdEnvironmentList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                uds = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designTreeOfEnvironment(
            )
        {
            try
            {
                tvwEnvironment.ImageList = new ImageList();
                // --
                tvwEnvironment.ImageList.Images.Add("EnvironmentList_unlock", Properties.Resources.EnvironmentList_unlock);
                tvwEnvironment.ImageList.Images.Add("EnvironmentList_lock", Properties.Resources.EnvironmentList_lock);
                tvwEnvironment.ImageList.Images.Add("Environment_List_unlock", Properties.Resources.Environment_List_unlock);
                tvwEnvironment.ImageList.Images.Add("Environment_List_lock", Properties.Resources.Environment_List_lock);
                tvwEnvironment.ImageList.Images.Add("Environment_unlock", Properties.Resources.Environment_unlock);
                tvwEnvironment.ImageList.Images.Add("Environment_lock", Properties.Resources.Environment_lock);
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

        private void refreshGridOfEnvironmentList(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdEnvironmentList.beginUpdate(false);

                // --

                foreach (FEnvironmentList fEnl in m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildEnvironmentListCollection)
                {
                    cellValues = new object[]{                        
                        fEnl.name,
                        fEnl.description
                    };
                    dataRow = grdEnvironmentList.appendDataRow(fEnl.uniqueIdToString, cellValues);
                    dataRow.Tag = fEnl;
                    FCommon.refreshGridRowOfObject(fEnl, grdEnvironmentList.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fEnl == m_fOldEnl)
                    {
                        activeDataRowKey = fEnl.uniqueIdToString;
                    }
                }

                // --

                grdEnvironmentList.endUpdate(false);

                // --

                if (grdEnvironmentList.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdEnvironmentList.ActiveRow = grdEnvironmentList.Rows[0];
                    }
                    else
                    {
                        grdEnvironmentList.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdEnvironmentList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObject(
            )
        {
            FEnvironmentList fEnl = null;
            UltraTreeNode tNodeEnl = null;

            try
            {
                tvwEnvironment.beginUpdate();

                // --

                fEnl = (FEnvironmentList)grdEnvironmentList.activeDataRow.Tag;
                tNodeEnl = new UltraTreeNode(fEnl.uniqueIdToString);
                tNodeEnl.Tag = fEnl;
                FCommon.refreshTreeNodeOfObject(fEnl, tvwEnvironment, tNodeEnl);

                // --

                foreach (FEnvironment fEnv in fEnl.fChildEnvironmentCollection)
                {
                    loadTreeOfObject(tNodeEnl, fEnv);
                }

                // --

                tNodeEnl.Expanded = true;
                tvwEnvironment.Nodes.Add(tNodeEnl);

                // --

                if (m_fOldEnv != null && tvwEnvironment.GetNodeByKey(m_fOldEnv.uniqueIdToString) != null)
                {
                    tvwEnvironment.ActiveNode = tvwEnvironment.GetNodeByKey(m_fOldEnv.uniqueIdToString);
                }
                else
                {
                    tvwEnvironment.ActiveNode = tNodeEnl;
                }

                // --

                tvwEnvironment.endUpdate();
            }
            catch (Exception ex)
            {
                tvwEnvironment.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fEnl = null;
                tNodeEnl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadTreeOfObject(
            UltraTreeNode tParentNode,
            FEnvironment fEnv
            )
        {
            UltraTreeNode tNodeEnv = null;

            try
            {
                tNodeEnv = new UltraTreeNode(fEnv.uniqueIdToString);
                tNodeEnv.Tag = fEnv;
                FCommon.refreshTreeNodeOfObject(fEnv, tvwEnvironment, tNodeEnv);

                // --

                foreach (FEnvironment fChild in fEnv.fChildEnvironmentCollection)
                {
                    loadTreeOfObject(tNodeEnv, fChild);
                }

                // --

                tNodeEnv.Expanded = true;
                tParentNode.Nodes.Add(tNodeEnv);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                tNodeEnv = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procPreviousStep(
            )
        {
            try
            {
                if (m_step == 0)
                {
                    // ***
                    // Environment List Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // Environment Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdEnvironmentList.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdEnvironmentList.Visible = true;                    
                    tvwEnvironment.Visible = false;
                    tvwEnvironment.Nodes.Clear();
                    grdEnvironmentList.Focus();
                    // --
                    m_step = 0;
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

        private void procNextStep(
            )
        {
            try
            {
                if (m_step == 0)
                {
                    // ***
                    // Environment List Selection
                    // ***
                    loadTreeOfObject();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;                    
                    // --
                    grdEnvironmentList.Visible = false;
                    tvwEnvironment.Visible = true;
                    tvwEnvironment.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    // ***
                    // Environment Selection
                    // ***                    
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

        private void selectEnvironment(
            )
        {
            try
            {
                m_fSelectedEnv = (FEnvironment)tvwEnvironment.ActiveNode.Tag;
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

        #region FEnvironmentSelector Form Event Handler

        private void FEnvironmentSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfEnvironmentList();
                designTreeOfEnvironment();

                // --

                grdEnvironmentList.Visible = true;
                tvwEnvironment.Visible = false;
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

        private void FEnvironmentSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldEnv != null)
                {
                    m_fOldEnl = m_fOldEnv.fAncestorEnvironmentList;
                    btnReset.Enabled = true;
                }

                // --

                refreshGridOfEnvironmentList();

                // --

                m_step = 0;
                if (grdEnvironmentList.activeDataRow != null)
                {
                    btnNext.Enabled = true;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdEnvironmentList Control Event Handler

        private void grdEnvironmentList_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procNextStep();
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

        #region tvwEnvironment Control Event Handler

        private void tvwEnvironment_AfterActivate(
            object sender,
            NodeEventArgs e
            )
        {
            FFormat fFormat;

            try
            {
                if (((FIObject)e.TreeNode.Tag).fObjectType == FObjectType.EnvironmentList)
                {
                    btnOk.Enabled = false;
                }
                else
                {
                    fFormat = ((FEnvironment)e.TreeNode.Tag).fFormat;
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

        private void tvwEnvironment_MouseDoubleClick(
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
                    selectEnvironment();
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

        private void tvwEnvironment_BeforeCollapse(
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

                selectEnvironment();
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

                m_fSelectedEnv = null;
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

        #region btnPrevious Control Event Handler

        private void btnPrevious_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procPreviousStep();
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

        #region btnNext Control Event Handler

        private void btnNext_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procNextStep();
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
