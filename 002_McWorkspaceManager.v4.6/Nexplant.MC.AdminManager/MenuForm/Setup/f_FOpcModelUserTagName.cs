/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcModelUserTagName.cs
--  Creator         : mjkim
--  Create Date     : 2015.07.13
--  Description     : FAMate Admin Manager Setup OPC Model User Tag Name Form Class 
--  History         : Created by mjkim at 2015.07.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FOpcModelUserTagName : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcModelUserTagName(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcModelUserTagName(
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
                btnDelete.Enabled = grdUserTagName.activeDataRowKey != string.Empty && m_tranEnabled;
                // --
                btnUpdate.Enabled = grdObjectType.activeDataRowKey != string.Empty && m_tranEnabled;
                btnClear.Enabled = grdUserTagName.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void designGridOfObjectType(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdObjectType.dataSource;

                // --

                uds.Band.Columns.Add("Object Type");
                uds.Band.Columns.Add("Description");

                // --

                grdObjectType.DisplayLayout.Bands[0].Columns["Object Type"].CellAppearance.Image = Properties.Resources.OmdUserTagNameList;

                // --

                grdObjectType.DisplayLayout.Bands[0].Columns["Object Type"].Width = 120;                
                grdObjectType.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfUserTagName(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdUserTagName.dataSource;

                // --

                uds.Band.Columns.Add("Tag No");
                uds.Band.Columns.Add("Tag Name");

                // --

                grdUserTagName.DisplayLayout.Bands[0].Columns["Tag No"].CellAppearance.Image = Properties.Resources.OmdUserTagName;

                // --

                grdUserTagName.DisplayLayout.Bands[0].Columns["Tag No"].Width = 120;
                grdUserTagName.DisplayLayout.Bands[0].Columns["Tag Name"].Width = 200;
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

        private void refreshGridOfObjectType(
            string beforeKey
            )
        {
            object[] cellValues = null;
            string key = string.Empty;
            
            try
            {
                grdObjectType.removeAllDataRow();
                grdUserTagName.removeAllDataRow();
                grdObjectType.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdUserTagName.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfUserTagName();
                // --
                refreshUserTagNameTotal();

                // --
                
                grdObjectType.beginUpdate();
                
                // --

                foreach (FObjectType objType in Enum.GetValues(typeof(FObjectType)))
                {
                    cellValues = new object[] {
                        objType.ToString(),                                             // Type
                        Regex.Replace(objType.ToString(), "([a-z])([A-Z])", "$1 $2")    // Description
                        };
                    key = (string)cellValues[0];
                    grdObjectType.appendDataRow(key, cellValues);
                }

                // --

                grdObjectType.endUpdate();

                // --

                if (grdObjectType.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdObjectType.activateDataRow(beforeKey);
                    }
                    if (grdObjectType.activeDataRow == null)
                    {
                        grdObjectType.ActiveRow = grdObjectType.Rows[0];
                    }
                }

                // --

                refreshObjectTypeTotal();
                
                // --

                controlButton();

                // --

                grdObjectType.Focus();
            }
            catch (Exception ex)
            {
                grdObjectType.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfUserTagName(
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
                grdUserTagName.removeAllDataRow();
                grdUserTagName.DisplayLayout.Bands[0].SortedColumns.Clear();
                //--
                initPropOfUserTagName();

                // --

                if (grdObjectType.activeDataRow == null)
                {
                    return;
                }

                // --

                grdUserTagName.beginUpdate();                

                // --                

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.OPC.ToString());
                fSqlParams.add("obj_type", grdObjectType.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelUserTagName", "ListUserTag", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // UserTagNo
                            r[1].ToString()    // UsertagName
                            };
                        key = (string)cellValues[0];
                        grdUserTagName.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdUserTagName.endUpdate();

                // --

                if (grdUserTagName.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdUserTagName.activateDataRow(beforeKey);
                    }
                    if (grdUserTagName.activeDataRow == null)
                    {
                        grdUserTagName.ActiveRow = grdUserTagName.Rows[0];
                    }
                }

                // --

                refreshUserTagNameTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdUserTagName.endUpdate();
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

        private void updateGridOfUserTagName(
            )
        {
            FPropModelUserTagName fPropUsrTagNm = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropUsrTagNm = (FPropModelUserTagName)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropUsrTagNm.UserTag.ToString(), true, this.fUIWizard, "Tag No");
                // --
                if (fPropUsrTagNm.UserTag.ToString().Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Tag No" }));
                }

                // --

                FCommon.validateName(fPropUsrTagNm.UserTagName, true, this.fUIWizard, "Tag Name");
                // --
                if (fPropUsrTagNm.UserTagName.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Tag Name" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelUserTagNameUpdate_In.E_ADMADS_SetModelUserTagNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hLanguage, FADMADS_SetModelUserTagNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hFactory, FADMADS_SetModelUserTagNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hUserId, FADMADS_SetModelUserTagNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hHostIp, FADMADS_SetModelUserTagNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hHostName, FADMADS_SetModelUserTagNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hStep, FADMADS_SetModelUserTagNameUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInFun = fXmlNodeIn.set_elem(FADMADS_SetModelUserTagNameUpdate_In.FUserTag.E_UserTag);
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.A_ModelType,
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.D_ModelType,
                    FEapType.OPC.ToString()
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.A_ObjectType,
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.D_ObjectType,
                    grdObjectType.activeDataRowKey
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.A_UserTag,
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.D_UserTag,
                    fPropUsrTagNm.UserTag.ToString()
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.A_UserTagName,
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.D_UserTagName,
                    fPropUsrTagNm.UserTagName
                    );

                // --

                FADMADSCaster.ADMADS_SetModelUserTagNameUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelUserTagNameUpdate_Out.A_hStatus, FADMADS_SetModelUserTagNameUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelUserTagNameUpdate_Out.A_hStatusMessage));
                }

                // --

                cellValues = new object[] {
                    fPropUsrTagNm.UserTag.ToString(),   
                    fPropUsrTagNm.UserTagName
                    };
                // --
                key = fPropUsrTagNm.UserTag.ToString();
                grdUserTagName.appendOrUpdateDataRow(key, cellValues);
                grdUserTagName.activateDataRow(key);

                // --

                refreshUserTagNameTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropUsrTagNm = null;
                fXmlNodeIn = null;
                fXmlNodeInFun = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfUserTagName(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Tag No" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdUserTagName.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelUserTagNameUpdate_In.E_ADMADS_SetModelUserTagNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hLanguage, FADMADS_SetModelUserTagNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hFactory, FADMADS_SetModelUserTagNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hUserId, FADMADS_SetModelUserTagNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hHostIp, FADMADS_SetModelUserTagNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hHostName, FADMADS_SetModelUserTagNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUserTagNameUpdate_In.A_hStep, FADMADS_SetModelUserTagNameUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInFun = fXmlNodeIn.set_elem(FADMADS_SetModelUserTagNameUpdate_In.FUserTag.E_UserTag);
                // --
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.A_ModelType,
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.D_ModelType,
                    FEapType.OPC.ToString()
                    );
                // --
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.A_ObjectType,
                    FADMADS_SetModelUserTagNameUpdate_In.FUserTag.D_ObjectType,
                    grdObjectType.activeDataRowKey
                    );

                // --

                foreach (UltraDataRow row in grdUserTagName.selectedDataRows)
                {
                    fXmlNodeInFun.set_elemVal(
                        FADMADS_SetModelUserTagNameUpdate_In.FUserTag.A_UserTag,
                        FADMADS_SetModelUserTagNameUpdate_In.FUserTag.D_UserTag,
                        row["Tag No"].ToString()
                        );

                    // --

                    FADMADSCaster.ADMADS_SetModelUserTagNameUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelUserTagNameUpdate_Out.A_hStatus, FADMADS_SetModelUserTagNameUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetModelUserTagNameUpdate_Out.A_hStatusMessage, FADMADS_SetModelUserTagNameUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdUserTagName.removeDataRow(row.Index);
                }

                // --

                grdUserTagName.endUpdate();

                // --

                if (grdUserTagName.Rows.Count == 0)
                {
                    initPropOfUserTagName();
                }

                // --

                refreshUserTagNameTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdUserTagName.endUpdate();
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

        private void initPropOfUserTagName(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropModelUserTagName(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfUserTagName(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdUserTagName.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.OPC.ToString());
                fSqlParams.add("obj_type", grdObjectType.activeDataRowKey);
                fSqlParams.add("obj_tag_no", grdUserTagName.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelUserTagName", "SearchUserTag", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropModelUserTagName(m_fAdmCore, pgdProp, dt, m_tranEnabled);
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

        private void refreshObjectTypeTotal(
            )
        {
            try
            {
                lblTypeTotal.Text = grdObjectType.Rows.Count.ToString("#,##0");
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

        private void refreshUserTagNameTotal(
            )
        {
            try
            {
                lblTagTotal.Text = grdUserTagName.Rows.Count.ToString("#,##0");
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

        #region FModelUserTagName Form Event Handler

        private void FModelUserTagName_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.OpcModelUserTagName);

                // --

                designGridOfObjectType();
                designGridOfUserTagName();

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

        private void FModelUserTagName_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfObjectType(string.Empty);

                // --

                grdObjectType.Focus();
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

        private void FModelUserTagName_FormClosing(
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

        private void FOpcModelUserTagName_KeyDown(
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
                    if (grdUserTagName.Focused)
                    {
                        refreshGridOfUserTagName(grdUserTagName.activeDataRowKey);
                    }
                    else
                    {
                        refreshGridOfObjectType(grdObjectType.activeDataRowKey);
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

        #region grdObjectType Control Event Handler

        private void grdObjectType_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserTagName(string.Empty);
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

        #region grdUserTagName Control Event Handler

        private void grdUserTagName_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfUserTagName();

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

        private void grdUserTagName_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfUserTagName();
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
            try
            {
                FCursor.waitCursor();

                // --

                updateGridOfUserTagName();
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
            try
            {
                FCursor.waitCursor();

                // --

                initPropOfUserTagName();
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

                deleteGridOfUserTagName();
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

        #region rstTypeToolbar Control Event Handler

        private void rstTypeToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfObjectType(grdObjectType.activeDataRowKey);
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

        private void rstTypeToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdObjectType.searchGridRow(e.searchWord))
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

        #region rstUserTagToolbar Control Event Handler

        private void rstUserTagToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                
                refreshGridOfUserTagName(grdUserTagName.activeDataRowKey);
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

        private void rstUserTagToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdUserTagName.searchGridRow(e.searchWord))
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
