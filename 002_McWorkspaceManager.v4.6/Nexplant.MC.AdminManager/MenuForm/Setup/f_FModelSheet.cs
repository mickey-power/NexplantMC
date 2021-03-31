/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FModelSheet.cs
--  Creator         : iskim
--  Create Date     : 2014.01.21
--  Description     : FAMate Admin Manager Model Sheet Form Class 
--  History         : Created by iskim at 2014.01.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FModelSheet : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
    
        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FModelSheet(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FModelSheet(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

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

        private void controlButton(
            )
        {
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "Model")
                {
                    btnReset.Enabled = false;
                    // --
                    btnUpdate.Enabled = false;
                    btnClear.Enabled = false;
                }
                else if (key == "Model Sheet")
                {
                    btnReset.Enabled = grdModel.activeDataRowKey != string.Empty && m_tranEnabled;
                    // --
                    btnUpdate.Enabled = grdModel.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdModel.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void initPropOfModel(
            )
        {
            try
            {
                pgdModel.selectedObject = new FPropModelSheet(m_fAdmCore, pgdModel, m_tranEnabled);
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

        private void setPropOfModel(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdModel.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", grdModel.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelSheet", "SearchModel", fSqlParams, true);

                // --

                pgdModel.selectedObject = new FPropModelSheet(m_fAdmCore, pgdModel, dt, m_tranEnabled);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfModel(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdModel.dataSource;
                // --
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Maker");
                uds.Band.Columns.Add("Release Ver.");
                uds.Band.Columns.Add("Last Ver.");

                // --

                grdModel.DisplayLayout.Bands[0].Columns["Release Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdModel.DisplayLayout.Bands[0].Columns["Last Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdModel.DisplayLayout.Bands[0].Columns["Model"].Header.Fixed = true;
                // --
                grdModel.DisplayLayout.Bands[0].Columns["Model"].Width = 150;
                grdModel.DisplayLayout.Bands[0].Columns["Description"].Width = 216;
                grdModel.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                grdModel.DisplayLayout.Bands[0].Columns["Maker"].Width = 120;
                grdModel.DisplayLayout.Bands[0].Columns["Release Ver."].Width = 80;
                grdModel.DisplayLayout.Bands[0].Columns["Last Ver."].Width = 80;

                // --

                grdModel.ImageList = new ImageList();
                // --
                grdModel.ImageList.Images.Add("Model", Properties.Resources.Model);
                grdModel.ImageList.Images.Add("Model_Secs", Properties.Resources.Model_Secs);
                grdModel.ImageList.Images.Add("Model_Plc", Properties.Resources.Model_Plc);
                grdModel.ImageList.Images.Add("Model_Opc", Properties.Resources.Model_Opc);
                grdModel.ImageList.Images.Add("Model_Tcp", Properties.Resources.Model_Tcp);
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

        private void refreshGridOfModel(
            string beforeKey
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                grdModel.removeAllDataRow();
                grdModel.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfModel();
                // --
                ftxSheet.value = string.Empty;
                ftxSheet.Tag = string.Empty;

                // --

                grdModel.beginUpdate(false);

                // -- 

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelSheet", "ListModel", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Model
                            r[1].ToString(),   // Description   
                            r[2].ToString(),   // Type
                            r[3].ToString(),   // Maker
                            r[4].ToString(),   // Release Version
                            r[5].ToString()    // Last Version                        
                            };
                        key = (string)cellValues[0];
                        index = grdModel.appendDataRow(key, cellValues).Index;
                        // --
                        grdModel.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfModel(grdModel, r[2].ToString());
                    }
                } while (nextRowNumber >= 0);

                // -- 

                grdModel.endUpdate(false);

                // --

                if (grdModel.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdModel.activateDataRow(beforeKey);
                    }
                    if (grdModel.activeDataRow == null)
                    {
                        grdModel.ActiveRow = grdModel.Rows[0];
                    }
                }

                // -- 

                refreshModelTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Model")
                {
                    grdModel.Focus();
                }
            }
            catch (Exception ex)
            {
                grdModel.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshModelSheet(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            string contents = string.Empty;

            try
            {
                ftxSheet.value = string.Empty;
                ftxSheet.Tag = string.Empty;

                // --

                if (grdModel.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", grdModel.activeDataRowKey);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelSheet", "SearchModelSheet", fSqlParams, false);
                // --
                if (dt.Rows.Count == 0)
                {
                    return;
                }

                // --

                contents = "";
                contents += dt.Rows[0]["SHT_CONTENTS_01"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_02"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_03"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_04"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_05"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_06"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_07"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_08"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_09"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_10"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_11"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_12"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_13"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_14"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_15"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_16"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_17"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_18"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_19"].ToString();
                contents += dt.Rows[0]["SHT_CONTENTS_20"].ToString();

                // --

                ftxSheet.value = contents;
                ftxSheet.Tag = ftxSheet.value;

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Model Sheet")
                {
                    ftxSheet.Focus();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshModelTotal(
            )
        {
            try
            {
                lblTotal.Text = grdModel.Rows.Count.ToString("#,##0");
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

        #region FModelSheet Form Event Handler

        private void FModelSheet_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.ModelSheet);

                // --

                designGridOfModel();

                // --

                controlButton();

                // --

                m_fAdmCore.fOption.fChildFormList.add(this);
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

        private void FModelSheet_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfModel(string.Empty);

                // --

                grdModel.Focus();
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

        private void FModelSheet_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fAdmCore.fOption.fChildFormList.remove(this);
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

        private void FModelSheet_KeyDown(
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
                    if (tabMain.ActiveTab.Key == "Model")
                    {
                        refreshGridOfModel(grdModel.activeDataRowKey);
                    }
                    else
                    {
                        refreshModelSheet();
                    }                    
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

        #region tabMain Control Event Handler

        private void tabMain_ActiveTabChanged(
            object sender,
            Infragistics.Win.UltraWinTabControl.ActiveTabChangedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // -- 

                controlButton();
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

        #region grdModel Control Event Handler

        private void grdModel_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfModel();

                // --

                refreshModelSheet();
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

        private void grdModel_DoubleClickRow(
            object sender,
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.Tabs["Model Sheet"].Selected = true;
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

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
            object sender,
            EventArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSht = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelSheetUpdate_In.E_ADMADS_SetModelSheetUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelSheetUpdate_In.A_hLanguage, FADMADS_SetModelSheetUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelSheetUpdate_In.A_hFactory, FADMADS_SetModelSheetUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelSheetUpdate_In.A_hUserId, FADMADS_SetModelSheetUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelSheetUpdate_In.A_hHostIp, FADMADS_SetModelSheetUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelSheetUpdate_In.A_hHostName, FADMADS_SetModelSheetUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelSheetUpdate_In.A_hStep, FADMADS_SetModelSheetUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInSht = fXmlNodeIn.set_elem(FADMADS_SetModelSheetUpdate_In.FSheet.E_Sheet);
                fXmlNodeInSht.set_elemVal(FADMADS_SetModelSheetUpdate_In.FSheet.A_Model, FADMADS_SetModelSheetUpdate_In.FSheet.D_Model, grdModel.activeDataRowKey);
                fXmlNodeInSht.set_elemVal(FADMADS_SetModelSheetUpdate_In.FSheet.A_Contents, FADMADS_SetModelSheetUpdate_In.FSheet.D_Contents, ftxSheet.value.ToString());

                // --

                FADMADSCaster.ADMADS_SetModelSheetUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelSheetUpdate_Out.A_hStatus, FADMADS_SetModelSheetUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelSheetUpdate_Out.A_hStatusMessage, FADMADS_SetModelSheetUpdate_Out.D_hStatusMessage));
                }

                // --

                ftxSheet.Tag = ftxSheet.value;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSht = null;
                fXmlNodeOut = null;

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

                ftxSheet.value = string.Empty;
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
                FCursor.waitCursor();

                // --

                ftxSheet.value = ftxSheet.Tag;
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

        #region rstModel Control Event Handler

        private void rstModel_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdModel.searchGridRow(e.searchWord))
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

        //------------------------------------------------------------------------------------------------------------------------

        private void rstModel_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfModel(grdModel.activeDataRowKey);
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