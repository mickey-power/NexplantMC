/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FGrid.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.31
--  Description     : FAMate Core FaUIs Grid Control
--  History         : Created by spike.lee at 2010.12.31
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
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FGrid : UltraGrid
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<string> m_keys = null;
        private Dictionary<string, UltraDataRow> m_dataRows = null;
        private bool m_multiSelected = false;
        private bool m_valueCopyOfClickedCell = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FGrid(
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

        public bool multiSelected
        {
            get
            {
                try
                {
                    return m_multiSelected;
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
                    if (value)
                    {
                        this.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.True;
                        this.DisplayLayout.Override.SelectTypeRow = SelectType.Extended;
                    }
                    else
                    {
                        this.DisplayLayout.Override.SelectedAppearancesEnabled = Infragistics.Win.DefaultableBoolean.False;
                        this.DisplayLayout.Override.SelectTypeRow = SelectType.Single;
                    }
                    // --
                    m_multiSelected = value;
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

        //------------------------------------------------------------------------------------------------------------------------

        public UltraDataRow activeDataRow
        {
            get
            {
                try
                {
                    if (this.Rows.Count == 0 || this.ActiveRow == null)
                    {
                        return null;
                    }
                    return this.dataSource.Rows[this.ActiveRow.ListIndex];                    
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

        //------------------------------------------------------------------------------------------------------------------------       

        public string activeDataRowKey
        {
            get
            {
                try
                {
                    if (this.Rows.Count == 0 || this.ActiveRow == null)
                    {
                        return string.Empty;
                    }
                    return m_keys[this.ActiveRow.ListIndex];
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

        //------------------------------------------------------------------------------------------------------------------------

        public UltraDataRow[] selectedDataRows
        {
            get
            {
                UltraDataRow[] dataRows = null;

                try
                {
                    if (this.ActiveRow != null)
                    {
                        this.ActiveRow.Selected = true;
                    }

                    // --

                    dataRows = new UltraDataRow[this.Selected.Rows.Count];
                    for (int i = 0; i < dataRows.Length; i++)
                    {
                        dataRows[i] = this.dataSource.Rows[this.Selected.Rows[i].ListIndex];
                    }
                    return dataRows;                    
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

        //------------------------------------------------------------------------------------------------------------------------

        public string[] selectedDataRowKeys
        {
            get
            {
                string[] keys = null;

                try
                {
                    if (this.ActiveRow != null)
                    {
                        this.ActiveRow.Selected = true;
                    }

                    // --

                    keys = new string[this.Selected.Rows.Count];
                    for (int i = 0; i < keys.Length; i++)
                    {
                        keys[i] = m_keys[this.Selected.Rows[i].ListIndex];
                    }
                    return keys;
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
                m_keys = new List<string>();
                m_dataRows = new Dictionary<string, UltraDataRow>();

                // --

                this.HandleCreated += new EventHandler(FGrid_HandleCreated);
                this.ClickCell += new ClickCellEventHandler(FGrid_ClickCell);
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
                this.HandleCreated -= new EventHandler(FGrid_HandleCreated);
                this.ClickCell -= new ClickCellEventHandler(FGrid_ClickCell);
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
            bool isSuspendBinding
            )
        {
            try
            {
                if (!this.IsUpdating)
                {
                    this.BeginUpdate();
                    if (isSuspendBinding)
                    {
                        this.dataSource.SuspendBindingNotifications();
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

        public void beginUpdate(
            )
        {
            try
            {
                beginUpdate(true);
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
            bool isSuspendBinding
            )
        {
            try
            {
                if (this.IsUpdating)
                {
                    if (isSuspendBinding)
                    {
                        this.dataSource.ResumeBindingNotifications();
                    }                    
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

        public void endUpdate(
            )
        {
            try
            {
                endUpdate(true);
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

        public bool containsDataRow(
            string key
            )
        {
            try
            {
                return m_dataRows.ContainsKey(key);
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

        //------------------------------------------------------------------------------------------------------------------------

        public UltraDataRow getDataRow(
            string key
            )
        {
            try
            {
                if (m_dataRows.ContainsKey(key))
                {
                    return m_dataRows[key];
                }                
                return null;
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

        public UltraDataRow getDataRow(
            int index
            )
        {
            try
            {
                if (index < 0 || index >= this.dataSource.Rows.Count)
                {
                    return null;
                }
                return this.dataSource.Rows[index];
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

        public int getDataRowIndex(
            string key
            )
        {
            try
            {
                if (m_dataRows.ContainsKey(key))
                {
                    return m_dataRows[key].Index;
                }
                return -1;
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

        public string getDataRowKey(
            int index
            )
        {
            try
            {
                return m_keys[index];
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

        //------------------------------------------------------------------------------------------------------------------------

        public void activateDataRow(
            string key
            )
        {
            try
            {
                if (m_dataRows.ContainsKey(key))
                {
                    this.Selected.Rows.Clear();
                    this.ActiveRow = this.Rows.GetRowWithListIndex(m_dataRows[key].Index);
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

        public void activateDataRow(
            int index
            )
        {
            try
            {
                activateDataRow(m_keys[index]);
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

        public UltraDataRow insertBeforeDataRow(
            int index, 
            string key, 
            object[] cellValues
            )
        {
            UltraDataRow dataRow = null;

            try
            {
                m_keys.Insert(index, key);
                // --
                dataRow = this.dataSource.Rows.Insert(index, cellValues);
                m_dataRows.Add(key, dataRow);
                // --
                return dataRow;
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

        public UltraDataRow insertAfterDataRow(
            int index, 
            string key, 
            object[] cellValues
            )
        {
            UltraDataRow dataRow = null;

            try
            {
                m_keys.Insert(index + 1, key);
                // --
                dataRow = this.dataSource.Rows.Insert(index + 1, cellValues);
                m_dataRows.Add(key, dataRow);
                // --
                return dataRow;
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

        public UltraDataRow appendDataRow(
            string key, 
            object[] cellValues
            )
        {
            UltraDataRow dataRow = null;            

            try
            {
                m_keys.Add(key);   
                // --
                dataRow = this.dataSource.Rows.Add(cellValues);                
                m_dataRows.Add(key, dataRow);
                // --
                return dataRow;
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

        public UltraDataRow updateDataRow(
            string key, 
            object[] cellValues
            )
        {
            UltraDataRow dataRow = null;

            try
            {
                dataRow = m_dataRows[key];
                // --
                for (int i = 0; i < cellValues.Length; i++)
                {
                    dataRow.SetCellValue(i, cellValues[i]);
                }    
                // --
                return dataRow;
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

        public UltraDataRow appendOrUpdateDataRow(
            string key, 
            object[] cellValues
            )
        {
            try
            {
                if (m_dataRows.ContainsKey(key))
                {
                    return updateDataRow(key, cellValues);
                }
                else
                {
                    return appendDataRow(key, cellValues);
                }
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

        //public UltraDataRow removeDataRow(
        //    string key
        //    )
        //{
        //    UltraDataRow dataRow = null;
        //    UltraGridRow gridRow = null;
        //    int index = -1;

        //    try
        //    {
        //        dataRow = m_dataRows[key];
        //        gridRow = this.Rows.GetRowWithListIndex(dataRow.Index);

        //        // --                

        //        index = gridRow.Index;                
        //        if (index == this.Rows.Count - 1)
        //        {
        //            index--;
        //        }                

        //        // --                               

        //        m_keys.Remove(key);
        //        m_dataRows.Remove(key);                
        //        this.dataSource.Rows.Remove(dataRow);                

        //        // --                

        //        if (index > -1)
        //        {
        //            this.ActiveRow = this.Rows[index];
        //        }
        //        return dataRow;              
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {

        //    }
        //    return null;
        //}

        //------------------------------------------------------------------------------------------------------------------------

        public UltraDataRow removeDataRow(
            string key
            )
        {
            UltraDataRow dataRow = null;

            try
            {
                dataRow = m_dataRows[key];
                // --
                m_keys.Remove(key);
                m_dataRows.Remove(key);
                this.dataSource.Rows.Remove(dataRow);
                // --
                return dataRow;
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

        public UltraDataRow removeDataRow(
            int index
            )
        {
            try
            {
                return removeDataRow(m_keys[index]);
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

        //public void removeDataRows(
        //    string[] keys
        //    )
        //{
        //    UltraDataRow dataRow = null;
        //    UltraGridRow gridRow = null;
        //    int index = -1;

        //    try
        //    {
        //        for (int i = 0; i < keys.Length; i++)
        //        {
        //            dataRow = m_dataRows[keys[i]];

        //            // --

        //            if (i == keys.Length - 1)
        //            {
        //                gridRow = this.Rows.GetRowWithListIndex(dataRow.Index);
        //                // --
        //                index = gridRow.Index;
        //                if (index == this.Rows.Count - 1)
        //                {
        //                    index--;
        //                }
        //            }

        //            // --

        //            m_keys.Remove(keys[i]);
        //            m_dataRows.Remove(keys[i]);
        //            this.dataSource.Rows.Remove(dataRow);      
        //        }

        //        // --

        //        if (index > -1)
        //        {
        //            this.ActiveRow = this.Rows[index];
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {

        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        public void removeDataRows(
            string[] keys
            )
        {
            UltraDataRow dataRow = null;

            try
            {
                for (int i = 0; i < keys.Length; i++)
                {
                    dataRow = m_dataRows[keys[i]];
                    // --                   
                    m_keys.Remove(keys[i]);
                    m_dataRows.Remove(keys[i]);
                    this.dataSource.Rows.Remove(dataRow);
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

        public void removeAllDataRow(
            )
        {
            try
            {
                m_keys.Clear();
                m_dataRows.Clear();                
                this.dataSource.Rows.Clear();
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

        public void moveUpDataRow(
            string key
            )
        {
            UltraDataRow dataRow = null;
            int index = 0;
            object[] cellValues = null;
            object tag = null;

            try
            {
                dataRow = m_dataRows[key];
                
                // --
                
                index = dataRow.Index;
                if (index <= 0)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0001, "Index"));
                }

                // --

                cellValues = new object[this.dataSource.Band.Columns.Count];
                for (int i = 0; i < cellValues.Length; i++)
                {
                    cellValues[i] = dataRow.GetCellValue(i);
                }
                tag = dataRow.Tag;

                // --

                m_keys.Remove(key);
                m_dataRows.Remove(key);
                this.dataSource.Rows.Remove(dataRow);
                
                // --

                index--;
                dataRow = this.dataSource.Rows.Insert(index, cellValues);
                dataRow.Tag = tag;
                m_keys.Insert(index, key);
                m_dataRows.Add(key, dataRow);                                
                
                // --

                this.activateDataRow(key);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveUpDataRow(
            int index
            )
        {
            try
            {
                moveUpDataRow(m_keys[index]);
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

        public void moveDownDataRow(
            string key
            )
        {
            UltraDataRow dataRow = null;
            int index = 0;
            object[] cellValues = null;
            object tag = null;

            try
            {
                dataRow = m_dataRows[key];

                // --

                index = dataRow.Index;
                if (index < 0 || index >= this.Rows.Count - 1)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0001, "Index"));
                }

                // --

                cellValues = new object[this.dataSource.Band.Columns.Count];
                for (int i = 0; i < cellValues.Length; i++)
                {
                    cellValues[i] = dataRow.GetCellValue(i);
                }
                tag = dataRow.Tag;

                // --

                m_keys.Remove(key);
                m_dataRows.Remove(key);
                this.dataSource.Rows.Remove(dataRow);

                // --

                index++;
                dataRow = this.dataSource.Rows.Insert(index, cellValues);
                dataRow.Tag = tag;
                m_keys.Insert(index, key);
                m_dataRows.Add(key, dataRow);

                // --

                this.activateDataRow(key);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void moveDownDataRow(
            int index
            )
        {
            try
            {
                moveDownDataRow(m_keys[index]);
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

        public void searchGridRow(
            string columnName,
            string searchWord
            )
        {
            int index = 0;

            try
            {
                if (this.Rows.Count == 0)
                {
                    return;
                }

                // --

                // ***
                // Column 존재 여부 검사
                // ***
                for (int i = 0; i < this.DisplayLayout.Bands.Count; i++)
                {
                    if (this.DisplayLayout.Bands[i].Columns.Exists(columnName))
                    {
                        break;                      
                    }

                    // --

                    if (i == this.DisplayLayout.Bands.Count)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0012, "Column"));
                    }
                }

                // --

                if (this.ActiveRow != null)
                {
                    index = this.ActiveRow.Index + 1;   // 현재 Active Row 다음 부터 검색
                }

                // --

                for (int i = index; i < this.Rows.Count; i++)
                {
                    if (
                        this.Rows[i].Cells[columnName].Column.Hidden == false &&
                        this.Rows[i].Cells[columnName].Text.ToUpper() == searchWord.ToUpper()
                       )
                    {
                        this.Selected.Rows.Clear();
                        // --
                        this.Selected.Rows.Add(this.Rows[i]);
                        this.ActiveRow = this.Rows[i];
                        return;
                    }
                }

                // --

                for (int i = 0; i < index; i++)
                {
                    if (this.Rows[i].Cells[columnName].Column.Hidden == false &&
                        this.Rows[i].Cells[columnName].Text.ToUpper() == searchWord.ToUpper()
                       )
                    {
                        this.Selected.Rows.Clear();
                        // --
                        this.Selected.Rows.Add(this.Rows[i]);
                        this.ActiveRow = this.Rows[i];
                        return;
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
       
        public bool searchGridRow(            
            string searchWord
            )
        {
            int index = 0;

            try
            {
                if (this.Rows.Count == 0)
                {
                    return false;
                }

                // --

                if (this.ActiveRow != null)
                {
                    index = this.ActiveRow.Index + 1;   // 현재 Active Row 다음 부터 검색
                }

                // --

                for (int i = index; i < this.Rows.Count; i++)
                {
                    if (searchGridCell(this.Rows[i], searchWord))
                    {
                        return true;
                    }
                }

                // --

                for (int i = 0; i < index; i++)
                {
                    if (searchGridCell(this.Rows[i], searchWord))
                    {
                        return true;
                    }
                }

                return false;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool searchGridCell(
            UltraGridRow row,
            string searchWord
            )
        {
            try
            {
                if (row.VisibleIndex < 0)
                {
                    return false;
                }

                // --

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    if (
                        row.Cells[i].Column.Hidden == false &&
                        row.Cells[i].Text.ToLower().IndexOf(searchWord.ToLower()) > -1
                       )
                    {
                        this.Selected.Rows.Clear();
                        // --
                        this.Selected.Rows.Add(row);
                        this.ActiveRow = row;
                        return true;
                    }
                }

                // --

                if (row.ChildBands == null)
                {
                    return false;
                }

                for (int i = 0; i < row.ChildBands.Count; i++)
                {
                    for (int j = 0; j < row.ChildBands[i].Rows.Count; j++)
                    {
                        if (searchGridCell(row.ChildBands[i].Rows[j], searchWord))
                        {
                            return true;
                        }
                    }
                }

                return false;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FGrid Control Event Handler

        private void FGrid_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {

            }
            catch (Exception ex)
            {
                FMessageBox.showError("FGrid", ex, null);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FGrid_ClickCell(
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
                FMessageBox.showError("FGrid", ex, null);
            }
            finally
            {

            }
        }   

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
