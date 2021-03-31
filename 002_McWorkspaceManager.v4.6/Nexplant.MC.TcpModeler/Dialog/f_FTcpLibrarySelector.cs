/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpLibrarySelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.15
--  Description     : FAMate TCP Modeler TCP Library Selector Form Class 
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.TcpModeler
{
    public partial class FTcpLibrarySelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FTcpLibraryGroup m_fOldTlg = null;
        private FTcpLibrary m_fOldTlb = null;        
        private FTcpLibrary m_fSelectedTlb = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpLibrarySelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpLibrarySelector(
            FTcmCore fTcmCore,
            FTcpLibrary fOldTlb
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fOldTlb = fOldTlb;            
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
                    m_fOldTlg = null;
                    m_fOldTlb = null;
                    m_fSelectedTlb = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FTcpLibrary fSelectedTcpLibrary
        {
            get
            {
                try
                {
                    return m_fSelectedTlb;
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

        private void designGridOfTcpLibraryGroup(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdTcpLibraryGroup.dataSource;
                // --                
                uds.Band.Columns.Add("TCP Library Group");
                uds.Band.Columns.Add("Description");

                // --

                grdTcpLibraryGroup.DisplayLayout.Bands[0].Columns["TCP Library Group"].CellAppearance.Image = Properties.Resources.TcpLibraryGroup_unlock;
                // --
                grdTcpLibraryGroup.DisplayLayout.Bands[0].Columns["TCP Library Group"].Width = 150;
                grdTcpLibraryGroup.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfTcpLibrary(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdTcpLibrary.dataSource;
                // --
                uds.Band.Columns.Add("TCP Library");
                uds.Band.Columns.Add("Description");

                // --

                grdTcpLibrary.DisplayLayout.Bands[0].Columns["TCP Library"].CellAppearance.Image = Properties.Resources.TcpLibrary_unlock;
                // --
                grdTcpLibrary.DisplayLayout.Bands[0].Columns["TCP Library"].Width = 150;
                grdTcpLibrary.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfTcpLibraryGroup(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdTcpLibraryGroup.beginUpdate(false);

                // --

                foreach (FTcpLibraryGroup fTlg in m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildTcpLibraryGroupCollection)
                {
                    cellValues = new object[]{                        
                        fTlg.name,
                        fTlg.description
                    };
                    dataRow = grdTcpLibraryGroup.appendDataRow(fTlg.uniqueIdToString, cellValues);
                    dataRow.Tag = fTlg;
                    FCommon.refreshGridRowOfObject(fTlg, grdTcpLibraryGroup.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fTlg == m_fOldTlg)
                    {
                        activeDataRowKey = fTlg.uniqueIdToString;
                    }
                }

                // --
                
                grdTcpLibraryGroup.endUpdate(false);

                // --

                if (grdTcpLibraryGroup.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdTcpLibraryGroup.ActiveRow = grdTcpLibraryGroup.Rows[0];
                    }
                    else
                    {
                        grdTcpLibraryGroup.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdTcpLibraryGroup.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfTcpLibrary(
            )
        {
            FTcpLibraryGroup fTlg = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fTlg = (FTcpLibraryGroup)grdTcpLibraryGroup.activeDataRow.Tag;

                // --
                
                grdTcpLibrary.beginUpdate(false);

                // --
                
                grdTcpLibrary.removeAllDataRow();

                // --

                foreach (FTcpLibrary fTlb in fTlg.fChildTcpLibraryCollection)
                {
                    cellValues = new object[] {
                        fTlb.name,
                        fTlb.description
                    };
                    dataRow = grdTcpLibrary.appendDataRow(fTlb.uniqueIdToString, cellValues);
                    dataRow.Tag = fTlb;
                    FCommon.refreshGridRowOfObject(fTlb, grdTcpLibrary.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fTlb == m_fOldTlb)
                    {
                        activeDataRowKey = fTlb.uniqueIdToString;
                    }
                }

                // --

                grdTcpLibrary.endUpdate(false);

                // --
                
                if (grdTcpLibrary.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdTcpLibrary.ActiveRow = grdTcpLibrary.Rows[0];
                    }
                    else
                    {
                        grdTcpLibrary.activateDataRow(activeDataRowKey);
                    }                    
                }
            }
            catch (Exception ex)
            {
                grdTcpLibrary.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fTlg = null;
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
                    // TCP Library Group Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // TCP Library Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdTcpLibraryGroup.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdTcpLibraryGroup.Visible = true;
                    grdTcpLibrary.Visible = false;
                    grdTcpLibraryGroup.Focus();
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
                    // TCP Library Group Selection
                    // ***
                    refreshGridOfTcpLibrary();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdTcpLibrary.activeDataRow == null ? false : true);
                    // --
                    grdTcpLibraryGroup.Visible = false;
                    grdTcpLibrary.Visible = true;
                    grdTcpLibrary.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    // ***
                    // TCP Library Selection
                    // ***
                    selectTcpLibrary();
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

        private void selectTcpLibrary(
            )
        {
            try
            {
                m_fSelectedTlb = (FTcpLibrary)grdTcpLibrary.activeDataRow.Tag;
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

        #region FTcpLibrarySelector Form Event Handler

        private void FTcpLibrarySelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfTcpLibraryGroup();
                designGridOfTcpLibrary();

                // --

                grdTcpLibraryGroup.Visible = true;
                grdTcpLibrary.Visible = false;                
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

        private void FTcpLibrarySelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldTlb != null)
                {
                    m_fOldTlg = m_fOldTlb.fParent;
                    btnReset.Enabled = true;
                }

                // --
                
                refreshGridOfTcpLibraryGroup();

                // --

                m_step = 0;
                if (grdTcpLibraryGroup.activeDataRow != null)
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                selectTcpLibrary();
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

                m_fSelectedTlb = null;
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
;