/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEapClassSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2012.05.29
--  Description     : FAMate Admin Manager EAP Select Dialog Form Class 
--  History         : Created by spike.lee at 2012.05.29
                      Modified by iskim at 2013.07.05
                      - Eap Group, Eap Line Delete
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.AdminManager
{
    public partial class FEapClassSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FEapAttrCategory m_fDefaultCategory = FEapAttrCategory.Setup;
        private string m_excludeEapType = string.Empty;
        private string[] m_selectedEapList = null;
        private string[] m_selectedEapDescList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEapClassSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapClassSelector(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEapClassSelector(
            FAdmCore fAdmCore,
            FEapAttrCategory fDefaultCategory,
            string excludeEapType
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_fDefaultCategory = fDefaultCategory;
            m_excludeEapType = excludeEapType;
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

        public string[] selectedEapList
        {
            get
            {
                try
                {
                    return m_selectedEapList;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string[] selectedEapDescList
        {
            get
            {
                try
                {
                    return m_selectedEapDescList;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void designComboOfCategory(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbCategory.dataSource;
                // --
                uds.Band.Columns.Add("Category");

                // --

                ucbCategory.Appearance.Image = Properties.Resources.EapAttrCategory;
                // --
                ucbCategory.DisplayLayout.Bands[0].Columns["Category"].CellAppearance.Image = Properties.Resources.EapAttrCategory;
                ucbCategory.DisplayLayout.Bands[0].Columns["Category"].Width = ucbCategory.Width - 2;
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

        private void designGridOfEapClass(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdClass.dataSource;
                // --
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");                
                uds.Band.Columns.Add("Server IP");
                uds.Band.Columns.Add("Type");

                // --

                grdClass.DisplayLayout.Bands[0].Columns["Server IP"].Hidden = true;
                grdClass.DisplayLayout.Bands[0].Columns["Name"].Width = 100;
                grdClass.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdClass.DisplayLayout.Bands[0].Columns["Type"].Width = 80;

                // --

                uds.Band.ChildBands.Add("Version");
                // --
                uds.Band.ChildBands["Version"].Columns.Add("Version");
                uds.Band.ChildBands["Version"].Columns.Add("Description");

                // --

                grdClass.DisplayLayout.Bands["Version"].Columns["Version"].Width = 100;
                grdClass.DisplayLayout.Bands["Version"].Columns["Description"].Width = 180;
                // --
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.MultiBand;
                grdClass.DisplayLayout.ViewStyleBand = ViewStyleBand.Vertical;

                // --

                grdClass.ImageList = new ImageList();
                // --
                grdClass.ImageList.Images.Add("Server_Main_Up", Properties.Resources.Server_Main_Up);
                grdClass.ImageList.Images.Add("Server_Main_Alarm", Properties.Resources.Server_Main_Alarm);
                grdClass.ImageList.Images.Add("Server_Main_Down", Properties.Resources.Server_Main_Down);
                grdClass.ImageList.Images.Add("Server_Backup_Up", Properties.Resources.Server_Backup_Up);
                grdClass.ImageList.Images.Add("Server_Backup_Alarm", Properties.Resources.Server_Backup_Alarm);
                grdClass.ImageList.Images.Add("Server_Backup_Down", Properties.Resources.Server_Backup_Down);
                grdClass.ImageList.Images.Add("Package", Properties.Resources.Package);
                grdClass.ImageList.Images.Add("Package_Secs", Properties.Resources.Package_Secs);
                grdClass.ImageList.Images.Add("Package_Plc", Properties.Resources.Package_Plc);
                grdClass.ImageList.Images.Add("Package_Opc", Properties.Resources.Package_Opc);
                grdClass.ImageList.Images.Add("Package_Tcp", Properties.Resources.Package_Tcp);
                grdClass.ImageList.Images.Add("PackageVersion", Properties.Resources.PackageVersion);
                grdClass.ImageList.Images.Add("PackageVersion_Secs", Properties.Resources.PackageVersion_Secs);
                grdClass.ImageList.Images.Add("PackageVersion_Plc", Properties.Resources.PackageVersion_Plc);
                grdClass.ImageList.Images.Add("PackageVersion_Opc", Properties.Resources.PackageVersion_Opc);
                grdClass.ImageList.Images.Add("PackageVersion_Tcp", Properties.Resources.PackageVersion_Tcp);
                grdClass.ImageList.Images.Add("Model", Properties.Resources.Model);
                grdClass.ImageList.Images.Add("Model_Secs", Properties.Resources.Model_Secs);
                grdClass.ImageList.Images.Add("Model_Plc", Properties.Resources.Model_Plc);
                grdClass.ImageList.Images.Add("Model_Opc", Properties.Resources.Model_Opc);
                grdClass.ImageList.Images.Add("Model_Tcp", Properties.Resources.Model_Tcp);
                grdClass.ImageList.Images.Add("ModelVersion", Properties.Resources.ModelVersion);
                grdClass.ImageList.Images.Add("ModelVersion_Secs", Properties.Resources.ModelVersion_Secs);
                grdClass.ImageList.Images.Add("ModelVersion_Plc", Properties.Resources.ModelVersion_Plc);
                grdClass.ImageList.Images.Add("ModelVersion_Opc", Properties.Resources.ModelVersion_Opc);
                grdClass.ImageList.Images.Add("ModelVersion_Tcp", Properties.Resources.ModelVersion_Tcp);
                grdClass.ImageList.Images.Add("Component", Properties.Resources.Component);
                grdClass.ImageList.Images.Add("Component_Secs", Properties.Resources.Component_Secs);
                grdClass.ImageList.Images.Add("Component_Plc", Properties.Resources.Component_Plc);
                grdClass.ImageList.Images.Add("Component_Opc", Properties.Resources.Component_Opc);
                grdClass.ImageList.Images.Add("Component_Tcp", Properties.Resources.Component_Tcp);
                grdClass.ImageList.Images.Add("ComponentVersion", Properties.Resources.ComponentVersion);
                grdClass.ImageList.Images.Add("ComponentVersion_Secs", Properties.Resources.ComponentVersion_Secs);
                grdClass.ImageList.Images.Add("ComponentVersion_Plc", Properties.Resources.ComponentVersion_Plc);
                grdClass.ImageList.Images.Add("ComponentVersion_Opc", Properties.Resources.ComponentVersion_Opc);
                grdClass.ImageList.Images.Add("ComponentVersion_Tcp", Properties.Resources.ComponentVersion_Tcp);
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

        private void designGridOfEap(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEap.dataSource;
                // --
                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Step");
                uds.Band.Columns.Add("Up/Down");
                uds.Band.Columns.Add("Status");
                uds.Band.Columns.Add("Need Action");
                uds.Band.Columns.Add("Next Need Action");
                uds.Band.Columns.Add("Package");
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Component");

                // --

                grdEap.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;
                grdEap.DisplayLayout.Bands[0].Columns["EAP"].Width = 150;
                grdEap.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Server"].Width = 120;
                grdEap.DisplayLayout.Bands[0].Columns["Step"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Up/Down"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Status"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Need Action"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Next Need Action"].Width = 80;
                grdEap.DisplayLayout.Bands[0].Columns["Package"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["Model"].Width = 180;
                grdEap.DisplayLayout.Bands[0].Columns["Component"].Width = 180;

                // --

                grdEap.ImageList = new ImageList();
                // --
                grdEap.ImageList.Images.Add("Eap_Secs_Main_Up", Properties.Resources.Eap_Secs_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Secs_Main_Alarm", Properties.Resources.Eap_Secs_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Secs_Main_Down", Properties.Resources.Eap_Secs_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Secs_Backup_Up", Properties.Resources.Eap_Secs_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Secs_Backup_Alarm", Properties.Resources.Eap_Secs_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Secs_Backup_Down", Properties.Resources.Eap_Secs_Backup_Down);
                grdEap.ImageList.Images.Add("Eap_Plc_Main_Up", Properties.Resources.Eap_Plc_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Plc_Main_Alarm", Properties.Resources.Eap_Plc_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Plc_Main_Down", Properties.Resources.Eap_Plc_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Plc_Backup_Up", Properties.Resources.Eap_Plc_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Plc_Backup_Alarm", Properties.Resources.Eap_Plc_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Plc_Backup_Down", Properties.Resources.Eap_Plc_Backup_Down);
                grdEap.ImageList.Images.Add("Eap_Opc_Main_Up", Properties.Resources.Eap_Opc_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Opc_Main_Alarm", Properties.Resources.Eap_Opc_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Opc_Main_Down", Properties.Resources.Eap_Opc_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Opc_Backup_Up", Properties.Resources.Eap_Opc_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Opc_Backup_Alarm", Properties.Resources.Eap_Opc_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Opc_Backup_Down", Properties.Resources.Eap_Opc_Backup_Down);
                grdEap.ImageList.Images.Add("Eap_Tcp_Main_Up", Properties.Resources.Eap_Tcp_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Tcp_Main_Alarm", Properties.Resources.Eap_Tcp_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Tcp_Main_Down", Properties.Resources.Eap_Tcp_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Tcp_Backup_Up", Properties.Resources.Eap_Tcp_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Tcp_Backup_Alarm", Properties.Resources.Eap_Tcp_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Tcp_Backup_Down", Properties.Resources.Eap_Tcp_Backup_Down);
                grdEap.ImageList.Images.Add("Eap_Process_Main_Up", Properties.Resources.Eap_Process_Main_Up);
                grdEap.ImageList.Images.Add("Eap_Process_Main_Alarm", Properties.Resources.Eap_Process_Main_Alarm);
                grdEap.ImageList.Images.Add("Eap_Process_Main_Down", Properties.Resources.Eap_Process_Main_Down);
                grdEap.ImageList.Images.Add("Eap_Process_Backup_Up", Properties.Resources.Eap_Process_Backup_Up);
                grdEap.ImageList.Images.Add("Eap_Process_Backup_Alarm", Properties.Resources.Eap_Process_Backup_Alarm);
                grdEap.ImageList.Images.Add("Eap_Process_Backup_Down", Properties.Resources.Eap_Process_Backup_Down);                
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

        private void refreshComboOfCategory(
             )
        {
            try
            {
                ucbCategory.beginUpdate(false);
                ucbCategory.removeAllDataRow();

                // --

                foreach (string s in Enum.GetNames(typeof(FEapAttrCategory)))
                {
                    ucbCategory.appendDataRow(s, new object[] { s });
                }

                // --

                ucbCategory.endUpdate(false);

                // --

                ucbCategory.Text = m_fDefaultCategory.ToString();
            }
            catch (Exception ex)
            {
                ucbCategory.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshClassGridOfServer(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            string key = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;

            try
            {
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();
                grdClass.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                grdClass.DisplayLayout.Bands[0].Columns["Server IP"].Hidden = false;
                grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = true;
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.SingleBand;

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapSelector", "ListServer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Server
                            r[1].ToString(),   // Description
                            r[2].ToString()    // Server Ip
                            };
                        key = (string)cellValues[0];
                        index = grdClass.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdClass.Rows.GetRowWithListIndex(index);
                        row.Tag = key;

                        // --

                        cell = row.Cells["Name"];
                        cell.Appearance.Image = FCommon.getImageOfServer(grdClass, r[3].ToString(), r[4].ToString(), r[5].ToString());
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);

                // --

                if (grdClass.Rows.Count > 0)
                {
                    grdClass.ActiveRow = grdClass.Rows[0];
                }

                // --

                grdClass.Focus();
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshClassGridOfPackage(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraDataRow dr = null;
            UltraDataRow cr = null;
            UltraGridCell c = null;
            string newPackage = string.Empty;
            string oldPackage = string.Empty;
            string packageVer = string.Empty;
            string packageType = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;

            try
            {
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();
                grdClass.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                grdClass.DisplayLayout.Bands[0].Columns["Server IP"].Hidden = true;
                grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = false;
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.MultiBand;

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapSelector", "ListPackage", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        newPackage = r[0].ToString();  // Package
                        packageType = r[5].ToString();

                        // --

                        if (newPackage != oldPackage)
                        {
                            cellValues = new object[] {
                                newPackage,      // Eap Package
                                r[1].ToString(), // Package Description
                                null,            // Server IP
                                packageType      // Type
                                };
                            dr = grdClass.appendDataRow(newPackage, cellValues);
                            grdClass.Rows[dr.Index].Tag = newPackage;

                            // --

                            c = grdClass.Rows.GetRowWithListIndex(dr.Index).Cells["Name"];
                            c.Appearance.Image = FCommon.getImageOfPackage(grdClass, packageType);

                            // --

                            oldPackage = newPackage;
                            dr.GetChildRows(0).Clear();
                        }

                        // --

                        packageVer = r[2].ToString();       // Package Version

                        // --

                        if (packageVer != string.Empty)
                        {
                            cellValues = new object[] {
                                string.Format("{0}{1}", packageVer, r[4].ToString() == FYesNo.Yes.ToString() ? "*" : string.Empty),
                                r[3].ToString()  // Package Version Description
                                };
                            cr = dr.GetChildRows(0).Add(cellValues);
                            grdClass.Rows[dr.Index].ChildBands[0].Rows[cr.Index].Tag = packageVer;

                            // --
                                
                            c = grdClass.Rows[dr.Index].ChildBands[0].Rows.GetRowWithListIndex(cr.Index).Cells["Version"];
                            c.Appearance.Image = FCommon.getImageOfPackageVersion(grdClass, packageType);
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);

                // --

                if (grdClass.Rows.Count > 0)
                {
                    grdClass.ActiveRow = grdClass.Rows[0];
                }

                // --

                grdClass.Focus();
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                dr = null;
                cr = null;
                c = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshClassGridOfModel(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraDataRow dr = null;
            UltraDataRow cr = null;
            UltraGridCell c = null;
            string newModel = string.Empty;
            string oldModel = string.Empty;
            string modelVer = string.Empty;
            string modelType = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;

            try
            {
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();
                grdClass.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                grdClass.DisplayLayout.Bands[0].Columns["Server IP"].Hidden = true;
                grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = false;
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.MultiBand;

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapSelector", "ListModel", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        newModel = r[0].ToString();  
                        modelType = r[5].ToString(); 

                        // --

                        if (newModel != oldModel)
                        {
                            cellValues = new object[] {
                                newModel,        // Eap Model
                                r[1].ToString(), // Model Description
                                null,            // Server IP
                                modelType        // Type
                                };
                            dr = grdClass.appendDataRow(newModel, cellValues);
                            grdClass.Rows[dr.Index].Tag = newModel;

                            // --

                            c = grdClass.Rows.GetRowWithListIndex(dr.Index).Cells["Name"];
                            c.Appearance.Image = FCommon.getImageOfModel(grdClass, modelType);

                            // --

                            oldModel = newModel;
                            dr.GetChildRows(0).Clear();
                        }

                        // --

                        modelVer = r[2].ToString();       // Model Version

                        // --

                        if (modelVer != string.Empty)
                        {
                            cellValues = new object[] {
                                modelVer + (r[4].ToString() == FYesNo.Yes.ToString() ? "*" : ""), // Model Version
                                r[3].ToString()                                                   // Model Version Description
                                };
                            cr = dr.GetChildRows(0).Add(cellValues);
                            grdClass.Rows[dr.Index].ChildBands[0].Rows[cr.Index].Tag = modelVer;

                            // --

                            c = grdClass.Rows[dr.Index].ChildBands[0].Rows.GetRowWithListIndex(cr.Index).Cells["Version"];
                            c.Appearance.Image = FCommon.getImageOfModelVersion(grdClass, modelType);
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);

                // --

                if (grdClass.Rows.Count > 0)
                {
                    grdClass.ActiveRow = grdClass.Rows[0];
                }

                // --

                grdClass.Focus();
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                dr = null;
                cr = null;
                c = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshClassGridOfComponent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraDataRow dr = null;
            UltraDataRow cr = null;
            UltraGridCell c = null;
            string newComponent = string.Empty;
            string oldComponent = string.Empty;
            string componentVer = string.Empty;
            string componentType = string.Empty;
            object[] cellValues = null;
            int nextRowNumber = 0;

            try
            {
                grdClass.beginUpdate(false);
                grdClass.removeAllDataRow();
                grdClass.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                grdClass.DisplayLayout.Bands[0].Columns["Server IP"].Hidden = true;
                grdClass.DisplayLayout.Bands[0].Columns["Type"].Hidden = false;
                grdClass.DisplayLayout.ViewStyle = Infragistics.Win.UltraWinGrid.ViewStyle.MultiBand;

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapSelector", "ListComponent", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        newComponent = r[0].ToString(); 
                        componentType = r[5].ToString();

                        // --

                        if (newComponent != oldComponent)
                        {
                             cellValues = new object[] {
                                newComponent,    // Component
                                r[1].ToString(), // Component Description
                                null,            // Server IP
                                componentType    // Type
                                };
                             dr = grdClass.appendDataRow(newComponent, cellValues);
                             grdClass.Rows[dr.Index].Tag = newComponent;

                             // --

                             c = grdClass.Rows.GetRowWithListIndex(dr.Index).Cells["Name"];
                             c.Appearance.Image = FCommon.getImageOfComponent(grdClass, componentType);

                             // --

                             oldComponent = newComponent;
                             dr.GetChildRows(0).Clear();
                        }

                        // --

                        componentVer = r[2].ToString();       // Component Version

                        // --

                        if (componentVer != string.Empty)
                        {
                            cellValues = new object[] {
                                componentVer + (r[4].ToString() == FYesNo.Yes.ToString() ? "*" : string.Empty),
                                r[3].ToString()  // Component Version Description
                                };
                            cr = dr.GetChildRows(0).Add(cellValues);
                            grdClass.Rows[dr.Index].ChildBands[0].Rows[cr.Index].Tag = componentVer;

                            // --

                            c = grdClass.Rows[dr.Index].ChildBands[0].Rows.GetRowWithListIndex(cr.Index).Cells["Version"];
                            c.Appearance.Image = FCommon.getImageOfComponentVersion(grdClass, componentType);
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdClass.endUpdate(false);

                // --

                if (grdClass.Rows.Count > 0)
                {
                    grdClass.ActiveRow = grdClass.Rows[0];
                }

                // --

                grdClass.Focus();
            }
            catch (Exception ex)
            {
                grdClass.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                dr = null;
                cr = null;
                c = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEap(            
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            UltraGridCell cell = null;
            string server = string.Empty;
            string pkg = string.Empty;
            string pkgVer = string.Empty;
            string mdl = string.Empty;
            string mdlVer = string.Empty;
            string com = string.Empty;
            string comVer = string.Empty;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;
            int index = 0;
            string package = string.Empty;
            string model = string.Empty;
            string component = string.Empty;

            try
            {
                btnOk.Enabled = false;

                // --

                if (tabMain.ActiveTab.Key == "Server")
                {
                    server = grdClass.activeDataRowKey;
                }
                else if (tabMain.ActiveTab.Key == "Package")
                {
                    if (grdClass.ActiveRow.ParentRow == null)
                    {
                        pkg = grdClass.activeDataRowKey;
                    }
                    else
                    {
                        pkg = (string)grdClass.ActiveRow.ParentRow.Tag;
                        pkgVer = (string)grdClass.ActiveRow.Tag;
                    }
                }
                else if (tabMain.ActiveTab.Key == "Model")
                {
                    if (grdClass.ActiveRow.ParentRow == null)
                    {
                        mdl = grdClass.activeDataRowKey;
                    }
                    else
                    {
                        mdl = (string)grdClass.ActiveRow.ParentRow.Tag;
                        mdlVer = (string)grdClass.ActiveRow.Tag;
                    }
                }
                else if (tabMain.ActiveTab.Key == "Component")
                {
                    if (grdClass.ActiveRow.ParentRow == null)
                    {
                        com = grdClass.activeDataRowKey;
                    }
                    else
                    {
                        com = (string)grdClass.ActiveRow.ParentRow.Tag;
                        comVer = (string)grdClass.ActiveRow.Tag;
                    }
                }

                // --

                if (
                    server == string.Empty &&
                    pkg == string.Empty &&
                    pkgVer == string.Empty &&
                    mdl == string.Empty &&
                    mdlVer == string.Empty &&
                    com == string.Empty &&
                    comVer == string.Empty
                    )
                {
                    return;
                }

                // --

                grdEap.beginUpdate(false);
                grdEap.removeAllDataRow();
                grdEap.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // fSqlParams.add("eap_type", m_excludeEapType);
                fSqlParams.add("attr_category", ucbCategory.Text);
                fSqlParams.add("server", server == string.Empty ? " " : server);
                // --
                if (pkg == string.Empty && pkgVer == string.Empty)
                {
                    fSqlParams.add("package", " ");
                    fSqlParams.add("pkg_ver", "-1");
                }
                else
                {
                    fSqlParams.add("package", pkg == string.Empty ? " " : pkg);
                    fSqlParams.add("pkg_ver", pkgVer == string.Empty ? "0" : pkgVer);
                }
                // --
                if (mdl == string.Empty && mdlVer == string.Empty)
                {
                    fSqlParams.add("model", " ");
                    fSqlParams.add("mdl_ver", "-1");
                }
                else
                {
                    fSqlParams.add("model", mdl == string.Empty ? " " : mdl);
                    fSqlParams.add("mdl_ver", mdlVer == string.Empty ? "0" : mdlVer);
                }
                // --
                if (com == string.Empty && comVer == string.Empty)
                {
                    fSqlParams.add("component", " ");
                    fSqlParams.add("com_ver", "-1");
                }
                else
                {
                    fSqlParams.add("component", com == string.Empty ? " " : com);
                    fSqlParams.add("com_ver", comVer == string.Empty ? "0" : comVer);
                }                
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapSelector", "ListEap", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        package = FCommon.generateStringForPackage(r[9].ToString(), r[10].ToString());
                        model = FCommon.generateStringForModel(r[11].ToString(), r[12].ToString());
                        component = FCommon.generateStringForComponent(r[13].ToString(), r[14].ToString(), r[15].ToString());

                        // --

                        cellValues = new object[] {
                            r[0].ToString(),   // Eap
                            r[1].ToString(),   // Description
                            r[16].ToString(),  // Type
                            r[2].ToString(),   // Server
                            r[3].ToString(),   // Step
                            r[4].ToString(),   // Up/Down
                            r[5].ToString(),   // Status
                            r[7].ToString(),   // Need Action
                            r[8].ToString(),   // Next Need Action
                            package,           // Package
                            model,             // Model
                            component          // Component
                            };
                        key = (string)cellValues[0];
                        index = grdEap.appendDataRow(key, cellValues).Index;

                        // --

                        row = grdEap.Rows.GetRowWithListIndex(index);

                        // --

                        cell = row.Cells["EAP"];
                        cell.Appearance.Image = FCommon.getImageOfEap(grdEap, r[16].ToString(), r[4].ToString(), r[5].ToString(), r[6].ToString());

                        // --
                        
                        cell = row.Cells["Step"];
                        if (cell.Text != FEapAttrCategory.Applied.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["Up/Down"];
                        if (cell.Text == FUpDown.Down.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                            // --
                            cell = row.Cells["EAP"];
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["Status"];
                        if (cell.Text != FEapStatusEnum.Main.ToString())
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Red;
                        }
                        // --
                        cell = row.Cells["Need Action"];
                        if (cell.Text.Trim() != "")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                        // --
                        cell = row.Cells["Next Need Action"];
                        if (cell.Text.Trim() != "")
                        {
                            cell.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True;
                            cell.Appearance.ForeColor = Color.Blue;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdEap.endUpdate(false);

                // --

                if (grdEap.Rows.Count > 0)
                {
                    grdEap.ActiveRow = grdEap.Rows[0];
                }
            }
            catch (Exception ex)
            {
                grdEap.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
                row = null;
                cell = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void searchGridRow(
            string searchWord
            )
        {
            string[] tempString = null;
            char[] delimiterChars = { ' ', ']' };
            string dataValue = string.Empty;
            int childIndex = 0;

            try
            {

                if (!grdEap.searchGridRow(searchWord))
                {
                    FMessageBox.showInformation("Search", m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { searchWord }), this);
                }

                // --

                switch (tabMain.ActiveTab.Key)
                {
                    case "Server":
                        break;
                    case "Package":
                    case "Model":
                    case "Component":
                        tempString = grdEap.activeDataRow[tabMain.ActiveTab.Key].ToString().Split(delimiterChars);

                        // --

                        foreach (UltraDataRow udr in grdClass.activeDataRow.GetChildRows(0))
                        {
                            dataValue = udr.GetCellValue("Version").ToString();
                            // --
                            if (dataValue.Contains("*"))
                                dataValue = dataValue.Substring(0, dataValue.Length - 1);

                            // --

                            if (dataValue == tempString[tempString.Length - 2]
                                )
                            {
                                grdClass.Rows[grdClass.activeDataRow.Index].ChildBands["Version"].Rows[childIndex].Selected = true;
                            }

                            // --

                            childIndex++;
                        }
                        break;

                    default:
                        break;
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

        #region FEapSelector Form Event Handler

        private void FEapSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designComboOfCategory();
                designGridOfEapClass();
                designGridOfEap();

                // --

                tabMain.SelectedTabChanged += new Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventHandler(tabMain_SelectedTabChanged);
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

        private void FEapSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfCategory();
                refreshClassGridOfServer();
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


        // ***
        // 2012.11.26 by mjkim
        // Escape 키를 사용하여 폼을 닫으려면,
        // 사용하지 않을 버튼을 만들어 CancelButton로 설정하는 것보다 폼의 Key Event를 사용하는 게 현명한 선택.
        // 그리고, Key Event를 사용하려면, 'KeyPreview' Property를 'True'로 설정해야 한다. 
        // ***
        private void FEapSelector_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.Close();
                }
                else if (e.KeyCode == Keys.F5)
                {
                    FCursor.waitCursor();
                    // --
                    if (grdEap.Focused)
                    {
                        refreshGridOfEap();
                    }
                    else
                    {
                        if (tabMain.ActiveTab.Key == "Server")
                        {
                            refreshClassGridOfServer();
                        }
                        else if (tabMain.ActiveTab.Key == "Package")
                        {
                            refreshClassGridOfPackage();
                        }
                        else if (tabMain.ActiveTab.Key == "Model")
                        {
                            refreshClassGridOfModel();
                        }
                        else if (tabMain.ActiveTab.Key == "Component")
                        {
                            refreshClassGridOfComponent();
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

        #region tabMain Control Event Handler

        private void tabMain_SelectedTabChanged(
            object sender, 
            Infragistics.Win.UltraWinTabControl.SelectedTabChangedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (tabMain.ActiveTab.Key == "Server")
                {
                    refreshClassGridOfServer();
                }
                else if (tabMain.ActiveTab.Key == "Package")
                {
                    refreshClassGridOfPackage();
                }
                else if (tabMain.ActiveTab.Key == "Model")
                {
                    refreshClassGridOfModel();
                }
                else if (tabMain.ActiveTab.Key == "Component")
                {
                    refreshClassGridOfComponent();
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

        #region ucbCategory Control Event Handler

        private void ucbCategory_ValueChanged(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEap();
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

        #region grdClass Control Event Handler

        private void grdClass_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEap();
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

        private void grdClass_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdClass.ActiveRow != null)
                {
                    if (grdClass.ActiveRow.ChildBands != null && grdClass.ActiveRow.ChildBands.Count != 0)
                    {
                        grdClass.ActiveRow.Expanded = (grdClass.ActiveRow.Expanded == true) ? false : true;
                    }
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

        #region grdEap Control Event Handler

        private void grdEap_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdEap.activeDataRow == null)
                {
                    return;
                }

                // --

                btnOk.Enabled = true;
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

        private void grdEap_DoubleClickRow(
            object sender, 
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_selectedEapList = grdEap.selectedDataRowKeys;
                m_selectedEapDescList = new string[m_selectedEapList.Length];
                for (int i = 0; i < m_selectedEapList.Length; i++)
                {
                    m_selectedEapDescList[i] = grdEap.getDataRow(m_selectedEapList[i])["Description"].ToString();
                }

                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void grdEap_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Control && e.KeyCode == Keys.A)
                {
                    grdEap.Selected.Rows.AddRange((UltraGridRow[])grdEap.Rows.All);
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

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_selectedEapList = grdEap.selectedDataRowKeys;
                m_selectedEapDescList = new string[m_selectedEapList.Length];
                for (int i = 0; i < m_selectedEapList.Length; i++)
                {
                    m_selectedEapDescList[i] = grdEap.getDataRow(m_selectedEapList[i])["Description"].ToString();
                }
                
                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
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

        #region rstEapToolbar Control Event Handler

        private void rstEapToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                FCursor.waitCursor();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("target", tabMain.ActiveTab.Key);
                fSqlParams.add("eap", "%" + e.searchWord + "%");

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "EapSelector", "SearchEap", fSqlParams, false);
                // --
                if (dt.Rows.Count <= 0)
                {
                    FDebug.throwFException(m_fAdmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }));
                }

                // --

                if (tabMain.ActiveTab.Key == "Server")
                {
                    grdClass.searchGridRow(dt.Rows[0][0].ToString());
                }
                else if (tabMain.ActiveTab.Key == "Package")
                {
                    grdClass.searchGridRow("Name", dt.Rows[0][1].ToString());
                    grdClass.ActiveRow.ExpandAll();
                }
                else if (tabMain.ActiveTab.Key == "Model")
                {
                    grdClass.searchGridRow("Name", dt.Rows[0][2].ToString());
                    grdClass.ActiveRow.ExpandAll();
                }
                else if (tabMain.ActiveTab.Key == "Component")
                {
                    grdClass.searchGridRow("Name", dt.Rows[0][3].ToString());
                    grdClass.ActiveRow.ExpandAll();
                }

                // --

                searchGridRow(e.searchWord);
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
