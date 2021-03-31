/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FServerSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.28
--  Description     : FAMate Admin Manager Server Select Dialog Form Class 
--  History         : Created by spike.lee at 2012.03.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public partial class FServerSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_serverType = string.Empty;
        private string m_oldServer = string.Empty;
        private string m_deleteFlag = string.Empty; 
        private bool m_multiSelected = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServerSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerSelector(
            FAdmCore fAdmCore,
            string serverType,
            string oldServer,
            string deleteFlag
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_serverType = serverType;
            m_oldServer = oldServer;
            m_deleteFlag = deleteFlag;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServerSelector(
            FAdmCore fAdmCore
            )
            : this(fAdmCore, FServerType.Real.ToString(), "", "N")
        {
            m_multiSelected = true;
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

        public string selectedServer
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

        public string[] selectedServerList
        {
            get
            {
                try
                {
                    return grdList.selectedDataRowKeys;
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
                uds.Band.Columns.Add("Server");
                uds.Band.Columns.Add("Description");
                uds.Band.Columns.Add("Server IP");

                // --

                grdList.DisplayLayout.Bands[0].Columns["Server"].CellAppearance.Image = Properties.Resources.Server;
                // --
                grdList.DisplayLayout.Bands[0].Columns["Server"].Width = 150;
                grdList.DisplayLayout.Bands[0].Columns["Description"].Width = 250;
                grdList.DisplayLayout.Bands[0].Columns["Server IP"].Width = 100;

                // --

                grdList.multiSelected = m_multiSelected;
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
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            UltraGridRow row = null;
            object[] cellValues = null;
            int nextRowNumber = 0;
            int index = 0;
            string deleteFlag = string.Empty;

            try
            {
                btnOk.Enabled = false;

                // --

                grdList.beginUpdate(false);
                grdList.removeAllDataRow();

                // --
                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("svr_type", m_serverType, m_serverType == string.Empty ? true : false);
                fSqlParams.add("delete_flag", m_deleteFlag, m_deleteFlag == string.Empty ? true : false);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "ServerSelector", "ListAllServer", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        deleteFlag = r[6].ToString();   // Delete Flag

                        // --

                        cellValues = new object[] {
                            r[0].ToString(),   // Server
                            r[1].ToString(),   // Description
                            r[2].ToString()    // Server IP                            
                            };
                        index = grdList.appendDataRow(r[0].ToString(), cellValues).Index;

                        // --

                        if (deleteFlag == "Y")
                        {
                            row = grdList.Rows.GetRowWithListIndex(index);
                            row.Appearance.ForeColor = Color.DimGray;
                        }
                    }
                } while (nextRowNumber >= 0);

                // --

                grdList.endUpdate();

                // --

                if (grdList.Rows.Count > 0)
                {
                    if (m_oldServer != string.Empty)
                    {
                        grdList.activateDataRow(m_oldServer);
                    }
                    // --
                    if (grdList.ActiveRow == null || grdList.ActiveRow.VisibleIndex < 0)
                    {
                        grdList.ActiveRow = grdList.Rows[0];
                    }
                }

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
                row = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FServerSelector Form Event Handler

        private void FServerSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                btnReset.Enabled = (m_oldServer == string.Empty ? false : true);

                // --

                designGridOfList();
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

        private void FServerSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfList();
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

        private void FServerSelector_KeyDown(
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
                    refreshGridOfList();
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

                if (grdList.activeDataRow == null)
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

        private void grdList_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                grdList.Selected.Rows.Clear();
                grdList.ActiveRow.Selected = true;
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

        #region btnReset Control Event Handler

        private void btnReset_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                grdList.Selected.Rows.Clear();
                grdList.ActiveRow = null;
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

        #region rstToolbar Control EventHandler

        private void rstToolbar_RefreshRequested(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --     

                refreshGridOfList();
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
