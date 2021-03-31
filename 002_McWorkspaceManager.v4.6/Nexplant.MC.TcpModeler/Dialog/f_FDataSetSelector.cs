/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FDataSetSelector.cs
--  Creator         : kitae
--  Create Date     : 2011.05.23
--  Description     : FAMate Workspace Manager Data Set Selector Form Class
--  History         : Created by kitae at 2011.05.23
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
    public partial class FDataSetSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FDataSetList m_fOldDsl = null;
        private FDataSet m_fOldDts = null;
        private FDataSet m_fSelectedDts = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDataSetSelector()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataSetSelector(
            FTcmCore fTcmCore,
            FDataSet fOldDts
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fOldDts = fOldDts;
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
                    m_fOldDsl = null;
                    m_fOldDts = null;
                    m_fSelectedDts = null;
                }

                m_disposed = true;
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FDataSet fSelectedDataSet
        {
            get
            {
                try
                {
                    return m_fSelectedDts;
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

        private void designOfDataSetList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdDataSetList.dataSource;
                // --
                uds.Band.Columns.Add("Data Set List");
                uds.Band.Columns.Add("Description");

                // --

                grdDataSetList.DisplayLayout.Bands[0].Columns["Data Set List"].CellAppearance.Image = Properties.Resources.DataSetList_unlock;
                // --
                grdDataSetList.DisplayLayout.Bands[0].Columns["Data Set List"].Width = 150;
                grdDataSetList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designOfDataSet(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdDataSet.dataSource;
                // -- 
                uds.Band.Columns.Add("Data Set");
                uds.Band.Columns.Add("Description");

                // --

                grdDataSet.DisplayLayout.Bands[0].Columns["Data Set"].CellAppearance.Image = Properties.Resources.DataSet_unlock;
                // --
                grdDataSet.DisplayLayout.Bands[0].Columns["Data Set"].Width = 150;
                grdDataSet.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfDataSetList(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdDataSetList.beginUpdate(false);

                // --
                
                foreach (FDataSetList fDsl in m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildDataSetListCollection)
                {
                    cellValues = new object[]{                        
                        fDsl.name,
                        fDsl.description
                    };
                    dataRow = grdDataSetList.appendDataRow(fDsl.uniqueIdToString, cellValues);
                    dataRow.Tag = fDsl;
                    FCommon.refreshGridRowOfObject(fDsl, grdDataSetList.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fDsl == m_fOldDsl)
                    {
                        activeDataRowKey = fDsl.uniqueIdToString;
                    }
                }

                // --
                
                grdDataSetList.endUpdate(false);

                // --

                if (grdDataSetList.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdDataSetList.ActiveRow = grdDataSetList.Rows[0];
                    }
                    else
                    {
                        grdDataSetList.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch(Exception ex)
            {
                grdDataSetList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfDataSet(
            )
        {
            FDataSetList fDsl = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fDsl = (FDataSetList)grdDataSetList.activeDataRow.Tag;

                // --
                
                grdDataSet.beginUpdate(false);

                // --                
                
                grdDataSet.removeAllDataRow();                

                // --

                foreach (FDataSet fDts in fDsl.fChildDataSetCollection)
                {
                    cellValues = new object[] {
                        fDts.name,
                        fDts.description
                    };
                    dataRow = grdDataSet.appendDataRow(fDts.uniqueIdToString, cellValues);
                    dataRow.Tag = fDts;
                    FCommon.refreshGridRowOfObject(fDts, grdDataSet.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fDts == m_fOldDts)
                    {
                        activeDataRowKey = fDts.uniqueIdToString;
                    }
                }

                // --

                grdDataSet.endUpdate(false);

                // --
                
                if (grdDataSet.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdDataSet.ActiveRow = grdDataSet.Rows[0];
                    }
                    else
                    {
                        grdDataSet.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdDataSet.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fDsl = null;
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
                    // Data Set List Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // Data Set Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdDataSetList.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdDataSetList.Visible = true;
                    grdDataSet.Visible = false;
                    grdDataSetList.Focus();
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
                    // Data Set List Selection
                    // ***
                    refreshGridOfDataSet();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdDataSet.activeDataRow == null ? false : true);
                    // --
                    grdDataSetList.Visible = false;
                    grdDataSet.Visible = true;
                    grdDataSet.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    selectDataSet();
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

        private void selectDataSet(
            )
        {
            try
            {
                m_fSelectedDts = (FDataSet)grdDataSet.activeDataRow.Tag;
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

        #region FDataSetSelector Form Event Handler

        private void FDataSetSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designOfDataSetList();
                designOfDataSet();

                // --

                grdDataSetList.Visible = true;
                grdDataSet.Visible = false;                
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

        private void FDataSetSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldDts != null)
                {
                    m_fOldDsl = m_fOldDts.fParent;
                    btnReset.Enabled = true;
                }

                // --

                refreshGridOfDataSetList();

                // --

                m_step = 0;
                if (grdDataSetList.activeDataRow != null)
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

                selectDataSet();
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

                m_fSelectedDts = null;
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
