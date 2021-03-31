/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : t_FDropDownCombo.cs
--  Creator         : spike.lee
--  Create Date     : 2011.03.16
--  Description     : FAMate Core FaUIs Drop Down Combo Control
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
    public partial class FDropDownCombo : UltraCombo
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<string> m_keys = null;
        private Dictionary<string, UltraDataRow> m_dataRows = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDropDownCombo(
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

                this.HandleCreated += new EventHandler(FDropDownCombo_HandleCreated);
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
                this.HandleCreated -= new EventHandler(FDropDownCombo_HandleCreated);
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

        // ***
        // 2012.11.28 by spike.lee
        // Suspend Binding 기능이 없어서 구현합니다.
        // ***
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

        // ***
        // 2012.11.28 by spike.lee
        // Suspend Binding 기능이 없어서 구현합니다.
        // ***
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FDropDownCombo Control Event Handler

        private void FDropDownCombo_HandleCreated(
            object sender, 
            EventArgs e
            )
        {
            try
            {

            }
            catch (Exception ex)
            {
                FMessageBox.showError("FDropDownCombo", ex, null);
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
                FMessageBox.showError("FDropDownCombo", ex, null);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end