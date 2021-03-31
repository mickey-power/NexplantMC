/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEvent.cs
--  Creator         : mjkim
--  Create Date     : 2013.05.31
--  Description     : FAMate Admin Manager Setup Event Form Class 
--  History         : Created by mjkim at 2013.05.31
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
    public partial class FEvent : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEvent(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEvent(
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

                if (key == "Server")
                {
                    btnDelete.Enabled = grdSvrEvent.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdSvrEvent.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "Eap")
                {
                    btnDelete.Enabled = grdEapEvent.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdEapEvent.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "Eqp")
                {
                    btnDelete.Enabled = grdEqpEvent.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdEqpEvent.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "User")
                {
                    btnDelete.Enabled = grdUsrEvent.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdUsrEvent.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void designGridOfServerEvent(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdSvrEvent.dataSource;
                // --
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("System Event");
                uds.Band.Columns.Add("Issue Event");

                // --

                grdSvrEvent.DisplayLayout.Bands[0].Columns["Event"].CellAppearance.Image = Properties.Resources.ServerEvent;
                // --
                grdSvrEvent.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;
                // --
                grdSvrEvent.DisplayLayout.Bands[0].Columns["Event"].Width = 230;
                grdSvrEvent.DisplayLayout.Bands[0].Columns["Description"].Width = 300;
                grdSvrEvent.DisplayLayout.Bands[0].Columns["System Event"].Width = 90;
                grdSvrEvent.DisplayLayout.Bands[0].Columns["Issue Event"].Width = 90;
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

        private void designGridOfEapEvent(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEapEvent.dataSource;
                // --
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("System Event");
                uds.Band.Columns.Add("Issue Event");

                // --

                grdEapEvent.DisplayLayout.Bands[0].Columns["Event"].CellAppearance.Image = Properties.Resources.EapEvent;
                // --
                grdEapEvent.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;
                // --
                grdEapEvent.DisplayLayout.Bands[0].Columns["Event"].Width = 230;
                grdEapEvent.DisplayLayout.Bands[0].Columns["Description"].Width = 300;
                grdEapEvent.DisplayLayout.Bands[0].Columns["System Event"].Width = 90;
                grdEapEvent.DisplayLayout.Bands[0].Columns["Issue Event"].Width = 90;
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

        private void designGridOfEqpEvent(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEqpEvent.dataSource;
                // --
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("System Event");
                uds.Band.Columns.Add("Issue Event");

                // --

                grdEqpEvent.DisplayLayout.Bands[0].Columns["Event"].CellAppearance.Image = Properties.Resources.EquipmentEvent;
                // --
                grdEqpEvent.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;
                // --
                grdEqpEvent.DisplayLayout.Bands[0].Columns["Event"].Width = 230;
                grdEqpEvent.DisplayLayout.Bands[0].Columns["Description"].Width = 300;
                grdEqpEvent.DisplayLayout.Bands[0].Columns["System Event"].Width = 90;
                grdEqpEvent.DisplayLayout.Bands[0].Columns["Issue Event"].Width = 90;
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

        private void designGridOfUserEvent(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdUsrEvent.dataSource;
                // --
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Action");
                uds.Band.Columns.Add("System Event");

                // --

                grdUsrEvent.DisplayLayout.Bands[0].Columns["Event"].CellAppearance.Image = Properties.Resources.UserEvent;
                // --
                grdUsrEvent.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;
                // --
                grdUsrEvent.DisplayLayout.Bands[0].Columns["Event"].Width = 260;
                grdUsrEvent.DisplayLayout.Bands[0].Columns["Description"].Width = 255;
                grdUsrEvent.DisplayLayout.Bands[0].Columns["Action"].Width = 110;
                grdUsrEvent.DisplayLayout.Bands[0].Columns["System Event"].Width = 70;
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

        private void refreshGridOfServerEvent(
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
                grdSvrEvent.removeAllDataRow();
                grdSvrEvent.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfServerEvent();

                // --

                grdSvrEvent.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ServerEvent", "ListServerEvent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Server Event
                            r[1].ToString(),   // Description
                            r[2].ToString(),   // System Event
                            r[3].ToString()    // Issue Event
                            };
                        key = (string)cellValues[0];
                        grdSvrEvent.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdSvrEvent.endUpdate();

                // --

                if (grdSvrEvent.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdSvrEvent.activateDataRow(beforeKey);
                    }
                    if (grdSvrEvent.activeDataRow == null)
                    {
                        grdSvrEvent.ActiveRow = grdSvrEvent.Rows[0];
                    }
                }

                // --

                refreshServerTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Server")
                {
                    grdSvrEvent.Focus();
                }
            }
            catch (Exception ex)
            {
                grdSvrEvent.endUpdate();
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

        private void refreshGridOfEapEvent(
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
                grdEapEvent.removeAllDataRow();
                grdEapEvent.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfEapEvent();

                // --

                grdEapEvent.beginUpdate();

                // --
                
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "EapEvent", "ListEapEvent", fSqlParams, false, ref nextRowNumber);                    
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // EAP Event
                            r[1].ToString(),   // Description
                            r[2].ToString(),   // System Event
                            r[3].ToString()    // Issue Event
                            };
                        key = (string)cellValues[0];
                        grdEapEvent.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);
                
                // --

                grdEapEvent.endUpdate();

                // --

                if (grdEapEvent.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)                    
                    {
                        grdEapEvent.activateDataRow(beforeKey); 
                    }
                    if (grdEapEvent.activeDataRow == null)
                    {
                        grdEapEvent.ActiveRow = grdEapEvent.Rows[0];
                    }
                }

                // --

                refreshEapTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Eap")
                {
                    grdEapEvent.Focus();
                }
            }
            catch (Exception ex)
            {
                grdEapEvent.endUpdate();
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

        private void refreshGridOfEqpEvent(
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
                grdEqpEvent.removeAllDataRow();
                grdEqpEvent.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfEqpEvent();

                // --

                grdEqpEvent.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("system", FSystemCode.ADM.ToString());

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "EquipmentEvent", "ListEquipmentEvent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),    // Equipment Event
                            r[1].ToString(),    // Description
                            r[2].ToString(),    // System Event 
                            r[3].ToString()     // Issue Event
                            };
                        key = (string)cellValues[0];
                        grdEqpEvent.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEqpEvent.endUpdate();

                // --

                if (grdEqpEvent.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdEqpEvent.activateDataRow(beforeKey);
                    }
                    if (grdEqpEvent.activeDataRow == null)
                    {
                        grdEqpEvent.ActiveRow = grdEqpEvent.Rows[0];
                    }
                }

                // --

                refreshEquipmentTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Eqp")
                {
                    grdEqpEvent.Focus();
                }
            }
            catch (Exception ex)
            {
                grdEqpEvent.endUpdate();
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

        private void refreshGridOfUserEvent(
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
                grdUsrEvent.removeAllDataRow();
                grdUsrEvent.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfUserEvent();

                // --

                grdUsrEvent.beginUpdate();

                // --
                
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("system", FSystemCode.ADM.ToString());

                // --

                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserEvent", "ListUserEvent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Event ID
                            r[1].ToString(),   // Description
                            r[2].ToString(),   // Action
                            r[3].ToString()    // System Code
                            };
                        key = (string)cellValues[0] + "-" + (string)cellValues[2];  // User Event Key: Event ID + "-" + Action
                        grdUsrEvent.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdUsrEvent.endUpdate();

                // --

                if (grdUsrEvent.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdUsrEvent.activateDataRow(beforeKey);
                    }
                    if (grdUsrEvent.activeDataRow == null)
                    {
                        grdUsrEvent.ActiveRow = grdUsrEvent.Rows[0];
                    }
                }

                // --

                refreshUserTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "User")
                {
                    grdUsrEvent.Focus();
                }
            }
            catch (Exception ex)
            {
                grdUsrEvent.endUpdate();
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

        private void updateGridOfServerEvent(
            )
        {
            FPropServerEvent fPropEvt = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropEvt = (FPropServerEvent)pgdSvrEvent.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropEvt.Event, true, this.fUIWizard, "Event");

                if (fPropEvt.Event.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Event" }));
                }

                // --

                if (fPropEvt.Description.Length > 100)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                if (fPropEvt.Comment.Length > 400)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Comment" }));
                }

                // --

                if (fPropEvt.Data_1_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 1" }));
                }

                // --

                if (fPropEvt.Data_2_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 2" }));
                }

                // --

                if (fPropEvt.Data_3_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 3" }));
                }

                // --

                if (fPropEvt.Data_4_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 4" }));
                }

                // --

                if (fPropEvt.Data_5_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 5" }));
                }

                // --

                if (fPropEvt.Data_6_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 6" }));
                }

                // --

                if (fPropEvt.Data_7_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 7" }));
                }

                // --

                if (fPropEvt.Data_8_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 8" }));
                }

                // --

                if (fPropEvt.Data_9_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 9" }));
                }

                // --

                if (fPropEvt.Data_10_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 10" }));
                }

                // --

                if (fPropEvt.Data_11_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 11" }));
                }

                // --

                if (fPropEvt.Data_12_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 12" }));
                }

                // --

                if (fPropEvt.Data_13_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 13" }));
                }

                // --

                if (fPropEvt.Data_14_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 14" }));
                }

                // --

                if (fPropEvt.Data_15_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 15" }));
                }

                // --

                if (fPropEvt.Data_16_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 16" }));
                }

                // --

                if (fPropEvt.Data_17_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 17" }));
                }

                // --

                if (fPropEvt.Data_18_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 18" }));
                }

                // --

                if (fPropEvt.Data_19_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 19" }));
                }

                // --

                if (fPropEvt.Data_20_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 20" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetServerEventUpdate_In.E_ADMADS_SetServerEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hFactory, FADMADS_SetServerEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hUserId, FADMADS_SetServerEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hLanguage, FADMADS_SetServerEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hHostIp, FADMADS_SetServerEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hHostName, FADMADS_SetServerEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hStep, FADMADS_SetServerEventUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetServerEventUpdate_In.FServerEvent.E_ServerEvent);
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Event,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Event,
                    fPropEvt.Event
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Description,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Description,
                    fPropEvt.Description
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_SystemEvent,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_SystemEvent,
                    fPropEvt.SystemEvent.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_IssueEvent,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_IssueEvent,
                    fPropEvt.IssueEvent.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Comment,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Comment,
                    fPropEvt.Comment
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_1_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_2_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_3_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_4_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_5_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_6_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_7_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_8_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_9_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_10_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_11_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_12_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_13_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_14_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_15_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_16_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_17_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_18_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_19_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetServerEventUpdate_In.FServerEvent.A_Data,
                    FADMADS_SetServerEventUpdate_In.FServerEvent.D_Data,
                    fPropEvt.Data_20_Prt
                    );

                // --

                FADMADSCaster.ADMADS_SetServerEventUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetServerEventUpdate_Out.A_hStatus, FADMADS_SetServerEventUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetServerEventUpdate_Out.A_hStatusMessage, FADMADS_SetServerEventUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropEvt.Event,
                    fPropEvt.Description,
                    fPropEvt.SystemEvent.ToString(),
                    fPropEvt.IssueEvent.ToString()
                };
                // --                
                key = fPropEvt.Event;
                grdSvrEvent.appendOrUpdateDataRow(key, cellValues);
                grdSvrEvent.activateDataRow(key);

                // --

                refreshServerTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropEvt = null;
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfEapEvent(
            )
        {
            FPropEapEvent fPropEvt = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropEvt = (FPropEapEvent)pgdEapEvent.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropEvt.Event, true, this.fUIWizard, "Event");

                if (fPropEvt.Event.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Event" }));
                }

                // --

                if (fPropEvt.Description.Length > 100)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                if (fPropEvt.Comment.Length > 400)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Comment" }));
                }

                // --

                if (fPropEvt.Data_1_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 1" }));
                }

                // --

                if (fPropEvt.Data_2_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 2" }));
                }

                // --

                if (fPropEvt.Data_3_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 3" }));
                }

                // --

                if (fPropEvt.Data_4_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 4" }));
                }

                // --

                if (fPropEvt.Data_5_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 5" }));
                }

                // --

                if (fPropEvt.Data_6_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 6" }));
                }

                // --

                if (fPropEvt.Data_7_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 7" }));
                }

                // --

                if (fPropEvt.Data_8_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 8" }));
                }

                // --

                if (fPropEvt.Data_9_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 9" }));
                }

                // --

                if (fPropEvt.Data_10_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 10" }));
                }

                // --

                if (fPropEvt.Data_11_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 11" }));
                }

                // --

                if (fPropEvt.Data_12_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 12" }));
                }

                // --

                if (fPropEvt.Data_13_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 13" }));
                }

                // --

                if (fPropEvt.Data_14_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 14" }));
                }

                // --

                if (fPropEvt.Data_15_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 15" }));
                }

                // --

                if (fPropEvt.Data_16_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 16" }));
                }

                // --

                if (fPropEvt.Data_17_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 17" }));
                }

                // --

                if (fPropEvt.Data_18_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 18" }));
                }

                // --

                if (fPropEvt.Data_19_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 19" }));
                }

                // --

                if (fPropEvt.Data_20_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 20" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEapEventUpdate_In.E_ADMADS_SetEapEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hFactory, FADMADS_SetEapEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hUserId, FADMADS_SetEapEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hLanguage, FADMADS_SetEapEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hHostIp, FADMADS_SetEapEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hHostName, FADMADS_SetEapEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hStep, FADMADS_SetEapEventUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetEapEventUpdate_In.FEapEvent.E_EapEvent);
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Event,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Event,
                    fPropEvt.Event
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Description,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Description,
                    fPropEvt.Description
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_SystemEvent,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_SystemEvent,
                    fPropEvt.SystemEvent.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_IssueEvent,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_IssueEvent,
                    fPropEvt.IssueEvent.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Comment,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Comment,
                    fPropEvt.Comment
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_1_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_2_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_3_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_4_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_5_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_6_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_7_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_8_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_9_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_10_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_11_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_12_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_13_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_14_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_15_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_16_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_17_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_18_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_19_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEapEventUpdate_In.FEapEvent.A_Data,
                    FADMADS_SetEapEventUpdate_In.FEapEvent.D_Data,
                    fPropEvt.Data_20_Prt
                    );

                // --

                FADMADSCaster.ADMADS_SetEapEventUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetEapEventUpdate_Out.A_hStatus, FADMADS_SetEapEventUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetEapEventUpdate_Out.A_hStatusMessage, FADMADS_SetEapEventUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropEvt.Event,
                    fPropEvt.Description,
                    fPropEvt.SystemEvent.ToString(),
                    fPropEvt.IssueEvent.ToString()
                };
                // --                
                key = fPropEvt.Event;
                grdEapEvent.appendOrUpdateDataRow(key, cellValues);
                grdEapEvent.activateDataRow(key);

                // --

                refreshEapTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropEvt = null;
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfEqpEvent(
            )
        {
            FPropEquipmentEvent fPropEvt = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropEvt = (FPropEquipmentEvent)pgdEqpEvent.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropEvt.Event, true, this.fUIWizard, "Event");

                if (fPropEvt.Event.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Event" }));
                }

                // --

                if (fPropEvt.Description.Length > 100)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                if (fPropEvt.Comment.Length > 400)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Comment" }));
                }

                // --

                if (fPropEvt.Data_1_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 1" }));
                }

                // --

                if (fPropEvt.Data_2_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 2" }));
                }

                // --

                if (fPropEvt.Data_3_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 3" }));
                }

                // --

                if (fPropEvt.Data_4_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 4" }));
                }

                // --

                if (fPropEvt.Data_5_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 5" }));
                }

                // --

                if (fPropEvt.Data_6_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 6" }));
                }

                // --

                if (fPropEvt.Data_7_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 7" }));
                }

                // --

                if (fPropEvt.Data_8_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 8" }));
                }

                // --

                if (fPropEvt.Data_9_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 9" }));
                }

                // --

                if (fPropEvt.Data_10_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 10" }));
                }

                // --

                if (fPropEvt.Data_11_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 11" }));
                }

                // --

                if (fPropEvt.Data_12_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 12" }));
                }

                // --

                if (fPropEvt.Data_13_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 13" }));
                }

                // --

                if (fPropEvt.Data_14_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 14" }));
                }

                // --

                if (fPropEvt.Data_15_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 15" }));
                }

                // --

                if (fPropEvt.Data_16_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 16" }));
                }

                // --

                if (fPropEvt.Data_17_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 17" }));
                }

                // --

                if (fPropEvt.Data_18_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 18" }));
                }

                // --

                if (fPropEvt.Data_19_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 19" }));
                }

                // --

                if (fPropEvt.Data_20_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 20" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEquipmentEventUpdate_In.E_ADMADS_SetEquipmentEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hFactory, FADMADS_SetEquipmentEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hUserId, FADMADS_SetEquipmentEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hLanguage, FADMADS_SetEquipmentEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hHostIp, FADMADS_SetEquipmentEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hHostName, FADMADS_SetEquipmentEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hStep, FADMADS_SetEquipmentEventUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.E_EquipmentEvent);
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_System,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_System,
                    FSystemCode.ADM.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Event,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Event,
                    fPropEvt.Event
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Description,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Description,
                    fPropEvt.Description
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_SystemEvent,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_SystemEvent,
                    fPropEvt.SystemEvent.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_IssueEvent,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_IssueEvent,
                    fPropEvt.IssueEvent.ToString()
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_1_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_2_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_3_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_4_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_5_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_6_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_7_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_8_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_9_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_10_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_11_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_12_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_13_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_14_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_15_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_16_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_17_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_18_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_19_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Data,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Data,
                    fPropEvt.Data_20_Prt
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Comment,
                    FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Comment,
                    fPropEvt.Comment
                    );

                // --

                FADMADSCaster.ADMADS_SetEquipmentEventUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentEventUpdate_Out.A_hStatus, FADMADS_SetEquipmentEventUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentEventUpdate_Out.A_hStatusMessage, FADMADS_SetEquipmentEventUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropEvt.Event,
                    fPropEvt.Description,
                    fPropEvt.SystemEvent.ToString(),
                    fPropEvt.IssueEvent.ToString()
                };
                // --                
                key = fPropEvt.Event;
                grdEqpEvent.appendOrUpdateDataRow(key, cellValues);
                grdEqpEvent.activateDataRow(key);

                // --

                refreshEquipmentTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropEvt = null;
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfUserEvent(
            )
        {
            FPropUserEvent fPropEvt = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropEvt = (FPropUserEvent)pgdUsrEvent.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropEvt.Event, true, this.fUIWizard, "Event");
                // --
                if (fPropEvt.Event.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Event" }));
                }

                // --

                if (fPropEvt.Description.Length > 100)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                FCommon.validateName(fPropEvt.Action, true, this.fUIWizard, "Action");
                // --
                if (fPropEvt.Action.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Action" }));
                }

                // --

                if (fPropEvt.Data_1_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 1" }));
                }

                // --

                if (fPropEvt.Data_2_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 2" }));
                }

                // --

                if (fPropEvt.Data_3_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 3" }));
                }

                // --

                if (fPropEvt.Data_4_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 4" }));
                }

                // --

                if (fPropEvt.Data_5_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 5" }));
                }

                // --

                if (fPropEvt.Data_6_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 6" }));
                }

                // --

                if (fPropEvt.Data_7_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 7" }));
                }

                // --

                if (fPropEvt.Data_8_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 8" }));
                }

                // --

                if (fPropEvt.Data_9_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 9" }));
                }

                // --

                if (fPropEvt.Data_10_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 10" }));
                }

                // --

                if (fPropEvt.Data_11_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 11" }));
                }

                // --

                if (fPropEvt.Data_12_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 12" }));
                }

                // --

                if (fPropEvt.Data_13_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 13" }));
                }

                // --

                if (fPropEvt.Data_14_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 14" }));
                }

                // --

                if (fPropEvt.Data_15_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 15" }));
                }

                // --

                if (fPropEvt.Data_16_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 16" }));
                }

                // --

                if (fPropEvt.Data_17_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 17" }));
                }

                // --

                if (fPropEvt.Data_18_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 18" }));
                }

                // --

                if (fPropEvt.Data_19_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 19" }));
                }

                // --

                if (fPropEvt.Data_20_Prt.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Data 20" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserEventUpdate_In.E_ADMADS_SetUserEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hFactory, FADMADS_SetUserEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hUserId, FADMADS_SetUserEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hLanguage, FADMADS_SetUserEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hHostIp, FADMADS_SetUserEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hHostName, FADMADS_SetUserEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hStep, FADMADS_SetUserEventUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetUserEventUpdate_In.FUserEvent.E_UserEvent);
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_System,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_System,
                    FSystemCode.ADM.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Event,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Event,
                    fPropEvt.Event
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Description,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Description,
                    fPropEvt.Description
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Action,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Action,
                    fPropEvt.Action
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_SystemEvent,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_SystemEvent,
                    fPropEvt.SystemEvent.ToString()
                    );
                // --
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_1_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_2_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_3_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_4_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_5_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_6_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_7_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_8_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_9_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_10_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_11_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_12_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_13_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_14_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_15_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_16_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_17_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_18_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_19_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetUserEventUpdate_In.FUserEvent.A_Data,
                    FADMADS_SetUserEventUpdate_In.FUserEvent.D_Data,
                    fPropEvt.Data_20_Prt
                    );

                // --

                FADMADSCaster.ADMADS_SetUserEventUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetUserEventUpdate_Out.A_hStatus, FADMADS_SetUserEventUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetUserEventUpdate_Out.A_hStatusMessage, FADMADS_SetUserEventUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropEvt.Event,
                    fPropEvt.Description,
                    fPropEvt.Action,
                    fPropEvt.SystemEvent.ToString()
                };
                // --                
                key = fPropEvt.Event + "-" + fPropEvt.Action;
                grdUsrEvent.appendOrUpdateDataRow(key, cellValues);
                grdUsrEvent.activateDataRow(key);

                // --

                refreshUserTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropEvt = null;
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfServerEvent(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                grdSvrEvent.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetServerEventUpdate_In.E_ADMADS_SetServerEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hLanguage, FADMADS_SetServerEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hFactory, FADMADS_SetServerEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hUserId, FADMADS_SetServerEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hHostIp, FADMADS_SetServerEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hHostName, FADMADS_SetServerEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetServerEventUpdate_In.A_hStep, FADMADS_SetServerEventUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetServerEventUpdate_In.FServerEvent.E_ServerEvent);

                // --

                foreach (UltraDataRow dr in grdSvrEvent.selectedDataRows)
                {
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetServerEventUpdate_In.FServerEvent.A_Event,
                        FADMADS_SetServerEventUpdate_In.FServerEvent.D_Event,
                        dr["Event"].ToString()
                        );
                    // --
                    FADMADSCaster.ADMADS_SetServerEventUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetServerEventUpdate_Out.A_hStatus, FADMADS_SetServerEventUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetServerEventUpdate_Out.A_hStatusMessage, FADMADS_SetServerEventUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdSvrEvent.removeDataRow(dr.Index);
                }

                // --

                grdSvrEvent.endUpdate();

                // --

                refreshServerTotal();

                // --

                if (grdSvrEvent.Rows.Count == 0)
                {
                    initPropOfServerEvent();
                }    
      
                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdSvrEvent.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfEapEvent(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                grdEapEvent.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEapEventUpdate_In.E_ADMADS_SetEapEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hLanguage, FADMADS_SetEapEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hFactory, FADMADS_SetEapEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hUserId, FADMADS_SetEapEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hHostIp, FADMADS_SetEapEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hHostName, FADMADS_SetEapEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetEapEventUpdate_In.A_hStep, FADMADS_SetEapEventUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetEapEventUpdate_In.FEapEvent.E_EapEvent);

                // --

                foreach (UltraDataRow dr in grdEapEvent.selectedDataRows)
                {
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetEapEventUpdate_In.FEapEvent.A_Event,
                        FADMADS_SetEapEventUpdate_In.FEapEvent.D_Event,
                        dr["Event"].ToString()
                        );
                    // --
                    FADMADSCaster.ADMADS_SetEapEventUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetEapEventUpdate_Out.A_hStatus, FADMADS_SetEapEventUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetEapEventUpdate_Out.A_hStatusMessage, FADMADS_SetEapEventUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdEapEvent.removeDataRow(dr.Index);
                }

                // --

                grdEapEvent.endUpdate();

                // --

                refreshEapTotal();

                // --

                if (grdEapEvent.Rows.Count == 0)
                {
                    initPropOfEapEvent();
                }

                // --
                
                controlButton();
            }
            catch (Exception ex)
            {
                grdEapEvent.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfEqpEvent(
           )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                grdEqpEvent.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEquipmentEventUpdate_In.E_ADMADS_SetEquipmentEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hLanguage, FADMADS_SetEquipmentEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hFactory, FADMADS_SetEquipmentEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hUserId, FADMADS_SetEquipmentEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hHostIp, FADMADS_SetEquipmentEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hHostName, FADMADS_SetEquipmentEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.A_hStep, FADMADS_SetEquipmentEventUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.E_EquipmentEvent);
                fXmlNodeInEvt.set_elemVal(FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_System, FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_System, FSystemCode.ADM.ToString());

                // --

                foreach (UltraDataRow dr in grdEqpEvent.selectedDataRows)
                {
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.A_Event,
                        FADMADS_SetEquipmentEventUpdate_In.FEquipmentEvent.D_Event,
                        dr["Event"].ToString()
                        );
                    // --
                    FADMADSCaster.ADMADS_SetEquipmentEventUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentEventUpdate_Out.A_hStatus, FADMADS_SetEquipmentEventUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentEventUpdate_Out.A_hStatusMessage, FADMADS_SetEquipmentEventUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdEqpEvent.removeDataRow(dr.Index);
                }

                // --

                grdEqpEvent.endUpdate();

                // --

                refreshEquipmentTotal();

                // --

                if (grdEqpEvent.Rows.Count == 0)
                {
                    initPropOfEqpEvent();
                }

                // --
                
                controlButton();
            }
            catch (Exception ex)
            {
                grdEqpEvent.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfUserEvent(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                grdUsrEvent.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserEventUpdate_In.E_ADMADS_SetUserEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hLanguage, FADMADS_SetUserEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hFactory, FADMADS_SetUserEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hUserId, FADMADS_SetUserEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hHostIp, FADMADS_SetUserEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hHostName, FADMADS_SetUserEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserEventUpdate_In.A_hStep, FADMADS_SetUserEventUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetUserEventUpdate_In.FUserEvent.E_UserEvent);
                fXmlNodeInEvt.set_elemVal(FADMADS_SetUserEventUpdate_In.FUserEvent.A_System, FADMADS_SetUserEventUpdate_In.FUserEvent.D_System, FSystemCode.ADM.ToString());

                // --

                foreach (UltraDataRow dr in grdUsrEvent.selectedDataRows)
                {
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetUserEventUpdate_In.FUserEvent.A_Event,
                        FADMADS_SetUserEventUpdate_In.FUserEvent.D_Event,
                        dr["Event"].ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetUserEventUpdate_In.FUserEvent.A_Action,
                        FADMADS_SetUserEventUpdate_In.FUserEvent.D_Action,
                        dr["Action"].ToString()
                        );
                    // --
                    FADMADSCaster.ADMADS_SetUserEventUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetUserEventUpdate_Out.A_hStatus, FADMADS_SetUserEventUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetUserEventUpdate_Out.A_hStatusMessage, FADMADS_SetUserEventUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdUsrEvent.removeDataRow(dr.Index);
                }

                // --

                grdUsrEvent.endUpdate();

                // --

                refreshUserTotal();

                // --

                if (grdUsrEvent.Rows.Count == 0)
                {
                    initPropOfUserEvent();
                }

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdUsrEvent.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfServerEvent(
            )
        {
            try
            {
                pgdSvrEvent.selectedObject = new FPropServerEvent(m_fAdmCore, pgdSvrEvent, m_tranEnabled);
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

        private void initPropOfEapEvent(
            )
        {
            try
            {
                pgdEapEvent.selectedObject = new FPropEapEvent(m_fAdmCore, pgdEapEvent, m_tranEnabled);
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

        private void initPropOfEqpEvent(
            )
        {
            try
            {
                pgdEqpEvent.selectedObject = new FPropEquipmentEvent(m_fAdmCore, pgdEqpEvent, m_tranEnabled);
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

        private void initPropOfUserEvent(
            )
        {
            try
            {
                pgdUsrEvent.selectedObject = new FPropUserEvent(m_fAdmCore, pgdUsrEvent, m_tranEnabled);
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

        private void setPropOfServerEvent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdSvrEvent.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("event_id", grdSvrEvent.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ServerEvent", "SearchServerEvent", fSqlParams, true);

                // --

                pgdSvrEvent.selectedObject = new FPropServerEvent(m_fAdmCore, pgdSvrEvent, dt, m_tranEnabled);
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

        private void setPropOfEapEvent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdEapEvent.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("event_id", grdEapEvent.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "EapEvent", "SearchEapEvent", fSqlParams, true);

                // --

                pgdEapEvent.selectedObject = new FPropEapEvent(m_fAdmCore, pgdEapEvent, dt, m_tranEnabled);
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

        private void setPropOfEqpEvent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdEqpEvent.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("system", FSystemCode.ADM.ToString());
                fSqlParams.add("event_id", grdEqpEvent.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "EquipmentEvent", "SearchEquipmentEvent", fSqlParams, true);

                // --

                pgdEqpEvent.selectedObject = new FPropEquipmentEvent(m_fAdmCore, pgdEqpEvent, dt, m_tranEnabled);
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

        private void setPropOfUserEvent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdUsrEvent.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("system", FSystemCode.ADM.ToString());
                fSqlParams.add("event_id", grdUsrEvent.activeDataRow["Event"].ToString());
                fSqlParams.add("action", grdUsrEvent.activeDataRow["Action"].ToString());

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserEvent", "SearchUserEvent", fSqlParams, true);

                // --

                pgdUsrEvent.selectedObject = new FPropUserEvent(m_fAdmCore, pgdUsrEvent, dt, m_tranEnabled);
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

        private void refreshServerTotal(
            )
        {
            try
            {
                lblServerTotal.Text = grdSvrEvent.Rows.Count.ToString("#,##0");
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

        private void refreshEapTotal(
            )
        {
            try
            {
                lblEapTotal.Text = grdEapEvent.Rows.Count.ToString("#,##0");
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

        private void refreshEquipmentTotal(
            )
        {
            try
            {
                lblEqpTotal.Text = grdEqpEvent.Rows.Count.ToString("#,##0");
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

        private void refreshUserTotal(
            )
        {
            try
            {
                lblUserTotal.Text = grdUsrEvent.Rows.Count.ToString("#,##0");
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

        #region FEvent Form Event Handler

        private void FEvent_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Event);

                // --

                designGridOfServerEvent();
                designGridOfEapEvent();
                designGridOfEqpEvent();
                designGridOfUserEvent();

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

        private void FEvent_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfServerEvent(string.Empty);
                refreshGridOfEapEvent(string.Empty);
                refreshGridOfEqpEvent(string.Empty);
                refreshGridOfUserEvent(string.Empty);

                // --

                grdSvrEvent.Focus();
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

        private void FEvent_FormClosing(
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

        private void FEvent_KeyDown(
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
                    if (tabMain.ActiveTab.Key == "Server")
                    {
                        refreshGridOfServerEvent(grdSvrEvent.activeDataRowKey);
                    }
                    else if (tabMain.ActiveTab.Key == "Eap")
                    {
                        refreshGridOfEapEvent(grdEapEvent.activeDataRowKey);
                    }
                    else if (tabMain.ActiveTab.Key == "Eqp")
                    {
                        refreshGridOfEqpEvent(grdEqpEvent.activeDataRowKey);
                    }
                    else
                    {
                        refreshGridOfUserEvent(grdUsrEvent.activeDataRowKey);
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

        #region grdSvrEvent Control Event Handler

        private void grdSvrEvent_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfServerEvent();

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

        private void grdSvrEvent_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfServerEvent();
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

        #region grdEapEvent Control Event Handler

        private void grdEapEvent_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfEapEvent();

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

        private void grdEapEvent_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfEapEvent();
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

        #region grdEqpEvent Control Event Handler

        private void grdEqpEvent_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfEqpEvent();

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

        private void grdEqpEvent_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfEqpEvent();
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

        #region grdUsrEvent Control Event Handler

        private void grdUsrEvent_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfUserEvent();

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

        private void grdUsrEvent_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfUserEvent();
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

                if (key == "Server")
                {
                    updateGridOfServerEvent();
                }
                else if (key == "Eap")
                {
                    updateGridOfEapEvent();
                }
                else if (key == "Eqp")
                {
                    updateGridOfEqpEvent();
                }
                else if (key == "User")
                {
                    updateGridOfUserEvent();
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

                if (key == "Server")
                {
                    initPropOfServerEvent();
                }
                else if (key == "Eap")
                {
                    initPropOfEapEvent();
                }
                else if (key == "Eqp")
                {
                    initPropOfEqpEvent();
                }
                else if (key == "User")
                {
                    initPropOfUserEvent();
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

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Event" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                key = tabMain.ActiveTab.Key;

                // --

                if (key == "Server")
                {
                    deleteGridOfServerEvent();
                }
                else if (key == "Eap")
                {
                    deleteGridOfEapEvent();
                }
                else if (key == "Eqp")
                {
                    deleteGridOfEqpEvent();
                }
                else if (key == "User")
                {
                    deleteGridOfUserEvent();
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

        #region ucbEqpSystem Control Event Handler

        private void ucbEqpSystem_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEqpEvent(string.Empty);
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

        #region ucbUsrSystem Control Event Handler

        private void ucbUsrSystem_ValueChanged(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserEvent(string.Empty);
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

        #region rstSvrEvent Control Event Handler

        private void rstSvrEvent_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfServerEvent(grdSvrEvent.activeDataRowKey);
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

        private void rstSvrEvent_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdSvrEvent.searchGridRow(e.searchWord))
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

        #region rstEapEvent Control Event Handler

        private void rstEapEvent_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEapEvent(grdEapEvent.activeDataRowKey);
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

        private void rstEapEvent_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdEapEvent.searchGridRow(e.searchWord))
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

        #region rstEqpEvent Control Event Handler

        private void rstEqpEvent_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEqpEvent(grdEqpEvent.activeDataRowKey);
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

        private void rstEqpEvent_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdEqpEvent.searchGridRow(e.searchWord))
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

        #region rstUsrEvent Control Event Handler

        private void rstUsrEvent_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserEvent(grdUsrEvent.activeDataRowKey);
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

        private void rstUsrEvent_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdUsrEvent.searchGridRow(e.searchWord))
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
