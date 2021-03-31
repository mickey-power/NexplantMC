/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FHostDriver.cs
--  Creator         : mjkim
--  Create Date     : 2012.04.25
--  Description     : FAMate Admin Manager Setup Host Driver Form Class 
--  History         : Created by mjkim at 2012.04.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;

namespace Nexplant.MC.AdminManager
{
    public partial class FHostDriver : Nexplant.MC.Core.FaUIs.FBaseTabChildDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private bool m_tranEnabled = false;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostDriver(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDriver(
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
            try
            {
                btnDelete.Enabled = grdList.activeDataRowKey != string.Empty && m_tranEnabled;
                btnDownload.Enabled = grdList.activeDataRowKey != string.Empty && m_tranEnabled;
                btnUpdate.Enabled = m_tranEnabled;
                btnClear.Enabled = grdList.activeDataRowKey != string.Empty && m_tranEnabled;
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

        private void designGridOfHostDriver(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdList.dataSource;

                // --

                uds.Band.Columns.Add("Host Driver");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Path");
                uds.Band.Columns.Add("File");
                uds.Band.Columns.Add("File Ver.");
                uds.Band.Columns.Add("Update Time");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Host Driver"].Width = 140;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 144;
                grdList.DisplayLayout.Bands[0].Columns["File"].Width = 200;
                grdList.DisplayLayout.Bands[0].Columns["File Ver."].Width = 77;
                grdList.DisplayLayout.Bands[0].Columns["Update Time"].Width = 150;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Host Driver"].CellAppearance.Image = Properties.Resources.HostDriver;

                // --

                grdList.DisplayLayout.Bands[0].Columns["Host Driver"].Header.Fixed = true;
                
                // --
                
                grdList.DisplayLayout.Bands[0].Columns["Path"].Hidden = true;
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

        private void refreshGridOfHostDriver(
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
                grdList.removeAllDataRow();
                grdList.DisplayLayout.Bands[0].SortedColumns.Clear();
                // --
                initPropOfHostDriver();

                //--

                grdList.beginUpdate();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "HostDriver", "ListHostDriver", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),                                       // Host Driver
                            r[1].ToString(),                                       // Description
                            r[2].ToString(),                                       // Path
                            r[3].ToString(),                                       // File
                            r[4].ToString(),                                       // File Version
                            FDataConvert.defaultDataTimeFormating(r[5].ToString()) // Update Time
                            };
                        key = (string)cellValues[0];
                        grdList.appendDataRow(key, cellValues);                            
                    }
                } while (nextRowNumber >= 0);
                
                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count > 0)
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

                //--

                refreshTotal();

                // --

                controlButton();

                // --

                grdList.Focus();
            }
            catch (Exception ex)
            {
                grdList.endUpdate();
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

        private void initPropOfHostDriver(
            )
        {
            try
            {
                pgdProp.selectedObject = new FPropHostDriver(m_fAdmCore, pgdProp, m_tranEnabled);
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

        private void setPropOfHostDriver(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;

            try
            {
                if (grdList.activeDataRow == null)
                {
                    return;
                }
                
                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("hdr", grdList.activeDataRowKey);

                // --

                dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Setup", "HostDriver", "SearchHostDriver", fSqlParams, true);

                // --

                pgdProp.selectedObject = new FPropHostDriver(m_fAdmCore, pgdProp, dt, m_tranEnabled);                
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FHostDriver Form Event Handler

        private void FHostDriver_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                m_tranEnabled = FCommon.hasTransactionAuthority(m_fAdmCore, FUserFunction.HostDriver);

                // --

                designGridOfHostDriver();

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

        private void FHostDriver_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfHostDriver(string.Empty);

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

        private void FHostDriver_FormClosing(
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

        private void FHostDriver_KeyDown(
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
                    refreshGridOfHostDriver(grdList.activeDataRowKey);
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

                setPropOfHostDriver();

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

        private void grdList_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                setPropOfHostDriver();
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
            FPropHostDriver fPropHdr = null;
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInHdr = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutHdr = null; 
            string key = string.Empty;
            object[] cellValues = null;
            FFtp fFtp = null;
            string tempFilePath = string.Empty;
            string zipFileName = string.Empty;
            string path = string.Empty;
            string fileName = string.Empty;
            string fileVer = string.Empty;

            try
            {
                FCursor.waitCursor();

                // --

                fPropHdr = (FPropHostDriver)pgdProp.selectedObject;

                // --

                #region Validataion

                FCommon.validateName(fPropHdr.HostDriver, true, this.fUIWizard, "Host Driver");

                // --

                if (fPropHdr.HostDriver.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Host Driver" }));
                }

                // --

                if (fPropHdr.Description.Length > 50)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Description" }));
                }

                // --

                if (fPropHdr.Comments.Length > 400)
                {
                    FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0023", new object[] { "Comments" }));
                }

                // --

                if (
                    grdList.activeDataRow == null ||
                    grdList.activeDataRowKey != fPropHdr.HostDriver
                   )
                {
                    if (fPropHdr.file == fPropHdr.path)
                    {
                        FDebug.throwFException(m_fAdmCore.fUIWizard.generateMessage("E0010", new object[] { "File" }));
                    }
                }
                                
                #endregion

                // --

                // ***
                // 2013.01.06 by spike.lee
                // 한번더 생각했으면 어떨가요?
                // File Upload 해야할 경우에만 Temp Directory와 FTP 개체를 생성해서 사용하면 더 깔끔하지 않을까요?
                // File UPload 후, Temp Directory를 바로 삭제하면 오류가 발생해더 Temp Directory가 삭제되어 쓰레기 파일이 남지 않을 텐데요.
                // ***
                if (fPropHdr.file != fPropHdr.path)
                {
                    // ***
                    // Host Driver File Version Get
                    // ***
                    fileVer = FileVersionInfo.GetVersionInfo(fPropHdr.file).FileVersion;

                    // --

                    // ***
                    // FTP Creation
                    // ***
                    fFtp = FCommon.createFtp(m_fAdmCore);

                    // --

                    // ***
                    // Temp Directory create
                    // ***
                    tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                    Directory.CreateDirectory(tempFilePath);

                    // --

                    zipFileName = tempFilePath + string.Format(FConstants.TempFileFormat, Guid.NewGuid().ToString(), FConstants.ZipFileExtension);
                    F7Zip.pack(zipFileName, fPropHdr.file);
                    // --
                    fFtp.uploadFiles(zipFileName);
                }

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetHostDriverUpdate_In.E_ADMADS_SetHostDriverUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hLanguage, FADMADS_SetHostDriverUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hFactory, FADMADS_SetHostDriverUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hUserId, FADMADS_SetHostDriverUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hHostIp, FADMADS_SetHostDriverUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hHostName, FADMADS_SetHostDriverUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hStep, FADMADS_SetHostDriverUpdate_In.D_hStep, "1");
                
                // --

                fXmlNodeInHdr = fXmlNodeIn.set_elem(FADMADS_SetHostDriverUpdate_In.FHostDriver.E_HostDriver);
                fXmlNodeInHdr.set_elemVal(FADMADS_SetHostDriverUpdate_In.FHostDriver.A_HostDriver, FADMADS_SetHostDriverUpdate_In.FHostDriver.D_HostDriver, fPropHdr.HostDriver);
                fXmlNodeInHdr.set_elemVal(
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.A_Description, 
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.D_Description,
                    fPropHdr.Description
                    );
                fXmlNodeInHdr.set_elemVal(
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.A_Comment, 
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.D_Comment,
                    fPropHdr.Comments
                    );
                fXmlNodeInHdr.set_elemVal(
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.A_Path, 
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.D_Path, 
                    Path.GetFileName(zipFileName)
                    );
                fXmlNodeInHdr.set_elemVal(
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.A_FileName, 
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.D_FileName, 
                    Path.GetFileName(fPropHdr.file)
                    );
                fXmlNodeInHdr.set_elemVal(
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.A_FileVersion,
                    FADMADS_SetHostDriverUpdate_In.FHostDriver.D_FileVersion,
                    fileVer
                    );

                // --

                FADMADSCaster.ADMADS_SetHostDriverUpdate_Req(
                    m_fAdmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FADMADS_SetHostDriverUpdate_Out.A_hStatus, FADMADS_SetHostDriverUpdate_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(
                        fXmlNodeOut.get_elemVal(FADMADS_SetHostDriverUpdate_Out.A_hStatusMessage, FADMADS_SetHostDriverUpdate_Out.D_hStatusMessage)
                        );
                }

                // --

                fXmlNodeOutHdr = fXmlNodeOut.get_elem(FADMADS_SetHostDriverUpdate_Out.FHostDriver.E_HostDriver);
                path = fXmlNodeOutHdr.get_elemVal(
                    FADMADS_SetHostDriverUpdate_Out.FHostDriver.A_Path, 
                    FADMADS_SetHostDriverUpdate_Out.FHostDriver.D_Path
                    );
                fileName = fXmlNodeOutHdr.get_elemVal(
                    FADMADS_SetHostDriverUpdate_Out.FHostDriver.A_FileName, 
                    FADMADS_SetHostDriverUpdate_Out.FHostDriver.D_FileName
                    );
                fileVer = fXmlNodeOutHdr.get_elemVal(
                    FADMADS_SetHostDriverUpdate_Out.FHostDriver.A_FileVersion,
                    FADMADS_SetHostDriverUpdate_Out.FHostDriver.D_FileVersion
                    );
                // --
                cellValues = new object[]
                {
                    fPropHdr.HostDriver,    // Host Driver
                    fPropHdr.Description,   // Description
                    path,                   // Path
                    fileName,               // FileName
                    fileVer                 // File Version
                };

                // --

                key = (string)cellValues[0];
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
                if (fFtp != null)
                {
                    fFtp.Dispose();
                    fFtp = null;
                }

                // --

                fPropHdr = null;
                fXmlNodeIn = null;
                fXmlNodeInHdr = null;
                fXmlNodeOut = null;
                fXmlNodeOutHdr = null; 

                // --

                FCommon.deleteDirectory(tempFilePath);

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

                initPropOfHostDriver();
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
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInHdr = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (FMessageBox.showQuestion(
                    FConstants.ApplicationName,
                    m_fAdmCore.fUIWizard.generateMessage("Q0003", new object[] { "Selected Host Driver" }),
                    MessageBoxButtons.YesNo,
                    MessageBoxDefaultButton.Button2,
                    this
                    ) == DialogResult.No)
                {
                    return;
                }

                // --

                grdList.beginUpdate();

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetHostDriverUpdate_In.E_ADMADS_SetHostDriverUpdate_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hLanguage, FADMADS_SetHostDriverUpdate_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hFactory, FADMADS_SetHostDriverUpdate_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hUserId, FADMADS_SetHostDriverUpdate_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hHostIp, FADMADS_SetHostDriverUpdate_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hHostName, FADMADS_SetHostDriverUpdate_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverUpdate_In.A_hStep, FADMADS_SetHostDriverUpdate_In.D_hStep, "2");                
                // --
                fXmlNodeInHdr = fXmlNodeIn.set_elem(FADMADS_SetHostDriverUpdate_In.FHostDriver.E_HostDriver);

                // --

                foreach (UltraDataRow r in grdList.selectedDataRows)
                {
                    fXmlNodeInHdr.set_elemVal(
                        FADMADS_SetHostDriverUpdate_In.FHostDriver.A_HostDriver, 
                        FADMADS_SetHostDriverUpdate_In.FHostDriver.D_HostDriver, 
                        r["Host Driver"].ToString()
                        );
                    fXmlNodeInHdr.set_elemVal(
                        FADMADS_SetHostDriverUpdate_In.FHostDriver.A_Path, 
                        FADMADS_SetHostDriverUpdate_In.FHostDriver.D_Path, 
                        r["Path"].ToString()
                        );
                    
                    // --
                    
                    FADMADSCaster.ADMADS_SetHostDriverUpdate_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetHostDriverUpdate_Out.A_hStatus, FADMADS_SetHostDriverUpdate_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetHostDriverUpdate_Out.A_hStatusMessage, FADMADS_SetHostDriverUpdate_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    grdList.removeDataRow(r.Index);
                }

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count == 0)
                {
                    initPropOfHostDriver();
                }
                
                //--

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
                fXmlNodeInHdr = null;
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
            FXmlNode fXmlNodeInHdr = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutHdr = null;
            FolderBrowserDialog fbd = null;
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

                m_fAdmCore.fOption.recentDownloadPath = fbd.SelectedPath;

                // --

                fFtp = FCommon.createFtp(m_fAdmCore);

                // --

                // ***
                // Temp Directory create
                // ***
                tempFilePath = Path.Combine(m_fAdmCore.fWsmCore.tempPath, Guid.NewGuid().ToString());
                Directory.CreateDirectory(tempFilePath);

                // --

                fXmlNodeIn = FCommon.createXmlNode(FADMADS_SetHostDriverDownload_In.E_ADMADS_SetHostDriverDownload_In);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverDownload_In.A_hLanguage, FADMADS_SetHostDriverDownload_In.D_hLanguage, m_fAdmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverDownload_In.A_hFactory, FADMADS_SetHostDriverDownload_In.D_hFactory, m_fAdmCore.fOption.factory);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverDownload_In.A_hUserId, FADMADS_SetHostDriverDownload_In.D_hUserId, m_fAdmCore.fOption.user);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverDownload_In.A_hHostIp, FADMADS_SetHostDriverDownload_In.D_hHostIp, m_fAdmCore.fOption.hostIPAddrress);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverDownload_In.A_hHostName, FADMADS_SetHostDriverDownload_In.D_hHostName, m_fAdmCore.fOption.hostName);
                fXmlNodeIn.set_elemVal(FADMADS_SetHostDriverDownload_In.A_hStep, FADMADS_SetHostDriverDownload_In.D_hStep, "1");

                // --

                fXmlNodeInHdr = fXmlNodeIn.set_elem(FADMADS_SetHostDriverDownload_In.FHostDriver.E_HostDriver);

                // --

                foreach (string s in grdList.selectedDataRowKeys)
                {
                    fXmlNodeInHdr.set_elemVal(
                        FADMADS_SetHostDriverDownload_In.FHostDriver.A_HostDriver, 
                        FADMADS_SetHostDriverDownload_In.FHostDriver.D_HostDriver, 
                        s
                        );
                    
                    // --
                    
                    FADMADSCaster.ADMADS_SetHostDriverDownload_Req(
                        m_fAdmCore.fH101,
                        fXmlNodeIn,
                        ref fXmlNodeOut
                        );
                    // --
                    if (fXmlNodeOut.get_elemVal(FADMADS_SetHostDriverDownload_Out.A_hStatus, FADMADS_SetHostDriverDownload_Out.D_hStatus) != "0")
                    {
                        FDebug.throwFException(
                            fXmlNodeOut.get_elemVal(FADMADS_SetHostDriverDownload_Out.A_hStatusMessage, FADMADS_SetHostDriverDownload_Out.D_hStatusMessage)
                            );
                    }

                    // --

                    fXmlNodeOutHdr = fXmlNodeOut.get_elem(FADMADS_SetHostDriverDownload_Out.FHostDriver.E_HostDriver);
                    zipFileName = fXmlNodeOutHdr.get_elemVal(FADMADS_SetHostDriverDownload_Out.FHostDriver.A_Path, FADMADS_SetHostDriverDownload_Out.FHostDriver.D_Path);

                    // --

                    fFtp.downloadFiles(tempFilePath, zipFileName);
                    fFtp.deleteFiles(zipFileName);

                    // --

                    zipFileName = tempFilePath + "\\" + zipFileName;
                    downloadFilePath = Path.Combine(fbd.SelectedPath, m_fAdmCore.fOption.factory + "_" + s);
                    if (Directory.Exists(downloadFilePath))
                    {
                        Directory.Delete(downloadFilePath, true);
                    }
                    Directory.CreateDirectory(downloadFilePath);
                    // --
                    F7Zip.unpack(zipFileName, downloadFilePath);
                }

                // --

                // ***
                // Folder open
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
                grdList.endUpdate();
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
                fXmlNodeInHdr = null;
                fXmlNodeOut = null;

                // --

                FCommon.deleteDirectory(tempFilePath);

                // --

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

                refreshGridOfHostDriver(grdList.activeDataRowKey);
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
