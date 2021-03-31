/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FMaker.cs
--  Creator         : tjkim
--  Create Date     : 2012.05.21
--  Description     : FAMate Admin Manager Setup Maker Form Class 
--  History         : Created by tjkim at 2012.05.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win;

namespace Nexplant.MC.AdminManager
{
    public partial class FMaker : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMaker(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMaker(
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
                // --
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

        private void designGridOfMaker(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Maker");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Engineer");
                uds.Band.Columns.Add("Phone Office");
                uds.Band.Columns.Add("Phone Mobile");
                uds.Band.Columns.Add("e-Mail");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Maker"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdList.DisplayLayout.Bands[0].Columns["Engineer"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Phone Office"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Phone Mobile"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["e-Mail"].Width = 150;
                
                // --

                grdList.DisplayLayout.Bands[0].Columns["Maker"].CellAppearance.Image = Properties.Resources.Maker;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Maker"].Header.Fixed = true;
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

        private void refreshGridOfMaker(
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
                initPropOfMaker();
                
                // --

                grdList.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Maker", "ListMaker", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Maker
                            r[1].ToString(),   // Description
                            r[2].ToString(),   // Engineer
                            r[3].ToString(),   // Phone Office 
                            r[4].ToString(),   // Phone Mobile 
                            r[5].ToString()    // EMail ID 
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

        private void initPropOfMaker(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropMaker(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfMaker(
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
                fSqlParams.add("maker", grdList.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Maker", "SearchMaker", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropMaker(m_fAdmCore, pgdProp, dt, m_tranEnabled);                
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

        #region FMaker Form Event Handler

        private void FMaker_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Maker);

                // --

                designGridOfMaker();

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

        private void FMaker_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfMaker(string.Empty);

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

        private void FMaker_FormClosing(
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

        private void FMaker_KeyDown(
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
                    refreshGridOfMaker(grdList.activeDataRowKey);
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

                setPropOfMaker();

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

                setPropOfMaker();
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
            FPropMaker fPropMaker = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMak = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropMaker = (FPropMaker)pgdProp.selectedObject;

                // --
                
                #region Validation
                
                FCommon.validateName(fPropMaker.Maker, true, this.fUIWizard, "Maker");

                if (fPropMaker.Maker.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Maker" }));
                }

                // --

                if (fPropMaker.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                if (fPropMaker.Engineer.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Engineer" }));
                }

                // --

                if (fPropMaker.PhoneOffice.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Phone Office" }));
                }

                // --

                if (fPropMaker.PhoneMobile.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Phone Mobile" }));
                }

                // --

                if (fPropMaker.EmailId.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "e-Mail" }));
                }

                #endregion
                
                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetMakerUpdate_In.E_ADMADS_SetMakerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hLanguage, FADMADS_SetMakerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hFactory, FADMADS_SetMakerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hUserId, FADMADS_SetMakerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hHostIp, FADMADS_SetMakerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hHostName, FADMADS_SetMakerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hStep, FADMADS_SetMakerUpdate_In.D_hStep, "1");   
             
                // --

                fXmlNodeInMak = fXmlNodeIn.set_elem(FADMADS_SetMakerUpdate_In.FMaker.E_Maker);
                fXmlNodeInMak.set_elemVal(FADMADS_SetMakerUpdate_In.FMaker.A_Maker, FADMADS_SetMakerUpdate_In.FMaker.E_Maker, fPropMaker.Maker);
                fXmlNodeInMak.set_elemVal(FADMADS_SetMakerUpdate_In.FMaker.A_Description, FADMADS_SetMakerUpdate_In.FMaker.D_Description, fPropMaker.Description);
                fXmlNodeInMak.set_elemVal(FADMADS_SetMakerUpdate_In.FMaker.A_Engineer, FADMADS_SetMakerUpdate_In.FMaker.D_Engineer, fPropMaker.Engineer);
                fXmlNodeInMak.set_elemVal(FADMADS_SetMakerUpdate_In.FMaker.A_PhoneOffice, FADMADS_SetMakerUpdate_In.FMaker.D_PhoneOffice, fPropMaker.PhoneOffice);
                fXmlNodeInMak.set_elemVal(FADMADS_SetMakerUpdate_In.FMaker.A_PhoneMobile, FADMADS_SetMakerUpdate_In.FMaker.D_PhoneMobile, fPropMaker.PhoneMobile);
                fXmlNodeInMak.set_elemVal(FADMADS_SetMakerUpdate_In.FMaker.A_EmailId, FADMADS_SetMakerUpdate_In.FMaker.D_EmailId, fPropMaker.EmailId);
                
                // --

                FADMADSCaster.ADMADS_SetMakerUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetMakerUpdate_Out.A_hStatus, FADMADS_SetMakerUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetMakerUpdate_Out.A_hStatusMessage, FADMADS_SetMakerUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropMaker.Maker,
                    fPropMaker.Description,
                    fPropMaker.Engineer,
                    fPropMaker.PhoneOffice,
                    fPropMaker.PhoneMobile,
                    fPropMaker.EmailId
                };
                // --
                key = fPropMaker.Maker;
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
                fXmlNodeIn = null;
                fXmlNodeInMak = null;
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

                initPropOfMaker();
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
            FXmlNode fXmlNodeInMak = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Maker" }),
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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetMakerUpdate_In.E_ADMADS_SetMakerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hLanguage, FADMADS_SetMakerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hFactory, FADMADS_SetMakerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hUserId, FADMADS_SetMakerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hHostIp, FADMADS_SetMakerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hHostName, FADMADS_SetMakerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetMakerUpdate_In.A_hStep, FADMADS_SetMakerUpdate_In.D_hStep, "2"); 
               
                // --

                fXmlNodeInMak = fXmlNodeIn.set_elem(FADMADS_SetMakerUpdate_In.FMaker.E_Maker);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInMak.set_elemVal(FADMADS_SetMakerUpdate_In.FMaker.A_Engineer, FADMADS_SetMakerUpdate_In.FMaker.D_Engineer, row["Engineer"].ToString());
                    fXmlNodeInMak.set_elemVal(FADMADS_SetMakerUpdate_In.FMaker.A_Maker, FADMADS_SetMakerUpdate_In.FMaker.D_Maker, row["Maker"].ToString());

                    // --

                    FADMADSCaster.ADMADS_SetMakerUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetMakerUpdate_Out.A_hStatus, FADMADS_SetMakerUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetMakerUpdate_Out.A_hStatusMessage, FADMADS_SetMakerUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdList.removeDataRow(row.Index);
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfMaker();
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
                fXmlNodeInMak = null;
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

                refreshGridOfMaker(grdList.activeDataRowKey);
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
