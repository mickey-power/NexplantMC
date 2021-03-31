/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecs1ToHsmsConverterSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.28
--  Description     : FAmate Admin Manager SECS1 To HSMS Converter Select Dialog Form Class 
--  History         : Created by spike.lee at 2017.04.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.Collections;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecs1ToHsmsConverterSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_oldConverter = string.Empty;
        private string m_deleteFlag = string.Empty; 
        private string m_selectedConverter = string.Empty;
        private string m_selectedConverterDesc = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1ToHsmsConverterSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1ToHsmsConverterSelector(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1ToHsmsConverterSelector(
            FAdmCore fAdmCore,
            string oldConverter,
            string deleteFlag
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_oldConverter = oldConverter;
            m_deleteFlag = deleteFlag;
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

        public string selectedConverter
        {
            get
            {
                try
                {
                    return m_selectedConverter;
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

        public string selectedConverterDesc
        {
            get
            {
                try
                {
                    return m_selectedConverterDesc;
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

        private void designGridOfSecs1ToHsmsConverterList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdS2HCvtList.dataSource;
                // --                
                uds.Band.Columns.Add("Converter");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Converter IP");

                // --

                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Converter"].CellAppearance.Image = Properties.Resources.S2HCvt;
                // --
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Converter"].Width = 120;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Type"].Width = 90;
                grdS2HCvtList.DisplayLayout.Bands[0].Columns["Converter IP"].Width = 90;
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

        private void refreshGridOfSecs1ToHsmsConverterList(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;
            string deleteFlag = string.Empty;

            try
            {
                btnOk.Enabled = false;

                // --

                grdS2HCvtList.beginUpdate(false);
                grdS2HCvtList.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("delete_flag", m_deleteFlag, m_deleteFlag == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "Secs1ToHsmsConverterSelector", "ListSecs1ToHsmsConverter", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        deleteFlag = r[4].ToString();   // Delete Flag

                        // --

                        cellValues = new object[] {
                            r[0].ToString(),    // Converter
                            r[1].ToString(),    // Description
                            r[2].ToString(),    // Type
                            r[3].ToString()     // Converter IP
                            };
                        index = grdS2HCvtList.appendDataRow(r[0].ToString(), cellValues).Index;

                        // --

                        if (deleteFlag == "Y")
                        {
                            row = grdS2HCvtList.Rows.GetRowWithListIndex(index);
                            row.Appearance.ForeColor = Color.DimGray;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdS2HCvtList.endUpdate();

                // --

                if (grdS2HCvtList.Rows.Count > 0)
                {
                    if (m_oldConverter != string.Empty)
                    {
                        grdS2HCvtList.activateDataRow(m_oldConverter);
                    }
                    // --
                    if (grdS2HCvtList.activeDataRow == null)
                    {
                        grdS2HCvtList.ActiveRow = grdS2HCvtList.Rows[0];
                    }
                }

                // --

                grdS2HCvtList.Focus();
            }
            catch (Exception ex)
            {
                grdS2HCvtList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void selectSecs1ToHsmsConverter(
            )
        {
            try
            {
                m_selectedConverter = grdS2HCvtList.activeDataRow["Converter"].ToString();
                m_selectedConverterDesc = grdS2HCvtList.activeDataRow["Description"].ToString();
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

        #region FSecs1ToHsmsConverterSelector Form Event Handler

        private void FSecs1ToHsmsConverterSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                btnReset.Enabled = (m_oldConverter == string.Empty ? false : true);

                // --

                designGridOfSecs1ToHsmsConverterList();                
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

        private void FSecs1ToHsmsConverterSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfSecs1ToHsmsConverterList();                
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

        private void FSecs1ToHsmsConverterSelector_KeyDown(
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
                    refreshGridOfSecs1ToHsmsConverterList();
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

        #region grdS2HCvtList Control Event Handler

        private void grdS2HCvtList_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdS2HCvtList.activeDataRow == null)
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

        private void grdS2HCvtList_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                selectSecs1ToHsmsConverter();
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
            string server = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                selectSecs1ToHsmsConverter();
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
                m_selectedConverter = string.Empty;
                m_selectedConverterDesc = string.Empty;
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

        #region rstS2HCvt Control Event Handler

        private void rstS2HCvt_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --     

                refreshGridOfSecs1ToHsmsConverterList();
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

        private void rstS2HCvt_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdS2HCvtList.searchGridRow(e.searchWord))
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
