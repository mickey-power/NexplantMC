/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FModel.cs
--  Creator         : kitae
--  Create Date     : 2012.03.26
--  Description     : FAMate Admin Manager Setup Model Form Class 
--  History         : Created by kitae at 2012.03.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FModel : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FModel(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FModel(
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

        private string activeType
        {
            get
            {
                try
                {
                    return grdModel.activeDataRow == null ? string.Empty : grdModel.activeDataRow["Type"].ToString();
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string activeVersion
        {
            get
            {
                string version = string.Empty;

                try
                {
                    if (tabMain.ActiveTab == tabMain.Tabs[0])
                    {
                        version = grdModel.activeDataRow == null ? string.Empty : grdModel.activeDataRow["Release Ver."].ToString();
                    }
                    else
                    {
                        version = grdVersion.activeDataRowKey;
                    }
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return version;
            }
        }

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
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "Model")
                {
                    btnDelete.Enabled = grdModel.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnDownload.Enabled = false;
                    // --
                    btnNewVersion.Enabled = false;
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdModel.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "Model Version")
                {
                    btnDelete.Enabled = grdVersion.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnDownload.Enabled = grdVersion.activeDataRowKey != string.Empty && m_tranEnabled;
                    // --
                    btnNewVersion.Enabled = grdModel.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = grdVersion.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdVersion.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "Model Manual")
                {
                    btnDelete.Enabled = grdManual.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnDownload.Enabled = grdManual.activeDataRowKey != string.Empty && m_tranEnabled;
                    // --
                    btnNewVersion.Enabled = false;
                    btnUpdate.Enabled = grdModel.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdManual.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void initPropOfModel(
            )
        {
            try
            {
                pgdModel.selectedObject = new FPropModel(m_fAdmCore, pgdModel, m_tranEnabled);
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

        private void initPropOfVersion(
            )
        {
            string modelType = FEapType.SECS.ToString();

            try
            {
                if (grdModel.activeDataRow != null)
                {
                    modelType = grdModel.activeDataRow["Type"].ToString();
                }

                // --

                pgdVersion.selectedObject = new FPropModelVersion(m_fAdmCore, pgdVersion, grdModel.activeDataRowKey, modelType, m_tranEnabled);
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

        private void initPropOfManual(
            )
        {
            try
            {
                pgdManual.selectedObject = new FPropModelManual(m_fAdmCore, pgdManual, grdModel.activeDataRowKey, m_tranEnabled);
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

        private void setPropOfModel(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            
            try
            {
                if (grdModel.activeDataRow == null)
                {
                    return;
                }
               
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", grdModel.activeDataRowKey);

                // --
                
                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Model", "SearchModel", fSqlParams, true);

                // --

                pgdModel.selectedObject = new FPropModel(m_fAdmCore, pgdModel, dt, m_tranEnabled);                
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

        private void setPropOfVersion(
            )
        {
            string modelType = FEapType.SECS.ToString();
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdVersion.activeDataRow == null)
                {
                    return;
                }

                // --

                if (grdModel.activeDataRow != null)
                {
                    modelType = grdModel.activeDataRow["Type"].ToString();
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", grdModel.activeDataRowKey);
                fSqlParams.add("mdl_ver", grdVersion.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelVer", "SearchModelVer", fSqlParams, true);

                // --

                pgdVersion.selectedObject = new FPropModelVersion(m_fAdmCore, pgdVersion, dt, modelType, m_tranEnabled);
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

        private void setPropOfManual(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdManual.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", grdModel.activeDataRowKey);
                fSqlParams.add("mnu_type", grdManual.activeDataRow["Manual Type"].ToString());
                fSqlParams.add("mnu_name", grdManual.activeDataRow["Manual Name"].ToString());

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelManual", "SearchModelManual", fSqlParams, true);

                // --

                pgdManual.selectedObject = new FPropModelManual(m_fAdmCore, pgdManual, dt, m_tranEnabled);
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

        private void designGridOfModel(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdModel.dataSource;
                // --
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Maker");
                uds.Band.Columns.Add("Release Ver.");
                uds.Band.Columns.Add("Last Ver.");
                
                // --

                grdModel.DisplayLayout.Bands[0].Columns["Release Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdModel.DisplayLayout.Bands[0].Columns["Last Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdModel.DisplayLayout.Bands[0].Columns["Model"].Header.Fixed = true;
                // --
                grdModel.DisplayLayout.Bands[0].Columns["Model"].Width = 140;
                grdModel.DisplayLayout.Bands[0].Columns["Description"].Width = 241;
                grdModel.DisplayLayout.Bands[0].Columns["Type"].Width = 77;
                grdModel.DisplayLayout.Bands[0].Columns["Maker"].Width = 84;
                grdModel.DisplayLayout.Bands[0].Columns["Release Ver."].Width = 77;
                grdModel.DisplayLayout.Bands[0].Columns["Last Ver."].Width = 77;

                // --

                grdModel.ImageList = new ImageList();
                // --
                grdModel.ImageList.Images.Add("Model", Properties.Resources.Model);
                grdModel.ImageList.Images.Add("Model_Secs", Properties.Resources.Model_Secs);
                grdModel.ImageList.Images.Add("Model_Plc", Properties.Resources.Model_Plc);
                grdModel.ImageList.Images.Add("Model_Opc", Properties.Resources.Model_Opc);
                grdModel.ImageList.Images.Add("Model_Tcp", Properties.Resources.Model_Tcp);
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

        private void designGridOfVersion(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdVersion.dataSource;
                // --
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Version");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("File");
                uds.Band.Columns.Add("Update Time");
                
                // --

                grdVersion.DisplayLayout.Bands[0].Columns["Model"].Header.Fixed = true;
                grdVersion.DisplayLayout.Bands[0].Columns["Version"].Header.Fixed = true;
                                
                // --

                grdVersion.DisplayLayout.Bands[0].Columns["Model"].Width = 140;
                grdVersion.DisplayLayout.Bands[0].Columns["Version"].Width = 77;
                grdVersion.DisplayLayout.Bands[0].Columns["Description"].Width = 137;
                grdVersion.DisplayLayout.Bands[0].Columns["File"].Width = 200;
                grdVersion.DisplayLayout.Bands[0].Columns["Update Time"].Width = 150;

                // --

                grdVersion.ImageList = new ImageList();
                // --
                grdVersion.ImageList.Images.Add("ModelVersion", Properties.Resources.ModelVersion);
                grdVersion.ImageList.Images.Add("ModelVersion_Secs", Properties.Resources.ModelVersion_Secs);
                grdVersion.ImageList.Images.Add("ModelVersion_Plc", Properties.Resources.ModelVersion_Plc);
                grdVersion.ImageList.Images.Add("ModelVersion_Opc", Properties.Resources.ModelVersion_Opc);
                grdVersion.ImageList.Images.Add("ModelVersion_Tcp", Properties.Resources.ModelVersion_Tcp);
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

        private void designGridOfManual(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdManual.dataSource;
                // --
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Manual Name");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Manual Type");
                uds.Band.Columns.Add("File");
                uds.Band.Columns.Add("Update Time");

                // --

                grdManual.DisplayLayout.Bands[0].Columns["Model"].CellAppearance.Image = Properties.Resources.ModelManual;
                // --
                grdManual.DisplayLayout.Bands[0].Columns["Model"].Header.Fixed = true;
                grdManual.DisplayLayout.Bands[0].Columns["Manual Name"].Header.Fixed = true;
                // --
                grdManual.DisplayLayout.Bands[0].Columns["Model"].Width = 140;
                grdManual.DisplayLayout.Bands[0].Columns["Manual Name"].Width = 140;
                grdManual.DisplayLayout.Bands[0].Columns["Description"].Width = 69;
                grdManual.DisplayLayout.Bands[0].Columns["Manual Type"].Width = 77;
                grdManual.DisplayLayout.Bands[0].Columns["File"].Width = 200;
                grdManual.DisplayLayout.Bands[0].Columns["Update Time"].Width = 150;
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

        private void refreshGridOfModel(
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
                grdModel.removeAllDataRow();
                grdVersion.removeAllDataRow();
                grdManual.removeAllDataRow();
                grdModel.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdVersion.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdManual.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfModel();
                initPropOfVersion();
                initPropOfManual();
                // --
                refreshVersionTotal();
                refreshManualTotal();

                // --

                grdModel.beginUpdate(false);
                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);   
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Model", "ListModel", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Model
                            r[1].ToString(),   // Description   
                            r[2].ToString(),   // Type
                            r[3].ToString(),   // Maker
                            r[4].ToString(),   // Release Version
                            r[5].ToString()    // Last Version                        
                            };
                        key = (string)cellValues[0];
                        index = grdModel.appendDataRow(key, cellValues).Index;
                        // --
                        grdModel.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfModel(grdModel, r[2].ToString());
                    }
                } while (nextRowNumber >= 0);
                
                // --

                grdModel.endUpdate(false);

                // --

                if (grdModel.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdModel.activateDataRow(beforeKey);
                    }
                    if (grdModel.activeDataRow == null)
                    {
                        grdModel.ActiveRow = grdModel.Rows[0];
                    }
                }

                // --

                refreshModelTotal();

                // -- 

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Model")
                {
                    grdModel.Focus();
                }
            }
            catch (Exception ex)
            {
                grdModel.endUpdate();
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

        private void refreshGridOfVersion(
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
                grdVersion.removeAllDataRow();
                grdVersion.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfVersion();

                // --

                if (grdModel.activeDataRow == null)
                {
                    return;
                }

                // --

                grdVersion.beginUpdate(false);

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", grdModel.activeDataRowKey);
                // --                
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelVer", "ListModelVer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            grdModel.activeDataRowKey,                                                         // Model
                            r[0].ToString() + (r[3].ToString() == FYesNo.Yes.ToString() ? "*" : string.Empty), // Version
                            r[1].ToString(),                                                                   // Description
                            r[2].ToString(),
                            FDataConvert.defaultDataTimeFormating(r[4].ToString())                             // Update Time
                            };
                        key = r[0].ToString();
                        index = grdVersion.appendDataRow(key, cellValues).Index;
                        // --
                        grdVersion.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfModelVersion(grdVersion, grdModel.activeDataRow["Type"].ToString());
                    }
                } while (nextRowNumber >= 0);

                // --

                grdVersion.endUpdate(false);

                // --

                if (grdVersion.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdVersion.activateDataRow(beforeKey);
                    }
                    if (grdVersion.activeDataRow == null)
                    {
                        grdVersion.ActiveRow = grdVersion.Rows[0];
                    }
                }

                // --

                refreshVersionTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Model Version")
                {
                    grdVersion.Focus();
                }
            }
            catch (Exception ex)
            {
                grdVersion.endUpdate();
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

        private void refreshGridOfManual(
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
                grdManual.removeAllDataRow();
                grdManual.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfManual();
                
                // --

                if (grdModel.activeDataRow == null)
                {
                    return;
                }

                // --

                grdManual.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("model", grdModel.activeDataRowKey);
                // --                
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelManual", "ListModelManual", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            grdModel.activeDataRowKey,                             // Model
                            r[0].ToString(),                                       // Manual
                            r[1].ToString(),                                       // Description
                            r[2].ToString(),                                       // Manual Type
                            r[3].ToString(),                                       // Manual File
                            FDataConvert.defaultDataTimeFormating(r[4].ToString()) // Update Time
                            };
                        key = generateGridUniqueKey(new string[] {r[2].ToString(), r[0].ToString()});
                        grdManual.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdManual.endUpdate();

                // --

                if (grdManual.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdManual.activateDataRow(beforeKey);
                    }
                    if (grdManual.activeDataRow == null)
                    {
                        grdManual.ActiveRow = grdManual.Rows[0];
                    }
                }

                // --

                refreshManualTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Model Manual")
                {
                    grdManual.Focus();
                }
            }
            catch (Exception ex)
            {
                grdManual.endUpdate();
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

        private void updateGridOfModel(
            )
        {
            FPropModel fPropMdl = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMdl = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutMdl = null;
            string key = string.Empty;
            object[] cellValues = null;
            string releaseVer = string.Empty;
            string lastVer = string.Empty;
            int index=0;

            try
            {
                fPropMdl = (FPropModel)pgdModel.selectedObject;

                // --

                #region Validation

                // ***
                // 2013.02.25 by spike.lee
                // 여기서 ActiveRowKey로 Validation하면 처음 등록할 때 무조건 오류가 발생하지 않습니까?
                // ***
                FCommon.validateName(fPropMdl.Model, true, this.fUIWizard, "Model");

                if (fPropMdl.Model.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Model" }));
                }

                // --

                if (fPropMdl.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelUpdate_In.E_ADMADS_SetModelUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hLanguage, FADMADS_SetModelUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hFactory, FADMADS_SetModelUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hUserId, FADMADS_SetModelUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hHostIp, FADMADS_SetModelUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hHostName, FADMADS_SetModelUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hStep, FADMADS_SetModelUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInMdl = fXmlNodeIn.set_elem(FADMADS_SetModelUpdate_In.FModel.E_Model);
                fXmlNodeInMdl.set_elemVal(FADMADS_SetModelUpdate_In.FModel.A_Model, FADMADS_SetModelUpdate_In.FModel.D_Model, fPropMdl.Model);
                fXmlNodeInMdl.set_elemVal(FADMADS_SetModelUpdate_In.FModel.A_Description, FADMADS_SetModelUpdate_In.FModel.D_Description, fPropMdl.Description);
                fXmlNodeInMdl.set_elemVal(FADMADS_SetModelUpdate_In.FModel.A_Type, FADMADS_SetModelUpdate_In.FModel.D_Type, fPropMdl.Type.ToString());
                fXmlNodeInMdl.set_elemVal(FADMADS_SetModelUpdate_In.FModel.A_Maker, FADMADS_SetModelUpdate_In.FModel.D_Maker, fPropMdl.Maker);

                // --

                FADMADSCaster.ADMADS_SetModelUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelUpdate_Out.A_hStatus, FADMADS_SetModelUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetModelUpdate_Out.A_hStatusMessage, FADMADS_SetModelUpdate_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutMdl = fXmlNodeOut.get_elem(FADMADS_SetModelUpdate_Out.FModel.E_Model);
                releaseVer = fXmlNodeOutMdl.get_elemVal(FADMADS_SetModelUpdate_Out.FModel.A_ReleaseVer, FADMADS_SetModelUpdate_Out.FModel.D_ReleaseVer);
                lastVer = fXmlNodeOutMdl.get_elemVal(FADMADS_SetModelUpdate_Out.FModel.A_LastVer, FADMADS_SetModelUpdate_Out.FModel.D_LastVer);

                // --

                cellValues = new object[]
                {
                    fPropMdl.Model,
                    fPropMdl.Description,
                    fPropMdl.Type.ToString(),
                    fPropMdl.Maker,      
                    releaseVer,
                    lastVer
                };
                // --
                key = fPropMdl.Model;
                index=grdModel.appendOrUpdateDataRow(key, cellValues).Index;
                // --
                grdModel.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfModel(grdModel, fPropMdl.Type.ToString());

                // --

                grdModel.activateDataRow(key);

                // --

                refreshModelTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInMdl = null;
                fXmlNodeOut = null;
                fXmlNodeOutMdl = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfModel(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMdl = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Model" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdModel.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelUpdate_In.E_ADMADS_SetModelUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hLanguage, FADMADS_SetModelUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hFactory, FADMADS_SetModelUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hUserId, FADMADS_SetModelUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hHostIp, FADMADS_SetModelUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hHostName, FADMADS_SetModelUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelUpdate_In.A_hStep, FADMADS_SetModelUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInMdl = fXmlNodeIn.set_elem(FADMADS_SetModelUpdate_In.FModel.E_Model);

                // --

                foreach (UltraDataRow dr in grdModel.selectedDataRows)
                {
                    fXmlNodeInMdl.set_elemVal(FADMADS_SetModelUpdate_In.FModel.A_Model, FADMADS_SetModelUpdate_In.FModel.D_Model, dr["Model"].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetModelUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelUpdate_Out.A_hStatus, FADMADS_SetModelUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetModelUpdate_Out.A_hStatusMessage, FADMADS_SetModelUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdModel.removeDataRow(dr.Index);
                }

                // --

                grdModel.endUpdate();

                // --

                if (grdModel.Rows.Count == 0)
                {
                    initPropOfModel();
                    initPropOfVersion();
                    // ***
                    // Model 삭제 시 Manual을 같이 삭제됨으로, 
                    // Manual Grid / Property를 Clear 하기 위해 Refresh를 수행한다.
                    // ***
                    refreshGridOfManual(string.Empty);
                }

                // --

                refreshModelTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdModel.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInMdl = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode updateVersion(
            string hStep,
            string version,
            FPropModelVersion fPropVer,
            string path
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInVer = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelVerUpdate_In.E_ADMADS_SetModelVerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hLanguage, FADMADS_SetModelVerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hFactory, FADMADS_SetModelVerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hUserId, FADMADS_SetModelVerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hHostIp, FADMADS_SetModelVerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hHostName, FADMADS_SetModelVerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hStep, FADMADS_SetModelVerUpdate_In.D_hStep, hStep);

                // --

                fXmlNodeInVer = fXmlNodeIn.set_elem(FADMADS_SetModelVerUpdate_In.FVersion.E_Version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerUpdate_In.FVersion.A_Model, FADMADS_SetModelVerUpdate_In.FVersion.D_Model, fPropVer.Model);
                fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerUpdate_In.FVersion.A_Version, FADMADS_SetModelVerUpdate_In.FVersion.D_Version, version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerUpdate_In.FVersion.A_Description, FADMADS_SetModelVerUpdate_In.FVersion.D_Description, fPropVer.Description);
                fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerUpdate_In.FVersion.A_Comment, FADMADS_SetModelVerUpdate_In.FVersion.D_Comment, fPropVer.Comments);
                fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerUpdate_In.FVersion.A_Release, FADMADS_SetModelVerUpdate_In.FVersion.D_Release, fPropVer.Release.ToString());
                fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerUpdate_In.FVersion.A_Path, FADMADS_SetModelVerUpdate_In.FVersion.D_Path, Path.GetFileName(path));

                // --

                FADMADSCaster.ADMADS_SetModelVerUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelVerUpdate_Out.A_hStatus, FADMADS_SetModelVerUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetModelVerUpdate_Out.A_hStatusMessage, FADMADS_SetModelVerUpdate_Out.D_hStatusMessage)
                        );
                }

                // --

                return fXmlNodeOut;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInVer = null;
                fXmlNodeOut = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void insertGridOfVersion(
            )
        {
            FPropModelVersion fPropVer = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutVer = null;
            object[] cellValues = null;
            string key = string.Empty;
            FFtp fFtp = null;
            string tempFilePath = string.Empty;
            string fileName = string.Empty;
            string zipFileName = string.Empty;
            string version = string.Empty;
            string releaseVer = string.Empty;
            int index = 0;

            try
            {
                fPropVer = (FPropModelVersion)pgdVersion.selectedObject;

                // --

                #region Validation

                if (fPropVer.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                if (fPropVer.Comments.Length > 400)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Comments" }));
                }

                if (fPropVer.newFile == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0041", new object[] { "New Model Version File" }));
                }

                #endregion

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0009", new object[] { "New Model Version" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                // ***
                // Temp Directory Create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                // ***
                // Model Version File Copy to Temp Directory
                // ***
                fileName = tempFilePath + "\\" + grdModel.activeDataRowKey + Path.GetExtension(fPropVer.File);
                File.Copy(fPropVer.File, fileName);

                // --

                // ***
                // Model Version File Pack & FTP Upload
                // ***
                zipFileName = tempFilePath + string.Format(FConstants.TempFileFormat, Guid.NewGuid().ToString(), FConstants.ZipFileExtension);
                F7Zip.pack(zipFileName, fileName);
                // --                
                fFtp = FCommon.createFtp(m_fAdmCore);
                fFtp.uploadFiles(zipFileName);
                
                // --

                FCommon.deleteDirectory(tempFilePath);

                // --

                fXmlNodeOut = updateVersion("3", "0", fPropVer, zipFileName);
                // --
                fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetModelVerUpdate_Out.FVersion.E_Version);
                version = fXmlNodeOutVer.get_elemVal(FADMADS_SetModelVerUpdate_Out.FVersion.A_Version, FADMADS_SetModelVerUpdate_Out.FVersion.D_Version);
                releaseVer = fXmlNodeOutVer.get_elemVal(FADMADS_SetModelVerUpdate_Out.FVersion.A_Release, FADMADS_SetModelVerUpdate_Out.FVersion.D_Release);
                zipFileName = fXmlNodeOutVer.get_elemVal(FADMADS_SetModelVerUpdate_Out.FVersion.A_Path, FADMADS_SetModelVerUpdate_Out.FVersion.D_Path);

                // --

                grdModel.ActiveRow.Cells["Release Ver."].Value = releaseVer;
                grdModel.ActiveRow.Cells["Last Ver."].Value = version;
                // --
                cellValues = new object[] {
                    grdModel.activeDataRowKey, // Model
                    version,                   // Model Version
                    fPropVer.Description,      // Model Version Description
                    zipFileName                // Model File
                    };
                // --
                key = version;
                index=grdVersion.insertBeforeDataRow(0, key, cellValues).Index;
                // --
                grdVersion.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfModelVersion(grdVersion, grdModel.activeDataRow["Type"].ToString());

                // --

                setReleasedVersion(releaseVer);

                // --

                grdVersion.activateDataRow(key);

                // --

                refreshVersionTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFtp != null)
                {
                    fFtp.Dispose();
                    fFtp = null;
                }

                // --

                fPropVer = null;
                fXmlNodeOut = null;
                fXmlNodeOutVer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfVersion(
            )
        {
            FPropModelVersion fPropVer = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutVer = null;
            string releaseVer = string.Empty;
            string modelVer = string.Empty;

            try
            {
                fPropVer = (FPropModelVersion)pgdVersion.selectedObject;

                // --

                #region Validation

                if (fPropVer.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                if (fPropVer.Comments.Length > 400)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Comments" }));
                }

                if (fPropVer.File != fPropVer.oldPath)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0022", new object[] { "Model Version File" }));
                }

                #endregion

                // --

                modelVer = grdVersion.activeDataRowKey;
                modelVer = modelVer.Contains("*") ? modelVer.Substring(0, modelVer.IndexOf("*", 0)) : modelVer;

                // --

                fXmlNodeOut = updateVersion("1", modelVer, fPropVer, string.Empty);
                // --
                fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetModelVerUpdate_Out.FVersion.E_Version);
                releaseVer = fXmlNodeOutVer.get_elemVal(FADMADS_SetModelVerUpdate_Out.FVersion.A_Release, FADMADS_SetModelVerUpdate_Out.FVersion.D_Release);

                // --

                grdModel.ActiveRow.Cells["Release Ver."].Value = releaseVer;
                grdVersion.ActiveRow.Cells["Description"].Value = fPropVer.Description;

                // --

                setReleasedVersion(releaseVer);

                // --

                refreshVersionTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropVer = null;
                fXmlNodeOut = null;
                fXmlNodeOutVer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfVersion(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInVer = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutVer = null;
            string releaseVer = string.Empty;

            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Version" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdVersion.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelVerUpdate_In.E_ADMADS_SetModelVerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hLanguage, FADMADS_SetModelVerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hFactory, FADMADS_SetModelVerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hUserId, FADMADS_SetModelVerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hHostIp, FADMADS_SetModelVerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hHostName, FADMADS_SetModelVerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerUpdate_In.A_hStep, FADMADS_SetModelVerUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInVer = fXmlNodeIn.set_elem(FADMADS_SetModelVerUpdate_In.FVersion.E_Version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerUpdate_In.FVersion.A_Model, FADMADS_SetModelVerUpdate_In.FVersion.D_Model, grdModel.activeDataRowKey);

                // --

                foreach (UltraDataRow dr in grdVersion.selectedDataRows)
                {
                    fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerUpdate_In.FVersion.A_Version, FADMADS_SetModelVerUpdate_In.FVersion.D_Version, grdVersion.getDataRowKey(dr.Index));
                    fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerUpdate_In.FVersion.A_Path, FADMADS_SetModelVerUpdate_In.FVersion.D_Path, dr["File"].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetModelVerUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelVerUpdate_Out.A_hStatus, FADMADS_SetModelVerUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetModelVerUpdate_Out.A_hStatusMessage, FADMADS_SetModelVerUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetModelVerUpdate_Out.FVersion.E_Version);
                    releaseVer = fXmlNodeOutVer.get_elemVal(FADMADS_SetModelVerUpdate_Out.FVersion.A_Release, FADMADS_SetModelVerUpdate_Out.FVersion.D_Release);
                    // --
                    grdModel.ActiveRow.Cells["Release Ver."].Value = releaseVer;
                    grdVersion.removeDataRow(dr.Index);
                }

                // --

                grdVersion.endUpdate();

                // --

                if (grdVersion.Rows.Count == 0)
                {
                    initPropOfVersion();
                }

                // --

                refreshVersionTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdVersion.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInVer = null;
                fXmlNodeOut = null;
                fXmlNodeOutVer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setReleasedVersion(
            string version
            )
        {
            string key = string.Empty;

            try
            {
                foreach (UltraGridRow r in grdVersion.Rows)
                {
                    key = grdVersion.getDataRowKey(r.ListIndex);
                    r.Cells[1].Value = (key == version ? key + "*" : key);
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

        private void downloadVersion(
            )
        {
            FolderBrowserDialog fbd = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInVer = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutVer = null;
            FFtp fFtp = null;
            string downloadFilePath = string.Empty;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;

            try
            {
                fbd = new FolderBrowserDialog();
                fbd.SelectedPath = m_fAdmCore.fOption.recentDownloadPath;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                // ***
                // Temp Directory Create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                // ***
                // FTP Create
                // ***
                fFtp = FCommon.createFtp(m_fAdmCore);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelVerDownload_In.E_ADMADS_SetModelVerDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerDownload_In.A_hLanguage, FADMADS_SetModelVerDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerDownload_In.A_hFactory, FADMADS_SetModelVerDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerDownload_In.A_hUserId, FADMADS_SetModelVerDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelVerDownload_In.A_hStep, FADMADS_SetModelVerDownload_In.D_hStep, "1");

                // --

                fXmlNodeInVer = fXmlNodeIn.set_elem(FADMADS_SetModelVerDownload_In.FVersion.E_Version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerDownload_In.FVersion.A_Model, FADMADS_SetModelVerDownload_In.FVersion.D_Model, grdModel.activeDataRowKey);

                // --

                foreach (string s in grdVersion.selectedDataRowKeys)
                {
                    fXmlNodeInVer.set_elemVal(FADMADS_SetModelVerDownload_In.FVersion.A_Version, FADMADS_SetModelVerDownload_In.FVersion.D_Version, s);
                    // --
                    FADMADSCaster.ADMADS_SetModelVerDownload_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelVerDownload_Out.A_hStatus, FADMADS_SetModelVerDownload_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetModelVerDownload_Out.A_hStatusMessage, FADMADS_SetModelVerDownload_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetModelVerDownload_Out.FVersion.E_Version);
                    zipFileName = fXmlNodeOutVer.get_elemVal(FADMADS_SetModelVerDownload_Out.FVersion.A_Path, FADMADS_SetModelVerDownload_Out.FVersion.D_Path);

                    // --

                    fFtp.downloadFiles(tempFilePath, zipFileName);
                    fFtp.deleteFiles(zipFileName);

                    // --

                    zipFileName = tempFilePath + "\\" + zipFileName;
                    downloadFilePath = Path.Combine(fbd.SelectedPath, m_fAdmCore.fOption.factory + "_" + grdModel.activeDataRowKey + "_" + s);
                    if (Directory.Exists(downloadFilePath))
                    {
                        Directory.Delete(downloadFilePath, true);
                    }
                    Directory.CreateDirectory(downloadFilePath);
                    // --
                    F7Zip.unpack(zipFileName, downloadFilePath);
                }

                // --

                m_fAdmCore.fOption.recentDownloadPath = fbd.SelectedPath;
                FCommon.deleteDirectory(tempFilePath);

                // --

                // ***
                // Download Folder Open
                // ***
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0005"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                Process.Start("explorer.exe", "/select, " + downloadFilePath);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFtp != null)
                {
                    fFtp.Dispose();
                    fFtp = null;
                }

                // --

                fXmlNodeIn = null;
                fXmlNodeInVer = null;
                fXmlNodeOut = null;
                fXmlNodeOutVer = null;
                fbd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfManual(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMnu = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutMnu = null;
            FPropModelManual fPropMnu = null;
            FFtp fFtp = null;
            object[] cellValues = null;
            string key = string.Empty;
            string fileName = string.Empty;
            string filePath = string.Empty;
            string tempFileName = string.Empty;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;
                        
            try
            {
                fPropMnu = (FPropModelManual)pgdManual.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropMnu.ManualName, true, this.fUIWizard, "Manual Name");
                if (fPropMnu.ManualName.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Manual Name" }));
                }

                // --

                if (fPropMnu.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                FCommon.validateName(fPropMnu.ManualType, true, this.fUIWizard, "Manual Type");
                if (fPropMnu.ManualType.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Manual Type" }));
                }
                
                // --

                if (fPropMnu.File == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0041", new object[] { "Manual File" }));
                }

                // --

                // ***
                // 2017.03.29 by spike.lee
                // Active Row가 아닌 Menual 정보를 Update 할 경우 Manuel File이 등록되었는지 체크
                // ***
                key = generateGridUniqueKey(new string[] { fPropMnu.ManualType, fPropMnu.ManualName });
                if (grdManual == null || grdManual.activeDataRowKey != key)
                {
                    if (fPropMnu.FileChange == FYesNo.No)
                    {
                        FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0010", new object[] { "File" }));
                    }
                }                

                #endregion

                // --

                if (fPropMnu.FileChange == FYesNo.Yes)
                {
                    fileName = Path.GetFileName(fPropMnu.NewFile);

                    // --

                    // ***
                    // Temp Directory Create
                    // ***
                    tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                    Directory.CreateDirectory(tempFilePath);

                    // --

                    // ***
                    // Model Manual File Copy to Temp Directory
                    // ***
                    tempFileName = tempFilePath + "\\" + fileName;
                    File.Copy(fPropMnu.NewFile, tempFileName);

                    // --

                    // ***
                    // Model Manual File Pack & FTP Upload
                    // ***
                    zipFileName = tempFilePath + string.Format(FConstants.TempFileFormat, Guid.NewGuid().ToString(), FConstants.ZipFileExtension);
                    F7Zip.pack(zipFileName, tempFileName);
                    // --
                    fFtp = FCommon.createFtp(m_fAdmCore);
                    fFtp.uploadFiles(zipFileName);

                    // --

                    filePath = Path.GetFileName(zipFileName);

                    // --

                    FCommon.deleteDirectory(tempFilePath);
                }
                else
                {
                    fileName = fPropMnu.OldFile;
                    filePath = fPropMnu.File;
                }

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelManualUpdate_In.E_ADMADS_SetModelManualUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hLanguage, FADMADS_SetModelManualUpdate_In.D_hLanguage);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hFactory, FADMADS_SetModelManualUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hUserId, FADMADS_SetModelManualUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hHostIp, FADMADS_SetModelManualUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hHostName, FADMADS_SetModelManualUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hStep, FADMADS_SetModelManualUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInMnu = fXmlNodeIn.set_elem(FADMADS_SetModelManualUpdate_In.FManual.E_Manual);
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualUpdate_In.FManual.A_Model,
                    FADMADS_SetModelManualUpdate_In.FManual.D_Model,
                    fPropMnu.Model
                    );
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualUpdate_In.FManual.A_ManualType,
                    FADMADS_SetModelManualUpdate_In.FManual.D_ManualType,
                    fPropMnu.ManualType
                    );
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualUpdate_In.FManual.A_ManualName,
                    FADMADS_SetModelManualUpdate_In.FManual.D_ManualName,
                    fPropMnu.ManualName
                    );
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualUpdate_In.FManual.A_Description,
                    FADMADS_SetModelManualUpdate_In.FManual.D_Description,
                    fPropMnu.Description
                    );
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualUpdate_In.FManual.A_FileName,
                    FADMADS_SetModelManualUpdate_In.FManual.D_FileName,
                    fileName
                    );
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualUpdate_In.FManual.A_FileChange,
                    FADMADS_SetModelManualUpdate_In.FManual.D_FileChange,
                    fPropMnu.FileChange.ToString()
                    );
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualUpdate_In.FManual.A_Path,
                    FADMADS_SetModelManualUpdate_In.FManual.D_Path,
                    filePath
                    );

                // --

                FADMADSCaster.ADMADS_SetModelManualUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelManualUpdate_Out.A_hStatus, FADMADS_SetModelManualUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetModelManualUpdate_Out.A_hStatusMessage, FADMADS_SetModelManualUpdate_Out.D_hStatusMessage)
                        );
                }
                // --
                fXmlNodeOutMnu = fXmlNodeOut.get_elem(FADMADS_SetModelManualUpdate_Out.FManual.E_Manual);
                fileName = fXmlNodeOutMnu.get_elemVal(
                    FADMADS_SetModelManualUpdate_Out.FManual.A_Path,
                    FADMADS_SetModelManualUpdate_Out.FManual.D_Path
                    );
                
                // --

                cellValues = new object[] {
                    fPropMnu.Model,
                    fPropMnu.ManualName,
                    fPropMnu.Description,
                    fPropMnu.ManualType,
                    fileName
                    };
                // --
                key = generateGridUniqueKey(new string[] { fPropMnu.ManualType, fPropMnu.ManualName });
                grdManual.appendOrUpdateDataRow(key, cellValues);
                grdManual.activateDataRow(key);

                // --

                refreshManualTotal();

                // --

                // ***
                // Property Refresh를 위해 Grid로 Focus 이동.
                // ***
                grdManual.Focus();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInMnu = null;
                fXmlNodeOut = null;
                fXmlNodeOutMnu = null;
                fPropMnu = null;
                fFtp = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfManual(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMnu = null;
            FXmlNode fXmlNodeOut = null;
            
            try
            {
                
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Manual" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdManual.beginUpdate();
                
                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelManualUpdate_In.E_ADMADS_SetModelManualUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hLanguage, FADMADS_SetModelManualUpdate_In.D_hLanguage);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hFactory, FADMADS_SetModelManualUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hUserId, FADMADS_SetModelManualUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hHostIp, FADMADS_SetModelManualUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hHostName, FADMADS_SetModelManualUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualUpdate_In.A_hStep, FADMADS_SetModelManualUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInMnu = fXmlNodeIn.set_elem(FADMADS_SetModelManualUpdate_In.FManual.E_Manual);

                // --

                foreach (UltraDataRow r in grdManual.selectedDataRows)
                {
                    fXmlNodeInMnu.set_elemVal(
                        FADMADS_SetModelManualUpdate_In.FManual.A_Model,
                        FADMADS_SetModelManualUpdate_In.FManual.D_Model,
                        r["Model"].ToString()
                        );
                    fXmlNodeInMnu.set_elemVal(
                        FADMADS_SetModelManualUpdate_In.FManual.A_ManualType,
                        FADMADS_SetModelManualUpdate_In.FManual.D_ManualType,
                        r["Manual Type"].ToString()
                        );
                    fXmlNodeInMnu.set_elemVal(
                        FADMADS_SetModelManualUpdate_In.FManual.A_ManualName,
                        FADMADS_SetModelManualUpdate_In.FManual.D_ManualName,
                        r["Manual Name"].ToString()
                        );
                    fXmlNodeInMnu.set_elemVal(
                        FADMADS_SetModelManualUpdate_In.FManual.A_Path,
                        FADMADS_SetModelManualUpdate_In.FManual.D_Path,
                        r["File"].ToString()
                        );

                    // --

                    FADMADSCaster.ADMADS_SetModelManualUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelManualUpdate_Out.A_hStatus, FADMADS_SetModelManualUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelManualUpdate_Out.A_hStatusMessage, FADMADS_SetModelManualUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdManual.removeDataRow(r.Index);
                }

                // --

                grdManual.endUpdate();

                // --

                if (grdManual.Rows.Count == 0)
                {
                    initPropOfManual();
                }

                // --

                refreshManualTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdManual.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInMnu = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void downloadManual(
            )
        {
            FolderBrowserDialog fbd = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMnu = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutMnu = null;
            FFtp fFtp = null;
            string mnuType = string.Empty;
            string mnuName = string.Empty;
            string fileName = string.Empty;
            string downloadFilePath = string.Empty;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;

            try
            {
                fbd = new FolderBrowserDialog();
                fbd.SelectedPath = m_fAdmCore.fOption.recentDownloadPath;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                // ***
                // Temp Directory Create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                // ***
                // FTP Create
                // ***
                fFtp = FCommon.createFtp(m_fAdmCore);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelManualDownload_In.E_ADMADS_SetModelManualDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualDownload_In.A_hLanguage, FADMADS_SetModelManualDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualDownload_In.A_hFactory, FADMADS_SetModelManualDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualDownload_In.A_hUserId, FADMADS_SetModelManualDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelManualDownload_In.A_hStep, FADMADS_SetModelManualDownload_In.D_hStep, "1");

                // --

                fXmlNodeInMnu = fXmlNodeIn.set_elem(FADMADS_SetModelManualDownload_In.FManual.E_Manual);
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualDownload_In.FManual.A_Model,
                    FADMADS_SetModelManualDownload_In.FManual.D_Model,
                    grdModel.activeDataRowKey
                    );

                // --

                mnuType = grdManual.activeDataRow["Manual Type"].ToString();
                mnuName = grdManual.activeDataRow["Manual Name"].ToString();

                // --

                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualDownload_In.FManual.A_ManualType,
                    FADMADS_SetModelManualDownload_In.FManual.D_ManualType,
                    mnuType
                    );
                fXmlNodeInMnu.set_elemVal(
                    FADMADS_SetModelManualDownload_In.FManual.A_ManualName,
                    FADMADS_SetModelManualDownload_In.FManual.D_ManualName,
                    mnuName
                    );
                // --
                FADMADSCaster.ADMADS_SetModelManualDownload_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelManualDownload_Out.A_hStatus, FADMADS_SetModelManualDownload_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetModelManualDownload_Out.A_hStatusMessage, FADMADS_SetModelManualDownload_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutMnu = fXmlNodeOut.get_elem(FADMADS_SetModelManualDownload_Out.FManual.E_Manual);
                fileName = fXmlNodeOutMnu.get_elemVal(FADMADS_SetModelManualDownload_Out.FManual.A_Filename, FADMADS_SetModelManualDownload_Out.FManual.D_Filename);
                zipFileName = fXmlNodeOutMnu.get_elemVal(FADMADS_SetModelManualDownload_Out.FManual.A_Path, FADMADS_SetModelManualDownload_Out.FManual.D_Path);

                // --

                fFtp.downloadFiles(tempFilePath, zipFileName);
                fFtp.deleteFiles(zipFileName);

                // --

                zipFileName = Path.Combine(tempFilePath, zipFileName);
                downloadFilePath = Path.Combine(fbd.SelectedPath, string.Join("_", m_fAdmCore.fOption.factory, grdModel.activeDataRowKey, mnuType, mnuName));
                if (Directory.Exists(downloadFilePath))
                {
                    Directory.Delete(downloadFilePath, true);
                }
                Directory.CreateDirectory(downloadFilePath);
                // --
                F7Zip.unpack(zipFileName, downloadFilePath);

                // --

                m_fAdmCore.fOption.recentDownloadPath = fbd.SelectedPath;
                FCommon.deleteDirectory(tempFilePath);

                // --

                // ***
                // Download Manual Open
                // ***
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0016"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                Process.Start(Path.Combine(downloadFilePath, fileName));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fFtp != null)
                {
                    fFtp.Dispose();
                    fFtp = null;
                }

                // --

                fXmlNodeIn = null;
                fXmlNodeInMnu = null;
                fXmlNodeOut = null;
                fXmlNodeOutMnu = null;
                fbd = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private string generateGridUniqueKey(
            string[] dat
            )
        {
            const char UnitSeparator = (char)0x1F;
            // --
            StringBuilder key = null;

            try
            {
                key = new StringBuilder();

                foreach (string s in dat)
                {
                    key.Append(s);
                    key.Append(UnitSeparator);
                }

                // --

                return key.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                key = null;
            }
            return string.Empty;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void refreshModelTotal(
            )
        {
            try
            {
                lblMdlTotal.Text = grdModel.Rows.Count.ToString("#,##0");
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

        private void refreshVersionTotal(
            )
        {
            try
            {
                lblVerTotal.Text = grdVersion.Rows.Count.ToString("#,##0");
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

        private void refreshManualTotal(
            )
        {
            try
            {
                lblMnuTotal.Text = grdManual.Rows.Count.ToString("#,##0");
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

        #region Popup Menu

        private void procMenuModelStatus(
            )
        {
            FModelStatus fModelStatus = null;

            try
            {
                fModelStatus = (FModelStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FModelStatus));
                if (fModelStatus == null)
                {
                    fModelStatus = new FModelStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fModelStatus);
                }
                fModelStatus.activate();
                fModelStatus.attach(grdModel.activeDataRowKey, this.activeType, this.activeVersion);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fModelStatus = null;
            }
        }

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FModel Form Event Handler

        private void FModel_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Model);

                // --

                designGridOfModel();
                designGridOfVersion();
                designGridOfManual();

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

        private void FModel_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfModel(string.Empty);

                // --

                grdModel.Focus();
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

        private void FModel_FormClosing(
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

        private void FModel_KeyDown(
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
                    if (tabMain.ActiveTab.Key == "Model")
                    {
                        refreshGridOfModel(grdModel.activeDataRowKey);
                    }
                    else if (tabMain.ActiveTab.Key == "Model Version")
                    {
                        refreshGridOfVersion(grdVersion.activeDataRowKey);
                    }                    
                    else
                    {
                        refreshGridOfManual(grdManual.activeDataRowKey);
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

                if (e.Tool.Key == FMenuKey.MenuSetModelStatus)
                {
                    procMenuModelStatus();
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
            string key = string.Empty;

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

        #region grdModel Control Event Handler

        private void grdModel_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfModel();

                // --

                refreshGridOfVersion(string.Empty);
                refreshGridOfManual(string.Empty);
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

        private void grdModel_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.Tabs["Model Version"].Selected = true;
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

        private void grdModel_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfModel();
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

        private void grdModel_MouseDown(
            object sender,
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdModel.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdModel.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                     grdModel.ActiveRow = grdModel.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuSetModelStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ModelStatus);

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuSetMdlPopupMenu);
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

        #region grdVersion Control Event Handler

        private void grdVersion_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfVersion();

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

        private void grdVersion_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfVersion();
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

        private void grdVersion_MouseDown(
            object sender,
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdVersion.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdVersion.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdVersion.ActiveRow = grdVersion.Rows[r.Index];
                }
                
                // --
                
                mnuMenu.Tools[FMenuKey.MenuSetModelStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ModelStatus);

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuSetMdlPopupMenu);
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

        #region grdManual Control Event Handler

        private void grdManual_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfManual();

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

        private void grdManual_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfManual();
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

        #region btnNewVersion Control Event Handler

        private void btnNewVersion_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                 insertGridOfVersion();
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

                if (key == "Model")
                {
                    updateGridOfModel();
                }
                else if (key == "Model Version")
                {
                    updateGridOfVersion();
                }
                else if (key == "Model Manual")
                {
                    updateGridOfManual();
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

                if (key == "Model")
                {
                    initPropOfModel();
                }
                else if (key == "Model Version")
                {
                    initPropOfVersion();
                }
                else if (key == "Model Manual")
                {
                    initPropOfManual();
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

                if (key == "Model")
                {
                    deleteGridOfModel();
                }
                else if (key == "Model Version")
                {
                    deleteGridOfVersion();
                }
                else if (key == "Model Manual")
                {
                    deleteGridOfManual();
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

        #region btnDownload Control Event Handler

        private void btnDownload_Click(
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

                if (key == "Model Version")
                {
                    downloadVersion();
                }
                else if (key == "Model Manual")
                {
                    downloadManual();
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

        #region rstModel Control Event Handler

        private void rstModel_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfModel(grdModel.activeDataRowKey);
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

        private void rstModel_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdModel.searchGridRow(e.searchWord))
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

        #region rstVersion Control Event Handler

        private void rstVersion_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfVersion(grdVersion.activeDataRowKey);
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

        private void rstVersion_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdVersion.searchGridRow(e.searchWord))
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

        #region rstManual Control Event Handler

        private void rstManual_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfManual(grdVersion.activeDataRowKey);
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

        private void rstManual_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdManual.searchGridRow(e.searchWord))
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
