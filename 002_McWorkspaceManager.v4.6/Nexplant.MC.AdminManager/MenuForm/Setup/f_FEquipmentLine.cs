/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_EquipmentLine.cs
--  Creator         : iskim
--  Create Date     : 2013.07.03
--  Description     : FAMate Admin Manager Setup Line Form Class 
--  History         : Created by iskim at 2013.07.03
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
    public partial class FEquipmentLine : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipmentLine(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentLine(
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

        private void designGridOfEquipmentLine(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Equipment Line");
                uds.Band.Columns.Add("Description");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Equipment Line"].CellAppearance.Image = Properties.Resources.EquipmentLine;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment Line"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment Line"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 300;
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

        private void refreshGridOfEquipmentLine(
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
                initPropOfEquipmentLine();

                //--

                grdList.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "EquipmentLine", "ListEquipmentLine", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Line
                            r[1].ToString()    // Description
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

        private void initPropOfEquipmentLine(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropEquipmentLine(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfEquipmentLine(
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
                fSqlParams.add("line", grdList.activeDataRowKey);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "EquipmentLine", "SearchEquipmentLine", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropEquipmentLine(m_fAdmCore, pgdProp, dt, m_tranEnabled);
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

        #region FEquipmentLine Form Event Handler

        private void FEquipmentLine_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EquipmentLine);

                // --

                designGridOfEquipmentLine();

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

        private void FEquipmentLine_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEquipmentLine(string.Empty);

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

        private void FEquipmentLine_FormClosing(
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

        private void FEquipmentLine_KeyDown(
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
                    refreshGridOfEquipmentLine(grdList.activeDataRowKey);
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

                setPropOfEquipmentLine();

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

                setPropOfEquipmentLine();
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
            FPropEquipmentLine fPropAre = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInAre = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropAre = (FPropEquipmentLine)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropAre.Line, true, this.fUIWizard, "Line");

                if (fPropAre.Line.Length > 30)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Line" }));
                }

                if (fPropAre.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEquipmentLineUpdate_In.E_ADMADS_SetEquipmentLineUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hLanguage, FADMADS_SetEquipmentLineUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hFactory, FADMADS_SetEquipmentLineUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hUserId, FADMADS_SetEquipmentLineUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hHostIp, FADMADS_SetEquipmentLineUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hHostName, FADMADS_SetEquipmentLineUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName); 
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hStep, FADMADS_SetEquipmentLineUpdate_In.D_hStep, "1");                
                // --
                fXmlNodeInAre = fXmlNodeIn.set_elem(FADMADS_SetEquipmentLineUpdate_In.FEquipmentLine.E_EquipmentLine);
                fXmlNodeInAre.set_elemVal(
                    FADMADS_SetEquipmentLineUpdate_In.FEquipmentLine.A_EquipmentLine, 
                    FADMADS_SetEquipmentLineUpdate_In.FEquipmentLine.D_EquipmentLine,
                    fPropAre.Line
                    );
                fXmlNodeInAre.set_elemVal(
                    FADMADS_SetEquipmentLineUpdate_In.FEquipmentLine.A_Description,
                    FADMADS_SetEquipmentLineUpdate_In.FEquipmentLine.D_Description,
                    fPropAre.Description
                    );

                // --

                FADMADSCaster.ADMADS_SetEquipmentLineUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentLineUpdate_Out.A_hStatus, FADMADS_SetEquipmentLineUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentLineUpdate_Out.A_hStatusMessage, FADMADS_SetEquipmentLineUpdate_Out.D_hStatusMessage)
                        );
                }

                // --
                
                cellValues = new object[]
                {
                    fPropAre.Line,
                    fPropAre.Description
                };
                // --
                key = fPropAre.Line;
                grdList.appendOrUpdateDataRow(key, cellValues);
                grdList.activateDataRow(key);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fPropAre = null;
                fXmlNodeIn = null;
                fXmlNodeInAre = null;
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

                initPropOfEquipmentLine();
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
            FXmlNode fXmlNodeInAre = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Equipment Line" }),
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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEquipmentLineUpdate_In.E_ADMADS_SetEquipmentLineUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hLanguage, FADMADS_SetEquipmentLineUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hFactory, FADMADS_SetEquipmentLineUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hUserId, FADMADS_SetEquipmentLineUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hHostIp, FADMADS_SetEquipmentLineUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hHostName, FADMADS_SetEquipmentLineUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentLineUpdate_In.A_hStep, FADMADS_SetEquipmentLineUpdate_In.D_hStep, "2");                
                // --
                fXmlNodeInAre = fXmlNodeIn.set_elem(FADMADS_SetEquipmentLineUpdate_In.FEquipmentLine.E_EquipmentLine);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInAre.set_elemVal(
                        FADMADS_SetEquipmentLineUpdate_In.FEquipmentLine.A_EquipmentLine,
                        FADMADS_SetEquipmentLineUpdate_In.FEquipmentLine.D_EquipmentLine, 
                        row["Equipment Line"].ToString()
                        );

                    // --
                    
                    FADMADSCaster.ADMADS_SetEquipmentLineUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentLineUpdate_Out.A_hStatus, FADMADS_SetEquipmentLineUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentLineUpdate_Out.A_hStatusMessage, FADMADS_SetEquipmentLineUpdate_Out.D_hStatusMessage)
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
                    initPropOfEquipmentLine();
                }    

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
                fXmlNodeInAre = null;
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

                refreshGridOfEquipmentLine(grdList.activeDataRowKey);
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
