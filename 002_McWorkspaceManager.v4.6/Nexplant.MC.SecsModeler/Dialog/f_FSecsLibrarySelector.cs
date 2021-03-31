/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsLibrarySelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.15
--  Description     : FAMate SECS Modeler SECS Library Selector Form Class 
--  History         : Created by spike.lee at 2011.03.15
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
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.SecsModeler
{
    public partial class FSecsLibrarySelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FSecsLibraryGroup m_fOldSlg = null;
        private FSecsLibrary m_fOldSlb = null;        
        private FSecsLibrary m_fSelectedSlb = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsLibrarySelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsLibrarySelector(
            FSsmCore fSsmCore,
            FSecsLibrary fOldSlb
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fOldSlb = fOldSlb;            
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
                    m_fOldSlg = null;
                    m_fOldSlb = null;
                    m_fSelectedSlb = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FSecsLibrary fSelectedSecsLibrary
        {
            get
            {
                try
                {
                    return m_fSelectedSlb;
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

        private void designGridOfSecsLibraryGroup(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdSecsLibraryGroup.dataSource;
                // --                
                uds.Band.Columns.Add("SECS Library Group");
                uds.Band.Columns.Add("Description");

                // --
                
                grdSecsLibraryGroup.DisplayLayout.Bands[0].Columns["SECS Library Group"].CellAppearance.Image = Properties.Resources.SecsLibraryGroup_unlock;
                // --
                grdSecsLibraryGroup.DisplayLayout.Bands[0].Columns["SECS Library Group"].Width = 150;
                grdSecsLibraryGroup.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfSecsLibrary(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdSecsLibrary.dataSource;
                // --
                uds.Band.Columns.Add("SECS Library");
                uds.Band.Columns.Add("Description");

                // --

                grdSecsLibrary.DisplayLayout.Bands[0].Columns["SECS Library"].CellAppearance.Image = Properties.Resources.SecsLibrary_unlock;
                // --
                grdSecsLibrary.DisplayLayout.Bands[0].Columns["SECS Library"].Width = 150;
                grdSecsLibrary.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfSecsLibraryGroup(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdSecsLibraryGroup.beginUpdate(false);

                // --

                foreach (FSecsLibraryGroup fSlg in m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildSecsLibraryGroupCollection)
                {
                    cellValues = new object[]{                        
                        fSlg.name,
                        fSlg.description
                    };
                    dataRow = grdSecsLibraryGroup.appendDataRow(fSlg.uniqueIdToString, cellValues);
                    dataRow.Tag = fSlg;
                    FCommon.refreshGridRowOfObject(fSlg, grdSecsLibraryGroup.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fSlg == m_fOldSlg)
                    {
                        activeDataRowKey = fSlg.uniqueIdToString;
                    }
                }

                // --
                
                grdSecsLibraryGroup.endUpdate(false);

                // --

                if (grdSecsLibraryGroup.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdSecsLibraryGroup.ActiveRow = grdSecsLibraryGroup.Rows[0];
                    }
                    else
                    {
                        grdSecsLibraryGroup.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdSecsLibraryGroup.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfSecsLibrary(
            )
        {
            FSecsLibraryGroup fSlg = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fSlg = (FSecsLibraryGroup)grdSecsLibraryGroup.activeDataRow.Tag;

                // --
                
                grdSecsLibrary.beginUpdate(false);

                // --
                
                grdSecsLibrary.removeAllDataRow();

                // --

                foreach (FSecsLibrary fSlb in fSlg.fChildSecsLibraryCollection)
                {
                    cellValues = new object[] {
                        fSlb.name,
                        fSlb.description
                    };
                    dataRow = grdSecsLibrary.appendDataRow(fSlb.uniqueIdToString, cellValues);
                    dataRow.Tag = fSlb;
                    FCommon.refreshGridRowOfObject(fSlb, grdSecsLibrary.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fSlb == m_fOldSlb)
                    {
                        activeDataRowKey = fSlb.uniqueIdToString;
                    }
                }

                // --

                grdSecsLibrary.endUpdate(false);

                // --
                
                if (grdSecsLibrary.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdSecsLibrary.ActiveRow = grdSecsLibrary.Rows[0];
                    }
                    else
                    {
                        grdSecsLibrary.activateDataRow(activeDataRowKey);
                    }                    
                }
            }
            catch (Exception ex)
            {
                grdSecsLibrary.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSlg = null;
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
                    // SECS Library Group Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // SECS Library Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdSecsLibraryGroup.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdSecsLibraryGroup.Visible = true;
                    grdSecsLibrary.Visible = false;
                    grdSecsLibraryGroup.Focus();
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
                    // SECS Library Group Selection
                    // ***
                    refreshGridOfSecsLibrary();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdSecsLibrary.activeDataRow == null ? false : true);
                    // --
                    grdSecsLibraryGroup.Visible = false;
                    grdSecsLibrary.Visible = true;
                    grdSecsLibrary.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    // ***
                    // SECS Library Selection
                    // ***
                    selectSecsLibrary();
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

        private void selectSecsLibrary(
            )
        {
            try
            {
                m_fSelectedSlb = (FSecsLibrary)grdSecsLibrary.activeDataRow.Tag;
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

        #region FSecsLibrarySelector Form Event Handler

        private void FSecsLibrarySelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfSecsLibraryGroup();
                designGridOfSecsLibrary();

                // --

                grdSecsLibraryGroup.Visible = true;
                grdSecsLibrary.Visible = false;                
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

        private void FSecsLibrarySelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldSlb != null)
                {
                    m_fOldSlg = m_fOldSlb.fParent;
                    btnReset.Enabled = true;
                }

                // --
                
                refreshGridOfSecsLibraryGroup();

                // --

                m_step = 0;
                if (grdSecsLibraryGroup.activeDataRow != null)
                {
                    btnNext.Enabled = true;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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

                selectSecsLibrary();
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

                m_fSelectedSlb = null;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
;