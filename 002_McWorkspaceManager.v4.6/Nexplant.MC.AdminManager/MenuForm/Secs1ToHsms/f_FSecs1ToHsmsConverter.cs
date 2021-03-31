/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecs1ToHsmsConverter.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.24
--  Description     : FAMate Admin Manager Setup SECS1 To Hsms Converter Form Class 
--  History         : Created by spike.lee at 2017.04.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinGrid;
using System.Drawing;

namespace Nexplant.MC.AdminManager
{
    public partial class FSecs1ToHsmsConverter : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1ToHsmsConverter(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1ToHsmsConverter(
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
                base.fUIWizard.changeControlCaption(mnuMenu);
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
                base.fUIWizard.changeControlFontName(mnuMenu);
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

        private void designGridOfSecs1ToHsmsConverter(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Converter");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("IP Address");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Converter"].CellAppearance.Image = Properties.Resources.S2HCvt;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Converter"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Converter"].Width = 250;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 250;
                grdList.DisplayLayout.Bands[0].Columns["Type"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["IP Address"].Width = 150;
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

        private void refreshGridOfSecs1ToHsmsConverter(
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
                initPropOfSecs1ToHsmsConverter();

                //--

                grdList.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Secs1ToHsms", "Secs1ToHsmsConverter", "ListSecs1ToHsmsConverter", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Converter
                            r[1].ToString(),   // Description
                            r[2].ToString(),   // Type
                            r[3].ToString()    // IP Address
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

        private void initPropOfSecs1ToHsmsConverter(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropSecs1ToHsmsConverter(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfSecs1ToHsmsConverter(
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
                fSqlParams.add("cvt_name", grdList.activeDataRowKey);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Secs1ToHsms", "Secs1ToHsmsConverter", "SearchSecs1ToHsmsConverter", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropSecs1ToHsmsConverter(m_fAdmCore, pgdProp, dt, m_tranEnabled);
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

        #region SECS1 To HSMS Convereter Popup Menu

        private void procMenuSecs1ToHsmsConverterStatus(
            )
        {
            FSecs1ToHsmsConverterStatus fSecs1ToHsmsConverterStatus = null;

            try
            {
                fSecs1ToHsmsConverterStatus = (FSecs1ToHsmsConverterStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterStatus));
                if (fSecs1ToHsmsConverterStatus == null)
                {
                    fSecs1ToHsmsConverterStatus = new FSecs1ToHsmsConverterStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterStatus);
                }
                fSecs1ToHsmsConverterStatus.activate();
                fSecs1ToHsmsConverterStatus.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuSecs1ToHsmsConverterHistory(
            )
        {
            FSecs1ToHsmsConverterHistory fSecs1ToHsmsConverterHistory = null;

            try
            {
                fSecs1ToHsmsConverterHistory = (FSecs1ToHsmsConverterHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterHistory));
                if (fSecs1ToHsmsConverterHistory == null)
                {
                    fSecs1ToHsmsConverterHistory = new FSecs1ToHsmsConverterHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterHistory);
                }
                fSecs1ToHsmsConverterHistory.activate();
                fSecs1ToHsmsConverterHistory.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuSecs1ToHsmsConverterLogList(
            )
        {
            FSecs1ToHsmsConverterLogList fSecs1ToHsmsConverterLogList = null;

            try
            {
                fSecs1ToHsmsConverterLogList = (FSecs1ToHsmsConverterLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterLogList));
                if (fSecs1ToHsmsConverterLogList == null)
                {
                    fSecs1ToHsmsConverterLogList = new FSecs1ToHsmsConverterLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterLogList);
                }
                fSecs1ToHsmsConverterLogList.activate();
                fSecs1ToHsmsConverterLogList.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuSecs1ToHsmsConverterBackupLogList(
            )
        {
            FSecs1ToHsmsConverterBackupLogList fSecs1ToHsmsConverterBackupLogList = null;

            try
            {
                fSecs1ToHsmsConverterBackupLogList = (FSecs1ToHsmsConverterBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FSecs1ToHsmsConverterBackupLogList));
                if (fSecs1ToHsmsConverterBackupLogList == null)
                {
                    fSecs1ToHsmsConverterBackupLogList = new FSecs1ToHsmsConverterBackupLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fSecs1ToHsmsConverterBackupLogList);
                }
                fSecs1ToHsmsConverterBackupLogList.activate();
                fSecs1ToHsmsConverterBackupLogList.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSecs1ToHsmsConverterBackupLogList = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSecs1ToHsmsConverter Form Event Handler

        private void FSecs1ToHsmsConverter_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverter);

                // --

                designGridOfSecs1ToHsmsConverter();

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

        private void FSecs1ToHsmsConverter_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfSecs1ToHsmsConverter(string.Empty);

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

        private void FSecs1ToHsmsConverter_FormClosing(
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

        private void FSecs1ToHsmsConverter_KeyDown(
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
                    refreshGridOfSecs1ToHsmsConverter(grdList.activeDataRowKey);
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

                setPropOfSecs1ToHsmsConverter();

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

                setPropOfSecs1ToHsmsConverter();
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

        private void grdList_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;
            string serverType = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdList.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdList.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdList.ActiveRow = grdList.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterStatus].SharedProps.Enabled = grdList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterStatus) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterHistory].SharedProps.Enabled = grdList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterHistory) ? true : false;
                // --                
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterLogList].SharedProps.Enabled = grdList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterLogList) ? true : false;
                mnuMenu.Tools[FMenuKey.MenuSecs1ToHsmsConverterBackupLogList].SharedProps.Enabled = grdList.ActiveRow != null && FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsConverterBackupLogList) ? true : false;

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuS2HCvtMonitorPopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                r = null;
                // --
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
            FPropSecs1ToHsmsConverter fPropCvt = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInCvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropCvt = (FPropSecs1ToHsmsConverter)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropCvt.Converter, true, this.fUIWizard, "Converter");

                if (fPropCvt.Converter.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Converter" }));
                }

                if (fPropCvt.Description.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                if (fPropCvt.Type == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "Type" }));
                }

                if (fPropCvt.IpAddress.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "IP Address" }));
                }

                // --

                if (fPropCvt.Secs1SessionId < 0 || fPropCvt.Secs1SessionId > 32767)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "SECS1 Session ID" }));
                }

                if (fPropCvt.Secs1SerialPort.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "SECS1 Serial Port" }));
                }

                if (fPropCvt.Secs1Baud < 300)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "SECS1 Baud" }));
                }

                if (fPropCvt.Secs1RetryLimit > 31)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "SECS1 Retry Limit" }));
                }

                if (fPropCvt.Secs1T1Timeout < 0.1F || fPropCvt.Secs1T1Timeout > 10.0F)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "SECS1 T1 Timeout" }));
                }

                if (fPropCvt.Secs1T2Timeout < 0.1F || fPropCvt.Secs1T2Timeout > 10.0F)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "SECS1 T2 Timeout" }));
                }

                if (fPropCvt.Secs1T3Timeout < 1 || fPropCvt.Secs1T3Timeout > 120)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "SECS1 T2 Timeout" }));
                }

                if (fPropCvt.Secs1T4Timeout < 1 || fPropCvt.Secs1T4Timeout > 120)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "SECS1 T2 Timeout" }));
                }

                // --

                if (fPropCvt.HsmsSessionId < 0 || fPropCvt.HsmsSessionId > 32767)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "HSMS Session ID" }));
                }

                if (fPropCvt.HsmsConnectMode == FS2HConnectMode.Passive)
                {
                    if (fPropCvt.HsmsLocalIp.Trim() == string.Empty)
                    {
                        FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "HSMS Local IP" }));
                    }

                    if (fPropCvt.HsmsLocalPort < 0 || fPropCvt.HsmsLocalPort > 65535)
                    {
                        FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "HSMS Local Port" }));
                    }
                }
                else
                {
                    if (fPropCvt.HsmsLocalIp.Trim() == string.Empty)
                    {
                        FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "HSMS Local IP" }));
                    }

                    if (fPropCvt.HsmsRemoteIp.Trim() == string.Empty)
                    {
                        FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0004", new object[] { "HSMS Remote IP" }));
                    }

                    if (fPropCvt.HsmsRemotePort < 0 || fPropCvt.HsmsRemotePort > 65535)
                    {
                        FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "HSMS Remote Port" }));
                    }
                }

                if (fPropCvt.HsmsLinkTestPeriod > 240)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "HSMS Link Test Period" }));
                }

                if (fPropCvt.HsmsT3Timeout < 1 || fPropCvt.HsmsT3Timeout > 120)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "HSMS T3 Timeout" }));
                }

                if (fPropCvt.HsmsT5Timeout < 1 || fPropCvt.HsmsT5Timeout > 240)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "HSMS T5 Timeout" }));
                }

                if (fPropCvt.HsmsT6Timeout < 1 || fPropCvt.HsmsT6Timeout > 240)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "HSMS T6 Timeout" }));
                }

                if (fPropCvt.HsmsT7Timeout < 1 || fPropCvt.HsmsT7Timeout > 240)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "HSMS T7 Timeout" }));
                }

                if (fPropCvt.HsmsT8Timeout < 1 || fPropCvt.HsmsT8Timeout > 120)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "HSMS T8 Timeout" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetSecs1ToHsmsConverterUpdate_In.E_ADMADS_SetSecs1ToHsmsConverterUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hLanguage, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hFactory, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hUserId, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hHostIp, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hHostName, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName); 
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hStep, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hStep, "1");                
                // --
                fXmlNodeInCvt = fXmlNodeIn.set_elem(FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.E_Secs1ToHsmsConverter);
                fXmlNodeInCvt.set_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Converter, 
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Converter,
                    fPropCvt.Converter
                    );
                fXmlNodeInCvt.set_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Description,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Description,
                    fPropCvt.Description
                    );
                fXmlNodeInCvt.set_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Type,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Type,
                    fPropCvt.Type
                    );
                fXmlNodeInCvt.set_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_IpAddress,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_IpAddress,
                    fPropCvt.IpAddress
                    );
                // --
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1SessionId,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1SessionId,
                    fPropCvt.Secs1SessionId.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1SerialPort,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1SerialPort,
                    fPropCvt.Secs1SerialPort
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1Baud,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1Baud,
                    fPropCvt.Secs1Baud.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1RBit,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1RBit,
                    fPropCvt.Secs1RBit.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1Interleave,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1Interleave,
                    fPropCvt.Secs1Interleave.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1DuplicateError,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1DuplicateError,
                    fPropCvt.Secs1DuplicateError.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1IgnoreSystemBytes,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1IgnoreSystemBytes,
                    fPropCvt.Secs1IgnoreSystemBytes.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1RetryLimit,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1RetryLimit,
                    fPropCvt.Secs1RetryLimit.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1T1Timeout,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1T1Timeout,
                    fPropCvt.Secs1T1Timeout.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1T2Timeout,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1T2Timeout,
                    fPropCvt.Secs1T2Timeout.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1T3Timeout,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1T3Timeout,
                    fPropCvt.Secs1T3Timeout.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Secs1T4Timeout,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Secs1T4Timeout,
                    fPropCvt.Secs1T4Timeout.ToString()
                    );
                // --
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsSessionId,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsSessionId,
                    fPropCvt.HsmsSessionId.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsConnectMode,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsConnectMode,
                    fPropCvt.HsmsConnectMode.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsLocalIp,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsLocalIp,
                    fPropCvt.HsmsLocalIp
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsLocalPort,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsLocalPort,
                    fPropCvt.HsmsLocalPort.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsRemoteIp,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsRemoteIp,
                    fPropCvt.HsmsRemoteIp
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsRemotePort,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsRemotePort,
                    fPropCvt.HsmsRemotePort.ToString()
                    );                
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsLinkTestPeriod,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsLinkTestPeriod,
                    fPropCvt.HsmsLinkTestPeriod.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsT3Timeout,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsT3Timeout,
                    fPropCvt.HsmsT3Timeout.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsT5Timeout,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsT5Timeout,
                    fPropCvt.HsmsT5Timeout.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsT6Timeout,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsT6Timeout,
                    fPropCvt.HsmsT6Timeout.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsT7Timeout,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsT7Timeout,
                    fPropCvt.HsmsT7Timeout.ToString()
                    );
                fXmlNodeInCvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_HsmsT8Timeout,
                    FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_HsmsT8Timeout,
                    fPropCvt.HsmsT8Timeout.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_SetSecs1ToHsmsConverterUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_Out.A_hStatus, FADMADS_SetSecs1ToHsmsConverterUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_Out.A_hStatusMessage, FADMADS_SetSecs1ToHsmsConverterUpdate_Out.D_hStatusMessage)
                        );
                }

                // --
                
                cellValues = new object[]
                {
                    fPropCvt.Converter,
                    fPropCvt.Description,
                    fPropCvt.Type,
                    fPropCvt.IpAddress
                };
                // --
                key = fPropCvt.Converter;
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
                fPropCvt = null;
                fXmlNodeIn = null;
                fXmlNodeInCvt = null;
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

                initPropOfSecs1ToHsmsConverter();
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
            FXmlNode fXmlNodeInCvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (
                    FMessageBox.showQuestion(
                        FConstants.ApplicationName,
                        m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected SECS1 To HSMS Converter" }),
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

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetSecs1ToHsmsConverterUpdate_In.E_ADMADS_SetSecs1ToHsmsConverterUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hLanguage, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hFactory, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hUserId, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hHostIp, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hHostName, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_In.A_hStep, FADMADS_SetSecs1ToHsmsConverterUpdate_In.D_hStep, "2");                
                // --
                fXmlNodeInCvt = fXmlNodeIn.set_elem(FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.E_Secs1ToHsmsConverter);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInCvt.set_elemVal(
                        FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.A_Converter,
                        FADMADS_SetSecs1ToHsmsConverterUpdate_In.FSecs1ToHsmsConverter.D_Converter, 
                        row["Converter"].ToString()
                        );

                    // --
                    
                    FADMADSCaster.ADMADS_SetSecs1ToHsmsConverterUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_Out.A_hStatus, FADMADS_SetSecs1ToHsmsConverterUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetSecs1ToHsmsConverterUpdate_Out.A_hStatusMessage, FADMADS_SetSecs1ToHsmsConverterUpdate_Out.D_hStatusMessage)
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
                    initPropOfSecs1ToHsmsConverter();
                }    

                //--

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
                fXmlNodeInCvt = null;
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

                refreshGridOfSecs1ToHsmsConverter(grdList.activeDataRowKey);
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

        #region mnuMenu Control Event Handler

        private void mnuMenu_ToolClick(
            object sender, 
            Infragistics.Win.UltraWinToolbars.ToolClickEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterStatus)
                {
                    procMenuSecs1ToHsmsConverterStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterHistory)
                {
                    procMenuSecs1ToHsmsConverterHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterLogList)
                {
                    procMenuSecs1ToHsmsConverterLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuSecs1ToHsmsConverterBackupLogList)
                {
                    procMenuSecs1ToHsmsConverterBackupLogList();
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
