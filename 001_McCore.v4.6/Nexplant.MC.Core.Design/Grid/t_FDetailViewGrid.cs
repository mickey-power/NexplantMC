/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FDetailViewGrid.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.12
--  Description     : FAMate Core FaUIs Detail View Grid Control
--  History         : Created by spike.lee at 2011.01.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FDetailViewGrid : UltraGrid
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private Dictionary<string, int> m_rows = null;
        private Dictionary<string, int> m_cols = null;
        private bool m_valueCopyOfClickedCell = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDetailViewGrid(
            )
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public bool valueCopyOfClickedCell
        {
            get
            {
                try
                {
                    return m_valueCopyOfClickedCell;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_valueCopyOfClickedCell = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public UltraDataSource dataSource
        {
            get
            {
                try
                {
                    if (this.DataSource == null)
                    {
                        return null;
                    }
                    return (UltraDataSource)this.DataSource;
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

        private void init(
            )
        {
            try
            {
                m_rows = new Dictionary<string, int>();
                m_cols = new Dictionary<string, int>();

                // --

                this.HandleCreated += new EventHandler(FDetailViewGrid_HandleCreated);
                this.ClickCell += new ClickCellEventHandler(FDetailViewGrid_ClickCell);
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

        private void term(
            )
        {
            try
            {
                this.HandleCreated -= new EventHandler(FDetailViewGrid_HandleCreated);
                this.ClickCell -= new ClickCellEventHandler(FDetailViewGrid_ClickCell);
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

        public void beginUpdate(
            )
        {
            try
            {
                if (!this.IsUpdating)
                {
                    this.BeginUpdate();
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

        public void endUpdate(
            )
        {
            try
            {
                if (this.IsUpdating)
                {
                    this.EndUpdate();
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

        public void addColumns(
            int columnCountInOneRow, 
            string[] columns
            )
        {
            UltraDataSource uds = null;
            string columnKey = string.Empty;
            string valueKey = string.Empty;
            int rowCount = 0;
            int rowNo = 0;
            int colNo = 0;

            try
            {
                clearColumn();

                // --

                uds = this.dataSource;

                // --

                // ***
                // Colmun 생성
                // ***
                for (int i = 0; i < columnCountInOneRow; i++)
                {
                    columnKey = "Column" + i.ToString();
                    valueKey = "Value" + i.ToString();

                    // --

                    uds.Band.Columns.Add(columnKey);
                    uds.Band.Columns.Add(valueKey);

                    // --

                    this.DisplayLayout.Bands[0].Columns[columnKey].CellActivation = Activation.Disabled;
                    this.DisplayLayout.Bands[0].Columns[columnKey].CellAppearance = FGridCommon.getHeaderAppearance();
                }

                // --

                // ***
                // Row 생성
                // ***
                rowCount = (columns.Length / columnCountInOneRow) + (columns.Length % columnCountInOneRow > 0 ? 1 : 0);
                for (int i = 0; i < rowCount; i++)
                {
                    this.Rows[uds.Rows.Add().Index].Height = 24;
                }

                // ---

                // ***
                // Detail Grid의 Column과 Value란을 설정한다.
                // (Row를 Column과 Value로 사용)
                // ***
                for (int i = 0; i < columns.Length; i++)
                {
                    rowNo = i / columnCountInOneRow;
                    colNo = (i % columnCountInOneRow) * 2;
                    // --                    
                    uds.Rows[rowNo][colNo] = columns[i];
                    uds.Rows[rowNo][colNo + 1] = string.Empty;
                    // --
                    m_rows.Add(columns[i], rowNo);
                    m_cols.Add(columns[i], colNo);                    
                }

                // --

                this.ActiveCell = this.Rows[0].Cells[1];
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

        public void addColumns(
            int columnCountInOneRow,
            string[] columns,
            bool checkBox
            )
        {
            UltraDataSource uds = null;
            string columnKey = string.Empty;
            string valueKey = string.Empty;
            int rowCount = 0;
            int rowNo = 0;
            int colNo = 0;

            try
            {
                clearColumn();

                // --

                uds = this.dataSource;

                // --

                // ***
                // Colmun 생성
                // ***
                for (int i = 0; i < columnCountInOneRow; i++)
                {
                    columnKey = "Column" + i.ToString();
                    valueKey = "Value" + i.ToString();

                    // --

                    uds.Band.Columns.Add(columnKey);
                    uds.Band.Columns.Add(valueKey, typeof(bool));

                    // --

                    this.DisplayLayout.Bands[0].Columns[columnKey].CellActivation = Activation.Disabled;
                    this.DisplayLayout.Bands[0].Columns[columnKey].CellAppearance = FGridCommon.getHeaderAppearance();
                }

                // --

                // ***
                // Row 생성
                // ***
                rowCount = (columns.Length / columnCountInOneRow) + (columns.Length % columnCountInOneRow > 0 ? 1 : 0);
                for (int i = 0; i < rowCount; i++)
                {
                    this.Rows[uds.Rows.Add().Index].Height = 24;
                }

                // ---

                // ***
                // Detail Grid의 Column과 Value란을 설정한다.
                // (Row를 Column과 Value로 사용)
                // ***
                for (int i = 0; i < columns.Length; i++)
                {
                    rowNo = i / columnCountInOneRow;
                    colNo = (i % columnCountInOneRow) * 2;
                    // --                    
                    uds.Rows[rowNo][colNo] = columns[i];
                    uds.Rows[rowNo][colNo + 1] = true;
                    // --
                    m_rows.Add(columns[i], rowNo);
                    m_cols.Add(columns[i], colNo);
                }

                // --

                this.ActiveCell = this.Rows[0].Cells[1];
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

        public void clearColumn(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = this.dataSource;
                // --
                uds.Rows.Clear();
                uds.Band.Columns.Clear();
                // --
                m_rows.Clear();
                m_cols.Clear();
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

        public void clearColumnValue(
            )
        {
            UltraDataSource uds = null;
            UltraGridCell cell = null;

            try
            {
                uds = this.dataSource;
                // --
                for (int i = 0; i < uds.Rows.Count; i++)
                {
                    for (int j = 1; j < uds.Band.Columns.Count; j+=2)
                    {
                        uds.Rows[i][j] = string.Empty;                        
                        // --
                        cell = this.Rows[i].Cells[j];
                        cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.False;
                        cell.Appearance.ForeColor = Color.Black;
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                uds = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public object getColumnValue(
            string key
            )
        {
            try
            {
                return this.dataSource.Rows[m_rows[key]][m_cols[key] + 1];
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

        //------------------------------------------------------------------------------------------------------------------------

        public void setColumnValue(
            string key, 
            object value
            )
        {
            try
            {
                this.dataSource.Rows[m_rows[key]][m_cols[key] + 1] = value;
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

        public void setColumnValues(
            object[] cellValues
            )
        {
            UltraDataSource uds = null;
            int index = 0;

            try
            {
                uds = this.dataSource;

                // --

                for (int i = 0; i < uds.Rows.Count; i++)
                {
                    for (int j = 1; j < uds.Band.Columns.Count; j+=2)
                    {
                        if (index >= cellValues.Length)
                        {
                            return;
                        }
                        uds.Rows[i][j] = cellValues[index++];                        
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

        public int getColumnHeaderWidth(
            )
        {
            try
            {
                return this.DisplayLayout.Bands[0].Columns[0].Width;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setColumnHeaderWidth(
            int width
            )
        {
            UltraGridColumn col = null;

            try
            {
                for (int i = 0; i < this.DisplayLayout.Bands[0].Columns.Count; i+=2)
                {
                    col = this.DisplayLayout.Bands[0].Columns[i];
                    // --
                    col.Width = width;
                    col.MaxWidth = width;
                    col.MinWidth = width;
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

        public int getColumnWidth(
            string key
            )
        {
            try
            {
                return this.DisplayLayout.Bands[0].Columns[m_cols[key] + 1].Width;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setColumnWidth(
            string key, 
            int width
            )
        {
            UltraGridColumn col = null;

            try
            {
                col = this.DisplayLayout.Bands[0].Columns[m_cols[key] + 1];
                col.Width = width;
                col.MaxWidth = width;
                col.MinWidth = width;
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

        public HAlign getColumnHAlign(
            string key
            )
        {
            try
            {
                return this.Rows[m_rows[key]].Cells[m_cols[key] + 1].Appearance.TextHAlign;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return HAlign.Default;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void setColumnHAlign(
            string key, 
            HAlign halign
            )
        {
            try
            {
                this.Rows[m_rows[key]].Cells[m_cols[key] + 1].Appearance.TextHAlign = halign;
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

        public UltraGridCell getColumn(
            string key
            )
        {
            try
            {
                return this.Rows[m_rows[key]].Cells[m_cols[key] + 1];
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FDetailViewGrid Control Event Handler

        private void FDetailViewGrid_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FDetailViewGrid", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FDetailViewGrid_ClickCell(
            object sender, 
            ClickCellEventArgs e
            )
        {
            try
            {
                if (m_valueCopyOfClickedCell && e.Cell.Value != null && e.Cell.Value is string && (string)e.Cell.Value != string.Empty)
                {
                    FClipboard.setText((string)e.Cell.Value);
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FDetailViewGrid", ex, null);
            }
            finally
            {

            }
        }   

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
