/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FUserGroup.cs
--  Creator         : kitae
--  Create Date     : 2012.03.23
--  Description     : FAMate Admin Manager Setup UserGroup Form Class 
--  History         : Created by kitae at 2012.03.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;

namespace Nexplant.MC.AdminManager
{
    public partial class FUserGroup : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FUserGroup(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUserGroup(
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

        #region Common Methods

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

                if (key == "User Group")
                {
                    btnDelete.Enabled = grdUserGroup.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnDelete.Visible = true;
                    // --
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdUserGroup.activeDataRowKey != string.Empty && m_tranEnabled; ;
                }
                else if (key == "User Group Authority")
                {
                    btnDelete.Visible = false;
                    // --
                    btnUpdate.Enabled = grdApplication.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdFunction.Rows.Count > 0 && m_tranEnabled;
                }
                else if (key == "User Group Alert")
                {
                    btnDelete.Visible = false;
                    // --
                    btnUpdate.Enabled = grdEventType.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdEvent.Rows.Count > 0 && m_tranEnabled;  
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

        private void setGridCellStyle(
            UltraGridCell cell
            )
        {
            try
            {
                cell.Activation = Activation.NoEdit;
                cell.ActiveAppearance.ForegroundAlpha = Infragistics.Win.Alpha.Transparent;
                cell.SelectedAppearance.ForegroundAlpha = Infragistics.Win.Alpha.Transparent;
                cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
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

        private Image getImageOfEvent(
            )
        {
            string eventType = string.Empty;

            try
            {
                eventType = grdEventType.activeDataRowKey;

                // --

                if (eventType == FEventType.Server.ToString())
                {
                    return grdEvent.ImageList.Images["ServerEvent"];
                }
                else if (eventType == FEventType.MC.ToString())
                {
                    return grdEvent.ImageList.Images["EapEvent"];
                }
                else if (eventType == FEventType.Equipment.ToString())
                {
                    return grdEvent.ImageList.Images["EquipmentEvent"];
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region User Group Methods

        private void designGridOfUserGroup(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdUserGroup.dataSource;

                // --

                uds.Band.Columns.Add("User Group");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("All Authority");                

                // --

                grdUserGroup.DisplayLayout.Bands[0].Columns["User Group"].Width = 260;
                grdUserGroup.DisplayLayout.Bands[0].Columns["Description"].Width = 306;
                grdUserGroup.DisplayLayout.Bands[0].Columns["All Authority"].Width = 80;
                
                // --

                grdUserGroup.DisplayLayout.Bands[0].Columns["User Group"].CellAppearance.Image = Properties.Resources.UserGroup;

                // --

                grdUserGroup.DisplayLayout.Bands[0].Columns["User Group"].Header.Fixed = true;
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

        private void refreshGridOfUserGroup(
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
                grdUserGroup.removeAllDataRow();
                grdApplication.removeAllDataRow();
                grdFunction.removeAllDataRow();
                grdEventType.removeAllDataRow();
                grdEvent.removeAllDataRow();
                grdUserGroup.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdApplication.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdFunction.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdEventType.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdEvent.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfUserGroup();
                // --
                refreshApplicationTotal();
                refreshFunctionTotal();

                // --

                grdUserGroup.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserGroup", "ListUserGroup", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // UserGroup
                            r[1].ToString(),   // Description
                            r[2].ToString()    // All Authority   
                            };
                        key = (string)cellValues[0];
                        grdUserGroup.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);
                
                // --

                grdUserGroup.endUpdate();

                // --

                if (grdUserGroup.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdUserGroup.activateDataRow(beforeKey);
                    }
                    if (grdUserGroup.activeDataRow == null)
                    {
                        grdUserGroup.ActiveRow = grdUserGroup.Rows[0];
                    }
                }

                // --

                refreshUserGroupTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "User Group")
                {
                    grdUserGroup.Focus();
                }
            }
            catch (Exception ex)
            {
                grdUserGroup.endUpdate();
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

        private void initPropOfUserGroup(
            )
        {
            try
            {
                pgdUserGroup.selectedObject = new FPropUserGroup(m_fAdmCore, pgdUserGroup, m_tranEnabled);
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

        private void setPropOfUserGroup(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdUserGroup.activeDataRow == null)
                {
                    return;
                }

                // --                

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("user_grp", grdUserGroup.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserGroup", "SearchUserGroup", fSqlParams, true);

                // --

                pgdUserGroup.selectedObject = new FPropUserGroup(m_fAdmCore, pgdUserGroup, dt, m_tranEnabled);                
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

        private void updateGridOfUserGroup(
            )
        {
            FPropUserGroup fPropUserGroup = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInUgp = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropUserGroup = (FPropUserGroup)pgdUserGroup.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropUserGroup.UserGroup, true, this.fUIWizard, "User Group");

                if (fPropUserGroup.UserGroup.Length > 20)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "User Group" }));
                }

                // --

                if (fPropUserGroup.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserGroupUpdate_In.E_ADMADS_SetUserGroupUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hLanguage, FADMADS_SetUserGroupUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hFactory, FADMADS_SetUserGroupUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hUserId, FADMADS_SetUserGroupUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hHostIp, FADMADS_SetUserGroupUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hHostName, FADMADS_SetUserGroupUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hStep, FADMADS_SetUserGroupUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInUgp = fXmlNodeIn.set_elem(FADMADS_SetUserGroupUpdate_In.FUserGroup.E_UserGroup);
                fXmlNodeInUgp.set_elemVal(
                    FADMADS_SetUserGroupUpdate_In.FUserGroup.A_UserGroup,
                    FADMADS_SetUserGroupUpdate_In.FUserGroup.E_UserGroup,
                    fPropUserGroup.UserGroup
                    );
                fXmlNodeInUgp.set_elemVal(
                    FADMADS_SetUserGroupUpdate_In.FUserGroup.A_Description,
                    FADMADS_SetUserGroupUpdate_In.FUserGroup.D_Description,
                    fPropUserGroup.Description
                    );
                fXmlNodeInUgp.set_elemVal(
                    FADMADS_SetUserGroupUpdate_In.FUserGroup.A_AllAuthority,
                    FADMADS_SetUserGroupUpdate_In.FUserGroup.D_AllAuthority,
                    fPropUserGroup.AllAuthority.ToString()
                    );

                // --

                FADMADSCaster.ADMADS_SetUserGroupUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupUpdate_Out.A_hStatus, FADMADS_SetUserGroupUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupUpdate_Out.A_hStatusMessage, FADMADS_SetUserGroupUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropUserGroup.UserGroup,
                    fPropUserGroup.Description,
                    fPropUserGroup.AllAuthority
                };
                // --
                key = fPropUserGroup.UserGroup;
                grdUserGroup.appendOrUpdateDataRow(key, cellValues);
                grdUserGroup.activateDataRow(key);

                // --

                refreshUserGroupTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropUserGroup = null;
                fXmlNodeIn = null;
                fXmlNodeInUgp = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfUserGroup(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInUrg = null;
            FXmlNode fXmlNodeOut = null;
            FPropUserGroup fPropUrg = null;

            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected User Group" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdUserGroup.beginUpdate();

                // --

                fPropUrg = (FPropUserGroup)pgdUserGroup.selectedObject;

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserGroupUpdate_In.E_ADMADS_SetUserGroupUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hLanguage, FADMADS_SetUserGroupUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hFactory, FADMADS_SetUserGroupUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hUserId, FADMADS_SetUserGroupUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hHostIp, FADMADS_SetUserGroupUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hHostName, FADMADS_SetUserGroupUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupUpdate_In.A_hStep, FADMADS_SetUserGroupUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInUrg = fXmlNodeIn.set_elem(FADMADS_SetUserGroupUpdate_In.FUserGroup.E_UserGroup);

                // --

                foreach (UltraDataRow row in grdUserGroup.selectedDataRows)
                {
                    fXmlNodeInUrg.set_elemVal(
                        FADMADS_SetUserGroupUpdate_In.FUserGroup.A_UserGroup,
                        FADMADS_SetUserGroupUpdate_In.FUserGroup.D_UserGroup,
                        row["User Group"].ToString()
                        );
                    fXmlNodeInUrg.set_elemVal(
                        FADMADS_SetUserGroupUpdate_In.FUserGroup.A_Description,
                        FADMADS_SetUserGroupUpdate_In.FUserGroup.D_Description,
                        fPropUrg.Description
                        );
                    // --

                    FADMADSCaster.ADMADS_SetUserGroupUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupUpdate_Out.A_hStatus, FADMADS_SetUserGroupUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupUpdate_Out.A_hStatusMessage, FADMADS_SetUserGroupUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdUserGroup.removeDataRow(row.Index);
                }

                // --

                grdUserGroup.endUpdate();

                // --

                refreshUserGroupTotal();

                // --

                if (grdUserGroup.Rows.Count == 0)
                {
                    initPropOfUserGroup();
                }
                
                // -- 

                controlButton();
            }
            catch (Exception ex)
            {
                grdUserGroup.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInUrg = null;
                fXmlNodeOut = null;
                fPropUrg = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region User Group Authority

        private void designGridOfApplication(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdApplication.dataSource;

                // --

                uds.Band.Columns.Add("User Group");
                uds.Band.Columns.Add("Application");
                uds.Band.Columns.Add("Description");

                // --

                grdApplication.DisplayLayout.Bands[0].Columns["User Group"].CellAppearance.Image = Properties.Resources.UserGroupApplication;

                // --

                grdApplication.DisplayLayout.Bands[0].Columns["User Group"].Width = 260;
                grdApplication.DisplayLayout.Bands[0].Columns["Application"].Width = 225;
                grdApplication.DisplayLayout.Bands[0].Columns["Description"].Width = 161;
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

        private void designGridOfFunction(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdFunction.dataSource;

                // --

                uds.Band.Columns.Add("Function");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Enabled Transaction", typeof(bool));

                // --

                grdFunction.DisplayLayout.Bands[0].Columns["Function"].CellActivation = Activation.NoEdit;
                grdFunction.DisplayLayout.Bands[0].Columns["Description"].CellActivation = Activation.NoEdit;

                // --

                grdFunction.DisplayLayout.Bands[0].Columns["Function"].CellAppearance.Image = Properties.Resources.UserGroupFunction;
                grdFunction.DisplayLayout.Bands[0].Columns["Enabled Transaction"].CellAppearance.ForeColor = System.Drawing.Color.WhiteSmoke;

                // --

                grdFunction.DisplayLayout.Bands[0].Columns["Enabled Transaction"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.CheckBox;

                // --

                grdFunction.DisplayLayout.Bands[0].Columns["Function"].Width = 330;
                grdFunction.DisplayLayout.Bands[0].Columns["Description"].Width = 380;
                grdFunction.DisplayLayout.Bands[0].Columns["Enabled Transaction"].Width = 30;
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

        private void refreshGridOfApplication(
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
                grdApplication.removeAllDataRow();
                grdFunction.removeAllDataRow();
                grdApplication.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdFunction.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                refreshFunctionTotal();

                // --

                if (grdUserGroup.ActiveRow == null)
                {
                    return;
                }

                grdApplication.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserGroupAuthority", "ListApplication", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            grdUserGroup.activeDataRowKey,
                            r[0].ToString(),   // Application
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[1];
                        grdApplication.appendDataRow(key, cellValues);
                    }

                } while (nextRowNumber >= 0);

                // --

                grdApplication.endUpdate();

                // --

                if(grdApplication.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdApplication.activateDataRow(beforeKey);
                    }
                    // --
                    if (grdApplication.activeDataRow == null)
                    {
                        grdApplication.ActiveRow = grdApplication.Rows[0];
                    }
                }

                // --

                refreshApplicationTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "User Group Authority")
                {
                    grdApplication.Focus();
                }
            }
            catch (Exception ex)
            {
                grdApplication.endUpdate();
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

        private void refreshGridOfFunction(
            string beforeKey
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                grdFunction.removeAllDataRow();
                grdFunction.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                if (grdApplication.activeDataRow == null)
                {
                    return;
                }

                // --

                grdFunction.beginUpdate(false);

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("user_grp", grdUserGroup.activeDataRowKey);
                fSqlParams.add("app", grdApplication.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserGroupAuthority", "ListAuthority", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),                                        // Function
                            r[1].ToString(),                                        // Description
                            (FBoolean)Enum.Parse(typeof(FBoolean), r[2].ToString()) // Enabled Transaction
                            };
                        key = (string)cellValues[0];
                        index = grdFunction.appendDataRow(key, cellValues).Index;
                        // --
                        if (r[3].ToString() == FYesNo.No.ToString())
                        {
                            setGridCellStyle(grdFunction.Rows.GetRowWithListIndex(index).Cells["Enabled Transaction"]);
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdFunction.endUpdate(false);

                // --

                if (grdFunction.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdFunction.activateDataRow(beforeKey);
                    }
                    if (grdFunction.activeDataRow == null)
                    {
                        grdFunction.ActiveRow = grdFunction.Rows[0];
                    }
                }

                // --

                refreshFunctionTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "User Group Authority")
                {
                    grdFunction.Focus();
                }
            }
            catch (Exception ex)
            {
                grdFunction.endUpdate(false);
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

        private void procMenuAttachAuthority(
            )
        {
            FUserGroupFunctionSelector fFunctionSelector = null;
            string key = string.Empty;
            object[] cellValues = null;
            int index = 0;

            try
            {
                if (grdApplication.Rows.Count == 0)
                {
                    return;
                }

                // --

                fFunctionSelector = new FUserGroupFunctionSelector(m_fAdmCore, grdApplication.activeDataRowKey);
                if (fFunctionSelector.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                grdFunction.beginUpdate(false);

                // --

                foreach (FUserFunctionData fData in fFunctionSelector.selectedFunctionList)
                {
                    key = fData.function;
                    if (grdFunction.getDataRow(key) == null)
                    {
                        cellValues = new object[] {
                            fData.function,
                            fData.description,
                            false
                            };
                        index = grdFunction.appendOrUpdateDataRow(key, cellValues).Index;
                        // --
                        if (fData.usedTransaction == FYesNo.No)
                        {
                            setGridCellStyle(grdFunction.Rows.GetRowWithListIndex(index).Cells["Enabled Transaction"]);
                        }
                    }
                    grdFunction.activateDataRow(key);
                }

                // --

                grdFunction.endUpdate(false);

                // --

                if (grdFunction.activeDataRow == null)
                {
                    grdFunction.ActiveRow = grdFunction.Rows[0];
                }

                // --

                refreshFunctionTotal();
            }
            catch (Exception ex)
            {
                grdFunction.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFunctionSelector != null)
                {
                    fFunctionSelector.Dispose();
                    fFunctionSelector = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuDetachAuthority(
            )
        {
            try
            {
                if (grdFunction.Rows.Count == 0)
                {
                    return;
                }

                // --

                grdFunction.beginUpdate();

                // --

                grdFunction.removeDataRows(grdFunction.selectedDataRowKeys);

                // --

                grdFunction.endUpdate();

                // --

                refreshFunctionTotal();
            }
            catch (Exception ex)
            {
                grdFunction.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopyAuthority(
            )
        {
            FUserGroupAuthoritySelector fAuthoritySelector = null;
            string key = string.Empty;
            object[] cellValues = null;
            int index = 0;

            try
            {
                if (grdApplication.Rows.Count == 0)
                {
                    return;
                }

                // --

                fAuthoritySelector = new FUserGroupAuthoritySelector(m_fAdmCore, grdApplication.activeDataRowKey);
                if (fAuthoritySelector.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                grdFunction.beginUpdate(false);
                grdFunction.removeAllDataRow();

                // --

                foreach (FUserFunctionData fData in fAuthoritySelector.functionList)
                {
                    cellValues = new object[] {
                            fData.function,          // Function
                            fData.description,       // Description
                            fData.enabledTransaction // Enabled Transaction
                            };
                    key = (string)cellValues[0];
                    index = grdFunction.appendDataRow(key, cellValues).Index;
                    // --
                    if (fData.usedTransaction == FYesNo.No)
                    {
                        setGridCellStyle(grdFunction.Rows.GetRowWithListIndex(index).Cells["Enabled Transaction"]);
                    }
                }

                // --

                grdFunction.endUpdate(false);

                // --
                if (grdFunction.Rows.Count > 0)
                {
                    if (grdFunction.activeDataRow == null)
                    {
                        grdFunction.ActiveRow = grdFunction.Rows[0];
                    }
                }

                // --

                refreshFunctionTotal();
            }
            catch (Exception ex)
            {
                grdFunction.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                if (fAuthoritySelector != null)
                {
                    fAuthoritySelector.Dispose();
                    fAuthoritySelector = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuClearAuthority(
            )
        {
            try
            {
                grdFunction.beginUpdate();

                // --

                grdFunction.removeAllDataRow();

                // --

                grdFunction.endUpdate();

                // --

                refreshFunctionTotal();
            }
            catch (Exception ex)
            {
                grdFunction.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfAuthority(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInAut = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserGroupAuthorityUpdate_In.E_ADMADS_SetUserGroupAuthorityUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAuthorityUpdate_In.A_hLanguage, FADMADS_SetUserGroupAuthorityUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAuthorityUpdate_In.A_hFactory, FADMADS_SetUserGroupAuthorityUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAuthorityUpdate_In.A_hUserId, FADMADS_SetUserGroupAuthorityUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAuthorityUpdate_In.A_hHostIp, FADMADS_SetUserGroupAuthorityUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAuthorityUpdate_In.A_hHostName, FADMADS_SetUserGroupAuthorityUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAuthorityUpdate_In.A_hStep, FADMADS_SetUserGroupAuthorityUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInAut = fXmlNodeIn.set_elem(FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.E_Authority);
                fXmlNodeInAut.set_elemVal(
                    FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.A_UserGroup,
                    FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.D_UserGroup,
                    grdUserGroup.activeDataRowKey
                    );
                fXmlNodeInAut.set_elemVal(
                    FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.A_Application,
                    FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.D_Application,
                    grdApplication.activeDataRowKey
                    );
                // --
                foreach (UltraGridRow row in grdFunction.Rows)
                {
                    fXmlNodeInFun = fXmlNodeInAut.add_elem(FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.FFunction.E_Function);
                    fXmlNodeInFun.set_elemVal(
                        FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.FFunction.A_Function,
                        FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.FFunction.D_Function,
                        row.Cells["Function"].Value.ToString()
                        );
                    fXmlNodeInFun.set_elemVal(
                        FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.FFunction.A_EnabledTransaction,
                        FADMADS_SetUserGroupAuthorityUpdate_In.FAuthority.FFunction.D_EnabledTransaction,
                        row.Cells["Enabled Transaction"].Value.ToString()
                        );
                }

                // --

                FADMADSCaster.ADMADS_SetUserGroupAuthorityUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupAuthorityUpdate_Out.A_hStatus, FADMADS_SetUserGroupAuthorityUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupAuthorityUpdate_Out.A_hStatusMessage));
                }

                // --

                // ***
                // Authority Tab에는 Delete Button이 없어 update시 Button Control수행
                // ***
                controlButton();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInAut = null;
                fXmlNodeInFun = null;
                fXmlNodeOut = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region User Group Alert

        //------------------------------------------------------------------------------------------------------------------------   

        private void designGridOfEventType(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEventType.dataSource;

                // --

                uds.Band.Columns.Add("User Group");
                uds.Band.Columns.Add("Event Type");
                uds.Band.Columns.Add("Description");

                // --

                grdEventType.DisplayLayout.Bands[0].Columns["User Group"].CellAppearance.Image = Properties.Resources.Event;

                // --

                grdEventType.DisplayLayout.Bands[0].Columns["User Group"].Width = 260;
                grdEventType.DisplayLayout.Bands[0].Columns["Event Type"].Width = 225;
                grdEventType.DisplayLayout.Bands[0].Columns["Description"].Width = 161;
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

        private void designGridOfEvent(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEvent.dataSource;
                // --
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");

                // --

                grdEvent.DisplayLayout.Bands[0].Columns["Event"].CellActivation = Activation.NoEdit;
                grdEvent.DisplayLayout.Bands[0].Columns["Description"].CellActivation = Activation.NoEdit;
                // --
                grdEvent.DisplayLayout.Bands[0].Columns["Event"].Width = 330;
                grdEvent.DisplayLayout.Bands[0].Columns["Description"].Width = 225;

                // --

                grdEvent.ImageList = new ImageList();
                // --
                grdEvent.ImageList.Images.Add("ServerEvent", Properties.Resources.ServerEvent);
                grdEvent.ImageList.Images.Add("EapEvent", Properties.Resources.EapEvent);
                grdEvent.ImageList.Images.Add("EquipmentEvent", Properties.Resources.EquipmentEvent);
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

        private void refreshGridOfEventType(
            string beforeKey
            )
        {
            object[] cellValues = null;
            string key = string.Empty;

            try
            {
                grdEventType.removeAllDataRow();
                grdEvent.removeAllDataRow();
                grdEventType.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdEvent.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                if (grdUserGroup.ActiveRow == null)
                {
                    return;
                }

                // --

                grdEventType.beginUpdate();

                // --

                foreach (FEventType evtType in Enum.GetValues(typeof(FEventType)))
                {
                    // ***
                    // User Event는 Alert으로 등록하지 않는다.
                    // ***
                    if (evtType == FEventType.User)
                    {
                        continue;
                    }

                    // --

                    cellValues = new object[] {
                        grdUserGroup.activeDataRowKey,                  // User Group
                        evtType.ToString(),                             // Event Type
                        string.Format("{0} Event", evtType.ToString())  // Description
                        };
                    key = cellValues[1].ToString();
                    grdEventType.appendDataRow(key, cellValues);
                }
                
                // --

                grdEventType.endUpdate();

                // --

                if (grdEventType.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdEventType.activateDataRow(beforeKey);
                    }
                    if (grdEventType.activeDataRow == null)
                    {
                        grdEventType.ActiveRow = grdEventType.Rows[0];
                    }
                }

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdEventType.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEvent(
            string beforeKey
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                grdEvent.removeAllDataRow();
                grdEvent.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                if (grdEventType.activeDataRow == null)
                {
                    return;
                }

                // --

                grdEvent.beginUpdate(false);

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("user_grp", grdUserGroup.activeDataRowKey);
                fSqlParams.add("event_type", grdEventType.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "UserGroupAlert", "ListUserGroupAlert", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(), // Event
                            r[1].ToString()  // Description
                            };
                        key = (string)cellValues[0];
                        index = grdEvent.appendDataRow(key, cellValues).Index;

                        // --

                        grdEvent.Rows.GetRowWithListIndex(index).Cells["Event"].Appearance.Image = getImageOfEvent();
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEvent.endUpdate(false);

                // --

                if (grdEvent.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdEvent.activateDataRow(beforeKey);
                    }
                    if (grdEvent.activeDataRow == null)
                    {
                        grdEvent.ActiveRow = grdEvent.Rows[0];
                    }
                }

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdEvent.endUpdate(false);
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

        private void procMenuAttachAlert(
            )
        {
            FEventSelector fEventSelector = null;
            string key = string.Empty;
            object[] cellValues = null;
            int index = 0;

            try
            {
                if (grdEventType.Rows.Count == 0)
                {
                    return;
                }

                // --

                fEventSelector = new FEventSelector(m_fAdmCore, grdEventType.activeDataRowKey);
                if (fEventSelector.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                grdEvent.beginUpdate(false);

                // --

                foreach (string[] fData in fEventSelector.selectedEventList)
                {
                    key = fData[0];
                    if (grdEvent.getDataRow(key) == null)
                    {
                        cellValues = new object[] {
                            fData[0], // Event
                            fData[1]  // Description
                            };
                        index = grdEvent.appendOrUpdateDataRow(key, cellValues).Index;
                        // --
                        grdEvent.Rows.GetRowWithListIndex(index).Cells["Event"].Appearance.Image = getImageOfEvent();
                    }
                    grdEvent.activateDataRow(key);
                }

                // --

                grdEvent.endUpdate(false);

                // --

                if (grdEvent.activeDataRow == null)
                {
                    grdEvent.ActiveRow = grdEvent.Rows[0];
                }
            }
            catch (Exception ex)
            {
                grdEvent.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                if (fEventSelector != null)
                {
                    fEventSelector.Dispose();
                    fEventSelector = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuDetachAlert(
            )
        {
            try
            {
                if (grdEvent.Rows.Count == 0)
                {
                    return;
                }

                // --

                grdEvent.beginUpdate();

                // --

                grdEvent.removeDataRows(grdEvent.selectedDataRowKeys);

                // --

                grdEvent.endUpdate();
            }
            catch (Exception ex)
            {
                grdEvent.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuCopyAlert(
            )
        {
            FUserGroupAlertSelector fUserGroupAlertSelector = null;
            string key = string.Empty;
            object[] cellValues = null;
            int index = 0;

            try
            {
                if (grdEventType.Rows.Count == 0)
                {
                    return;
                }

                // --

                fUserGroupAlertSelector = new FUserGroupAlertSelector(m_fAdmCore, grdEventType.activeDataRowKey);
                if (fUserGroupAlertSelector.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                grdEvent.beginUpdate(false);
                grdEvent.removeAllDataRow();

                // --

                foreach (string[] fData in fUserGroupAlertSelector.eventList)
                {
                    cellValues = new object[] {
                            fData[0], // Event
                            fData[1]  // Descriptioin
                            };
                    key = (string)cellValues[0];
                    index = grdEvent.appendDataRow(key, cellValues).Index;
                    // --
                    grdEvent.Rows.GetRowWithListIndex(index).Cells["Event"].Appearance.Image = getImageOfEvent();
                }

                // --

                grdEvent.endUpdate(false);

                // --

                if (grdEvent.Rows.Count > 0)
                {
                    if (grdEvent.activeDataRow == null)
                    {
                        grdEvent.ActiveRow = grdEvent.Rows[0];
                    }
                }
             }
            catch (Exception ex)
            {
                grdEvent.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                if (fUserGroupAlertSelector != null)
                {
                    fUserGroupAlertSelector.Dispose();
                    fUserGroupAlertSelector = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuClearAlert(
            )
        {
            try
            {
                grdEvent.beginUpdate();

                // --

                grdEvent.removeAllDataRow();

                // --

                grdEvent.endUpdate();
            }
            catch (Exception ex)
            {
                grdEvent.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfAlert(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInAlt = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetUserGroupAlertUpdate_In.E_ADMADS_SetUserGroupAlertUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAlertUpdate_In.A_hLanguage, FADMADS_SetUserGroupAlertUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAlertUpdate_In.A_hFactory, FADMADS_SetUserGroupAlertUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAlertUpdate_In.A_hUserId, FADMADS_SetUserGroupAlertUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAlertUpdate_In.A_hHostIp, FADMADS_SetUserGroupAlertUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAlertUpdate_In.A_hHostName, FADMADS_SetUserGroupAlertUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetUserGroupAlertUpdate_In.A_hStep, FADMADS_SetUserGroupAlertUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInAlt = fXmlNodeIn.set_elem(FADMADS_SetUserGroupAlertUpdate_In.FAlert.E_Alert);
                fXmlNodeInAlt.set_elemVal(
                    FADMADS_SetUserGroupAlertUpdate_In.FAlert.A_UserGroup,
                    FADMADS_SetUserGroupAlertUpdate_In.FAlert.D_UserGroup,
                    grdUserGroup.activeDataRowKey
                    );
                fXmlNodeInAlt.set_elemVal(
                    FADMADS_SetUserGroupAlertUpdate_In.FAlert.A_EventType,
                    FADMADS_SetUserGroupAlertUpdate_In.FAlert.D_EventType,
                    grdEventType.activeDataRowKey
                    );
                // --
                foreach (UltraGridRow row in grdEvent.Rows)
                {
                    fXmlNodeInEvt = fXmlNodeInAlt.add_elem(FADMADS_SetUserGroupAlertUpdate_In.FAlert.FEvent.E_Event);
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetUserGroupAlertUpdate_In.FAlert.FEvent.A_Event,
                        FADMADS_SetUserGroupAlertUpdate_In.FAlert.FEvent.D_Event,
                        row.Cells["Event"].Value.ToString()
                        );
                }

                // --

                FADMADSCaster.ADMADS_SetUserGroupAlertUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupAlertUpdate_Out.A_hStatus, FADMADS_SetUserGroupAlertUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetUserGroupAlertUpdate_Out.A_hStatusMessage));
                }

                // --

                // ***
                // Alert Tab에는 Delete Button이 없어 update시 Button Control수행
                // ***
                controlButton();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInAlt = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshUserGroupTotal(
            )
        {
            try
            {
                lblGrpTotal.Text = grdUserGroup.Rows.Count.ToString("#,##0");
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

        private void refreshApplicationTotal(
            )
        {
            try
            {
                lblAppTotal.Text = grdApplication.Rows.Count.ToString("#,##0");
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
                lblFunTotal.Text = grdFunction.Rows.Count.ToString("#,##0");
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

        #region FUserGroup Form Event Handler

        private void FUserGroup_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.UserGroup);

                // --

                designGridOfUserGroup();
                designGridOfApplication();
                designGridOfFunction();
                designGridOfEventType();
                designGridOfEvent();

                // --

                controlButton();

                // --

                if (!m_tranEnabled)
                {
                    grdFunction.dataSource.Band.Columns["Enabled Transaction"].ReadOnly = Infragistics.Win.DefaultableBoolean.True;
                }

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

        private void FUserGroup_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserGroup(string.Empty);

                // --

                grdUserGroup.Focus();
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

        private void FUserGroup_FormClosing(
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

        private void FUserGroup_KeyDown(
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
                    if (tabMain.ActiveTab.Key == "User Group")
                    {
                        refreshGridOfUserGroup(grdUserGroup.activeDataRowKey);
                    }                    
                    else
                    {
                        if (grdFunction.Focused)
                        {
                            refreshGridOfFunction(grdFunction.activeDataRowKey);
                        }
                        else
                        {
                            refreshGridOfApplication(grdApplication.activeDataRowKey);
                        }
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

        #region grdUserGroup Control Event Handler

        private void grdUserGroup_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfUserGroup();

                // --

                refreshGridOfApplication(string.Empty);
                refreshGridOfEventType(string.Empty);
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

        private void grdUserGroup_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.SelectedTab = tabMain.Tabs["User Group Authority"];

                // --

                grdApplication.Focus();
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

        private void grdUserGroup_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfUserGroup();
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

        #region grdApplication Control Event Handler

        private void grdApplication_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfFunction(string.Empty);
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

        private void grdApplication_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                //refreshGridOfFunction(string.Empty);
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
        
        #region grdEventType Control Event Handler

        private void grdEventType_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEvent(string.Empty);
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

        private void grdEventType_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEvent(string.Empty);
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

        #region rstUserGroupToolbar Control Event Handler

        private void rstUserGroupToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserGroup(grdUserGroup.activeDataRowKey);
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

        private void rstUserGroupToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdUserGroup.searchGridRow(e.searchWord))
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

        #region btnAppendFunction Control Event Handler

        private void btnAppendFunction_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuAttachAuthority();

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

        #region btnRemoveFunction Control Event Handler

        private void btnRemoveFunction_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuDetachAuthority();
                
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

        #region btnCopyAuthority Control Event Handler

        private void btnCopyAuthority_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuCopyAuthority();
                
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

        #region btnAppendEvent Control Event Handler

        private void btnAppendEvent_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuAttachAlert();

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

        #region btnRemoveEvent Control Event Handler

        private void btnRemoveEvent_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuDetachAlert();

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

        #region btnCopyAlert Control Event Handler

        private void btnCopyAlert_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procMenuCopyAlert();

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

                refreshGridOfApplication(grdApplication.activeDataRowKey);
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

                if (!grdApplication.searchGridRow(e.searchWord))
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

                refreshGridOfFunction(grdFunction.activeDataRowKey);
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

                if (!grdFunction.searchGridRow(e.searchWord))
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

        #region rstEventTypeToolbar Control Event Handler

        private void rstEventTypeToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEventType(grdApplication.activeDataRowKey);
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

        private void rstEventTypeToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdEventType.searchGridRow(e.searchWord))
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

        #region rstEvtToolbar Control Event Handler

        private void rstEvtToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEvent(grdEvent.activeDataRowKey);
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

        private void rstEvtToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdEvent.searchGridRow(e.searchWord))
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

                if (key == "User Group")
                {
                    updateGridOfUserGroup();
                }
                else if (key == "User Group Authority")
                {
                    updateGridOfAuthority();
                }
                else if (key == "User Group Alert")
                {
                    updateGridOfAlert();
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

                if (key == "User Group")
                {
                    initPropOfUserGroup();
                }
                else if (key == "User Group Authority")
                {
                    procMenuClearAuthority();

                    // --

                    controlButton();
                }
                else if (key == "User Group Alert")
                {
                    procMenuClearAlert();

                    // --

                    controlButton();
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
            try
            {
                FCursor.waitCursor();

                // --

                if (tabMain.ActiveTab.Key != "User Group")
                {
                    return;
                }

                // --

                deleteGridOfUserGroup();
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
