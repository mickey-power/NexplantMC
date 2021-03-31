/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcLibrarySelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.15
--  Description     : FAMate OPC Modeler OPC Library Selector Form Class 
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.OpcModeler
{
    public partial class FOpcLibrarySelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FOpcLibraryGroup m_fOldOlg = null;
        private FOpcLibrary m_fOldOlb = null;        
        private FOpcLibrary m_fSelectedOlb = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcLibrarySelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcLibrarySelector(
            FOpmCore fOpmCore,
            FOpcLibrary fOldOlb
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fOldOlb = fOldOlb;            
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
                    m_fOldOlg = null;
                    m_fOldOlb = null;
                    m_fSelectedOlb = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FOpcLibrary fSelectedOpcLibrary
        {
            get
            {
                try
                {
                    return m_fSelectedOlb;
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

        private void designGridOfOpcLibraryGroup(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdOpcLibraryGroup.dataSource;
                // --                
                uds.Band.Columns.Add("OPC Library Group");
                uds.Band.Columns.Add("Description");

                // --

                grdOpcLibraryGroup.DisplayLayout.Bands[0].Columns["OPC Library Group"].CellAppearance.Image = Properties.Resources.OpcLibraryGroup_unlock;
                // --
                grdOpcLibraryGroup.DisplayLayout.Bands[0].Columns["OPC Library Group"].Width = 150;
                grdOpcLibraryGroup.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfOpcLibrary(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdOpcLibrary.dataSource;
                // --
                uds.Band.Columns.Add("OPC Library");
                uds.Band.Columns.Add("Description");

                // --

                grdOpcLibrary.DisplayLayout.Bands[0].Columns["OPC Library"].CellAppearance.Image = Properties.Resources.OpcLibrary_unlock;
                // --
                grdOpcLibrary.DisplayLayout.Bands[0].Columns["OPC Library"].Width = 150;
                grdOpcLibrary.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfOpcLibraryGroup(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdOpcLibraryGroup.beginUpdate(false);

                // --

                foreach (FOpcLibraryGroup fOlg in m_fOpmCore.fOpmFileInfo.fOpcDriver.fChildOpcLibraryGroupCollection)
                {
                    cellValues = new object[]{                        
                        fOlg.name,
                        fOlg.description
                    };
                    dataRow = grdOpcLibraryGroup.appendDataRow(fOlg.uniqueIdToString, cellValues);
                    dataRow.Tag = fOlg;
                    FCommon.refreshGridRowOfObject(fOlg, grdOpcLibraryGroup.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fOlg == m_fOldOlg)
                    {
                        activeDataRowKey = fOlg.uniqueIdToString;
                    }
                }

                // --
                
                grdOpcLibraryGroup.endUpdate(false);

                // --

                if (grdOpcLibraryGroup.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdOpcLibraryGroup.ActiveRow = grdOpcLibraryGroup.Rows[0];
                    }
                    else
                    {
                        grdOpcLibraryGroup.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdOpcLibraryGroup.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfOpcLibrary(
            )
        {
            FOpcLibraryGroup fOlg = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fOlg = (FOpcLibraryGroup)grdOpcLibraryGroup.activeDataRow.Tag;

                // --
                
                grdOpcLibrary.beginUpdate(false);

                // --
                
                grdOpcLibrary.removeAllDataRow();

                // --

                foreach (FOpcLibrary fOlb in fOlg.fChildOpcLibraryCollection)
                {
                    cellValues = new object[] {
                        fOlb.name,
                        fOlb.description
                    };
                    dataRow = grdOpcLibrary.appendDataRow(fOlb.uniqueIdToString, cellValues);
                    dataRow.Tag = fOlb;
                    FCommon.refreshGridRowOfObject(fOlb, grdOpcLibrary.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fOlb == m_fOldOlb)
                    {
                        activeDataRowKey = fOlb.uniqueIdToString;
                    }
                }

                // --

                grdOpcLibrary.endUpdate(false);

                // --
                
                if (grdOpcLibrary.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdOpcLibrary.ActiveRow = grdOpcLibrary.Rows[0];
                    }
                    else
                    {
                        grdOpcLibrary.activateDataRow(activeDataRowKey);
                    }                    
                }
            }
            catch (Exception ex)
            {
                grdOpcLibrary.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fOlg = null;
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
                    // OPC Library Group Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // OPC Library Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdOpcLibraryGroup.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdOpcLibraryGroup.Visible = true;
                    grdOpcLibrary.Visible = false;
                    grdOpcLibraryGroup.Focus();
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
                    // OPC Library Group Selection
                    // ***
                    refreshGridOfOpcLibrary();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdOpcLibrary.activeDataRow == null ? false : true);
                    // --
                    grdOpcLibraryGroup.Visible = false;
                    grdOpcLibrary.Visible = true;
                    grdOpcLibrary.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    // ***
                    // OPC Library Selection
                    // ***
                    selectOpcLibrary();
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

        private void selectOpcLibrary(
            )
        {
            try
            {
                m_fSelectedOlb = (FOpcLibrary)grdOpcLibrary.activeDataRow.Tag;
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

        #region FOpcLibrarySelector Form Event Handler

        private void FOpcLibrarySelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfOpcLibraryGroup();
                designGridOfOpcLibrary();

                // --

                grdOpcLibraryGroup.Visible = true;
                grdOpcLibrary.Visible = false;                
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

        private void FOpcLibrarySelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldOlb != null)
                {
                    m_fOldOlg = m_fOldOlb.fParent;
                    btnReset.Enabled = true;
                }

                // --
                
                refreshGridOfOpcLibraryGroup();

                // --

                m_step = 0;
                if (grdOpcLibraryGroup.activeDataRow != null)
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

                selectOpcLibrary();
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

                m_fSelectedOlb = null;
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
;