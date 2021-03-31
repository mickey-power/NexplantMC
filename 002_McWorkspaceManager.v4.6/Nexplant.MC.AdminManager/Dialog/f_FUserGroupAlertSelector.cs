/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FUserGroupAlertSelector.cs
--  Creator         : tjkim 
--  Create Date     : 2013.06.10
--  Description     : FAMate Admin Manager User Group Alert Select Dialog Form Class 
--  History         : Created by tjkim at 2013.06.10
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
    public partial class FUserGroupAlertSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;
        private string m_eventType = string.Empty;
        private string[][] m_eventList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FUserGroupAlertSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUserGroupAlertSelector(
            FAdmCore fAdmCore
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FUserGroupAlertSelector(
            FAdmCore fAdmCore,
            string eventType
            )
            : this()
        {
            base.fUIWizard = fAdmCore.fUIWizard;
            m_fAdmCore = fAdmCore;
            m_eventType = eventType;
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

        public string[][] eventList
        {
            get
            {
                try
                {
                    return m_eventList;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void designGridOfUserGroup(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdUserGroup.dataSource;
                // --
                uds.Band.Columns.Add("User Group");
                uds.Band.Columns.Add("Description");

                // --

                grdUserGroup.DisplayLayout.Bands[0].Columns["User Group"].CellAppearance.Image = Properties.Resources.UserGroup;
                // --
                grdUserGroup.DisplayLayout.Bands[0].Columns["User Group"].Header.Fixed = true;
                // --
                grdUserGroup.DisplayLayout.Bands[0].Columns["User Group"].Width = 120;
                grdUserGroup.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private Image getImageOfEvent(
            )
        {
            try
            {
                if (m_eventType == FEventType.User.ToString())
                {
                    return Properties.Resources.UserEvent;
                }
                else if (m_eventType == FEventType.Server.ToString())
                {
                    return Properties.Resources.ServerEvent;
                }
                else if (m_eventType == FEventType.MC.ToString())
                {
                    return Properties.Resources.EapEvent;
                }
                else if (m_eventType == FEventType.Equipment.ToString())
                {
                    return Properties.Resources.EquipmentEvent;
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

        private void designGridOfEvent(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdEvent.dataSource;
                // --
                uds.Band.Columns.Add("Event");
                uds.Band.Columns.Add("Description");

                // --

                grdEvent.DisplayLayout.Bands[0].Columns["Event"].CellAppearance.Image = getImageOfEvent();
                // --
                grdEvent.DisplayLayout.Bands[0].Columns["Event"].CellActivation = Activation.NoEdit;
                grdEvent.DisplayLayout.Bands[0].Columns["Description"].CellActivation = Activation.NoEdit;
                // --
                grdEvent.DisplayLayout.Bands[0].Columns["Event"].Width = 218;
                grdEvent.DisplayLayout.Bands[0].Columns["Description"].Width = 218;
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

        private void setGridCellStyle(
            UltraGridCell cell
            )
        {
            try
            {
                cell.Activation = Activation.NoEdit;
                cell.ActiveAppearance.ForegroundAlpha = Infragistics.Win.Alpha.Transparent;
                cell.SelectedAppearance.ForegroundAlpha = Infragistics.Win.Alpha.Transparent;
                cell.Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit;
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

        private void refreshGridOfUserGroup(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string beforeKey = string.Empty;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                if (grdUserGroup.activeDataRow != null)
                {
                    beforeKey = grdUserGroup.activeDataRowKey;
                }

                // --

                grdUserGroup.beginUpdate();
                grdUserGroup.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "UserGroupAlertSelector", "ListUserGroup", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),   // User Group
                            r[1].ToString()    // Description
                            };
                        key = (string)cellValues[0];
                        grdUserGroup.appendDataRow(key, cellValues);
                    }
                } while (nextRowNumber >= 0);

                // --

                grdUserGroup.endUpdate();

                // --

                if (grdUserGroup.Rows.Count > 0)
                {
                    if (beforeKey != string.Empty)
                    {
                        grdUserGroup.activateDataRow(beforeKey);
                    }
                    if (grdUserGroup.activeDataRow == null)
                    {
                        grdUserGroup.ActiveRow = grdUserGroup.Rows[0];
                    }
                }

                // --

                grdUserGroup.Focus();
            }
            catch (Exception ex)
            {
                grdUserGroup.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfEvent(
            )
        {
            FSqlParams fSqlParams = null;
            DataTable dt = null;
            object[] cellValues = null;
            string key = string.Empty;
            int nextRowNumber = 0;

            try
            {
                grdEvent.beginUpdate(false);
                grdEvent.removeAllDataRow();

                // --

                fSqlParams = new FSqlParams();
                fSqlParams.add("factory", m_fAdmCore.fOption.factory);
                fSqlParams.add("user_grp", grdUserGroup.activeDataRowKey);
                fSqlParams.add("event_type", m_eventType);
                // --
                do
                {
                    dt = FCommon.requestCommonSqlQuery(m_fAdmCore, "Dialog", "UserGroupAlertSelector", "ListAlert", fSqlParams, false, ref nextRowNumber);
                    // --
                    foreach (DataRow r in dt.Rows)
                    {
                        cellValues = new object[] {
                            r[0].ToString(),             // Event
                            r[1].ToString()              // Descripiton
                            };
                        key = (string)cellValues[0];
                        grdEvent.appendDataRow(key, cellValues);
                    }

                } while (nextRowNumber >= 0);

                // --

                grdEvent.endUpdate(false);
            }
            catch (Exception ex)
            {
                grdEvent.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlParams = null;
                dt = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FUserGroupAlertSelector Form Event Handler

        private void FUserGroupAlertSelector_Load(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfUserGroup();
                designGridOfEvent();
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

        private void FUserGroupAlertSelector_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserGroup();

                // --

                txtEventType.Text = m_eventType;
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

        private void FUserGroupAlertSelector_KeyDown(
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
                    if (grdEvent.Focused)
                    {
                        refreshGridOfEvent();
                    }
                    else
                    {
                        refreshGridOfUserGroup();
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

        #region grdUserGroup Control Event Handler

        private void grdUserGroup_AfterRowActivate(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEvent();
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

        #region grdEvent Control Event Handler

        private void grdEvent_AfterRowActivate(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (grdEvent.activeDataRow == null)
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnOk Control Event Handler

        private void btnOk_Click(
            object sender, 
            EventArgs e
            )
        {
            int i = 0;

            try
            {
                FCursor.waitCursor();

                // --

                m_eventList = new string[grdEvent.Rows.Count][];
                foreach (UltraGridRow r in grdEvent.Rows)
                {
                    m_eventList[i] = new string[2]; 
                    m_eventList[i][0] = r.Cells["Event"].Value.ToString();
                    m_eventList[i][1] = r.Cells["Description"].Value.ToString();
                    i++;
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

        #region rstUrgToolbar Control Event Handler

        private void rstUrgToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfUserGroup();
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

        private void rstUrgToolbar_SearchRequested(
            object sender,
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdUserGroup.searchGridRow(e.searchWord))
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

        #region rstEvtToolbar Control Event Handler

        private void rstEvtToolbar_RefreshRequested(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshGridOfEvent();
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

        private void rstEvtToolbar_SearchRequested(
            object sender, 
            FSearchRequestedEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (!grdEvent.searchGridRow(e.searchWord))
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
