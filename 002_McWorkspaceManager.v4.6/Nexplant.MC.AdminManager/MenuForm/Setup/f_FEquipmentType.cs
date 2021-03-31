/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipmentType.cs
--  Creator         : mjkim
--  Create Date     : 2013.12.03
--  Description     : FAMate DCS Manager Setup Equipment Type Form Class 
--  History         : Created by mjkim at 2013.12.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FEquipmentType : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentType(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentType(
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
            try
            {
                btnDelete.Enabled = grdList.activeDataRowKey != string.Empty && m_tranEnabled;
                btnUpdate.Enabled = m_tranEnabled;
                btnClear.Enabled = grdList.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void designGridOfEquipmentType(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Equipment Type");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Maker");
                // --
                uds.Band.Columns.Add("Process Mode");
                uds.Band.Columns.Add("Qty Unit");
                uds.Band.Columns.Add("Remote Start Used");
                uds.Band.Columns.Add("Remote Pause Used");
                uds.Band.Columns.Add("Lot Cancel Rule");
                // --
                uds.Band.Columns.Add("RMS Used");
                uds.Band.Columns.Add("PMS Used");
                // --
                uds.Band.Columns.Add("Auto Recipe Mode");
                uds.Band.Columns.Add("Recipe Creation Mode");
                uds.Band.Columns.Add("Generate Format");
                // --
                uds.Band.Columns.Add("Recipe Type");
                uds.Band.Columns.Add("Standard Recipe Rule");
                // --
                uds.Band.Columns.Add("Recipe Download Used");                
                uds.Band.Columns.Add("Recipe Select Used");
                uds.Band.Columns.Add("Recipe Validation Used");
                // --
                uds.Band.Columns.Add("FW Recipe Download Rule1");
                uds.Band.Columns.Add("FW Recipe Download Rule2");
                uds.Band.Columns.Add("FW Recipe Download Rule3");
                uds.Band.Columns.Add("FW Recipe Download Rule4");
                uds.Band.Columns.Add("FW Recipe Download Rule5");
                // --
                uds.Band.Columns.Add("WO Recipe Download Rule1");
                uds.Band.Columns.Add("WO Recipe Download Rule2");
                uds.Band.Columns.Add("WO Recipe Download Rule3");
                uds.Band.Columns.Add("WO Recipe Download Rule4");
                uds.Band.Columns.Add("WO Recipe Download Rule5");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Equipment Type"].CellAppearance.Image = Properties.Resources.EquipmentType;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment Type"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment Type"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 300;
                grdList.DisplayLayout.Bands[0].Columns["Maker"].Width = 150;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Process Mode"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Qty Unit"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Remote Start Used"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Remote Pause Used"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Lot Cancel Rule"].Width = 120;
                // --
                grdList.DisplayLayout.Bands[0].Columns["RMS Used"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["PMS Used"].Width = 120;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Auto Recipe Mode"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Recipe Creation Mode"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Generate Format"].Width = 120;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Recipe Type"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Standard Recipe Rule"].Width = 130;
                grdList.DisplayLayout.Bands[0].Columns["Recipe Download Used"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Recipe Select Used"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Recipe Validation Used"].Width = 120;
                // --
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule1"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule2"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule3"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule4"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule5"].Width = 120;
                // --
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule1"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule2"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule3"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule4"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule5"].Width = 120;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Process Mode"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Qty Unit"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Remote Start Used"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Remote Pause Used"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Lot Cancel Rule"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["RMS Used"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["PMS Used"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Auto Recipe Mode"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Recipe Creation Mode"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Generate Format"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Recipe Type"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Standard Recipe Rule"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Recipe Download Used"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Recipe Select Used"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Recipe Validation Used"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule1"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule2"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule3"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule4"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["FW Recipe Download Rule5"].Hidden = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule1"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule2"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule3"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule4"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["WO Recipe Download Rule5"].Hidden = true;
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

        private void refreshGridOfEquipmentType(
            string beforeKey
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {   
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfEquipmentType();

                // --

                grdList.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "EquipmentType", "ListEquipmentType", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),    // Equipment Type
                            r[1].ToString(),    // Description
                            r[2].ToString(),    // Maker
                            r[3].ToString(),    // Process Mode
                            r[4].ToString(),    // Qty Unit
                            r[5].ToString(),    // Remote Start Used
                            r[6].ToString(),    // Remote Pause Used
                            r[27].ToString(),   // Lot Cancel Rule (CMF_1)
                            r[7].ToString(),    // RMS Used
                            r[8].ToString(),    // PMS Used
                            r[9].ToString(),    // Auto Recipe Mode
                            r[10].ToString(),   // Recipe Creation Mode (CMF_2)
                            r[11].ToString(),   // Generate Format
                            r[12].ToString(),   // Recipe Type
                            r[13].ToString(),   // Standard Recipe Rule
                            r[14].ToString(),   // Recipe Download Used
                            r[15].ToString(),   // Recipe Select Used
                            r[16].ToString(),   // Recipe Validation Used
                            r[17].ToString(),   // FW Recipe Download Rule 1
                            r[18].ToString(),   // FW Recipe Download Rule 2
                            r[19].ToString(),   // FW Recipe Download Rule 3
                            r[20].ToString(),   // FW Recipe Download Rule 4
                            r[21].ToString(),   // FW Recipe Download Rule 5
                            r[22].ToString(),   // WO Recipe Download Rule 1
                            r[23].ToString(),   // WO Recipe Download Rule 2
                            r[24].ToString(),   // WO Recipe Download Rule 3
                            r[25].ToString(),   // WO Recipe Download Rule 4
                            r[26].ToString()    // WO Recipe Download Rule 5
                            };
                        key = (string)cellValues[0];
                        grdList.appendDataRow(key, cellValues);
                    }

                } while (nextRowNumber >= 0);
                
                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count > 0)
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

                // --

                refreshTotal();

                // --

                controlButton();

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
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfEquipmentType(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropEquipmentType(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfEquipmentType(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            
            try
            {
                if (grdList.activeDataRow == null)
                {
                    return;
                }

                // --                

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("type", grdList.activeDataRowKey);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "EquipmentType", "SearchEquipmentType", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropEquipmentType(m_fAdmCore, pgdProp, dt, m_tranEnabled);
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

        private void refreshTotal(
            )
        {
            try
            {
                lblTotal.Text = grdList.Rows.Count.ToString("#,##0");
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

        #region FEquipmentType Form Event Handler

        private void FEquipmentType_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EquipmentType);

                // --

                designGridOfEquipmentType();

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

        private void FEquipmentType_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEquipmentType(string.Empty);

                // --

                grdList.Focus();
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

        private void FEquipmentType_FormClosing(
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

        private void FEquipmentType_KeyDown(
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
                    refreshGridOfEquipmentType(grdList.activeDataRowKey);
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

                setPropOfEquipmentType();

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

                setPropOfEquipmentType();
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
            FPropEquipmentType fPropTyp = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInTyp = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropTyp = (FPropEquipmentType)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropTyp.Type, true, this.fUIWizard, "Type");

                if (fPropTyp.Type.Length > 30)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Type" }));
                }

                if (fPropTyp.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEquipmentTypeUpdate_In.E_ADMADS_SetEquipmentTypeUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hLanguage, FADMADS_SetEquipmentTypeUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hFactory, FADMADS_SetEquipmentTypeUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hUserId, FADMADS_SetEquipmentTypeUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hHostIp, FADMADS_SetEquipmentTypeUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hHostName, FADMADS_SetEquipmentTypeUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName); 
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hStep, FADMADS_SetEquipmentTypeUpdate_In.D_hStep, "1");                
                // --
                fXmlNodeInTyp = fXmlNodeIn.set_elem(FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_EquipmentType);
                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_EquipmentType,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_EquipmentType,
                    fPropTyp.Type
                    );
                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_Description, 
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_Description, 
                    fPropTyp.Description
                    );
                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_Maker,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_Maker,
                    fPropTyp.Maker
                    );

                // --

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_ProcessMode,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_ProcessMode,
                    fPropTyp.ProcessMode.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_QtyUnit,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_QtyUnit,
                    fPropTyp.QtyUnit.ToString()
                    );

                // --

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_RemoteStartUsed,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_RemoteStartUsed,
                    fPropTyp.RemoteStartUsed.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_RemotePauseUsed,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_RemotePauseUsed,
                    fPropTyp.RemotePauseUsed.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_LotCancelRule,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_LotCancelRule,
                    fPropTyp.LotCancelRule.ToString()
                    );

                // --

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_RMSUsed,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_RMSUsed,
                    fPropTyp.RMSUsed.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_PMSUsed,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_PMSUsed,
                    fPropTyp.PMSUsed.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_AutoRecipeMode,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_AutoRecipeMode,
                    fPropTyp.AutoRecipeMode.ToString()
                    );
                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_RecipeCreationMode,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_RecipeCreationMode,
                    fPropTyp.RecipeCreationMode.ToString()
                    );
                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_GenerateFormat,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_GenerateFormat,
                    fPropTyp.GenerateFormat
                    );

                // --

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_RecipeType,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_RecipeType,
                    fPropTyp.RecipeType.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_StandardRecipeRule,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_StandardRecipeRule,
                    fPropTyp.StandardRecipeRule.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_RecipeDownloadUsed,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_RecipeDownloadUsed,
                    fPropTyp.RecipeDownloadUsed.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_RecipeSelectUsed,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_RecipeSelectUsed,
                    fPropTyp.RecipeSelectUsed.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_RecipeValidationUsed,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_RecipeValidationUsed,
                    fPropTyp.RecipeValidationUsed.ToString()
                    );

                // --

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_FWRecipeDownloadRule1,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_FWRecipeDownloadRule1,
                    fPropTyp.FWRecipeDownloadRule1.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_FWRecipeDownloadRule2,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_FWRecipeDownloadRule2,
                    fPropTyp.FWRecipeDownloadRule2.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_FWRecipeDownloadRule3,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_FWRecipeDownloadRule3,
                    fPropTyp.FWRecipeDownloadRule3.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_FWRecipeDownloadRule4,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_FWRecipeDownloadRule4,
                    fPropTyp.FWRecipeDownloadRule4.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_FWRecipeDownloadRule5,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_FWRecipeDownloadRule5,
                    fPropTyp.FWRecipeDownloadRule5.ToString()
                    );

                // --

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_WORecipeDownloadRule1,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_WORecipeDownloadRule1,
                    fPropTyp.WORecipeDownloadRule1.ToString()
                    );
                
                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_WORecipeDownloadRule2,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_WORecipeDownloadRule2,
                    fPropTyp.WORecipeDownloadRule2.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_WORecipeDownloadRule3,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_WORecipeDownloadRule3,
                    fPropTyp.WORecipeDownloadRule3.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_WORecipeDownloadRule4,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_WORecipeDownloadRule4,
                    fPropTyp.WORecipeDownloadRule4.ToString()
                    );

                fXmlNodeInTyp.set_elemVal(
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_WORecipeDownloadRule5,
                    FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_WORecipeDownloadRule5,
                    fPropTyp.WORecipeDownloadRule5.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_SetEquipmentTypeUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentTypeUpdate_Out.A_hStatus, FADMADS_SetEquipmentTypeUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentTypeUpdate_Out.A_hStatusMessage, FADMADS_SetEquipmentTypeUpdate_Out.D_hStatusMessage)
                        );
                }

                // --
                
                cellValues = new object[]
                {
                    fPropTyp.Type,
                    fPropTyp.Description,
                    fPropTyp.Maker,
                    fPropTyp.ProcessMode,
                    fPropTyp.QtyUnit,
                    fPropTyp.RemoteStartUsed,
                    fPropTyp.RemotePauseUsed,
                    fPropTyp.LotCancelRule,
                    fPropTyp.RMSUsed,
                    fPropTyp.PMSUsed,
                    fPropTyp.AutoRecipeMode,
                    fPropTyp.RecipeCreationMode,
                    fPropTyp.GenerateFormat,
                    fPropTyp.RecipeType,
                    fPropTyp.StandardRecipeRule,
                    fPropTyp.RecipeDownloadUsed,
                    fPropTyp.RecipeSelectUsed,
                    fPropTyp.RecipeValidationUsed,
                    fPropTyp.FWRecipeDownloadRule1,
                    fPropTyp.FWRecipeDownloadRule2,
                    fPropTyp.FWRecipeDownloadRule3,
                    fPropTyp.FWRecipeDownloadRule4,
                    fPropTyp.FWRecipeDownloadRule5,
                    fPropTyp.WORecipeDownloadRule1,
                    fPropTyp.WORecipeDownloadRule2,
                    fPropTyp.WORecipeDownloadRule3,
                    fPropTyp.WORecipeDownloadRule4,
                    fPropTyp.WORecipeDownloadRule5
                };
                // --
                key = fPropTyp.Type;
                grdList.appendOrUpdateDataRow(key, cellValues);
                grdList.activateDataRow(key);

                // --

                refreshTotal();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fPropTyp = null;
                fXmlNodeIn = null;
                fXmlNodeInTyp = null;
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

                initPropOfEquipmentType();
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

        #region btnDelete Control Event Handler

        private void btnDelete_Click(
            object sender,
            EventArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInTyp = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Equipment Type" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEquipmentTypeUpdate_In.E_ADMADS_SetEquipmentTypeUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hLanguage, FADMADS_SetEquipmentTypeUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hFactory, FADMADS_SetEquipmentTypeUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hUserId, FADMADS_SetEquipmentTypeUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hHostIp, FADMADS_SetEquipmentTypeUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hHostName, FADMADS_SetEquipmentTypeUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentTypeUpdate_In.A_hStep, FADMADS_SetEquipmentTypeUpdate_In.D_hStep, "2");                
                // --
                fXmlNodeInTyp = fXmlNodeIn.set_elem(FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.E_EquipmentType);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInTyp.set_elemVal(
                        FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.A_EquipmentType, 
                        FADMADS_SetEquipmentTypeUpdate_In.FEquipmentType.D_EquipmentType, 
                        row["Equipment Type"].ToString()
                        );

                    // --
                    
                    FADMADSCaster.ADMADS_SetEquipmentTypeUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentTypeUpdate_Out.A_hStatus, FADMADS_SetEquipmentTypeUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentTypeUpdate_Out.A_hStatusMessage, FADMADS_SetEquipmentTypeUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdList.removeDataRow(row.Index);
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfEquipmentType();
                }

                // --

                refreshTotal();
    
                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInTyp = null;
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

                refreshGridOfEquipmentType(grdList.activeDataRowKey);
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
