/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FGeneralCode.cs
--  Creator         : mjkim
--  Create Date     : 2013.06.05
--  Description     : FAMate Admin Manager Setup General Code Form Class 
--  History         : Created by mjkim at 2013.06.05
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FGeneralCode : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const char KEY_SEPARATOR = (char)0x1F;

        // --

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;
        private FGeneralCodeColumn[] m_generalCodeTableKey = null;
        private FGeneralCodeColumn[] m_generalCodeTableData = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FGeneralCode(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FGeneralCode(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
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

                if (key == "General Code Table")
                {
                    btnDelete.Enabled = grdTable.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdTable.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "General Code Data") 
                {
                    btnDelete.Enabled = grdData.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = grdTable.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdData.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void initPropOfGeneralCodeTable(
            )
        {
            try
            {
                pgdTable.selectedObject = new FPropGeneralCodeTable(m_fAdmCore, pgdTable, m_tranEnabled);
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

        private void initPropOfGeneralCodeData(
            )
        {
            try
            {
                if (m_generalCodeTableKey == null)
                {
                    m_generalCodeTableKey = new FGeneralCodeColumn[2];
                    for (int i = 0; i < m_generalCodeTableKey.Length; i++)
                    {
                        m_generalCodeTableKey[i] = new FGeneralCodeColumn(string.Empty, FGeneralCodeFormat.Ascii.ToString(), "30");
                    }
                }
                // --
                if (m_generalCodeTableData == null)
                {
                    m_generalCodeTableData = new FGeneralCodeColumn[10];
                    for (int i = 0; i < m_generalCodeTableData.Length; i++)
                    {
                        m_generalCodeTableData[i] = new FGeneralCodeColumn(string.Empty, FGeneralCodeFormat.Ascii.ToString(), "50");
                    }
                }
                // --
                pgdData.selectedObject = new FPropGeneralCodeData(m_fAdmCore, pgdData, grdTable.activeDataRowKey, m_generalCodeTableKey, m_generalCodeTableData, m_tranEnabled);
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

        private void setPropOfGeneralCodeTable(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            
            try
            {
                if (grdTable.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("table_name", grdTable.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "GcmTable", "SearchGcmTable", fSqlParams, true);

                // --

                pgdTable.selectedObject = new FPropGeneralCodeTable(m_fAdmCore, pgdTable, dt, m_tranEnabled);

                // --
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

        private void setPropOfGeneralCodeData(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdData.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("table_name", grdTable.activeDataRowKey);
                fSqlParams.add("key_1", grdData.ActiveRow.Cells[1].Text);
                fSqlParams.add("key_2", grdData.ActiveRow.Cells[2].Text.Trim() == string.Empty ? " " : grdData.ActiveRow.Cells[2].Text);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "GcmData", "SearchGcmData", fSqlParams, true);

                // --

                pgdData.selectedObject = new FPropGeneralCodeData(m_fAdmCore, pgdData, m_generalCodeTableKey, m_generalCodeTableData, dt, m_tranEnabled);
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

        private void designGridOfGeneralCodeTable(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdTable.dataSource;
                // --
                uds.Band.Columns.Add("Table");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("System Table");
                
                // --

                grdTable.DisplayLayout.Bands[0].Columns["Table"].CellAppearance.Image = Properties.Resources.GeneralCodeTable;
                // --
                grdTable.DisplayLayout.Bands[0].Columns["Table"].Header.Fixed = true;
                // --
                grdTable.DisplayLayout.Bands[0].Columns["Table"].Width = 260;
                grdTable.DisplayLayout.Bands[0].Columns["Description"].Width = 350;
                grdTable.DisplayLayout.Bands[0].Columns["System Table"].Width = 70;
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

        private void designGridOfGeneralCodeData(
            )
        {
            UltraDataSource uds = null;
            string columnKey = string.Empty;

            try
            {
                grdData.removeAllDataRow();

                // --

                uds = grdData.dataSource;
                uds.Band.Columns.Clear();
                // --
                uds.Band.Columns.Add("Table");
                grdData.DisplayLayout.Bands[0].Columns["Table"].Header.Fixed = true;
                grdData.DisplayLayout.Bands[0].Columns["Table"].Width = 260;

                // --
                
                for (int i = 0; i < m_generalCodeTableKey.Length; i++)
                {
                    columnKey = "Key_" + (i + 1).ToString();
                    // --
                    uds.Band.Columns.Add(columnKey);
                    grdData.DisplayLayout.Bands[0].Columns[columnKey].Header.Caption = m_generalCodeTableKey[i].prt;
                    grdData.DisplayLayout.Bands[0].Columns[columnKey].Header.Fixed = true;
                    grdData.DisplayLayout.Bands[0].Columns[columnKey].Hidden = m_generalCodeTableKey[i].prt == string.Empty ? true : false;
                    grdData.DisplayLayout.Bands[0].Columns[columnKey].Width = 100;
                }
                grdData.DisplayLayout.Bands[0].Columns[0].CellAppearance.Image = Properties.Resources.GeneralCodeData;

                // --

                for (int i = 0; i < m_generalCodeTableData.Length; i++)
                {
                    columnKey = "Data_" + (i + 1).ToString();
                    // --
                    uds.Band.Columns.Add(columnKey);
                    grdData.DisplayLayout.Bands[0].Columns[columnKey].Header.Caption = m_generalCodeTableData[i].prt;
                    grdData.DisplayLayout.Bands[0].Columns[columnKey].Hidden = m_generalCodeTableData[i].prt == string.Empty ? true : false;
                    grdData.DisplayLayout.Bands[0].Columns[columnKey].Width = 100;
                }
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

        private void refreshGridOfGeneralCodeTable(
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
                grdTable.removeAllDataRow();
                grdTable.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfGeneralCodeTable();
                
                // --

                refreshGeneralCodeTable();
                // --
                designGridOfGeneralCodeData();
                initPropOfGeneralCodeData();

                // --

                grdTable.beginUpdate();

                // --
                
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --                
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "GcmTable", "ListGcmTable", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Table
                            r[1].ToString(),   // Description
                            r[3].ToString()    // System Table
                            };
                        key = (string)cellValues[0];
                        grdTable.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);
                
                // --

                grdTable.endUpdate();

                // --

                if (grdTable.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdTable.activateDataRow(beforeKey);
                    }
                    // --
                    if (grdTable.activeDataRow == null)
                    {
                        grdTable.ActiveRow = grdTable.Rows[0];
                    }
                }

                // -- 

                refreshTableTotal();

                // --

                controlButton();

                // --

                grdTable.Focus();
            }
            catch (Exception ex)
            {
                grdTable.endUpdate();
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

        private void refreshGridOfGeneralCodeData(
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
                refreshGeneralCodeTable();
                // --
                designGridOfGeneralCodeData();
                initPropOfGeneralCodeData();

                // --

                if (grdTable.ActiveRow == null)
                {    
                    return;
                }
                
                // --

                grdData.beginUpdate();

                // --                

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("table_name", grdTable.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "GcmData", "ListGcmData", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            grdTable.activeDataRowKey, // Table
                            r[0].ToString(),           // Key_1
                            r[1].ToString(),           // Key_2
                            r[2].ToString(),           // DATA_1
                            r[3].ToString(),           // DATA_2
                            r[4].ToString(),           // DATA_3
                            r[5].ToString(),           // DATA_4
                            r[6].ToString(),           // DATA_5
                            r[7].ToString(),           // DATA_6
                            r[8].ToString(),           // DATA_7
                            r[9].ToString(),           // DATA_8
                            r[10].ToString(),          // DATA_9
                            r[11].ToString()           // DATA_10
                            };
                        key = r[0].ToString() + KEY_SEPARATOR + r[1].ToString();
                        grdData.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdData.endUpdate();

                // --

                if (grdData.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdData.activateDataRow(beforeKey);
                    }
                    if (grdData.activeDataRow == null)
                    {
                        grdData.ActiveRow = grdData.Rows[0];
                    }
                }

                // --

                refreshDataTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "General Code Data")
                {
                    grdData.Focus();
                }
            }
            catch (Exception ex)
            {
                grdData.endUpdate();
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

        private void refreshGeneralCodeTable(
            )
        {
            FPropGeneralCodeTable fPropGct = null;
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            int index = 0;

            try
            {
                // ***
                // Init General Code Table Key
                // ***
                m_generalCodeTableKey = new FGeneralCodeColumn[2];
                for (int i = 0; i < m_generalCodeTableKey.Length; i++)
                {
                    m_generalCodeTableKey[i] = new FGeneralCodeColumn(string.Empty, FGeneralCodeFormat.Ascii.ToString(), "30");
                }
                // ***
                // Init General Code Table Data
                // ***
                m_generalCodeTableData = new FGeneralCodeColumn[10];
                for (int i = 0; i < m_generalCodeTableData.Length; i++)
                {
                    m_generalCodeTableData[i] = new FGeneralCodeColumn(string.Empty, FGeneralCodeFormat.Ascii.ToString(), "50");
                }

                // --

                if (grdTable.activeDataRow == null)
                {
                    return;
                }

                // --

                if (tabMain.ActiveTab.Key == "General Code Table")
                {
                    fPropGct = (FPropGeneralCodeTable)pgdTable.selectedObject;
                    // --
                    m_generalCodeTableKey = fPropGct.GeneralCodeTableKey;
                    m_generalCodeTableData = fPropGct.GeneralCodeTableData;
                }
                else if (tabMain.ActiveTab.Key == "General Code Data")
                {
                    fSqlParams = new FSqlParams();
                    fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                    fSqlParams.add("table_name", grdTable.activeDataRowKey);
                    // --
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "GcmData", "SearchGcmTable", fSqlParams, true);

                    // --

                    // ***
                    // Set General Code Table Key
                    // ***
                    for (int i = 0; i < m_generalCodeTableKey.Length; i++)
                    {
                        m_generalCodeTableKey[i] = new FGeneralCodeColumn(
                            dt.Rows[0][index++].ToString(),
                            dt.Rows[0][index++].ToString(),
                            dt.Rows[0][index++].ToString()
                            );
                    }
                    // ***
                    // Set General Code Table Data
                    // ***
                    for (int i = 0; i < m_generalCodeTableData.Length; i++)
                    {
                        m_generalCodeTableData[i] = new FGeneralCodeColumn(
                            dt.Rows[0][index++].ToString(),
                            dt.Rows[0][index++].ToString(),
                            dt.Rows[0][index++].ToString()
                            );
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropGct = null;
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void validateData(
            string value,
            bool emptyError,
            FGeneralCodeColumn fGeneralCodeTable,
            params object[] args
           )
        {
            int number1;
            double number2;

            try
            {
                if (value == string.Empty)
                {
                    if (emptyError)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0004", args));
                    }
                    return;
                }

                // --

                if (fGeneralCodeTable.fmt == FGeneralCodeFormat.Ascii)
                {
                    if (value.Length > fGeneralCodeTable.size)
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0024", args));
                    }

                }
                else if (fGeneralCodeTable.fmt == FGeneralCodeFormat.Number)
                {
                    if (!Int32.TryParse(value, out number1))
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0015", args));
                    }
                }
                else if (fGeneralCodeTable.fmt == FGeneralCodeFormat.Double)
                {
                    if (!Double.TryParse(value, out number2))
                    {
                        FDebug.throwFException(this.fUIWizard.generateMessage("E0015", args));
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

        private void updateGridOfGeneralCodeTable(
            )
        {
            FPropGeneralCodeTable fPropGct = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInGct = null;
            FXmlNode fXmlNodeInGctKey1 = null;
            FXmlNode fXmlNodeInGctKey2 = null;
            FXmlNode fXmlNodeInGctData1 = null;
            FXmlNode fXmlNodeInGctData2 = null;
            FXmlNode fXmlNodeInGctData3 = null;
            FXmlNode fXmlNodeInGctData4 = null;
            FXmlNode fXmlNodeInGctData5 = null;
            FXmlNode fXmlNodeInGctData6 = null;
            FXmlNode fXmlNodeInGctData7 = null;
            FXmlNode fXmlNodeInGctData8 = null;
            FXmlNode fXmlNodeInGctData9 = null;
            FXmlNode fXmlNodeInGctData10 = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropGct = (FPropGeneralCodeTable)pgdTable.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropGct.Table, true, this.fUIWizard, "General Code Table");
                if (fPropGct.Table.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "General Code Table" }));
                }

                if (fPropGct.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                FCommon.validateName(fPropGct.Key_1_Prt, true, this.fUIWizard, "Key 1 Prompt");
                if (fPropGct.Key_1_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Key 1 Prompt" }));
                }
                if (fPropGct.Key_1_Size < 1 || fPropGct.Key_1_Size > 30)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Key 1 Size" }));
                }

                FCommon.validateName(fPropGct.Key_2_Prt, false, this.fUIWizard, "Key 2 Prompt");
                if (fPropGct.Key_2_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Key 2 Prompt" }));
                }
                if (fPropGct.Key_2_Size < 1 || fPropGct.Key_1_Size > 30)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Key 2 Size" }));
                }

                FCommon.validateName(fPropGct.Data_1_Prt, false, this.fUIWizard, "Data 1 Prompt");
                if (fPropGct.Data_1_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 1 Prompt" }));
                }
                if (fPropGct.Data_1_Size < 1 || fPropGct.Data_1_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 1 Size" }));
                }

                FCommon.validateName(fPropGct.Data_2_Prt, false, this.fUIWizard, "Data 2 Prompt");
                if (fPropGct.Data_2_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 2 Prompt" }));
                }
                if (fPropGct.Data_2_Size < 1 || fPropGct.Data_2_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 2 Size" }));
                }

                FCommon.validateName(fPropGct.Data_3_Prt, false, this.fUIWizard, "Data 3 Prompt");
                if (fPropGct.Data_3_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 3 Prompt" }));
                }
                if (fPropGct.Data_3_Size < 1 || fPropGct.Data_3_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 3 Size" }));
                }

                FCommon.validateName(fPropGct.Data_4_Prt, false, this.fUIWizard, "Data 4 Prompt");
                if (fPropGct.Data_4_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 4 Prompt" }));
                }
                if (fPropGct.Data_4_Size < 1 || fPropGct.Data_4_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 4 Size" }));
                }

                FCommon.validateName(fPropGct.Data_5_Prt, false, this.fUIWizard, "Data 5 Prompt");
                if (fPropGct.Data_5_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 5 Prompt" }));
                }
                if (fPropGct.Data_5_Size < 1 || fPropGct.Data_5_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 5 Size" }));
                }

                FCommon.validateName(fPropGct.Data_6_Prt, false, this.fUIWizard, "Data 6 Prompt");
                if (fPropGct.Data_6_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 6 Prompt" }));
                }
                if (fPropGct.Data_6_Size < 1 || fPropGct.Data_6_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 6 Size" }));
                }

                FCommon.validateName(fPropGct.Data_7_Prt, false, this.fUIWizard, "Data 7 Prompt");
                if (fPropGct.Data_7_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 7 Prompt" }));
                }
                if (fPropGct.Data_7_Size < 1 || fPropGct.Data_7_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 7 Size" }));
                }

                FCommon.validateName(fPropGct.Data_8_Prt, false, this.fUIWizard, "Data 8 Prompt");
                if (fPropGct.Data_8_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 8 Prompt" }));
                }
                if (fPropGct.Data_8_Size < 1 || fPropGct.Data_8_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 8 Size" }));
                }

                FCommon.validateName(fPropGct.Data_9_Prt, false, this.fUIWizard, "Data 9 Prompt");
                if (fPropGct.Data_9_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 9 Prompt" }));
                }
                if (fPropGct.Data_9_Size < 1 || fPropGct.Data_9_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 9 Size" }));
                }

                FCommon.validateName(fPropGct.Data_10_Prt, false, this.fUIWizard, "Data 10 Prompt");
                if (fPropGct.Data_10_Prt.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 10 Prompt" }));
                }
                if (fPropGct.Data_10_Size < 1 || fPropGct.Data_10_Size > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0024", new object[] { "Data 10 Size" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetGcmTableUpdate_In.E_ADMADS_SetGcmTableUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hLanguage, FADMADS_SetGcmTableUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hFactory, FADMADS_SetGcmTableUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hUserId, FADMADS_SetGcmTableUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hHostIp, FADMADS_SetGcmTableUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hHostName, FADMADS_SetGcmTableUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hStep, FADMADS_SetGcmTableUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInGct = fXmlNodeIn.set_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.E_GcmTable);
                fXmlNodeInGct.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.A_Table, FADMADS_SetGcmTableUpdate_In.FGcmTable.D_Table, fPropGct.Table);
                fXmlNodeInGct.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.A_Description, FADMADS_SetGcmTableUpdate_In.FGcmTable.D_Description, fPropGct.Description);
                fXmlNodeInGct.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.A_SystemTable, FADMADS_SetGcmTableUpdate_In.FGcmTable.D_Description, fPropGct.SystemTable.ToString());
                // --
                fXmlNodeInGctKey1 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.E_Key);
                fXmlNodeInGctKey1.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.D_Prompt, fPropGct.Key_1_Prt);
                fXmlNodeInGctKey1.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.D_Format, fPropGct.Key_1_Fmt.ToString());
                fXmlNodeInGctKey1.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.D_Size, fPropGct.Key_1_Size.ToString());
                // --
                fXmlNodeInGctKey2 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.E_Key);
                fXmlNodeInGctKey2.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.D_Prompt, fPropGct.Key_2_Prt);
                fXmlNodeInGctKey2.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.D_Format, fPropGct.Key_2_Fmt.ToString());
                fXmlNodeInGctKey2.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FKey.D_Size, fPropGct.Key_2_Size.ToString());
                // --
                fXmlNodeInGctData1 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData1.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_1_Prt);
                fXmlNodeInGctData1.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_1_Fmt.ToString());
                fXmlNodeInGctData1.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_1_Size.ToString());
                // --
                fXmlNodeInGctData2 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData2.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_2_Prt);
                fXmlNodeInGctData2.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_2_Fmt.ToString());
                fXmlNodeInGctData2.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_2_Size.ToString());
                // --
                fXmlNodeInGctData3 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData3.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_3_Prt);
                fXmlNodeInGctData3.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_3_Fmt.ToString());
                fXmlNodeInGctData3.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_3_Size.ToString());
                // --
                fXmlNodeInGctData4 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData4.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_4_Prt);
                fXmlNodeInGctData4.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_4_Fmt.ToString());
                fXmlNodeInGctData4.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_4_Size.ToString());
                // --
                fXmlNodeInGctData5 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData5.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_5_Prt);
                fXmlNodeInGctData5.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_5_Fmt.ToString());
                fXmlNodeInGctData5.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_5_Size.ToString());
                // --
                fXmlNodeInGctData6 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData6.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_6_Prt);
                fXmlNodeInGctData6.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_6_Fmt.ToString());
                fXmlNodeInGctData6.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_6_Size.ToString());
                // --
                fXmlNodeInGctData7 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData7.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_7_Prt);
                fXmlNodeInGctData7.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_7_Fmt.ToString());
                fXmlNodeInGctData7.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_7_Size.ToString());
                // --
                fXmlNodeInGctData8 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData8.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_8_Prt);
                fXmlNodeInGctData8.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_8_Fmt.ToString());
                fXmlNodeInGctData8.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_8_Size.ToString());
                // --
                fXmlNodeInGctData9 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData9.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_9_Prt);
                fXmlNodeInGctData9.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_9_Fmt.ToString());
                fXmlNodeInGctData9.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_9_Size.ToString());
                // --
                fXmlNodeInGctData10 = fXmlNodeInGct.add_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.E_Data);
                fXmlNodeInGctData10.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Prompt, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Prompt, fPropGct.Data_10_Prt);
                fXmlNodeInGctData10.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Format, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Format, fPropGct.Data_10_Fmt.ToString());
                fXmlNodeInGctData10.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.A_Size, FADMADS_SetGcmTableUpdate_In.FGcmTable.FData.D_Size, fPropGct.Data_10_Size.ToString());

                // --

                FADMADSCaster.ADMADS_SetGcmTableUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetGcmTableUpdate_Out.A_hStatus, FADMADS_SetGcmTableUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetGcmTableUpdate_Out.A_hStatusMessage, FADMADS_SetGcmTableUpdate_Out.D_hStatusMessage)
                        );
                }

                // --

                cellValues = new object[] {
                    fPropGct.Table,
                    fPropGct.Description,
                    fPropGct.SystemTable.ToString()
                    };
                // --
                key = fPropGct.Table;
                grdTable.appendOrUpdateDataRow(key, cellValues);
                grdTable.activateDataRow(key);

                // --

                refreshTableTotal();

                // --

                // ***
                // Active된 GCM Table을 수정할 경우 RowActivate Event가 발생되지 않음.
                // 변경된 정보를 GCM Data에 반영하기 위해 수행.
                // ***
                if (grdTable.activeDataRowKey == key)
                {
                    refreshGeneralCodeTable();
                    // --
                    designGridOfGeneralCodeData();
                    initPropOfGeneralCodeData();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropGct = null;
                fXmlNodeIn = null;
                fXmlNodeInGct = null;
                fXmlNodeInGctKey1 = null;
                fXmlNodeInGctKey2 = null;
                fXmlNodeInGctData1 = null;
                fXmlNodeInGctData2 = null;
                fXmlNodeInGctData3 = null;
                fXmlNodeInGctData4 = null;
                fXmlNodeInGctData5 = null;
                fXmlNodeInGctData6 = null;
                fXmlNodeInGctData7 = null;
                fXmlNodeInGctData8 = null;
                fXmlNodeInGctData9 = null;
                fXmlNodeInGctData10 = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfGeneralCodeData(
            )
        {
            FPropGeneralCodeData fPropGcd = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInGcd = null;
            FXmlNode fXmlNodeInKey = null;
            FXmlNode fXmlNodeInDat = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropGcd = (FPropGeneralCodeData)pgdData.selectedObject;

                // --

                #region Validation

                validateData(fPropGcd.Key_1, true, m_generalCodeTableKey[0], m_generalCodeTableKey[0].prt);
                validateData(fPropGcd.Key_2, m_generalCodeTableKey[1].prt != string.Empty ? true : false, m_generalCodeTableKey[1], m_generalCodeTableKey[1].prt);

                // --

                validateData(fPropGcd.Data_1, false, m_generalCodeTableData[0], m_generalCodeTableData[0].prt);
                validateData(fPropGcd.Data_2, false, m_generalCodeTableData[1], m_generalCodeTableData[1].prt);
                validateData(fPropGcd.Data_3, false, m_generalCodeTableData[2], m_generalCodeTableData[2].prt);
                validateData(fPropGcd.Data_4, false, m_generalCodeTableData[3], m_generalCodeTableData[3].prt);
                validateData(fPropGcd.Data_5, false, m_generalCodeTableData[4], m_generalCodeTableData[4].prt);
                validateData(fPropGcd.Data_6, false, m_generalCodeTableData[5], m_generalCodeTableData[5].prt);
                validateData(fPropGcd.Data_7, false, m_generalCodeTableData[6], m_generalCodeTableData[6].prt);
                validateData(fPropGcd.Data_8, false, m_generalCodeTableData[7], m_generalCodeTableData[7].prt);
                validateData(fPropGcd.Data_9, false, m_generalCodeTableData[8], m_generalCodeTableData[8].prt);
                validateData(fPropGcd.Data_10, false, m_generalCodeTableData[9], m_generalCodeTableData[9].prt);

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetGcmDataUpdate_In.E_ADMADS_SetGcmDataUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hLanguage, FADMADS_SetGcmDataUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hFactory, FADMADS_SetGcmDataUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hUserId, FADMADS_SetGcmDataUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hHostIp, FADMADS_SetGcmDataUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hHostName, FADMADS_SetGcmDataUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hStep, FADMADS_SetGcmDataUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInGcd = fXmlNodeIn.set_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.E_GcmData);
                fXmlNodeInGcd.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.A_Table, FADMADS_SetGcmDataUpdate_In.FGcmData.D_Table, grdTable.activeDataRowKey);

                // --

                fXmlNodeInKey = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.E_Key);
                fXmlNodeInKey.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.D_Value, fPropGcd.Key_1);
                fXmlNodeInKey = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.E_Key);
                fXmlNodeInKey.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.D_Value, fPropGcd.Key_2);
                // --
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_1);
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_2);
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_3);
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_4);
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_5);
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_6);
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_7);
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_8);
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_9);
                fXmlNodeInDat = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.E_Data);
                fXmlNodeInDat.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FData.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FData.D_Value, fPropGcd.Data_10);

                // --

                FADMADSCaster.ADMADS_SetGcmDataUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetGcmDataUpdate_Out.A_hStatus, FADMADS_SetGcmDataUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetGcmDataUpdate_Out.A_hStatusMessage)
                        );
                }

                // --

                cellValues = new object[] {
                    grdTable.activeDataRowKey, // Table
                    fPropGcd.Key_1,          
                    fPropGcd.Key_2,   
                    fPropGcd.Data_1,  
                    fPropGcd.Data_2,  
                    fPropGcd.Data_3,  
                    fPropGcd.Data_4,  
                    fPropGcd.Data_5,  
                    fPropGcd.Data_6,  
                    fPropGcd.Data_7,  
                    fPropGcd.Data_8,  
                    fPropGcd.Data_9,  
                    fPropGcd.Data_10
                    };
                // --
                key = fPropGcd.Key_1 + KEY_SEPARATOR + fPropGcd.Key_2;
                grdData.appendOrUpdateDataRow(key, cellValues);
                grdData.activateDataRow(key);

                // --

                refreshDataTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropGcd = null;
                fXmlNodeIn = null;
                fXmlNodeInGcd = null;
                fXmlNodeInKey = null;
                fXmlNodeInDat = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfGeneralCodeTable(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInGct = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected General Code Table" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdTable.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetGcmTableUpdate_In.E_ADMADS_SetGcmTableUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hLanguage, FADMADS_SetGcmTableUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hFactory, FADMADS_SetGcmTableUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hUserId, FADMADS_SetGcmTableUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hHostIp, FADMADS_SetGcmTableUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hHostName, FADMADS_SetGcmTableUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmTableUpdate_In.A_hStep, FADMADS_SetGcmTableUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInGct = fXmlNodeIn.set_elem(FADMADS_SetGcmTableUpdate_In.FGcmTable.E_GcmTable);

                // --

                foreach (UltraDataRow dr in grdTable.selectedDataRows)
                {
                    fXmlNodeInGct.set_elemVal(FADMADS_SetGcmTableUpdate_In.FGcmTable.A_Table, FADMADS_SetGcmTableUpdate_In.FGcmTable.D_Table, dr["Table"].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetGcmTableUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetFactoryUpdate_Out.A_hStatus, FADMADS_SetFactoryUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetFactoryUpdate_Out.A_hStatusMessage, FADMADS_SetFactoryUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdTable.removeDataRow(dr.Index);
                }

                // --

                grdTable.endUpdate();

                // --

                if (grdTable.Rows.Count == 0)
                {
                    initPropOfGeneralCodeTable();
                    // --
                    refreshGeneralCodeTable();
                    designGridOfGeneralCodeData();
                    initPropOfGeneralCodeData();
                }

                // --

                refreshTableTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdTable.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInGct = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfGeneralCodeData(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInGcd = null;
            FXmlNode fXmlNodeInKey = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected General Code Data" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdData.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetGcmDataUpdate_In.E_ADMADS_SetGcmDataUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hLanguage, FADMADS_SetGcmDataUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hFactory, FADMADS_SetGcmDataUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hUserId, FADMADS_SetGcmDataUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hHostIp, FADMADS_SetGcmDataUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hHostName, FADMADS_SetGcmDataUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetGcmDataUpdate_In.A_hStep, FADMADS_SetGcmDataUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInGcd = fXmlNodeIn.set_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.E_GcmData);

                // --

                foreach (UltraDataRow dr in grdData.selectedDataRows)
                {
                    fXmlNodeInGcd.removeAll();
                    fXmlNodeInGcd.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.A_Table, FADMADS_SetGcmDataUpdate_In.FGcmData.D_Table, grdTable.activeDataRowKey);
                    // --
                    fXmlNodeInKey = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.E_Key);
                    fXmlNodeInKey.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.D_Value, dr[1].ToString());
                    // --
                    fXmlNodeInKey = fXmlNodeInGcd.add_elem(FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.E_Key);
                    fXmlNodeInKey.set_elemVal(FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.A_Value, FADMADS_SetGcmDataUpdate_In.FGcmData.FKey.D_Value, dr[2].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetGcmDataUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetGcmDataUpdate_Out.A_hStatus, FADMADS_SetGcmDataUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetGcmDataUpdate_Out.A_hStatusMessage, FADMADS_SetGcmDataUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdData.removeDataRow(dr.Index);
                }

                // --

                grdData.endUpdate();

                // --

                if (grdData.Rows.Count == 0)
                {
                    initPropOfGeneralCodeData();
                }

                // --

                refreshDataTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdData.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInGcd = null;
                fXmlNodeInKey = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshTableTotal(
            )
        {
            try
            {
                lblTableTotal.Text = grdTable.Rows.Count.ToString("#,##0");
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

        private void refreshDataTotal(
            )
        {
            try
            {
                lblDataTotal.Text = grdData.Rows.Count.ToString("#,##0");
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

        #region FGeneralCode Form Event Handler

        private void FGeneralCode_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.GeneralCode);

                // --

                designGridOfGeneralCodeTable();

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

        private void FGeneralCode_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfGeneralCodeTable(string.Empty);

                // --

                grdTable.Focus();
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

        private void FGeneralCode_FormClosing(
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

        //------------------------------------------------------------------------------------------------------------------------

        private void FGeneralCode_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    if (tabMain.ActiveTab.Key == "General Code Table")
                    {
                        refreshGridOfGeneralCodeTable(grdTable.activeDataRowKey);
                    }
                    else
                    {
                        refreshGridOfGeneralCodeData(grdData.activeDataRowKey);
                    }
                    // --
                    FCursor.defaultCursor();
                }
            }
            catch (Exception ex)
            {
                FCursor.defaultCursor();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                
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

                // --

                if (e.Tab.Key == "General Code Table")
                {
                    grdTable.Focus();
                }
                else
                {
                    grdData.Focus();
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

        #region grdTable Control Event Handler

        private void grdTable_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfGeneralCodeTable();
                
                // --

                refreshGridOfGeneralCodeData(string.Empty);
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

        private void grdTable_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.Tabs[1].Selected = true;
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

        private void grdTable_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfGeneralCodeTable();
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

        #region grdData Control Event Handler

        private void grdData_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfGeneralCodeData();

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

        //------------------------------------------------------------------------------------------------------------------------

        private void grdData_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfGeneralCodeData();
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

                if (key == "General Code Table")
                {
                    updateGridOfGeneralCodeTable();
                }
                else if (key == "General Code Data")
                {
                    updateGridOfGeneralCodeData();
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

                if (key == "General Code Table")
                {
                    initPropOfGeneralCodeTable();
                }
                else if (key == "General Code Data")
                {
                    initPropOfGeneralCodeData();
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

        #region btnDelete Control Event Handler

        private void btnDelete_Click(
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

                if (key == "General Code Table")
                {
                    deleteGridOfGeneralCodeTable();
                }
                else if (key == "General Code Data")
                {
                    deleteGridOfGeneralCodeData();
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

        #region rstTable Control Event Handler

        private void rstTable_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfGeneralCodeTable(grdTable.activeDataRowKey);
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

        private void rstTable_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdTable.searchGridRow(e.searchWord))
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

        #region rstData Control Event Handler

        private void rstData_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfGeneralCodeData(grdData.activeDataRowKey);
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

        private void rstData_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdData.searchGridRow(e.searchWord))
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

    }   // Class end
}   // Namespace end
