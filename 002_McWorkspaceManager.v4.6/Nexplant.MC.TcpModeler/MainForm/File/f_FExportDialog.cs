/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FExportDialog.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2014.04.08
--  Description     : FAMate TCP Modeler Export Dialog Form Class
--  History         : Created by jungyoul.moon at 2014.04.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.TcpModeler
{
    public partial class FExportDialog : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;
        // -- 
        private FTcmCore m_fTcmCore = null;
        private FTreeView tvwFlow = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        private FExportDialog(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FExportDialog(
            FTcmCore fTcmCore
            )
            :this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
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
                    m_fTcmCore = null;
                    tvwFlow = null;
                }
                m_disposed = true;

                // -- 

                base.myDispose(disposing);
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

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

        private void designGridOfDetail(
            )
        {
            string[] columns = null;

            try
            {
                columns = new string[]
                {
                    "Object Name Definition",
                    "Function Name Definition",
                    "User Tag Name Definition",
                    "Data Conversion Definition",
                    "Equipment State Set Definition",
                    "Repository Definition",
                    "Environment Definition",
                    "Data Set Definition",
                    "TCP Library Modeler",
                    "Host Library Modeler",
                    "Equipment Modeler"
                };

                // --

                grdExportItems.addColumns(1, columns, true);
                grdExportItems.setColumnHeaderWidth(230);

                // -- 

                grdExportItems.DisplayLayout.Bands[0].Columns[0].CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect;
                // --
                grdExportItems.DisplayLayout.Bands[0].Columns[1].Header.Caption = "";                
                grdExportItems.DisplayLayout.Bands[0].Columns[1].Header.CheckBoxVisibility = Infragistics.Win.UltraWinGrid.HeaderCheckBoxVisibility.WhenUsingCheckEditor;
                grdExportItems.DisplayLayout.Bands[0].Columns[1].Header.CheckBoxSynchronization = Infragistics.Win.UltraWinGrid.HeaderCheckBoxSynchronization.RowsCollection;
                grdExportItems.DisplayLayout.Bands[0].Columns[1].Header.CheckBoxAlignment = Infragistics.Win.UltraWinGrid.HeaderCheckBoxAlignment.Center;
                // --
                grdExportItems.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True;
                grdExportItems.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Default;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                columns = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void export(
            string filename
            )
        {
            FExcelExporter2 fExcelExp = null;
            FProgress fProgress = null;

            try
            {
                // --

                fProgress = new FProgress();
                fProgress.show(this);
                Application.DoEvents();

                // --

                fExcelExp = new FExcelExporter2(filename, m_fTcmCore.fUIWizard.fontName, 9);

                // --

                if ((bool)grdExportItems.Rows[0].Cells[1].Value)
                {
                    exportObjectNameDefinition(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[1].Cells[1].Value)
                {
                    exportFunctionNameDefinition(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[2].Cells[1].Value)
                {
                    exportUserTagNameDefinition(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[3].Cells[1].Value)
                {
                    exportDataConversionDefinition(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[4].Cells[1].Value)
                {
                    exportEquipmentStateSetDefinition(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[5].Cells[1].Value)
                {
                    exportRepositoryDefinition(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[6].Cells[1].Value)
                {
                    exportEnvironmentDefinition(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[7].Cells[1].Value)
                {
                    exportDataSetDefinition(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[8].Cells[1].Value)
                {
                    exportTcpLibraryModeler(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[9].Cells[1].Value)
                {
                    exportHostLibraryModeler(fExcelExp);
                }

                // --

                if ((bool)grdExportItems.Rows[10].Cells[1].Value)
                {
                    exportEquipmentModeler(fExcelExp);
                }

                // --

                fExcelExp.save();

                // --

                // ***
                // Last Excel Export Path 저장
                // ***
                m_fTcmCore.fOption.libRecentExportPath = System.IO.Path.GetDirectoryName(filename);
            }
            catch (Exception ex)
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }
                FDebug.throwException(ex);
            }
            finally
            {
                if (fProgress != null)
                {
                    fProgress.Dispose();
                    fProgress = null;
                }

                if (fExcelExp != null)
                {
                    fExcelExp.Dispose();
                    fExcelExp = null;
                }
            }       
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportObjectNameDefinition(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;
            int firstRowIndexOnl = 0;

            try
            {
                fExcelSht = fExcelExp.addExcelSheet("Object Name Definition");

                // --
                
                // ***
                // Title Write
                // ***
                fExcelSht.writeTitle("Object Name Definition", rowIndex, 0);

                // --

                // ***
                // Object Name Header Write
                // ***
                rowIndex += 2;
                fExcelSht.writeHeaderText("Object Name List", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Object Name", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                
                // --
                
                // ***
                // Object Name List Load
                // ***
                foreach (FObjectNameList fOnl in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildObjectNameListCollection)
                {
                    rowIndex++;
                    fExcelSht.writeText(fOnl.name, rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    // --
                    firstRowIndexOnl = rowIndex;
                    
                    // --

                    // ***
                    // Object Name Load
                    // ***
                    foreach (FObjectName fOn in fOnl.fChildObjectNameCollection)
                    {
                        fExcelSht.writeText(fOn.name, rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);

                        // --

                        // ***
                        // Next Object Name Check
                        // ***
                        if (fOn.fNextSibling != null)
                        {
                            rowIndex++;
                        }
                    }

                    // --

                    // ***
                    // Object Name List Row Merge
                    // ***
                    if (firstRowIndexOnl != rowIndex)
                    {
                        fExcelSht.mergedRow(firstRowIndexOnl, rowIndex, 0, 0);
                    }
                }

                // --

                fExcelSht.autoFitColumn();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportFunctionNameDefinition(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;
            int firstRowIndexFnl = 0;
            int firstRowIndexFn = 0;
            int firstRowIndexPn = 0;

            try
            {
                fExcelSht = fExcelExp.addExcelSheet("Function Name Definition");

                // --

                // ***
                // Title Write
                // ***
                fExcelSht.writeTitle("Function Name Definition", rowIndex, 0);

                // --

                // ***
                // Function Name Header Write
                // ***
                rowIndex += 2;
                fExcelSht.writeHeaderText("Function Name List", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Function Name", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Parameter Name", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Argument", rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);

                // --

                // ***
                // Function Name List Load
                // ***
                foreach (FFunctionNameList fFnl in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildFunctionNameListCollection)
                {
                    rowIndex++;
                    fExcelSht.writeText(fFnl.name, rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    // --
                    firstRowIndexFnl = rowIndex;

                    // --

                    // ***
                    // Function Name Load
                    // ***
                    foreach (FFunctionName fFn in fFnl.fChildFunctionNameCollection)
                    {                        
                        fExcelSht.writeText(fFn.name, rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                        // --
                        firstRowIndexFn = rowIndex;

                        // --

                        // ***
                        // Parameter Name Load
                        // ***
                        foreach (FParameterName fPn in fFn.fChildParameterNameCollection)
                        {
                            fExcelSht.writeText(fPn.name, rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                            // --
                            firstRowIndexPn = rowIndex;

                            // --

                            // ***
                            // Argument Load
                            // ***
                            foreach (FArgument fAn in fPn.fChildFArgumentCollection)
                            {
                                fExcelSht.writeText(fAn.name, rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                                
                                // --

                                // ***
                                // Next Argument Check
                                // ***
                                if (fAn.fNextSibling != null)
                                {
                                    rowIndex++;
                                }
                            }

                            // --

                            // ***
                            // Parameter Name Row Merge
                            // ***
                            if (firstRowIndexPn != rowIndex)
                            {
                                fExcelSht.mergedRow(firstRowIndexPn, rowIndex, 2, 2);
                            }

                            // --

                            // ***
                            // Next Parameter Name Check
                            // ***
                            if (fPn.fNextSibling != null)
                            {
                                rowIndex++;
                            }
                        }

                        // --

                        // ***
                        // Function Name Row Merge
                        // ***
                        if (firstRowIndexFn != rowIndex)
                        {
                            fExcelSht.mergedRow(firstRowIndexFn, rowIndex, 1, 1);
                        }

                        // --

                        // ***
                        // Next Function Name Check
                        // ***
                        if (fFn.fNextSibling != null)
                        {
                            rowIndex++;
                        }
                    }

                    // --

                    // ***
                    // Function Name List Row Merge
                    // ***
                    if (firstRowIndexFnl != rowIndex)
                    {
                        fExcelSht.mergedRow(firstRowIndexFnl, rowIndex, 0, 0);
                    }
                }

                // --

                fExcelSht.autoFitColumn();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportUserTagNameDefinition(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                fExcelSht = fExcelExp.addExcelSheet("User Tag Name Definition");

                // --

                // ***
                // Title Write
                // ***
                fExcelSht.writeTitle("User Tag Name Definition", rowIndex, 0);

                // --

                // ***
                // User Tag Name Header Write
                // ***
                rowIndex += 2;
                fExcelSht.writeHeaderText("TCP Object Type", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("User Tag Name1", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("User Tag Name2", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("User Tag Name3", rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("User Tag Name4", rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("User Tag Name5", rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, true);

                // --
                
                // ***
                // User Tag Name List Load
                // ***                
                foreach (FUserTagName fUtn in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildUserTagNameCollection)
                {
                    rowIndex++;
                    fExcelSht.writeText(fUtn.name, rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fUtn.userTagName1, rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fUtn.userTagName2, rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fUtn.userTagName3, rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fUtn.userTagName4, rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fUtn.userTagName5, rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                }

                // --

                fExcelSht.autoFitColumn();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportDataConversionDefinition(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;
            int firstRowIndexDsl = 0;
            int firstRowIndexDcs = 0;

            try
            {
                fExcelSht = fExcelExp.addExcelSheet("Data Conversion Definition");

                // --

                // ***
                // Title write
                // ***
                fExcelSht.writeTitle("Data Conversion Definition", rowIndex, 0);

                // --

                // ***
                // User Tag Name Header Write
                // ***
                rowIndex += 2;
                fExcelSht.writeHeaderText("Data Conversion Set List", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Data Conversion Set", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Data Conversion", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 9, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 10, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.mergedRow(rowIndex, rowIndex, 2, 10);
                // --
                rowIndex++;
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Name", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Format", rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Index", rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Comparison Mode", rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Conversion Mode", rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Operation", rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Value", rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Conversion Value", rowIndex, 9, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Value Transformer", rowIndex, 10, m_fTcmCore.fUIWizard.fontName, 9, true);
                // --
                fExcelSht.mergedRow(rowIndex - 1, rowIndex, 0, 0);
                fExcelSht.mergedRow(rowIndex - 1, rowIndex, 1, 1);
                
                // --

                // ***
                // Data Conversion Set List Load
                // *** 
                foreach (FDataConversionSetList fDsl in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildDataConversionSetListCollection)
                {
                    rowIndex++;
                    fExcelSht.writeText(fDsl.name, rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    // --
                    firstRowIndexDsl = rowIndex;

                    // --
                     
                    // ***
                    // Data Conversion Set Load
                    // ***
                    foreach (FDataConversionSet fDcs in fDsl.fChildDataConversionSetCollection)
                    {
                        fExcelSht.writeText(fDcs.name, rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                        // --
                        firstRowIndexDcs = rowIndex;
                        
                        // --

                        // ***
                        // Data Conversion Load
                        // ***
                        foreach (FDataConversion fDcv in fDcs.fChildDataConversionCollection)
                        {
                            fExcelSht.writeText(fDcv.name, rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                            fExcelSht.writeText(fDcv.fFormat.ToString(), rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                            fExcelSht.writeText(fDcv.operandIndex.ToString(), rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                            fExcelSht.writeText(fDcv.fComparisonMode.ToString(), rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                            fExcelSht.writeText(fDcv.fConversionMode.ToString(), rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, false);
                            fExcelSht.writeText(fDcv.fOperation.ToString(), rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, false);
                            fExcelSht.writeText(fDcv.stringValue, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, false);
                            fExcelSht.writeText(fDcv.conversionValue, rowIndex, 9, m_fTcmCore.fUIWizard.fontName, 9, false);
                            fExcelSht.writeText(fDcv.fValueTransformer.ToString(), rowIndex, 10, m_fTcmCore.fUIWizard.fontName, 9, false);

                            // --

                            // ***
                            // Next Data Conversion Check
                            // ***
                            if (fDcv.fNextSibling != null)
                            {
                                rowIndex++;
                            }
                        }

                        // --

                        // ***
                        // Data Conversion Set Row Merge
                        // ***
                        if (firstRowIndexDcs != rowIndex)
                        {
                            fExcelSht.mergedRow(firstRowIndexDcs, rowIndex, 1, 1);
                        }

                        // --

                        // ***
                        // Next Data Conversion Set Check
                        // ***
                        if (fDcs.fNextSibling != null)
                        {
                            rowIndex++;
                        }
                    }

                    // --

                    // ***
                    // Data Conversion Set List Row Merge
                    // ***
                    if (firstRowIndexDsl != rowIndex)
                    {
                        fExcelSht.mergedRow(firstRowIndexDsl, rowIndex, 0, 0);
                    }
                }

                // --

                fExcelSht.autoFitColumn();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportEquipmentStateSetDefinition(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;
            int firstRowIndexEsl = 0;
            int firstRowIndexEss = 0;
            int firstRowIndexEst = 0;

            try
            {
                // --

                fExcelSht = fExcelExp.addExcelSheet("Equipment State Set Definition");

                // --

                // ***
                // Title write
                // ***
                fExcelSht.writeTitle("Equipment State Set Definition", rowIndex, 0);

                // --

                // ***
                // Equipment State Set Header Write
                // ***
                rowIndex += 2;
                fExcelSht.writeHeaderText("Equipment State Set List", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Equipment State Set", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Equipment State", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("State Value", rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.mergedRow(rowIndex, rowIndex, 2, 3);
                // --
                rowIndex++;
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Name", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Default Value", rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText(string.Empty, rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, true);
                // --
                // --
                fExcelSht.mergedRow(rowIndex - 1, rowIndex, 0, 0);
                fExcelSht.mergedRow(rowIndex - 1, rowIndex, 1, 1);
                fExcelSht.mergedRow(rowIndex - 1, rowIndex, 4, 4);
                
                // --

                // ***
                // Equipment State Set List Load
                // ***
                foreach (FEquipmentStateSetList fEsl in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildEquipmentStateSetListCollection)
                {
                    rowIndex++;
                    fExcelSht.writeText(fEsl.name, rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    // --
                    firstRowIndexEsl = rowIndex;
                    
                    // --

                    // ***
                    // Equipment State Set Load
                    // ***
                    foreach (FEquipmentStateSet fEss in fEsl.fChildEquipmentStateSetCollection)
                    {
                        fExcelSht.writeText(fEss.name, rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                        // --
                        firstRowIndexEss = rowIndex;
                        
                        // --

                        // ***
                        // Equipment State Load
                        // ***
                        foreach (FEquipmentState fEst in fEss.fChildEquipmentStateCollection)
                        {
                            fExcelSht.writeText(fEst.name, rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                            fExcelSht.writeText(fEst.defaultValue, rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                            // --
                            firstRowIndexEst = rowIndex;
                            
                            // --

                            // ***
                            // State Value Load
                            // ***
                            foreach (FStateValue fStv in fEst.fChildStateValueCollection)
                            {
                                fExcelSht.writeText(fStv.name, rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);

                                // --

                                // ***
                                // Next State Check
                                // ***
                                if (fStv.fNextSibling != null)
                                {
                                    rowIndex++;
                                }
                            }

                            // --

                            // ***
                            // Equipment State Row Merge
                            // ***
                            if (firstRowIndexEst != rowIndex)
                            {
                                fExcelSht.mergedRow(firstRowIndexEst, rowIndex, 2, 2);
                                fExcelSht.mergedRow(firstRowIndexEst, rowIndex, 3, 3);
                            }

                            // --

                            // ***
                            // Next Equipment State Check
                            // ***
                            if (fEst.fNextSibling != null)
                            {
                                rowIndex++;
                            }
                        }

                        // --

                        // ***
                        // Equipment State Set Row Merge
                        // ***
                        if (firstRowIndexEss != rowIndex)
                        {
                            fExcelSht.mergedRow(firstRowIndexEss, rowIndex, 1, 1);
                        }

                        // --

                        // ***
                        // Next Equipment State Set Check
                        // ***
                        if (fEss.fNextSibling != null)
                        {
                            rowIndex++;
                        }
                    }

                    // --

                    // ***
                    // Equipment State Set List Row Merge
                    // ***
                    if (firstRowIndexEsl != rowIndex)
                    {
                        fExcelSht.mergedRow(firstRowIndexEsl, rowIndex, 0, 0);
                    }
                }

                // --

                fExcelSht.autoFitColumn();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportRepositoryDefinition(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                // --

                fExcelSht = fExcelExp.addExcelSheet("Repository Definition");

                // --

                // ***
                // Title Write
                // ***
                fExcelSht.writeTitle("Repository Definition", rowIndex, 0);

                // --

                // ***
                // Repository List Load
                // ***
                foreach (FRepositoryList fRpl in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildRepositoryListCollection)
                {
                    rowIndex += 2;
                    fExcelSht.writeSubTitle(string.Format("[{0}]", fRpl.name), rowIndex, 0);
                    
                    // --

                    // ***
                    // FRepository Load
                    // ***
                    foreach (FRepository fRpt in fRpl.fChildRepositoryCollection)
                    {
                        rowIndex += 2;
                        fExcelSht.writeSubTitle(string.Format("   {0}", fRpt.name), rowIndex, 0);

                        // --

                        if (!fRpt.hasChild)
                        {
                            continue;
                        }

                        // --

                        // ***
                        // Repository Header Write
                        // ***
                        rowIndex++;
                        fExcelSht.writeHeaderText("Structure", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Primary Key", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Duplication Key", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Pattern", rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Fixed Length", rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Format", rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Scan Mode", rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Value Transformer", rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Data Conversion Set", rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, true);

                        // --

                        // ***
                        // Column Export
                        // ***
                        exportRepositoryDefinitionSub(fExcelSht, fRpt, ref rowIndex);
                    }
                }

                // --

                fExcelSht.autoFitColumn();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportRepositoryDefinitionSub(
            FExcelSheet fExcelSht,
            FRepository fRpt,
            ref int rowIndex
            )
        {
            int idx = 0;

            try
            {        
                foreach (FColumn fCol in fRpt.fChildColumnCollection)
                {
                    rowIndex++;
                    fExcelSht.writeText(string.Format("{0}. {1}", (++idx), fCol.ToString(FStringOption.Detail)), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fCol.primaryKey.ToString(), rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fCol.duplicationKey.ToString(), rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fCol.fPattern.ToString(), rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fCol.fixedLength.ToString(), rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fCol.fFormat.ToString(), rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fCol.fScanMode.ToString(), rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fCol.fValueTransformer.ToString(), rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fCol.dataConversionSetName, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, false);

                    // --

                    if (fCol.hasChild)
                    {
                        exportRepositoryDefinitionChild(1, fExcelSht, fCol, ref rowIndex);
                    }                                       
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

        private void exportRepositoryDefinitionChild(
            int depth,
            FExcelSheet fExcelSht,
            FColumn fCol,
            ref int rowIndex
            )
        {
            string name = string.Empty;
            int idx = 0;
            
            try
            {
                foreach (FColumn fColChild in fCol.fChildColumnCollection)
                {
                    rowIndex++;
                    name = string.Format("{0}. {1}", (++idx), fColChild.ToString(FStringOption.Detail));
                    fExcelSht.writeText(name.PadLeft((depth * 5) + name.Length, ' '), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fColChild.primaryKey.ToString(), rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fColChild.duplicationKey.ToString(), rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fColChild.fPattern.ToString(), rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fColChild.fixedLength.ToString(), rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fColChild.fFormat.ToString(), rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fColChild.fScanMode.ToString(), rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fColChild.fValueTransformer.ToString(), rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fColChild.dataConversionSetName, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, false);

                    // --

                    if (fColChild.hasChild)
                    {
                        exportRepositoryDefinitionChild(depth + 1, fExcelSht, fColChild, ref rowIndex);
                    }
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

        private void exportEnvironmentDefinition(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;
            try
            {
                // --

                fExcelSht = fExcelExp.addExcelSheet("Environment Definition");

                // --

                // ***
                // Title Write
                // ***
                fExcelSht.writeTitle("Environment Definition", rowIndex, 0);

                // --
                
                // ***
                // Environment List Load
                // ***
                foreach (FEnvironmentList fEvl in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildEnvironmentListCollection)
                {
                    rowIndex += 2;
                    fExcelSht.writeSubTitle(string.Format("[{0}]", fEvl.name), rowIndex, 0);

                    // --

                    if (!fEvl.hasChild)
                    {
                        continue;
                    }

                    // --

                    // ***
                    // Environment Header Write
                    // ***
                    rowIndex++;
                    fExcelSht.writeHeaderText("Structure", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                    fExcelSht.writeHeaderText("Format", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                    fExcelSht.writeHeaderText("Value", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);

                    // --

                    // ***
                    // Environment Load
                    // ***
                    foreach (FEnvironment fEnv in fEvl.fChildEnvironmentCollection)
                    {
                        // ***
                        // Environment Export
                        // ***
                        exportEnvironmentDefinitionSub(fExcelSht, fEnv, ref rowIndex);
                    }
                }

                // --

                fExcelSht.autoFitColumn();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportEnvironmentDefinitionSub(
            FExcelSheet fExcelSht,
            FEnvironment fEnv,
            ref int rowIndex
            )
        {
            int idx = 0;

            try
            {
                rowIndex++;
                fExcelSht.writeText(string.Format("{0}. {1}", (++idx), fEnv.ToString(FStringOption.Detail)), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                fExcelSht.writeText(fEnv.fFormat.ToString(), rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                fExcelSht.writeText(fEnv.stringValue, rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);

                // --

                if (fEnv.hasChild)
                {
                    exportEnvironmentDefinitionChild(1, fExcelSht, fEnv, ref rowIndex);
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

        private void exportEnvironmentDefinitionChild(
            int depth,
            FExcelSheet fExcelSht,
            FEnvironment fEnv,
            ref int rowIndex
            )
        {
            string name = string.Empty;
            int idx = 0;
            
            try
            {
                foreach (FEnvironment fEnvChild in fEnv.fChildEnvironmentCollection)
                {
                    rowIndex++;
                    name = string.Format("{0}. {1}", (++idx), fEnvChild.ToString(FStringOption.Detail));
                    fExcelSht.writeText(name.PadLeft((depth * 5) + name.Length, ' '), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fEnvChild.fFormat.ToString(), rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fEnvChild.stringValue, rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    
                    // --

                    if (fEnvChild.hasChild)
                    {
                        exportEnvironmentDefinitionChild(depth + 1, fExcelSht, fEnvChild, ref rowIndex);
                    }
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

        private void exportDataSetDefinition(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            int rowIndex = 0;

            try
            {
                // --

                fExcelSht = fExcelExp.addExcelSheet("Data Set Definition");

                // --

                // ***
                // Title Write
                // ***
                fExcelSht.writeTitle("Data Set Definition", rowIndex, 0);

                // --

                // ***
                // Data Set List Load
                // ***
                foreach (FDataSetList fDsl in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildDataSetListCollection)
                {
                    rowIndex += 2;
                    fExcelSht.writeSubTitle(string.Format("[{0}]", fDsl.name), rowIndex, 0);

                    // --

                    // ***
                    // Data Set Load
                    // ***
                    foreach (FDataSet fDst in fDsl.fChildDataSetCollection)
                    {
                        rowIndex += 2;
                        fExcelSht.writeSubTitle(string.Format("   {0}", fDst.name), rowIndex, 0);

                        // --

                        if (!fDst.hasChild)
                        {
                            continue;
                        }

                        // --

                        // ***
                        // Data Set Header Write
                        // ***
                        rowIndex++;
                        fExcelSht.writeHeaderText("Structure", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Source", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Target", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Patten", rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Fixed Length", rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Format", rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Scan Mode", rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Value Transformer", rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, true);
                        fExcelSht.writeHeaderText("Data Conversion Set", rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, true);

                        // --

                        // ***
                        // Data Export
                        // ***
                        exportDataSetDefinitionSub(fExcelSht, fDsl.name, fDst, ref rowIndex);
                    }
                }

                // --

                fExcelSht.autoFitColumn();

                // --
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportDataSetDefinitionSub(
            FExcelSheet fExcelSht,
            string repositoryListName,
            FDataSet fDst,
            ref int rowIndex
            )
        {
            string source = string.Empty;
            string target = string.Empty;
            int idx = 0;

            try
            {
                foreach (FData fDat in fDst.fChildDataCollection)
                {
                    rowIndex++;
                    fExcelSht.writeText(string.Format("{0}. {1}", (++idx), fDat.ToString(FStringOption.Detail)), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    source = generateStringForDataSetSource(fDat);
                    fExcelSht.writeText(source, rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    target = generateStringForDataSetTarget(fDat);
                    fExcelSht.writeText(target, rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDat.fPattern.ToString(), rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDat.fixedLength.ToString(), rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDat.fFormat.ToString(), rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDat.fScanMode.ToString(), rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDat.fValueTransformer.ToString(), rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDat.dataConversionSetName, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, false);

                    // --

                    if (fDat.hasChild)
                    {
                        exportDataSetDefinitionChild(1, fExcelSht, fDat, ref rowIndex);
                    }
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

        private void exportDataSetDefinitionChild(
            int depth,
            FExcelSheet fExcelSht,
            FData fParentData,
            ref int rowIndex
            )
        {
            string name = string.Empty;
            string source = string.Empty;
            string target = string.Empty;
            int idx = 0;
            
            try
            {
                // --

                foreach (FData fDatChild in fParentData.fChildDataCollection)
                {
                    rowIndex++;
                    name = string.Format("{0}. {1}", (++idx), fDatChild.ToString(FStringOption.Detail));
                    fExcelSht.writeText(name.PadLeft((depth * 5) + name.Length, ' '), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    source = generateStringForDataSetSource(fDatChild);
                    fExcelSht.writeText(source, rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    target = generateStringForDataSetTarget(fDatChild);
                    fExcelSht.writeText(target, rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDatChild.fPattern.ToString(), rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDatChild.fixedLength.ToString(), rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDatChild.fFormat.ToString(), rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDatChild.fScanMode.ToString(), rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDatChild.fValueTransformer.ToString(), rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fDatChild.dataConversionSetName, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, false);

                    // --

                    if (fDatChild.hasChild)
                    {
                        exportDataSetDefinitionChild(depth + 1, fExcelSht, fDatChild, ref rowIndex);
                    }

                    // --
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

        private void exportTcpLibraryModeler(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            string name = string.Empty;
            int rowIndex = 0;
            try
            {
                fExcelSht = fExcelExp.addExcelSheet("TCP Library Modeler");

                // --

                // ***
                // Title write
                // *** 
                fExcelSht.writeTitle("TCP Library Modeler", rowIndex, 0);

                // --

                // ***
                // TCP Library Group Load
                // ***
                foreach (FTcpLibraryGroup fTlg in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildTcpLibraryGroupCollection)
                {
                    // ***
                    // TCP Library Load
                    // ***
                    foreach (FTcpLibrary fTlb in fTlg.fChildTcpLibraryCollection)
                    {
                        rowIndex += 2;
                        fExcelSht.writeTitle(string.Format("{0} - {1}", fTlg.name, fTlb.name), rowIndex, 0);

                        // --

                        // ***
                        // TCP Message List Load
                        // ***
                        foreach (FTcpMessageList fTml in fTlb.fChildTcpMessageListCollection)
                        {
                            rowIndex += 2;
                            fExcelSht.writeSubTitle(string.Format("[{0}]", fTml.name), rowIndex, 0);

                            // --

                            // ***
                            // TCP Messages Load
                            // ***
                            foreach (FTcpMessages fTms in fTml.fChildTcpMessagesCollection)
                            {
                                if (fTms.fDirection == FDirection.Both)
                                {
                                    name = string.Format("◆ {0}, {1}", fTms.ToString(FStringOption.Detail), fTms.directionSymbol);
                                }
                                else if (fTms.fDirection == FDirection.Host)
                                {
                                    name = string.Format("▶ {0}, {1}", fTms.ToString(FStringOption.Detail), fTms.directionSymbol);
                                }
                                else
                                {
                                    name = string.Format("◀ {0}, {1}", fTms.ToString(FStringOption.Detail), fTms.directionSymbol);
                                }

                                // --

                                rowIndex += 2;
                                fExcelSht.writeSubTitle(name, rowIndex, 0);

                                // --

                                // ***
                                // TCP Message Load
                                // ***
                                foreach (FTcpMessage fTmg in fTms.fChildTcpMessageCollection)
                                {
                                    exportTcpLibraryModelerSub(fExcelSht, fTmg, ref rowIndex);
                                }
                            }
                        }
                    }
                }

                // --

                fExcelSht.autoFitColumn();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportTcpLibraryModelerSub(
            FExcelSheet fExcelSht,
            FTcpMessage fTmg,
            ref int rowIndex
            )
        {
            string name = string.Empty;
            int idx = 0;

            try
            {
                name = string.Format("   {0}, {1}", fTmg.ToString(FStringOption.Detail), fTmg.fTcpMessageType.ToString());
                // --
                if (fTmg.fTcpMessageType == FTcpMessageType.Reply)
                {
                    if (fTmg.autoReply)
                    {
                        name += ", Auto Reply";
                    }
                }

                // --

                rowIndex++;
                fExcelSht.writeSubTitle(name, rowIndex, 0);

                // --

                if (!fTmg.hasChild)
                {
                    return;
                }

                // --

                // ***
                // TCP Message Header Write
                // ***
                rowIndex++;
                fExcelSht.writeHeaderText("Structure", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Pattern", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Fixed Length", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Format", rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Scan Mode", rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Value Transformer", rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Data Conversion Set", rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Precondition", rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Reserved Word", rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Extraction", rowIndex, 9, m_fTcmCore.fUIWizard.fontName, 9, true);

                // --

                foreach (FTcpItem fTit in fTmg.fChildTcpItemCollection)
                {
                    rowIndex++;
                    fExcelSht.writeText(string.Format("{0}. {1}", (++idx), fTit.ToString(FStringOption.Detail)), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTit.fPattern.ToString(), rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTit.fixedLength.ToString(), rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTit.fFormat.ToString(), rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTit.fScanMode.ToString(), rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTit.fValueTransformer.ToString(), rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTit.dataConversionSetName, rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTit.fPrecondition.ToString(), rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTit.reservedWord, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTit.extraction.ToString(), rowIndex, 9, m_fTcmCore.fUIWizard.fontName, 9, false);

                    // --

                    if (fTit.hasChild)
                    {
                        exportTcpLibraryModelerChild(1, fExcelSht, fTit, ref rowIndex);
                    }
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

        private void exportTcpLibraryModelerChild(
            int depth,
            FExcelSheet fExcelSht,
            FTcpItem fTit,
            ref int rowIndex
            )
        {
            string name = string.Empty;
            int idx = 0;

            try
            {
                foreach (FTcpItem fTitChild in fTit.fChildTcpItemCollection)
                {
                    name = string.Format("{0}. {1}", (++idx), fTitChild.ToString(FStringOption.Detail));

                    // --

                    rowIndex++;
                    fExcelSht.writeText(name.PadLeft((depth * 5) + name.Length, ' '), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTitChild.fPattern.ToString(), rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTitChild.fixedLength.ToString(), rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTitChild.fFormat.ToString(), rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTitChild.fScanMode.ToString(), rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTitChild.fValueTransformer.ToString(), rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTitChild.dataConversionSetName, rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTitChild.fPrecondition.ToString(), rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTitChild.reservedWord, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fTitChild.extraction.ToString(), rowIndex, 9, m_fTcmCore.fUIWizard.fontName, 9, false);

                    // --

                    if (fTitChild.hasChild)
                    {
                        exportTcpLibraryModelerChild(depth + 1, fExcelSht, fTitChild, ref rowIndex);
                    }
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

        private void exportHostLibraryModeler(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            string name = string.Empty;
            int rowIndex = 0;
            try
            {
                fExcelSht = fExcelExp.addExcelSheet("Host Library Modeler");
                
                // --

                // ***
                // Title write
                // *** 
                fExcelSht.writeTitle("Host Library Modeler", rowIndex, 0);

                // --

                // ***
                // Host Library Group Load
                // ***
                foreach (FHostLibraryGroup fHlg in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildHostLibraryGroupCollection)
                {
                    // ***
                    // Host Library Load
                    // ***
                    foreach (FHostLibrary fHlb in fHlg.fChildHostLibraryCollection)
                    {
                        rowIndex += 2;              
                        fExcelSht.writeTitle(string.Format("{0} - {1}", fHlg.name, fHlb.name), rowIndex, 0);

                        // --
                        
                        // ***
                        // Host Message List Load
                        // ***
                        foreach (FHostMessageList fHml in fHlb.fChildHostMessageListCollection)
                        {
                            rowIndex += 2;
                            fExcelSht.writeSubTitle(string.Format("[{0}]", fHml.name), rowIndex, 0);

                            // --
                            
                            // ***
                            // Host Messages Load
                            // ***
                            foreach (FHostMessages fHms in fHml.fChildHostMessagesCollection)
                            {
                                if (fHms.fDirection == FDirection.Both)
                                {
                                    name = string.Format("◆ {0}, {1}", fHms.ToString(FStringOption.Detail), fHms.directionSymbol);
                                }
                                else if (fHms.fDirection == FDirection.Host)
                                {
                                    name = string.Format("▶ {0}, {1}", fHms.ToString(FStringOption.Detail), fHms.directionSymbol);
                                }
                                else
                                {
                                    name = string.Format("◀ {0}, {1}", fHms.ToString(FStringOption.Detail), fHms.directionSymbol);
                                }

                                // --

                                rowIndex += 2;
                                fExcelSht.writeSubTitle(name, rowIndex, 0);

                                // --

                                // ***
                                // Host Message Load
                                // ***
                                foreach (FHostMessage fHmg in fHms.fChildHostMessageCollection)
                                {
                                    exportHostLibraryModelerSub(fExcelSht, fHmg, ref rowIndex);
                                }
                            }
                        }
                    }
                }

                // --

                fExcelSht.autoFitColumn();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportHostLibraryModelerSub(
            FExcelSheet fExcelSht,
            FHostMessage fHmg,
            ref int rowIndex
            )
        {
            string name = string.Empty;
            int idx = 0;

            try
            {
                name = string.Format("   {0}, {1}", fHmg.ToString(FStringOption.Detail), fHmg.fHostMessageType.ToString());
                if (fHmg.fHostMessageType == FHostMessageType.Unsolicited)
                {
                    if (fHmg.multiCastMessage)
                    {
                        name += ", Multi Cast";
                    }
                    if (fHmg.guaranteedMessage)
                    {
                        name += ", Guaranteed";
                    }
                }
                else if (fHmg.fHostMessageType == FHostMessageType.Reply)
                {
                    if (fHmg.autoReply)
                    {
                        name += ", Auto Reply";
                    }
                }

                // --

                rowIndex++;
                fExcelSht.writeSubTitle(name, rowIndex, 0);

                // --

                if (!fHmg.hasChild)
                {
                    return;
                }

                // --

                // ***
                // Host Message Header Write
                // ***
                rowIndex++;
                fExcelSht.writeHeaderText("Structure", rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Pattern", rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Fixed Length", rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Format", rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Scan Mode", rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Value Transformer", rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Data Conversion Set", rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Precondition", rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Reserved Word", rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, true);
                fExcelSht.writeHeaderText("Extraction", rowIndex, 9, m_fTcmCore.fUIWizard.fontName, 9, true);

                // --

                foreach (FHostItem fHit in fHmg.fChildHostItemCollection)
                {
                    rowIndex++;
                    fExcelSht.writeText(string.Format("{0}. {1}", (++idx), fHit.ToString(FStringOption.Detail)), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHit.fPattern.ToString(), rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHit.fixedLength.ToString(), rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHit.fFormat.ToString(), rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHit.fScanMode.ToString(), rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHit.fValueTransformer.ToString(), rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHit.dataConversionSetName, rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHit.fPrecondition.ToString(), rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHit.reservedWord, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHit.extraction.ToString(), rowIndex, 9, m_fTcmCore.fUIWizard.fontName, 9, false);

                    // --

                    if (fHit.hasChild)
                    {
                        exportHostLibraryModelerChild(1, fExcelSht, fHit, ref rowIndex);
                    }
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

        private void exportHostLibraryModelerChild(
            int depth,
            FExcelSheet fExcelSht,
            FHostItem fHit,
            ref int rowIndex
            )
        {
            string name = string.Empty;
            int idx = 0;

            try
            {
                foreach (FHostItem fHitChild in fHit.fChildHostItemCollection)
                {
                    name = string.Format("{0}. {1}", (++idx), fHitChild.ToString(FStringOption.Detail));

                    // --

                    rowIndex++;
                    fExcelSht.writeText(name.PadLeft((depth * 5) + name.Length, ' '), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHitChild.fPattern.ToString(), rowIndex, 1, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHitChild.fixedLength.ToString(), rowIndex, 2, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHitChild.fFormat.ToString(), rowIndex, 3, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHitChild.fScanMode.ToString(), rowIndex, 4, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHitChild.fValueTransformer.ToString(), rowIndex, 5, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHitChild.dataConversionSetName, rowIndex, 6, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHitChild.fPrecondition.ToString(), rowIndex, 7, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHitChild.reservedWord, rowIndex, 8, m_fTcmCore.fUIWizard.fontName, 9, false);
                    fExcelSht.writeText(fHitChild.extraction.ToString(), rowIndex, 9, m_fTcmCore.fUIWizard.fontName, 9, false);

                    // --

                    if (fHitChild.hasChild)
                    {
                        exportHostLibraryModelerChild(depth + 1, fExcelSht, fHitChild, ref rowIndex);
                    }
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

        private void exportEquipmentModeler(
            FExcelExporter2 fExcelExp
            )
        {
            FExcelSheet fExcelSht = null;
            FIObject fObject = null;
            Nexplant.MC.Core.FaUIs.WPF.FIFlowCtrl fFlowCtrl = null;
            Nexplant.MC.Core.FaUIs.WPF.FFlowContainer flcContainer = null;
            string name = string.Empty;
            int rowIndex = 0;
            int count = 0;

            try
            {
                // --

                fExcelSht = fExcelExp.addExcelSheet("Equipment Modeler");

                // --

                // ***
                // Title write
                // *** 
                fExcelSht.writeTitle("Equipment Modeler", rowIndex, 0);

                // --

                // ***
                // Equipment Load
                // ***
                foreach (FEquipment fEqp in this.m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildEquipmentCollection)
                {
                    rowIndex += 2;                
                    fExcelSht.writeTitle(fEqp.name, rowIndex, 0);
                    
                    // --

                    // ***
                    // Scenario Group Load
                    // ***
                    foreach (FScenarioGroup fSng in fEqp.fChildScenarioGroupCollection)
                    {
                        rowIndex += 2;
                        fExcelSht.writeTitle(fSng.name, rowIndex, 0);
                        
                        // --

                        // ***
                        // Scenario Load
                        // ***
                        foreach (FScenario fSnr in fSng.fChildScenarioCollection)
                        {
                            name = string.Format("{0} | [{1} ─ {2} ─ {3}]", fSnr.name, fSng.equipmentAlias, fSng.eapAlias, fSng.hostAlias);
                            // --
                            rowIndex += 2;
                            fExcelSht.writeSubTitle(name, rowIndex, 0);
                            
                            // --

                            count = fSnr.fChildFlowCollection.count;
                            flcContainer = new Nexplant.MC.Core.FaUIs.WPF.FFlowContainer();

                            // --

                            // ***
                            // Change Alias Name
                            // ***
                            flcContainer.eapAlias = fSng.eapAlias;
                            flcContainer.eqAlias = fSng.equipmentAlias;
                            flcContainer.hostAlias = fSng.hostAlias;

                            // --

                            // ***
                            // Set Flow Size
                            // ***
                            flcContainer.Width = 527;
                            flcContainer.Height = (count * 36) + 64;
                            if (flcContainer.Height < 524)
                            {
                                flcContainer.Height = 524;
                            }
                                                       
                            // --
                            
                            // ***
                            // Flow Create
                            // ***
                            foreach (FIFlow fFlow in fSnr.fChildFlowCollection)
                            {
                                fObject = (FIObject)fFlow;
                                // --
                                if (fFlow.fFlowType == FFlowType.TcpTrigger)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FTcpTriggerFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.TcpTransmitter)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FTcpTransmitterFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.HostTrigger)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTriggerFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.HostTransmitter)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FHostTransmitterFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.EquipmentStateSetAlterer)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FEquipmentStateSetAltererFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.Judgement)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FJudgementFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.Mapper)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FMapperFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.Storage)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FStorageFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.Callback)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCallbackFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.Branch)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FBranchFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.Comment)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FCommentFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.Pauser)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FPauserFlow(fObject.uniqueIdToString));
                                }
                                else if (fFlow.fFlowType == FFlowType.EntryPoint)
                                {
                                    fFlowCtrl = flcContainer.appendFlowCtrl(new Nexplant.MC.Core.FaUIs.WPF.FEntryPointFlow(fObject.uniqueIdToString));
                                }
                                // --
                                FCommon.refreshFlowCtrlOfObject(fObject, fFlowCtrl, tvwFlow);
                            }
                           
                            // --

                            // ***
                            // Row Count 설정 (최소 20줄)
                            // ***
                            if (count < 20)
                            {
                                count = 20;
                            }

                            // --

                            rowIndex++;
                            fExcelSht.writeImage(flcContainer.getImage(), rowIndex, 0, (rowIndex += count), 8);
                            
                            // --

                            if (flcContainer != null)
                            {
                                flcContainer.Dispose();
                                flcContainer = null;
                            }

                            // --

                            foreach (FIFlow fFlow in fSnr.fChildFlowCollection)
                            {
                                fObject = (FIObject)fFlow;
                                exportEquipmentModelerSub(fExcelSht, fObject, ref rowIndex);
                            }
                        }
                    }
                }

                // --

                fExcelSht.autoFitColumn();

                // --
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fExcelSht != null)
                {
                    fExcelSht.Dispose();
                    fExcelSht = null;
                }
                // --
                fFlowCtrl = null;
                fObject = null;
                flcContainer = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void exportEquipmentModelerSub(
            FExcelSheet fExcelSht,
            FIObject fObject,
            ref int rowIndex
            )
        {            
            string name = string.Empty;

            try
            {
                // ***
                // Write Header
                // ***
                name = string.Format("{0} [{1}]", fObject.name, fObject.fObjectType.ToString());
                // --
                rowIndex++;
                fExcelSht.writeHeaderText(name, rowIndex, 0, 1, m_fTcmCore.fUIWizard.fontName, 9, true);

                // --

                rowIndex++;
                fExcelSht.writeText(fObject.ToString(FStringOption.Detail), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);

                // --

                // ***
                // Child Object가 존재하지 않으면 Next...
                // ***
                if (!fObject.hasChild)
                {
                    return;
                }

                // --

                if (fObject.fObjectType == FObjectType.TcpTrigger)
                {
                    foreach (FIObject fChildObject in ((FTcpTrigger)fObject).fChildTcpConditionCollection)
                    {
                        exportEquipmentModelerChild(fExcelSht, fChildObject, 1, ref rowIndex);
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpTransmitter)
                {
                    foreach (FIObject fChildObject in ((FTcpTransmitter)fObject).fChildTcpTransferCollection)
                    {
                        exportEquipmentModelerChild(fExcelSht, fChildObject, 1, ref rowIndex);
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostTrigger)
                {
                    foreach (FIObject fChildObject in ((FHostTrigger)fObject).fChildHostConditionCollection)
                    {
                        exportEquipmentModelerChild(fExcelSht, fChildObject, 1, ref rowIndex);
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostTransmitter)
                {
                    foreach (FIObject fChildObject in ((FHostTransmitter)fObject).fChildHostTransferCollection)
                    {
                        exportEquipmentModelerChild(fExcelSht, fChildObject, 1, ref rowIndex);
                    }
                }
                else if (fObject.fObjectType == FObjectType.EquipmentStateSetAlterer)
                {
                    foreach (FIObject fChildObject in ((FEquipmentStateSetAlterer)fObject).fChildEquipmentStateAltererCollection)
                    {
                        exportEquipmentModelerChild(fExcelSht, fChildObject, 1, ref rowIndex);
                    }
                }
                else if (fObject.fObjectType == FObjectType.Judgement)
                {
                    foreach (FIObject fChildObject in ((FJudgement)fObject).fChildJudgementConditionCollection)
                    {
                        exportEquipmentModelerChild(fExcelSht, fChildObject, 1, ref rowIndex);
                        rowIndex++;
                    }
                } 
                else if (fObject.fObjectType == FObjectType.Callback)
                {
                    foreach (FIObject fChildObject in ((FCallback)fObject).fChildFunctionCollection)
                    {
                        exportEquipmentModelerChild(fExcelSht, fChildObject, 1, ref rowIndex);
                        rowIndex++;
                    }
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

        private void exportEquipmentModelerChild(
            FExcelSheet fExcelSht,
            FIObject fObject,
            int depth,
            ref int rowIndex
            )
        {            
            string name = string.Empty;
            try
            {
                name = fObject.ToString(FStringOption.Detail);
                // --
                rowIndex++;
                fExcelSht.writeText(name.PadLeft(depth * 5 + (name.Length), ' '), rowIndex, 0, m_fTcmCore.fUIWizard.fontName, 9, false);

                // --

                if (fObject.fObjectType == FObjectType.TcpCondition)
                {
                    if (((FTcpCondition)fObject).hasChild)
                    {
                        foreach (FIObject fChildObject in ((FTcpCondition)fObject).fChildTcpExpressionCollection)
                        {
                            exportEquipmentModelerChild(fExcelSht, fChildObject, depth + 1, ref rowIndex);
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.TcpExpression)
                {
                    if (((FTcpExpression)fObject).hasChild)
                    {
                        foreach (FIObject fChildObject in ((FTcpExpression)fObject).fChildTcpExpressionCollection)
                        {
                            exportEquipmentModelerChild(fExcelSht, fChildObject, depth + 1, ref rowIndex);
                        }
                    }
                }
                // --
                else if (fObject.fObjectType == FObjectType.HostCondition)
                {
                    if (((FHostCondition)fObject).hasChild)
                    {
                        foreach (FIObject fChildObject in ((FHostCondition)fObject).fChildHostExpressionCollection)
                        {
                            exportEquipmentModelerChild(fExcelSht, fChildObject, depth + 1, ref rowIndex);
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.HostExpression)
                {
                    if (((FHostExpression)fObject).hasChild)
                    {
                        foreach (FIObject fChildObject in ((FHostExpression)fObject).fChildHostExpressionCollection)
                        {
                            exportEquipmentModelerChild(fExcelSht, fChildObject, depth + 1, ref rowIndex);
                        }
                    }
                }
                // --
                else if (fObject.fObjectType == FObjectType.JudgementCondition)
                {
                    if (((FJudgementCondition)fObject).hasChild)
                    {
                        foreach (FIObject fChildObject in ((FJudgementCondition)fObject).fChildJudgementExpressionCollection)
                        {
                            exportEquipmentModelerChild(fExcelSht, fChildObject, depth + 1, ref rowIndex);
                        }
                    }
                }
                else if (fObject.fObjectType == FObjectType.JudgementExpression)
                {
                    if (((FJudgementExpression)fObject).hasChild)
                    {
                        foreach (FIObject fChildObject in ((FJudgementExpression)fObject).fChildJudgementExpressionCollection)
                        {
                            exportEquipmentModelerChild(fExcelSht, fChildObject, depth + 1, ref rowIndex);
                        }
                    }
                }                

                // --
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

        private string generateStringForDataSetSource(
            FData fData
            )
        {
            try
            {
                if (fData.fSourceType == FDataSourceType.Constant)
                {
                    return string.Format("{0} : {1}", fData.fSourceType.ToString(), fData.sourceConstant);
                }
                else if (fData.fSourceType == FDataSourceType.Resource)
                {
                    return string.Format("{0} : {1}", fData.fSourceType.ToString(), fData.sourceResource);
                }
                else if (fData.fSourceType == FDataSourceType.EquipmentState)
                {
                    return string.Format("{0} : {1}", fData.fSourceType.ToString(), fData.sourceEquipmentState);
                }
                else if (fData.fSourceType == FDataSourceType.Environment)
                {
                    return string.Format("{0} : {1}", fData.fSourceType.ToString(), fData.sourceEnvironment);
                }
                else if (fData.fSourceType == FDataSourceType.Column)
                {
                    return string.Format("{0} : {1}", fData.fSourceType.ToString(), fData.sourceColumn);
                }
                else if (fData.fSourceType == FDataSourceType.Item)
                {
                    return string.Format("{0} : {1}", fData.fSourceType.ToString(), fData.sourceItem);
                } 
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

        //------------------------------------------------------------------------------------------------------------------------

        private string generateStringForDataSetTarget(
            FData fData
            )
        {
            try
            {
                if (fData.fTargetType == FDataTargetType.Constant)
                {
                    return string.Format("{0} : {1}", fData.fTargetType.ToString(), fData.targetConstant);
                }
                else if (fData.fTargetType == FDataTargetType.Column)
                {
                    return string.Format("{0} : {1}", fData.fTargetType.ToString(), fData.targetColumn);
                }
                else if (fData.fTargetType == FDataTargetType.Item)
                {
                    return string.Format("{0} : {1}", fData.fTargetType.ToString(), fData.targetItem);
                }
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FExportDialog Form Event Handler

        private void FExportDialog_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                tvwFlow = new FTreeView();
                tvwFlow.ImageList = new ImageList();
                // --
                tvwFlow.ImageList.Images.Add("TcpTrigger", Properties.Resources.TcpTrigger);
                tvwFlow.ImageList.Images.Add("TcpCondition_Expression", Properties.Resources.TcpCondition_Expression);
                tvwFlow.ImageList.Images.Add("TcpCondition_Timeout", Properties.Resources.TcpCondition_Timeout);
                tvwFlow.ImageList.Images.Add("TcpCondition_Connection_Closed", Properties.Resources.TcpCondition_Connection_Closed);
                tvwFlow.ImageList.Images.Add("TcpCondition_Connection_Opened", Properties.Resources.TcpCondition_Connection_Opened);
                tvwFlow.ImageList.Images.Add("TcpCondition_Connection_Connected", Properties.Resources.TcpCondition_Connection_Connected);
                tvwFlow.ImageList.Images.Add("TcpCondition_Connection_Selected", Properties.Resources.TcpCondition_Connection_Selected);
                tvwFlow.ImageList.Images.Add("TcpExpression_Bracket", Properties.Resources.TcpExpression_Bracket);
                tvwFlow.ImageList.Images.Add("TcpExpression_Comparison_Value_EquipmentState", Properties.Resources.TcpExpression_Comparison_Value_EquipmentState);
                tvwFlow.ImageList.Images.Add("TcpExpression_Comparison_Value_Environment", Properties.Resources.TcpExpression_Comparison_Value_Environment);
                tvwFlow.ImageList.Images.Add("TcpExpression_Comparison_Value_Item", Properties.Resources.TcpExpression_Comparison_Value_TcpItem);
                tvwFlow.ImageList.Images.Add("TcpExpression_Comparison_Length_Environment", Properties.Resources.TcpExpression_Comparison_Length_Environment);
                tvwFlow.ImageList.Images.Add("TcpExpression_Comparison_Length_Item", Properties.Resources.TcpExpression_Comparison_Length_TcpItem);
                tvwFlow.ImageList.Images.Add("TcpTransmitter", Properties.Resources.TcpTransmitter);
                tvwFlow.ImageList.Images.Add("TcpTransfer", Properties.Resources.TcpTransfer);
                tvwFlow.ImageList.Images.Add("HostTrigger", Properties.Resources.HostTrigger);
                tvwFlow.ImageList.Images.Add("HostCondition_Expression", Properties.Resources.HostCondition_Expression);
                tvwFlow.ImageList.Images.Add("HostCondition_Timeout", Properties.Resources.HostCondition_Timeout);
                tvwFlow.ImageList.Images.Add("HostCondition_Connection_Closed", Properties.Resources.HostCondition_Connection_Closed);
                tvwFlow.ImageList.Images.Add("HostCondition_Connection_Opened", Properties.Resources.HostCondition_Connection_Opened);
                tvwFlow.ImageList.Images.Add("HostCondition_Connection_Connected", Properties.Resources.HostCondition_Connection_Connected);
                tvwFlow.ImageList.Images.Add("HostCondition_Connection_Selected", Properties.Resources.HostCondition_Connection_Selected);
                tvwFlow.ImageList.Images.Add("HostExpression_Bracket", Properties.Resources.HostExpression_Bracket);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Value_EquipmentState", Properties.Resources.HostExpression_Comparison_Value_EquipmentState);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Value_Environment", Properties.Resources.HostExpression_Comparison_Value_Environment);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Value_HostItem", Properties.Resources.HostExpression_Comparison_Value_HostItem);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Length_Environment", Properties.Resources.HostExpression_Comparison_Length_Environment);
                tvwFlow.ImageList.Images.Add("HostExpression_Comparison_Length_HostItem", Properties.Resources.HostExpression_Comparison_Length_HostItem);
                tvwFlow.ImageList.Images.Add("HostTransmitter", Properties.Resources.HostTransmitter);
                tvwFlow.ImageList.Images.Add("HostTransfer", Properties.Resources.HostTransfer);
                // --
                tvwFlow.ImageList.Images.Add("EquipmentStateSetAlterer", Properties.Resources.EquipmentStateSetAlterer);
                tvwFlow.ImageList.Images.Add("EquipmentStateAlterer", Properties.Resources.EquipmentStateAlterer);
                tvwFlow.ImageList.Images.Add("Judgement", Properties.Resources.Judgement);
                tvwFlow.ImageList.Images.Add("JudgementCondition", Properties.Resources.JudgementCondition);
                tvwFlow.ImageList.Images.Add("JudgementExpression_Bracket", Properties.Resources.JudgementExpression_Bracket);
                tvwFlow.ImageList.Images.Add("JudgementExpression_Comparison_Length", Properties.Resources.JudgementExpression_Comparison_Length);
                tvwFlow.ImageList.Images.Add("JudgementExpression_Comparison_Value", Properties.Resources.JudgementExpression_Comparison_Value);
                tvwFlow.ImageList.Images.Add("Mapper", Properties.Resources.Mapper);
                tvwFlow.ImageList.Images.Add("Storage", Properties.Resources.Storage);
                tvwFlow.ImageList.Images.Add("Callback", Properties.Resources.Callback);
                tvwFlow.ImageList.Images.Add("Function", Properties.Resources.Function);
                tvwFlow.ImageList.Images.Add("Branch", Properties.Resources.Branch);
                tvwFlow.ImageList.Images.Add("Comment", Properties.Resources.Comment);
                tvwFlow.ImageList.Images.Add("Pauser", Properties.Resources.Pauser);
                tvwFlow.ImageList.Images.Add("EntryPoint", Properties.Resources.EntryPoint);
                
                // --

                designGridOfDetail();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FExportDialog_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {

            }
        }
                
        #endregion
                            
        //------------------------------------------------------------------------------------------------------------------------

        #region btnOk Control Event Handler

        private void btnExport_Click(
            object sender, 
            EventArgs e
            )
        {
            SaveFileDialog dialog = null;
            DialogResult dialogResult;
            string fileName = string.Empty;

            try
            {
                dialog = new SaveFileDialog();
                // --
                dialog.Title = fUIWizard.searchCaption("Export Library to Excel");
                dialog.Filter = "Excel Files | *.xlsx";
                dialog.DefaultExt = "xlsx";
                dialog.InitialDirectory = m_fTcmCore.fOption.libRecentExportPath;
                dialog.FileName = Path.GetFileNameWithoutExtension(m_fTcmCore.fTcmFileInfo.fileName);
                // --
                if (dialog.ShowDialog(m_fTcmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                export(dialog.FileName);

                // --

                // ***
                // folder open
                // ***
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fTcmCore.fUIWizard.generateMessage("Q0006"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.Yes)
                {
                    Process.Start("explorer.exe", dialog.FileName);
                }

                // --                    

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnToggleAll Control Event Handler

        private void btnToggleAll_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                foreach (Infragistics.Win.UltraWinGrid.UltraGridRow row in grdExportItems.Rows)
                {
                    row.Cells[1].Value = !(bool)row.Cells[1].Value;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, this);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end