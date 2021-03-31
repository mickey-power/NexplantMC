/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentStateSetSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.14
--  Description     : FAMate Workspace Manager Equipment State Set Selector Form Class
--  History         : Created by spike.lee at 2012.03.14
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
    public partial class FEquipmentStateSetSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FEquipmentStateSetList m_fOldEsl = null;
        private FEquipmentStateSet m_fOldEss = null;
        private FEquipmentStateSet m_fSelectedEss = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentStateSetSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateSetSelector(
            FSsmCore fSsmCore,
            FEquipmentStateSet fOldEss
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fOldEss = fOldEss;
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
                    m_fOldEsl = null;
                    m_fOldEss = null;
                    m_fSelectedEss = null;
                }

                m_disposed = true;
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FEquipmentStateSet fSelectedEquipmentStateSet
        {
            get
            {
                try
                {
                    return m_fSelectedEss;
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

        private void designOfEquipmentStateSetList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEquipmentStateSetList.dataSource;
                // --
                uds.Band.Columns.Add("Equipment State Set List");
                uds.Band.Columns.Add("Description");

                // --

                grdEquipmentStateSetList.DisplayLayout.Bands[0].Columns["Equipment State Set List"].CellAppearance.Image = Properties.Resources.EquipmentStateSetList_unlock;
                // --
                grdEquipmentStateSetList.DisplayLayout.Bands[0].Columns["Equipment State Set List"].Width = 150;
                grdEquipmentStateSetList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designOfEquipmentStateSet(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEquipmentStateSet.dataSource;
                // -- 
                uds.Band.Columns.Add("Equipment State Set");
                uds.Band.Columns.Add("Description");

                // --

                grdEquipmentStateSet.DisplayLayout.Bands[0].Columns["Equipment State Set"].CellAppearance.Image = Properties.Resources.EquipmentStateSet_unlock;
                // --
                grdEquipmentStateSet.DisplayLayout.Bands[0].Columns["Equipment State Set"].Width = 150;
                grdEquipmentStateSet.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfEquipmentStateSetList(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdEquipmentStateSetList.beginUpdate(false);

                // --
                
                foreach (FEquipmentStateSetList fEsl in m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildEquipmentStateSetListCollection)
                {
                    cellValues = new object[]{                        
                        fEsl.name,
                        fEsl.description
                        };
                    dataRow = grdEquipmentStateSetList.appendDataRow(fEsl.uniqueIdToString, cellValues);
                    dataRow.Tag = fEsl;
                    FCommon.refreshGridRowOfObject(fEsl, grdEquipmentStateSetList.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fEsl == m_fOldEsl)
                    {
                        activeDataRowKey = fEsl.uniqueIdToString;
                    }
                }

                // --
                
                grdEquipmentStateSetList.endUpdate(false);

                // --

                if (grdEquipmentStateSetList.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdEquipmentStateSetList.ActiveRow = grdEquipmentStateSetList.Rows[0];
                    }
                    else
                    {
                        grdEquipmentStateSetList.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch(Exception ex)
            {
                grdEquipmentStateSetList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEquipmentStateSet(
            )
        {
            FEquipmentStateSetList fEsl = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fEsl = (FEquipmentStateSetList)grdEquipmentStateSetList.activeDataRow.Tag;

                // --
                
                grdEquipmentStateSet.beginUpdate(false);

                // --                
                
                grdEquipmentStateSet.removeAllDataRow();                

                // --

                foreach (FEquipmentStateSet fEss in fEsl.fChildEquipmentStateSetCollection)
                {
                    cellValues = new object[] {
                        fEss.name,
                        fEss.description
                        };
                    dataRow = grdEquipmentStateSet.appendDataRow(fEss.uniqueIdToString, cellValues);
                    dataRow.Tag = fEss;
                    FCommon.refreshGridRowOfObject(fEss, grdEquipmentStateSet.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fEss == m_fOldEss)
                    {
                        activeDataRowKey = fEss.uniqueIdToString;
                    }
                }

                // --

                grdEquipmentStateSet.endUpdate(false);

                // --
                
                if (grdEquipmentStateSet.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdEquipmentStateSet.ActiveRow = grdEquipmentStateSet.Rows[0];
                    }
                    else
                    {
                        grdEquipmentStateSet.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdEquipmentStateSet.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fEsl = null;
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
                    // Equipment State Set List Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // Equipment State Set Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdEquipmentStateSetList.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdEquipmentStateSetList.Visible = true;
                    grdEquipmentStateSet.Visible = false;
                    grdEquipmentStateSetList.Focus();
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
                    // Equipment State Set List Selection
                    // ***
                    refreshGridOfEquipmentStateSet();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdEquipmentStateSet.activeDataRow == null ? false : true);
                    // --
                    grdEquipmentStateSetList.Visible = false;
                    grdEquipmentStateSet.Visible = true;
                    grdEquipmentStateSet.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    selectEquipmentStateSet();
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

        private void selectEquipmentStateSet(
            )
        {
            try
            {
                m_fSelectedEss = (FEquipmentStateSet)grdEquipmentStateSet.activeDataRow.Tag;
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

        #region FEquipmentStateSetSelector Form Event Handler

        private void FEquipmentStateSetSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designOfEquipmentStateSetList();
                designOfEquipmentStateSet();

                // --

                grdEquipmentStateSetList.Visible = true;
                grdEquipmentStateSet.Visible = false;                
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

        private void FEquipmentStateSetSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldEss != null)
                {
                    m_fOldEsl = m_fOldEss.fParent;
                    btnReset.Enabled = true;
                }

                // --

                refreshGridOfEquipmentStateSetList();

                // --

                m_step = 0;
                if (grdEquipmentStateSetList.activeDataRow != null)
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

                selectEquipmentStateSet();
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

                m_fSelectedEss = null;
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
