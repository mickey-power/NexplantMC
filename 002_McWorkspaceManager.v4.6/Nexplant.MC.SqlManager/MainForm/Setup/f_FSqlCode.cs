/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSqlCode.cs
--  Creator         : mj.kim
--  Create Date     : 2011.10.12
--  Description     : FAMate SQL Manager Setup Sql Code Form Class 
--  History         : Created by mj.kim at 2011.10.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.SqlManager
{
    public partial class FSqlCode : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSqlCode(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqlCode(
            FSqmCore fSqmCore
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
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
            try
            {
                this.Text = m_fSqmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        private void designComboOfSystem(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbSystem.dataSource;

                // --

                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");

                // --

                ucbSystem.Appearance.Image = Properties.Resources.System;

                // --

                ucbSystem.DisplayLayout.Bands[0].Columns["Name"].CellAppearance.Image = Properties.Resources.System;
                // --
                ucbSystem.DisplayLayout.Bands[0].Columns["Name"].Width = 120;
                ucbSystem.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designComboOfModule(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbModule.dataSource;

                // --

                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");

                // --

                ucbModule.Appearance.Image = Properties.Resources.Module;

                // --

                ucbModule.DisplayLayout.Bands[0].Columns["Name"].CellAppearance.Image = Properties.Resources.Module;
                // --
                ucbModule.DisplayLayout.Bands[0].Columns["Name"].Width = 120;
                ucbModule.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designComboOfFunction(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbFunction.dataSource;

                // --

                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");

                // --

                ucbFunction.Appearance.Image = Properties.Resources.Function;

                // --

                ucbFunction.DisplayLayout.Bands[0].Columns["Name"].CellAppearance.Image = Properties.Resources.Function;
                // --
                ucbFunction.DisplayLayout.Bands[0].Columns["Name"].Width = 120;
                ucbFunction.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfSqlCode(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("SQL Code");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Migration");
                
                // --

                grdList.DisplayLayout.Bands[0].Columns["SQL Code"].CellAppearance.Image = Properties.Resources.SqlCode;
                // --
                grdList.DisplayLayout.Bands[0].Columns["SQL Code"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["SQL Code"].Width = 200;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdList.DisplayLayout.Bands[0].Columns["Migration"].Width = 200;
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

        private void refreshComboOfSystem(
            )
        {
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (ucbSystem.activeDataRow != null)
                {
                    beforeKey = ucbSystem.activeDataRowKey;
                }

                // --

                ucbSystem.beginUpdate();
                ucbSystem.removeAllDataRow();

                // --

                do
                {
                    dt = FCommon.requestSystemList(m_fSqmCore, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[1],   // System
                            r[2]    // Description
                        };
                        key = (string)cellValues[0];
                        ucbSystem.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                ucbSystem.endUpdate();

                // --

                ucbSystem.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);
                // --
                if (ucbSystem.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        ucbSystem.activateDataRow(beforeKey);
                    }
                    // --
                    if (ucbSystem.activeDataRow == null)
                    {
                        ucbSystem.ActiveRow = ucbSystem.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ucbSystem.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshComboOfModule(
            )
        {
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (ucbSystem.activeDataRow == null)
                {
                    ucbModule.removeAllDataRow();
                    return;
                }
                if (ucbModule.activeDataRow != null)
                {
                    beforeKey = ucbModule.activeDataRowKey;
                }

                // --

                ucbModule.beginUpdate();
                ucbModule.removeAllDataRow();

                // --

                do
                {
                    dt = FCommon.requestModuleList(m_fSqmCore, ucbSystem.Text, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[1],   // Module
                            r[2]    // Description
                        };
                        key = (string)cellValues[0];
                        ucbModule.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                ucbModule.endUpdate();

                // --

                ucbModule.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);
                // --
                if (ucbModule.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        ucbModule.activateDataRow(beforeKey);
                    }
                    // --
                    if (ucbModule.activeDataRow == null)
                    {
                        ucbModule.ActiveRow = ucbModule.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ucbModule.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshComboOfFunction(
            )
        {
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (ucbModule.activeDataRow == null)
                {
                    ucbFunction.removeAllDataRow();
                    return;
                }
                if (ucbFunction.activeDataRow != null)
                {
                    beforeKey = ucbFunction.activeDataRowKey;
                }

                // --

                ucbFunction.beginUpdate();
                ucbFunction.removeAllDataRow();

                // --

                do
                {
                    dt = FCommon.requestFunctionList(m_fSqmCore, ucbSystem.Text, ucbModule.Text, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[1],   // Function
                            r[2]    // Description
                        };
                        key = (string)cellValues[0];
                        ucbFunction.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                ucbFunction.endUpdate();

                // --

                ucbFunction.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);
                // --
                if (ucbFunction.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        ucbFunction.activateDataRow(beforeKey);
                    }
                    // --
                    if (ucbFunction.activeDataRow == null)
                    {
                        ucbFunction.ActiveRow = ucbFunction.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ucbFunction.endUpdate(); 
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfSqlCode(
            )
        {
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (ucbFunction.activeDataRow == null)
                {
                    grdList.removeAllDataRow();
                    return;
                }
                if (grdList.activeDataRow != null)
                {
                    beforeKey = grdList.activeDataRowKey;
                }

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();

                // --

                do
                {
                    dt = FCommon.requestSqlCodeList(m_fSqmCore, ucbSystem.activeDataRowKey, ucbModule.activeDataRowKey, ucbFunction.activeDataRowKey, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[1], // SQL Code
                            r[2], // Description
                            r[3]  // UsedMigration
                        };
                        key = r[0].ToString();
                        grdList.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate();

                // --
                grdList.DisplayLayout.Bands[0].SortedColumns.Add("SQL Code", false);
                // --
                if (grdList.Rows.Count == 0)
                {
                    initPropOfSqlCode();
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (beforeKey != string.Empty)
                    {
                        grdList.activateDataRow(beforeKey);
                    }
                    // --
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfSqlCode(
            )
        {
            try
            {
                pgdProp.selectedObject = (new FPropSqlCode(m_fSqmCore, pgdProp, ucbSystem.Text, ucbModule.Text, ucbFunction.Text));
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

        private void setPropOfSqlCode(
            )
        {
            DataTable dt = null;
            string uniqueIdToString = string.Empty;

            try
            {
                if (grdList.activeDataRow == null)
                {
                    return;
                }
                uniqueIdToString = grdList.activeDataRowKey;
                
                // --

                dt = FCommon.getSqlCodeInfo(m_fSqmCore, ucbSystem.activeDataRowKey, uniqueIdToString, (string)grdList.activeDataRow["SQL Code"]);

                // --

                pgdProp.selectedObject = new FPropSqlCode(m_fSqmCore, pgdProp, ucbSystem.Text, ucbModule.Text, ucbFunction.Text, dt);
                btnDelete.Enabled = true;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSqlCode Form Event Handler

        private void FSqlCode_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designComboOfSystem();
                designComboOfModule();
                designComboOfFunction();
                designGridOfSqlCode();

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

        private void FSqlCode_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfSystem();

                // --

                setTitle();

                // --

                ucbSystem.Focus();
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

        private void FSqlCode_FormClosing(
            object sender,
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSqmCore.fOption.fChildList.remove(this);
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

        #region ucbSystem Control Event Handler

        private void ucbSystem_BeforeDropDown(
            object sender,
            CancelEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfSystem();
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

        private void ucbSystem_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfModule();
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

        #region ucbModule Control Event Handler

        private void ucbModule_BeforeDropDown(
            object sender,
            CancelEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfModule();
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

        private void ucbModule_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfFunction();
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

        #region ucbFunction Control Event Handler

        private void ucbFunction_BeforeDropDown(
            object sender,
            CancelEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfFunction();
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

        private void ucbFunction_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfSqlCode();
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

        #region grdList Control Event Handler

        private void grdList_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfSqlCode();
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

        private void grdList_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfSqlCode();
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

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
            object sender,
            EventArgs e
            )
        {
            FPropSqlCode fPropSqlCode = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSqc = null;
            FXmlNode fXmlNodeInSqy = null;
            FXmlNode fXmlNodeInSqp = null;
            FXmlNode fXmlNodeOut = null;
            object[] cellValues = null;
            string key = string.Empty;
            string update_Paramater = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                fPropSqlCode = (FPropSqlCode)pgdProp.selectedObject;

                // -- 

                #region Validation

                FCommon.validateName(fPropSqlCode.System, true, this.fUIWizard);
                FCommon.validateName(fPropSqlCode.Module, true, this.fUIWizard);
                FCommon.validateName(fPropSqlCode.Function, true, this.fUIWizard);
                FCommon.validateName(fPropSqlCode.SqlCode, true, this.fUIWizard);

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSqlCodeUpdate_In.E_SQMSQS_SetSqlCodeUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.A_hLanguage, FSQMSQS_SetSqlCodeUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.A_hStep, FSQMSQS_SetSqlCodeUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInSqc = fXmlNodeIn.set_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.E_SqlCode);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_System, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_System, fPropSqlCode.System);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Module, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Module, fPropSqlCode.Module);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Function, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Function, fPropSqlCode.Function);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_UniqueId, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_UniqueId, fPropSqlCode.ID);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_SqlCode, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_SqlCode, fPropSqlCode.SqlCode);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Description, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Description, fPropSqlCode.Description);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_UsedMigration, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_UsedMigration, fPropSqlCode.UsedMigration.ToString());
                // --
                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.MsSqlServer.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, fPropSqlCode.MsSqlQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MsSqlServer.ToString(), fPropSqlCode.MsSqlQuery).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }
                // --
                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.Oracle.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, fPropSqlCode.OracleQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.Oracle.ToString(), fPropSqlCode.OracleQuery).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }
                // --
                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.MySql.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, fPropSqlCode.MySqlQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MySql.ToString(), fPropSqlCode.MySqlQuery).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }
                // --
                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.MariaDb.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, fPropSqlCode.MariaDbQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.MariaDb.ToString(), fPropSqlCode.MariaDbQuery).Values)
                {
                    fXmlNodeInSqp = fXmlNodeInSqy.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.E_Parameter);
                    fXmlNodeInSqp.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.A_Parameter, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.FParameter.D_Parameter, fSqlParameter.parameter);
                }
                // --
                fXmlNodeInSqy = fXmlNodeInSqc.add_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.E_Query);
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_DbProvider, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_DbProvider, FDbProvider.PostgreSql.ToString());
                fXmlNodeInSqy.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.A_Query, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.FQuery.D_Query, fPropSqlCode.PostgreSqlQuery);
                foreach (FSqlParameter fSqlParameter in FCommon.parseSqlParameter(FDbProvider.PostgreSql.ToString(), fPropSqlCode.PostgreSqlQuery).Values)
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

                cellValues = new object[]
                {
                    fPropSqlCode.SqlCode,
                    fPropSqlCode.Description,
                    fPropSqlCode.UsedMigration.ToString()                    
                };
                // --
                key = fXmlNodeOut.get_elem(FSQMSQS_SetSqlCodeUpdate_Out.FSqlCode.E_SqlCode).
                    get_elemVal(FSQMSQS_SetSqlCodeUpdate_Out.FSqlCode.A_UniqueId, FSQMSQS_SetSqlCodeUpdate_Out.FSqlCode.D_UniqueId);
                grdList.appendOrUpdateDataRow(key, cellValues);
                grdList.activateDataRow(key);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSqc = null;
                fXmlNodeInSqy = null;
                fXmlNodeInSqp = null;
                fXmlNodeOut = null;
                cellValues = null;

                // --

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
            try
            {
                FCursor.waitCursor();

                // --

                initPropOfSqlCode();
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

        #region btnDelete Control Event Handler

        private void btnDelete_Click(
            object sender,
            EventArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSqc = null; 
            FXmlNode fXmlNodeOut = null;
            DialogResult dialogResult;

            try
            {
                FCursor.waitCursor();

                // --

                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected SQL Code" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSqlCodeUpdate_In.E_SQMSQS_SetSqlCodeUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.A_hLanguage, FSQMSQS_SetSqlCodeUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.A_hStep, FSQMSQS_SetSqlCodeUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInSqc = fXmlNodeIn.set_elem(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.E_SqlCode);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_System, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_System, ucbSystem.activeDataRowKey);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Module, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Module, ucbModule.activeDataRowKey);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_Function, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_Function, ucbFunction.activeDataRowKey);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.A_SqlCode, FSQMSQS_SetSqlCodeUpdate_In.FSqlCode.D_SqlCode, (string)row["SQL Code"]);
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

                    grdList.removeDataRow(row.Index);
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfSqlCode();
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSqc = null; 
                fXmlNodeOut = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control Event Handler

        private void rstToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfSqlCode();
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

        private void rstToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdList.searchGridRow(e.searchWord))
                {
                    FMessageBox.showInformation("Search", m_fSqmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
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
