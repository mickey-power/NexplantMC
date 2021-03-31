/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FRepositorySelector.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.02
--  Description     : FAMate TCP Modeler Repository Selector Form Class
--  History         : Created by kitae at 2012.01.02
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
    public partial class FRepositorySelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FRepositoryList m_fOldRpl = null;
        private FRepository m_fOldRps = null;
        private FRepository m_fSelectedRps = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FRepositorySelector()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FRepositorySelector(
            FTcmCore fTcmCore,
            FRepository fOldRps
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fOldRps = fOldRps;
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
                    m_fOldRpl = null;
                    m_fOldRps = null;
                    m_fSelectedRps = null;
                }

                m_disposed = true;
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FRepository fSelectedRepository
        {
            get
            {
                try
                {
                    return m_fSelectedRps;
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

        private void designOfRepositoryList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdRepositoryList.dataSource;
                // --
                uds.Band.Columns.Add("Repository List");
                uds.Band.Columns.Add("Description");

                // --

                grdRepositoryList.DisplayLayout.Bands[0].Columns["Repository List"].CellAppearance.Image = Properties.Resources.RepositoryList_unlock;
                // --
                grdRepositoryList.DisplayLayout.Bands[0].Columns["Repository List"].Width = 150;
                grdRepositoryList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designOfRepository(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdRepository.dataSource;
                // -- 
                uds.Band.Columns.Add("Repository");
                uds.Band.Columns.Add("Description");

                // --

                grdRepository.DisplayLayout.Bands[0].Columns["Repository"].CellAppearance.Image = Properties.Resources.Repository_unlock;
                // --
                grdRepository.DisplayLayout.Bands[0].Columns["Repository"].Width = 150;
                grdRepository.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfRepositoryList(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdRepositoryList.beginUpdate(false);

                // --
                
                foreach (FRepositoryList fRpl in m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildRepositoryListCollection)
                {
                    cellValues = new object[]{                        
                        fRpl.name,
                        fRpl.description
                    };
                    dataRow = grdRepositoryList.appendDataRow(fRpl.uniqueIdToString, cellValues);
                    dataRow.Tag = fRpl;
                    FCommon.refreshGridRowOfObject(fRpl, grdRepositoryList.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fRpl == m_fOldRpl)
                    {
                        activeDataRowKey = fRpl.uniqueIdToString;
                    }
                }

                // --
                
                grdRepositoryList.endUpdate(false);

                // --

                if (grdRepositoryList.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdRepositoryList.ActiveRow = grdRepositoryList.Rows[0];
                    }
                    else
                    {
                        grdRepositoryList.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch(Exception ex)
            {
                grdRepositoryList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfRepository(
            )
        {
            FRepositoryList fRpl = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fRpl = (FRepositoryList)grdRepositoryList.activeDataRow.Tag;

                // --
                
                grdRepository.beginUpdate(false);

                // --                
                
                grdRepository.removeAllDataRow();                

                // --

                foreach (FRepository fRps in fRpl.fChildRepositoryCollection)
                {
                    cellValues = new object[] {
                        fRps.name,
                        fRps.description
                    };
                    dataRow = grdRepository.appendDataRow(fRps.uniqueIdToString, cellValues);
                    dataRow.Tag = fRps;
                    FCommon.refreshGridRowOfObject(fRps, grdRepository.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fRps == m_fOldRps)
                    {
                        activeDataRowKey = fRps.uniqueIdToString;
                    }
                }

                // --

                grdRepository.endUpdate(false);

                // --
                
                if (grdRepository.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdRepository.ActiveRow = grdRepository.Rows[0];
                    }
                    else
                    {
                        grdRepository.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdRepository.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fRpl = null;
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
                    // Repository List Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // Repository Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdRepositoryList.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdRepositoryList.Visible = true;
                    grdRepository.Visible = false;
                    grdRepositoryList.Focus();
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
                    // Repository List Selection
                    // ***
                    refreshGridOfRepository();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdRepository.activeDataRow == null ? false : true);
                    // --
                    grdRepositoryList.Visible = false;
                    grdRepository.Visible = true;
                    grdRepository.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    selectRepository();
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

        private void selectRepository(
            )
        {
            try
            {
                m_fSelectedRps = (FRepository)grdRepository.activeDataRow.Tag;
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

        #region FRepositorySelector Form Event Handler

        private void FRepositorySelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designOfRepositoryList();
                designOfRepository();

                // --

                grdRepositoryList.Visible = true;
                grdRepository.Visible = false;                
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

        private void FRepositorySelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldRps != null)
                {
                    m_fOldRpl = m_fOldRps.fParent;
                    btnReset.Enabled = true;
                }

                // --

                refreshGridOfRepositoryList();

                // --

                m_step = 0;
                if (grdRepositoryList.activeDataRow != null)
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

                selectRepository();
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

                m_fSelectedRps = null;
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
        
    }   // Class end
}   // Namespace end
