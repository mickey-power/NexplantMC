/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FInlineEquipment.cs
--  Creator         : iskim
--  Create Date     : 2014.09.10
--  Description     : FAMate Admin Manager Inline Equipment Form Class 
--  History         : Created by iskim at 2014.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FInlineEquipment : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FInlineEquipment(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FInlineEquipment(
            FAdmCore fAmCore
            )
            : this()
        {
            base.fUIWizard = fAmCore.fUIWizard;
            m_fAdmCore = fAmCore;
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
                    m_fAdmCore = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
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

        protected override void changeControlFontName(
            )
        {
            try
            {
                base.changeControlFontName();
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

        private void controlButton(
            )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "Main")
                {
                    btnUpdate.Enabled = false;
                    // --
                    btnClear.Enabled = false;
                    // --
                    btnAppEquipment.Enabled = false;
                    btnRemEquipment.Enabled = false;
                    btnUpEquipment.Enabled = false;
                    btnDownEquipment.Enabled = false;
                }
                else if (key == "Sub")
                {
                    btnUpdate.Enabled = grdMainEqp.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnAppEquipment.Enabled = grdMainEqp.activeDataRowKey != string.Empty && m_tranEnabled; ;
                    btnRemEquipment.Enabled = grdSubEqp.activeDataRowKey != string.Empty && m_tranEnabled; ;
                    // --
                    btnClear.Enabled = grdSubEqp.activeDataRowKey != string.Empty && m_tranEnabled;

                    // --

                    controlSubEqpUpdownButton();                    
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

        private void controlSubEqpUpdownButton(
            )
        {
            int activeRowIndex = 0;

            try
            {
                if (grdSubEqp.activeDataRowKey == string.Empty)
                {
                    btnUpEquipment.Enabled = false;
                    btnDownEquipment.Enabled = false;
                }
                else
                {
                    btnUpEquipment.Enabled = m_tranEnabled;
                    btnDownEquipment.Enabled = m_tranEnabled;
                    
                    // --

                    activeRowIndex = grdSubEqp.ActiveRow.Index;
                    if (activeRowIndex == 0)
                    {
                        btnUpEquipment.Enabled = false;
                    }
                    // --
                    if (activeRowIndex == grdSubEqp.Rows.Count - 1)
                    {
                        btnDownEquipment.Enabled = false;
                    }
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

        private void initPropOfMainEquipment(
            )
        {
            try
            {
                pgdMainEqp.selectedObject = new FPropMainEquipment(m_fAdmCore, pgdMainEqp, false);
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

        private void setPropOfMainEquipment(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            
            try
            {
                if (grdMainEqp.activeDataRow == null)
                {
                    return;
                }
               
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eqp_name", grdMainEqp.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "InlineEquipment", "SearchMainEquipment", fSqlParams, true);

                // --

                pgdMainEqp.selectedObject = new FPropMainEquipment(m_fAdmCore, pgdMainEqp, dt, false);                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }
              
        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfMainEquipment(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdMainEqp.dataSource;
                // --
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Equipment ID");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Equipment Type");
                uds.Band.Columns.Add("Equipment Area");
                uds.Band.Columns.Add("Equipment Line");

                // --

                grdMainEqp.DisplayLayout.Bands[0].Columns["Equipment"].CellAppearance.Image = Properties.Resources.Equipment;
                // --
                grdMainEqp.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;
                // --
                grdMainEqp.DisplayLayout.Bands[0].Columns["Equipment"].Width = 120;
                grdMainEqp.DisplayLayout.Bands[0].Columns["Equipment ID"].Width = 120;
                grdMainEqp.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdMainEqp.DisplayLayout.Bands[0].Columns["Equipment Type"].Width = 120;
                grdMainEqp.DisplayLayout.Bands[0].Columns["Equipment Area"].Width = 120;
                grdMainEqp.DisplayLayout.Bands[0].Columns["Equipment Line"].Width = 120;
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

        private void designGridOfSubEquipment(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdSubEqp.dataSource;
                // --
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Equipment ID");
                uds.Band.Columns.Add("Sub Equipment");
                uds.Band.Columns.Add("Sub Equipment ID");
                uds.Band.Columns.Add("Description");

                // --

                // Image 추가
                grdSubEqp.DisplayLayout.Bands[0].Columns["Equipment"].CellAppearance.Image = Properties.Resources.Equipment;
               
                // --
                grdSubEqp.DisplayLayout.Bands[0].Columns["Equipment"].Width = 120;
                grdSubEqp.DisplayLayout.Bands[0].Columns["Equipment ID"].Width = 120;
                grdSubEqp.DisplayLayout.Bands[0].Columns["Sub Equipment"].Width = 120;
                grdSubEqp.DisplayLayout.Bands[0].Columns["Sub Equipment ID"].Width = 120;
                grdSubEqp.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                // --

                grdSubEqp.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;
                grdSubEqp.DisplayLayout.Bands[0].Columns["Equipment ID"].Header.Fixed = true;
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

        private void refreshGridOfMainEquipment(
            string beforeKey
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                grdMainEqp.removeAllDataRow();
                grdMainEqp.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdSubEqp.removeAllDataRow();
                grdSubEqp.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --
                initPropOfMainEquipment();

                // --

                grdMainEqp.beginUpdate();
                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);                
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "InlineEquipment", "ListMainEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment Name
                            r[1].ToString(),   // Equipment ID
                            r[2].ToString(),   // Description
                            r[3].ToString(),   // Type
                            r[4].ToString(),   // Area
                            r[5].ToString()    // Line
                            };
                        key = (string)cellValues[0];
                        grdMainEqp.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);
                
                // --

                grdMainEqp.endUpdate();

                // --

                if (grdMainEqp.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdMainEqp.activateDataRow(beforeKey);
                    }
                    if (grdMainEqp.activeDataRow == null)
                    {
                        grdMainEqp.ActiveRow = grdMainEqp.Rows[0];
                    }
                }

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdMainEqp.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfSubEquipment(
            string beforeKey
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                grdSubEqp.removeAllDataRow();
                grdSubEqp.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                grdSubEqp.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eqp_name", grdMainEqp.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "InlineEquipment", "ListSubEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r["EQP_NAME"].ToString(),       // Equipment Name
                            r["EQP_ID"].ToString(),         // Equipment ID
                            r["SUB_EQP_NAME"].ToString(),   // Sub Equipment Name
                            r["SUB_EQP_ID"].ToString(),     // Sub Equipment ID
                            r["SUB_EQP_DESC"].ToString()    // Sub Equipment Description
                            };
                        key = (string)cellValues[3];
                        grdSubEqp.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdSubEqp.endUpdate();

                // --

                if (grdSubEqp.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdSubEqp.activateDataRow(beforeKey);
                    }
                    if (grdSubEqp.activeDataRow == null)
                    {
                        grdSubEqp.ActiveRow = grdSubEqp.Rows[0];
                    }
                }

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdSubEqp.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfSubEquipment(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInInl = null;
            FXmlNode fXmlNodeInSeq = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                #region Validation

                FCommon.validateName(grdMainEqp.activeDataRowKey, true, this.fUIWizard, "Equipment");
               

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetInlineEquipmentUpdate_In.E_ADMADS_SetInlineEquipmentUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetInlineEquipmentUpdate_In.A_hLanguage, FADMADS_SetInlineEquipmentUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetInlineEquipmentUpdate_In.A_hFactory, FADMADS_SetInlineEquipmentUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetInlineEquipmentUpdate_In.A_hUserId, FADMADS_SetInlineEquipmentUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetInlineEquipmentUpdate_In.A_hHostIp, FADMADS_SetInlineEquipmentUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetInlineEquipmentUpdate_In.A_hHostName, FADMADS_SetInlineEquipmentUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetInlineEquipmentUpdate_In.A_hStep, FADMADS_SetInlineEquipmentUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInInl = fXmlNodeIn.set_elem(FADMADS_SetInlineEquipmentUpdate_In.FInline.E_Inline);
                fXmlNodeInInl.set_elemVal(
                    FADMADS_SetInlineEquipmentUpdate_In.FInline.A_Equipment, 
                    FADMADS_SetInlineEquipmentUpdate_In.FInline.D_Equipment, 
                    grdMainEqp.activeDataRowKey
                    );
                fXmlNodeInInl.set_elemVal(
                    FADMADS_SetInlineEquipmentUpdate_In.FInline.A_EquipmentID, 
                    FADMADS_SetInlineEquipmentUpdate_In.FInline.D_EquipmentID, 
                    grdMainEqp.activeDataRow["Equipment ID"].ToString()
                    );
                // --
                foreach (UltraGridRow row in grdSubEqp.Rows)
                {
                    fXmlNodeInSeq = fXmlNodeInInl.add_elem(FADMADS_SetInlineEquipmentUpdate_In.FInline.FSubEquipment.E_SubEquipment);
                    fXmlNodeInSeq.set_elemVal(
                        FADMADS_SetInlineEquipmentUpdate_In.FInline.FSubEquipment.A_SubEquipment, 
                        FADMADS_SetInlineEquipmentUpdate_In.FInline.FSubEquipment.D_SubEquipment, 
                        row.Cells["Sub Equipment"].Value.ToString()
                        );
                    fXmlNodeInSeq.set_elemVal(
                        FADMADS_SetInlineEquipmentUpdate_In.FInline.FSubEquipment.A_SubEquipmentID,
                        FADMADS_SetInlineEquipmentUpdate_In.FInline.FSubEquipment.D_SubEquipmentID, 
                        row.Cells["Sub Equipment ID"].Value.ToString()
                        );
                }
                
                // --

                FADMADSCaster.ADMADS_SetInlineEquipmentUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetInlineEquipmentUpdate_Out.A_hStatus, FADMADS_SetInlineEquipmentUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetInlineEquipmentUpdate_Out.A_hStatusMessage, FADMADS_SetInlineEquipmentUpdate_Out.D_hStatusMessage)
                        );
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInInl = null;
                fXmlNodeOut = null;
            }
        }
                
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuUpSubEquipment(
            )
        {
            int index = 0;

            try
            {
                if (grdSubEqp.activeDataRow == null)
                {
                    return;
                }
                // --
                index = grdSubEqp.activeDataRow.Index;

                // --

                if (index == 0)
                {
                    return;
                }

                // --

                grdSubEqp.beginUpdate();

                // --

                grdSubEqp.moveUpDataRow(index);

                // --

                grdSubEqp.endUpdate();

                // --

                grdSubEqp.ActiveRow = grdSubEqp.Rows[index - 1];
            }
            catch (Exception ex)
            {
                grdSubEqp.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuDownSubEquipment(
            )
        {
            int index = 0;

            try
            {
                if (grdSubEqp.activeDataRow == null)
                {
                    return;
                }
                // --
                index = grdSubEqp.activeDataRow.Index;

                // --

                if (index == (grdSubEqp.Rows.Count - 1))
                {
                    return;
                }

                // --

                grdSubEqp.beginUpdate();

                // --

                grdSubEqp.moveDownDataRow(index);

                // --

                grdSubEqp.endUpdate();

                // --

                grdSubEqp.ActiveRow = grdSubEqp.Rows[index + 1];
            }
            catch (Exception ex)
            {
                grdSubEqp.endUpdate();
                // --
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAppendSubEquipment(
            )
        {
            FSubEquipmentSelector fDialog = null;
            UltraGridRow row = null;
            string key = string.Empty;
            object[] cellValues = null;
            int index = 0;

            try
            {
                if (grdMainEqp.activeDataRowKey == string.Empty)
                {
                    return;
                }

                // --

                fDialog = new FSubEquipmentSelector(m_fAdmCore, grdMainEqp.activeDataRowKey);
                if (fDialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                grdSubEqp.beginUpdate(false);

                // --

                foreach (string[] equipment in fDialog.selectedList)
                {
                    key = equipment[1];
                    if (grdSubEqp.getDataRow(key) == null)
                    {
                        cellValues = new object[] {
                            grdMainEqp.activeDataRowKey,                           // Equipment
                            grdMainEqp.activeDataRow["Equipment ID"].ToString(),   // Equipment ID
                            equipment[0],                                          // Sub Equipment 
                            equipment[1],                                          // Sub Equipment ID
                            equipment[2]                                           // Description
                            };
                        index = grdSubEqp.appendOrUpdateDataRow(key, cellValues).Index;
                        row = grdSubEqp.Rows.GetRowWithListIndex(index);
                    }
                    grdSubEqp.activateDataRow(key);
                }

                // --

                grdSubEqp.endUpdate(false);

                // --

                if (grdSubEqp.activeDataRow == null)
                {
                    grdSubEqp.ActiveRow = grdSubEqp.Rows[0];
                }
            }
            catch (Exception ex)
            {
                grdSubEqp.endUpdate(false);
                // --
                FDebug.throwException(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
                // --
                row = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuRemoveSubEquipment(
            )
        {
            try
            {
                if (grdSubEqp.Rows.Count == 0)
                {
                    return;
                }

                // --

                grdSubEqp.beginUpdate();

                // --

                grdSubEqp.removeDataRows(grdSubEqp.selectedDataRowKeys);

                // --

                grdSubEqp.endUpdate();
            }
            catch (Exception ex)
            {
                grdSubEqp.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuClearSubEquipment(
            )
        {
            try
            {
                grdSubEqp.beginUpdate();

                // --

                grdSubEqp.removeAllDataRow();

                // --

                grdSubEqp.endUpdate();
            }
            catch (Exception ex)
            {
                grdSubEqp.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FInlineSetup Form Event Handler

        private void FInlineSetup_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.InlineEquipment);

                // --

                designGridOfMainEquipment();
                designGridOfSubEquipment();

                // --

                controlButton();

                // --

                m_fAdmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void FInlineSetup_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfMainEquipment(string.Empty);

                // --

                grdMainEqp.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FInlineSetup_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tabMain Control Event Handler

        private void tabMain_ActiveTabChanged(
            object sender, 
            Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdMainEqp Control Event Handler

        private void grdMainEqp_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfMainEquipment();

                // --

                refreshGridOfSubEquipment(string.Empty);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdMainEqp_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.SelectedTab = tabMain.Tabs["Sub"];
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdMainEqp_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfMainEquipment();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            } 
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdSubEqp Control Event Handler

        private void grdSubEqp_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                
                // --

                controlButton();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
            object sender,
            EventArgs e
            )
        {
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Sub")
                {
                    updateGridOfSubEquipment();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

       //------------------------------------------------------------------------------------------------------------------------

        #region btnClear Control Event Handler

        private void btnClear_Click(
            object sender, 
            EventArgs e
            )
        {
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                key = tabMain.ActiveTab.Key;
                // --
                if (key == "Sub")
                {
                    procMenuClearSubEquipment();

                    // --

                    controlButton();  
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion
        
        //------------------------------------------------------------------------------------------------------------------------

        #region rstMainEqp Control Event Handler

        private void rstMainEqp_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfMainEquipment(grdMainEqp.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void rstMainEqp_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdMainEqp.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstSubEqp Control Event Handler

        private void rstSubEqp_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdSubEqp.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void rstSubEqp_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfSubEquipment(grdSubEqp.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnUpEquipment Control Event Handler

        private void btnUpEquipment_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuUpSubEquipment();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnDownEquipment Control Event Handler

        private void btnDownEquipment_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuDownSubEquipment();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnAppEquipment Control Event Handler

        private void btnAppEquipment_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuAppendSubEquipment();

                // --

                controlButton();                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnRemEquipment Control Event Handler

        private void btnRemEquipment_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuRemoveSubEquipment();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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
