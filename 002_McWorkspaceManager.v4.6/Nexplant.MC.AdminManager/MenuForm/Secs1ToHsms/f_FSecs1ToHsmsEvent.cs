/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecs1ToHsmsEvent.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.21
--  Description     : FAMate Admin Manager Setup SECS1 To Hsms Event Form Class 
--  History         : Created by spike.lee at 2017.04.21
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
    public partial class FSecs1ToHsmsEvent : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1ToHsmsEvent(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1ToHsmsEvent(
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

        private void designGridOfSecs1ToHsmsEvent(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("System Event");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Event"].CellAppearance.Image = Properties.Resources.S2HEvent;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Event"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Event"].Width = 260;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 350;
                grdList.DisplayLayout.Bands[0].Columns["System Event"].Width = 70;
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

        private void refreshGridOfSecs1ToHsmsEvent(
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
                initPropOfSecs1ToHsmsEvent();

                //--

                grdList.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Secs1ToHsms", "Secs1ToHsmsEvent", "ListSecs1ToHsmsEvent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // EVent
                            r[1].ToString(),   // Description
                            r[2].ToString()    // System Event
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

        private void initPropOfSecs1ToHsmsEvent(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropSecs1ToHsmsEvent(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfSecs1ToHsmsEvent(
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
                fSqlParams.add("event_id", grdList.activeDataRowKey);
                // --
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Secs1ToHsms", "Secs1ToHsmsEvent", "SearchSecs1ToHsmsEvent", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropSecs1ToHsmsEvent(m_fAdmCore, pgdProp, dt, m_tranEnabled);
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

        #region FSecs1ToHsmsEvent Form Event Handler

        private void FSecs1ToHsmsEvent_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Secs1ToHsmsEvent);

                // --

                designGridOfSecs1ToHsmsEvent();

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

        private void FSecs1ToHsmsEvent_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfSecs1ToHsmsEvent(string.Empty);

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

        private void FSecs1ToHsmsEvent_FormClosing(
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

        private void FSecs1ToHsmsEvent_KeyDown(
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
                    refreshGridOfSecs1ToHsmsEvent(grdList.activeDataRowKey);
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

                setPropOfSecs1ToHsmsEvent();

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

                setPropOfSecs1ToHsmsEvent();
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
            FPropSecs1ToHsmsEvent fPropEvt = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                FCursor.waitCursor();

                // --

                fPropEvt = (FPropSecs1ToHsmsEvent)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropEvt.Event, true, this.fUIWizard, "Event");

                if (fPropEvt.Event.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Event" }));
                }

                if (fPropEvt.Description.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetSecs1ToHsmsEventUpdate_In.E_ADMADS_SetSecs1ToHsmsEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hLanguage, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hFactory, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hUserId, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hHostIp, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hHostName, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName); 
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hStep, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hStep, "1");                
                // --
                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.E_Secs1ToHsmsEvent);
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Event, 
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Event,
                    fPropEvt.Event
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Description,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Description,
                    fPropEvt.Description
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_SystemEvent,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_SystemEvent,
                    fPropEvt.SystemEvent.ToString()
                    );
                // --
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_1_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_2_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_3_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_4_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_5_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_6_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_7_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_8_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_9_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_10_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_11_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_12_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_13_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_14_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_15_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_16_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_17_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_18_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_19_Prt
                    );
                fXmlNodeInEvt.add_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Data,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Data,
                    fPropEvt.Data_20_Prt
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Comment,
                    FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Comment,
                    fPropEvt.Comment
                    );

                // --

                FADMADSCaster.ADMADS_SetSecs1ToHsmsEventUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_Out.A_hStatus, FADMADS_SetSecs1ToHsmsEventUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_Out.A_hStatusMessage, FADMADS_SetSecs1ToHsmsEventUpdate_Out.D_hStatusMessage)
                        );
                }

                // --
                
                cellValues = new object[]
                {
                    fPropEvt.Event,
                    fPropEvt.Description,
                    fPropEvt.SystemEvent.ToString()
                };
                // --
                key = fPropEvt.Event;
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
                fPropEvt = null;
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
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

                initPropOfSecs1ToHsmsEvent();
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
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected SECS1 To HSMS Event" }),
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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetSecs1ToHsmsEventUpdate_In.E_ADMADS_SetSecs1ToHsmsEventUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hLanguage, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hFactory, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hUserId, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hHostIp, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hHostName, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_In.A_hStep, FADMADS_SetSecs1ToHsmsEventUpdate_In.D_hStep, "2");                
                // --
                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.E_Secs1ToHsmsEvent);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.A_Event,
                        FADMADS_SetSecs1ToHsmsEventUpdate_In.FSecs1ToHsmsEvent.D_Event, 
                        row["Event"].ToString()
                        );

                    // --
                    
                    FADMADSCaster.ADMADS_SetSecs1ToHsmsEventUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_Out.A_hStatus, FADMADS_SetSecs1ToHsmsEventUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetSecs1ToHsmsEventUpdate_Out.A_hStatusMessage, FADMADS_SetSecs1ToHsmsEventUpdate_Out.D_hStatusMessage)
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
                    initPropOfSecs1ToHsmsEvent();
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
                fXmlNodeInEvt = null;
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

                refreshGridOfSecs1ToHsmsEvent(grdList.activeDataRowKey);
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
