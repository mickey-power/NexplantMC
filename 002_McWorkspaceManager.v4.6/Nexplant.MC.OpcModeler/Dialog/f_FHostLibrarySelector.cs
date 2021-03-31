/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FHostLibrarySelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.21
--  Description     : FAMate OPC Modeler Host Library Selector Form Class 
--  History         : Created by spike.lee at 2011.03.21
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
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.OpcModeler
{
    public partial class FHostLibrarySelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FHostLibraryGroup m_fOldHlg = null;
        private FHostLibrary m_fOldHlb = null;
        private FHostLibrary m_fSelectedHlb = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostLibrarySelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostLibrarySelector(
            FOpmCore fOpmCore,
            FHostLibrary fOldHlb
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fOldHlb = fOldHlb;
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
                    m_fOldHlg = null;
                    m_fOldHlb = null;
                    m_fSelectedHlb = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FHostLibrary fSelectedHostLibrary
        {
            get
            {
                try
                {
                    return m_fSelectedHlb;
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

        private void designGridOfHostLibraryGroup(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdHostLibraryGroup.dataSource;
                // --                
                uds.Band.Columns.Add("Host Library Group");
                uds.Band.Columns.Add("Description");

                // --

                grdHostLibraryGroup.DisplayLayout.Bands[0].Columns["Host Library Group"].CellAppearance.Image = Properties.Resources.HostLibraryGroup_unlock;
                // --
                grdHostLibraryGroup.DisplayLayout.Bands[0].Columns["Host Library Group"].Width = 150;
                grdHostLibraryGroup.DisplayLayout.Bands[0].Columns["Description"].Width = 200;                
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

        private void designGridOfHostLibrary(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdHostLibrary.dataSource;
                // --
                uds.Band.Columns.Add("Host Library");
                uds.Band.Columns.Add("Description");

                // --

                grdHostLibrary.DisplayLayout.Bands[0].Columns["Host Library"].CellAppearance.Image = Properties.Resources.HostLibrary_unlock;
                // --
                grdHostLibrary.DisplayLayout.Bands[0].Columns["Host Library"].Width = 150;
                grdHostLibrary.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfHostLibraryGroup(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdHostLibraryGroup.beginUpdate(false);

                // --

                foreach (FHostLibraryGroup fHlg in m_fOpmCore.fOpmFileInfo.fOpcDriver.fChildHostLibraryGroupCollection)
                {
                    cellValues = new object[]{                        
                        fHlg.name,
                        fHlg.description
                    };
                    dataRow = grdHostLibraryGroup.appendDataRow(fHlg.uniqueIdToString, cellValues);
                    dataRow.Tag = fHlg;
                    FCommon.refreshGridRowOfObject(fHlg, grdHostLibraryGroup.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fHlg == m_fOldHlg)
                    {
                        activeDataRowKey = fHlg.uniqueIdToString;
                    }
                }

                // --

                grdHostLibraryGroup.endUpdate(false);

                // --

                if (grdHostLibraryGroup.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdHostLibraryGroup.ActiveRow = grdHostLibraryGroup.Rows[0];
                    }
                    else
                    {
                        grdHostLibraryGroup.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdHostLibraryGroup.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfHostLibrary(
            )
        {
            FHostLibraryGroup fHlg = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fHlg = (FHostLibraryGroup)grdHostLibraryGroup.activeDataRow.Tag;

                // --
                
                grdHostLibrary.beginUpdate(false);

                // --
                
                grdHostLibrary.removeAllDataRow();

                // --

                foreach (FHostLibrary fHlb in fHlg.fChildHostLibraryCollection)
                {
                    cellValues = new object[] {
                        fHlb.name,
                        fHlb.description
                    };
                    dataRow = grdHostLibrary.appendDataRow(fHlb.uniqueIdToString, cellValues);
                    dataRow.Tag = fHlb;
                    FCommon.refreshGridRowOfObject(fHlb, grdHostLibrary.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fHlb == m_fOldHlb)
                    {
                        activeDataRowKey = fHlb.uniqueIdToString;
                    }
                }

                // --

                grdHostLibrary.endUpdate(false);

                // --

                if (grdHostLibrary.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdHostLibrary.ActiveRow = grdHostLibrary.Rows[0];
                    }
                    else
                    {
                        grdHostLibrary.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdHostLibrary.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fHlg = null;
                dataRow = null;
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
                    // Host Library Group Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // Host Library Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdHostLibraryGroup.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdHostLibraryGroup.Visible = true;
                    grdHostLibrary.Visible = false;
                    grdHostLibraryGroup.Focus();
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
                    // Host Library Group Selection
                    // ***
                    refreshGridOfHostLibrary();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdHostLibrary.activeDataRow == null ? false : true);
                    // --
                    grdHostLibraryGroup.Visible = false;
                    grdHostLibrary.Visible = true;
                    grdHostLibrary.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    // ***
                    // Host Library Selection
                    // ***
                    selectHostLibrary();
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

        private void selectHostLibrary(
            )
        {
            try
            {
                m_fSelectedHlb = (FHostLibrary)grdHostLibrary.activeDataRow.Tag;
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

        #region FHostLibrarySelector Form Event Handler

        private void FHostLibrarySelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfHostLibraryGroup();
                designGridOfHostLibrary();

                // --

                grdHostLibraryGroup.Visible = true;
                grdHostLibrary.Visible = false;
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

        private void FHostLibrarySelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldHlb != null)
                {
                    m_fOldHlg = m_fOldHlb.fParent;
                    btnReset.Enabled = true;
                }

                // --

                refreshGridOfHostLibraryGroup();

                // --

                m_step = 0;
                if (grdHostLibraryGroup.activeDataRow != null)
                {
                    btnNext.Enabled = true;
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

        #region Grid Control Common Event Handler

        private void grdCommon_DoubleClickRow(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
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

                selectHostLibrary();
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

                m_fSelectedHlb = null;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
