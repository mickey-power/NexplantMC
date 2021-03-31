/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FUserGroupApplication.cs
--  Creator         : mjkim
--  Create Date     : 2013.01.28
--  Description     : FAMate Admin Manager Setup User Group Application Form Class 
--  History         : Created by mjkim at 2013.01.28
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
    public partial class FUserGroupApplication : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FUserGroupApplication(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUserGroupApplication(
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

                if (key == "User Group Application")
                {
                    btnDelete.Enabled = grdApp.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdApp.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "User Group Function")
                {
                    btnDelete.Enabled = grdFun.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = grdApp.activeDataRowKey != string.Empty && m_tranEnabled; 
                    btnClear.Enabled = grdFun.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void designGridOfApp(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdApp.dataSource;
                // --
                uds.Band.Columns.Add("Application");
                uds.Band.Columns.Add("Description");

                // --

                grdApp.DisplayLayout.Bands[0].Columns["Application"].CellAppearance.Image = Properties.Resources.UserGroupApplication;
                // --
                grdApp.DisplayLayout.Bands[0].Columns["Application"].Header.Fixed = true;
                // --
                grdApp.DisplayLayout.Bands[0].Columns["Application"].Width = 150;
                grdApp.DisplayLayout.Bands[0].Columns["Description"].Width = 300;
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

        private void refreshGridOfApp(
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
                grdApp.removeAllDataRow();
                grdFun.removeAllDataRow();
                grdApp.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdFun.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfApp();
                initPropOfFun();
                // --
                refreshFunctionTotal();

                // --

                grdApp.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserGroupApplication", "ListApplication", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Application
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[0];
                        grdApp.appendDataRow(key, cellValues);
                    }

                } while (nextRowNumber >= 0);
                
                // --

                grdApp.endUpdate();

                // --

                if (grdApp.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdApp.activateDataRow(beforeKey);
                    }
                    if (grdApp.activeDataRow == null)
                    {
                        grdApp.ActiveRow = grdApp.Rows[0];
                    }
                }

                // --

                refreshApplicationTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "User Group Application")
                {
                    grdApp.Focus();
                }
            }
            catch (Exception ex)
            {
                grdApp.endUpdate();
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

        private void initPropOfApp(
            )
        {
            try
            {
                pgdApp.selectedObject = new FPropUserGroupApplication(m_fAdmCore, pgdApp, m_tranEnabled);
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

        private void setPropOfApp(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            
            try
            {
                if (grdApp.activeDataRow == null)
                {
                    return;
                }

                // --                

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("app", grdApp.activeDataRowKey);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserGroupApplication", "SearchApplication", fSqlParams, true);

                // --

                pgdApp.selectedObject = new FPropUserGroupApplication(m_fAdmCore, pgdApp, dt, m_tranEnabled);
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

        private void designGridOfFun(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdFun.dataSource;
                // --
                uds.Band.Columns.Add("Application");
                uds.Band.Columns.Add("Function");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Used Transaction");

                // --

                grdFun.DisplayLayout.Bands[0].Columns["Application"].CellAppearance.Image = Properties.Resources.UserGroupFunction;
                // --
                grdFun.DisplayLayout.Bands[0].Columns["Application"].Width = 150;
                grdFun.DisplayLayout.Bands[0].Columns["Function"].Width = 200;
                grdFun.DisplayLayout.Bands[0].Columns["Description"].Width = 250;
                grdFun.DisplayLayout.Bands[0].Columns["Used Transaction"].Width = 33;
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

        private void refreshGridOfFun(
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
                grdFun.removeAllDataRow();
                grdFun.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfFun();

                // --

                if (grdApp.ActiveRow == null)
                {
                    return;
                }
                
                // --

                grdFun.beginUpdate();

                // --                

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("app", grdApp.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserGroupFunction", "ListFunction", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            grdApp.activeDataRowKey,
                            r[0].ToString(),   // Function
                            r[1].ToString(),   // Description
                            r[2].ToString()    // Used Transaction
                            };
                        key = (string)cellValues[1];
                        grdFun.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdFun.endUpdate();

                // --

                if (grdFun.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdFun.activateDataRow(beforeKey);
                    }
                    if (grdFun.activeDataRow == null)
                    {
                        grdFun.ActiveRow = grdFun.Rows[0];
                    }
                }

                // --

                refreshFunctionTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "User Group Function")
                {
                    grdFun.Focus();
                }
            }
            catch (Exception ex)
            {
                grdFun.endUpdate();
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

        private void initPropOfFun(
            )
        {
            try
            {
                pgdFun.selectedObject = new FPropUserGroupFunction(m_fAdmCore, pgdFun, grdApp.activeDataRowKey, m_tranEnabled);
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

        private void setPropOfFun(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdFun.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("app", grdApp.activeDataRowKey);
                fSqlParams.add("fun", grdFun.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserGroupFunction", "SearchFunction", fSqlParams, true);

                // --

                pgdFun.selectedObject = new FPropUserGroupFunction(m_fAdmCore, pgdFun, grdApp.activeDataRowKey, dt, m_tranEnabled);
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

        private void updateGridOfApplication(
            )
        {
            FPropUserGroupApplication fPropApp = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInApp = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropApp = (FPropUserGroupApplication)pgdApp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropApp.Application, true, this.fUIWizard, "Application");

                if (fPropApp.Application.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Application" }));
                }

                if (fPropApp.Description.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserGroupApplicationUpdate_In.E_ADMADS_SetUserGroupApplicationUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hLanguage, FADMADS_SetUserGroupApplicationUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hFactory, FADMADS_SetUserGroupApplicationUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hUserId, FADMADS_SetUserGroupApplicationUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hHostIp, FADMADS_SetUserGroupApplicationUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hHostName, FADMADS_SetUserGroupApplicationUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hStep, FADMADS_SetUserGroupApplicationUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInApp = fXmlNodeIn.set_elem(FADMADS_SetUserGroupApplicationUpdate_In.FApplication.E_Application);
                fXmlNodeInApp.set_elemVal(
                    FADMADS_SetUserGroupApplicationUpdate_In.FApplication.A_Application,
                    FADMADS_SetUserGroupApplicationUpdate_In.FApplication.D_Application,
                    fPropApp.Application
                    );
                fXmlNodeInApp.set_elemVal(
                    FADMADS_SetUserGroupApplicationUpdate_In.FApplication.A_Description,
                    FADMADS_SetUserGroupApplicationUpdate_In.FApplication.D_Description,
                    fPropApp.Description
                    );

                // --

                FADMADSCaster.ADMADS_SetUserGroupApplicationUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupApplicationUpdate_Out.A_hStatus, FADMADS_SetUserGroupApplicationUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupApplicationUpdate_Out.A_hStatusMessage, FADMADS_SetUserGroupApplicationUpdate_Out.D_hStatusMessage)
                        );
                }

                // --

                cellValues = new object[]
                {
                    fPropApp.Application,
                    fPropApp.Description
                };
                // --
                key = fPropApp.Application;
                grdApp.appendOrUpdateDataRow(key, cellValues);
                grdApp.activateDataRow(key);

                // --

                refreshApplicationTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropApp = null;
                fXmlNodeIn = null;
                fXmlNodeInApp = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfFunction(
            )
        {
            FPropUserGroupFunction fPropFun = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropFun = (FPropUserGroupFunction)pgdFun.selectedObject;

                // --

                #region Validation

                if (fPropFun.Function.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Function" }));
                }

                if (fPropFun.Function.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Function" }));
                }

                if (fPropFun.Description.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserGroupFunctionUpdate_In.E_ADMADS_SetUserGroupFunctionUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hLanguage, FADMADS_SetUserGroupFunctionUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hFactory, FADMADS_SetUserGroupFunctionUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hUserId, FADMADS_SetUserGroupFunctionUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hHostIp, FADMADS_SetUserGroupFunctionUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hHostName, FADMADS_SetUserGroupFunctionUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hStep, FADMADS_SetUserGroupFunctionUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInFun = fXmlNodeIn.set_elem(FADMADS_SetUserGroupFunctionUpdate_In.FFunction.E_Function);
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.A_Application,
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.D_Application,
                    grdApp.activeDataRowKey
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.A_Function,
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.D_Function,
                    fPropFun.Function
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.A_Description,
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.D_Description,
                    fPropFun.Description
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.A_UsedTransaction,
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.D_UsedTransaction,
                    fPropFun.UsedTransaction.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_SetUserGroupFunctionUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupFunctionUpdate_Out.A_hStatus, FADMADS_SetUserGroupFunctionUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupFunctionUpdate_Out.A_hStatusMessage));
                }

                // --

                cellValues = new object[] {
                    grdApp.activeDataRowKey,
                    fPropFun.Function,   
                    fPropFun.Description,   
                    fPropFun.UsedTransaction.ToString()  
                    };
                // --
                key = fPropFun.Function;
                grdFun.appendOrUpdateDataRow(key, cellValues);
                grdFun.activateDataRow(key);

                // --

                refreshFunctionTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropFun = null;
                fXmlNodeIn = null;
                fXmlNodeInFun = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfApplication(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInApp = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Application" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdApp.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserGroupApplicationUpdate_In.E_ADMADS_SetUserGroupApplicationUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hLanguage, FADMADS_SetUserGroupApplicationUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hFactory, FADMADS_SetUserGroupApplicationUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hUserId, FADMADS_SetUserGroupApplicationUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hHostIp, FADMADS_SetUserGroupApplicationUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hHostName, FADMADS_SetUserGroupApplicationUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupApplicationUpdate_In.A_hStep, FADMADS_SetUserGroupApplicationUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInApp = fXmlNodeIn.set_elem(FADMADS_SetUserGroupApplicationUpdate_In.FApplication.E_Application);

                // --

                foreach (UltraDataRow row in grdApp.selectedDataRows)
                {
                    fXmlNodeInApp.set_elemVal(
                        FADMADS_SetUserGroupApplicationUpdate_In.FApplication.A_Application,
                        FADMADS_SetUserGroupApplicationUpdate_In.FApplication.D_Application,
                        row["Application"].ToString()
                        );

                    // --

                    FADMADSCaster.ADMADS_SetUserGroupApplicationUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupApplicationUpdate_Out.A_hStatus, FADMADS_SetUserGroupApplicationUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupApplicationUpdate_Out.A_hStatusMessage, FADMADS_SetUserGroupApplicationUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdApp.removeDataRow(row.Index);
                }

                // --

                grdApp.endUpdate();

                // --

                refreshApplicationTotal();

                // --

                if (grdApp.Rows.Count == 0)
                {
                    initPropOfApp();
                    initPropOfFun();
                }

                // --
                
                controlButton();
            }
            catch (Exception ex)
            {
                grdApp.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInApp = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfFunction(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Function" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdFun.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserGroupFunctionUpdate_In.E_ADMADS_SetUserGroupFunctionUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hLanguage, FADMADS_SetUserGroupFunctionUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hFactory, FADMADS_SetUserGroupFunctionUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hUserId, FADMADS_SetUserGroupFunctionUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hHostIp, FADMADS_SetUserGroupFunctionUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hHostName, FADMADS_SetUserGroupFunctionUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupFunctionUpdate_In.A_hStep, FADMADS_SetUserGroupFunctionUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInFun = fXmlNodeIn.set_elem(FADMADS_SetUserGroupFunctionUpdate_In.FFunction.E_Function);
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.A_Application,
                    FADMADS_SetUserGroupFunctionUpdate_In.FFunction.D_Application,
                    grdApp.activeDataRowKey
                    );

                // --

                foreach (UltraDataRow row in grdFun.selectedDataRows)
                {
                    fXmlNodeInFun.set_elemVal(
                        FADMADS_SetUserGroupFunctionUpdate_In.FFunction.A_Function,
                        FADMADS_SetUserGroupFunctionUpdate_In.FFunction.D_Function,
                        row["Function"].ToString()
                        );

                    // --

                    FADMADSCaster.ADMADS_SetUserGroupFunctionUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupFunctionUpdate_Out.A_hStatus, FADMADS_SetUserGroupFunctionUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupFunctionUpdate_Out.A_hStatusMessage, FADMADS_SetUserGroupFunctionUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdFun.removeDataRow(row.Index);
                }

                // --

                grdFun.endUpdate();

                // --

                refreshFunctionTotal();

                // --

                if (grdFun.Rows.Count == 0)
                {
                    initPropOfFun();
                }

                // --
                
                controlButton();
            }
            catch (Exception ex)
            {
                grdFun.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInFun = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshApplicationTotal(
            )
        {
            try
            {
                lblAppTotal.Text = grdApp.Rows.Count.ToString("#,##0");
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

        private void refreshFunctionTotal(
            )
        {
            try
            {
                lblFunTotal.Text = grdFun.Rows.Count.ToString("#,##0");
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

        #region FUserGroupApplication Form Event Handler

        private void FUserGroupApplication_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.UserGroupApplication);

                // --

                designGridOfApp();
                designGridOfFun();

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

        private void FUserGroupApplication_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfApp(string.Empty);

                // --

                grdApp.Focus();
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

        private void FUserGroupApplication_FormClosing(
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

        private void FUserGroupApplication_KeyDown(
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
                    if (tabMain.ActiveTab.Key == "User Group Application")
                    {
                        refreshGridOfApp(grdApp.activeDataRowKey);
                    }                    
                    else
                    {
                        refreshGridOfFun(grdFun.activeDataRowKey);
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

        #region grdApp Control Event Handler

        private void grdApp_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfApp();

                // --

                refreshGridOfFun(string.Empty);
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

        private void grdApp_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.SelectedTab = tabMain.Tabs["User Group Function"];

                // --

                grdFun.Focus();
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

        private void grdApp_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfApp();
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

        #region grdFun Control Event Handler

        private void grdFun_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfFun();

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

        private void grdFun_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfFun();
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
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                key = tabMain.ActiveTab.Key;

                // --

                if (key == "User Group Application")
                {
                    updateGridOfApplication();
                }
                else if (key == "User Group Function")
                {
                    updateGridOfFunction();
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

        #region btnClear Control Event Handler

        private void btnClear_Click(
            object sender,
            EventArgs e
            )
        {
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                key = tabMain.ActiveTab.Key;

                // --

                if (key == "User Group Application")
                {
                    initPropOfApp();
                }
                else if (key == "User Group Function")
                {
                    initPropOfFun();
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

        #region btnDelete Control Event Handler

        private void btnDelete_Click(
            object sender,
            EventArgs e
            )
        {
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                key = tabMain.ActiveTab.Key;

                // --

                if (key == "User Group Application")
                {
                    deleteGridOfApplication();
                }
                else if (key == "User Group Function")
                {
                    deleteGridOfFunction();
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

        #region rstAppToolbar Control Event Handler

        private void rstAppToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfApp(grdApp.activeDataRowKey);
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

        private void rstAppToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdApp.searchGridRow(e.searchWord))
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

        #region rstFunToolbar Control Event Handler

        private void rstFunToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfFun(grdFun.activeDataRowKey);
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

        private void rstFunToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdFun.searchGridRow(e.searchWord))
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

    }   // Class end
}   // Namespace end
