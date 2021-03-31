/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FDropDownListCombo.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.16
--  Description     : FAMate Core FaUIs Drop Down List Combo Control
--  History         : Created by spike.lee at 2011.03.16
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
using Infragistics.Win.UltraWinEditors;

namespace Nexplant.MC.Core.FaUIs
{
    public partial class FDropDownListCombo : UltraCombo
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<string> m_keys = null;
        private Dictionary<string, UltraDataRow> m_dataRows = null;
        private string m_displayedText = string.Empty;
        private string m_displayedKey = string.Empty;
        private int m_keyColumnPosition = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDropDownListCombo(
            )
        {
            InitializeComponent();
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
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

        public int keyColumnPosition
        {
            get
            {
                try
                {
                    return m_keyColumnPosition;
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

            set
            {
                try
                {
                    m_keyColumnPosition = value >= 0 ? value : 0;
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
                m_keyColumnPosition = 0;

                // --

                this.HandleCreated += new EventHandler(FDropDownListCombo_HandleCreated);
                this.ButtonsRight.ItemAdding += new EditorButtonEventHandler(ButtonsRight_ItemAdding);
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
                this.HandleCreated -= new EventHandler(FDropDownListCombo_HandleCreated);
                this.ButtonsRight.ItemAdding -= new EditorButtonEventHandler(ButtonsRight_ItemAdding);
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
                m_displayedText = this.Text;
                if (m_displayedText != string.Empty)
                {
                    m_displayedKey = this.activeDataRowKey;                    
                }

                // --

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
                if (m_displayedText != string.Empty && !m_keys.Contains(m_displayedKey))                
                {
                    for (int i = 0; i < this.dataSource.Rows.Count; i++)
                    {
                        if ((string)this.dataSource.Rows[i][keyColumnPosition] == m_displayedText)
                        {
                            this.dataSource.Rows.RemoveAt(i);
                            break;
                        }
                    }
                }

                // --

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

        public void activateDataRow(
            string key
            )
        {
            try
            {
                if (m_dataRows.ContainsKey(key))
                {
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

        public UltraDataRow appendDataRow(
            string key,
            object[] cellValues
            )
        {
            UltraDataRow dataRow = null;
            int index = -1;

            try
            {
                m_keys.Add(key);
                index = m_keys.Count - 1;
                // --
                //if (this.dataSource.Rows.Count == index)
                //{
                //    dataRow = this.dataSource.Rows.Add(cellValues);
                //}
                //else if ((string)this.dataSource.Rows[index][0] == key)
                //{
                //    for (int i = 0; i < cellValues.Length; i++)
                //    {
                //        this.dataSource.Rows[index][i] = cellValues[i];
                //    }
                //    dataRow = this.dataSource.Rows[index];
                //}
                //else
                //{
                //    dataRow = this.dataSource.Rows.Insert(index, cellValues);
                //}
                // --
                if (this.dataSource.Rows.Count == index)
                {
                    dataRow = this.dataSource.Rows.Add(cellValues);
                }
                else if (m_displayedKey == key)
                {
                    for (int i = 0; i < cellValues.Length; i++)
                    {
                        this.dataSource.Rows[index][i] = cellValues[i];
                    }
                    dataRow = this.dataSource.Rows[index];
                }
                else
                {
                    dataRow = this.dataSource.Rows.Insert(index, cellValues);
                }
                // --
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

        public void removeAllDataRow(
            )
        {
            int i = 0;

            try
            {
                m_keys.Clear();
                m_dataRows.Clear();
                // --
                //if (m_displayedText == string.Empty)
                //{
                //    this.dataSource.Rows.Clear();
                //}
                //else
                {
                    for(i = this.dataSource.Rows.Count - 1; i >= 0; i--)
                    {
                        if ((string)this.dataSource.Rows[i][keyColumnPosition] != m_displayedText)
                        {
                            this.dataSource.Rows.RemoveAt(i);
                        }
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

        public void setInitValue(
            string key
            )
        {
            object[] cellValues = null;

            try
            {
                if (this.dataSource.Rows.Count > 0 || key == string.Empty)
                {
                    return;
                }

                // --

                cellValues = new object[this.dataSource.Band.Columns.Count];
                for (int index = 0; index < cellValues.Length; index++)
                {
                    cellValues[index] = keyColumnPosition == index ? key : string.Empty;                    
                }
                // --
                m_keys.Add(key);
                m_dataRows.Add(key, this.dataSource.Rows.Add(cellValues));                

                // --

                this.ActiveRow = this.Rows[0];
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

        #region FDropDownListCombo Control Event Handler

        private void FDropDownListCombo_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FDropDownListCombo", ex, null);
            }
            finally
            {

            }
        }
 
        //------------------------------------------------------------------------------------------------------------------------

        private void ButtonsRight_ItemAdding(
            object sender,
            EditorButtonEventArgs e
            )
        {
            try
            {
                if (e.Button is EditorButton)
                {
                    e.Button.Appearance = FComboCommon.editButtonAppearance;
                    ((EditorButton)e.Button).PressedAppearance = FComboCommon.editButtonPressedAppearance;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError("FDropDownListCombo", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
