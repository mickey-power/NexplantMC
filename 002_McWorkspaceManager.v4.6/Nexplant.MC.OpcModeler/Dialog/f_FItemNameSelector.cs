/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FItemNameSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.13
--  Description     : FAMate OPC Modeler Item Name Selector Form Class 
--  History         : Created by Jeff.Kim at 2015.07.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.OpcModeler
{
    public partial class FItemNameSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FOpcSession m_fOsn = null;
        private string m_oldItemName = null;        
        private FItemName m_fSelectedItn = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FItemNameSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FItemNameSelector(
            FOpmCore fOpmCore,
            FOpcSession fOsn,
            string oldItemName
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            m_fOpmCore = fOpmCore;
            m_fOsn = fOsn;
            m_oldItemName = oldItemName;
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
                    m_fOpmCore = null;
                    m_fOsn = null;
                    m_fSelectedItn = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FItemName fSelectedItemName
        {
            get
            {
                try
                {
                    return m_fSelectedItn;
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

        private void designGridOfDevice(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdItemName.dataSource;
                // --
                uds.Band.Columns.Add("Item Name");
                uds.Band.Columns.Add("Item Format");
                uds.Band.Columns.Add("Item Array");                

                // --

                grdItemName.DisplayLayout.Bands[0].Columns["Item Name"].CellAppearance.Image = Properties.Resources.AppendOpcItem;
                // --
                grdItemName.DisplayLayout.Bands[0].Columns["Item Name"].Width = 150;
                grdItemName.DisplayLayout.Bands[0].Columns["Item Format"].Width = 90;
                grdItemName.DisplayLayout.Bands[0].Columns["Item Array"].Width = 90;                
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

        private void refreshGridOfItemName(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdItemName.beginUpdate(false);                

                // --

                foreach (FItemName fItn in m_fOsn.FChildItemNameCollection)
                {
                    cellValues = new object[] {
                        fItn.name,
                        fItn.fItemFormat.ToString(),
                        fItn.itemArray
                    };
                    dataRow = grdItemName.appendDataRow(fItn.uniqueIdToString, cellValues);
                    dataRow.Tag = fItn;
                    FCommon.refreshGridRowOfObject(fItn, grdItemName.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fItn.name == m_oldItemName)
                    {
                        activeDataRowKey = fItn.uniqueIdToString;
                    }
                }

                // --

                grdItemName.endUpdate(false);                

                // --

                if (grdItemName.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdItemName.ActiveRow = grdItemName.Rows[0];
                    }
                    else
                    {
                        grdItemName.activateDataRow(activeDataRowKey);
                    }
                }
                else
                {
                    btnOk.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                grdItemName.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }              
        
        //------------------------------------------------------------------------------------------------------------------------

        private void selectItemName(
            )
        {
            try
            {
                m_fSelectedItn = (FItemName)grdItemName.activeDataRow.Tag;
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

        #region FOpcDeviceSelector Form Event Handler

        private void FOpcDeviceSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfDevice();

                // --

                grdItemName.Visible = true;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FOpcDeviceSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --                
                
                refreshGridOfItemName();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                selectItemName();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                selectItemName();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region rstToolbar Control Event Handler

        private void rstToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                grdItemName.searchGridRow(e.searchWord);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
