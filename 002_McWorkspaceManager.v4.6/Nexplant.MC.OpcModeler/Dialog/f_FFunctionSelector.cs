/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FFunctionSelector.cs
--  Creator         : kitae
--  Create Date     : 2011.08.29
--  Description     : FAMate Workspace Manager Function Selector Form Class
--  History         : Created by kitae at 2011.08.29
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
    public partial class FFunctionSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FFunctionNameList m_fOldFnl = null;
        private FFunctionName m_fSelectedFna = null;
        private FFunction m_fOldFun = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFunctionSelector()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFunctionSelector(
            FOpmCore fOpmCore,
            FFunction fOldFun
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fOldFun = fOldFun; 
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
                    m_fOldFnl = null;                   
                    m_fOldFun = null;
                    m_fSelectedFna = null;
                }

                m_disposed = true;
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FFunctionName fSelectedFunctionName
        {
            get
            {
                try
                {
                    return m_fSelectedFna;
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

        private void designOfFunctionNameList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdFunctionNameList.dataSource;
                // --
                uds.Band.Columns.Add("Function Name List");
                uds.Band.Columns.Add("Description");

                // --

                grdFunctionNameList.DisplayLayout.Bands[0].Columns["Function Name List"].CellAppearance.Image = Properties.Resources.OmdFunctionNameList;
                // --
                grdFunctionNameList.DisplayLayout.Bands[0].Columns["Function Name List"].Width = 150;
                grdFunctionNameList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designOfFunctionName(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdFunctionName.dataSource;
                // -- 
                uds.Band.Columns.Add("Function Name");
                uds.Band.Columns.Add("Description");

                // --

                grdFunctionName.DisplayLayout.Bands[0].Columns["Function Name"].CellAppearance.Image = Properties.Resources.OmdFunctionName;
                // -
                grdFunctionName.DisplayLayout.Bands[0].Columns["Function Name"].Width = 150;
                grdFunctionName.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfFunctionNameList(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdFunctionNameList.beginUpdate(false);

                // --
                
                foreach (FFunctionNameList fFnl in m_fOpmCore.fOpmFileInfo.fOpcDriver.fChildFunctionNameListCollection)
                {
                    cellValues = new object[]{                        
                        fFnl.name,
                        fFnl.description
                    };
                    dataRow = grdFunctionNameList.appendDataRow(fFnl.uniqueIdToString, cellValues);
                    dataRow.Tag = fFnl;
                    FCommon.refreshGridRowOfObject(fFnl, grdFunctionNameList.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fFnl == m_fOldFnl)
                    {
                        activeDataRowKey = fFnl.uniqueIdToString;
                    }
                }

                // --
                
                grdFunctionNameList.endUpdate(false);

                // --

                if (grdFunctionNameList.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdFunctionNameList.ActiveRow = grdFunctionNameList.Rows[0];
                    }
                    else
                    {
                        grdFunctionNameList.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch(Exception ex)
            {
                grdFunctionNameList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }      
    
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfFunctionName(
            )
        {
            FFunctionNameList fFnl = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fFnl = (FFunctionNameList)grdFunctionNameList.activeDataRow.Tag;

                // --
                
                grdFunctionName.beginUpdate(false);

                // --                
                
                grdFunctionName.removeAllDataRow();                

                // --

                foreach (FFunctionName fFna in fFnl.fChildFunctionNameCollection)
                {
                    cellValues = new object[] {
                        fFna.name,
                        fFna.description
                    };
                    dataRow = grdFunctionName.appendDataRow(fFna.uniqueIdToString, cellValues);
                    dataRow.Tag = fFna;

                    // --

                    if (fFna == m_fOldFun.fFunctionName)
                    {
                        activeDataRowKey = fFna.uniqueIdToString;
                    }
                }

                // --

                grdFunctionName.endUpdate(false);

                // --
                
                if (grdFunctionName.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdFunctionName.ActiveRow = grdFunctionName.Rows[0];
                    }
                    else
                    {
                        grdFunctionName.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdFunctionName.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fFnl = null;
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
                    // Function Name List Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // Function Name Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdFunctionNameList.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdFunctionNameList.Visible = true;
                    grdFunctionName.Visible = false;
                    grdFunctionNameList.Focus();
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
                    // Function Name List Selection
                    // ***
                    refreshGridOfFunctionName();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdFunctionName.activeDataRow == null ? false : true);
                    // --
                    grdFunctionNameList.Visible = false;
                    grdFunctionName.Visible = true;
                    grdFunctionName.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    selectFunctionName();
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

        private void selectFunctionName(
            )
        {
            try
            {
                m_fSelectedFna = (FFunctionName)grdFunctionName.activeDataRow.Tag;
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

        #region FFunctionSelector Form Event Handler

        private void FFunctionSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designOfFunctionNameList();
                designOfFunctionName();

                // --

                grdFunctionNameList.Visible = true;
                grdFunctionName.Visible = false;                
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

        private void FFunctionSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldFun.fFunctionName != null)
                {
                    m_fOldFnl = m_fOldFun.fFunctionName.fParent;
                    btnReset.Enabled = true;
                }

                // --

                refreshGridOfFunctionNameList();

                // --

                m_step = 0;
                if (grdFunctionNameList.activeDataRow != null)
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

                selectFunctionName();
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

                m_fSelectedFna = null;
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
        
    }   // Class end
}   // Namespace end
