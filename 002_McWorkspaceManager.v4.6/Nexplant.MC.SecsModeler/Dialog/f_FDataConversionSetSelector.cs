/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FDataConversionSetSelector.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.06.10
--  Description     : FAMate Workspace Manager Data Conversion Set Selector Form Class
--  History         : Created by Jeff.Kim at 2013.06.10
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
    public partial class FDataConversionSetSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FDataConversionSetList m_fOldDcl = null;
        private FDataConversionSet m_fOldDcs = null;
        private FDataConversionSet m_fSelectedDcs = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDataConversionSetSelector()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDataConversionSetSelector(
            FSsmCore fSsmCore,
            FDataConversionSet fOldDcs
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fOldDcs = fOldDcs;
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
                    m_fOldDcl = null;
                    m_fOldDcs = null;
                    m_fSelectedDcs = null;
                }

                m_disposed = true;
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FDataConversionSet fSelectedDataConversionSet
        {
            get
            {
                try
                {
                    return m_fSelectedDcs;
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                //base.fUIWizard.changeControlCaption();
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

        private void designOfDataConversionSetList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdDataConversionSetList.dataSource;
                // --
                uds.Band.Columns.Add("Data Conversion Set List");
                uds.Band.Columns.Add("Description");

                // --

                grdDataConversionSetList.DisplayLayout.Bands[0].Columns["Data Conversion Set List"].CellAppearance.Image = Properties.Resources.DataSetList_unlock;
                // --
                grdDataConversionSetList.DisplayLayout.Bands[0].Columns["Data Conversion Set List"].Width = 150;
                grdDataConversionSetList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designOfDataConversionSet(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdDataConversionSet.dataSource;
                // -- 
                uds.Band.Columns.Add("Data Conversion Set ");
                uds.Band.Columns.Add("Description");

                // --

                grdDataConversionSet.DisplayLayout.Bands[0].Columns["Data Conversion Set "].CellAppearance.Image = Properties.Resources.DataSet_unlock;
                // --
                grdDataConversionSet.DisplayLayout.Bands[0].Columns["Data Conversion Set "].Width = 150;
                grdDataConversionSet.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfDataConversionSetList(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdDataConversionSetList.beginUpdate(false);

                // --
                
                foreach (FDataConversionSetList fDcl in m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildDataConversionSetListCollection)
                {
                    cellValues = new object[]{                        
                        fDcl.name,
                        fDcl.description
                    };
                    dataRow = grdDataConversionSetList.appendDataRow(fDcl.uniqueIdToString, cellValues);
                    dataRow.Tag = fDcl;
                    FCommon.refreshGridRowOfObject(fDcl, grdDataConversionSetList.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fDcl == m_fOldDcl)
                    {
                        activeDataRowKey = fDcl.uniqueIdToString;
                    }
                }

                // --
                
                grdDataConversionSetList.endUpdate(false);

                // --

                if (grdDataConversionSetList.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdDataConversionSetList.ActiveRow = grdDataConversionSetList.Rows[0];
                    }
                    else
                    {
                        grdDataConversionSetList.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch(Exception ex)
            {
                grdDataConversionSetList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfDataConversionSet(
            )
        {
            FDataConversionSetList fDsl = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fDsl = (FDataConversionSetList)grdDataConversionSetList.activeDataRow.Tag;

                // --
                
                grdDataConversionSet.beginUpdate(false);

                // --                
                
                grdDataConversionSet.removeAllDataRow();                

                // --

                foreach (FDataConversionSet fDcs in fDsl.fChildDataConversionSetCollection)
                {
                    cellValues = new object[] {
                        fDcs.name,
                        fDcs.description
                    };
                    dataRow = grdDataConversionSet.appendDataRow(fDcs.uniqueIdToString, cellValues);
                    dataRow.Tag = fDcs;
                    FCommon.refreshGridRowOfObject(fDcs, grdDataConversionSet.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fDcs == m_fOldDcs)
                    {
                        activeDataRowKey = fDcs.uniqueIdToString;
                    }
                }

                // --

                grdDataConversionSet.endUpdate(false);

                // --
                
                if (grdDataConversionSet.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdDataConversionSet.ActiveRow = grdDataConversionSet.Rows[0];
                    }
                    else
                    {
                        grdDataConversionSet.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdDataConversionSet.endUpdate(false);
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
                    btnNext.Enabled = (grdDataConversionSetList.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdDataConversionSetList.Visible = true;
                    grdDataConversionSet.Visible = false;
                    grdDataConversionSetList.Focus();
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
                    refreshGridOfDataConversionSet();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdDataConversionSet.activeDataRow == null ? false : true);
                    // --
                    grdDataConversionSetList.Visible = false;
                    grdDataConversionSet.Visible = true;
                    grdDataConversionSet.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    selectDataConversionSet();
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

        private void selectDataConversionSet(
            )
        {
            try
            {
                m_fSelectedDcs = (FDataConversionSet)grdDataConversionSet.activeDataRow.Tag;
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

        #region FDataConversionSetSelector Form Event Handler

        private void FDataConversionSetSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designOfDataConversionSetList();
                designOfDataConversionSet();

                // --

                grdDataConversionSetList.Visible = true;
                grdDataConversionSet.Visible = false;                
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

        private void FDataConversionSetSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldDcs != null)
                {
                    m_fOldDcl = m_fOldDcs.fParent;
                    btnReset.Enabled = true;
                }

                // --

                refreshGridOfDataConversionSetList();

                // --

                m_step = 0;
                if (grdDataConversionSetList.activeDataRow != null)
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

                selectDataConversionSet();
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

                m_fSelectedDcs = null;
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
        
    }   // Class end
}   // Namespace end
