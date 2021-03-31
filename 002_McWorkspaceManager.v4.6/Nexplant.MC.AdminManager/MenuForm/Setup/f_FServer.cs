/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServer.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.22
--  Description     : FAMate Admin Manager Setup Server Form Class 
--  History         : Created by spike.lee at 2012.03.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win;

namespace Nexplant.MC.AdminManager
{
    public partial class FServer : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServer(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServer(
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

        private void designGridOfServer(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Server Type");
                uds.Band.Columns.Add("Server IP");
                uds.Band.Columns.Add("Used Backup");
                uds.Band.Columns.Add("Backup Mode");
                uds.Band.Columns.Add("Backup Server");
                uds.Band.Columns.Add("OPC Server Monitoring");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Server"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 130;
                grdList.DisplayLayout.Bands[0].Columns["Server Type"].Width = 70;
                grdList.DisplayLayout.Bands[0].Columns["Server IP"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Used Backup"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Backup Mode"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Backup Server"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["OPC Server Monitoring"].Width = 80;
                
                // --
                
                grdList.DisplayLayout.Bands[0].Columns["Server"].CellAppearance.Image = Properties.Resources.Server;

                // --
                
                grdList.DisplayLayout.Bands[0].Columns["Server"].Header.Fixed = true;
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

        private void refreshGridOfServer(
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
                initPropOfServer();

                //--

                grdList.beginUpdate();

                // --
                
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Server", "ListServer", fSqlParams, false, ref nextRowNumber);                    
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Server
                            r[1].ToString(),   // Description
                            r[2].ToString(),   // Server Type
                            r[3].ToString(),   // Server IP
                            r[4].ToString(),   // Used Backup
                            r[5].ToString(),   // Backup Mode
                            r[6].ToString(),   // Backup Server
                            r[7].ToString()    // OPC Server Monitoring 
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

                //--

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

        private void initPropOfServer(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropServer(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfServer(
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
                fSqlParams.add("server", grdList.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Server", "SearchServer", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropServer(m_fAdmCore, pgdProp, dt, m_tranEnabled);
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

        #region Server Popup Menu

        private void procMenuServerStatus(
            )
        {
            FServerStatus fServerStatus = null;

            try
            {
                fServerStatus = (FServerStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FServerStatus));
                if (fServerStatus == null)
                {
                    fServerStatus = new FServerStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerStatus);
                }
                fServerStatus.activate();
                fServerStatus.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuServerHistory(
            )
        {
            FServerHistory fServerHistory = null;

            try
            {
                fServerHistory = (FServerHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FServerHistory));
                if (fServerHistory == null)
                {
                    fServerHistory = new FServerHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerHistory);
                }
                fServerHistory.activate();
                fServerHistory.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuServerResourceStatus(
            )
        {
            FServerResourceStatus fServerResourceStatus = null;

            try
            {
                fServerResourceStatus = (FServerResourceStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FServerResourceStatus));
                if (fServerResourceStatus == null)
                {
                    fServerResourceStatus = new FServerResourceStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerResourceStatus);
                }
                fServerResourceStatus.activate();
                fServerResourceStatus.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerResourceStatus = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuServerResourceHistory(
            )
        {
            FServerResourceHistory fServerResourceHistory = null;

            try
            {
                fServerResourceHistory = (FServerResourceHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FServerResourceHistory));
                if (fServerResourceHistory == null)
                {
                    fServerResourceHistory = new FServerResourceHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerResourceHistory);
                }
                fServerResourceHistory.activate();
                fServerResourceHistory.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerResourceHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuServerMainSwitch(
            )
        {
            FServerMainSwitch fServerMainSwitch = null;

            try
            {
                fServerMainSwitch = (FServerMainSwitch)m_fAdmCore.fAdmContainer.getChild(typeof(FServerMainSwitch));
                if (fServerMainSwitch == null)
                {
                    fServerMainSwitch = new FServerMainSwitch(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerMainSwitch);
                }
                fServerMainSwitch.activate();
                fServerMainSwitch.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerMainSwitch = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuServerBackupSwitch(
            )
        {
            FServerBackupSwitch fServerBackupSwitch = null;

            try
            {
                fServerBackupSwitch = (FServerBackupSwitch)m_fAdmCore.fAdmContainer.getChild(typeof(FServerBackupSwitch));
                if (fServerBackupSwitch == null)
                {
                    fServerBackupSwitch = new FServerBackupSwitch(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fServerBackupSwitch);
                }
                fServerBackupSwitch.activate();
                fServerBackupSwitch.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fServerBackupSwitch = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuAdminAgentLogList(
            )
        {
            FAdminAgentLogList fAdminAgentLogList = null;

            try
            {
                fAdminAgentLogList = (FAdminAgentLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FAdminAgentLogList));
                if (fAdminAgentLogList == null)
                {
                    fAdminAgentLogList = new FAdminAgentLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fAdminAgentLogList);
                }
                fAdminAgentLogList.activate();
                fAdminAgentLogList.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAdminAgentLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void procMenuAdminAgentBackupLogList(
            )
        {
            FAdminAgentBackupLogList fAdminAgentBackupLogList = null;

            try
            {
                fAdminAgentBackupLogList = (FAdminAgentBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FAdminAgentBackupLogList));
                if (fAdminAgentBackupLogList == null)
                {
                    fAdminAgentBackupLogList = new FAdminAgentBackupLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fAdminAgentBackupLogList);
                }
                fAdminAgentBackupLogList.activate();
                fAdminAgentBackupLogList.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAdminAgentBackupLogList = null;
            }
        }

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FServer Form Event Handler

        private void FServer_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Server);

                // --

                designGridOfServer();

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

        private void FServer_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfServer(string.Empty);

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

        private void FServer_FormClosing(
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

        private void FServer_KeyDown(
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
                    refreshGridOfServer(grdList.activeDataRowKey);
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

                setPropOfServer();

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

                setPropOfServer();
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

                r = (UltraGridRow)grdList.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdList.ActiveRow = grdList.Rows[r.Index];
                }

                // --

                serverType = grdList.activeDataRow["Server Type"].ToString();

                // --

                mnuMenu.Tools[FMenuKey.MenuSetServerStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerStatus);
                mnuMenu.Tools[FMenuKey.MenuSetServerHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerHistory);
                // --                    
                mnuMenu.Tools[FMenuKey.MenuSetServerResourceStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceStatus);
                mnuMenu.Tools[FMenuKey.MenuSetServerResourceComparison].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceComparison);
                mnuMenu.Tools[FMenuKey.MenuSetServerResourceAnalysis].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceAnalysis);
                mnuMenu.Tools[FMenuKey.MenuSetServerResourceHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerResourceHistory);
                // --
                mnuMenu.Tools[FMenuKey.MenuSetServerMainSwitch].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerMainSwitch);
                mnuMenu.Tools[FMenuKey.MenuSetServerBackupSwitch].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ServerBackupSwitch);
                // --
                mnuMenu.Tools[FMenuKey.MenuSetAdminAgentLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentLogList);
                mnuMenu.Tools[FMenuKey.MenuSetAdminAgentBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.AdminAgentBackupLogList);

                // --

                #region Menu Control

                if (serverType == FServerType.Virtual.ToString())
                {
                    mnuMenu.Tools[FMenuKey.MenuSetServerResourceStatus].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetServerResourceComparison].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetServerResourceAnalysis].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetServerResourceHistory].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSetServerMainSwitch].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetServerBackupSwitch].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSetAdminAgentLogList].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetAdminAgentBackupLogList].SharedProps.Enabled = false;
                }

                #endregion

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuSetSvrPopupMenu);                
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
                if (e.Tool.Key == FMenuKey.MenuSetServerStatus)
                {
                    procMenuServerStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetServerHistory)
                {
                    procMenuServerHistory();
                }
                // --                
                else if (e.Tool.Key == FMenuKey.MenuSetServerResourceStatus)
                {
                    procMenuServerResourceStatus();
                }
               
                else if (e.Tool.Key == FMenuKey.MenuSetServerResourceHistory)
                {
                    procMenuServerResourceHistory();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSetServerMainSwitch)
                {
                    procMenuServerMainSwitch();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetServerBackupSwitch)
                {
                    procMenuServerBackupSwitch();
                }
                // --
                else if (e.Tool.Key == FMenuKey.MenuSetAdminAgentLogList)
                {
                    procMenuAdminAgentLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetAdminAgentBackupLogList)
                {
                    procMenuAdminAgentBackupLogList();
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

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
            object sender,
            EventArgs e
            )
        {
            FPropServer fPropSvr = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSvr = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropSvr = (FPropServer)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropSvr.Server, true, this.fUIWizard, "Server");

                if (fPropSvr.Server.Length > 20)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Server" }));
                }

                // --

                if (fPropSvr.Description.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }
                
                // --

                if (fPropSvr.ServerType == FServerType.Real)
                {
                    if (fPropSvr.ServerIp.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "Server IP" }));
                    }

                    // --

                    if (fPropSvr.ServerIp.Length > 100)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Server IP" }));
                    }
                }

                #endregion

                // --

                if (fPropSvr.UsedBackup == FYesNo.Yes)
                {
                    if (fPropSvr.BackupServer.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0015", new object[] { "Backup Server" }));
                    }
                }

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetServerUpdate_In.E_ADMADS_SetServerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hFactory, FADMADS_SetServerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hUserId, FADMADS_SetServerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);                
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hLanguage, FADMADS_SetServerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hHostIp, FADMADS_SetServerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hHostName, FADMADS_SetServerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hStep, FADMADS_SetServerUpdate_In.D_hStep, "1");  
              
                // --

                fXmlNodeInSvr = fXmlNodeIn.set_elem(FADMADS_SetServerUpdate_In.FServer.E_Server);
                fXmlNodeInSvr.set_elemVal(
                    FADMADS_SetServerUpdate_In.FServer.A_Server, 
                    FADMADS_SetServerUpdate_In.FServer.D_Server, 
                    fPropSvr.Server
                    );
                fXmlNodeInSvr.set_elemVal(
                    FADMADS_SetServerUpdate_In.FServer.A_Description, 
                    FADMADS_SetServerUpdate_In.FServer.D_Description,
                    fPropSvr.Description
                    );
                fXmlNodeInSvr.set_elemVal(
                    FADMADS_SetServerUpdate_In.FServer.A_ServerType,
                    FADMADS_SetServerUpdate_In.FServer.D_ServerType,
                    fPropSvr.ServerType.ToString()
                    );
                fXmlNodeInSvr.set_elemVal(
                    FADMADS_SetServerUpdate_In.FServer.A_ServerIp, 
                    FADMADS_SetServerUpdate_In.FServer.D_ServerIp, 
                    fPropSvr.ServerIp
                    );
                fXmlNodeInSvr.set_elemVal(
                    FADMADS_SetServerUpdate_In.FServer.A_UsedBackup, 
                    FADMADS_SetServerUpdate_In.FServer.D_UsedBackup, 
                    fPropSvr.UsedBackup.ToString()
                    );
                fXmlNodeInSvr.set_elemVal(
                    FADMADS_SetServerUpdate_In.FServer.A_BackupMode, 
                    FADMADS_SetServerUpdate_In.FServer.D_BackupMode, 
                    fPropSvr.BackupMode.ToString()
                    );
                fXmlNodeInSvr.set_elemVal(
                    FADMADS_SetServerUpdate_In.FServer.A_BackupServer, 
                    FADMADS_SetServerUpdate_In.FServer.D_BackupServer,
                    fPropSvr.BackupServer
                    );
                fXmlNodeInSvr.set_elemVal(
                    FADMADS_SetServerUpdate_In.FServer.A_OpcServerMonitoring,
                    FADMADS_SetServerUpdate_In.FServer.D_OpcServerMonitoring,
                    fPropSvr.OpcServerMonitoring.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_SetServerUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetServerUpdate_Out.A_hStatus, FADMADS_SetServerUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetServerUpdate_Out.A_hStatusMessage, FADMADS_SetServerUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropSvr.Server,
                    fPropSvr.Description,
                    fPropSvr.ServerType,
                    fPropSvr.ServerIp,
                    fPropSvr.UsedBackup.ToString(),
                    fPropSvr.BackupMode.ToString(),
                    fPropSvr.BackupServer,
                    fPropSvr.OpcServerMonitoring.ToString()
                };
                // --                
                key = fPropSvr.Server;
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
                fPropSvr = null;
                fXmlNodeIn = null;
                fXmlNodeInSvr = null;
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

                initPropOfServer();
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
            FXmlNode fXmlNodeInSvr = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Server" }),
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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetServerUpdate_In.E_ADMADS_SetServerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hLanguage, FADMADS_SetServerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hFactory, FADMADS_SetServerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hUserId, FADMADS_SetServerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hHostIp, FADMADS_SetServerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hHostName, FADMADS_SetServerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerUpdate_In.A_hStep, FADMADS_SetServerUpdate_In.D_hStep, "2");
                
                // --

                fXmlNodeInSvr = fXmlNodeIn.set_elem(FADMADS_SetServerUpdate_In.FServer.E_Server);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInSvr.set_elemVal(
                        FADMADS_SetServerUpdate_In.FServer.A_Server, 
                        FADMADS_SetServerUpdate_In.FServer.D_Server, 
                        row["Server"].ToString()
                        );
                    
                    // --
                    
                    FADMADSCaster.ADMADS_SetServerUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetServerUpdate_Out.A_hStatus, FADMADS_SetServerUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetServerUpdate_Out.A_hStatusMessage, FADMADS_SetServerUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdList.removeDataRow(row.Index);
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfServer();
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
                fXmlNodeInSvr = null;
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

                refreshGridOfServer(grdList.activeDataRowKey);
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
