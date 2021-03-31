/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FLogList.cs
--  Creator         : spike.lee
--  Create Date     : 2011.01.11
--  Description     : FAMate Application Log Viewer Log List Form Class 
--  History         : Created by spike.lee at 2011.01.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;

namespace Nexplant.MC.LogViewer
{
    public partial class FLogList : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FLvwCore m_fLvwCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLogList(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FLogList(
            FLvwCore fLvwCore
            ) 
            : this()
        {
            base.fUIWizard = fLvwCore.fUIWizard;
            m_fLvwCore = fLvwCore;
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
                    m_fLvwCore = null;
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
                this.Text = m_fLvwCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        private void designGridOfDetail(
            )
        {
            try
            {
                grdDetail.addColumns(3, new string[] { "Folder", "Total Count", "Total Size" });
                // --
                grdDetail.setColumnHeaderWidth(120);
                grdDetail.setColumnWidth("Total Count", 100);
                grdDetail.setColumnWidth("Total Size", 100);
                // --
                grdDetail.setColumnHAlign("Total Count", Infragistics.Win.HAlign.Right);
                grdDetail.setColumnHAlign("Total Size", Infragistics.Win.HAlign.Right);

                // --

                grdDetail.DisplayLayout.Override.TipStyleCell = Infragistics.Win.UltraWinGrid.TipStyle.Show;
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

        private void refreshListOfDetail(
            )
        {
            string[] fileList = null;
            FileInfo fileInfo = null;
            long totalCount = 0;
            long totalSize = 0;

            try
            {
                grdDetail.clearColumnValue();

                // --

                fileList = Directory.GetFiles(m_fLvwCore.logPath, "*.dlg");
                for (int i = fileList.Length - 1; i >= 0; i--)
                {
                    fileInfo = new FileInfo(fileList[i]);
                    // --
                    totalCount++;
                    totalSize += fileInfo.Length;
                }

                // --

                grdDetail.setColumnValue("Folder", m_fLvwCore.logPath);
                grdDetail.setColumnValue("Total Count", totalCount.ToString());
                grdDetail.setColumnValue("Total Size", FDataConvert.volumeSizeToString(totalSize, FVolumnOption.KiloByte));
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

        private void designListOfLog(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --
                uds.Band.Columns.Add("File Name");
                uds.Band.Columns.Add("Start Time");
                uds.Band.Columns.Add("Creation Time");
                uds.Band.Columns.Add("Last Write Time");
                uds.Band.Columns.Add("Last Access Time");
                uds.Band.Columns.Add("Size");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Start Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Creation Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Last Write Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Last Access Time"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Center;
                grdList.DisplayLayout.Bands[0].Columns["Size"].CellAppearance.TextHAlign = Infragistics.Win.HAlign.Right;
                // --
                grdList.DisplayLayout.Bands[0].Columns["File Name"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["File Name"].Width = 290;
                grdList.DisplayLayout.Bands[0].Columns["Start Time"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Creation Time"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Last Write Time"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Last Access Time"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Size"].Width = 60;

                // --

                grdList.DisplayLayout.Bands[0].Columns["File Name"].CellAppearance.Image = Properties.Resources.File_Dlg;
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

        private void refreshListOfLog(
            )
        {
            string[] fileList = null;
            FileInfo fileInfo = null;
            object[] cellValues = null;

            try
            {
                grdList.beginUpdate();

                // --

                grdList.removeAllDataRow();
                // --
                btnView.Enabled = false;
                btnDelete.Enabled = false;

                // --

                fileList = Directory.GetFiles(m_fLvwCore.logPath, "*.dlg");
                for (int i = fileList.Length - 1; i >= 0; i--)
                {
                    fileInfo = new FileInfo(fileList[i]);                    
                    // --
                    cellValues = new object[]
                    {
                        fileInfo.Name,
                        FDataConvert.defaultDataTimeFormating(fileInfo.Name.ToString().Substring(0, 17)),
                        fileInfo.CreationTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        fileInfo.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        fileInfo.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss.fff"),
                        FDataConvert.volumeSizeToString(fileInfo.Length, FVolumnOption.KiloByte)
                    };
                    // --
                    grdList.appendDataRow(fileInfo.FullName, cellValues);
                }
                
                // --

                grdList.endUpdate();

                // --                

                grdList.DisplayLayout.Bands[0].SortedColumns.Add("File Name", false);
                if (grdList.Rows.Count > 0)
                {
                    grdList.ActiveRow = grdList.Rows[grdList.Rows.Count - 1];
                    // --
                    btnView.Enabled = true;
                    btnDelete.Enabled = true;
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

        private void viewOfLog(
            )
        {
            FLogViewer fLogViewer = null;
            string fileName = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                if (grdList.activeDataRow == null)
                {
                    return;
                }
                fileName = Path.GetFileName(grdList.activeDataRowKey);

                // --

                foreach (FBaseTabChildForm f in m_fLvwCore.fLvwContainer.fChilds)
                {
                    if (f is FLogViewer)
                    {
                        fLogViewer = (FLogViewer)f;
                        if (Path.GetFileName(fLogViewer.fileName) == fileName)
                        {
                            fLogViewer.refreshLog();
                            fLogViewer.activate();
                            return;
                        }
                    }                    
                }

                // --
                
                fLogViewer = new FLogViewer(m_fLvwCore, m_fLvwCore.logPath + "\\" + fileName);
                m_fLvwCore.fLvwContainer.showChild(fLogViewer);
                fLogViewer.activate();                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fLogViewer = null;
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region FLogList Form Event Handler

        private void FLogList_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfDetail();
                designListOfLog();

                // --

                m_fLvwCore.fOption.fChildFormList.add(this);

                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void FLogList_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshListOfDetail();
                refreshListOfLog();

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        private void FLogList_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fLvwCore.fOption.fChildFormList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region grdList Control Event Handler

        private void grdList_DoubleClickRow(
            object sender, 
            Infragistics.Win.UltraWinGrid.DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                viewOfLog();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_KeyDown(
            object sender,
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --                

                if (e.KeyCode == Keys.Enter)
                {
                    viewOfLog();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
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
            DialogResult dialogResult;
            string[] keys = null;

            try
            {
                FCursor.waitCursor();

                // --

                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fLvwCore.fUIWizard.generateMessage("Q0003", new object[] { "Log File" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                btnDelete.Enabled = false;
                btnView.Enabled = false;

                // --

                keys = grdList.selectedDataRowKeys;

                // --

                foreach (string key in keys)
                {
                    File.Delete(key);
                }

                // --

                grdList.removeDataRows(keys);

                // --

                refreshListOfDetail();
                // --
                if (grdList.Rows.Count > 0)
                {
                    btnDelete.Enabled = true;
                    btnView.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnView Control Event Handler

        private void btnView_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                viewOfLog();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region rstToolbar Control Event Handler

        private void rstToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                grdList.searchGridRow(e.searchWord);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        private void rstToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshListOfDetail();
                refreshListOfLog();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fLvwCore.fWsmCore.fWsmContainer);
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
