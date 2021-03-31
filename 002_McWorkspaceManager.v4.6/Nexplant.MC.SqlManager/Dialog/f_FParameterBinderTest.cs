/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FParameterBinder.cs
--  Creator         : mj.kim
--  Create Date     : 2011.11.15
--  Description     : FAMate SQL Manager Parameter Binder Form Class 
--  History         : Created by mj.kim at 2011.11.15
--                    Query Test용으로 만듬
 ----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
//using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SqlManager
{
    public partial class FParameterBinderTest : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FSqmCore m_fSqmCore = null;
        private Dictionary<string, FSqlParameter> m_fSqlParameters = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FParameterBinderTest(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FParameterBinderTest(
            FSqmCore fSqmCore,            
            Dictionary<string, FSqlParameter> fSqlParameter
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
            m_fSqlParameters = fSqlParameter;
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
                    m_fSqlParameters = null;
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
            string caption = string.Empty;

            try
            {
                caption = m_fSqmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
                this.Text = caption;
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

        private void designGridOfParameterBinder(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Nullable", typeof(bool));
                uds.Band.Columns.Add("Value");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Name"].CellAppearance.Image = Properties.Resources.Parameter;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Name"].Header.Fixed = true;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Name"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Nullable"].Width = 60;
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

        private void refreshGridOfParameterBinder(
            )
        {
            UltraDataRow dataRow = null;
            object[] cellValues = null;

            try
            {
                grdList.beginUpdate();
                grdList.removeAllDataRow();

                // --
                
                foreach (FSqlParameter f in m_fSqlParameters.Values)
                {
                    cellValues = new object[] { f.parameter, f.nullable, f.value};
                    dataRow = grdList.appendDataRow(f.parameter, cellValues);
                    dataRow.Tag = f;
                }

                // --

                grdList.endUpdate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setPropOfParameter(
            )
        {
            string key = string.Empty;

            try
            {
                key = grdList.activeDataRowKey;
                if (key == string.Empty)
                {
                    return;
                }

                // --

                pgdProp.selectedObject = new FPropParameter(m_fSqmCore, pgdProp, m_fSqlParameters[key]);
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

        #region FParameterBinder Form Event Handler

        private void FParameterBinder_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfParameterBinder();
                
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

        private void FParameterBinder_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfParameterBinder();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
                btnGenerator.Focus();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region  btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                
                this.DialogResult = DialogResult.OK;
                this.Close();
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

                setPropOfParameter();
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

        #region pgdProp Control Event Handler

        private void pgdProp_PropertyValueChanged(
            object s, 
            PropertyValueChangedEventArgs e
            )
        {
            FPropParameter fPropParameter = null;
            UltraGridRow gridRow = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropParameter = (FPropParameter)pgdProp.selectedObject;
                gridRow = grdList.ActiveRow;
                
                // --

                grdList.beginUpdate();

                // --

                if (e.ChangedItem.PropertyDescriptor.Name == "Nullable")
                {
                    if (fPropParameter.Nullable)
                    {
                        fPropParameter.Value =  string.Empty;
                    }
                }
                else if (e.ChangedItem.PropertyDescriptor.Name == "Value")
                {
                    fPropParameter.Nullable = ((string)fPropParameter.Value == string.Empty ? true : false);
                    pgdProp.Refresh();
                }

                gridRow.Cells["Nullable"].Value = fPropParameter.Nullable;
                gridRow.Cells["Value"].Value = fPropParameter.Value;

                // --

                grdList.endUpdate();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        private void btnGenerator_Click(
            object sender, 
            EventArgs e
            )
        {
            FPropParameter fPropParameter = null;
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                fPropParameter = (FPropParameter)pgdProp.selectedObject;

                // --

                grdList.beginUpdate();

                // --
                foreach (UltraGridRow r in grdList.Rows)
                {
                    key = r.Cells[0].Value.ToString();
                    r.Cells["Value"].Value = "1";
                    r.Cells[1].Value = false;
                    m_fSqlParameters[key].value = "1";
                    m_fSqlParameters[key].nullable = false;
                    pgdProp.selectedObject = new FPropParameter(m_fSqmCore, pgdProp, m_fSqlParameters[key]);
                }

                // --

                grdList.endUpdate();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
                btnOk.Focus();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
