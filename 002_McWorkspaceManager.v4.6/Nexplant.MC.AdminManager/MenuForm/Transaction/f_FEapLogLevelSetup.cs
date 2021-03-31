/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapLogLevelSetup.cs
--  Creator         : spike.lee
--  Create Date     : 2017.07.05
--  Description     : FAmate Admin Manager EAP Log Level Setup Transaction Form Class 
--  History         : Created by spike.lee at 2017.07.05
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
    public partial class FEapLogLevelSetup : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;
        private string[] m_logLevelCaption = null;
        private string m_beforeKey = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapLogLevelSetup(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapLogLevelSetup(
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
                if (grdList.Rows.Count == 0)
                {
                    btnUpdate.Enabled = false;
                }
                else
                {
                    btnUpdate.Enabled = m_tranEnabled;
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

        private void designGridOfList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Description");
                // --
                uds.Band.Columns.Add("Level 1");
                uds.Band.Columns.Add("Level 2");
                uds.Band.Columns.Add("Level 3");
                uds.Band.Columns.Add("Level 4");
                uds.Band.Columns.Add("Level 5");
                uds.Band.Columns.Add("Level 6");
                uds.Band.Columns.Add("Level 7");
                uds.Band.Columns.Add("Level 8");
                uds.Band.Columns.Add("Level 9");
                uds.Band.Columns.Add("Level 10");
                
                // --

                grdList.DisplayLayout.Bands[0].Columns["EAP"].CellAppearance.Image = Properties.Resources.Eap;
                // --
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Level 1"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Level 2"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Level 3"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Level 4"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Level 5"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Level 6"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Level 7"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Level 8"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Level 9"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Level 10"].Width = 80;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Level 1"].Header.Caption = m_logLevelCaption[0];
                grdList.DisplayLayout.Bands[0].Columns["Level 2"].Header.Caption = m_logLevelCaption[1];
                grdList.DisplayLayout.Bands[0].Columns["Level 3"].Header.Caption = m_logLevelCaption[2];
                grdList.DisplayLayout.Bands[0].Columns["Level 4"].Header.Caption = m_logLevelCaption[3];
                grdList.DisplayLayout.Bands[0].Columns["Level 5"].Header.Caption = m_logLevelCaption[4];
                grdList.DisplayLayout.Bands[0].Columns["Level 6"].Header.Caption = m_logLevelCaption[5];
                grdList.DisplayLayout.Bands[0].Columns["Level 7"].Header.Caption = m_logLevelCaption[6];
                grdList.DisplayLayout.Bands[0].Columns["Level 8"].Header.Caption = m_logLevelCaption[7];
                grdList.DisplayLayout.Bands[0].Columns["Level 9"].Header.Caption = m_logLevelCaption[8];
                grdList.DisplayLayout.Bands[0].Columns["Level 10"].Header.Caption = m_logLevelCaption[9];
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

        private void refreshGridOfList(
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
                initPropOfEapLogLevelSetup();

                // --

                grdList.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Transaction", "EapLogLevelSetup", "ListEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),    // EAP
                            r[1].ToString(),    // Description                            
                            (r[2].ToString().Trim() == string.Empty ? FYesNo.Yes.ToString() : r[2].ToString()),     // Log Level 1
                            (r[3].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : r[3].ToString()),      // Log Level 2
                            (r[4].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : r[4].ToString()),      // Log Level 3
                            (r[5].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : r[5].ToString()),      // Log Level 4
                            (r[6].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : r[6].ToString()),      // Log Level 5
                            (r[7].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : r[7].ToString()),      // Log Level 6
                            (r[8].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : r[8].ToString()),      // Log Level 7
                            (r[9].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : r[9].ToString()),      // Log Level 8
                            (r[10].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : r[10].ToString()),    // Log Level 9
                            (r[11].ToString().Trim() == string.Empty ? FYesNo.No.ToString() : r[11].ToString())     // Log Level 10
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
                    if (m_beforeKey != string.Empty)
                    {
                        grdList.activateDataRow(m_beforeKey);
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

        private void initPropOfEapLogLevelSetup(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropEapLogLevelSetup(m_fAdmCore, pgdProp, m_logLevelCaption, m_tranEnabled);
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

        private void setPropOfEapLogLevelSetup(
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
                fSqlParams.add("eap", grdList.activeDataRowKey);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Transaction", "EapLogLevelSetup", "SearchEap", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropEapLogLevelSetup(m_fAdmCore, pgdProp, m_logLevelCaption, dt, m_tranEnabled);
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

        //------------------------------------------------------------------------------------------------------------------------

        private void loadLogLevelCatpion(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                m_logLevelCaption = new string[10];

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Transaction", "EapLogLevelSetup", "SearchFactory", fSqlParams, true);

                // --

                for (int i = 0; i < 10; i++)
                {
                    m_logLevelCaption[i] = dt.Rows[0][i].ToString();
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

        public void attach(
            string eapName
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_beforeKey = eapName;
                refreshGridOfList();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEapLogLevelSetup Form Event Handler

        private void FEapLogLevelSetup_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                loadLogLevelCatpion();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.EapLogLevelSetup);

                // --

                designGridOfList();

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

        private void FEapLogLevelSetup_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfList();

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

        private void FEapLogLevelSetup_FormClosing(
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

        private void FEapLogLevelSetup_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.KeyCode == Keys.F5)
                {
                    m_beforeKey = grdList.activeDataRowKey;
                    refreshGridOfList();
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

                setPropOfEapLogLevelSetup();

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

                setPropOfEapLogLevelSetup();
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
            FPropEapLogLevelSetup fPropEap = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeInLgv = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropEap = (FPropEapLogLevelSetup)pgdProp.selectedObject;

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_TrnEapLogLevelSetup_In.E_ADMADS_TrnEapLogLevelSetup_In);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.A_hLanguage, FADMADS_TrnEapLogLevelSetup_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.A_hFactory, FADMADS_TrnEapLogLevelSetup_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.A_hUserId, FADMADS_TrnEapLogLevelSetup_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.A_hHostIp, FADMADS_TrnEapLogLevelSetup_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.A_hHostName, FADMADS_TrnEapLogLevelSetup_In.D_hHostName, m_fAdmCore.fOption.hostName); 
                fXmlNodeIn.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.A_hStep, FADMADS_TrnEapLogLevelSetup_In.D_hStep, "1");                
                // --
                fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_TrnEapLogLevelSetup_In.FEap.E_Eap);
                fXmlNodeInEap.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.A_Name, FADMADS_TrnEapLogLevelSetup_In.FEap.D_Name, fPropEap.MC);
                // --
                fXmlNodeInLgv = fXmlNodeInEap.set_elem(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.E_LogLevel);
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel1, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel1, fPropEap.LogLevel1.ToString());
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel2, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel2, fPropEap.LogLevel2.ToString());
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel3, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel3, fPropEap.LogLevel3.ToString());
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel4, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel4, fPropEap.LogLevel4.ToString());
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel5, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel5, fPropEap.LogLevel5.ToString());
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel6, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel6, fPropEap.LogLevel6.ToString());
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel7, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel7, fPropEap.LogLevel7.ToString());
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel8, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel8, fPropEap.LogLevel8.ToString());
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel9, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel9, fPropEap.LogLevel9.ToString());
                fXmlNodeInLgv.set_elemVal(FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.A_LogLevel10, FADMADS_TrnEapLogLevelSetup_In.FEap.FLogLevel.D_LogLevel10, fPropEap.LogLevel10.ToString());
                
                // --

                FADMADSCaster.ADMADS_TrnEapLogLevelSetup_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_TrnEapLogLevelSetup_Out.A_hStatus, FADMADS_TrnEapLogLevelSetup_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_TrnEapLogLevelSetup_Out.A_hStatusMessage, FADMADS_TrnEapLogLevelSetup_Out.D_hStatusMessage)
                        );
                }

                // --
                
                cellValues = new object[]
                {
                    fPropEap.MC,
                    fPropEap.Description,
                    fPropEap.LogLevel1.ToString(),
                    fPropEap.LogLevel2.ToString(),
                    fPropEap.LogLevel3.ToString(),
                    fPropEap.LogLevel4.ToString(),
                    fPropEap.LogLevel5.ToString(),
                    fPropEap.LogLevel6.ToString(),
                    fPropEap.LogLevel7.ToString(),
                    fPropEap.LogLevel8.ToString(),
                    fPropEap.LogLevel9.ToString(),
                    fPropEap.LogLevel10.ToString()
                };
                // --
                key = fPropEap.MC;
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
                fPropEap = null;
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeInLgv = null;
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

                m_beforeKey = grdList.activeDataRowKey;
                refreshGridOfList();
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
