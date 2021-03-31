/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FCustomRemoteCommand.cs
--  Creator         : mjkim
--  Create Date     : 2013.06.11
--  Description     : FAMate Admin Manager Setup Custom Remote Command Form Class 
--  History         : Created by mjkim at 2013.06.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using System.Collections.Generic;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FCustomRemoteCommand : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
    
        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCustomRemoteCommand(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FCustomRemoteCommand(
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

        private void initPropOfCommand(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropCustomRemoteCommand(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfCommand(
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
                fSqlParams.add("command", grdList.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "CustomRemoteCommand", "SearchCommand", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropCustomRemoteCommand(m_fAdmCore, pgdProp, dt, m_tranEnabled);
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

        private void designGridOfCommand(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Command ");
                uds.Band.Columns.Add("Description");
                
                // --

                grdList.DisplayLayout.Bands[0].Columns["Command "].CellAppearance.Image = Properties.Resources.Command;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Command "].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Command "].Width = 268;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfCommand(
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
                //--
                initPropOfCommand();
                
                //--

                grdList.beginUpdate();

                //--

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                //--
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "CustomRemoteCommand", "ListCommand", fSqlParams, false, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Command
                            r[1].ToString(),   // Description
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
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];                        
                    }
                }

                // --

                refreshTotal();

                //--

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

        #region FCustomRemoteCommand Form Event Handler

        private void FCustomRemoteCommand_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.CustomRemoteCommand);

                // --

                designGridOfCommand();

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

        private void FCustomRemoteCommand_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfCommand(string.Empty);

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

        private void FCustomRemoteCommand_FormClosing(
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

        private void FCustomRemoteCommand_KeyDown(
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
                    refreshGridOfCommand(grdList.activeDataRowKey);
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

                setPropOfCommand();

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

                setPropOfCommand();
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
            FPropCustomRemoteCommand fPropCmd = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInCmd = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;            

            try
            {
                FCursor.waitCursor();

                // --

                fPropCmd = (FPropCustomRemoteCommand)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropCmd.Command, true, this.fUIWizard, "Command");
                if (fPropCmd.Command.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Command" }));
                }

                if (fPropCmd.Description.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                if (fPropCmd.Data_1_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 1" }));
                }

                if (fPropCmd.Data_2_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 2" }));
                }

                if (fPropCmd.Data_3_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 3" }));
                }

                if (fPropCmd.Data_4_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 4" }));
                }

                if (fPropCmd.Data_5_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 5" }));
                }

                if (fPropCmd.Data_6_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 6" }));
                }

                if (fPropCmd.Data_7_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 7" }));
                }

                if (fPropCmd.Data_8_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 8" }));
                }

                if (fPropCmd.Data_9_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 9" }));
                }

                if (fPropCmd.Data_10_Prt.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Data 10" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetCustomRemoteCommandUpdate_In.E_ADMADS_SetCustomRemoteCommandUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hLanguage, FADMADS_SetCustomRemoteCommandUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hFactory, FADMADS_SetCustomRemoteCommandUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hUserId, FADMADS_SetCustomRemoteCommandUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hHostIp, FADMADS_SetCustomRemoteCommandUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hHostName, FADMADS_SetCustomRemoteCommandUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hStep, FADMADS_SetCustomRemoteCommandUpdate_In.D_hStep, "1");
                
                // --
                
                fXmlNodeInCmd = fXmlNodeIn.set_elem(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.E_CustomRemoteCommand);
                fXmlNodeInCmd.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_Command, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_Command, fPropCmd.Command);
                fXmlNodeInCmd.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_Description, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_Description, fPropCmd.Description);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_1_Prt);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_2_Prt);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_3_Prt);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_4_Prt);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_5_Prt);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_6_Prt);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_7_Prt);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_8_Prt);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_9_Prt);
                fXmlNodeInCmd.add_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_DataPrompt, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_DataPrompt, fPropCmd.Data_10_Prt);
                
                // --
                
                FADMADSCaster.ADMADS_SetCustomRemoteCommandUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetCustomRemoteCommandUpdate_Out.A_hStatus, FADMADS_SetCustomRemoteCommandUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetCustomRemoteCommandUpdate_Out.A_hStatusMessage, FADMADS_SetCustomRemoteCommandUpdate_Out.D_hStatusMessage)
                        );
                }

                // --

                cellValues = new object[]
                {
                    fPropCmd.Command,
                    fPropCmd.Description
                };
                // --
                key = fPropCmd.Command;                
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
                fPropCmd = null;
                fXmlNodeIn = null;
                fXmlNodeInCmd = null;
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

                initPropOfCommand();
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
            FXmlNode fXmlNodeInCmd = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Command" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                //--

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetCustomRemoteCommandUpdate_In.E_ADMADS_SetCustomRemoteCommandUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hLanguage, FADMADS_SetCustomRemoteCommandUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hFactory, FADMADS_SetCustomRemoteCommandUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hUserId, FADMADS_SetCustomRemoteCommandUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hHostIp, FADMADS_SetCustomRemoteCommandUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hHostName, FADMADS_SetCustomRemoteCommandUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.A_hStep, FADMADS_SetCustomRemoteCommandUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInCmd = fXmlNodeIn.set_elem(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.E_CustomRemoteCommand);

                // --

                foreach (UltraDataRow dr in grdList.selectedDataRows)
                {
                    fXmlNodeInCmd.set_elemVal(FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.A_Command, FADMADS_SetCustomRemoteCommandUpdate_In.FCustomRemoteCommand.D_Command, dr["Command "].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetCustomRemoteCommandUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetCustomRemoteCommandUpdate_Out.A_hStatus, FADMADS_SetCustomRemoteCommandUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetCustomRemoteCommandUpdate_Out.A_hStatusMessage, FADMADS_SetCustomRemoteCommandUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdList.removeDataRow(dr.Index);
                }

                // --

                grdList.endUpdate();                

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfCommand();
                }

                // --

                refreshTotal();

                //--

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
                fXmlNodeInCmd = null;
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

                refreshGridOfCommand(grdList.activeDataRowKey);
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
