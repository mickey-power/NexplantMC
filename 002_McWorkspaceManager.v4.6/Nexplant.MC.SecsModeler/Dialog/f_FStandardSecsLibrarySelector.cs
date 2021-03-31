/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FStandardSecsLibrarySelector.cs
--  Creator         : kitae
--  Create Date     : 2012.03.06
--  Description     : FAMate Workspace Manager Standard SECS Library Selector Form Class
--  History         : Created by kitae at 2011.03.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
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
    public partial class FStandardSecsLibrarySelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FSecsMessageList m_fOldSml = null;
        private FSecsMessages m_fOldSms = null;
        List<FIObject> m_fSelectedSms = null;        
        private FSecsLibraryGroupCollection m_fSLGCollection = null;
        private FSecsLibrary m_fSecsLibrary = null;        
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FStandardSecsLibrarySelector()
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FStandardSecsLibrarySelector(
            FSsmCore fSsmCore            
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;            
            m_fSLGCollection = fSsmCore.standardSecsLibrary.fChildSecsLibraryGroupCollection;
            m_fSecsLibrary = m_fSLGCollection[0].fChildSecsLibraryCollection[0];                        
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
                    m_fOldSml = null;
                    m_fOldSms = null;
                    m_fSelectedSms = null;
                    m_fSLGCollection = null;
                    m_fSecsLibrary = null;
                    m_step = 0;
                }
                m_disposed = true;
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public List<FIObject> fSelectedSecsMessages
        {
            get
            {
                try
                {
                    return m_fSelectedSms;
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

        private void designOfSecsMessagesList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdMessageList.dataSource;
                // --
                uds.Band.Columns.Add("SECS Messages List");
                uds.Band.Columns.Add("Description");

                // --

                grdMessageList.DisplayLayout.Bands[0].Columns["SECS Messages List"].CellAppearance.Image = Properties.Resources.SecsMessageList_unlock;
                // --
                grdMessageList.DisplayLayout.Bands[0].Columns["SECS Messages List"].Width = 150;
                grdMessageList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designOfSecsMessages(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdMessages.dataSource;
                // --                 
                uds.Band.Columns.Add("Check", typeof(bool));
                uds.Band.Columns.Add("SECS Messages Set");
                uds.Band.Columns.Add("Description");

                // --

                grdMessages.DisplayLayout.Bands[0].Columns["SECS Messages Set"].CellAppearance.Image = Properties.Resources.SecsMessages;
                // --
                grdMessages.DisplayLayout.Bands[0].Columns["Check"].Header.Caption = "";
                grdMessages.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxVisibility = HeaderCheckBoxVisibility.WhenUsingCheckEditor;
                grdMessages.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxSynchronization = HeaderCheckBoxSynchronization.RowsCollection;
                grdMessages.DisplayLayout.Bands[0].Columns["Check"].Header.CheckBoxAlignment = HeaderCheckBoxAlignment.Center;
                // --
                grdMessages.DisplayLayout.Bands[0].Columns["Check"].Width = 30;                
                grdMessages.DisplayLayout.Bands[0].Columns["SECS Messages Set"].Width = 270;                
                grdMessages.DisplayLayout.Bands[0].Columns["Description"].Width = 200;          
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

        private void refreshGridOfSecsMessageList(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;            
            try
            {
                grdMessageList.beginUpdate(false);
                
                // --
                
                foreach (FSecsMessageList fSml in m_fSecsLibrary.fChildSecsMessageListCollection)
                {                    
                    cellValues = new object[]{                        
                        fSml.name,
                        fSml.description
                    };
                    dataRow = grdMessageList.appendDataRow(fSml.uniqueIdToString, cellValues);                         
                    dataRow.Tag = fSml;
                    FCommon.refreshGridRowOfObject(fSml, grdMessageList.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fSml == m_fOldSml)
                    {
                        activeDataRowKey = fSml.uniqueIdToString;
                    }
                }

                // --
                
                grdMessageList.endUpdate(false);

                // --

                if (grdMessageList.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdMessageList.ActiveRow = grdMessageList.Rows[0];
                    }
                    else
                    {
                        grdMessageList.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch(Exception ex)
            {
                grdMessageList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfSecsMessages(
            )
        {
            FSecsMessageList fSml = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;
            bool check = false;

            try
            {
                fSml = (FSecsMessageList)grdMessageList.activeDataRow.Tag;
                
                // --
                
                grdMessages.beginUpdate(false);

                // --                
                
                grdMessages.removeAllDataRow();                
                
                // --
                
                foreach (FSecsMessages fSms in fSml.fChildSecsMessagesCollection)
                {                    
                    cellValues = new object[] {             
                        check,
                        "[S" + fSms.stream + " F" + fSms.function + " V" + fSms.version + "] " + fSms.name,
                        fSms.description
                    };                    
                    dataRow = grdMessages.appendDataRow(fSms.uniqueIdToString, cellValues);                                       
                    dataRow.Tag = fSms;                    
                    FCommon.refreshGridRowOfObject(fSms, grdMessages.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fSms == m_fOldSml)
                    {
                        activeDataRowKey = fSms.uniqueIdToString;
                    }
                }                

                // --

                grdMessages.endUpdate(false);

                // --
                
                if (grdMessages.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdMessages.ActiveRow = grdMessages.Rows[0] ;                        
                    }
                    else
                    {
                        grdMessages.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdMessages.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSml = null;
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
                    // Secs Messages List Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // Secs Messages Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdMessageList.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdMessageList.Visible = true;
                    grdMessages.Visible = false;
                    grdMessageList.Focus();
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
                    // Secs Messages List Selection
                    // ***
                    refreshGridOfSecsMessages();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdMessages.activeDataRow == null ? false : true);
                    // --
                    grdMessageList.Visible = false;
                    grdMessages.Visible = true;
                    grdMessages.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    // Secs Messages Checked
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

        private void selectSecsMessages(
            )
        {   
            try
            {
                m_fSelectedSms = new List<FIObject>();
                // --
                foreach (UltraDataRow uGridRow in grdMessages.dataSource.Rows)
                {
                    if (uGridRow.GetCellValue(0).ToString() == "True")
                    {
                        m_fSelectedSms.Add((FIObject)uGridRow.Tag);
                    }                    
                }
                
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

        #region FStandardSecsLibrary Selector Form Event Handler

        private void FStandardSecsLibrarySelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designOfSecsMessagesList();
                designOfSecsMessages();

                // --

                grdMessageList.Visible = true;
                grdMessages.Visible = false;                
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

        private void FStandardSecsLibrarySelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldSms != null)
                {
                    m_fOldSml = m_fOldSms.fParent;                    
                }

                // --

                refreshGridOfSecsMessageList();

                // --

                m_step = 0;
                if (grdMessageList.activeDataRow != null)
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

                selectSecsMessages();
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

                m_fSelectedSms = null;
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
        
        #region grdMessages Control Event Handler

        private void grdMessages_ClickCell(
            object sender, 
            ClickCellEventArgs e
            )
        {
            try
            {
                if (e.Cell.Row.Cells[0].Value.ToString() == "False")
                {
                    e.Cell.Row.Cells[0].SetValue("True", false);
                }
                else
                {
                    e.Cell.Row.Cells[0].SetValue("False", false);
                }
                
                grdMessages.Refresh();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
    }   // Class end
}   // Namespace end
