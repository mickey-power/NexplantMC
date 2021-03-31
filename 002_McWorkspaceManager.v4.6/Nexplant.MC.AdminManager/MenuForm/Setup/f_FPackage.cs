/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FPackage.cs
--  Creator         : kitae
--  Create Date     : 2012.03.22
--  Description     : FAMate Admin Manager Setup Package Form Class 
--  History         : Created by kitae at 2012.03.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Drawing;
using System.Diagnostics;
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
    public partial class FPackage : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPackage(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPackage(
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
                    return grdPackage.activeDataRow == null ? string.Empty : grdPackage.activeDataRow["Type"].ToString();
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
                        version = grdPackage.activeDataRow == null ? string.Empty : grdPackage.activeDataRow["Release Ver."].ToString();
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

                if (key == "Package")
                {
                    btnDelete.Enabled = grdPackage.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnDownload.Enabled = false;
                    // --
                    btnNewVersion.Enabled = false;
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdPackage.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "Package Version")
                {
                    btnDelete.Enabled = grdVersion.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnDownload.Enabled = grdVersion.activeDataRowKey != string.Empty && m_tranEnabled;
                    // --
                    btnNewVersion.Enabled = grdPackage.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void initPropOfPackage(
            )
        {
            try
            {
                pgdPackage.selectedObject = new FPropPackage(m_fAdmCore, pgdPackage, m_tranEnabled);
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
                pgdVersion.selectedObject = new FPropPackageVersion(m_fAdmCore, pgdVersion, grdPackage.activeDataRowKey, m_tranEnabled);
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

        private void setPropOfPackage(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdPackage.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("package", grdPackage.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Package", "SearchPackage", fSqlParams, true);

                // --

                pgdPackage.selectedObject = new FPropPackage(m_fAdmCore, pgdPackage, dt, m_tranEnabled);
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
            DataTable dtPkgVer = null;
            DataTable dtPkgVerFile = null;

            try
            {
                if (grdVersion.activeDataRow == null)
                {
                    return;
                }

                // --

                // ***
                // Package Version Request
                // ***
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("package", grdPackage.activeDataRowKey);
                fSqlParams.add("pkg_ver", grdVersion.activeDataRowKey);

                // --

                dtPkgVer = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "PackageVer", "SearchPackageVer", fSqlParams, true);

                // --

                // ***
                // Package Version File Request
                // ***
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("package", grdPackage.activeDataRowKey);
                fSqlParams.add("pkg_ver", grdVersion.activeDataRowKey);

                // --

                dtPkgVerFile = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "PackageVer", "ListPackageVerFile", fSqlParams, false);

                // --

                pgdVersion.selectedObject = new FPropPackageVersion(m_fAdmCore, pgdVersion, dtPkgVer, dtPkgVerFile, m_tranEnabled);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dtPkgVer = null;
                dtPkgVerFile = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfPackage(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdPackage.dataSource;
                // --
                uds.Band.Columns.Add("Package");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Release Ver.");
                uds.Band.Columns.Add("Last Ver.");
                
                // --

                grdPackage.DisplayLayout.Bands[0].Columns["Release Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                grdPackage.DisplayLayout.Bands[0].Columns["Last Ver."].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdPackage.DisplayLayout.Bands[0].Columns["Package"].Header.Fixed = true;
                // --
                grdPackage.DisplayLayout.Bands[0].Columns["Package"].Width = 140;
                grdPackage.DisplayLayout.Bands[0].Columns["Description"].Width = 342;
                grdPackage.DisplayLayout.Bands[0].Columns["Type"].Width = 77;
                grdPackage.DisplayLayout.Bands[0].Columns["Release Ver."].Width = 77;
                grdPackage.DisplayLayout.Bands[0].Columns["Last Ver."].Width = 77;

                // --

                grdPackage.ImageList = new ImageList();
                // --
                grdPackage.ImageList.Images.Add("Package", Properties.Resources.Package);
                grdPackage.ImageList.Images.Add("Package_Secs", Properties.Resources.Package_Secs);
                grdPackage.ImageList.Images.Add("Package_Plc", Properties.Resources.Package_Plc);
                grdPackage.ImageList.Images.Add("Package_Opc", Properties.Resources.Package_Opc);
                grdPackage.ImageList.Images.Add("Package_Tcp", Properties.Resources.Package_Tcp);
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
                uds.Band.Columns.Add("Package");
                uds.Band.Columns.Add("Version");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("File");
                uds.Band.Columns.Add("Update Time");
                
                // --

                grdVersion.DisplayLayout.Bands[0].Columns["Package"].Header.Fixed = true;
                grdVersion.DisplayLayout.Bands[0].Columns["Version"].Header.Fixed = true;
                // --
                grdVersion.DisplayLayout.Bands[0].Columns["Package"].Width = 140;
                grdVersion.DisplayLayout.Bands[0].Columns["Version"].Width = 77;
                grdVersion.DisplayLayout.Bands[0].Columns["Description"].Width = 138;
                grdVersion.DisplayLayout.Bands[0].Columns["File"].Width = 200;
                grdVersion.DisplayLayout.Bands[0].Columns["Update Time"].Width = 150;
                
                // --

                grdVersion.ImageList = new ImageList();
                // --
                grdVersion.ImageList.Images.Add("PackageVersion", Properties.Resources.PackageVersion);
                grdVersion.ImageList.Images.Add("PackageVersion_Secs", Properties.Resources.PackageVersion_Secs);
                grdVersion.ImageList.Images.Add("PackageVersion_Plc", Properties.Resources.PackageVersion_Plc);
                grdVersion.ImageList.Images.Add("PackageVersion_Opc", Properties.Resources.PackageVersion_Opc);
                grdVersion.ImageList.Images.Add("PackageVersion_Tcp", Properties.Resources.PackageVersion_Tcp);
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

        private void refreshGridOfPackage(
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
                grdPackage.removeAllDataRow();
                grdVersion.removeAllDataRow();
                grdPackage.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdVersion.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfPackage();
                initPropOfVersion();
                // --
                refreshVersionTotal();

                // --
                
                grdPackage.beginUpdate(false);
                                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --                
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Package", "ListPackage", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Package
                            r[1].ToString(),   // Description
                            r[2].ToString(),   // Type
                            r[3].ToString(),   // Release Version
                            r[4].ToString()    // Last Version                         
                            };
                        key = (string)cellValues[0];
                        index = grdPackage.appendDataRow(key, cellValues).Index;
                        // --
                        grdPackage.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfPackage(grdPackage, r[2].ToString());
                    }
                } while (nextRowNumber >= 0);
                
                // --

                grdPackage.endUpdate(false);

                // --

                if (grdPackage.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdPackage.activateDataRow(beforeKey);
                    }
                    if (grdPackage.activeDataRow == null)
                    {
                        grdPackage.ActiveRow = grdPackage.Rows[0];
                    }
                }

                // --

                refreshPackageTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Package")
                {
                    grdPackage.Focus();
                }
            }
            catch (Exception ex)
            {
                grdPackage.endUpdate(false);
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

                if (grdPackage.activeDataRow == null)
                {
                    return;
                }

                // --

                grdVersion.beginUpdate(false);

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("package", grdPackage.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "PackageVer", "ListPackageVer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            grdPackage.activeDataRowKey,                                                       // Package
                            r[0].ToString() + (r[3].ToString() == FYesNo.Yes.ToString() ? "*" : string.Empty), // Version
                            r[1].ToString(),                                                                   // Description
                            r[2].ToString(),
                            FDataConvert.defaultDataTimeFormating(r[4].ToString())
                            };
                        key = r[0].ToString();
                        index = grdVersion.appendDataRow(key, cellValues).Index;
                        // --
                        grdVersion.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfPackageVersion(grdVersion, grdPackage.activeDataRow["Type"].ToString());
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

                // --

                if (tabMain.ActiveTab.Key == "Package Version")
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
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfPackage(
            )
        {
            FPropPackage fPropPkg = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInPkg = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutPkg = null;
            string key = string.Empty;
            object[] cellValues = null;
            string releaseVer = string.Empty;
            string lastVer = string.Empty;
            int index = 0;

            try
            {
                fPropPkg = (FPropPackage)pgdPackage.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropPkg.Package, true, this.fUIWizard, "Package");

                if (fPropPkg.Package.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Package" }));
                }

                // --

                if (fPropPkg.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetPackageUpdate_In.E_ADMADS_SetPackageUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hLanguage, FADMADS_SetPackageUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hFactory, FADMADS_SetPackageUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hUserId, FADMADS_SetPackageUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hHostIp, FADMADS_SetPackageUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hHostName, FADMADS_SetPackageUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hStep, FADMADS_SetPackageUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInPkg = fXmlNodeIn.set_elem(FADMADS_SetPackageUpdate_In.FPackage.E_Package);
                fXmlNodeInPkg.set_elemVal(FADMADS_SetPackageUpdate_In.FPackage.A_Package, FADMADS_SetPackageUpdate_In.FPackage.D_Package, fPropPkg.Package);
                fXmlNodeInPkg.set_elemVal(FADMADS_SetPackageUpdate_In.FPackage.A_Description, FADMADS_SetPackageUpdate_In.FPackage.D_Description, fPropPkg.Description);
                fXmlNodeInPkg.set_elemVal(FADMADS_SetPackageUpdate_In.FPackage.A_Type, FADMADS_SetPackageUpdate_In.FPackage.D_Type, fPropPkg.Type.ToString());

                // --

                FADMADSCaster.ADMADS_SetPackageUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetPackageUpdate_Out.A_hStatus, FADMADS_SetPackageUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetPackageUpdate_Out.A_hStatusMessage, FADMADS_SetPackageUpdate_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutPkg = fXmlNodeOut.get_elem(FADMADS_SetPackageUpdate_Out.FPackage.E_Package);
                releaseVer = fXmlNodeOutPkg.get_elemVal(FADMADS_SetPackageUpdate_Out.FPackage.A_ReleaseVer, FADMADS_SetPackageUpdate_Out.FPackage.D_ReleaseVer);
                lastVer = fXmlNodeOutPkg.get_elemVal(FADMADS_SetPackageUpdate_Out.FPackage.A_LastVer, FADMADS_SetPackageUpdate_Out.FPackage.D_LastVer);

                // --

                cellValues = new object[]
                {
                    fPropPkg.Package,
                    fPropPkg.Description,
                    fPropPkg.Type.ToString(),
                    releaseVer,
                    lastVer
                };
                // --
                key = fPropPkg.Package;
                index = grdPackage.appendOrUpdateDataRow(key, cellValues).Index;
                // --
                grdPackage.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfPackage(grdPackage, fPropPkg.Type.ToString());

                // --
                
                grdPackage.activateDataRow(key);

                // --

                refreshPackageTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropPkg = null;
                fXmlNodeIn = null;
                fXmlNodeInPkg = null;
                fXmlNodeOut = null;
                fXmlNodeOutPkg = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FXmlNode updateVersion(
            string hStep,
            string version,
            FPropPackageVersion fPropVer,
            string path
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInVer = null;
            FXmlNode fXmlNodeInVerFil = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetPackageVerUpdate_In.E_ADMADS_SetPackageVerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hLanguage, FADMADS_SetPackageVerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hFactory, FADMADS_SetPackageVerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hUserId, FADMADS_SetPackageVerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hHostIp, FADMADS_SetPackageVerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hHostName, FADMADS_SetPackageVerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hStep, FADMADS_SetPackageVerUpdate_In.D_hStep, hStep);

                // --

                fXmlNodeInVer = fXmlNodeIn.set_elem(FADMADS_SetPackageVerUpdate_In.FVersion.E_Version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.A_Package, FADMADS_SetPackageVerUpdate_In.FVersion.D_Package, grdPackage.activeDataRowKey);
                fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.A_Version, FADMADS_SetPackageVerUpdate_In.FVersion.D_Version, version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.A_Description, FADMADS_SetPackageVerUpdate_In.FVersion.D_Description, fPropVer.Description);
                fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.A_Comment, FADMADS_SetPackageVerUpdate_In.FVersion.D_Comment, fPropVer.Comments);
                fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.A_Release, FADMADS_SetPackageVerUpdate_In.FVersion.D_Release, fPropVer.Release.ToString());
                fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.A_Path, FADMADS_SetPackageVerUpdate_In.FVersion.D_Path, Path.GetFileName(path));
                
                // --
                
                if (fPropVer.newFileList != null)
                {
                    foreach (FPackageVersionFile f in fPropVer.newFileList)
                    {
                        fXmlNodeInVerFil = fXmlNodeInVer.add_elem(FADMADS_SetPackageVerUpdate_In.FVersion.FFile.E_File);
                        fXmlNodeInVerFil.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.FFile.A_File, FADMADS_SetPackageVerUpdate_In.FVersion.FFile.D_File, Path.GetFileName(f.name));
                        fXmlNodeInVerFil.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.FFile.A_Type, FADMADS_SetPackageVerUpdate_In.FVersion.FFile.D_Type, f.type);
                    }
                }

                // --

                FADMADSCaster.ADMADS_SetPackageVerUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetPackageVerUpdate_Out.A_hStatus, FADMADS_SetPackageVerUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetPackageVerUpdate_Out.A_hStatusMessage, FADMADS_SetPackageVerUpdate_Out.D_hStatusMessage)
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
                fXmlNodeInVerFil = null;
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

        private void insertGridOfVersion(
            )
        {
            FPropPackageVersion fPropVer = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutVer = null;
            object[] cellValues = null;
            string key = string.Empty;
            FFtp fFtp = null;
            string[] files = null;
            string tempFilePath = string.Empty;
            string fileName = string.Empty;
            string zipFileName = string.Empty;
            string version = string.Empty;
            string releaseVer = string.Empty;
            int index = 0;

            try
            {
                fPropVer = (FPropPackageVersion)pgdVersion.selectedObject;

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

                if (fPropVer.newFileList == null)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0041", new object[] { "New Package Version File" }));
                }

                #endregion

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0009", new object[] { "New Package Version" }),
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
                // Package Version File Copy to Temp Directory
                // ***
                files = new string[fPropVer.newFileList.Length];
                files[0] = tempFilePath + "\\" + grdPackage.activeDataRowKey + Path.GetExtension(fPropVer.newFileList[0].name);
                File.Copy(fPropVer.newFileList[0].name, files[0]);
                for (int i = 1; i < fPropVer.newFileList.Length; i++)
                {
                    files[i] = tempFilePath + "\\" + Path.GetFileName(fPropVer.newFileList[i].name);
                    File.Copy(fPropVer.newFileList[i].name, files[i]);
                }

                // --

                // ***
                // Package Version File Pack & FTP Upload
                // ***
                zipFileName = tempFilePath + string.Format(FConstants.TempFileFormat, Guid.NewGuid().ToString(), FConstants.ZipFileExtension);
                F7Zip.pack(zipFileName, files);
                // --                
                fFtp = FCommon.createFtp(m_fAdmCore);
                fFtp.uploadFiles(zipFileName);

                // --

                FCommon.deleteDirectory(tempFilePath);

                // --

                fXmlNodeOut = updateVersion("3", "0", fPropVer, zipFileName);
                // --
                fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetPackageVerUpdate_Out.FVersion.E_Version);
                version = fXmlNodeOutVer.get_elemVal(FADMADS_SetPackageVerUpdate_Out.FVersion.A_Version, FADMADS_SetPackageVerUpdate_Out.FVersion.D_Version);
                releaseVer = fXmlNodeOutVer.get_elemVal(FADMADS_SetPackageVerUpdate_Out.FVersion.A_Release, FADMADS_SetPackageVerUpdate_Out.FVersion.D_Release);
                zipFileName = fXmlNodeOutVer.get_elemVal(FADMADS_SetPackageVerUpdate_Out.FVersion.A_Path, FADMADS_SetPackageVerUpdate_Out.FVersion.D_Path);

                // --

                grdPackage.ActiveRow.Cells["Release Ver."].Value = releaseVer;
                grdPackage.ActiveRow.Cells["Last Ver."].Value = version;
                // --
                cellValues = new object[] {
                    grdPackage.activeDataRowKey, // Package 
                    version,                     // Package Version
                    fPropVer.Description,        // Package Version Description
                    zipFileName                  // Package File
                    };
                // --
                key = version;
                index = grdVersion.insertBeforeDataRow(0, key, cellValues).Index;
                // --
                grdVersion.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfPackageVersion(grdVersion, grdPackage.activeDataRow["Type"].ToString());

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
            FPropPackageVersion fPropVer = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutVer = null;
            string releaseVer = string.Empty;
            string packageVer = string.Empty;

            try
            {
                fPropVer = (FPropPackageVersion)pgdVersion.selectedObject;

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

                if (fPropVer.newFileList != null)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0022", new object[] { "Package Version File" }));
                }

                #endregion

                // --

                packageVer = grdVersion.activeDataRowKey;
                packageVer = packageVer.Contains("*") ? packageVer.Substring(0, packageVer.IndexOf("*", 0)) : packageVer;

                // --

                fXmlNodeOut = updateVersion("1", packageVer, fPropVer, string.Empty);
                // --
                fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetPackageVerUpdate_Out.FVersion.E_Version);
                releaseVer = fXmlNodeOutVer.get_elemVal(FADMADS_SetPackageVerUpdate_Out.FVersion.A_Release, FADMADS_SetPackageVerUpdate_Out.FVersion.D_Release);

                // --

                grdPackage.ActiveRow.Cells["Release Ver."].Value = releaseVer;
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

        private void deleteGridOfPackage(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInPkg = null;
            FXmlNode fXmlNodeOut = null;
 
            try
            {
                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Package" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdPackage.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetPackageUpdate_In.E_ADMADS_SetPackageUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hLanguage, FADMADS_SetPackageUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hFactory, FADMADS_SetPackageUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hUserId, FADMADS_SetPackageUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hHostIp, FADMADS_SetPackageUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hHostName, FADMADS_SetPackageUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageUpdate_In.A_hStep, FADMADS_SetPackageUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInPkg = fXmlNodeIn.set_elem(FADMADS_SetPackageUpdate_In.FPackage.E_Package);

                // --

                foreach (UltraDataRow dr in grdPackage.selectedDataRows)
                {
                    fXmlNodeInPkg.set_elemVal(FADMADS_SetPackageUpdate_In.FPackage.A_Package, FADMADS_SetPackageUpdate_In.FPackage.D_Package, dr["Package"].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetPackageUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetPackageUpdate_Out.A_hStatus, FADMADS_SetPackageUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetPackageUpdate_Out.A_hStatusMessage, FADMADS_SetPackageUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdPackage.removeDataRow(dr.Index);
                }

                // --

                grdPackage.endUpdate();

                // --

                if (grdPackage.Rows.Count == 0)
                {
                    initPropOfPackage();
                    initPropOfVersion();
                }

                // --

                refreshPackageTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdPackage.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInPkg = null;
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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetPackageVerUpdate_In.E_ADMADS_SetPackageVerUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hLanguage, FADMADS_SetPackageVerUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hFactory, FADMADS_SetPackageVerUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hUserId, FADMADS_SetPackageVerUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hHostIp, FADMADS_SetPackageVerUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hHostName, FADMADS_SetPackageVerUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerUpdate_In.A_hStep, FADMADS_SetPackageVerUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInVer = fXmlNodeIn.set_elem(FADMADS_SetPackageVerUpdate_In.FVersion.E_Version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.A_Package, FADMADS_SetPackageVerUpdate_In.FVersion.D_Package, grdPackage.activeDataRowKey);

                // --

                foreach (UltraDataRow r in grdVersion.selectedDataRows)
                {
                    fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.A_Version, FADMADS_SetPackageVerUpdate_In.FVersion.D_Version, grdVersion.getDataRowKey(r.Index));
                    fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerUpdate_In.FVersion.A_Path, FADMADS_SetPackageVerUpdate_In.FVersion.D_Path, r["File"].ToString());
                    // --
                    FADMADSCaster.ADMADS_SetPackageVerUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetPackageVerUpdate_Out.A_hStatus, FADMADS_SetPackageVerUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetPackageVerUpdate_Out.A_hStatusMessage, FADMADS_SetPackageVerUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetPackageVerUpdate_Out.FVersion.E_Version);
                    releaseVer = fXmlNodeOutVer.get_elemVal(FADMADS_SetPackageVerUpdate_Out.FVersion.A_Release, FADMADS_SetPackageVerUpdate_Out.FVersion.D_Release);
                    // --
                    grdPackage.ActiveRow.Cells["Release Ver."].Value = releaseVer;
                    grdVersion.removeDataRow(r.Index);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
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

        private void refreshPackageTotal(
            )
        {
            try
            {
                lblPkgTotal.Text = grdPackage.Rows.Count.ToString("#,##0");
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

        private void procMenuPackageStatus(
            )
        {
            FPackageStatus fPackageStatus = null;
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;
                // --
                fPackageStatus = (FPackageStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FPackageStatus));
                if (fPackageStatus == null)
                {
                    fPackageStatus = new FPackageStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fPackageStatus);
                }
                fPackageStatus.activate();
                // --
                fPackageStatus.attach(grdPackage.activeDataRowKey, this.activeType, this.activeVersion);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPackageStatus = null;
            }
        }

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FPackage Form Event Handler

        private void FPackage_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Package);

                // --

                designGridOfPackage();
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

        private void FPackage_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfPackage(string.Empty);

                // --

                grdPackage.Focus();
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

        private void FPackage_FormClosing(
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

        private void FPackage_KeyDown(
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
                    if (tabMain.ActiveTab.Key == "Package")
                    {
                        refreshGridOfPackage(grdPackage.activeDataRowKey);
                    }                    
                    else
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

                if (e.Tool.Key == FMenuKey.MenuSetPackageStatus)
                {
                    procMenuPackageStatus();
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

        #region grdPackage Control Event Handler

        private void grdPackage_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfPackage();

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

        private void grdPackage_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.Tabs["Package Version"].Selected = true;
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

        private void grdPackage_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfPackage();
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

        private void grdPackage_MouseDown(
            object sender,
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdPackage.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdPackage.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdPackage.ActiveRow = grdPackage.Rows[r.Index];
                }

                // --

                mnuMenu.Tools[FMenuKey.MenuSetPackageStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.PackageStatus);
                
                // --
                
                mnuMenu.ShowPopup(FMenuKey.MenuSetPkgPopupMenu);
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

                mnuMenu.Tools[FMenuKey.MenuSetPackageStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.PackageStatus);
                
                // --
                
                mnuMenu.ShowPopup(FMenuKey.MenuSetPkgPopupMenu);
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

                if (key == "Package")
                {
                    updateGridOfPackage();
                }
                else if (key == "Package Version")
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

                if (key == "Package")
                {
                    initPropOfPackage();
                }
                else if (key == "Package Version")
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

                if (key == "Package")
                {
                    deleteGridOfPackage();
                }
                else if (key == "Package Version")
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

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetPackageVerDownload_In.E_ADMADS_SetPackageVerDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerDownload_In.A_hLanguage, FADMADS_SetPackageVerDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerDownload_In.A_hFactory, FADMADS_SetPackageVerDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerDownload_In.A_hUserId, FADMADS_SetPackageVerDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerDownload_In.A_hHostIp, FADMADS_SetPackageVerDownload_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerDownload_In.A_hHostName, FADMADS_SetPackageVerDownload_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetPackageVerDownload_In.A_hStep, FADMADS_SetPackageVerDownload_In.D_hStep, "1");

                // --

                fXmlNodeInVer = fXmlNodeIn.set_elem(FADMADS_SetPackageVerDownload_In.FVersion.E_Version);
                fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerDownload_In.FVersion.A_Package, FADMADS_SetPackageVerDownload_In.FVersion.D_Package, grdPackage.activeDataRowKey);

                // --

                foreach (string s in grdVersion.selectedDataRowKeys)
                {
                    fXmlNodeInVer.set_elemVal(FADMADS_SetPackageVerDownload_In.FVersion.A_Version, FADMADS_SetPackageVerDownload_In.FVersion.D_Version, s);
                    // --
                    FADMADSCaster.ADMADS_SetPackageVerDownload_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetPackageVerDownload_Out.A_hStatus, FADMADS_SetPackageVerDownload_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetPackageVerDownload_Out.A_hStatusMessage, FADMADS_SetPackageVerDownload_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutVer = fXmlNodeOut.get_elem(FADMADS_SetPackageVerDownload_Out.FVersion.E_Version);
                    zipFileName = fXmlNodeOutVer.get_elemVal(FADMADS_SetPackageVerDownload_Out.FVersion.A_Path, FADMADS_SetPackageVerDownload_Out.FVersion.D_Path);

                    // --

                    fFtp.downloadFiles(tempFilePath, zipFileName);
                    fFtp.deleteFiles(Path.GetFileName(zipFileName));

                    // --

                    zipFileName = tempFilePath + "\\" + zipFileName;
                    downloadFilePath = Path.Combine(fbd.SelectedPath, m_fAdmCore.fOption.factory + "_" + grdPackage.activeDataRowKey + "_" + s);
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

        #region rstPackage Control Event Handler

        private void rstPackage_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfPackage(grdPackage.activeDataRowKey);
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

        private void rstPackage_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdPackage.searchGridRow(e.searchWord))
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
            string beforeKey = string.Empty;

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
