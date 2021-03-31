/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSystem.cs
--  Creator         : mj.kim
--  Create Date     : 2011.10.12
--  Description     : FAMate SQL Manager Setup System Form Class 
--  History         : Created by mj.kim at 2011.10.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Infragistics.Win.UltraWinDataSource;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.SqlManager
{
    public partial class FSystem : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSystem(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSystem(
            FSqmCore fSqmCore
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
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
                    m_fSqmCore = null;
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
                this.Text = m_fSqmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
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

        private void designGridOfSystem(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("System");
                uds.Band.Columns.Add("Description");

                // --

                grdList.DisplayLayout.Bands[0].Columns["System"].CellAppearance.Image = Properties.Resources.System;
                // --
                grdList.DisplayLayout.Bands[0].Columns["System"].Header.Fixed = true;
                // --
                grdList.DisplayLayout.Bands[0].Columns["System"].Width = 120;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void refreshGridOfSystem(
            )
        {
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (grdList.activeDataRow != null)
                {
                    beforeKey = grdList.activeDataRowKey;
                }

                // --

                grdList.beginUpdate();
                grdList.removeAllDataRow();

                // --

                do
                {
                    dt = FCommon.requestSystemList(m_fSqmCore, ref nextRowNumber);
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[1],   // System
                            r[2]    // Description
                        };
                        key = (string)cellValues[0];
                        grdList.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate();

                // --

                grdList.DisplayLayout.Bands[0].SortedColumns.Add("System", false);
                // --
                if (grdList.Rows.Count == 0)
                {
                    initPropOfSystem();
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (beforeKey != string.Empty)
                    {
                        grdList.activateDataRow(beforeKey);
                    }
                    // --
                    if (grdList.activeDataRow == null)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
                cellValues = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfSystem(
            )
        {
            try
            {
                pgdProp.selectedObject = (new FPropSystem(m_fSqmCore, pgdProp));
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

        private void setPropOfSystem(
            )
        {
            DataTable dt = null;
            string system = string.Empty;
            
            try
            {
                if (grdList.activeDataRow == null)
                {
                    return;
                }
                system = grdList.activeDataRowKey;

                // --

                dt = FCommon.getSystemInfo(m_fSqmCore, system);

                // --

                pgdProp.selectedObject = new FPropSystem(m_fSqmCore, pgdProp, dt);
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                dt = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FSystem Form Event Handler

        private void FSystem_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfSystem();

                // --

                m_fSqmCore.fOption.fChildList.add(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSystem_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfSystem();

                // --

                setTitle();

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSystem_FormClosing(
            object sender, 
            FormClosingEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_fSqmCore.fOption.fChildList.remove(this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
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

                setPropOfSystem();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void grdList_Enter(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfSystem();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
            FPropSystem fPropSystem = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSys = null;
            FXmlNode fXmlNodeOut = null;
            object[] cellValues = null;
            string key = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                fPropSystem = (FPropSystem)pgdProp.selectedObject;

                // --

                #region Validation

                FCommon.validateName(fPropSystem.System, true, this.fUIWizard);

                #endregion

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSystemUpdate_In.E_SQMSQS_SetSystemUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemUpdate_In.A_hLanguage, FSQMSQS_SetSystemUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemUpdate_In.A_hStep, FSQMSQS_SetSystemUpdate_In.D_hStep, "1");
                // --
                fXmlNodeInSys = fXmlNodeIn.set_elem(FSQMSQS_SetSystemUpdate_In.FSystem.E_System);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemUpdate_In.FSystem.A_UniqueId, FSQMSQS_SetSystemUpdate_In.FSystem.D_UniqueId, fPropSystem.ID);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemUpdate_In.FSystem.A_System, FSQMSQS_SetSystemUpdate_In.FSystem.D_System, fPropSystem.System);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemUpdate_In.FSystem.A_Description, FSQMSQS_SetSystemUpdate_In.FSystem.D_Description, fPropSystem.Description);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemUpdate_In.FSystem.A_StandardDatabase, FSQMSQS_SetSystemUpdate_In.FSystem.D_StandardDatabase, fPropSystem.StandardDb.ToString());
                // --

                FSQMSQSCaster.SQMSQS_SetSystemUpdate_Req(
                    m_fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemUpdate_Out.A_hStatus, FSQMSQS_SetSystemUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemUpdate_Out.A_hStatusMessage, FSQMSQS_SetSystemUpdate_Out.D_hStatusMessage));
                }

                // --

                cellValues = new object[]
                {
                    fPropSystem.System,
                    fPropSystem.Description
                };
                key = fPropSystem.System;
                grdList.appendOrUpdateDataRow(key, cellValues);
                grdList.activateDataRow(key);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSys = null;
                fXmlNodeOut = null;
                cellValues = null;

                // --

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

                initPropOfSystem();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSys = null;
            FXmlNode fXmlNodeOut = null;
            DialogResult dialogResult;

            try
            {
                FCursor.waitCursor();

                // --

                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected System" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSystemUpdate_In.E_SQMSQS_SetSystemUpdate_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemUpdate_In.A_hLanguage, FSQMSQS_SetSystemUpdate_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemUpdate_In.A_hStep, FSQMSQS_SetSystemUpdate_In.D_hStep, "2");
                // --
                fXmlNodeInSys = fXmlNodeIn.set_elem(FSQMSQS_SetSystemUpdate_In.FSystem.E_System);

                // --

                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemUpdate_In.FSystem.A_System, FSQMSQS_SetSystemUpdate_In.FSystem.D_System, (string)row["System"]);
                    // --
                    FSQMSQSCaster.SQMSQS_SetSystemUpdate_Req(
                        m_fSqmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemUpdate_Out.A_hStatus, FSQMSQS_SetSystemUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemUpdate_Out.A_hStatusMessage, FSQMSQS_SetSystemUpdate_Out.D_hStatusMessage));
                    }

                    // --

                    grdList.removeDataRow(row.Index);
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfSystem();
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSys = null;
                fXmlNodeOut = null;

                // --

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
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSys = null;
            FXmlNode fXmlNodeInDbs = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutSys = null;
            FFtp fFtp = null;
            FDatabaseSelector dialog = null;
            FolderBrowserDialog fbd = null;
            DialogResult dialogResult;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;
            string[] downDbList = null;

            try
            {
                FCursor.waitCursor();

                // --

                dialog = new FDatabaseSelector(
                    m_fSqmCore
                    );
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }

                fbd = new FolderBrowserDialog();
                fbd.SelectedPath = m_fSqmCore.fOption.recentDownloadPath;
                if (fbd.ShowDialog() == DialogResult.Cancel)
                {
                    return;
                }
                m_fSqmCore.fOption.recentDownloadPath = fbd.SelectedPath;

                // --

                // ***
                // FTP Create
                // ***
                fFtp = FCommon.createFtp(m_fSqmCore);

                // --

                tempFilePath = Path.Combine(m_fSqmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSystemDownload_In.E_SQMSQS_SetSystemDownload_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemDownload_In.A_hLanguage, FSQMSQS_SetSystemDownload_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemDownload_In.A_hStep, FSQMSQS_SetSystemDownload_In.D_hStep, "1");
                // --
                fXmlNodeInDbs = fXmlNodeIn.set_elem(FSQMSQS_SetSystemDownload_In.FDatabase.E_Database);

                // --

                downDbList = m_fSqmCore.fOption.downloadDatabase.Split(';');
                // --
                foreach (string db in downDbList)
                {
                    fXmlNodeInDbs.add_elemVal(FSQMSQS_SetSystemDownload_In.FDatabase.A_Type, FSQMSQS_SetSystemDownload_In.FDatabase.D_Type, db);
                }

                // --

                fXmlNodeInSys = fXmlNodeIn.set_elem(FSQMSQS_SetSystemDownload_In.FSystem.E_System);
                // --
                foreach (UltraDataRow row in grdList.selectedDataRows)
                {
                    fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemDownload_In.FSystem.A_System, FSQMSQS_SetSystemDownload_In.FSystem.D_System, (string)row["System"]);
                    // --
                    FSQMSQSCaster.SQMSQS_SetSystemDownload_Req(
                        m_fSqmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemDownload_Out.A_hStatus, FSQMSQS_SetSystemDownload_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemDownload_Out.A_hStatusMessage, FSQMSQS_SetSystemDownload_Out.D_hStatusMessage));
                    }

                    // ***
                    // FTP File download
                    // ***
                    fXmlNodeOutSys = fXmlNodeOut.get_elem(FSQMSQS_SetSystemDownload_Out.FSystem.E_System);
                    zipFileName = fXmlNodeOutSys.get_elemVal(FSQMSQS_SetSystemDownload_Out.FSystem.A_FilePath, FSQMSQS_SetSystemDownload_Out.FSystem.D_FilePath);

                    // --

                    fFtp.downloadFiles(tempFilePath, zipFileName);
                    fFtp.deleteFiles(zipFileName);

                    // --
                    F7Zip.unpack(tempFilePath + "\\" + zipFileName, fbd.SelectedPath);
                }

                // ***
                // Temp Directory delete
                // ***
                Directory.Delete(tempFilePath, true);
                
                // --
                
                // ***
                // Folder open
                // ***
                dialogResult = FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fUIWizard.generateMessage("Q0005"),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    );
                if (dialogResult == DialogResult.No)
                {
                    return;
                }

                // -- 

                Process.Start("explorer.exe", fbd.SelectedPath);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                if (fbd != null)
                {
                    fbd.Dispose();
                    fbd = null;
                }

                // --

                if (fFtp != null)
                {
                    fFtp.Dispose();
                    fFtp = null;
                }

                // --

                fXmlNodeIn = null;
                fXmlNodeInSys = null;
                fXmlNodeOut = null;
                fXmlNodeOutSys = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnMigration Control Event Handler
        
        private void btnMigration_Click(
            object sender, 
            EventArgs e
            )
        {
            FPropSystem fPropSys = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSys = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fSqmCore.fUIWizard.generateMessage("Q0022", new object[] { "Migration" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                fPropSys = (FPropSystem)pgdProp.selectedObject;
                
                // --
                
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSystemMigration_In.E_SQMSQS_SetSystemMigration_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemMigration_In.A_hLanguage, FSQMSQS_SetSystemMigration_In.D_hLanguage, m_fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemMigration_In.A_hStep, FSQMSQS_SetSystemMigration_In.D_hStep, "1");

                // --

                fXmlNodeInSys = fXmlNodeIn.set_elem(FSQMSQS_SetSystemMigration_In.FSystem.E_System);
                // --
                foreach (UltraDataRow r in grdList.selectedDataRows)
                {
                    fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemMigration_In.FSystem.A_System, FSQMSQS_SetSystemMigration_In.FSystem.D_System, r[0].ToString());
                    // --
                    FSQMSQSCaster.SQMSQS_SetSystemMigration_Req(
                        m_fSqmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemMigration_Out.A_hStatus, FSQMSQS_SetSystemMigration_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemMigration_Out.A_hStatusMessage, FSQMSQS_SetSystemMigration_Out.D_hStatusMessage));
                    }
                }
                
                // -- 

                FMessageBox.showInformation(FConstants.ApplicationName, m_fSqmCore.fWsmCore.fUIWizard.generateMessage("M0012"), this);
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            { 
            
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

                refreshGridOfSystem();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
                    FMessageBox.showInformation("Search", m_fSqmCore.fWsmCore.fUIWizard.generateMessage("M0004", new object[] { e.searchWord }), this);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
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
