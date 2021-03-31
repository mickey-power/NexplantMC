/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FModule.cs
--  Creator         : mj.kim
--  Create Date     : 2011.10.12
--  Description     : FAMate SQL Manager Setup Module Form Class 
--  History         : Created by mj.kim at 2011.10.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.SqlManager
{
    public partial class FModule : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm //FBaseControlDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FModule(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FModule(
            FSqmCore fSqmCore
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
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
            try
            {
                this.Text = m_fSqmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        private void designComboOfSystem(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbSystem.dataSource;

                // --

                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");

                // --

                ucbSystem.Appearance.Image = Properties.Resources.System;

                // --

                ucbSystem.DisplayLayout.Bands[0].Columns["Name"].CellAppearance.Image = Properties.Resources.System;
                // --
                ucbSystem.DisplayLayout.Bands[0].Columns["Name"].Width = 120;
                ucbSystem.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfModule(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Module");
                uds.Band.Columns.Add("Description");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Module"].CellAppearance.Image = Properties.Resources.Module;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Module"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Module"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshComboOfSystem(
            )
        {
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (ucbSystem.activeDataRow != null)
                {
                    beforeKey = ucbSystem.activeDataRowKey;
                }

                // --

                ucbSystem.beginUpdate();
                ucbSystem.removeAllDataRow();

                // --

                do
                {
                    dt = FCommon.requestSystemList(m_fSqmCore, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[1],   // System
                            r[2]    // Description
                        };
                        key = (string)cellValues[0];
                        ucbSystem.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                ucbSystem.endUpdate();

                // --

                ucbSystem.DisplayLayout.Bands[0].SortedColumns.Add("Name", false);
                // --
                if (ucbSystem.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        ucbSystem.activateDataRow(beforeKey);
                    }
                    // --
                    if (ucbSystem.activeDataRow == null)
                    {
                        ucbSystem.ActiveRow = ucbSystem.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                ucbSystem.endUpdate(); 
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfModule(
            )
        {
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty; 
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (ucbSystem.Text == string.Empty)
                {
                    grdList.removeAllDataRow();
                    return;
                }
                if (grdList.activeDataRow != null)
                {
                    beforeKey = grdList.activeDataRowKey;
                }

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();

                // --

                do
                {
                    dt = FCommon.requestModuleList(m_fSqmCore, ucbSystem.Text, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[1],   // Module
                            r[2]    // Description
                        };
                        key = r[0].ToString();
                        grdList.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate();

                // --

                grdList.DisplayLayout.Bands[0].SortedColumns.Add("Module", false);
                // --
                if (grdList.Rows.Count == 0)
                {
                    initPropOfModule();
                    btnDelete.Enabled = false;
                }
                else
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
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfModule(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropModule(m_fSqmCore, pgdProp, ucbSystem.Text);
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

        private void setPropOfModule(
            )
        {
            DataTable dt = null;
            string uniqueIdToString = string.Empty;

            try
            {
                if (grdList.activeDataRow == null)
                {
                    return;
                }
                uniqueIdToString = grdList.activeDataRowKey;

                // --

                dt = FCommon.getModuleInfo(m_fSqmCore, ucbSystem.activeDataRowKey, uniqueIdToString, (string)grdList.activeDataRow["Module"]);

                // --

                pgdProp.selectedObject = new FPropModule(m_fSqmCore, pgdProp, ucbSystem.Text, dt);
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FModule Form Event Handler

        private void FModule_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designComboOfSystem();
                designGridOfModule();

                // --

                m_fSqmCore.fOption.fChildList.add(this);
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

        private void FModule_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfSystem();

                // --

                setTitle();

                // --

                ucbSystem.Focus();
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

        private void FModule_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSqmCore.fOption.fChildList.remove(this);
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

        #region ucbSystem Control Event Handler

        private void ucbSystem_BeforeDropDown(
            object sender, 
            CancelEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfSystem();
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

        private void ucbSystem_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfModule();
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

                setPropOfModule();
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

        private void grdList_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfModule();
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

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
            object sender,
            EventArgs e
            )
        {
            FPropModule fPropModule = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMod = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropModule = (FPropModule)pgdProp.selectedObject;

                // --

                #region Validation 

                FCommon.validateName(fPropModule.System, true, this.fUIWizard);
                FCommon.validateName(fPropModule.Module, true, this.fUIWizard);

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetModuleUpdate_In.E_SQMSQS_SetModuleUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleUpdate_In.A_hLanguage, FSQMSQS_SetModuleUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleUpdate_In.A_hStep, FSQMSQS_SetModuleUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInMod = fXmlNodeIn.set_elem(FSQMSQS_SetModuleUpdate_In.FModule.E_Module);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_System, FSQMSQS_SetModuleUpdate_In.FModule.D_System, fPropModule.System);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_UniqueId, FSQMSQS_SetModuleUpdate_In.FModule.D_UniqueId, fPropModule.ID);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_Module, FSQMSQS_SetModuleUpdate_In.FModule.D_Module, fPropModule.Module);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_Description, FSQMSQS_SetModuleUpdate_In.FModule.D_Description, fPropModule.Description);

                // --

                FSQMSQSCaster.SQMSQS_SetModuleUpdate_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleUpdate_Out.A_hStatus, FSQMSQS_SetModuleUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleUpdate_Out.A_hStatusMessage, FSQMSQS_SetModuleUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropModule.Module,
                    fPropModule.Description
                };
                // --
                key = fXmlNodeOut.get_elem(FSQMSQS_SetModuleUpdate_Out.FModule.E_Module).get_elemVal(FSQMSQS_SetModuleUpdate_Out.FModule.A_UniqueId, FSQMSQS_SetModuleUpdate_Out.FModule.A_UniqueId);
                grdList.appendOrUpdateDataRow(key, cellValues);
                grdList.activateDataRow(key);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInMod = null;
                fXmlNodeOut = null;
                cellValues = null;

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

                initPropOfModule();
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

        #region btnDelete Control Event Handler

        private void btnDelete_Click(
            object sender,
            EventArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMod = null;
            FXmlNode fXmlNodeOut = null;
            DialogResult dialogResult;

            try
            {
                FCursor.waitCursor();

                // --

                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fUIWizard.generateMessage("Q0003", new object[] { "Module" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --
                
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetModuleUpdate_In.E_SQMSQS_SetModuleUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleUpdate_In.A_hLanguage, FSQMSQS_SetModuleUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleUpdate_In.A_hStep, FSQMSQS_SetModuleUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInMod = fXmlNodeIn.set_elem(FSQMSQS_SetModuleUpdate_In.FModule.E_Module);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_System, FSQMSQS_SetModuleUpdate_In.FModule.D_System, ucbSystem.activeDataRowKey);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleUpdate_In.FModule.A_Module, FSQMSQS_SetModuleUpdate_In.FModule.D_Module, (string)row["Module"]);
                    // --
                    FSQMSQSCaster.SQMSQS_SetModuleUpdate_Req(
                        m_fSqmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleUpdate_Out.A_hStatus, FSQMSQS_SetModuleUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleUpdate_Out.A_hStatusMessage, FSQMSQS_SetModuleUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdList.removeDataRow(row.Index);
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfModule();
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInMod = null;
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

                refreshGridOfModule();
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
                    FMessageBox.showInformation("Search", m_fSqmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
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

    }   // Class end
}   // Namespace end
