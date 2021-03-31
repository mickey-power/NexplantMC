/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpModelObjectName.cs
--  Creator         : mjkim
--  Create Date     : 2015.07.13
--  Description     : FAMate Admin Manager Setup TCP Model Object Name Form Class 
--  History         : Created by mjkim at 2015.07.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FTcpModelObjectName : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpModelObjectName(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpModelObjectName(
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
                btnDelete.Enabled = grdObjectName.activeDataRowKey != string.Empty && m_tranEnabled;
                // --
                btnUpdate.Enabled = grdObjectType.activeDataRowKey != string.Empty && m_tranEnabled;
                btnClear.Enabled = grdObjectName.activeDataRowKey != string.Empty && m_tranEnabled;
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

                grdObjectType.DisplayLayout.Bands[0].Columns["Object Type"].CellAppearance.Image = Properties.Resources.TmdObjectNameList;

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

        private void designGridOfObjectName(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdObjectName.dataSource;

                // --

                uds.Band.Columns.Add("Object Name");
                uds.Band.Columns.Add("Description");

                // --

                grdObjectName.DisplayLayout.Bands[0].Columns["Object Name"].CellAppearance.Image = Properties.Resources.TmdObjectName;

                // --

                grdObjectName.DisplayLayout.Bands[0].Columns["Object Name"].Width = 120;
                grdObjectName.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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
                grdObjectName.removeAllDataRow();
                grdObjectType.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdObjectName.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfModelObjectName();
                // --
                refreshModelObjectNameTotal();

                // --

                grdObjectType.beginUpdate();
                
                // --

                foreach (FObjectType objType in Enum.GetValues(typeof(FObjectType)))
                {
                    cellValues = new object[] {
                        objType.ToString(),                                          // Type (ex:TcpDriver)
                        Regex.Replace(objType.ToString(), "([a-z])([A-Z])", "$1 $2") // Description (ex:Tcp Driver)
                        };
                    // --
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

                refreshModelObjectTypeTotal();
                
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

        private void refreshGridOfObjectName(
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
                grdObjectName.removeAllDataRow();
                grdObjectName.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfModelObjectName();

                // --

                if (grdObjectType.activeDataRow == null)
                {
                    return;
                }
                
                // --

                grdObjectName.beginUpdate();
                
                // --                

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                fSqlParams.add("obj_type", grdObjectType.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelObjectName", "ListObjectName", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Name
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[0];
                        grdObjectName.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdObjectName.endUpdate();

                // --

                if (grdObjectName.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdObjectName.activateDataRow(beforeKey);
                    }
                    if (grdObjectName.activeDataRow == null)
                    {
                        grdObjectName.ActiveRow = grdObjectName.Rows[0];
                    }
                }

                // --

                refreshModelObjectNameTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdObjectName.endUpdate();
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

        private void updateGridOfObjectName(
            )
        {
            FPropModelObjectName fPropMdlObjNm = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeOut = null;
            object[] cellValues = null;
            string key = string.Empty;

            try
            {
                fPropMdlObjNm = (FPropModelObjectName)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropMdlObjNm.ObjectName, true, this.fUIWizard, "Object Name");
                // --
                if (fPropMdlObjNm.ObjectName.Length > 100)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Object Name" }));
                }

                // --

                if (fPropMdlObjNm.Description.Length > 256)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelObjectNameUpdate_In.E_ADMADS_SetModelObjectNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hLanguage, FADMADS_SetModelObjectNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hFactory, FADMADS_SetModelObjectNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hUserId, FADMADS_SetModelObjectNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hHostIp, FADMADS_SetModelObjectNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hHostName, FADMADS_SetModelObjectNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hStep, FADMADS_SetModelObjectNameUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInFun = fXmlNodeIn.set_elem(FADMADS_SetModelObjectNameUpdate_In.FObejctName.E_ObejctName);
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.A_ModelType,
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.D_ModelType,
                    FEapType.TCP.ToString()
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.A_ObjectType,
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.D_ObjectType,
                    grdObjectType.activeDataRowKey
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.A_ObjectName,
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.D_ObjectName,
                    fPropMdlObjNm.ObjectName
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.A_Description,
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.D_Description,
                    fPropMdlObjNm.Description
                    );

                // --

                FADMADSCaster.ADMADS_SetModelObjectNameUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelObjectNameUpdate_Out.A_hStatus, FADMADS_SetModelObjectNameUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelObjectNameUpdate_Out.A_hStatusMessage));
                }

                // --

                cellValues = new object[] 
                {
                    fPropMdlObjNm.ObjectName,   
                    fPropMdlObjNm.Description
                };
                // --
                key = fPropMdlObjNm.ObjectName;
                grdObjectName.appendOrUpdateDataRow(key, cellValues);
                grdObjectName.activateDataRow(key);

                // --

                refreshModelObjectNameTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropMdlObjNm = null;
                fXmlNodeIn = null;
                fXmlNodeInFun = null;
                fXmlNodeOut = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfObjectName(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Obejct Name" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdObjectName.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelObjectNameUpdate_In.E_ADMADS_SetModelObjectNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hLanguage, FADMADS_SetModelObjectNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hFactory, FADMADS_SetModelObjectNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hUserId, FADMADS_SetModelObjectNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hHostIp, FADMADS_SetModelObjectNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hHostName, FADMADS_SetModelObjectNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelObjectNameUpdate_In.A_hStep, FADMADS_SetModelObjectNameUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInFun = fXmlNodeIn.set_elem(FADMADS_SetModelObjectNameUpdate_In.FObejctName.E_ObejctName);
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.A_ModelType,
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.D_ModelType,
                    FEapType.TCP.ToString()
                    );
                fXmlNodeInFun.set_elemVal(
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.A_ObjectType,
                    FADMADS_SetModelObjectNameUpdate_In.FObejctName.D_ObjectType,
                    grdObjectType.activeDataRowKey
                    );

                // --

                foreach (UltraDataRow row in grdObjectName.selectedDataRows)
                {
                    fXmlNodeInFun.set_elemVal(
                        FADMADS_SetModelObjectNameUpdate_In.FObejctName.A_ObjectName,
                        FADMADS_SetModelObjectNameUpdate_In.FObejctName.D_ObjectName,
                        row["Object Name"].ToString()
                        );

                    // --

                    FADMADSCaster.ADMADS_SetModelObjectNameUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelObjectNameUpdate_Out.A_hStatus, FADMADS_SetModelObjectNameUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetModelObjectNameUpdate_Out.A_hStatusMessage, FADMADS_SetModelObjectNameUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdObjectName.removeDataRow(row.Index);
                }

                // --

                grdObjectName.endUpdate();

                // --

                if (grdObjectName.Rows.Count == 0)
                {
                    initPropOfModelObjectName();
                }

                // --

                refreshModelObjectNameTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdObjectName.endUpdate();
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

        private void initPropOfModelObjectName(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropModelObjectName(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfModelObjectName(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdObjectName.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                fSqlParams.add("obj_type", grdObjectType.activeDataRowKey);
                fSqlParams.add("obj_name", grdObjectName.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelObjectName", "SearchObjectName", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropModelObjectName(m_fAdmCore, pgdProp, dt, m_tranEnabled);
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

        private void refreshModelObjectTypeTotal(
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

        private void refreshModelObjectNameTotal(
            )
        {
            try
            {
                lblNameTotal.Text = grdObjectName.Rows.Count.ToString("#,##0");
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

        #region FModelObjectName Form Event Handler

        private void FModelObjectName_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.TcpModelObjectName);

                // --

                designGridOfObjectType();
                designGridOfObjectName();

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

        private void FModelObjectName_Shown(
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

        private void FModelObjectName_FormClosing(
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

        private void FTcpModelObjectName_KeyDown(
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
                    if (grdObjectName.Focused)
                    {
                        refreshGridOfObjectName(grdObjectName.activeDataRowKey);
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

                refreshGridOfObjectName(string.Empty);
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

        #region grdObjectName Control Event Handler

        private void grdObjectName_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfModelObjectName();

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

        private void grdObjectName_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfModelObjectName();
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

                updateGridOfObjectName();
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

                initPropOfModelObjectName();
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

                deleteGridOfObjectName();
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

        #region rstNameToolbar Control Event Handler

        private void rstNameToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfObjectName(grdObjectName.activeDataRowKey);
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

        private void rstNameToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdObjectName.searchGridRow(e.searchWord))
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
