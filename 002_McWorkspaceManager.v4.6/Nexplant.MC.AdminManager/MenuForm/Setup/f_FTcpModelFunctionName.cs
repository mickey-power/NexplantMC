/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpModelFunctionName.cs
--  Creator         : mjkim
--  Create Date     : 2015.07.13
--  Description     : FAMate Admin Manager Setup TCP Model Function Name Form Class 
--  History         : Created by mjkim at 2015.07.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public partial class FTcpModelFunctionName : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpModelFunctionName(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpModelFunctionName(
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
            string key = string.Empty;

            try
            {
                key = tabMain.ActiveTab.Key;

                // --

                if (key == "Function Name List")
                {
                    btnDelete.Enabled = grdFunList.activeDataRowKey != string.Empty && m_tranEnabled;
                    // --
                    btnUpdate.Enabled = m_tranEnabled;
                    btnClear.Enabled = grdFunList.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "Function Name")
                {
                    btnDelete.Enabled = grdFun.activeDataRowKey != string.Empty && m_tranEnabled;
                    // --
                    btnUpdate.Enabled = grdFunList.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdFun.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "Parameter Name")
                {
                    btnDelete.Enabled = grdPara.activeDataRowKey != string.Empty && m_tranEnabled;
                    // --
                    btnUpdate.Enabled = grdFun.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdPara.activeDataRowKey != string.Empty && m_tranEnabled;
                }
                else if (key == "Argument")
                {
                    btnDelete.Enabled = grdArg.activeDataRowKey != string.Empty && m_tranEnabled;
                    // --
                    btnUpdate.Enabled = grdPara.activeDataRowKey != string.Empty && m_tranEnabled;
                    btnClear.Enabled = grdArg.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void initPropOfFunctionList(
            )
        {
            try
            {
                pgdFunList.selectedObject = new FPropModelFunctionNameList(m_fAdmCore, pgdFunList, m_tranEnabled);
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

        private void initPropOfFunction(
            )
        {
            try
            {
                pgdFun.selectedObject = new FPropModelFunctionName(m_fAdmCore, pgdFun, grdFunList.activeDataRowKey, m_tranEnabled);
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

        private void initPropOfParameter(
            )
        {
            try
            {
                pgdPara.selectedObject = new FPropModelParameterName(
                    m_fAdmCore, 
                    pgdPara, 
                    grdFunList.activeDataRowKey,
                    grdFun.activeDataRowKey,
                    m_tranEnabled
                    );
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

        private void initPropOfArgument(
            )
        {
            try
            {
                pgdArg.selectedObject = new FPropModelArgument(
                    m_fAdmCore, 
                    pgdArg, 
                    grdFunList.activeDataRowKey,
                    grdFun.activeDataRowKey,
                    grdPara.activeDataRowKey,
                    m_tranEnabled
                    );
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

        private void setPropOfFunctionList(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdFunList.activeDataRow == null)
                {
                    return;
                }
                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                fSqlParams.add("fnl_name", grdFunList.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelFunctionNameList", "SearchFunctionNameList", fSqlParams, true);

                // --

                pgdFunList.selectedObject = new FPropModelFunctionNameList(m_fAdmCore, pgdFunList, dt, m_tranEnabled);
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

        private void setPropOfFunction(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdFun.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                fSqlParams.add("fnl_name", grdFunList.activeDataRowKey);
                fSqlParams.add("fna_name", grdFun.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelFunctionName", "SearchFunctionName", fSqlParams, true);

                // --

                pgdFun.selectedObject = new FPropModelFunctionName(m_fAdmCore, pgdFun, dt, grdFunList.activeDataRowKey, m_tranEnabled);
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

        private void setPropOfParameter(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdPara.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                fSqlParams.add("fnl_name", grdFunList.activeDataRowKey);
                fSqlParams.add("fna_name", grdFun.activeDataRowKey);
                fSqlParams.add("pan_name", grdPara.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelParameterName", "SearchParameterName", fSqlParams, true);

                // --

                pgdPara.selectedObject = new FPropModelParameterName(
                    m_fAdmCore, 
                    pgdPara, 
                    dt, 
                    grdFunList.activeDataRowKey,
                    grdFun.activeDataRowKey,
                    m_tranEnabled
                    );
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

        private void setPropOfArgument(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdArg.activeDataRow == null)
                {
                    return;
                }

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                fSqlParams.add("fnl_name", grdFunList.activeDataRowKey);
                fSqlParams.add("fna_name", grdFun.activeDataRowKey);
                fSqlParams.add("pan_name", grdPara.activeDataRowKey);
                fSqlParams.add("arg_name", grdArg.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelArgument", "SearchArgument", fSqlParams, true);

                // --

                pgdArg.selectedObject = new FPropModelArgument(
                    m_fAdmCore, 
                    pgdArg, 
                    dt, 
                    grdFunList.activeDataRowKey,
                    grdFun.activeDataRowKey,
                    grdPara.activeDataRowKey,
                    m_tranEnabled
                    );
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

        private void designGridOfFunctionList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdFunList.dataSource;
                // --
                uds.Band.Columns.Add("Function Name List");
                uds.Band.Columns.Add("Description");

                // --

                grdFunList.DisplayLayout.Bands[0].Columns["Function Name List"].CellAppearance.Image = Properties.Resources.TmdFunctionNameList;
                // --
                grdFunList.DisplayLayout.Bands[0].Columns["Function Name List"].Header.Fixed = true;
                // --
                grdFunList.DisplayLayout.Bands[0].Columns["Function Name List"].Width = 120;
                grdFunList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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
                uds = grdFun.dataSource;
                // --
                uds.Band.Columns.Add("Function Name List");
                uds.Band.Columns.Add("Function Name");
                uds.Band.Columns.Add("Description");
                
                // --

                grdFun.DisplayLayout.Bands[0].Columns["Function Name List"].CellAppearance.Image = Properties.Resources.TmdFunctionName;
                // --
                grdFun.DisplayLayout.Bands[0].Columns["Function Name List"].Header.Fixed = true;
                grdFun.DisplayLayout.Bands[0].Columns["Function Name"].Header.Fixed = true;
                // --
                grdFun.DisplayLayout.Bands[0].Columns["Function Name List"].Width = 120;
                grdFun.DisplayLayout.Bands[0].Columns["Function Name"].Width = 120;
                grdFun.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfParameter(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdPara.dataSource;
                // --
                uds.Band.Columns.Add("Function Name List");
                uds.Band.Columns.Add("Function Name");
                uds.Band.Columns.Add("Parameter Name");
                uds.Band.Columns.Add("Description");

                // --

                grdPara.DisplayLayout.Bands[0].Columns["Function Name List"].CellAppearance.Image = Properties.Resources.TmdParameterName;
                // --
                grdPara.DisplayLayout.Bands[0].Columns["Function Name List"].Header.Fixed = true;
                grdPara.DisplayLayout.Bands[0].Columns["Function Name"].Header.Fixed = true;
                grdPara.DisplayLayout.Bands[0].Columns["Parameter Name"].Header.Fixed = true;
                // --
                grdPara.DisplayLayout.Bands[0].Columns["Function Name List"].Width = 120;
                grdPara.DisplayLayout.Bands[0].Columns["Function Name"].Width = 120;
                grdPara.DisplayLayout.Bands[0].Columns["Parameter Name"].Width = 120;
                grdPara.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfArgument(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdArg.dataSource;
                // --
                uds.Band.Columns.Add("Function Name List");
                uds.Band.Columns.Add("Function Name");
                uds.Band.Columns.Add("Parameter Name");
                uds.Band.Columns.Add("Argument");
                uds.Band.Columns.Add("Description");

                // --

                grdArg.DisplayLayout.Bands[0].Columns["Function Name List"].CellAppearance.Image = Properties.Resources.TmdArgument;
                // --
                grdArg.DisplayLayout.Bands[0].Columns["Function Name List"].Header.Fixed = true;
                grdArg.DisplayLayout.Bands[0].Columns["Function Name"].Header.Fixed = true;
                grdArg.DisplayLayout.Bands[0].Columns["Parameter Name"].Header.Fixed = true;
                grdArg.DisplayLayout.Bands[0].Columns["Argument"].Header.Fixed = true;
                // --
                grdArg.DisplayLayout.Bands[0].Columns["Function Name List"].Width = 120;
                grdArg.DisplayLayout.Bands[0].Columns["Function Name"].Width = 120;
                grdArg.DisplayLayout.Bands[0].Columns["Parameter Name"].Width = 120;
                grdArg.DisplayLayout.Bands[0].Columns["Argument"].Width = 120;
                grdArg.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfFunctionNameList(
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
                grdFunList.removeAllDataRow();
                grdFun.removeAllDataRow();
                grdPara.removeAllDataRow();
                grdArg.removeAllDataRow();
                grdFunList.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdFun.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdPara.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdArg.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfFunctionList();
                initPropOfFunction();
                initPropOfParameter();
                initPropOfArgument();
                // --
                refreshFunctionTotal();
                refreshParameterTotal();
                refreshArgumentTotal();

                // --
                
                grdFunList.beginUpdate();
                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelFunctionNameList", "ListFunctionNameList", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // Function Name List
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[0];
                        grdFunList.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdFunList.endUpdate();

                // --

                if (grdFunList.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdFunList.activateDataRow(beforeKey);
                    }
                    if (grdFunList.activeDataRow == null)
                    {
                        grdFunList.ActiveRow = grdFunList.Rows[0];
                    }
                }

                // --

                refreshFunctionListTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Function Name List")
                {
                    grdFunList.Focus();
                }
            }
            catch (Exception ex)
            {
                grdFunList.endUpdate();
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

            try
            {
                grdFun.removeAllDataRow();
                grdPara.removeAllDataRow();
                grdArg.removeAllDataRow();
                grdFun.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdPara.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdArg.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfFunction();
                initPropOfParameter();
                initPropOfArgument();
                // --
                // --
                refreshParameterTotal();
                refreshArgumentTotal();

                // --

                if (grdFunList.activeDataRow == null)
                {
                    return;
                }

                // --

                grdFun.beginUpdate();
                                                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                fSqlParams.add("fnl_name", grdFunList.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelFunctionName", "ListFunctionName", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[2].ToString(),   // Function Name List
                            r[0].ToString(),   // Function Name
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[1];
                        grdFun.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdFun.endUpdate();

                // --

                if (grdFun.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdFun.activateDataRow(beforeKey);
                    }
                    if (grdFun.activeDataRow == null)
                    {
                        grdFun.ActiveRow = grdFun.Rows[0];
                    }
                }

                // --

                refreshFunctionTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Function Name")
                {
                    grdFun.Focus();
                }
            }
            catch (Exception ex)
            {
                grdFun.endUpdate();
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

        private void refreshGridOfParameter(
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
                grdPara.removeAllDataRow();
                grdArg.removeAllDataRow();
                grdPara.DisplayLayout.Bands[0].SortedColumns.Clear();
                grdArg.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfParameter();
                initPropOfArgument();
                // --
                refreshArgumentTotal();

                // --

                if (grdFun.activeDataRow == null)
                {
                    return;
                }

                // --

                grdPara.beginUpdate();

                // --
                
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                fSqlParams.add("fnl_name", grdFunList.activeDataRowKey);
                fSqlParams.add("fna_name", grdFun.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelParameterName", "ListParameterName", fSqlParams, false, ref nextRowNumber);                    
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[2].ToString(),   // Function Name List
                            r[3].ToString(),   // Function Name
                            r[0].ToString(),   // Parameter Name
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[2];
                        grdPara.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);
                
                // --

                grdPara.endUpdate();

                // --

                if (grdPara.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdPara.activateDataRow(beforeKey);
                    }
                    if (grdPara.activeDataRow == null)
                    {
                        grdPara.ActiveRow = grdPara.Rows[0];
                    }
                }

                // --

                refreshParameterTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Parameter Name")
                {
                    grdPara.Focus();
                }
            }
            catch (Exception ex)
            {
                grdPara.endUpdate();
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

        private void refreshGridOfArgument(
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
                grdArg.removeAllDataRow();
                grdArg.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfArgument();

                // --

                if (grdPara.activeDataRow == null)
                {
                    return;
                }

                // --

                grdArg.beginUpdate();
                                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("mdl_type", FEapType.TCP.ToString());
                fSqlParams.add("fnl_name", grdFunList.activeDataRowKey);
                fSqlParams.add("fna_name", grdFun.activeDataRowKey);
                fSqlParams.add("pan_name", grdPara.activeDataRowKey);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "ModelArgument", "ListArgument", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[2].ToString(),   // Function Name List
                            r[3].ToString(),   // Function Name
                            r[4].ToString(),   // Parameter Name
                            r[0].ToString(),   // Argument
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[3];
                        grdArg.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdArg.endUpdate();

                // --

                if (grdArg.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdArg.activateDataRow(beforeKey);
                    }
                    if (grdArg.activeDataRow == null)
                    {
                        grdArg.ActiveRow = grdArg.Rows[0];
                    }
                }

                // --

                refreshArgumentTotal();

                // --

                controlButton();

                // --

                if (tabMain.ActiveTab.Key == "Argument")
                {
                    grdArg.Focus();
                }
            }
            catch (Exception ex)
            {
                grdArg.endUpdate();
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

        private void updateGridOfFunctionNameList(
            )
        {
            FPropModelFunctionNameList fPropFunList = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropFunList = (FPropModelFunctionNameList)pgdFunList.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropFunList.FunctionNameList, true, this.fUIWizard, "Function Name List");
                // --
                if (fPropFunList.FunctionNameList.Length > 100)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Function Name List" }));
                }

                // --

                if (fPropFunList.Description.Length > 256)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }
                
                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelFunctionNameListUpdate_In.E_ADMADS_SetModelFunctionNameListUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hFactory, FADMADS_SetModelFunctionNameListUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hUserId, FADMADS_SetModelFunctionNameListUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hLanguage, FADMADS_SetModelFunctionNameListUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hHostIp, FADMADS_SetModelFunctionNameListUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hHostName, FADMADS_SetModelFunctionNameListUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hStep, FADMADS_SetModelFunctionNameListUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.E_FunctionNameList);
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.A_ModelType,
                    FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.D_ModelType,
                    FEapType.TCP.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.A_FunctionNameList,
                    FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.D_FunctionNameList,
                    fPropFunList.FunctionNameList
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.A_Description,
                    FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.D_Description,
                    fPropFunList.Description
                    );

                // --

                FADMADSCaster.ADMADS_SetModelFunctionNameListUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelFunctionNameListUpdate_Out.A_hStatus, FADMADS_SetModelFunctionNameListUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelFunctionNameListUpdate_Out.A_hStatusMessage, FADMADS_SetModelFunctionNameListUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropFunList.FunctionNameList, // Function Name List
                    fPropFunList.Description       // Function List Description
                };

                // --                

                key = fPropFunList.FunctionNameList;
                grdFunList.appendOrUpdateDataRow(key, cellValues);
                grdFunList.activateDataRow(key);

                // --

                refreshFunctionListTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropFunList = null;
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfFunction(
            )
        {
            FPropModelFunctionName fPropFun = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropFun = (FPropModelFunctionName)pgdFun.selectedObject;

                // --

                #region Validation

                if (grdFunList.activeDataRowKey == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0025", new object[] { "Function Name List" }));
                }

                // --

                FCommon.validateName(fPropFun.FunctionName, true, this.fUIWizard, "Function Name");
                // --
                if (fPropFun.FunctionName.Length > 100)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Function Name" }));
                }

                // --

                if (fPropFun.Description.Length > 256)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }
                
                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelFunctionNameUpdate_In.E_ADMADS_SetModelFunctionNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hFactory, FADMADS_SetModelFunctionNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hUserId, FADMADS_SetModelFunctionNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hLanguage, FADMADS_SetModelFunctionNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hHostIp, FADMADS_SetModelFunctionNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hHostName, FADMADS_SetModelFunctionNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hStep, FADMADS_SetModelFunctionNameUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetModelFunctionNameUpdate_In.FFunction.E_Function);
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelFunctionNameUpdate_In.FFunction.A_ModelType,
                    FADMADS_SetModelFunctionNameUpdate_In.FFunction.D_ModelType,
                    FEapType.TCP.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelFunctionNameUpdate_In.FFunction.A_FunctionNameList,
                    FADMADS_SetModelFunctionNameUpdate_In.FFunction.D_FunctionNameList,
                    grdFunList.activeDataRowKey
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelFunctionNameUpdate_In.FFunction.A_Function,
                    FADMADS_SetModelFunctionNameUpdate_In.FFunction.D_Function,
                    fPropFun.FunctionName
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelFunctionNameUpdate_In.FFunction.A_Description,
                    FADMADS_SetModelFunctionNameUpdate_In.FFunction.D_Description,
                    fPropFun.Description
                    );
                
                // --

                FADMADSCaster.ADMADS_SetModelFunctionNameUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelFunctionNameUpdate_Out.A_hStatus, FADMADS_SetModelFunctionNameUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelFunctionNameUpdate_Out.A_hStatusMessage, FADMADS_SetModelFunctionNameUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    grdFunList.activeDataRowKey, // Function Name List
                    fPropFun.FunctionName,       // Function Name
                    fPropFun.Description         // Function Description
                };

                // --                

                key = fPropFun.FunctionName;
                grdFun.appendOrUpdateDataRow(key, cellValues);
                grdFun.activateDataRow(key);

                // --

                refreshFunctionTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropFun = null;
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfParameter(
            )
        {
            FPropModelParameterName fPropPara = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropPara = (FPropModelParameterName)pgdPara.selectedObject;

                // --

                #region Validation

                if (grdFunList.activeDataRowKey == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0025", new object[] { "Function Name List" }));
                }

                // --

                if (grdFun.activeDataRowKey == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0025", new object[] { "Function Name" }));
                }

                // --

                FCommon.validateName(fPropPara.ParameterName, true, this.fUIWizard, "Parameter Name");
                // --
                if (fPropPara.ParameterName.Length > 100)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Parameter Name" }));
                }

                // --

                if (fPropPara.Description.Length > 256)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }
                
                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelParameterNameUpdate_In.E_ADMADS_SetModelParameterNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hFactory, FADMADS_SetModelParameterNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hUserId, FADMADS_SetModelParameterNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hLanguage, FADMADS_SetModelParameterNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hHostIp, FADMADS_SetModelParameterNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hHostName, FADMADS_SetModelParameterNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hStep, FADMADS_SetModelParameterNameUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetModelParameterNameUpdate_In.FParameter.E_Parameter);
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.A_ModelType,
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.D_ModelType,
                    FEapType.TCP.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.A_FunctionNameList,
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.D_FunctionNameList,
                    grdFunList.activeDataRowKey
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.A_Function,
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.D_Function,
                    grdFun.activeDataRowKey
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.A_Parameter,
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.D_Parameter,
                    fPropPara.ParameterName
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.A_Description,
                    FADMADS_SetModelParameterNameUpdate_In.FParameter.D_Description,
                    fPropPara.Description
                    );
                
                // --

                FADMADSCaster.ADMADS_SetModelParameterNameUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelParameterNameUpdate_Out.A_hStatus, FADMADS_SetModelParameterNameUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelParameterNameUpdate_Out.A_hStatusMessage, FADMADS_SetModelParameterNameUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    grdFunList.activeDataRowKey, // Function Name List
                    grdFun.activeDataRowKey,     // Function Name
                    fPropPara.ParameterName,     // Parameter Name
                    fPropPara.Description        // Parameter Description
                };
                // --                
                key = fPropPara.ParameterName;
                grdPara.appendOrUpdateDataRow(key, cellValues);
                grdPara.activateDataRow(key);

                // --

                refreshParameterTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropPara = null;
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void updateGridOfArgument(
            )
        {
            FPropModelArgument fPropArg = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;
            string key = string.Empty;
            object[] cellValues = null;

            try
            {
                fPropArg = (FPropModelArgument)pgdArg.selectedObject;

                // --

                #region Validation

                if (grdFunList.activeDataRowKey == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0025", new object[] { "Function Name List" }));
                }

                // --

                if (grdFun.activeDataRowKey == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0025", new object[] { "Function Name" }));
                }

                // --

                if (grdPara.activeDataRowKey == string.Empty)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0025", new object[] { "Parameter Name" }));
                }

                // --

                FCommon.validateName(fPropArg.Argument, true, this.fUIWizard, "Argument");
                // --
                if (fPropArg.Argument.Length > 100)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Argument" }));
                }

                // --

                if (fPropArg.Description.Length > 256)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelArgumentNameUpdate_In.E_ADMADS_SetModelArgumentNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hFactory, FADMADS_SetModelArgumentNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hUserId, FADMADS_SetModelArgumentNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hLanguage, FADMADS_SetModelArgumentNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hHostIp, FADMADS_SetModelArgumentNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hHostName, FADMADS_SetModelArgumentNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hStep, FADMADS_SetModelArgumentNameUpdate_In.D_hStep, "1");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetModelArgumentNameUpdate_In.FArgument.E_Argument);

                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_ModelType,
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_ModelType,
                    FEapType.TCP.ToString()
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_FunctionNameList,
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_FunctionNameList,
                    grdFunList.activeDataRowKey
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_Function,
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_Function,
                    grdFun.activeDataRowKey
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_Parameter,
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_Parameter,
                    grdPara.activeDataRowKey
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_Argument,
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_Argument,
                    fPropArg.Argument
                    );
                fXmlNodeInEvt.set_elemVal(
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_Description,
                    FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_Description,
                    fPropArg.Description
                    );
                
                // --

                FADMADSCaster.ADMADS_SetModelArgumentNameUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetModelArgumentNameUpdate_Out.A_hStatus, FADMADS_SetModelArgumentNameUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelArgumentNameUpdate_Out.A_hStatusMessage, FADMADS_SetModelArgumentNameUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    grdFunList.activeDataRowKey, // Function Name List
                    grdFun.activeDataRowKey,     // Function Name
                    grdPara.activeDataRowKey,    // Parameter Name
                    fPropArg.Argument,           // Argument
                    fPropArg.Description         // Argument Description
                };
                // --                
                key = fPropArg.Argument;
                grdArg.appendOrUpdateDataRow(key, cellValues);
                grdArg.activateDataRow(key);

                // --

                refreshArgumentTotal();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fPropArg = null;
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfFunctionList(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                grdFunList.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelFunctionNameListUpdate_In.E_ADMADS_SetModelFunctionNameListUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hLanguage, FADMADS_SetModelFunctionNameListUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hFactory, FADMADS_SetModelFunctionNameListUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hUserId, FADMADS_SetModelFunctionNameListUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hHostIp, FADMADS_SetModelFunctionNameListUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hHostName, FADMADS_SetModelFunctionNameListUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameListUpdate_In.A_hStep, FADMADS_SetModelFunctionNameListUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.E_FunctionNameList);
                
                // --

                foreach (UltraDataRow row in grdFunList.selectedDataRows)
                {
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.A_ModelType,
                        FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.D_ModelType,
                        FEapType.TCP.ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.A_FunctionNameList,
                        FADMADS_SetModelFunctionNameListUpdate_In.FFunctionNameList.D_FunctionNameList,
                        row["Function Name List"].ToString()
                        );
                    
                    // --

                    FADMADSCaster.ADMADS_SetModelFunctionNameListUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelFunctionNameListUpdate_Out.A_hStatus, FADMADS_SetModelFunctionNameListUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelFunctionNameListUpdate_Out.A_hStatusMessage, FADMADS_SetModelFunctionNameListUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdFunList.removeDataRow(row.Index);
                }

                // --

                grdFunList.endUpdate();

                // --

                if (grdFunList.Rows.Count == 0)
                {
                    initPropOfFunctionList();
                    initPropOfFunction();
                    initPropOfParameter();
                    initPropOfArgument();
                }                

                // --

                refreshFunctionListTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdFunList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfFunction(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                grdFun.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelFunctionNameUpdate_In.E_ADMADS_SetModelFunctionNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hLanguage, FADMADS_SetModelFunctionNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hFactory, FADMADS_SetModelFunctionNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hUserId, FADMADS_SetModelFunctionNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hHostIp, FADMADS_SetModelFunctionNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hHostName, FADMADS_SetModelFunctionNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelFunctionNameUpdate_In.A_hStep, FADMADS_SetModelFunctionNameUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetModelFunctionNameUpdate_In.FFunction.E_Function);

                // --

                foreach (UltraDataRow row in grdFun.selectedDataRows)
                {
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.A_ModelType,
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.D_ModelType,
                        FEapType.TCP.ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.A_FunctionNameList,
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.D_FunctionNameList,
                        row["Function Name List"].ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.A_Function,
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.D_Function,
                        row["Function Name"].ToString()
                        );
                    
                    // --
                    
                    FADMADSCaster.ADMADS_SetModelFunctionNameUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelFunctionNameUpdate_Out.A_hStatus, FADMADS_SetModelFunctionNameUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelFunctionNameUpdate_Out.A_hStatusMessage, FADMADS_SetModelFunctionNameUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdFun.removeDataRow(row.Index);
                }

                // --

                grdFun.endUpdate();

                // --

                if (grdFun.Rows.Count == 0)
                {
                    initPropOfFunction();
                    initPropOfParameter();
                    initPropOfArgument();
                }

                // --

                refreshFunctionTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdFun.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfParameter(
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                grdPara.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelParameterNameUpdate_In.E_ADMADS_SetModelParameterNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hLanguage, FADMADS_SetModelParameterNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hFactory, FADMADS_SetModelParameterNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hUserId, FADMADS_SetModelParameterNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hHostIp, FADMADS_SetModelParameterNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hHostName, FADMADS_SetModelParameterNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelParameterNameUpdate_In.A_hStep, FADMADS_SetModelParameterNameUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetModelParameterNameUpdate_In.FParameter.E_Parameter);

                // --

                foreach (UltraDataRow row in grdPara.selectedDataRows)
                {
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.A_ModelType,
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.D_ModelType,
                        FEapType.TCP.ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelParameterNameUpdate_In.FParameter.A_FunctionNameList,
                        FADMADS_SetModelParameterNameUpdate_In.FParameter.D_FunctionNameList,
                        row["Function Name List"].ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelParameterNameUpdate_In.FParameter.A_Function,
                        FADMADS_SetModelParameterNameUpdate_In.FParameter.D_Function,
                        row["Function Name"].ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelParameterNameUpdate_In.FParameter.A_Parameter,
                        FADMADS_SetModelParameterNameUpdate_In.FParameter.D_Parameter,
                        row["Parameter Name"].ToString()
                        );
                    
                    // --
                    
                    FADMADSCaster.ADMADS_SetModelParameterNameUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelParameterNameUpdate_Out.A_hStatus, FADMADS_SetModelParameterNameUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelParameterNameUpdate_Out.A_hStatusMessage, FADMADS_SetModelParameterNameUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdPara.removeDataRow(row.Index);
                }

                // --

                grdPara.endUpdate();

                // --

                if (grdPara.Rows.Count == 0)
                {
                    initPropOfParameter();
                    initPropOfArgument();
                }              
  
                // --

                refreshParameterTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdPara.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void deleteGridOfArgument(
           )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInEvt = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                grdArg.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetModelArgumentNameUpdate_In.E_ADMADS_SetModelArgumentNameUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hLanguage, FADMADS_SetModelArgumentNameUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hFactory, FADMADS_SetModelArgumentNameUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hUserId, FADMADS_SetModelArgumentNameUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hHostIp, FADMADS_SetModelArgumentNameUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hHostName, FADMADS_SetModelArgumentNameUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetModelArgumentNameUpdate_In.A_hStep, FADMADS_SetModelArgumentNameUpdate_In.D_hStep, "2");

                // --

                fXmlNodeInEvt = fXmlNodeIn.set_elem(FADMADS_SetModelArgumentNameUpdate_In.FArgument.E_Argument);

                // --

                foreach (UltraDataRow row in grdArg.selectedDataRows)
                {
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.A_ModelType,
                        FADMADS_SetModelFunctionNameUpdate_In.FFunction.D_ModelType,
                        FEapType.TCP.ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_FunctionNameList,
                        FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_FunctionNameList,
                        row["Function Name List"].ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_Function,
                        FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_Function,
                        row["Function Name"].ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_Parameter,
                        FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_Parameter,
                        row["Parameter Name"].ToString()
                        );
                    fXmlNodeInEvt.set_elemVal(
                        FADMADS_SetModelArgumentNameUpdate_In.FArgument.A_Argument,
                        FADMADS_SetModelArgumentNameUpdate_In.FArgument.D_Argument,
                        row["Argument"].ToString()
                        );
                    
                    // --
                    
                    FADMADSCaster.ADMADS_SetModelArgumentNameUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetModelArgumentNameUpdate_Out.A_hStatus, FADMADS_SetModelArgumentNameUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FADMADS_SetModelArgumentNameUpdate_Out.A_hStatusMessage, FADMADS_SetModelArgumentNameUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdArg.removeDataRow(row.Index);
                }

                // --

                grdArg.endUpdate();

                // --

                if (grdArg.Rows.Count == 0)
                {
                    initPropOfArgument();
                }        
        
                // --

                refreshArgumentTotal();

                // --

                controlButton();
            }
            catch (Exception ex)
            {
                grdArg.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInEvt = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshFunctionListTotal(
            )
        {
            try
            {
                lblFunListTotal.Text = grdFunList.Rows.Count.ToString("#,##0");
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
                lblFunTotal.Text = grdFun.Rows.Count.ToString("#,##0");
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

        private void refreshParameterTotal(
            )
        {
            try
            {
                lblParTotal.Text = grdPara.Rows.Count.ToString("#,##0");
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

        private void refreshArgumentTotal(
            )
        {
            try
            {
                lblArgTotal.Text = grdArg.Rows.Count.ToString("#,##0");
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

        #region FModelFunctionName Form Event Handler

        private void FModelFunctionName_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.TcpModelFunctionName);

                // --

                designGridOfFunctionList();
                designGridOfFunction();
                designGridOfParameter();
                designGridOfArgument();

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

        private void FModelFunctionName_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfFunctionNameList(string.Empty);

                // --

                grdFunList.Focus();
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

        private void FModelFunctionName_FormClosing(
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

        private void FTcpModelFunctionName_KeyDown(
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
                    if (tabMain.ActiveTab.Key == "Function Name List")
                    {
                        refreshGridOfFunctionNameList(grdFunList.activeDataRowKey);
                    }
                    else if (tabMain.ActiveTab.Key == "Function Name")
                    {
                        refreshGridOfFunction(grdFun.activeDataRowKey);
                    }
                    else if (tabMain.ActiveTab.Key == "Parameter Name")
                    {
                        refreshGridOfParameter(grdPara.activeDataRowKey);
                    }
                    else
                    {
                        refreshGridOfArgument(grdArg.activeDataRowKey);
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

        #region grdFunList Control Event Handler

        private void grdFunList_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfFunctionList();

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

        private void grdFunList_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfFunctionList();
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

        private void grdFunList_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdFun Control Event Handler

        private void grdFun_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfFunction();

                // --
                
                refreshGridOfParameter(string.Empty);
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

        private void grdFun_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfFunction();
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

        private void grdFun_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.Tabs[2].Selected = true;
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

        #region grdPara Control Event Handler

        private void grdPara_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfParameter();

                // --
                
                refreshGridOfArgument(string.Empty);
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

        private void grdPara_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfParameter();
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

        private void grdPara_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                tabMain.Tabs[3].Selected = true;
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

        #region grdArg Control Event Handler

        private void grdArg_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfArgument();

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

        private void grdArg_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfArgument();
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

                if (tabMain.ActiveTab == tabMain.Tabs[0])
                {
                    updateGridOfFunctionNameList();
                }
                else if (tabMain.ActiveTab == tabMain.Tabs[1])
                {
                    updateGridOfFunction();
                }
                else if (tabMain.ActiveTab == tabMain.Tabs[2])
                {
                    updateGridOfParameter();
                }
                else if (tabMain.ActiveTab == tabMain.Tabs[3])
                {
                    updateGridOfArgument();
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
            try
            {
                FCursor.waitCursor();

                // --

                if (tabMain.ActiveTab == tabMain.Tabs[0])
                {
                    initPropOfFunctionList();
                }
                else if (tabMain.ActiveTab == tabMain.Tabs[1])
                {
                    initPropOfFunction();
                }
                else if (tabMain.ActiveTab == tabMain.Tabs[2])
                {
                    initPropOfParameter();
                }
                else if (tabMain.ActiveTab == tabMain.Tabs[3])
                {
                    initPropOfArgument();
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

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { string.Format("Selected {0}", tabMain.SelectedTab.Text) }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                if (tabMain.ActiveTab == tabMain.Tabs[0])
                {
                    deleteGridOfFunctionList();
                }
                else if (tabMain.ActiveTab == tabMain.Tabs[1])
                {
                    deleteGridOfFunction();
                }
                else if (tabMain.ActiveTab == tabMain.Tabs[2])
                {
                    deleteGridOfParameter();
                }
                else if (tabMain.ActiveTab == tabMain.Tabs[3])
                {
                    deleteGridOfArgument();
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

        #region rstFunList Control Event Handler

        private void rstFunList_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfFunctionNameList(grdFunList.activeDataRowKey);
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

        private void rstFunList_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdFunList.searchGridRow(e.searchWord))
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

        #region rstFun Control Event Handler

        private void rstFun_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --
                
                refreshGridOfFunction(grdFun.activeDataRowKey);
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

        private void rstFun_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdFun.searchGridRow(e.searchWord))
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

        #region rstPara Control Event Handler

        private void rstPara_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfParameter(grdPara.activeDataRowKey);
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

        private void rstPara_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdPara.searchGridRow(e.searchWord))
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

        #region rstArg Control Event Handler

        private void rstArg_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfArgument(grdArg.activeDataRowKey);
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

        private void rstArg_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdArg.searchGridRow(e.searchWord))
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
