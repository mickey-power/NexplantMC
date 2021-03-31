/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FScenarioSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.17
--  Description     : FAMate OPC Modeler Scenario Selector Form Class 
--  History         : Created by spike.lee at 2011.08.17
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
    public partial class FScenarioSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FEquipment m_fOldEqp = null;
        private FScenarioGroup m_fOldSng = null;        
        private FScenario m_fOldSnr = null;
        private FScenario m_fSelectedSnr = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FScenarioSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FScenarioSelector(
            FOpmCore fOpmCore,            
            FScenario fOldSnr
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fOldSnr = fOldSnr;
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
                    m_fOldEqp = null;
                    m_fOldSng = null;
                    m_fOldSnr = null;                    
                    m_fSelectedSnr = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FScenario fSelectedScenario
        {
            get
            {
                try
                {
                    return m_fSelectedSnr;
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

        private void designGridOfEquipment(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEquipment.dataSource;
                // --
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Description");

                // --

                grdEquipment.DisplayLayout.Bands[0].Columns["Equipment"].CellAppearance.Image = Properties.Resources.Equipment_unlock;
                // --
                grdEquipment.DisplayLayout.Bands[0].Columns["Equipment"].Width = 150;
                grdEquipment.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfScenarioGroup(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdScenarioGroup.dataSource;
                // --
                uds.Band.Columns.Add("Scenario Group");
                uds.Band.Columns.Add("Description");

                // --

                grdScenarioGroup.DisplayLayout.Bands[0].Columns["Scenario Group"].CellAppearance.Image = Properties.Resources.ScenarioGroup_unlock;
                // --
                grdScenarioGroup.DisplayLayout.Bands[0].Columns["Scenario Group"].Width = 150;
                grdScenarioGroup.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfScenario(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdScenario.dataSource;
                // --
                uds.Band.Columns.Add("Scenario");
                uds.Band.Columns.Add("Description");

                // --

                grdScenario.DisplayLayout.Bands[0].Columns["Scenario"].CellAppearance.Image = Properties.Resources.Scenario_unlock;
                // --
                grdScenario.DisplayLayout.Bands[0].Columns["Scenario"].Width = 150;
                grdScenario.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfEquipment(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdEquipment.beginUpdate(false);                

                // --

                foreach (FEquipment fEqp in m_fOpmCore.fOpmFileInfo.fOpcDriver.fChildEquipmentCollection)
                {
                    cellValues = new object[] {
                        fEqp.name,
                        fEqp.description
                    };
                    dataRow = grdEquipment.appendDataRow(fEqp.uniqueIdToString, cellValues);
                    dataRow.Tag = fEqp;
                    FCommon.refreshGridRowOfObject(fEqp, grdEquipment.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fEqp == m_fOldEqp)
                    {
                        activeDataRowKey = fEqp.uniqueIdToString;
                    }
                }

                // --

                grdEquipment.endUpdate(false);                

                // --

                if (grdEquipment.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdEquipment.ActiveRow = grdEquipment.Rows[0];
                    }
                    else
                    {
                        grdEquipment.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdEquipment.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfScenarioGroup(
            )
        {
            FEquipment fEqp = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fEqp = (FEquipment)grdEquipment.activeDataRow.Tag;

                // --

                grdScenarioGroup.beginUpdate(false);

                // --

                grdScenarioGroup.removeAllDataRow();

                // --

                foreach (FScenarioGroup fSng in fEqp.fChildScenarioGroupCollection)
                {
                    cellValues = new object[] {
                        fSng.name,
                        fSng.description
                    };
                    dataRow = grdScenarioGroup.appendDataRow(fSng.uniqueIdToString, cellValues);
                    dataRow.Tag = fSng;
                    FCommon.refreshGridRowOfObject(fSng, grdScenarioGroup.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fSng == m_fOldSng)
                    {
                        activeDataRowKey = fSng.uniqueIdToString;
                    }
                }

                // --

                grdScenarioGroup.endUpdate(false);

                // --

                if (grdScenarioGroup.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdScenarioGroup.ActiveRow = grdScenarioGroup.Rows[0];
                    }
                    else
                    {
                        grdScenarioGroup.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdScenarioGroup.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fEqp = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfScenario(
            )
        {
            FScenarioGroup fSng = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fSng = (FScenarioGroup)grdScenarioGroup.activeDataRow.Tag;

                // --

                grdScenario.beginUpdate(false);

                // --

                grdScenario.removeAllDataRow();

                // --

                foreach (FScenario fSnr in fSng.fChildScenarioCollection)
                {
                    cellValues = new object[] {
                        fSnr.name,          
                        fSnr.description
                    };
                    dataRow = grdScenario.appendDataRow(fSnr.uniqueIdToString, cellValues);
                    dataRow.Tag = fSnr;
                    FCommon.refreshGridRowOfObject(fSnr, grdScenario.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fSnr == m_fOldSnr)
                    {
                        activeDataRowKey = fSnr.uniqueIdToString;
                    }
                }                

                // --

                grdScenario.endUpdate(false);

                // --

                if (grdScenario.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdScenario.ActiveRow = grdScenario.Rows[0];
                    }
                    else
                    {
                        grdScenario.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdScenario.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSng = null;
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
                    // Equipment Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // Scenario Group Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdEquipment.activeDataRow == null ? false : true);
                    // --
                    grdEquipment.Visible = true;
                    grdScenarioGroup.Visible = false;
                    grdEquipment.Focus();
                    // --
                    m_step = 0;
                }                
                else if (m_step == 2)
                {
                    // ***
                    // Scenario Selection
                    // ***
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = (grdScenarioGroup.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdScenarioGroup.Visible = true;
                    grdScenario.Visible = false;
                    grdScenarioGroup.Focus();
                    // --
                    m_step = 1;
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
                    // Equipment Selection
                    // ***
                    refreshGridOfScenarioGroup();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = (grdScenarioGroup.activeDataRow == null ? false : true);                    
                    // --
                    grdEquipment.Visible = false;
                    grdScenarioGroup.Visible = true;
                    grdScenarioGroup.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    // ***
                    // Scenario Group Selection
                    // ***
                    refreshGridOfScenario();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdScenario.activeDataRow == null ? false : true);
                    // --
                    grdScenarioGroup.Visible = false;
                    grdScenario.Visible = true;
                    grdScenario.Focus();
                    // --
                    m_step = 2;
                }                
                else if (m_step == 2)
                {
                    // ***
                    // Scenario Selection
                    // ***
                    selectScenario();
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

        private void selectScenario(
            )
        {
            try
            {
                m_fSelectedSnr = (FScenario)grdScenario.activeDataRow.Tag;
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

        #region FScenarioSelector Form Event Handler

        private void FScenarioSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfEquipment();
                designGridOfScenarioGroup();
                designGridOfScenario();

                // --

                grdEquipment.Visible = true;
                grdScenarioGroup.Visible = false;
                grdScenario.Visible = false;
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

        private void FScenarioSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldSnr != null)
                {
                    m_fOldSng = m_fOldSnr.fParent;
                    m_fOldEqp = m_fOldSng.fParent;
                    btnReset.Enabled = true;
                }

                // --
                
                refreshGridOfEquipment();

                // --

                m_step = 0;                
                if (grdEquipment.activeDataRow != null)
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

                selectScenario();
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

                m_fSelectedSnr = null;
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
