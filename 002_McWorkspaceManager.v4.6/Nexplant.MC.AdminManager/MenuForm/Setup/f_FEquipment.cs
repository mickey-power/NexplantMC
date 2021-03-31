/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEquipment.cs
--  Creator         : mjkim
--  Create Date     : 2013.12.03
--  Description     : FAMate DCS Manager Setup Equipment Form Class 
--  History         : Created by mjkim at 2013.12.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win;
using Infragistics.Win.UltraWinGrid;
using System.Drawing;

namespace Nexplant.MC.AdminManager
{
    public partial class FEquipment : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEquipment(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipment(
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

        private void designGridOfEquipment(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("Equipment");
                uds.Band.Columns.Add("Equipment ID");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Equipment Class");
                uds.Band.Columns.Add("Dept. Skip Validation");
                uds.Band.Columns.Add("Equipment Type");
                uds.Band.Columns.Add("Equipment Area");
                uds.Band.Columns.Add("Equipment Line");
                uds.Band.Columns.Add("FMB Monitoring");
                uds.Band.Columns.Add("Ip Address");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Equipment"].CellAppearance.Image = Properties.Resources.Equipment;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Equipment"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Equipment ID"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Class"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Dept. Skip Validation"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Type"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Area"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Line"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["FMB Monitoring"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Ip Address"].Width = 120;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Equipment ID"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Dept. Skip Validation"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["Equipment Class"].Hidden = true;
                grdList.DisplayLayout.Bands[0].Columns["FMB Monitoring"].Hidden = true;                
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

        private void refreshGridOfEquipment(
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
                initPropOfEquipment();

                // --

                grdList.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Equipment", "ListEquipment", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Equipment
                            r[1].ToString(),   // Equipment Id
                            r[2].ToString(),   // Description
                            r[3].ToString(),   // Class
                            r[4].ToString(),   // Dept Skip Validation
                            r[5].ToString(),   // Type
                            r[6].ToString(),   // Area
                            r[7].ToString(),   // Line
                            r[8].ToString(),   // FMB Monitoring
                            r[9].ToString()    // Ip Address
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

        private void initPropOfEquipment(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropEquipment(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfEquipment(
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
                fSqlParams.add("eqp_name", grdList.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Equipment", "SearchEquipment", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropEquipment(m_fAdmCore, pgdProp, dt, m_tranEnabled);                
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

        #region Equipment Popup Menu

        private void procMenuEquipmentStatus(
            )
        {
            FEquipmentStatus fEqpStatus = null;

            try
            {
                fEqpStatus = (FEquipmentStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentStatus));
                if (fEqpStatus == null)
                {
                    fEqpStatus = new FEquipmentStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqpStatus);
                }
                // --
                fEqpStatus.attach(grdList.activeDataRowKey, FEapAttrCategory.Setup.ToString());
                fEqpStatus.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqpStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEquipmentHistory(
            )
        {
            FEquipmentHistory fEqpHistory = null;

            try
            {
                fEqpHistory = (FEquipmentHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEquipmentHistory));
                if (fEqpHistory == null)
                {
                    fEqpHistory = new FEquipmentHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEqpHistory);
                }
                // --
                fEqpHistory.attach(grdList.activeDataRowKey);
                fEqpHistory.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEqpHistory = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEquipment Form Event Handler

        private void FEquipment_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Equipment);

                // --

                designGridOfEquipment();

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

        private void FEquipment_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEquipment(string.Empty);

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

        private void FEquipment_FormClosing(
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

        private void FEquipment_KeyDown(
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
                    refreshGridOfEquipment(grdList.activeDataRowKey);
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

                setPropOfEquipment();

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

                setPropOfEquipment();
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
            object sender, MouseEventArgs e
            )
        {
            UltraGridRow r = null;

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

                mnuMenu.Tools[FMenuKey.MenuInqEqpStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentStatus);
                mnuMenu.Tools[FMenuKey.MenuInqEqpHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EquipmentHistory);                
                
                // --

                mnuMenu.ShowPopup(FMenuKey.MenuSetEqpPopupMenu);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                r = null;
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
            FPropEquipment fPropEquipment = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEqp = null;
            FXmlNode fXmlNodeOut = null;
            object[] cellValues = null;
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                fPropEquipment = (FPropEquipment)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropEquipment.Equipment, true, this.fUIWizard, "Equipment");
                // --
                if (fPropEquipment.Equipment.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Equipment" }));
                }

                // --

                if (fPropEquipment.Description.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                FCommon.validateName(fPropEquipment.Type, true, this.fUIWizard, "Type");
                // --
                if (fPropEquipment.Type.Length > 30)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Type" }));
                }

                // --

                FCommon.validateName(fPropEquipment.Area, true, this.fUIWizard, "Area");
                // --
                if (fPropEquipment.Area.Length > 30)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Area" }));
                }

                // --

                FCommon.validateName(fPropEquipment.Line, true, this.fUIWizard, "Area");
                // --
                if (fPropEquipment.Line.Length > 30)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Line" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEquipmentUpdate_In.E_ADMADS_SetEquipmentUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hLanguage, FADMADS_SetEquipmentUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hFactory, FADMADS_SetEquipmentUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hUserId, FADMADS_SetEquipmentUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hHostIp, FADMADS_SetEquipmentUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hHostName, FADMADS_SetEquipmentUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hStep, FADMADS_SetEquipmentUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInEqp = fXmlNodeIn.set_elem(FADMADS_SetEquipmentUpdate_In.FEquipment.E_Equipment);
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_Equipment, FADMADS_SetEquipmentUpdate_In.FEquipment.D_Equipment, fPropEquipment.Equipment);
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_EquipmentID, FADMADS_SetEquipmentUpdate_In.FEquipment.D_EquipmentID, fPropEquipment.EquipmentId.ToString());
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_Description, FADMADS_SetEquipmentUpdate_In.FEquipment.D_Description, fPropEquipment.Description);
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_EquipmentClass, FADMADS_SetEquipmentUpdate_In.FEquipment.D_EquipmentClass, fPropEquipment.Class.ToString());
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_DeptSkipValidation, FADMADS_SetEquipmentUpdate_In.FEquipment.D_DeptSkipValidation, fPropEquipment.DeptSkipValidation.ToString());
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_EquipmentType, FADMADS_SetEquipmentUpdate_In.FEquipment.D_EquipmentType, fPropEquipment.Type);
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_EquipmentArea, FADMADS_SetEquipmentUpdate_In.FEquipment.D_EquipmentArea, fPropEquipment.Area);
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_EquipmentLine, FADMADS_SetEquipmentUpdate_In.FEquipment.D_EquipmentLine, fPropEquipment.Line);
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_FmbMonitoring, FADMADS_SetEquipmentUpdate_In.FEquipment.D_FmbMonitoring, fPropEquipment.FmbMonitoring.ToString());
                fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_IpAddress, FADMADS_SetEquipmentUpdate_In.FEquipment.D_IpAddress, fPropEquipment.IpAddress);

                // --

                FADMADSCaster.ADMADS_SetEquipmentUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentUpdate_Out.A_hStatus, FADMADS_SetEquipmentUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentUpdate_Out.A_hStatusMessage, FADMADS_SetEquipmentUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropEquipment.Equipment,
                    fPropEquipment.EquipmentId,
                    fPropEquipment.Description,
                    fPropEquipment.Class,
                    fPropEquipment.DeptSkipValidation,
                    fPropEquipment.Type,
                    fPropEquipment.Area,
                    fPropEquipment.Line,
                    fPropEquipment.FmbMonitoring,
                    fPropEquipment.IpAddress
                };
                // --
                key = fPropEquipment.Equipment;
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
                fXmlNodeInEqp = null;
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

                initPropOfEquipment();
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
            FXmlNode fXmlNodeInEqp = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();
            
                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Equipment" }),
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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEquipmentUpdate_In.E_ADMADS_SetEquipmentUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hLanguage, FADMADS_SetEquipmentUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hFactory, FADMADS_SetEquipmentUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hUserId, FADMADS_SetEquipmentUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hHostIp, FADMADS_SetEquipmentUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hHostName, FADMADS_SetEquipmentUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetEquipmentUpdate_In.A_hStep, FADMADS_SetEquipmentUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInEqp = fXmlNodeIn.set_elem(FADMADS_SetEquipmentUpdate_In.FEquipment.E_Equipment);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInEqp.set_elemVal(FADMADS_SetEquipmentUpdate_In.FEquipment.A_Equipment, FADMADS_SetEquipmentUpdate_In.FEquipment.D_Equipment, row["Equipment"].ToString());

                    // --

                    FADMADSCaster.ADMADS_SetEquipmentUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentUpdate_Out.A_hStatus, FADMADS_SetEquipmentUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetEquipmentUpdate_Out.A_hStatusMessage, FADMADS_SetEquipmentUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdList.removeDataRow(row.Index);
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfEquipment();
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
                fXmlNodeInEqp = null;
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

                refreshGridOfEquipment(grdList.activeDataRowKey);
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

                if (e.Tool.Key == FMenuKey.MenuInqEqpStatus)
                {
                    procMenuEquipmentStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuInqEqpHistory)
                {
                    procMenuEquipmentHistory();
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
