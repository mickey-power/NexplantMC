/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FFactory.cs
--  Creator         : mj.kim
--  Create Date     : 2012.01.09
--  Description     : FAMate Admin Manager Setup Factory Form Class 
--  History         : Created by mj.kim at 2012.01.09
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
    public partial class FFactory : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
    
        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFactory(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FFactory(
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

        private void designGridOfFactory(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Factory");
                uds.Band.Columns.Add("Description");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Factory"].Width = 260;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 255;
                
                // --

                grdList.DisplayLayout.Bands[0].Columns["Factory"].CellAppearance.Image = Properties.Resources.Factory;

                // --
                
                grdList.DisplayLayout.Bands[0].Columns["Factory"].Header.Fixed = true;
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

        private void refreshGridOfFactory(
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
                initPropOfFactory();

                // --

                grdList.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Factory", "ListFactory", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Factory
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

        private void initPropOfFactory(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropFactory(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfFactory(
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
                fSqlParams.add("factory", grdList.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Factory", "SearchFactory", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropFactory(m_fAdmCore, pgdProp, dt, m_tranEnabled);
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

        #region FFactory Form Event Handler

        private void FFactory_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Factory);

                // --

                designGridOfFactory();

                // --

                controlButton();

                // -- 

                m_fAdmCore.fOption.fChildFormList.add(this);

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

        private void FFactory_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfFactory(string.Empty);

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

        private void FFactory_FormClosing(
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

        private void FFactory_KeyDown(
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
                    refreshGridOfFactory(grdList.activeDataRowKey);
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

                setPropOfFactory();

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

                setPropOfFactory();
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
            FPropFactory fPropFac = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFac = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;            

            try
            {
                FCursor.waitCursor();

                // --

                fPropFac = (FPropFactory)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropFac.Factory, true, this.fUIWizard, "Factory");

                if (fPropFac.Factory.Length > 10)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Factory" }));
                }

                if (fPropFac.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                if (fPropFac.ServerCpuDangerRate < 0 || fPropFac.ServerCpuDangerRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "Server CPU Danger Rate" }));
                }

                if (fPropFac.ServerCpuCautionRate < 0 || fPropFac.ServerCpuCautionRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "Server CPU Caution Rate" }));
                }

                if (fPropFac.ServerMemoryDangerRate < 0 || fPropFac.ServerMemoryDangerRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "Server Memory Danger Rate" }));
                }

                if (fPropFac.ServerMemoryCautionRate < 0 || fPropFac.ServerMemoryCautionRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "Server Memory Caution Rate" }));
                }

                if (fPropFac.ServerDiskDangerRate < 0 || fPropFac.ServerDiskDangerRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "Server Disk Danger Rate" }));
                }

                if (fPropFac.ServerDiskCautionRate < 0 || fPropFac.ServerDiskCautionRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "Server Disk Caution Rate" }));
                }

                // --

                if (fPropFac.EapCpuDangerRate < 0 || fPropFac.EapCpuDangerRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "EAP CPU Danger Rate" }));
                }

                if (fPropFac.EapCpuCautionRate < 0 || fPropFac.EapCpuCautionRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "EAP CPU Caution Rate" }));
                }

                if (fPropFac.EapMemoryDangerRate < 0 || fPropFac.EapMemoryDangerRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "EAP Memory Danger Rate" }));
                }

                if (fPropFac.EapMemoryCautionRate < 0 || fPropFac.EapMemoryCautionRate > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "EAP Memory Caution Rate" }));
                }

                if (fPropFac.EapDiskDangerRate < 0)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "EAP Disk Danger Rate" }));
                }

                if (fPropFac.EapDiskCautionRate < 0)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "EAP Disk Caution Rate" }));
                }

                if (fPropFac.EapReloadLimit < 0)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "EAP Reload Limit" }));
                }

                // --

                if (fPropFac.LogLevel1.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 1" }));
                }
                else if (fPropFac.LogLevel1.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 1" }));
                }

                if (fPropFac.LogLevel2.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 2" }));
                }
                else if (fPropFac.LogLevel2.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 2" }));
                }

                if (fPropFac.LogLevel3.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 3" }));
                }
                else if (fPropFac.LogLevel3.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 3" }));
                }

                if (fPropFac.LogLevel4.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 4" }));
                }
                else if (fPropFac.LogLevel4.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 4" }));
                }

                if (fPropFac.LogLevel5.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 5" }));
                }
                else if (fPropFac.LogLevel5.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 5" }));
                }

                if (fPropFac.LogLevel6.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 6" }));
                }
                else if (fPropFac.LogLevel6.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 6" }));
                }

                if (fPropFac.LogLevel7.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 7" }));
                }
                else if (fPropFac.LogLevel7.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 7" }));
                }

                if (fPropFac.LogLevel8.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 8" }));
                }
                else if (fPropFac.LogLevel8.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 8" }));
                }

                if (fPropFac.LogLevel9.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 9" }));
                }
                else if (fPropFac.LogLevel9.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 9" }));
                }

                if (fPropFac.LogLevel10.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Log Level Caption 10" }));
                }
                else if (fPropFac.LogLevel10.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Log Level Caption 10" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetFactoryUpdate_In.E_ADMADS_SetFactoryUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hLanguage, FADMADS_SetFactoryUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hFactory, FADMADS_SetFactoryUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hUserId, FADMADS_SetFactoryUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hHostIp, FADMADS_SetFactoryUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hHostName, FADMADS_SetFactoryUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hStep, FADMADS_SetFactoryUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInFac = fXmlNodeIn.set_elem(FADMADS_SetFactoryUpdate_In.FFactory.E_Factory);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_Factory, FADMADS_SetFactoryUpdate_In.FFactory.D_Factory, fPropFac.Factory);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_Description, FADMADS_SetFactoryUpdate_In.FFactory.D_Description, fPropFac.Description);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_ServerCpuDangerRate, FADMADS_SetFactoryUpdate_In.FFactory.D_ServerCpuDangerRate, fPropFac.ServerCpuDangerRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_ServerCpuCautionRate, FADMADS_SetFactoryUpdate_In.FFactory.D_ServerCpuCautionRate, fPropFac.ServerCpuCautionRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_ServerMemoryDangerRate, FADMADS_SetFactoryUpdate_In.FFactory.D_ServerMemoryDangerRate, fPropFac.ServerMemoryDangerRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_ServerMemoryCautionRate, FADMADS_SetFactoryUpdate_In.FFactory.D_ServerMemoryCautionRate, fPropFac.ServerMemoryCautionRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_ServerDiskDangerRate, FADMADS_SetFactoryUpdate_In.FFactory.D_ServerDiskDangerRate, fPropFac.ServerDiskDangerRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_ServerDiskCautionRate, FADMADS_SetFactoryUpdate_In.FFactory.D_ServerDiskCautionRate, fPropFac.ServerDiskCautionRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_EapCpuDangerRate, FADMADS_SetFactoryUpdate_In.FFactory.D_EapCpuDangerRate, fPropFac.EapCpuDangerRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_EapCpuCautionRate, FADMADS_SetFactoryUpdate_In.FFactory.D_EapCpuCautionRate, fPropFac.EapCpuCautionRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_EapMemoryDangerRate, FADMADS_SetFactoryUpdate_In.FFactory.D_EapMemoryDangerRate, fPropFac.EapMemoryDangerRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_EapMemoryCautionRate, FADMADS_SetFactoryUpdate_In.FFactory.D_EapMemoryCautionRate, fPropFac.EapMemoryCautionRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_EapDiskDangerRate, FADMADS_SetFactoryUpdate_In.FFactory.D_EapDiskDangerRate, fPropFac.EapDiskDangerRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_EapDiskCautionRate, FADMADS_SetFactoryUpdate_In.FFactory.D_EapDiskCautionRate, fPropFac.EapDiskCautionRate.ToString());
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_EapReloadLimit, FADMADS_SetFactoryUpdate_In.FFactory.D_EapReloadLimit, fPropFac.EapReloadLimit.ToString());
                // --
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap1, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap1, fPropFac.LogLevel1);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap2, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap2, fPropFac.LogLevel2);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap3, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap3, fPropFac.LogLevel3);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap4, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap4, fPropFac.LogLevel4);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap5, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap5, fPropFac.LogLevel5);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap6, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap6, fPropFac.LogLevel6);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap7, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap7, fPropFac.LogLevel7);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap8, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap8, fPropFac.LogLevel8);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap9, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap9, fPropFac.LogLevel9);
                fXmlNodeInFac.set_elemVal(FADMADS_SetFactoryUpdate_In.FFactory.A_LogLevelCap10, FADMADS_SetFactoryUpdate_In.FFactory.D_LogLevelCap10, fPropFac.LogLevel10);

                // --

                FADMADSCaster.ADMADS_SetFactoryUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetFactoryUpdate_Out.A_hStatus, FADMADS_SetFactoryUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetFactoryUpdate_Out.A_hStatusMessage, FADMADS_SetFactoryUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropFac.Factory,
                    fPropFac.Description
                };
                // --
                key = fPropFac.Factory;                
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
                fPropFac = null;
                fXmlNodeIn = null;
                fXmlNodeInFac = null;
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

                initPropOfFactory();
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
            FXmlNode fXmlNodeInFac = null;
            FXmlNode fXmlNodeOut = null;
            FPropFactory fPropFac = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (
                    FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Factory" }),
                        MessageBoxButtons.YesNo,
                        MessageBoxDefaultButton.Button2,
                        this
                        ) == DialogResult.No
                    )
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                //--

                fPropFac = (FPropFactory)pgdProp.selectedObject;

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetFactoryUpdate_In.E_ADMADS_SetFactoryUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hLanguage, FADMADS_SetFactoryUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hFactory, FADMADS_SetFactoryUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hUserId, FADMADS_SetFactoryUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hHostIp, FADMADS_SetFactoryUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hHostName, FADMADS_SetFactoryUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetFactoryUpdate_In.A_hStep, FADMADS_SetFactoryUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInFac = fXmlNodeIn.set_elem(FADMADS_SetFactoryUpdate_In.FFactory.E_Factory);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInFac.set_elemVal(
                        FADMADS_SetFactoryUpdate_In.FFactory.A_Factory, 
                        FADMADS_SetFactoryUpdate_In.FFactory.D_Factory,
                        row["Factory"].ToString()
                        );
                    fXmlNodeInFac.set_elemVal(
                        FADMADS_SetFactoryUpdate_In.FFactory.A_Description,
                        FADMADS_SetFactoryUpdate_In.FFactory.D_Description,
                        fPropFac.Description
                        );

                    // --
                    
                    FADMADSCaster.ADMADS_SetFactoryUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetFactoryUpdate_Out.A_hStatus, FADMADS_SetFactoryUpdate_Out.D_hStatus) != "0")
                    {
                        // grdList.removeDataRows(keys.ToArray()); 
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetFactoryUpdate_Out.A_hStatusMessage, FADMADS_SetFactoryUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdList.removeDataRow(row.Index);
                }

                // --

                grdList.endUpdate();                

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfFactory();
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
                fXmlNodeInFac = null;
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

                refreshGridOfFactory(grdList.activeDataRowKey);
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
