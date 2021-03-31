/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FComponent.cs
--  Creator         : kitae
--  Create Date     : 2012.03.23
--  Description     : FAMate Admin Manager Setup Component Form Class 
--  History         : Created by kitae at 2012.03.23
                    : Updated by baehyun seo at 2013.03.07
                        - Component : Popup Menu
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FComponent : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FComponent(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FComponent(
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
                    return grdComponent.activeDataRow == null ? string.Empty : grdComponent.activeDataRow["Type"].ToString();
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
                        version = grdComponent.activeDataRow == null ? string.Empty : grdComponent.activeDataRow["Release Ver."].ToString();
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

                if (key == "Component")
                {
                    btnDelete.Enabled = grdComponent.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnDownload.Enabled = false;
                    // --
                    btnNewVersion.Enabled = false;
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdComponent.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "Component Version")
                {
                    btnDelete.Enabled = grdVersion.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnDownload.Enabled = (grdVersion.activeDataRowKey != string.Empty ? true : false) && m_tranEnabled;
                    // --
                    btnNewVersion.Enabled = grdComponent.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnUpdate.Enabled = grdVersion.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdVersion.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void initPropOfComponent(
            )
        {
            try
            {
                pgdComponent.selectedObject = new FPropComponent(m_fAdmCore, pgdComponent, m_tranEnabled);
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
            try
            {
                pgdVersion.selectedObject = new FPropComponentVersion(m_fAdmCore, pgdVersion, grdComponent.activeDataRowKey, m_tranEnabled);
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

        private void setPropOfComponent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdComponent.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("component", grdComponent.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Component", "SearchComponent", fSqlParams, true);

                // --

                pgdComponent.selectedObject = new FPropComponent(m_fAdmCore, pgdComponent, dt, m_tranEnabled);                
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
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdVersion.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("component", grdComponent.activeDataRowKey);
                fSqlParams.add("com_ver", grdVersion.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ComponentVer", "SearchComponentVer", fSqlParams, true);

                // --

                pgdVersion.selectedObject = new FPropComponentVersion(m_fAdmCore, pgdVersion, dt, m_tranEnabled);
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

        private void designGridOfComponent(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdComponent.dataSource;
                // --
                uds.Band.Columns.Add("Component");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Release Ver.");
                uds.Band.Columns.Add("Last Ver.");

                // --

                grdComponent.DisplayLayout.Bands[0].Columns["Component"].CellAppearance.Image = Properties.Resources.Component;
                // --
                grdComponent.DisplayLayout.Bands[0].Columns["Release Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdComponent.DisplayLayout.Bands[0].Columns["Last Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdComponent.DisplayLayout.Bands[0].Columns["Component"].Header.Fixed = true;
                // --
                grdComponent.DisplayLayout.Bands[0].Columns["Component"].Width = 140;                
                grdComponent.DisplayLayout.Bands[0].Columns["Description"].Width = 341;
                grdComponent.DisplayLayout.Bands[0].Columns["Type"].Width = 77;
                grdComponent.DisplayLayout.Bands[0].Columns["Release Ver."].Width = 77;
                grdComponent.DisplayLayout.Bands[0].Columns["Last Ver."].Width = 77;

                // --

                grdComponent.ImageList = new ImageList();
                // --
                grdComponent.ImageList.Images.Add("Component", Properties.Resources.Component);
                grdComponent.ImageList.Images.Add("Component_Secs", Properties.Resources.Component_Secs);
                grdComponent.ImageList.Images.Add("Component_Plc", Properties.Resources.Component_Plc);
                grdComponent.ImageList.Images.Add("Component_Opc", Properties.Resources.Component_Opc);
                grdComponent.ImageList.Images.Add("Component_Tcp", Properties.Resources.Component_Tcp);
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

        private void designGridOfVersion(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdVersion.dataSource;
                // --
                uds.Band.Columns.Add("Component");
                uds.Band.Columns.Add("Version");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("File");
                uds.Band.Columns.Add("Update Time");
                
                // --

                grdVersion.DisplayLayout.Bands[0].Columns["Component"].CellAppearance.Image = Properties.Resources.ComponentVersion;
                // --
                grdVersion.DisplayLayout.Bands[0].Columns["Component"].Header.Fixed = true;
                grdVersion.DisplayLayout.Bands[0].Columns["Version"].Header.Fixed = true;
                // --
                grdVersion.DisplayLayout.Bands[0].Columns["Component"].Width = 140;
                grdVersion.DisplayLayout.Bands[0].Columns["Version"].Width = 77;
                grdVersion.DisplayLayout.Bands[0].Columns["Description"].Width = 120;
                grdVersion.DisplayLayout.Bands[0].Columns["File"].Width = 200;
                grdVersion.DisplayLayout.Bands[0].Columns["Update Time"].Width = 150;
                
                // --

                grdVersion.ImageList = new ImageList();
                // --
                grdVersion.ImageList.Images.Add("ComponentVersion", Properties.Resources.ComponentVersion);
                grdVersion.ImageList.Images.Add("ComponentVersion_Secs", Properties.Resources.ComponentVersion_Secs);
                grdVersion.ImageList.Images.Add("ComponentVersion_Plc", Properties.Resources.ComponentVersion_Plc);
                grdVersion.ImageList.Images.Add("ComponentVersion_Opc", Properties.Resources.ComponentVersion_Opc);
                grdVersion.ImageList.Images.Add("ComponentVersion_Tcp", Properties.Resources.ComponentVersion_Tcp);
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

        private void refreshGridOfComponent(
            string beforeKey
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = -1;

            try
            {
                grdComponent.removeAllDataRow();
                grdVersion.removeAllDataRow();
                grdComponent.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdVersion.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfComponent();
                initPropOfVersion();
                // --
                refreshVersionTotal();

                // --
                
                grdComponent.beginUpdate(false);
                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Component", "ListComponent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Component
                            r[1].ToString(),   // Description
                            r[2].ToString(),   // Type
                            r[3].ToString(),   // Release Version
                            r[4].ToString()    // Last Version                            
                            };
                        key = (string)cellValues[0];
                        index = grdComponent.appendDataRow(key, cellValues).Index;
                        // --
                        grdComponent.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfComponent(grdComponent, r[2].ToString());
                    }
                } while (nextRowNumber >= 0);
                
                // --

                grdComponent.endUpdate(false);
                
                // --

                if (grdComponent.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdComponent.activateDataRow(beforeKey);
                    }
                    if (grdComponent.activeDataRow == null)
                    {
                        grdComponent.ActiveRow = grdComponent.Rows[0];
                    }
                }

                // --

                refreshComponentTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Component")
                {
                    grdComponent.Focus();
                }
            }
            catch (Exception ex)
            {
                grdComponent.endUpdate(false);
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

                if (grdComponent.activeDataRow == null)
                {
                    return;
                }

                // --

                grdVersion.beginUpdate(false);

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("component", grdComponent.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ComponentVer", "ListComponentVer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            grdComponent.activeDataRowKey,                                          // Component
                            r[0] + (r[3].ToString() == FYesNo.Yes.ToString() ? "*" : string.Empty), // Component Version
                            r[1].ToString(),                                                        // Description
                            r[2].ToString(),
                            FDataConvert.defaultDataTimeFormating(r[4].ToString())
                            };
                        key = r[0].ToString();
                        index = grdVersion.appendDataRow(key, cellValues).Index;
                        // --
                        grdVersion.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfComponentVersion(grdVersion, grdComponent.activeDataRow["Type"].ToString());
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

                if (tabMain.ActiveTab.Key == "Component Version")
                {
                    grdVersion.Focus();
                }
            }
            catch (Exception ex)
            {
                grdVersion.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfComponent(
            )
        {
            FPropComponent fPropCom = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInCom = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutCom = null;
            string key = string.Empty;
            object[] cellValues = null;
            string releaseVer = string.Empty;
            string lastVer = string.Empty;

            try
            {
                fPropCom = (FPropComponent)pgdComponent.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropCom.Component, true, this.fUIWizard, "Component");

                if (fPropCom.Component.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Component" }));
                }

                // --

                if (fPropCom.Description.Length > 50)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetComponentUpdate_In.E_ADMADS_SetComponentUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hLanguage, FADMADS_SetComponentUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hFactory, FADMADS_SetComponentUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hUserId, FADMADS_SetComponentUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hHostIp, FADMADS_SetComponentUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hHostName, FADMADS_SetComponentUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hStep, FADMADS_SetComponentUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInCom = fXmlNodeIn.set_elem(FADMADS_SetComponentUpdate_In.FComponent.E_Component);
                fXmlNodeInCom.set_elemVal(FADMADS_SetComponentUpdate_In.FComponent.A_Component, FADMADS_SetComponentUpdate_In.FComponent.D_Component, fPropCom.Component);
                fXmlNodeInCom.set_elemVal(FADMADS_SetComponentUpdate_In.FComponent.A_Description, FADMADS_SetComponentUpdate_In.FComponent.D_Description, fPropCom.Description);
                fXmlNodeInCom.set_elemVal(FADMADS_SetComponentUpdate_In.FComponent.A_Type, FADMADS_SetComponentUpdate_In.FComponent.D_Type, fPropCom.Type.ToString());

                // --

                FADMADSCaster.ADMADS_SetComponentUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetComponentUpdate_Out.A_hStatus, FADMADS_SetComponentUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetComponentUpdate_Out.A_hStatusMessage, FADMADS_SetComponentUpdate_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutCom = fXmlNodeOut.get_elem(FADMADS_SetComponentUpdate_Out.FComponent.E_Component);
                releaseVer = fXmlNodeOutCom.get_elemVal(FADMADS_SetComponentUpdate_Out.FComponent.A_ReleaseVer, FADMADS_SetComponentUpdate_Out.FComponent.D_ReleaseVer);
                lastVer = fXmlNodeOutCom.get_elemVal(FADMADS_SetComponentUpdate_Out.FComponent.A_LastVer, FADMADS_SetComponentUpdate_Out.FComponent.D_LastVer);

                // --

                cellValues = new object[]
                {
                    fPropCom.Component,
                    fPropCom.Description,
                    fPropCom.Type.ToString(),
                    releaseVer,
                    lastVer
                };
                // --
                key = fPropCom.Component;
                grdComponent.appendOrUpdateDataRow(key, cellValues);
                grdComponent.activateDataRow(key);

                // --

                refreshComponentTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropCom = null;
                fXmlNodeIn = null;
                fXmlNodeInCom = null;
                fXmlNodeOut = null;
                fXmlNodeOutCom = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode updateVersion(
            string hStep,
            string version,
            FPropComponentVersion fPropVer,
            string path
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInVer = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetComponentVerUpdate_In.E_ADMADS_SetComponentVerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hLanguage, FADMADS_SetComponentVerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hFactory, FADMADS_SetComponentVerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hUserId, FADMADS_SetComponentVerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hHostIp, FADMADS_SetComponentVerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hHostName, FADMADS_SetComponentVerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hStep, FADMADS_SetComponentVerUpdate_In.D_hStep, hStep);

                // --

                fXmlNodeInVer = fXmlNodeIn.set_elem(FADMADS_SetComponentVerUpdate_In.FVersion.E_Version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerUpdate_In.FVersion.A_Component, FADMADS_SetComponentVerUpdate_In.FVersion.D_Component, fPropVer.Component);
                fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerUpdate_In.FVersion.A_Version, FADMADS_SetComponentVerUpdate_In.FVersion.D_Version, version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerUpdate_In.FVersion.A_Description, FADMADS_SetComponentVerUpdate_In.FVersion.D_Description, fPropVer.Description);
                fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerUpdate_In.FVersion.A_Comment, FADMADS_SetComponentVerUpdate_In.FVersion.D_Comment, fPropVer.Comments);
                fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerUpdate_In.FVersion.A_Release, FADMADS_SetComponentVerUpdate_In.FVersion.D_Release, fPropVer.Release.ToString());
                fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerUpdate_In.FVersion.A_Path, FADMADS_SetComponentVerUpdate_In.FVersion.D_Path, Path.GetFileName(path));

                // --

                FADMADSCaster.ADMADS_SetComponentVerUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetComponentVerUpdate_Out.A_hStatus, FADMADS_SetComponentVerUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetComponentVerUpdate_Out.A_hStatusMessage, FADMADS_SetComponentVerUpdate_Out.D_hStatusMessage)
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
                    r.Cells[1].Value = key == version ? key + "*" : key;
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

        private void insertGridOfVersion(
            )
        {
            FPropComponentVersion fPropVer = null;
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

            try
            {
                FCursor.waitCursor();

                // --

                fPropVer = (FPropComponentVersion)pgdVersion.selectedObject;

                // --

                #region Validation

                if (fPropVer.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                if (fPropVer.Comments.Length > 400)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Comments" }));
                }

                // --

                if (fPropVer.newFile == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0041", new object[] { "New Component Version File" }));
                }

                #endregion

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0009", new object[] { "New Component Version" }),
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
                // Comonent Version File Copy to Temp Directory
                // ***
                fileName = tempFilePath + "\\" + grdComponent.activeDataRowKey + Path.GetExtension(fPropVer.File);
                File.Copy(fPropVer.newFile, fileName);

                // --

                // ***
                // Component Version File Pack & FTP Upload
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
                fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetComponentVerUpdate_Out.FVersion.E_Version);
                version = fXmlNodeOutVer.get_elemVal(FADMADS_SetComponentVerUpdate_Out.FVersion.A_Version, FADMADS_SetComponentVerUpdate_Out.FVersion.D_Version);
                releaseVer = fXmlNodeOutVer.get_elemVal(FADMADS_SetComponentVerUpdate_Out.FVersion.A_Release, FADMADS_SetComponentVerUpdate_Out.FVersion.D_Release);
                zipFileName = fXmlNodeOutVer.get_elemVal(FADMADS_SetComponentVerUpdate_Out.FVersion.A_Path, FADMADS_SetComponentVerUpdate_Out.FVersion.D_Path);

                // --

                grdComponent.ActiveRow.Cells["Release Ver."].Value = releaseVer;
                grdComponent.ActiveRow.Cells["Last Ver."].Value = version;
                // --
                cellValues = new object[] {
                    grdComponent.activeDataRowKey, // Component
                    version,                       // Component Version
                    fPropVer.Description,          // Component Version Description
                    zipFileName                    // Component File
                };
                // --
                key = version;
                grdVersion.insertBeforeDataRow(0, key, cellValues);
                // -- 
                setReleasedVersion(releaseVer);
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
            FPropComponentVersion fPropVer = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutVer = null;
            string releaseVer = string.Empty;
            string componentVer = string.Empty;

            try
            {
                fPropVer = (FPropComponentVersion)pgdVersion.selectedObject;

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
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0022", new object[] { "Component Version File" }));
                }

                #endregion

                // --

                componentVer = grdVersion.activeDataRowKey;
                componentVer = componentVer.Contains("*") ? componentVer.Substring(0, componentVer.IndexOf("*", 0)) : componentVer;

                // --

                fXmlNodeOut = updateVersion("1", componentVer, fPropVer, string.Empty);
                // --
                fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetComponentVerUpdate_Out.FVersion.E_Version);
                releaseVer = fXmlNodeOutVer.get_elemVal(FADMADS_SetComponentVerUpdate_Out.FVersion.A_Release, FADMADS_SetComponentVerUpdate_Out.FVersion.D_Release);

                // --

                grdComponent.ActiveRow.Cells["Release Ver."].Value = releaseVer;
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

        private void deleteGridOfComponent(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInCom = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Component" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdComponent.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetComponentUpdate_In.E_ADMADS_SetComponentUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hLanguage, FADMADS_SetComponentUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hStep, FADMADS_SetComponentUpdate_In.D_hStep, "2");
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hFactory, FADMADS_SetComponentUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hUserId, FADMADS_SetComponentUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hHostIp, FADMADS_SetComponentUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentUpdate_In.A_hHostName, FADMADS_SetComponentUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);

                // --

                fXmlNodeInCom = fXmlNodeIn.set_elem(FADMADS_SetComponentUpdate_In.FComponent.E_Component);

                // --

                foreach (UltraDataRow dr in grdComponent.selectedDataRows)
                {
                    fXmlNodeInCom.set_elemVal(FADMADS_SetComponentUpdate_In.FComponent.A_Component, FADMADS_SetComponentUpdate_In.FComponent.D_Component, dr["Component"].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetComponentUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetComponentUpdate_Out.A_hStatus, FADMADS_SetComponentUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetComponentUpdate_Out.A_hStatusMessage, FADMADS_SetComponentUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdComponent.removeDataRow(dr.Index);
                }

                // --

                grdComponent.endUpdate();

                // --

                if (grdComponent.Rows.Count == 0)
                {
                    initPropOfComponent();
                    initPropOfVersion();
                }

                // --

                refreshVersionTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdComponent.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInCom = null;
                fXmlNodeOut = null;
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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetComponentVerUpdate_In.E_ADMADS_SetComponentVerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hLanguage, FADMADS_SetComponentVerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hFactory, FADMADS_SetComponentVerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hUserId, FADMADS_SetComponentVerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hHostIp, FADMADS_SetComponentVerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hHostName, FADMADS_SetComponentVerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerUpdate_In.A_hStep, FADMADS_SetComponentVerUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInVer = fXmlNodeIn.set_elem(FADMADS_SetComponentVerUpdate_In.FVersion.E_Version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerUpdate_In.FVersion.A_Component, FADMADS_SetComponentVerUpdate_In.FVersion.D_Component, grdComponent.activeDataRowKey );

                // --

                foreach (UltraDataRow dr in grdVersion.selectedDataRows)
                {
                    fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerUpdate_In.FVersion.A_Version, FADMADS_SetComponentVerUpdate_In.FVersion.D_Version, grdVersion.getDataRowKey(dr.Index));
                    fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerUpdate_In.FVersion.A_Path, FADMADS_SetComponentVerUpdate_In.FVersion.D_Path, dr["File"].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetComponentVerUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetComponentVerUpdate_Out.A_hStatus, FADMADS_SetComponentVerUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetComponentVerUpdate_Out.A_hStatusMessage, FADMADS_SetComponentVerUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetComponentVerUpdate_Out.FVersion.E_Version);
                    releaseVer = fXmlNodeOutVer.get_elemVal(FADMADS_SetComponentVerUpdate_Out.FVersion.A_Release, FADMADS_SetComponentVerUpdate_Out.FVersion.D_Release);
                    // --
                    grdComponent.ActiveRow.Cells["Release Ver."].Value = releaseVer;
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

        private void refreshComponentTotal(
            )
        {
            try
            {
                lblComTotal.Text = grdComponent.Rows.Count.ToString("#,##0");
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

        #region Popup Menu

        private void procMenuComponentStatus(
            )
        {
            FComponentStatus fComponentStatus = null;
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;
                // --
                fComponentStatus = (FComponentStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FComponentStatus));
                if (fComponentStatus == null)
                {
                    fComponentStatus = new FComponentStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fComponentStatus);
                }
                fComponentStatus.activate();
                fComponentStatus.attach(grdComponent.activeDataRowKey, this.activeType, this.activeVersion);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fComponentStatus = null;
            }
        }

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FComponent Form Event Handler

        private void FComponent_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Component);

                // --

                designGridOfComponent();
                designGridOfVersion();

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

        private void FComponent_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfComponent(string.Empty);

                // --

                grdComponent.Focus();
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

        private void FComponent_FormClosing(
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

        private void FComponent_KeyDown(
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
                    if (tabMain.ActiveTab.Key == "Component")
                    {
                        refreshGridOfComponent(grdComponent.activeDataRowKey);
                    }
                    else if (tabMain.ActiveTab.Key == "Component Version")
                    {
                        refreshGridOfVersion(grdVersion.activeDataRowKey);
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

                if (e.Tool.Key == FMenuKey.MenuSetComponentStatus)
                {
                    procMenuComponentStatus();
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

                key = e.Tab.Key;

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

        #region grdComponent Control Event Handler

        private void grdComponent_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfComponent();

                // --

                refreshGridOfVersion(string.Empty);
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

        private void grdComponent_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.Tabs[1].Selected = true;
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

        private void grdComponent_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfComponent();
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

        private void grdComponent_MouseDown(
            object sender,
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdComponent.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdComponent.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdComponent.ActiveRow = grdComponent.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuSetComponentStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ComponentStatus);
                
                // --
                
                mnuMenu.ShowPopup(FMenuKey.MenuSetComPopupMenu);
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

                mnuMenu.Tools[FMenuKey.MenuSetComponentStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.ComponentStatus);
                
                // --
                
                mnuMenu.ShowPopup(FMenuKey.MenuSetComPopupMenu);
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

                if (key == "Component")
                {
                    updateGridOfComponent();
                }
                else if (key == "Component Version")
                {
                    updateGridOfVersion();
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

                if (key == "Component")
                {
                    initPropOfComponent();
                }
                else if (key == "Component Version")
                {
                    initPropOfVersion();
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

                if (key == "Component")
                {
                    deleteGridOfComponent();
                }
                else if (key == "Component Version")
                {
                    deleteGridOfVersion();
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
                FCursor.waitCursor();

                // --

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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetComponentVerDownload_In.E_ADMADS_SetComponentVerDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerDownload_In.A_hLanguage, FADMADS_SetComponentVerDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerDownload_In.A_hFactory, FADMADS_SetComponentVerDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerDownload_In.A_hUserId, FADMADS_SetComponentVerDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerDownload_In.A_hHostIp, FADMADS_SetComponentVerDownload_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerDownload_In.A_hHostName, FADMADS_SetComponentVerDownload_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetComponentVerDownload_In.A_hStep, FADMADS_SetComponentVerDownload_In.D_hStep, "1");

                // --

                fXmlNodeInVer = fXmlNodeIn.set_elem(FADMADS_SetComponentVerDownload_In.FVersion.E_Version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerDownload_In.FVersion.A_Component, FADMADS_SetComponentVerDownload_In.FVersion.D_Component, grdComponent.activeDataRowKey);
                
                // --
                
                foreach (string s in grdVersion.selectedDataRowKeys)
                {
                    fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerDownload_In.FVersion.A_Version, FADMADS_SetComponentVerDownload_In.FVersion.D_Version, s);
                    fXmlNodeInVer.set_elemVal(FADMADS_SetComponentVerDownload_In.FVersion.A_File, FADMADS_SetComponentVerDownload_In.FVersion.D_File, grdVersion.activeDataRow["File"].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetComponentVerDownload_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetComponentVerDownload_Out.A_hStatus, FADMADS_SetComponentVerDownload_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetComponentVerDownload_Out.A_hStatusMessage, FADMADS_SetComponentVerDownload_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetComponentVerDownload_Out.FVersion.E_Version);
                    zipFileName = fXmlNodeOutVer.get_elemVal(FADMADS_SetComponentVerDownload_Out.FVersion.A_Path, FADMADS_SetComponentVerDownload_Out.FVersion.D_Path);

                    // --

                    fFtp.downloadFiles(tempFilePath, zipFileName);
                    fFtp.deleteFiles(zipFileName);

                    // --

                    zipFileName = tempFilePath + "\\" + zipFileName;
                    downloadFilePath = Path.Combine(fbd.SelectedPath, m_fAdmCore.fOption.factory + "_" + grdComponent.activeDataRowKey + "_" + s);
                    // --
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region rstComponent Control Event Handler

        private void rstComponent_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfComponent(grdComponent.activeDataRowKey);
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

        private void rstComponent_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdComponent.searchGridRow(e.searchWord))
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

    }   // Class end
}   // Namespace end
