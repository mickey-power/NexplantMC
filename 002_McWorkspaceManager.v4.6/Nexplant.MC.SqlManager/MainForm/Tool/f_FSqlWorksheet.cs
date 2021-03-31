/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSqlWorksheet.cs
--  Creator         : mjkim
--  Create Date     : 2011.11.14
--  Description     : FAMate SQL Worksheet Form Class
--  History         : Created by mjkim at 2011.11.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinTabControl;
using Infragistics.Win.UltraWinToolbars;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.SqlManager
{
    public partial class FSqlWorksheet : Nexplant.MC.Core.FaUIs.FBaseTabChildForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;
        private string m_system = string.Empty;
        private string m_module = string.Empty;
        private string m_function = string.Empty;
        private string m_uniqueIdToString = string.Empty;
        private string m_sqlCode = string.Empty;
        private string m_description = string.Empty;
        private string m_usedMigration = string.Empty;
        private string m_msSqlQuery = string.Empty;
        private string m_oracleQuery = string.Empty;
        private string m_mySqlQuery = string.Empty;
        private string m_mariaDbQuery = string.Empty;
        private string m_postgreSqlQuery = string.Empty;
        private bool m_isModifiedFile = false;
        private Dictionary<string, FSqlParameter> m_parameters = null;
        private FIDPointer64 m_fIdPointer = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSqlWorksheet(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqlWorksheet(
            FSqmCore fSsmCore
            )
            :this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSqmCore = fSsmCore;
            m_fIdPointer = new FIDPointer64();
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
                    if (m_fIdPointer != null)
                    {
                        m_fIdPointer.Dispose();
                        m_fIdPointer = null;
                    }
                    // --
                    m_fSqmCore = null;
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

        private void setTitle(
            )
        {
            string sqlCode = string.Empty;
            
            try
            {
                this.Text = m_fSqmCore.fWsmCore.fUIWizard.searchCaption("SQL Worksheet");
                
                // --

                if (!m_sqlCode.Equals(string.Empty))
                {
                    sqlCode = string.Join(" / ", new string[] { m_system, m_module, m_function, m_sqlCode });
                    // --
                    if (m_isModifiedFile)
                    {
                        txtSqlCode.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                        txtSqlCode.Text = sqlCode + "*";
                    }
                    else
                    {
                        txtSqlCode.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                        txtSqlCode.Text = sqlCode;
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
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
                base.fUIWizard.changeControlFontName(mnuMenu);
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

        private bool procMenuChangeFontName(
            )
        {
            bool isValidFontName = true;
            string preFontName = string.Empty;

            try
            {
                preFontName = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                // -- 
                txtQuery.Appearance.FontData.Name = (new System.Drawing.FontFamily(preFontName)).Name;
                m_fSqmCore.fOption.fontName = preFontName;
            }
            catch (Exception)
            {
                isValidFontName = false;
            }
            finally
            {
 
            }
            return isValidFontName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuChangeFontSize(
            )
        {
            try
            {
                txtQuery.Appearance.FontData.SizeInPoints = float.Parse(mskFontSize.Value.ToString());
                m_fSqmCore.fOption.fontSize = float.Parse(mskFontSize.Value.ToString());
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

        private void controlMenu(
            )
        {
            try
            {
                mnuMenu.beginUpdate();

                // --

                mnuMenu.Tools[FMenuKey.MenuSqwRefresh].SharedProps.Enabled = (m_system != string.Empty ? true : false);
                mnuMenu.Tools[FMenuKey.MenuSqwSave].SharedProps.Enabled = (m_system != string.Empty ? true : false);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                mnuMenu.endUpdate();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designComboOfDatabase(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbDatabase.dataSource;
                // --
                uds.Band.Columns.Add("Database");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Provider");
                uds.Band.Columns.Add("Connect String");
                uds.Band.Columns.Add("Timeout (ms)");

                // --

                ucbDatabase.Appearance.Image = Properties.Resources.SqlCode;
                // --
                ucbDatabase.DisplayLayout.Bands[0].Columns["Database"].CellAppearance.Image = Properties.Resources.SqlCode;
                ucbDatabase.DisplayLayout.Bands[0].Columns["Database"].Width = 120;
                ucbDatabase.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                ucbDatabase.DisplayLayout.Bands[0].Columns["Connect String"].Width = 560;
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

        private void refreshComboOfDatabase(
            )
        {
            object[] cellValues = null;
            string key = string.Empty;
            int index = -1;

            try
            {
                ucbDatabase.beginUpdate(false);

                // --

                ucbDatabase.removeAllDataRow();
                ucbDatabase.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                foreach (FDatabaseOption source in m_fSqmCore.fOption.databaseOptionList)
                {
                    key = source.database;
                    cellValues = new object[] 
                    {
                        source.database,
                        source.databaseDescription,
                        source.fDatabaseProvider,
                        source.databaseConnectString,
                        source.databaseTimeout
                    };
                    // --
                    key = source.database;
                    index = ucbDatabase.appendDataRow(key, cellValues).Index;

                    // --

                    //ucbDatabase.Rows.GetRowWithListIndex(index).Cells["Database"].Appearance.Image = getImageOfDatabase(source.fDatabaseProvider.ToString());
                }

                // --

                ucbDatabase.endUpdate(false);

                // --

                ucbDatabase.DisplayLayout.Bands[0].SortedColumns.Add("Database", false);
                if (ucbDatabase.Rows.Count > 0)
                {
                    ucbDatabase.activateDataRow(m_fSqmCore.fOption.database);
                    if (ucbDatabase.ActiveRow == null)
                    {
                        ucbDatabase.ActiveRow = ucbDatabase.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ucbDatabase.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void saveSqlCodeQuery(
            )
        {
            string dbProvider = string.Empty;

            try
            {
                dbProvider = (string)ucbDatabase.activeDataRow["Provider"];
                
                // --

                if (dbProvider == FDbProvider.MsSqlServer.ToString())
                {
                    m_msSqlQuery = txtQuery.Text;
                }
                else if (dbProvider == FDbProvider.Oracle.ToString())
                {
                    m_oracleQuery = txtQuery.Text;
                }
                else if (dbProvider == FDbProvider.OracleEx.ToString())
                {
                    m_oracleQuery = txtQuery.Text;
                }
                else if (dbProvider == FDbProvider.MySql.ToString())
                {
                    m_mySqlQuery = txtQuery.Text;
                }
                else if (dbProvider == FDbProvider.MariaDb.ToString())
                {
                    m_mariaDbQuery = txtQuery.Text;
                }
                else if (dbProvider == FDbProvider.PostgreSql.ToString())
                {
                    m_postgreSqlQuery = txtQuery.Text;
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

        private void refreshSqlCodeQuery(
            )
        {
            string dbProvider = string.Empty;
            try
            {
                dbProvider = (string)ucbDatabase.activeDataRow["Provider"];

                // --

                if (dbProvider == FDbProvider.MsSqlServer.ToString())
                {
                    txtQuery.Text = m_msSqlQuery;
                }
                else if (dbProvider == FDbProvider.Oracle.ToString())
                {
                    txtQuery.Text = m_oracleQuery;
                }
                else if (dbProvider == FDbProvider.OracleEx.ToString())
                {
                    txtQuery.Text = m_oracleQuery;
                }
                else if (dbProvider == FDbProvider.MySql.ToString())
                {
                    txtQuery.Text = m_mySqlQuery;
                }
                else if (dbProvider == FDbProvider.MariaDb.ToString())
                {
                    txtQuery.Text = m_mariaDbQuery;
                }
                else if (dbProvider == FDbProvider.PostgreSql.ToString())
                {
                    txtQuery.Text = m_postgreSqlQuery;
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

        private void saveSqlCodeParameter(
            ref Dictionary<string, FSqlParameter> fSqlParameters
            )
        {
            try
            {
                m_parameters = fSqlParameters;
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

        private void refreshTextOfResult(
            string text
            )
        {

            UltraTab ultraTab = null;

            try
            {
                txtMessage.AppendText(Environment.NewLine);
                txtMessage.AppendText(text);
                txtMessage.AppendText(Environment.NewLine);
                txtMessage.Select(txtMessage.TextLength, 0);
                txtMessage.ScrollToCaret();

                // --

                ultraTab = tabResult.Tabs["Message"];
                ultraTab.VisibleIndex = 0;
                ultraTab.Visible = true;
                ultraTab.Selected = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                ultraTab = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfResult(
            DataTable dt
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSql = null;
            UltraTab ultraTab = null;
            UInt64 uniqueId = 0;
            string key = string.Empty;
            string oldValue = string.Empty;
            string newValue = string.Empty;
            string query = string.Empty;

            try
            {
                uniqueId = m_fIdPointer.uniqueId;
                key = string.Format("Result {0}", uniqueId == 0 ? "" : uniqueId.ToString());

                // --

                fXmlNodeIn = FDataConvert.stringToXmlNode((string)dt.ExtendedProperties["fXmlNodeIn"]);
                fXmlNodeInSql = fXmlNodeIn.get_elem(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.E_SqlCode);
                query = fXmlNodeInSql.get_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Query, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.D_Query);
                foreach (FXmlNode n in fXmlNodeInSql.get_elemList(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.E_Parameter))
                {
                    oldValue = string.Format(
                        "{0}{1}",
                        (FDbProvider)Enum.Parse(typeof(FDbProvider), fXmlNodeInSql.get_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_DbProvider, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.D_DbProvider)) == FDbProvider.MsSqlServer ? "@" : ":",
                        n.get_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.A_Parameter, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.D_Parameter)
                        );

                    newValue = (FBoolean)Enum.Parse(typeof(FBoolean), n.get_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.A_Nullable, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.D_Nullable)) == FBoolean.True ? 
                        "NULL" :
                        "'" + n.get_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.A_Value, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.D_Value) + "'";

                    query = query.Replace(oldValue, newValue);
                }

                ultraTab = tabResult.Tabs.Add(key, key);
                ultraTab.Tag = dt;
                ultraTab.ToolTipText = string.Format("{0} :\n{1}", ucbDatabase.Text, query);
                ultraTab.Selected = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSql = null;
                ultraTab = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectQuery(
            ToolBase tool,
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInSqc = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;
            DataTable dt = null;
            DataTable dtCol = null;
            string query = string.Empty;
            string statusMessage = string.Empty;
            int nextRowNumber = 0;
            int i = 0;

            try
            {
                dt = new DataTable();
                dt.ExtendedProperties.Add("fXmlNodeIn", fXmlNodeIn.outerXml);

                fXmlNodeInSqc = fXmlNodeIn.get_elem(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.E_SqlCode);
                query = fXmlNodeInSqc.get_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Query, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.D_Query);
                i = 0;

                do
                {
                    fXmlNodeInSqc.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_NextRowNumber, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.D_NextRowNumber, nextRowNumber.ToString());

                    // --

                    FSQMSQSCaster.SQMSQS_TolSqlCodeExecute_Req(
                        m_fSqmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FSQMSQS_TolSqlCodeExecute_Out.A_hStatus, FSQMSQS_TolSqlCodeExecute_Out.D_hStatus) != "0")
                    {
                        statusMessage = fXmlNodeOut.get_elemVal(FSQMSQS_TolSqlCodeExecute_Out.A_hStatusMessage, FSQMSQS_TolSqlCodeExecute_Out.D_hStatusMessage);
                        refreshTextOfResult(
                            fUIWizard.generateMessage("E0016", new object[] { query, statusMessage })
                            );
                        return;
                    }

                    // --

                    fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_TolSqlCodeExecute_Out.FTable.E_Table);
                    // --
                    dtCol = FDbWizard.stringToDataTable(
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_TolSqlCodeExecute_Out.FTable.A_Columns, FSQMSQS_TolSqlCodeExecute_Out.FTable.D_Columns),
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_TolSqlCodeExecute_Out.FTable.A_Rows, FSQMSQS_TolSqlCodeExecute_Out.FTable.D_Rows)
                        );
                    if (i++ == 0)
                    {
                        foreach(DataColumn c in dtCol.Columns)
                        {
                            dt.Columns.Add(c.ColumnName);
                        }
                    }
                    object[] cellValues = null;
                    foreach (DataRow r in dtCol.Rows)
                    {
                        cellValues = new object[dtCol.Columns.Count];
                        for(int j = 0; j < dtCol.Columns.Count; j++)
                        {
                            cellValues[j] = r[j];
                        }
                        dt.Rows.Add(cellValues);
                    }
                    // --

                    nextRowNumber = int.Parse(
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_TolSqlCodeExecute_Out.FTable.A_NextRowNumber, FSQMSQS_TolSqlCodeExecute_Out.FTable.D_NextRowNumber)
                        );
                } while (nextRowNumber >= 0);

                // --

                if (tool.Key == FMenuKey.MenuSqwExecuteSql)
                {
                    refreshGridOfResult(dt);
                }
                else if (tool.Key == FMenuKey.MenuSqwRefresh)
                {
                    tabResult.SelectedTab.Tag = dt;
                    tabResult_SelectedTabChanged (null, new SelectedTabChangedEventArgs(tabResult.SelectedTab, null));
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeInSqc = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectQuery(
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                selectQuery(mnuMenu.Tools[FMenuKey.MenuSqwExecuteSql], fXmlNodeIn);
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

        private void transactionQuery(
            FXmlNode fXmlNodeIn
            )
        {
            FXmlNode fXmlNodeInSqc = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;
            string sql = string.Empty;
            string resultMessage = string.Empty;
            int rowCount = 0;

            try
            {
                fXmlNodeInSqc = fXmlNodeIn.get_elem(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.E_SqlCode);
                sql = fXmlNodeInSqc.get_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Query, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.D_Query);

                // --

                fXmlNodeInSqc.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_NextRowNumber, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.D_NextRowNumber, "0");

                // --

                FSQMSQSCaster.SQMSQS_TolSqlCodeExecute_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );

                if (fXmlNodeOut.get_elemVal(FSQMSQS_TolSqlCodeExecute_Out.A_hStatus, FSQMSQS_TolSqlCodeExecute_Out.D_hStatus) != "0")
                {
                    resultMessage = fUIWizard.generateMessage(
                        "E0016",
                        new object[] { sql, fXmlNodeOut.get_elemVal(FSQMSQS_TolSqlCodeExecute_Out.A_hStatusMessage, FSQMSQS_TolSqlCodeExecute_Out.D_hStatusMessage) }
                        );
                }
                else 
                {
                    fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_TolSqlCodeExecute_Out.FTable.E_Table);
                    rowCount = int.Parse(fXmlNodeOutTbl.get_elemVal(FSQMSQS_TolSqlCodeExecute_Out.FTable.A_RowCount, FSQMSQS_TolSqlCodeExecute_Out.FTable.D_RowCount));

                    sql = sql.ToLower();
                    if (sql.IndexOf("insert") == 0)
                    {
                        resultMessage = fUIWizard.generateMessage("M0001", new object[] { rowCount });
                    }
                    else if (sql.IndexOf("update") == 0)
                    {
                        resultMessage = fUIWizard.generateMessage("M0002", new object[] { rowCount });
                    }
                    else if (sql.IndexOf("delete") == 0)
                    {
                        resultMessage = fUIWizard.generateMessage("M0003", new object[] { rowCount });
                    }
                }

                // --

                refreshTextOfResult(resultMessage);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeInSqc = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FDmlType getDmlType(
            string sql
            )
        {
            string[] lineSpearator = { Environment.NewLine };

            try
            {
                foreach (string s in sql.ToLower().Split(lineSpearator, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (s.IndexOf("select") == 0)
                    {
                        return FDmlType.Select;
                    }
                    else if (s.IndexOf("insert") == 0)
                    { 
                        return FDmlType.Insert;
                    }
                    else if (s.IndexOf("update") == 0)
                    {
                        return FDmlType.Update;
                    }
                    else if (s.IndexOf("delete") == 0)
                    {
                        return FDmlType.Delete;
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
            return FDmlType.Unknown;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void executeSqlCodeQuery(
            string sql,
            ref Dictionary<string, FSqlParameter> fSqlParameters
            )
        {
            FProgress fProgress = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSql = null;
            FXmlNode fXmlNodeInPar = null;
            FDmlType fDmlType = FDmlType.Unknown;

            try
            {
                fProgress = new FProgress();
                fProgress.show(m_fSqmCore.fWsmCore.fWsmContainer);

                // --

                spcMain.Panel2Collapsed = false;
                fDmlType = getDmlType(sql);

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_TolSqlCodeExecute_In.E_SQMSQS_TolSqlCodeExecute_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.A_hLanguage, FSQMSQS_TolSqlCodeExecute_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.A_hStep, FSQMSQS_TolSqlCodeExecute_In.D_hStep, fDmlType == FDmlType.Select ? "1" : "2");
                
                // --

                fXmlNodeInSql = fXmlNodeIn.set_elem(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.E_SqlCode);
                fXmlNodeInSql.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_System, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Query, m_system);
                fXmlNodeInSql.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Module, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Query, m_module);
                fXmlNodeInSql.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Function, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Query, m_function);
                fXmlNodeInSql.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_SqlCode, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Query, m_sqlCode);
                fXmlNodeInSql.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Query, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Query, sql);
                fXmlNodeInSql.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_DbProvider, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_DbProvider, m_fSqmCore.fOption.databaseProvider.ToString());
                fXmlNodeInSql.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_ConnectString, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_ConnectString, m_fSqmCore.fOption.databaseDecodingConnectString);
                fXmlNodeInSql.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Timeout, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.A_Timeout, m_fSqmCore.fOption.databaseTimeout.ToString());
                
                // --

                foreach (FSqlParameter f in fSqlParameters.Values)
                {
                    fXmlNodeInPar = fXmlNodeInSql.add_elem(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.E_Parameter);
                    fXmlNodeInPar.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.A_Parameter, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.D_Parameter, f.parameter);
                    fXmlNodeInPar.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.A_Nullable, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.D_Nullable, f.nullable.ToString());
                    fXmlNodeInPar.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.A_Value, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.D_Value, (string)f.value);
                    fXmlNodeInPar.set_elemVal(FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.A_Type, FSQMSQS_TolSqlCodeExecute_In.FSqlCode.FParameter.D_Type, f.type == FType.text ? typeof(string).ToString() : typeof(int).ToString());
                }

                // --

                if (fDmlType == FDmlType.Select)
                {
                    selectQuery(fXmlNodeIn);
                }
                else
                {
                    transactionQuery(fXmlNodeIn);
                }
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                // --

                FDebug.throwException(ex);
            }
            finally
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                // --

                fXmlNodeIn = null;
                fXmlNodeInSql = null;
                fXmlNodeInPar = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sqlRefactoring(
            string s
            )
        {
            string[] lineSeparator = { Environment.NewLine };
            string[] selectedText = null;
            string finalText = string.Empty;
            int selectionStart = 0;
            int selectionLength = 0;
            int caretPosition = 0;

            try
            {
                foreach (string originalText in txtQuery.Text.Split(lineSeparator, StringSplitOptions.None))
                {
                    if (txtQuery.SelectionLength == 0)
                    {
                        if (
                            txtQuery.SelectionStart >= caretPosition &&
                            txtQuery.SelectionStart < caretPosition + originalText.Length + 1
                           )
                        {
                            finalText += s;
                            selectionStart = caretPosition;
                            selectionLength = originalText.Length + s.Length;
                        }
                    }
                    else
                    {
                        selectedText = txtQuery.SelectedText.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < selectedText.Length; i++)
                        {
                            if (originalText.IndexOf(selectedText[i]) > -1)
                            {
                                finalText += s;
                                if (i == 0)
                                {
                                    selectionStart = caretPosition;
                                }
                                selectionLength += (originalText.Length + Environment.NewLine.Length) + s.Length;
                                break;
                            }
                        }
                    }
                    finalText += originalText;
                    finalText += Environment.NewLine;
                    caretPosition += originalText.Length + Environment.NewLine.Length;
                }

                txtQuery.Text = finalText.TrimEnd();
                txtQuery.Select(selectionStart, selectionLength);
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

        private void sqlRefactoringRemove(
            string s
            )
        {
            string[] lineSeparator = { Environment.NewLine };
            string[] selectedText = null;
            string finalText = string.Empty;
            int selectionStart = 0;
            int selectionLength = 0;
            int caretPosition = 0;
            bool notApplied = false;

            try
            {
                foreach (string originalText in txtQuery.Text.Split(lineSeparator, StringSplitOptions.None))
                {
                    if (txtQuery.SelectionLength == 0)
                    {
                        if (
                            txtQuery.SelectionStart >= caretPosition &&
                            txtQuery.SelectionStart < caretPosition + originalText.Length + 1
                           )
                        {
                            if (originalText.IndexOf(s) > -1)
                            {
                                finalText += originalText.Substring(s.Length);
                                selectionLength = originalText.Length - s.Length;
                            }
                            else
                            {
                                finalText += originalText;
                                selectionLength = originalText.Length;

                            }
                            selectionStart = caretPosition;
                        }
                        else
                        {
                            finalText += originalText;
                        }
                    }
                    else
                    {
                        notApplied = true;
                        selectedText = txtQuery.SelectedText.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < selectedText.Length; i++)
                        {
                            if (originalText.IndexOf(selectedText[i]) > -1)
                            {
                                notApplied = false;
                                if (originalText.IndexOf(s) > -1)
                                {
                                    finalText += originalText.Substring(s.Length);
                                    selectionLength += (originalText.Length + Environment.NewLine.Length) - s.Length;
                                }
                                else
                                {
                                    finalText += originalText;
                                    selectionLength += (originalText.Length + Environment.NewLine.Length);
                                }
                                if (i == 0)
                                {
                                    selectionStart = caretPosition;
                                }
                                break;
                            }
                        }
                        if (notApplied == true)
                        {
                            finalText += originalText;
                        }
                    }
                    finalText += Environment.NewLine;
                    caretPosition += originalText.Length + Environment.NewLine.Length;
                }

                txtQuery.Text = finalText.TrimEnd();
                txtQuery.Select(selectionStart, selectionLength);
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

        public void procMenuRefresh(
            )
        {
            DataTable dt = null;

            try
            {
                dt = FCommon.getSqlCodeInfo(m_fSqmCore, m_system, m_uniqueIdToString, m_sqlCode);

                // --

                m_description = (string)dt.Rows[0][2];
                m_usedMigration = (string)dt.Rows[0][3];
                m_msSqlQuery = (string)dt.Rows[0][4];
                m_oracleQuery = (string)dt.Rows[0][6];
                m_mySqlQuery = (string)dt.Rows[0][8];
                m_mariaDbQuery = (string)dt.Rows[0][10];
                m_postgreSqlQuery = (string)dt.Rows[0][12];

                // --

                refreshSqlCodeQuery();
                
                // --

                m_isModifiedFile = false;

                // --

                setTitle();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSave(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSqc = null;
            FXmlNode fXmlNodeInSqy = null;
            FXmlNode fXmlNodeInSqp = null;
            FXmlNode fXmlNodeOut = null;
            string dbProvider = string.Empty;

            try
            {
                dbProvider = (string)ucbDatabase.activeDataRow["Provider"];

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSqlCodeUpdate_In.E_SQMSQS_SetSqlCodeUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.A_hLanguage, FSQMSQS_SetSqlCodeUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.A_hStep, FSQMSQS_SetSqlCodeUpdate_In.D_hStep, "1");
                
                // --

                fXmlNodeInSqc = fXmlNodeIn.set_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.E_SqlCode);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_System, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_System, m_system);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Module, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Module, m_module);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Function, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Function, m_function);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_UniqueId, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_UniqueId, m_uniqueIdToString);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_SqlCode, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_SqlCode, m_sqlCode);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_UsedMigration, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_UsedMigration, m_usedMigration);
                
                // --
                
                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.MsSqlServer.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, 
                    dbProvider == FDbProvider.MsSqlServer.ToString() ? txtQuery.Text : m_msSqlQuery
                    );
                // --
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MsSqlServer.ToString(), fXmlNodeInSqy.get_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query)).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }
                
                // --
                
                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.Oracle.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query,
                    dbProvider == FDbProvider.Oracle.ToString() || dbProvider == FDbProvider.OracleEx.ToString() ? txtQuery.Text : m_oracleQuery
                    );
                // --
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.Oracle.ToString(), fXmlNodeInSqy.get_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query)).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }

                // --

                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.MySql.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query,
                    dbProvider == FDbProvider.MySql.ToString() ? txtQuery.Text : m_mySqlQuery
                    );
                // --
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MySql.ToString(), fXmlNodeInSqy.get_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query)).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }

                // --

                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.MariaDb.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query,
                    dbProvider == FDbProvider.MariaDb.ToString() ? txtQuery.Text : m_mariaDbQuery
                    );
                // --
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MySql.ToString(), fXmlNodeInSqy.get_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query)).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }

                // --

                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.PostgreSql.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query,
                    dbProvider == FDbProvider.PostgreSql.ToString() ? txtQuery.Text : m_postgreSqlQuery
                    );
                // --
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.PostgreSql.ToString(), fXmlNodeInSqy.get_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query)).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }

                // --

                FSQMSQSCaster.SQMSQS_SetSqlCodeUpdate_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSqlCodeUpdate_Out.A_hStatus, FSQMSQS_SetSqlCodeUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSqlCodeUpdate_Out.A_hStatusMessage, FSQMSQS_SetSqlCodeUpdate_Out.D_hStatusMessage));
                }
                
                // --

                m_isModifiedFile = false;

                // --

                setTitle();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSqc = null;
                fXmlNodeInSqy = null;
                fXmlNodeInSqp = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuExecuteSql(
            )
        {
            Dictionary<string, FSqlParameter> fSqlParameters = null;
            FParameterBinder fBinder = null;
            string[] lineSeparator = { Environment.NewLine };
            char[] charsToTrim = { ' ', '\r', '\n' };
            string[] split = null;
            string sqls = string.Empty;
            string sqlType = string.Empty;
            string sql = string.Empty;
            int sqlIndex = -1;

            try
            {
                if (ucbDatabase.activeDataRow == null)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0025", new object[] { "Database Provider" }));
                }

                // --

                sqls = txtQuery.SelectedText;
                if (sqls == string.Empty)
                {
                    sqls = txtQuery.Text;
                }

                split = sqls.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < split.Length; i++)
                {
                    sqlIndex = split[i].IndexOf(';');
                    if (
                        (split[i].IndexOf(FConstants.SqlCommentChars) > -1 || sqlIndex <= -1) &&
                        (i != split.Length - 1)
                       )
                    {
                        sql += split[i];
                        sql += Environment.NewLine;
                        continue;                    
                    }

                    // ---
                    
                    sql += split[i].Substring(0, sqlIndex > -1 ? sqlIndex : split[i].Length);
                    sql = sql.Trim(charsToTrim);

                    // ---

                    fSqlParameters = FCommon.parseSqlParameter(m_fSqmCore.fOption.databaseProvider.ToString(), sql);
                    // --
                    foreach (FSqlParameter f in m_parameters.Values)
                    {
                        if (fSqlParameters.ContainsKey(f.parameter))
                        {
                            fSqlParameters[f.parameter].nullable = f.nullable;
                            fSqlParameters[f.parameter].type = f.type;
                            fSqlParameters[f.parameter].value = f.value;
                        }
                    }
                    
                    if (fSqlParameters.Count > 0)
                    {
                        fBinder = new FParameterBinder(m_fSqmCore, fSqlParameters);
                        if (fBinder.ShowDialog() != DialogResult.OK)
                        {
                            sql = split[i].Substring(sqlIndex + 1);
                            continue;
                        }
                    }

                    saveSqlCodeParameter(ref fSqlParameters);
                    executeSqlCodeQuery(sql, ref fSqlParameters);

                    // --

                    sql = split[i].Substring(sqlIndex + 1);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fBinder != null)
                {
                    fBinder.Dispose();
                    fBinder = null;
                }
                fSqlParameters = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuToUpperLowerInitCap(
            )
        {
            string[] lineSeparator = { Environment.NewLine };
            string[] words = null;
            char[] wordSeparator = { ' ' };
            char[] charsToTrim = { '\r', '\n' };
            string finalText = string.Empty;
            int selectionStart = 0;
            int selectionLength = 0;
            int caretPosition = 0;
            int i = 0;

            try
            {
                if(txtQuery.SelectionLength == 0)
                {
                    return;
                }

                selectionStart = txtQuery.SelectionStart;
                selectionLength = txtQuery.SelectedText.TrimEnd(charsToTrim).Length;
                foreach (string line in txtQuery.Text.Split(lineSeparator, StringSplitOptions.None))
                {
                    words = line.Split(wordSeparator);
                    for(i = 0; i < words.Length; i++) 
                    {
                        if (
                            selectionStart <= caretPosition &&
                            selectionStart + selectionLength >= caretPosition + words[i].Length
                           )
                        {
                            if (words[i] == words[i].ToUpper())
                            {
                                finalText += words[i].ToLower();
                            }
                            else if (words[i] == words[i].ToLower())
                            {
                                finalText += words[i].ToUpperInvariant();
                            }
                            else if (words[i] == words[i].ToUpperInvariant())
                            {
                                finalText += words[i].ToUpper();
                            }
                            else
                            {
                                finalText += words[i];
                            }
                        }
                        else
                        {
                            finalText += words[i];
                        }
                        caretPosition += words[i].Length;
                        if (i < words.Length - 1)
                        {
                            finalText += wordSeparator[0].ToString();
                            caretPosition += wordSeparator[0].ToString().Length;
                        }
                    }
                    finalText += Environment.NewLine;
                    caretPosition += Environment.NewLine.Length;
                }

                txtQuery.Text = finalText.TrimEnd();
                txtQuery.Select(selectionStart, selectionLength);
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

        private void procMenuClear(
            )
        {
            try
            {
                txtQuery.Text = string.Empty;

                // --

                m_isModifiedFile = true;

                // --

                setTitle();
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

        private void procMenuComment(
            )
        {
            try
            {
                sqlRefactoring(FConstants.SqlCommentChars);
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

        private void procMenuCommentRemove(
            )
        {
            try
            {
                sqlRefactoringRemove(FConstants.SqlCommentChars);
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

        private void procMenuIndent(
            )
        {
            try
            {
                sqlRefactoring(FConstants.SqlIndentChars);
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

        private void procMenuIndentRemove(
            )
        {
            string[] lineSeparator = { Environment.NewLine };
            string[] selectedText = null;
            string finalText = string.Empty;
            int selectionStart = 0;
            int selectionLength = 0;
            int caretPosition = 0;
            bool notApplied = false;

            try
            {
                foreach (string originalText in txtQuery.Text.Split(lineSeparator, StringSplitOptions.None))
                {
                    if (txtQuery.SelectionLength == 0)
                    {
                        if (
                            txtQuery.SelectionStart >= caretPosition &&
                            txtQuery.SelectionStart < caretPosition + originalText.Length + 1
                           )
                        {
                            if (originalText.IndexOf(FConstants.SqlIndentChars) > -1)
                            {
                                finalText += originalText.Substring(FConstants.SqlIndentChars.Length);
                                selectionLength = originalText.Length - FConstants.SqlIndentChars.Length;
                            }
                            else
                            {
                                finalText += originalText.TrimStart();
                                selectionLength = finalText.Length;

                            }
                            selectionStart = caretPosition;
                        }
                        else
                        {
                            finalText += originalText;
                        }
                    }
                    else
                    {
                        notApplied = true;
                        selectedText = txtQuery.SelectedText.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries);
                        for (int i = 0; i < selectedText.Length; i++)
                        {
                            if (originalText.IndexOf(selectedText[i]) > -1)
                            {
                                notApplied = false;
                                if (originalText.IndexOf(FConstants.SqlIndentChars) > -1)
                                {
                                    finalText += originalText.Substring(FConstants.SqlIndentChars.Length);
                                    selectionLength += (originalText.Length + Environment.NewLine.Length) - FConstants.SqlIndentChars.Length;
                                }
                                else
                                {
                                    finalText += originalText.TrimStart();
                                    selectionLength += (originalText.TrimStart().Length + Environment.NewLine.Length);
                                }
                                if (i == 0)
                                {
                                    selectionStart = caretPosition;
                                }
                                break;
                            }
                        }
                        if (notApplied == true)
                        {
                            finalText += originalText;
                        }
                    }
                    finalText += Environment.NewLine;
                    caretPosition += originalText.Length + Environment.NewLine.Length;
                }

                txtQuery.Text = finalText.TrimEnd();
                txtQuery.Select(selectionStart, selectionLength);
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

        private void procMenuClose(
            )
        {
            UltraTab selectedTab = null;

            try
            {
                selectedTab = tabResult.SelectedTab;

                if (selectedTab == null)
                {
                    return;
                }

                selectedTab.Close();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                selectedTab = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuResultClear(
            )
        {
            try
            {
                txtMessage.Text = string.Empty;
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

        private void procMenuResultRefresh(
            ToolBase tool
            )
        {
            FXmlNode fXmlNodeIn = null;
            DataTable dt = null;

            try
            {
                dt = (DataTable)tabResult.SelectedTab.Tag;
                fXmlNodeIn = FDataConvert.stringToXmlNode((string)dt.ExtendedProperties["fXmlNodeIn"]);
                selectQuery(tool, fXmlNodeIn);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void appendSqlCode(
            string system,
            string module,
            string function,
            string uniqueIdToString,
            string sqlCode
            )
        {
            try
            {
                m_system = system;
                m_module = module;
                m_function = function;
                m_uniqueIdToString = uniqueIdToString;
                m_sqlCode = sqlCode;

                // --

                procMenuRefresh();
                controlMenu();
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

        #region FSqlWorksheet Form Event Handler

        private void FSqlWorksheet_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_parameters = new Dictionary<string, FSqlParameter>();
                designComboOfDatabase();
                refreshComboOfDatabase();

                // -- 

                ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Text = m_fSqmCore.fOption.fontName;
                mskFontSize.Value = m_fSqmCore.fOption.fontSize;

                // --

                txtQuery.Appearance.FontData.Name = ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value.ToString();
                txtQuery.Appearance.FontData.SizeInPoints = float.Parse(mskFontSize.Value.ToString());

                // --

                m_fSqmCore.fOption.fChildList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSqlWorksheet_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                txtQuery.Focus();
            }
            catch (Exception ex)
            {   
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
             
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void FSqlWorksheet_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSqmCore.fOption.fChildList.remove(this);

                // --

                m_parameters = null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
       
        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender,
            ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuSqwRefresh)
                {
                    procMenuRefresh();
                }
                if (e.Tool.Key == FMenuKey.MenuSqwSave)
                {
                    procMenuSave();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwExecuteSql)
                {
                    procMenuExecuteSql();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwClear)
                {
                    procMenuClear();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwToUpperLowerInitCap)
                {
                    procMenuToUpperLowerInitCap();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwComment)
                {
                    procMenuComment();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwCommentRemove)
                {
                    procMenuCommentRemove();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwIndent)
                {
                    procMenuIndent();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwIndentRemove)
                {
                    procMenuIndentRemove();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_FontNameChange(
            object sender, 
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuFontName)
                {
                    procMenuChangeFontName();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mnuMenu_AfterToolDeactivate(
            object sender,
            ToolEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuFontName)
                {
                    if (!procMenuChangeFontName())
                    {
                        ((FontListTool)mnuMenu.Tools[FMenuKey.MenuFontName]).Value = m_fSqmCore.fOption.fontName;
                        txtQuery.Appearance.FontData.Name = m_fSqmCore.fOption.fontName;
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region mnuResult Control Event Handler

        private void mnuResult_ToolClick(
            object sender, 
            ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuSqwClose)
                {
                    procMenuClose();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwClear)
                {
                    procMenuResultClear();
                }
                else if (e.Tool.Key == FMenuKey.MenuSqwRefresh)
                {
                    procMenuResultRefresh(e.Tool);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region mskFontSize Control Event Handler

        private void mskFontSize_EditorSpinButtonClick(
            object sender, 
            Infragistics.Win.UltraWinEditors.SpinButtonClickEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(mskFontSize.Value.ToString());
                if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.NextItem)
                {
                    mskFontSize.Value = fontSize < FConstants.FontMaxSize ? (int)++fontSize : FConstants.FontMaxSize;
                }
                else if (e.ButtonType == Infragistics.Win.UltraWinEditors.SpinButtonItem.PreviousItem)
                {
                    mskFontSize.Value = fontSize > FConstants.FontMinSize ? (int)--fontSize : FConstants.FontMinSize;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mskFontSize_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuChangeFontSize();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mskFontSize_BeforeExitEditMode(
            object sender,
            Infragistics.Win.BeforeExitEditModeEventArgs e
            )
        {
            float fontSize = 0;

            try
            {
                FCursor.waitCursor();

                // --

                fontSize = float.Parse(mskFontSize.Value.ToString());
                if (fontSize < FConstants.FontMinSize)
                {
                    mskFontSize.Value = FConstants.FontMinSize;
                }
                else if (fontSize > FConstants.FontMaxSize)
                {
                    mskFontSize.Value = FConstants.FontMaxSize;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void mskFontSize_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.KeyCode == Keys.Enter)
                {
                    txtQuery.Focus();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region txtQuery Control Event Handler

        private void txtQuery_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!m_isModifiedFile)
                {
                    m_isModifiedFile = true;
                    // --
                    setTitle();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region ucbDatabase Control Event Handler

        private void ucbDatabase_BeforeDropDown(
            object sender,
            CancelEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfDatabase();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void ucbDatabase_EditorButtonClick(
            object sender, 
            Infragistics.Win.UltraWinEditors.EditorButtonEventArgs e
            )
        {
            FOptionDialog fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FOptionDialog(m_fSqmCore, FOptionTab.Database);
                if (fDialog.ShowDialog(this) == DialogResult.OK)
                {
                    m_fSqmCore.fOption.save();
                }

                // -- 

                refreshComboOfDatabase();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void ucbDatabase_TextChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fSqmCore.fOption == null)
                {
                    return;
                }

                // --

                foreach (FDatabaseOption source in m_fSqmCore.fOption.databaseOptionList)
                {
                    if (ucbDatabase.activeDataRowKey != source.database)
                    {
                        continue;
                    }

                    // --

                    m_fSqmCore.fOption.database = source.database;
                    m_fSqmCore.fOption.databaseDescription = source.databaseDescription;
                    m_fSqmCore.fOption.databaseProvider = source.fDatabaseProvider;
                    m_fSqmCore.fOption.databaseConnectString = source.databaseConnectString;
                    m_fSqmCore.fOption.databasePassword = source.databasePassword;
                    m_fSqmCore.fOption.databaseTimeout = source.databaseTimeout;
                    m_fSqmCore.fOption.databaseDecodingConnectString = string.Format(source.databaseConnectString, source.databasePassword);
                    // --
                    break;
                }

                // --

                refreshSqlCodeQuery();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region tabResult Control Event Handler

        private void tabResult_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            Infragistics.Win.UIElement element = null;
            UltraTab selectedTab = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right)
                {
                    return;
                }

                element = tabResult.UIElement.ElementFromPoint(e.Location);
                if (element == null)
                {
                    return;
                }

                selectedTab = (UltraTab)element.GetContext(typeof(UltraTab));
                if (selectedTab == null)
                {
                    return;
                }

                tabResult.SelectedTab = selectedTab;
                mnuResult.ShowPopup(FMenuKey.MenuPopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tabResult_SelectedTabChanged(
            object sender, 
            SelectedTabChangedEventArgs e
            )
        {
            DataTable dt = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tab == null)
                {
                    return;
                }

                // --

                dt = (DataTable)e.Tab.Tag;

                // --

                mnuResult.Tools[FMenuKey.MenuSqwRefresh].SharedProps.Visible = (e.Tab.Key == "Message" ? false : true);
                mnuResult.Tools[FMenuKey.MenuSqwClear].SharedProps.Visible = (e.Tab.Key == "Message" ? true : false);
                mnuResult.Tools[FMenuKey.MenuSqwTotalCount].SharedProps.Caption = (dt != null ? string.Format("Total Count : {0}", dt.Rows.Count) : string.Empty);
                
                // --

                grdList.DataSource = dt != null ? dt : null;
                grdList.DataBind();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                dt = null;

                // --

                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void tabResult_TabClosed(
            object sender, 
            TabClosedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tab.Key.Equals("Message"))
                {
                    procMenuResultClear();
                }

                if (tabResult.Tabs.VisibleTabsCount == 0)
                {
                    spcMain.Panel2Collapsed = true;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
