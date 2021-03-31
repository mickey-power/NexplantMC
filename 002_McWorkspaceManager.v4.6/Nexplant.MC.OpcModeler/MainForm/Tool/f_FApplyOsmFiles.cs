/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2015 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FMultiEditOsmFile.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2015.11.06
--  Description     : FAMate Opc Modeler - Mult Edit Osm File Form Class 
--  History         : Created by Jeff.Kim at 2015.11.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.Core.FaOpcDriver;

namespace Nexplant.MC.OpcModeler
{
    public partial class FApplyOsmFiles : Nexplant.MC.Core.FaUIs.FBaseControlDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FApplyOsmFiles(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FApplyOsmFiles(
            FOpmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fOpmCore = fAdmCore;
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
                    m_fOpmCore = null;
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

        private void setTitle(
            )
        {
            try
            {
                this.Text = m_fOpmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                base.fUIWizard.changeControlCaption(mnuMenu);
                // --
                setTitle();
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

        private void designGridOfOsmFile(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("File Name");
                uds.Band.Columns.Add("Dir.");
                uds.Band.Columns.Add("Result");
                uds.Band.Columns.Add("Proc. Time (ms)");
                uds.Band.Columns.Add("Message");

                // --

                grdList.DisplayLayout.Bands[0].Columns["File Name"].CellAppearance.Image = Properties.Resources.File_Osm;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdList.DisplayLayout.Bands[0].Columns["File Name"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["File Name"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Dir."].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Result"].Width = 80;
                grdList.DisplayLayout.Bands[0].Columns["Proc. Time (ms)"].Width = 90;
                grdList.DisplayLayout.Bands[0].Columns["Message"].Width = 80;

                // --

                grdList.ImageList = new ImageList();
                // --
                grdList.ImageList.Images.Add("Transaction_Target", Properties.Resources.Trn_Target);
                grdList.ImageList.Images.Add("Transaction_Result_Success", Properties.Resources.Trn_Result_Success);
                grdList.ImageList.Images.Add("Transaction_Result_Fail", Properties.Resources.Trn_Result_Fail);
                grdList.ImageList.Images.Add("Transaction_Result_Cancel", Properties.Resources.Trn_Result_Cancel);
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

        private Image getImageOfOsmFile(
            string result
            )
        {
            try
            {
                if (result == "Success")
                {
                    return grdList.ImageList.Images["Transaction_Result_Success"];
                }
                else if (result == "Fail")
                {
                    return grdList.ImageList.Images["Transaction_Result_Fail"];
                }
                else if (result == "Cancel")
                {
                    return grdList.ImageList.Images["Transaction_Result_Cancel"];
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
        
        //------------------------------------------------------------------------------------------------------------------------

        private void osmAttach(
            string[] fileList
            )
        {
            object[] cellValues = null;
            int index = 0;

            try
            {
                grdList.beginUpdate(false);

                // --

                if (mnuMenu.Tools["Attach"].SharedProps.Enabled == false)
                {
                    procMenuClear();
                }

                // --

                foreach (string osmFile in fileList)
                {
                    cellValues = new object[] {
                        System.IO.Path.GetFileName(osmFile),
                        System.IO.Path.GetDirectoryName(osmFile)
                        };
                    index = grdList.appendOrUpdateDataRow(osmFile, cellValues).Index;
                    grdList.Rows[index].Cells["File Name"].Appearance.Image = grdList.ImageList.Images["Transaction_Target"];
                }

                // --

                grdList.endUpdate(false);

                // --

                if (grdList.activeDataRow == null)
                {
                    grdList.ActiveRow = grdList.Rows[0];
                }

                // --

                if (grdList.Rows.Count > 0)
                {
                    btnApply.Enabled = true;
                }
                // --.
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuAttach(
            )
        {
            OpenFileDialog dialog = null;

            try
            {
                // --

                dialog = new OpenFileDialog();
                dialog.Title = fUIWizard.searchCaption("Open OPC Modeling File");
                dialog.Filter = "OPC Modeling Files | *.osm";
                dialog.DefaultExt = "osm";
                dialog.Multiselect = true;
                dialog.InitialDirectory = m_fOpmCore.fOption.libRecentOpenPath;
                // --
                if (dialog.ShowDialog(m_fOpmCore.fWsmCore.fWsmContainer) == DialogResult.Cancel)
                {
                    return;
                }

                // --

                osmAttach(dialog.FileNames);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (dialog != null)
                {
                    dialog.Dispose();
                    dialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuDetach(
            )
        {
            try
            {
                if (grdList.Rows.Count == 0)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                grdList.removeDataRows(grdList.selectedDataRowKeys);

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    btnApply.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procMenuClear(
            )
        {
            try
            {
                grdList.beginUpdate();

                // --

                grdList.removeAllDataRow();

                // --

                grdList.endUpdate();

                // --

                lblSuccess.Text = "0";
                lblFail.Text = "0";

                // --

                mnuMenu.Tools["Attach"].SharedProps.Enabled = true;
                mnuMenu.Tools["Detach"].SharedProps.Enabled = true;
                btnApply.Enabled = false;
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public void action(
            )
        {
            FOpcDriver fOpcDriver = null;
            string osmFile = string.Empty;
            string result = string.Empty;
            string msg = string.Empty;
            string resultMsg = string.Empty;
            Stopwatch sw = null;
            int sCnt = 0;
            int fCnt = 0;
            // --

            try
            {
                mnuMenu.Tools["Attach"].SharedProps.Enabled = false;
                mnuMenu.Tools["Detach"].SharedProps.Enabled = false;
                btnApply.Enabled = false;
               
                sw = new Stopwatch();

                // --

                foreach (UltraDataRow r in grdList.dataSource.Rows)
                {
                    sw.Reset();
                    sw.Start();
                    // --
                    Application.DoEvents();

                    // --

                    osmFile = grdList.getDataRowKey(r.Index);

                    // --

                    grdList.activateDataRow(osmFile);

                    // --
                    try
                    {
                        // --

                        fOpcDriver = new FOpcDriver(m_fOpmCore.fWsmCore.appPath + "\\License\\license.lic", FOpcRunMode.WorkspaceManager);
                        fOpcDriver.openModelingFile(osmFile);

                        // --
                        if (fOpcDriver.substitute(out resultMsg))
                        {
                            grdList.Rows[r.Index].Cells["File Name"].Appearance.Image = getImageOfOsmFile("Success");
                            result = this.fUIWizard.searchCaption("Success");
                            msg = this.fUIWizard.generateMessage("M0012");
                            sCnt++;
                        }
                        else
                        {
                            grdList.Rows[r.Index].Cells["File Name"].Appearance.Image = getImageOfOsmFile("Fail");
                            result = this.fUIWizard.searchCaption("Fail");
                            msg = resultMsg;
                            fCnt++;
                        }

                        // --

                        fOpcDriver.saveModelingFile(osmFile);
                    }
                    catch (Exception ex)
                    {
                        grdList.Rows[r.Index].Cells["File Name"].Appearance.Image = getImageOfOsmFile("Fail");
                        result = this.fUIWizard.searchCaption("Fail");
                        msg = ex.Message;
                        fCnt++;
                    }
                    finally
                    {
                        if (fOpcDriver != null)
                        {
                            fOpcDriver.Dispose();
                            fOpcDriver = null;
                        }
                    }

                    // --

                    sw.Stop();

                    // --

                    r["Result"] = result;
                    r["Proc. Time (ms)"] = sw.ElapsedMilliseconds.ToString();
                    r["Message"] = msg;
                }

                // --

                lblSuccess.Text = sCnt.ToString();
                lblFail.Text = fCnt.ToString();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FApplyOsmFiles Form Event Handler

        private void FApplyOsmFiles_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfOsmFile();

                // --
                btnApply.Enabled = false;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FApplyOsmFiles_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fOpmCore.fOption.fChildFormList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FApplyOsmFiles_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fOpmCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
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

                if (e.Tool.Key == "Attach")
                {
                    procMenuAttach();
                }
                else if (e.Tool.Key == "Detach")
                {
                    procMenuDetach();
                }
                else if (e.Tool.Key == "Clear")
                {
                    procMenuClear();
                }                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion


        //------------------------------------------------------------------------------------------------------------------------

        #region btnApply Control Event Handler

        private void btnApply_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                this.BeginInvoke(new MethodInvoker(delegate() {
                    action();
                }));
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                // --

                FCursor.defaultCursor();
            }
        }

        #endregion
                     
        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
