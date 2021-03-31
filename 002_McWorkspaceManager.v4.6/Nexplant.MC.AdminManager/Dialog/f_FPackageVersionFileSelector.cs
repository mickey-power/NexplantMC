/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FPackageVersionSelector.cs
--  Creator         : mjkim
--  Create Date     : 2012.03.29
--  Description     : FAMate Admin Manager Package Version Selector Form Class 
--  History         : Created by mjkim at 2011.03.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Drawing;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FPackageVersionFileSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2012.07.17 by spike.lee
        // m_pathList와 m_fileList 변수명의 의미를 명확이 알 수 없어 m_oldFileList와 m_newFileList로 변경함
        // *** 

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private FPackageVersionFile[] m_oldFileList = null;
        private FPackageVersionFile[] m_newFileList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPackageVersionFileSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPackageVersionFileSelector(
            FAdmCore fAdmCore,
            FPackageVersionFile[] oldFileList,
            FPackageVersionFile[] newFileList
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_oldFileList = oldFileList;
            m_newFileList = newFileList;
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
                    m_oldFileList = null;
                    m_newFileList = null;
                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FPackageVersionFile[] newFileList
        {
            get
            {
                try
                {
                    return m_newFileList;
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

        private void designGridOfList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;
                // --                
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Type");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Name"].Width = 100;
                grdList.DisplayLayout.Bands[0].Columns["Type"].Width = 80;
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

        private void designGridOfExeFile(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdExeFile.dataSource;
                // --
                uds.Band.Columns.Add("File");
                uds.Band.Columns.Add("Delete");

                // --

                grdExeFile.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;
                grdExeFile.DisplayLayout.Bands[0].ColHeadersVisible = false;
                grdExeFile.DisplayLayout.Bands[0].HeaderVisible = true;
                grdExeFile.DisplayLayout.Bands[0].Header.Caption = "Execution File";
                grdExeFile.DisplayLayout.Bands[0].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                // --
                grdExeFile.DisplayLayout.Bands[0].Columns["File"].ButtonDisplayStyle = ButtonDisplayStyle.Always;
                grdExeFile.DisplayLayout.Bands[0].Columns["File"].CellButtonAppearance.BorderColor = Color.Transparent;
                grdExeFile.DisplayLayout.Bands[0].Columns["File"].CellButtonAppearance.Image = Properties.Resources.FileAdd;
                grdExeFile.DisplayLayout.Bands[0].Columns["File"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                // --
                grdExeFile.DisplayLayout.Bands[0].Columns["Delete"].ButtonDisplayStyle = ButtonDisplayStyle.Always;
                grdExeFile.DisplayLayout.Bands[0].Columns["Delete"].CellButtonAppearance.BorderColor = Color.Transparent; 
                grdExeFile.DisplayLayout.Bands[0].Columns["Delete"].CellButtonAppearance.Image = Properties.Resources.FileDelete;
                grdExeFile.DisplayLayout.Bands[0].Columns["Delete"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                grdExeFile.DisplayLayout.Bands[0].Columns["Delete"].MaxWidth = 18;
                grdExeFile.DisplayLayout.Bands[0].Columns["Delete"].MinWidth = 18;
                grdExeFile.DisplayLayout.Bands[0].Columns["Delete"].Width = 18;
                // --
                grdExeFile.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;

                // --

                grdExeFile.DisplayLayout.Bands[0].Override.ActiveRowAppearance.BackColor2 = Color.Transparent;
                // --
                grdExeFile.DisplayLayout.Bands[0].Override.BorderStyleCell = Infragistics.Win.UIElementBorderStyle.Dotted;
                grdExeFile.DisplayLayout.Bands[0].Override.BorderStyleRow = Infragistics.Win.UIElementBorderStyle.Dotted;
                grdExeFile.DisplayLayout.Bands[0].Override.CellAppearance.BorderColor = Color.Transparent;
                grdExeFile.DisplayLayout.Bands[0].Override.CellPadding = 0;
                grdExeFile.DisplayLayout.Bands[0].Override.RowAppearance.BorderColor = Color.Transparent;
                // --
                grdExeFile.DisplayLayout.Bands[0].Override.SelectedRowAppearance.BackColor2 = Color.Transparent;
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

        private void designGridOfEtcFile(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEtcFile.dataSource;
                // --
                uds.Band.Columns.Add("File");
                uds.Band.Columns.Add("Delete");

                // --

                grdEtcFile.DisplayLayout.AutoFitStyle = AutoFitStyle.ResizeAllColumns;

                // --

                grdEtcFile.DisplayLayout.Bands[0].ColHeadersVisible = false;
                // --
                grdEtcFile.DisplayLayout.Bands[0].Columns["File"].ButtonDisplayStyle = ButtonDisplayStyle.Always;
                grdEtcFile.DisplayLayout.Bands[0].Columns["File"].CellButtonAppearance.BorderColor = Color.Transparent;
                grdEtcFile.DisplayLayout.Bands[0].Columns["File"].CellButtonAppearance.Image = Properties.Resources.FileAdd;
                grdEtcFile.DisplayLayout.Bands[0].Columns["File"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                // --
                grdEtcFile.DisplayLayout.Bands[0].Columns["Delete"].ButtonDisplayStyle = ButtonDisplayStyle.Always;
                grdEtcFile.DisplayLayout.Bands[0].Columns["Delete"].CellButtonAppearance.BorderColor = Color.Transparent;
                grdEtcFile.DisplayLayout.Bands[0].Columns["Delete"].CellButtonAppearance.Image = Properties.Resources.FileDelete;
                grdEtcFile.DisplayLayout.Bands[0].Columns["Delete"].Style = Infragistics.Win.UltraWinGrid.ColumnStyle.EditButton;
                grdEtcFile.DisplayLayout.Bands[0].Columns["Delete"].MaxWidth = 18;
                grdEtcFile.DisplayLayout.Bands[0].Columns["Delete"].MinWidth = 18;
                grdEtcFile.DisplayLayout.Bands[0].Columns["Delete"].Width = 18;
                // --
                grdEtcFile.DisplayLayout.Bands[0].HeaderVisible = true;
                grdEtcFile.DisplayLayout.Bands[0].Header.Caption = "Etc. File";
                grdEtcFile.DisplayLayout.Bands[0].Header.Appearance.TextHAlign = Infragistics.Win.HAlign.Left;
                // --
                grdEtcFile.DisplayLayout.Bands[0].Override.TemplateAddRowAppearance.BackColor = Color.WhiteSmoke;

                // --
                
                grdEtcFile.DisplayLayout.CaptionVisible = Infragistics.Win.DefaultableBoolean.False;
                grdEtcFile.DisplayLayout.Override.AllowAddNew = AllowAddNew.TemplateOnBottom;
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

        private void refreshGridOfList(
            )
        {
            object[] cellValues = null;
            string key = string.Empty;
            int index = 0;

            try
            {
                if (m_oldFileList == null)
                {
                    return;
                }

                // --

                grdList.beginUpdate(false);
                grdList.removeAllDataRow();

                // --

                foreach (FPackageVersionFile f in m_oldFileList)
                {
                    cellValues = new object[] {
                        f.name,   // Name
                        f.type    // Type
                        };
                    key = (string)cellValues[0];
                    index = grdList.appendDataRow(key, cellValues).Index;

                    // --

                    grdList.Rows[index].Cells[0].Appearance.Image = (f.type == FPackageFileType.Execution.ToString() ? Properties.Resources.File_Exe : Properties.Resources.File_Etc);
                }

                // --

                grdList.endUpdate(false);
            }
            catch (Exception ex)
            {
                grdList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfExeFile(
            )
        {
            object[] cellValues = null;
            string key = string.Empty;

            try
            {
                grdExeFile.beginUpdate();
                
                // --

                if (m_newFileList == null)
                {
                    cellValues = new object[] {
                        string.Empty,
                        string.Empty
                        };
                }
                else
                {
                    cellValues = new object[] {
                        m_newFileList[0].name,
                        m_newFileList[0].type
                        };
                }
                key = (string)cellValues[0];
                grdExeFile.appendDataRow(key, cellValues);

                // --

                grdExeFile.endUpdate();
            }
            catch (Exception ex)
            {
                grdExeFile.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEtcFile(
            )
        {
            object[] cellValues = null;
            string key = string.Empty;

            try
            {
                if (m_newFileList == null)
                {
                    return;
                }

                // --

                grdEtcFile.beginUpdate();
                grdEtcFile.removeAllDataRow();

                // --
                
                for (int i = 1; i < m_newFileList.GetLength(0); i++)
                {
                    cellValues = new object[] {
                        m_newFileList[i].name,   // Name
                        m_newFileList[i].type    // Type
                        };
                    key = (string)cellValues[0];
                    grdEtcFile.appendDataRow(key, cellValues);
                }

                // --

                grdEtcFile.endUpdate();
            }
            catch (Exception ex)
            {
                grdEtcFile.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------  

        private string[] openFile(
            string defaultExt,
            bool multiSelect
            )
        {
            OpenFileDialog openFileDialog = null;

            try
            {
                openFileDialog = new OpenFileDialog();
                openFileDialog.DefaultExt = defaultExt;
                openFileDialog.Filter = string.Format("{0} files (*.{0})|*.{0}", defaultExt);
                openFileDialog.FileName = null;
                openFileDialog.Multiselect = multiSelect;
                // --
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileNames;
                }
                return null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                openFileDialog = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------  

        private void validateEtcFile(
            string fileName
            )
        {
            try
            {
                // ***
                // 2012.07.17 by spike.lee
                // Cells[0].ToString()으로 Validation 안되는 문제 처리 및 오류 메시지 수정
                // ***
                if (grdExeFile.Rows[0].Cells[0].Text == fileName)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0008", new object[] {"Selected File"}));
                }

                foreach (UltraGridRow r in grdEtcFile.Rows)
                {
                    if (r.Cells[0].Text == fileName)
                    {
                        FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0008", new object[] { "Selected File" }));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FPackageVersionFileSelector Form Event Handler

        private void FPackageVersionFileSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfList();
                designGridOfExeFile();
                designGridOfEtcFile();
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

        private void FPackageVersionFileSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfList();
                refreshGridOfExeFile();
                refreshGridOfEtcFile();
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
            int index = 0;

            try
            {
                FCursor.waitCursor();

                // --

                if (grdExeFile.Rows[0].Cells[0].Text.Trim() == string.Empty)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0025", new object[] { "Execution File" }));
                }

                if (grdEtcFile.Rows.Count > 49)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0005", new object[] { "Etc File Count" }));
                }

                // --

                m_newFileList = new FPackageVersionFile[grdEtcFile.Rows.Count + 1];
                m_newFileList[0] = new FPackageVersionFile(grdExeFile.Rows[0].Cells[0].Text, FPackageFileType.Execution.ToString());
                for (int i = 0; i < grdEtcFile.Rows.Count; i++)
                {
                    index = i + 1;
                    m_newFileList[index] = new FPackageVersionFile(grdEtcFile.Rows[i].Cells[0].Text, FPackageFileType.Etc.ToString());
                }

                // --

                DialogResult = DialogResult.OK;
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

        #region ExeGrid Control Event Handler

        private void grdExeFile_ClickCellButton(
            object sender, 
            CellEventArgs e
            )
        {
            string[] fileNames = null;

            try
            {
                if (e.Cell.Column.Key == "File")
                {
                    fileNames = openFile("exe", false);
                    if (fileNames == null)
                    {
                        return;
                    }

                    // --

                    foreach (UltraGridRow row in grdEtcFile.Rows)
                    {
                        // ***
                        // 2012.07.17 by spike.lee
                        // Cells[0].ToString()으로 Validation 안되는 문제 처리 및 오류 메시지 수정
                        // ***
                        if (row.Cells[0].Text == fileNames[0])
                        {
                            FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0008", new object[] { "Selected File" }));
                        }
                    }
                    e.Cell.Value = fileNames[0];
                    //e.Cell.Appearance.Image = Properties.Resources.File;
                }
                else if (e.Cell.Column.Key == "Delete")
                {
                    e.Cell.Row.Cells[0].Value = string.Empty;
                    e.Cell.Row.Cells[0].Appearance.Image = null;
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdExeFile_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.KeyCode == Keys.F4)
                {
                    grdExeFile_ClickCellButton(sender, new CellEventArgs(grdExeFile.ActiveRow.Cells["File"]));
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    grdExeFile_ClickCellButton(sender, new CellEventArgs(grdExeFile.ActiveRow.Cells["Delete"]));
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

        #region ExeGrid Control Event Handler

        private void grdEtcFile_ClickCellButton(
            object sender, 
            CellEventArgs e
            )
        {
            string[] fileNames = null;
            int rowIndex = -1;

            try
            {
                rowIndex = e.Cell.Row.Index;

                // --

                if (e.Cell.Column.Key == "File")
                {
                    fileNames = openFile("*", true);
                    if (fileNames == null)
                    {
                        return;
                    }

                    // --

                    validateEtcFile(fileNames[0]);
                    grdEtcFile.insertBeforeDataRow(rowIndex++, fileNames[0], new object[] { fileNames[0] });
                    // --
                    for (int i = 1; i < fileNames.Length; i++)
                    {
                        validateEtcFile(fileNames[i]);
                        grdEtcFile.insertBeforeDataRow(rowIndex++, fileNames[i], new object[] { fileNames[i] });
                    }

                    // --

                    if (grdEtcFile.Rows[rowIndex].Cells[0].Text != string.Empty)
                    {
                        grdEtcFile.removeDataRow(rowIndex);
                        grdEtcFile.ActiveRow = grdEtcFile.Rows[rowIndex - 1];
                    }
                }
                else if (e.Cell.Column.Key == "Delete")
                {
                    if (e.Cell.Row.Cells[0].Value.ToString() != string.Empty)
                    {
                        grdEtcFile.removeDataRow(rowIndex);
                        if (grdEtcFile.Rows.Count > rowIndex && grdEtcFile.Rows[rowIndex].Cells[0].Text != string.Empty)
                        {
                            grdEtcFile.ActiveRow = grdEtcFile.Rows[rowIndex];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fAdmCore.fWsmCore.fWsmContainer);
            }
            finally
            {

            }

        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdEtcFile_KeyDown(
            object sender, 
            KeyEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.KeyCode == Keys.F4)
                {
                    grdEtcFile_ClickCellButton(sender, new CellEventArgs(grdEtcFile.ActiveRow.Cells["File"]));
                }
                else if (e.KeyCode == Keys.Delete)
                {
                    grdEtcFile_ClickCellButton(sender, new CellEventArgs(grdEtcFile.ActiveRow.Cells["Delete"]));
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