/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FEap.cs
--  Creator         : spike.lee
--  Create Date     : 2012.04.26
--  Description     : FAMate Admin Manager Setup EAP Form Class 
--  History         : Created by spike.lee at 2012.04.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win;

namespace Nexplant.MC.AdminManager
{
    public partial class FEap : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FEap(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEap(
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

        private string activeEap
        {
            get
            {
                try
                {
                    return grdList.activeDataRowKey;
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

        private string activeType
        {
            get
            {
                try
                {
                    if (grdList.activeDataRow == null)
                    {
                        return string.Empty;
                    }

                    // --

                    return (string)grdList.activeDataRow["Type"];
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
                btnTerminate.Enabled = grdList.activeDataRowKey != string.Empty && m_tranEnabled;
                // --
                btnNewEap.Enabled = m_tranEnabled;
                btnUpdate.Enabled = grdList.activeDataRowKey != string.Empty && m_tranEnabled;
                btnCloneEap.Enabled = grdList.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void designGridOfEap(
            )
        {
            UltraDataSource uds = null;            

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("EAP");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Type");
                uds.Band.Columns.Add("Operation Mode");
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Step");
                uds.Band.Columns.Add("Package");
                uds.Band.Columns.Add("Model");
                uds.Band.Columns.Add("Component");

                // --

                grdList.DisplayLayout.Bands[0].Columns["EAP"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Operation Mode"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Server"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Step"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Package"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Model"].Width = 180;
                grdList.DisplayLayout.Bands[0].Columns["Component"].Width = 180;
                
                // --

                grdList.DisplayLayout.Bands[0].Columns["EAP"].CellAppearance.Image = Properties.Resources.Eap;

                // --

                grdList.DisplayLayout.Bands[0].Columns["EAP"].Header.Fixed = true;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("Eap", Properties.Resources.Eap);
                grdList.ImageList.Images.Add("Eap_Secs", Properties.Resources.Eap_Secs);
                grdList.ImageList.Images.Add("Eap_Plc", Properties.Resources.Eap_Plc);
                grdList.ImageList.Images.Add("Eap_Opc", Properties.Resources.Eap_Opc);
                grdList.ImageList.Images.Add("Eap_Tcp", Properties.Resources.Eap_Tcp);
                grdList.ImageList.Images.Add("Eap_Process", Properties.Resources.Eap_Process);
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

        private void refreshGridOfEap(
            string beforeKey
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;
            string package = string.Empty;
            string model = string.Empty;
            string component = string.Empty;
            int index = 0;

            try
            {
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();

                // --
                
                grdList.beginUpdate(false);
                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("attr_category", FEapAttrCategory.Setup.ToString());
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Eap", "ListEap", fSqlParams, false, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        package = FCommon.generateStringForPackage(r[6].ToString(), r[7].ToString());
                        model = FCommon.generateStringForModel(r[8].ToString(), r[9].ToString());
                        component = FCommon.generateStringForComponent(r[10].ToString(), r[11].ToString(), r[12].ToString());

                        // --

                        cellValues = new object[] {
                            r[0].ToString(), // Eap
                            r[1].ToString(), // Description      
                            r[2].ToString(), // Type
                            r[3].ToString(), // Operation Mode
                            r[4].ToString(), // Server
                            r[5].ToString(), // Step
                            package,         // Package
                            model,           // Model
                            component        // Component
                            };
                        key = (string)cellValues[0];
                        index = grdList.appendDataRow(key, cellValues).Index;
                        // --
                        grdList.Rows.GetRowWithListIndex(index).Cells[0].Appearance.Image = FCommon.getImageOfEap(grdList, r[11].ToString());
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate(false);

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

                // --

                controlButton();

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
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

        private void eapNew(
            )
        {
            FEapTypeSelector fEapTypeSelector = null;
            FSecsEapWizard fSecsEapWizard = null;
            //FPlcEapWizard fPlcEapWizard = null;
            FOpcEapWizard fOpcEapWizard = null;
            FTcpEapWizard fTcpEapWizard = null;
            FFileEapWizard fFileEapWizard = null;
            FChdEapWizard fChdEapWizard = null;
            FProcessEapWizard fProcessEapWizard = null;
            FEapWizardData fEapWizardData = null;
            string key = string.Empty;
            object[] cellValues = null;
            string package = string.Empty;
            string model = string.Empty;
            string component = string.Empty;

            try
            {
                fEapTypeSelector = new FEapTypeSelector(m_fAdmCore);
                if (fEapTypeSelector.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                // --

                if (fEapTypeSelector.fEapType == FEapType.SECS)
                {
                    fSecsEapWizard = new FSecsEapWizard(m_fAdmCore);
                    // --
                    if (fSecsEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    fEapWizardData = fSecsEapWizard.fEapWizardData;
                }
                //else if (fEapTypeSelector.fEapType == FEapType.PLC)
                //{
                //    fPlcEapWizard = new FPlcEapWizard(m_fAdmCore);
                //    // --
                //    if (fPlcEapWizard.ShowDialog() == DialogResult.Cancel)
                //    {
                //        return;
                //    }
                //    fEapWizardData = fPlcEapWizard.fEapWizardData;
                //}
                else if (fEapTypeSelector.fEapType == FEapType.OPC)
                {
                    fOpcEapWizard = new FOpcEapWizard(m_fAdmCore);
                    // --
                    if (fOpcEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    fEapWizardData = fOpcEapWizard.fEapWizardData;                    
                }
                else if (fEapTypeSelector.fEapType == FEapType.TCP)
                {
                    fTcpEapWizard = new FTcpEapWizard(m_fAdmCore);
                    // --
                    if (fTcpEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    fEapWizardData = fTcpEapWizard.fEapWizardData;
                }
                else if (fEapTypeSelector.fEapType == FEapType.CHD)
                {
                    fChdEapWizard = new FChdEapWizard(m_fAdmCore);
                    // --
                    if (fChdEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    fEapWizardData = fChdEapWizard.fEapWizardData;
                }
                else if (fEapTypeSelector.fEapType == FEapType.Process)
                {
                    fProcessEapWizard = new FProcessEapWizard(m_fAdmCore);
                    // --
                    if (fProcessEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    fEapWizardData = fProcessEapWizard.fEapWizardData;
                }
                else if (fEapTypeSelector.fEapType == FEapType.FILE)
                {
                    fFileEapWizard = new FFileEapWizard(m_fAdmCore);
                    // --
                    if (fFileEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    fEapWizardData = fFileEapWizard.fEapWizardData;
                }
                else
                {
                    return;
                }

                // --                

                package = FCommon.generateStringForPackage(fEapWizardData.package, fEapWizardData.packageVer);
                model = FCommon.generateStringForModel(fEapWizardData.model, fEapWizardData.modelVer);
                // --
                if (fEapTypeSelector.fEapType == FEapType.Process)
                {
                    component = FCommon.generateStringForComponent(string.Empty, fEapWizardData.component, fEapWizardData.componentVer);
                }
                else
                {
                    component = FCommon.generateStringForComponent(fEapWizardData.usedComponent.ToString(), fEapWizardData.component, fEapWizardData.componentVer);
                }                

                // --

                cellValues = new object[]
                {
                    fEapWizardData.eap,
                    fEapWizardData.description,
                    fEapWizardData.fEapType.ToString(),
                    fEapWizardData.fOperMode,
                    fEapWizardData.server,
                    fEapWizardData.step,
                    package,
                    model,
                    component
                };

                // --

                key = fEapWizardData.eap;
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
                if (fEapTypeSelector != null)
                {
                    fEapTypeSelector.Dispose();
                    fEapTypeSelector = null;
                }
                if (fSecsEapWizard != null)
                {
                    fSecsEapWizard.Dispose();
                    fSecsEapWizard = null;
                }
                //if (fPlcEapWizard != null)
                //{
                //    fPlcEapWizard.Dispose();
                //    fPlcEapWizard = null;
                //}
                if (fOpcEapWizard != null)
                {
                    fOpcEapWizard.Dispose();
                    fOpcEapWizard = null;
                }
                if (fTcpEapWizard != null)
                {
                    fTcpEapWizard.Dispose();
                    fTcpEapWizard = null;
                }
                if (fChdEapWizard != null)
                {
                    fChdEapWizard.Dispose();
                    fChdEapWizard = null;
                }
                if (fProcessEapWizard != null)
                {
                    fProcessEapWizard.Dispose();
                    fProcessEapWizard = null;
                }
                if (fFileEapWizard != null)
                {
                    fFileEapWizard.Dispose();
                    fFileEapWizard = null;
                }
                fEapWizardData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void eapUpdate(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow r = null;
            FSecsEapWizard fSecsEapWizard = null;
            //FPlcEapWizard fPlcEapWizard = null;
            FOpcEapWizard fOpcEapWizard = null;
            FTcpEapWizard fTcpEapWizard = null;
            FFileEapWizard fFileEapWizard = null;
            FChdEapWizard fChdEapWizard = null;
            FProcessEapWizard fProcessEapWizard = null;
            FEapWizardData fEapWizardData = null;
            string key = string.Empty;
            object[] cellValues = null;
            string package = string.Empty;
            string model = string.Empty;
            string component = string.Empty;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eap", this.activeEap);
                fSqlParams.add("attr_category", FEapAttrCategory.Setup.ToString());

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Eap", "SearchEap", fSqlParams, true);
                r = dt.Rows[0];

                // --

                fEapWizardData = new FEapWizardData();
                // --
                fEapWizardData.eap = r[0].ToString();
                fEapWizardData.description = r[1].ToString();
                fEapWizardData.fEapType = (FEapType)Enum.Parse(typeof(FEapType), r[2].ToString());
                fEapWizardData.fOperMode = (FEapOperationMode)Enum.Parse(typeof(FEapOperationMode), r[3].ToString());
                fEapWizardData.server = r[4].ToString();
                fEapWizardData.step = r[5].ToString();
                fEapWizardData.package = r[6].ToString();
                fEapWizardData.packageVer = r[7].ToString();
                fEapWizardData.model = r[8].ToString();
                fEapWizardData.modelVer = r[9].ToString();
                fEapWizardData.usedComponent = (r[10].ToString() == FYesNo.Yes.ToString() ? FYesNo.Yes : FYesNo.No);
                fEapWizardData.component = r[11].ToString();
                fEapWizardData.componentVer = r[12].ToString();
                fEapWizardData.wizardMode = FEapWizardMode.Update;

                // --

                if (fEapWizardData.fEapType == FEapType.SECS)
                {
                    fSecsEapWizard = new FSecsEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fSecsEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fSecsEapWizard.fEapWizardData;
                }
                //else if (fEapWizardData.fEapType == FEapType.PLC)
                //{
                //    fPlcEapWizard = new FPlcEapWizard(m_fAdmCore, fEapWizardData);
                //    // --
                //    if (fPlcEapWizard.ShowDialog() == DialogResult.Cancel)
                //    {
                //        return;
                //    }
                //    // --
                //    fEapWizardData = fPlcEapWizard.fEapWizardData;
                //}
                else if (fEapWizardData.fEapType == FEapType.OPC)
                {
                    fOpcEapWizard = new FOpcEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fOpcEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fOpcEapWizard.fEapWizardData;
                }
                else if (fEapWizardData.fEapType == FEapType.TCP)
                {
                    fTcpEapWizard = new FTcpEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fTcpEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fTcpEapWizard.fEapWizardData;
                }
                else if (fEapWizardData.fEapType == FEapType.CHD)
                {
                    fChdEapWizard = new FChdEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fChdEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fChdEapWizard.fEapWizardData;
                }
                else if (fEapWizardData.fEapType == FEapType.Process)
                {
                    fProcessEapWizard = new FProcessEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fProcessEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fProcessEapWizard.fEapWizardData;
                }
                else if (fEapWizardData.fEapType == FEapType.FILE)
                {
                    fFileEapWizard = new FFileEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fFileEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fFileEapWizard.fEapWizardData;
                }
                else
                {
                    return;
                }
                
                // --

                package = FCommon.generateStringForPackage(fEapWizardData.package, fEapWizardData.packageVer);
                model = FCommon.generateStringForModel(fEapWizardData.model, fEapWizardData.modelVer);
                // --
                if (fEapWizardData.fEapType == FEapType.Process)
                {
                    component = FCommon.generateStringForComponent(string.Empty, fEapWizardData.component, fEapWizardData.componentVer);
                }
                else
                {
                    component = FCommon.generateStringForComponent(fEapWizardData.usedComponent.ToString(), fEapWizardData.component, fEapWizardData.componentVer);
                }  

                // --

                cellValues = new object[]
                {
                    fEapWizardData.eap,
                    fEapWizardData.description,
                    fEapWizardData.fEapType.ToString(),
                    fEapWizardData.fOperMode,
                    fEapWizardData.server,
                    fEapWizardData.step,
                    package,
                    model,
                    component
                };

                // --

                key = fEapWizardData.eap;
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
                if (fSecsEapWizard != null)
                {
                    fSecsEapWizard.Dispose();
                    fSecsEapWizard = null;
                }
                //if (fPlcEapWizard != null)
                //{
                //    fPlcEapWizard.Dispose();
                //    fPlcEapWizard = null;
                //}
                if (fOpcEapWizard != null)
                {
                    fOpcEapWizard.Dispose();
                    fOpcEapWizard = null;
                }
                if (fTcpEapWizard != null)
                {
                    fTcpEapWizard.Dispose();
                    fTcpEapWizard = null;
                }
                if (fChdEapWizard != null)
                {
                    fChdEapWizard.Dispose();
                    fChdEapWizard = null;
                }
                if (fProcessEapWizard != null)
                {
                    fProcessEapWizard.Dispose();
                    fProcessEapWizard = null;
                }
                if (fFileEapWizard != null)
                {
                    fFileEapWizard.Dispose();
                    fFileEapWizard = null;
                }

                // --

                fSqlParams = null;
                dt = null;
                r = null;
                fEapWizardData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void eapClone(
            string eapName
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            DataRow r = null;
            FSecsEapWizard fSecsEapWizard = null;
            //FPlcEapWizard fPlcEapWizard = null;
            FOpcEapWizard fOpcEapWizard = null;
            FTcpEapWizard fTcpEapWizard = null;
            FFileEapWizard fFileEapWizard = null;
            FChdEapWizard fChdEapWizard = null;
            FProcessEapWizard fProcessEapWizard = null;
            FEapWizardData fEapWizardData = null;
            string key = string.Empty;
            object[] cellValues = null;
            string package = string.Empty;
            string model = string.Empty;
            string component = string.Empty;

            try
            {
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("eap", eapName);
                fSqlParams.add("attr_category", FEapAttrCategory.Setup.ToString());

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "Eap", "SearchEap", fSqlParams, true);
                r = dt.Rows[0];

                // --

                fEapWizardData = new FEapWizardData();
                // --
                fEapWizardData.eap = r[0].ToString();
                fEapWizardData.description = string.Empty;
                fEapWizardData.fEapType = (FEapType)Enum.Parse(typeof(FEapType), r[2].ToString());
                fEapWizardData.fOperMode = (FEapOperationMode)Enum.Parse(typeof(FEapOperationMode), r[3].ToString());
                fEapWizardData.server = r[4].ToString();
                fEapWizardData.step = r[5].ToString();
                fEapWizardData.package = r[6].ToString();
                fEapWizardData.packageVer = r[7].ToString();
                fEapWizardData.model = r[8].ToString();
                fEapWizardData.modelVer = r[9].ToString();
                fEapWizardData.usedComponent = (r[10].ToString() == FYesNo.Yes.ToString() ? FYesNo.Yes : FYesNo.No);
                fEapWizardData.component = r[11].ToString();
                fEapWizardData.componentVer = r[12].ToString();
                fEapWizardData.wizardMode = FEapWizardMode.Clone;

                // --

                if (fEapWizardData.fEapType == FEapType.SECS)
                {
                    fSecsEapWizard = new FSecsEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fSecsEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fSecsEapWizard.fEapWizardData;
                }
                //else if (fEapWizardData.fEapType == FEapType.PLC)
                //{
                //    fPlcEapWizard = new FPlcEapWizard(m_fAdmCore, fEapWizardData);
                //    // --
                //    if (fPlcEapWizard.ShowDialog() == DialogResult.Cancel)
                //    {
                //        return;
                //    }
                //    // --
                //    fEapWizardData = fPlcEapWizard.fEapWizardData;
                //}
                else if (fEapWizardData.fEapType == FEapType.OPC)
                {
                    fOpcEapWizard = new FOpcEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fOpcEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fOpcEapWizard.fEapWizardData;
                }
                else if (fEapWizardData.fEapType == FEapType.TCP)
                {
                    fTcpEapWizard = new FTcpEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fTcpEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fTcpEapWizard.fEapWizardData;
                }
                else if (fEapWizardData.fEapType == FEapType.CHD)
                {
                    fChdEapWizard = new FChdEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fChdEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fChdEapWizard.fEapWizardData;
                }
                else if (fEapWizardData.fEapType == FEapType.Process)
                {
                    fProcessEapWizard = new FProcessEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fProcessEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fProcessEapWizard.fEapWizardData;
                }
                else if (fEapWizardData.fEapType == FEapType.FILE)
                {
                    fFileEapWizard = new FFileEapWizard(m_fAdmCore, fEapWizardData);
                    // --
                    if (fFileEapWizard.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    // --
                    fEapWizardData = fFileEapWizard.fEapWizardData;
                }
                else
                {
                    return;
                }

                // --

                package = FCommon.generateStringForPackage(fEapWizardData.package, fEapWizardData.packageVer);
                model = FCommon.generateStringForModel(fEapWizardData.model, fEapWizardData.modelVer);
                // --
                if (fEapWizardData.fEapType == FEapType.Process)
                {
                    component = FCommon.generateStringForComponent(string.Empty, fEapWizardData.component, fEapWizardData.componentVer);
                }
                else
                {
                    component = FCommon.generateStringForComponent(fEapWizardData.usedComponent.ToString(), fEapWizardData.component, fEapWizardData.componentVer);
                }      

                // --

                cellValues = new object[]
                {
                    fEapWizardData.eap,
                    fEapWizardData.description,
                    fEapWizardData.fEapType.ToString(),
                    fEapWizardData.fOperMode,
                    fEapWizardData.server,
                    fEapWizardData.step,
                    package,
                    model,
                    component
                };

                // --

                key = fEapWizardData.eap;
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
                if (fSecsEapWizard != null)
                {
                    fSecsEapWizard.Dispose();
                    fSecsEapWizard = null;
                }
                //if (fPlcEapWizard != null)
                //{
                //    fPlcEapWizard.Dispose();
                //    fPlcEapWizard = null;
                //}
                if (fOpcEapWizard != null)
                {
                    fOpcEapWizard.Dispose();
                    fOpcEapWizard = null;
                }
                if (fTcpEapWizard != null)
                {
                    fTcpEapWizard.Dispose();
                    fTcpEapWizard = null;
                }
                if (fChdEapWizard != null)
                {
                    fChdEapWizard.Dispose();
                    fChdEapWizard = null;
                }
                if (fProcessEapWizard != null)
                {
                    fProcessEapWizard.Dispose();
                    fProcessEapWizard = null;
                }
                if (fFileEapWizard != null)
                {
                    fFileEapWizard.Dispose();
                    fFileEapWizard = null;
                }

                // --

                fSqlParams = null;
                dt = null;
                r = null;
                fEapWizardData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void eapDelete(
            Dictionary<string, string> eapList
            )
        {
            string eapType = string.Empty;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeOut = null;
            
            try
            {   
                grdList.beginUpdate();                

                // --

                foreach (string eap in eapList.Keys)
                {
                    eapType = eapList[eap];
                    // --
                    if (eapType == FEapType.Process.ToString())
                    {
                        fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetProcessEapUpdate_In.E_ADMADS_SetProcessEapUpdate_In);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hLanguage, FADMADS_SetProcessEapUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hFactory, FADMADS_SetProcessEapUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hUserId, FADMADS_SetProcessEapUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hHostIp, FADMADS_SetProcessEapUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hHostName, FADMADS_SetProcessEapUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hStep, FADMADS_SetProcessEapUpdate_In.D_hStep, "3");

                        // --

                        fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_SetProcessEapUpdate_In.FEap.E_Eap);
                        // -
                        fXmlNodeInEap.set_elemVal(
                            FADMADS_SetProcessEapUpdate_In.FEap.A_Name,
                            FADMADS_SetProcessEapUpdate_In.FEap.D_Name,
                            eap
                            );

                        // --

                        FADMADSCaster.ADMADS_SetProcessEapUpdate_Req(
                            m_fAdmCore.fH101,
                            fXmlNodeIn,
                            ref fXmlNodeOut
                            );
                        if (fXmlNodeOut.get_elemVal(FADMADS_SetProcessEapUpdate_Out.A_hStatus, FADMADS_SetProcessEapUpdate_Out.D_hStatus) != "0")
                        {
                            FDebug.throwFException(
                                fXmlNodeOut.get_elemVal(FADMADS_SetProcessEapUpdate_Out.A_hStatusMessage, FADMADS_SetProcessEapUpdate_Out.D_hStatusMessage)
                                );
                        }
                    }
                    else
                    {
                        fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEapUpdate_In.E_ADMADS_SetEapUpdate_In);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hLanguage, FADMADS_SetEapUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hFactory, FADMADS_SetEapUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hUserId, FADMADS_SetEapUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostIp, FADMADS_SetEapUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostName, FADMADS_SetEapUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hStep, FADMADS_SetEapUpdate_In.D_hStep, "3");

                        // --

                        fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_SetEapUpdate_In.FEap.E_Eap);
                        // -
                        fXmlNodeInEap.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.A_Name,
                            FADMADS_SetEapUpdate_In.FEap.D_Name,
                            eap
                            );

                        // --

                        FADMADSCaster.ADMADS_SetEapUpdate_Req(
                            m_fAdmCore.fH101,
                            fXmlNodeIn,
                            ref fXmlNodeOut
                            );
                        if (fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatus, FADMADS_SetEapUpdate_Out.D_hStatus) != "0")
                        {
                            FDebug.throwFException(
                                fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatusMessage, FADMADS_SetEapUpdate_Out.D_hStatusMessage)
                                );
                        }
                    }
                    
                    // --

                    if (grdList.getDataRowIndex(eap) >= 0)
                    {
                        grdList.removeDataRow(eap);
                    }
                }

                // --

                grdList.endUpdate();

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
                fXmlNodeInEap = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void eapTerminate(
           Dictionary<string, string> eapList
            )
        {
            string eapType = string.Empty;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEap = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                grdList.beginUpdate();

                // --

                foreach (string eap in eapList.Keys)
                {
                    eapType = eapList[eap];
                    // --
                    if (eapType == FEapType.Process.ToString())
                    {
                        fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetProcessEapUpdate_In.E_ADMADS_SetProcessEapUpdate_In);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hLanguage, FADMADS_SetProcessEapUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hFactory, FADMADS_SetProcessEapUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hUserId, FADMADS_SetProcessEapUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hHostIp, FADMADS_SetProcessEapUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hHostName, FADMADS_SetProcessEapUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                        fXmlNodeIn.set_elemVal(FADMADS_SetProcessEapUpdate_In.A_hStep, FADMADS_SetProcessEapUpdate_In.D_hStep, "4");

                        // --

                        fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_SetProcessEapUpdate_In.FEap.E_Eap);
                        // -
                        fXmlNodeInEap.set_elemVal(
                            FADMADS_SetProcessEapUpdate_In.FEap.A_Name,
                            FADMADS_SetProcessEapUpdate_In.FEap.D_Name,
                            eap
                            );

                        // --

                        FADMADSCaster.ADMADS_SetProcessEapUpdate_Req(
                            m_fAdmCore.fH101,
                            fXmlNodeIn,
                            ref fXmlNodeOut
                            );
                        if (fXmlNodeOut.get_elemVal(FADMADS_SetProcessEapUpdate_Out.A_hStatus, FADMADS_SetProcessEapUpdate_Out.D_hStatus) != "0")
                        {
                            FDebug.throwFException(
                                fXmlNodeOut.get_elemVal(FADMADS_SetProcessEapUpdate_Out.A_hStatusMessage, FADMADS_SetProcessEapUpdate_Out.D_hStatusMessage)
                                );
                        }
                    }
                    else
                    {
                        fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetEapUpdate_In.E_ADMADS_SetEapUpdate_In);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hLanguage, FADMADS_SetEapUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hFactory, FADMADS_SetEapUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hUserId, FADMADS_SetEapUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostIp, FADMADS_SetEapUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hHostName, FADMADS_SetEapUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                        fXmlNodeIn.set_elemVal(FADMADS_SetEapUpdate_In.A_hStep, FADMADS_SetEapUpdate_In.D_hStep, "4");

                        // --

                        fXmlNodeInEap = fXmlNodeIn.set_elem(FADMADS_SetEapUpdate_In.FEap.E_Eap);
                        // -
                        fXmlNodeInEap.set_elemVal(
                            FADMADS_SetEapUpdate_In.FEap.A_Name,
                            FADMADS_SetEapUpdate_In.FEap.D_Name,
                            eap
                            );

                        // --

                        FADMADSCaster.ADMADS_SetEapUpdate_Req(
                            m_fAdmCore.fH101,
                            fXmlNodeIn,
                            ref fXmlNodeOut
                            );
                        if (fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatus, FADMADS_SetEapUpdate_Out.D_hStatus) != "0")
                        {
                            FDebug.throwFException(
                                fXmlNodeOut.get_elemVal(FADMADS_SetEapUpdate_Out.A_hStatusMessage, FADMADS_SetEapUpdate_Out.D_hStatusMessage)
                                );
                        }
                    }

                    // --

                    if (grdList.getDataRowIndex(eap) >= 0)
                    {
                        grdList.removeDataRow(eap);
                    }
                }

                // --

                grdList.endUpdate();

                // --

                refreshTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEap = null;
                fXmlNodeOut = null;
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

        //------------------------------------------------------------------------------------------------------------------------

        #region MC Popup Menu

        private void procMenuEapStatus(
            )
        {
            FEapStatus fEapStatus = null;

            try
            {
                fEapStatus = (FEapStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FEapStatus));
                if (fEapStatus == null)
                {
                    fEapStatus = new FEapStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapStatus);
                }
                fEapStatus.activate();
                fEapStatus.attach(this.activeEap, this.activeType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapHistory(
            )
        {
            FEapHistory fEapHistory = null;

            try
            {
                fEapHistory = (FEapHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEapHistory));
                if (fEapHistory == null)
                {
                    fEapHistory = new FEapHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapHistory);
                }
                fEapHistory.activate();
                fEapHistory.attach(this.activeEap);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapHistory = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapRepositoryStatus(
            )
        {
            FEapRepositoryStatus fEapRepositoryStatus = null;

            try
            {
                fEapRepositoryStatus = (FEapRepositoryStatus)m_fAdmCore.fAdmContainer.getChild(typeof(FEapRepositoryStatus));
                if (fEapRepositoryStatus == null)
                {
                    fEapRepositoryStatus = new FEapRepositoryStatus(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapRepositoryStatus);
                }
                fEapRepositoryStatus.activate();
                fEapRepositoryStatus.attach(this.activeEap, this.activeType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapRepositoryStatus = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapResourceHistory(
            )
        {
            FEapResourceHistory fEapResourceHistory = null;

            try
            {
                fEapResourceHistory = (FEapResourceHistory)m_fAdmCore.fAdmContainer.getChild(typeof(FEapResourceHistory));
                if (fEapResourceHistory == null)
                {
                    fEapResourceHistory = new FEapResourceHistory(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapResourceHistory);
                }
                fEapResourceHistory.activate();
                fEapResourceHistory.attach(grdList.activeDataRowKey);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapResourceHistory = null;
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapRelease(
            )
        {
            FEapRelease fEapRelease = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {
                fEapRelease = (FEapRelease)m_fAdmCore.fAdmContainer.getChild(typeof(FEapRelease));
                if (fEapRelease == null)
                {
                    fEapRelease = new FEapRelease(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapRelease);
                }
                fEapRelease.activate();

                // --

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapRelease.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapRelease = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapReload(
            )
        {
            FEapReload fEapReload = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {
                fEapReload = (FEapReload)m_fAdmCore.fAdmContainer.getChild(typeof(FEapReload));
                if (fEapReload == null)
                {
                    fEapReload = new FEapReload(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapReload);
                }
                fEapReload.activate();

                // --

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapReload.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapReload = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapRestart(
            )
        {
            FEapRestart fEapRestart = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {   
                fEapRestart = (FEapRestart)m_fAdmCore.fAdmContainer.getChild(typeof(FEapRestart));
                if (fEapRestart == null)
                {
                    fEapRestart = new FEapRestart(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapRestart);
                }
                fEapRestart.activate();

                // --

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapRestart.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapRestart = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapStart(
            )
        {
            FEapStart fEapStart = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {
                fEapStart = (FEapStart)m_fAdmCore.fAdmContainer.getChild(typeof(FEapStart));
                if (fEapStart == null)
                {
                    fEapStart = new FEapStart(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapStart);
                }
                fEapStart.activate();

                // --

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapStart.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapStart = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapStop(
            )
        {
            FEapStop fEapStop = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {   
                fEapStop = (FEapStop)m_fAdmCore.fAdmContainer.getChild(typeof(FEapStop));
                if (fEapStop == null)
                {
                    fEapStop = new FEapStop(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapStop);
                }
                fEapStop.activate();

                // --

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapStop.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapStop = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapAbort(
            )
        {
            FEapAbort fEapAbort = null;
            string[] eapList = null;
            string[] eapDescList = null;

            try
            {
                fEapAbort = (FEapAbort)m_fAdmCore.fAdmContainer.getChild(typeof(FEapAbort));
                if (fEapAbort == null)
                {
                    fEapAbort = new FEapAbort(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapAbort);
                }
                fEapAbort.activate();

                // --

                eapList = grdList.selectedDataRowKeys;
                eapDescList = new string[eapList.Length];
                // --
                for (int i = 0; i < eapList.Length; i++)
                {
                    eapDescList[i] = grdList.getDataRow(eapList[i])["Description"].ToString();
                }
                // --
                fEapAbort.attach(eapList, eapDescList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapAbort = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapMove(
            )
        {
            FEapMove fEapMove = null;

            try
            {
                fEapMove = (FEapMove)m_fAdmCore.fAdmContainer.getChild(typeof(FEapMove));
                if (fEapMove == null)
                {
                    fEapMove = new FEapMove(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapMove);
                }
                fEapMove.activate();
                fEapMove.attach(grdList.selectedDataRowKeys);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapMove = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapLogList(
            )
        {
            FEapLogList fEapLogList = null;

            try
            {
                fEapLogList = (FEapLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapLogList));
                if (fEapLogList == null)
                {
                    fEapLogList = new FEapLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapLogList);
                }
                fEapLogList.activate();
                fEapLogList.attach(this.activeEap, this.activeType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapBackupLogList(
            )
        {
            FEapBackupLogList fEapBackupLogList = null;

            try
            {
                fEapBackupLogList = (FEapBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapBackupLogList));
                if (fEapBackupLogList == null)
                {
                    fEapBackupLogList = new FEapBackupLogList(m_fAdmCore);
                    m_fAdmCore.fAdmContainer.showChild(fEapBackupLogList);
                }
                fEapBackupLogList.activate();
                fEapBackupLogList.attach(this.activeEap, this.activeType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEapBackupLogList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        //private void procMenuEapInterfaceLogList(
        //   )
        //{
        //    FEapInterfaceLogList fEapLogList = null;

        //    try
        //    {
        //        fEapLogList = (FEapInterfaceLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapInterfaceLogList));
        //        if (fEapLogList == null)
        //        {
        //            fEapLogList = new FEapInterfaceLogList(m_fAdmCore);
        //            m_fAdmCore.fAdmContainer.showChild(fEapLogList);
        //        }
        //        fEapLogList.activate();
        //        fEapLogList.attach(this.activeEap, this.activeType);
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fEapLogList = null;
        //    }
        //}

        ////------------------------------------------------------------------------------------------------------------------------

        //private void procMenuEapInterfaceBackupLogList(
        //    )
        //{
        //    FEapInterfaceBackupLogList fEapBackupLogList = null;

        //    try
        //    {
        //        fEapBackupLogList = (FEapInterfaceBackupLogList)m_fAdmCore.fAdmContainer.getChild(typeof(FEapInterfaceBackupLogList));
        //        if (fEapBackupLogList == null)
        //        {
        //            fEapBackupLogList = new FEapInterfaceBackupLogList(m_fAdmCore);
        //            m_fAdmCore.fAdmContainer.showChild(fEapBackupLogList);
        //        }
        //        fEapBackupLogList.activate();
        //        fEapBackupLogList.attach(this.activeEap, this.activeType);
        //    }
        //    catch (Exception ex)
        //    {
        //        FDebug.throwException(ex);
        //    }
        //    finally
        //    {
        //        fEapBackupLogList = null;
        //    }
        //}

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuEapReferenceSheet(
            )
        {
            FEapReferenceSheet fReferenceSheet = null;

            try
            {
                foreach (FBaseTabChildForm f in m_fAdmCore.fAdmContainer.fChilds)
                {
                    if (
                        f is FEapReferenceSheet &&
                        ((FEapReferenceSheet)f).eapName == this.activeEap
                        )
                    {
                        fReferenceSheet = (FEapReferenceSheet)f;
                        fReferenceSheet.refresh();
                        fReferenceSheet.activate();
                        return;
                    }
                }
                // --
                fReferenceSheet = new FEapReferenceSheet(m_fAdmCore, this.activeEap);
                m_fAdmCore.fAdmContainer.showChild(fReferenceSheet);
                fReferenceSheet.activate();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fReferenceSheet = null;
            }
        }

        #endregion

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FEap Form Event Handler

        private void FEap_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.Eap);

                // --

                designGridOfEap();

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

        private void FEap_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEap(string.Empty);

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

        private void FEap_FormClosing(
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

        private void FEap_KeyDown(
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
                    refreshGridOfEap(grdList.activeDataRowKey);
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

        private void grdList_MouseDown(
            object sender, 
            MouseEventArgs e
            )
        {
            UltraGridRow r = null;
            string eapType = string.Empty;
            string operMode = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (e.Button != MouseButtons.Right || grdList.Rows.Count == 0)
                {
                    return;
                }

                // --

                r = (UltraGridRow)grdList.DisplayLayout.UIElement.ElementFromPoint(new Point(e.X, e.Y)).
                    GetContext(typeof(UltraGridRow));
                if (r != null)
                {
                    grdList.ActiveRow = grdList.Rows[r.Index];
                }

                // --

                eapType = grdList.activeDataRow["Type"].ToString();
                operMode = grdList.activeDataRow["Operation Mode"].ToString();

                // --

                mnuMenu.Tools[FMenuKey.MenuSetEapStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStatus);
                mnuMenu.Tools[FMenuKey.MenuSetEapHistory].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapHistory);
                // --
                mnuMenu.Tools[FMenuKey.MenuSetEapRepositoryStatus].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRepositoryStatus) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuSetEapRelease].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRelease);
                mnuMenu.Tools[FMenuKey.MenuSetEapStart].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStart);
                mnuMenu.Tools[FMenuKey.MenuSetEapStop].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapStop);
                mnuMenu.Tools[FMenuKey.MenuSetEapReload].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReload);
                mnuMenu.Tools[FMenuKey.MenuSetEapRestart].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapRestart);
                mnuMenu.Tools[FMenuKey.MenuSetEapAbort].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapAbort);
                mnuMenu.Tools[FMenuKey.MenuSetEapMove].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapMove);
                // --
                mnuMenu.Tools[FMenuKey.MenuSetEapLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapLogList);
                mnuMenu.Tools[FMenuKey.MenuSetEapBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapBackupLogList);
                // --
                //mnuMenu.Tools[FMenuKey.MenuSetEapInterfaceLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceLogList) ? true : false;
                //mnuMenu.Tools[FMenuKey.MenuSetEapInterfaceBackupLogList].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapInterfaceBackupLogList) ? true : false;
                // --
                mnuMenu.Tools[FMenuKey.MenuSetEapReferenceSheet].SharedProps.Enabled = FCommon.hasFunctionAuthority(m_fAdmCore, FUserFunction.EapReferenceSheet);

                // --

                #region Menu Control

                if (eapType == FEapType.Process.ToString())
                {
                    mnuMenu.Tools[FMenuKey.MenuSetEapRelease].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapStart].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapStop].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapReload].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapRestart].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapAbort].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuInqEapLogList].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuInqEapBackupLogList].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceLogList].SharedProps.Enabled = false;
                    mnuMenu.Tools[FMenuKey.MenuInqEapInterfaceBackupLogList].SharedProps.Enabled = false;
                    // --
                    mnuMenu.Tools[FMenuKey.MenuSetEapReferenceSheet].SharedProps.Enabled = false;
                }
                else if (operMode == FEapOperationMode.Client.ToString())
                {
                    mnuMenu.Tools[FMenuKey.MenuSetEapStart].SharedProps.Enabled = false;
                }
                else if (eapType == FEapType.FILE.ToString())
                {
                    mnuMenu.Tools[FMenuKey.MenuSetEapInterfaceLogList].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapInterfaceBackupLogList].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapRepositoryStatus].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapReferenceSheet].SharedProps.Visible = false;
                }
                else if (
                         eapType == FEapType.OPC.ToString() || 
                         eapType == FEapType.SECS.ToString() || 
                         eapType == FEapType.TCP.ToString()
                        )
                {
                    mnuMenu.Tools[FMenuKey.MenuSetEapInterfaceLogList].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapInterfaceBackupLogList].SharedProps.Visible = false;
                    mnuMenu.Tools[FMenuKey.MenuSetEapRepositoryStatus].SharedProps.Visible = true;
                    mnuMenu.Tools[FMenuKey.MenuSetEapReferenceSheet].SharedProps.Visible = true;
                }

                #endregion

                // --

                mnuMenu.ShowPopup(FMenuKey.MenuSetEapPopupMenu);
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

                if (e.Tool.Key == FMenuKey.MenuSetEapStatus)
                {
                    procMenuEapStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapHistory)
                {
                    procMenuEapHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapRepositoryStatus)
                {
                    procMenuEapRepositoryStatus();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapResourceHistory)
                {
                    procMenuEapResourceHistory();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapRelease)
                {
                    procMenuEapRelease();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapStart)
                {
                    procMenuEapStart();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapStop)
                {
                    procMenuEapStop();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapReload)
                {
                    procMenuEapReload();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapRestart)
                {
                    procMenuEapRestart();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapAbort)
                {
                    procMenuEapAbort();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapMove)
                {
                    procMenuEapMove();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapLogList)
                {
                    procMenuEapLogList();
                }
                else if (e.Tool.Key == FMenuKey.MenuSetEapBackupLogList)
                {
                    procMenuEapBackupLogList();
                }
                //else if (e.Tool.Key == FMenuKey.MenuSetEapInterfaceLogList)
                //{
                //    procMenuEapInterfaceLogList();
                //}
                //else if (e.Tool.Key == FMenuKey.MenuSetEapInterfaceBackupLogList)
                //{
                //    procMenuEapInterfaceBackupLogList();
                //}
                else if (e.Tool.Key == FMenuKey.MenuSetEapReferenceSheet)
                {
                    procMenuEapReferenceSheet();
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

        #region btnNewEap Control Event Handler

        private void btnNewEap_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                // --
                eapNew();
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
            string eap = string.Empty;
            string eapType = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --                

                eapUpdate();
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
            Dictionary<string, string> eapList = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected EAP" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                eapList = new Dictionary<string, string>();
                foreach (UltraDataRow r in grdList.selectedDataRows)
                {
                    eapList.Add(r["EAP"].ToString(), r["Type"].ToString());
                }

                // --

                eapDelete(eapList);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                eapList = null;
                // --
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnTerminate Control Event Handler

        private void btnTerminate_Click(
            object sender, 
            EventArgs e
            )
        {
            Dictionary<string, string> eapList = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0017", new object[] { "Selected EAP" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                if (FMessageBox.showQuestion(
                   FConstants.ApplicationName,
                   m_fAdmCore.fUIWizard.generateMessage("Q0018", new object[] { "Selected EAP" }),
                   MessageBoxButtons.YesNo,
                   MessageBoxDefaultButton.Button2,
                   this
                   ) == DialogResult.No)
                {
                    return;
                }

                // --

                eapList = new Dictionary<string, string>();
                foreach (UltraDataRow r in grdList.selectedDataRows)
                {
                    eapList.Add(r["EAP"].ToString(), r["Type"].ToString());
                }

                // --

                eapTerminate(eapList);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                eapList = null;
                // --
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnClone Control Event Handler

        private void btnCloneEap_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();
                // --
                eapClone(grdList.activeDataRowKey);
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

                refreshGridOfEap(grdList.activeDataRowKey);
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
