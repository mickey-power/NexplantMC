/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FGeneralCodeDataSelector.cs
--  Creator         : mjkim
--  Create Date     : 2013.12.13
--  Description     : FAMate Admin Manager General Code Data Select Dialog Form Class 
--  History         : Created by mjkim at 2013.12.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.Collections;

namespace Nexplant.MC.AdminManager
{
    public partial class FGeneralCodeDataSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const char KEY_SEPARATOR = (char)0x1F;

        // --

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_tableName = string.Empty;
        private FGeneralCodeColumn[] m_gcmTableKey = null;
        private FGeneralCodeColumn[] m_gcmTableData = null;
        private string m_oldData = string.Empty;
        private string m_selectedData = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FGeneralCodeDataSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FGeneralCodeDataSelector(
            FAdmCore fAdCore,
            string tableName,
            string oldData
            )
            : this()
        {
            base.fUIWizard = fAdCore.fUIWizard;
            m_fAdmCore = fAdCore;
            m_tableName = tableName;
            m_oldData = oldData;
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
                    m_gcmTableKey = null;
                    m_gcmTableData = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string selectedData
        {
            get
            {
                try
                {
                    return m_selectedData;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            try
            {
                this.Text = "GCM[" + m_tableName + "] Selector";
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

        private void designGridOfList(
            )
        {
            UltraDataSource uds = null;
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string columnKey = string.Empty;

            int index = 0;

            try
            {
                m_gcmTableKey = new FGeneralCodeColumn[2];
                for (int i = 0; i < m_gcmTableKey.Length; i++)
                {
                    m_gcmTableKey[i] = new FGeneralCodeColumn(string.Empty, FGeneralCodeFormat.Ascii.ToString(), "30");
                }
                // --
                m_gcmTableData = new FGeneralCodeColumn[10];
                for (int i = 0; i < m_gcmTableData.Length; i++)
                {
                    m_gcmTableData[i] = new FGeneralCodeColumn(string.Empty, FGeneralCodeFormat.Ascii.ToString(), "50");
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("table_name", m_tableName);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "GcmDataSelector", "SearchGcmTable", fSqlParams, true);

                // --

                uds = grdList.dataSource;
                for (int i = 0; i < m_gcmTableKey.Length; i++)
                {
                    m_gcmTableKey[i] = new FGeneralCodeColumn(
                        dt.Rows[0][index++].ToString(),
                        dt.Rows[0][index++].ToString(),
                        dt.Rows[0][index++].ToString()
                        );
                    columnKey = "Key_" + (i + 1).ToString();
                    // --
                    uds.Band.Columns.Add(columnKey);
                    grdList.DisplayLayout.Bands[0].Columns[columnKey].Header.Caption = m_gcmTableKey[i].prt;
                    grdList.DisplayLayout.Bands[0].Columns[columnKey].Header.Fixed = true;
                    grdList.DisplayLayout.Bands[0].Columns[columnKey].Hidden = m_gcmTableKey[i].prt == string.Empty ? true : false;
                    grdList.DisplayLayout.Bands[0].Columns[columnKey].Width = 100;
                }
                grdList.DisplayLayout.Bands[0].Columns[0].CellAppearance.Image = Properties.Resources.GeneralCodeData;

                // --

                for (int i = 0; i < m_gcmTableData.Length; i++)
                {
                    m_gcmTableData[i] = new FGeneralCodeColumn(
                        dt.Rows[0][index++].ToString(),
                        dt.Rows[0][index++].ToString(),
                        dt.Rows[0][index++].ToString()
                        );
                    columnKey = "Data_" + (i + 1).ToString();
                    // --
                    uds.Band.Columns.Add(columnKey);
                    grdList.DisplayLayout.Bands[0].Columns[columnKey].Header.Caption = m_gcmTableData[i].prt;
                    grdList.DisplayLayout.Bands[0].Columns[columnKey].Hidden = m_gcmTableData[i].prt == string.Empty ? true : false;
                    grdList.DisplayLayout.Bands[0].Columns[columnKey].Width = 100;
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

        private void refreshGridOfList(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                btnOk.Enabled = false;

                // --

                grdList.beginUpdate(false);
                grdList.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("table_name", m_tableName);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "GcmDataSelector", "ListGcmData", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
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
                        key = r[0].ToString() + KEY_SEPARATOR + r[1].ToString(); ;
                        grdList.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (m_oldData != string.Empty)
                    {
                        grdList.activateDataRow(m_oldData);
                    }
                    // --
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectData(
            )
        {
            try
            {
                m_selectedData = grdList.activeDataRow[0].ToString();

                // --

                this.DialogResult = DialogResult.OK;
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

        #region FGeneralCodeDataSelector Form Event Handler

        private void FGeneralCodeDataSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                btnReset.Enabled = (m_oldData == string.Empty ? false : true);
                // --
                designGridOfList();

                // --

                setTitle();
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

        private void FGeneralCodeDataSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfList();
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

        private void FGeneralCodeDataSelector_KeyDown(
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
                    refreshGridOfList();
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

                if (grdList.activeDataRow == null)
                {
                    return;
                }

                // --

                btnOk.Enabled = true;
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

        private void grdList_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                selectData();
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

                selectData();
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

        #region btnReset Control Event Handler

        private void btnReset_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                m_selectedData = string.Empty;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control EventHandler

        private void rstToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --     

                refreshGridOfList();
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
