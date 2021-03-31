/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSecsMessageSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.07.28
--  Description     : FAMate SECS Modeler SECS Message Selector Form Class 
--  History         : Created by spike.lee at 2011.07.28
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
using Nexplant.MC.Core.FaSecsDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.SecsModeler
{
    public partial class FSecsMessageSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSsmCore m_fSsmCore = null;
        private FSecsDevice m_fOldSdv = null;
        private FSecsSession m_fOldSsn = null;
        private FSecsMessageList m_fOldSml = null;
        private FSecsMessage m_fOldSmg = null;
        private FSecsDevice m_fSelectedSdv = null;
        private FSecsSession m_fSelectedSsn = null;
        private FSecsMessage m_fSelectedSmg = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsMessageSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsMessageSelector(
            FSsmCore fSsmCore,
            FSecsDevice fOldSdv,
            FSecsSession fOldSsn,
            FSecsMessage fOldSmg
            )
            : this()
        {
            base.fUIWizard = fSsmCore.fUIWizard;
            m_fSsmCore = fSsmCore;
            m_fOldSdv = fOldSdv;
            m_fOldSsn = fOldSsn;            
            m_fOldSmg = fOldSmg;
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
                    m_fSsmCore = null;
                    m_fOldSdv = null;
                    m_fOldSsn = null;
                    m_fOldSml = null;
                    m_fOldSmg = null;
                    m_fSelectedSdv = null;
                    m_fSelectedSsn = null;
                    m_fSelectedSmg = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FSecsDevice fSelectedDevice
        {
            get
            {
                try
                {
                    return m_fSelectedSdv;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsSession fSelectedSession
        {
            get
            {
                try
                {
                    return m_fSelectedSsn;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsMessage fSelectedMessage
        {
            get
            {
                try
                {
                    return m_fSelectedSmg;
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

        private void designGridOfDevice(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdDevice.dataSource;
                // --
                uds.Band.Columns.Add("SECS Device");
                uds.Band.Columns.Add("Mode");
                uds.Band.Columns.Add("Protocol");
                uds.Band.Columns.Add("Description");

                // --

                grdDevice.DisplayLayout.Bands[0].Columns["SECS Device"].CellAppearance.Image = Properties.Resources.SecsDevice;
                // --
                grdDevice.DisplayLayout.Bands[0].Columns["SECS Device"].Width = 150;
                grdDevice.DisplayLayout.Bands[0].Columns["Mode"].Width = 90;
                grdDevice.DisplayLayout.Bands[0].Columns["Protocol"].Width = 90;
                grdDevice.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfSession(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdSession.dataSource;
                // --
                uds.Band.Columns.Add("SECS Session");
                uds.Band.Columns.Add("Session ID");
                uds.Band.Columns.Add("Library");
                uds.Band.Columns.Add("Description");

                // --

                grdSession.DisplayLayout.Bands[0].Columns["SECS Session"].CellAppearance.Image = Properties.Resources.SecsSession_unlock;
                grdSession.DisplayLayout.Bands[0].Columns["Session ID"].CellAppearance.TextHAlign = HAlign.Right;
                // --
                grdSession.DisplayLayout.Bands[0].Columns["SECS Session"].Width = 150;
                grdSession.DisplayLayout.Bands[0].Columns["Session ID"].Width = 70;
                grdSession.DisplayLayout.Bands[0].Columns["Library"].Width = 150;                
                grdSession.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfMessageList(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdMessageList.dataSource;
                // --
                uds.Band.Columns.Add("SECS Message List");                
                uds.Band.Columns.Add("Description");

                // --

                grdMessageList.DisplayLayout.Bands[0].Columns["SECS Message List"].CellAppearance.Image = Properties.Resources.SecsMessageList_unlock;
                // --
                grdMessageList.DisplayLayout.Bands[0].Columns["SECS Message List"].Width = 150;
                grdMessageList.DisplayLayout.Bands[0].Columns["Description"].Width = 200;
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

        private void designGridOfMessage(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = grdMessage.dataSource;
                // --
                uds.Band.Columns.Add("SECS Message");
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");

                // --

                grdMessage.DisplayLayout.Bands[0].Columns["SECS Message"].CellAppearance.Image = Properties.Resources.SecsMessage;
                // --
                grdMessage.DisplayLayout.Bands[0].Columns["SECS Message"].Width = 150;
                grdMessage.DisplayLayout.Bands[0].Columns["Name"].Width = 200;
                grdMessage.DisplayLayout.Bands[0].Columns["Description"].Width = 250;
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

        private void refreshGridOfDevice(
            )
        {
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                grdDevice.beginUpdate(false);                

                // --

                foreach (FSecsDevice fSdv in m_fSsmCore.fSsmFileInfo.fSecsDriver.fChildSecsDeviceCollection)
                {
                    cellValues = new object[] {
                        fSdv.name,
                        fSdv.fDeviceMode.ToString(),
                        fSdv.fProtocol.ToString(),
                        fSdv.description
                    };
                    dataRow = grdDevice.appendDataRow(fSdv.uniqueIdToString, cellValues);
                    dataRow.Tag = fSdv;
                    FCommon.refreshGridRowOfObject(fSdv, grdDevice.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fSdv == m_fOldSdv)
                    {
                        activeDataRowKey = fSdv.uniqueIdToString;
                    }
                }

                // --

                grdDevice.endUpdate(false);                

                // --

                if (grdDevice.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdDevice.ActiveRow = grdDevice.Rows[0];
                    }
                    else
                    {
                        grdDevice.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdDevice.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfSession(
            )
        {
            FSecsDevice fSdv = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fSdv = (FSecsDevice)grdDevice.activeDataRow.Tag;

                // --

                grdSession.beginUpdate(false);

                // --

                grdSession.removeAllDataRow();

                // --

                foreach (FSecsSession fSsn in fSdv.fChildSecsSessionCollection)
                {
                    cellValues = new object[] {
                        fSsn.name,
                        fSsn.sessionId.ToString(),
                        (fSsn.hasLibrary ? fSsn.fLibrary.name : string.Empty),
                        fSsn.description
                    };
                    dataRow = grdSession.appendDataRow(fSsn.uniqueIdToString, cellValues);
                    dataRow.Tag = fSsn;
                    FCommon.refreshGridRowOfObject(fSsn, grdSession.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fSsn == m_fOldSsn)
                    {
                        activeDataRowKey = fSsn.uniqueIdToString;
                    }
                }

                // --

                grdSession.endUpdate(false);

                // --

                if (grdSession.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdSession.ActiveRow = grdSession.Rows[0];
                    }
                    else
                    {
                        grdSession.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdSession.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSdv = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfMessageList(
            )
        {
            FSecsSession fSsn = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fSsn = (FSecsSession)grdSession.activeDataRow.Tag;

                // --

                grdMessageList.beginUpdate(false);

                // --

                grdMessageList.removeAllDataRow();

                // --

                if (fSsn.hasLibrary)
                {
                    foreach (FSecsMessageList fSml in fSsn.fLibrary.fChildSecsMessageListCollection)
                    {
                        cellValues = new object[] {
                            fSml.name,                            
                            fSml.description
                        };
                        dataRow = grdMessageList.appendDataRow(fSml.uniqueIdToString, cellValues);
                        dataRow.Tag = fSml;
                        FCommon.refreshGridRowOfObject(fSml, grdMessageList.Rows.GetRowWithListIndex(dataRow.Index));

                        // --

                        if (fSml == m_fOldSml)
                        {
                            activeDataRowKey = fSml.uniqueIdToString;
                        }
                    }
                }                

                // --

                grdMessageList.endUpdate(false);

                // --

                if (grdMessageList.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdMessageList.ActiveRow = grdMessageList.Rows[0];
                    }
                    else
                    {
                        grdMessageList.activateDataRow(activeDataRowKey);
                    }                    
                }
            }
            catch (Exception ex)
            {
                grdMessageList.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSsn = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfMessage(
            )
        {
            FSecsMessageList fSml = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fSml = (FSecsMessageList)grdMessageList.activeDataRow.Tag;

                // --

                grdMessage.beginUpdate(false);

                // --

                grdMessage.removeAllDataRow();

                // --

                foreach (FSecsMessage fSmg in fSml.fDescendantSecsMessageCollection)
                {
                    cellValues = new object[] {
                        "[S" + fSmg.stream.ToString() + " F" + fSmg.function.ToString() + " V" + fSmg.version.ToString() + "]",
                        fSmg.name,          
                        fSmg.description
                    };
                    dataRow = grdMessage.appendDataRow(fSmg.uniqueIdToString, cellValues);
                    dataRow.Tag = fSmg;
                    FCommon.refreshGridRowOfObject(fSmg, grdMessage.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fSmg == m_fOldSmg)
                    {
                        activeDataRowKey = fSmg.uniqueIdToString;
                    }
                }                

                // --

                grdMessage.endUpdate(false);

                // --

                if (grdMessage.Rows.Count > 0)
                {
                    if (activeDataRowKey == string.Empty)
                    {
                        grdMessage.ActiveRow = grdMessage.Rows[0];
                    }
                    else
                    {
                        grdMessage.activateDataRow(activeDataRowKey);
                    }
                }
            }
            catch (Exception ex)
            {
                grdMessage.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                fSml = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procPreviousStep(
            )
        {
            try
            {
                if (m_step == 0)
                {
                    // ***
                    // Device Selection
                    // ***
                }
                else if (m_step == 1)
                {
                    // ***
                    // Session Selection
                    // ***
                    btnPrevious.Enabled = false;
                    btnNext.Enabled = (grdDevice.activeDataRow == null ? false : true);
                    // --
                    grdDevice.Visible = true;
                    grdSession.Visible = false;
                    grdDevice.Focus();
                    // --
                    m_step = 0;
                }
                else if (m_step == 2)
                {
                    // ***
                    // Message List Selection
                    // ***                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = (grdSession.activeDataRow == null ? false : true);
                    // --
                    grdSession.Visible = true;
                    grdMessageList.Visible = false;
                    grdSession.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 3)
                {
                    // ***
                    // Message Selection
                    // ***
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = (grdMessageList.activeDataRow == null ? false : true);
                    btnOk.Enabled = false;
                    // --
                    grdMessageList.Visible = true;
                    grdMessage.Visible = false;
                    grdSession.Focus();
                    // --
                    m_step = 2;
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

        private void procNextStep(
            )
        {
            try
            {
                if (m_step == 0)
                {
                    // ***
                    // Device Selection
                    // ***
                    refreshGridOfSession();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = (grdSession.activeDataRow == null ? false : true);                    
                    // --
                    grdDevice.Visible = false;
                    grdSession.Visible = true;
                    grdSession.Focus();
                    // --
                    m_step = 1;
                }
                else if (m_step == 1)
                {
                    // ***
                    // Session Selection
                    // ***
                    refreshGridOfMessageList();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = (grdMessageList.activeDataRow == null ? false : true);
                    // --
                    grdSession.Visible = false;
                    grdMessageList.Visible = true;
                    grdMessageList.Focus();
                    // --
                    m_step = 2;
                }
                else if (m_step == 2)
                {
                    // ***
                    // Message List Selection
                    // ***
                    refreshGridOfMessage();
                    // --                    
                    btnPrevious.Enabled = true;
                    btnNext.Enabled = false;
                    btnOk.Enabled = (grdMessage.activeDataRow == null ? false : true);
                    // --
                    grdMessageList.Visible = false;
                    grdMessage.Visible = true;
                    grdMessage.Focus();
                    // --
                    m_step = 3;
                }
                else if (m_step == 3)
                {
                    // ***
                    // Message Selection
                    // ***
                    selectMessage();
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

        private void selectMessage(
            )
        {
            try
            {
                m_fSelectedSdv = (FSecsDevice)grdDevice.activeDataRow.Tag;
                m_fSelectedSsn = (FSecsSession)grdSession.activeDataRow.Tag;
                m_fSelectedSmg = (FSecsMessage)grdMessage.activeDataRow.Tag;
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
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

        #region FSecsMessageSelector Form Event Handler

        private void FSecsMessageSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfDevice();
                designGridOfSession();
                designGridOfMessageList();
                designGridOfMessage();

                // --

                grdDevice.Visible = true;
                grdSession.Visible = false;
                grdMessageList.Visible = false;
                grdMessage.Visible = false;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FSecsMessageSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldSmg != null)
                {
                    m_fOldSml = m_fOldSmg.fParent.fParent;
                    btnReset.Enabled = true;
                }

                // --
                
                refreshGridOfDevice();

                // --

                m_step = 0;                
                if (grdDevice.activeDataRow != null)
                {
                    btnNext.Enabled = true;
                }                                
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Grid Control Common Event Handler

        private void grdCommon_DoubleClickRow(
            object sender,
            DoubleClickRowEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procNextStep();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }       

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnPrevious Control Event Handler

        private void btnPrevious_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procPreviousStep();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnNext Control Event Handler

        private void btnNext_Click(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                procNextStep(); 
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
            try
            {
                FCursor.waitCursor();

                // --

                selectMessage();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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

                m_fSelectedSdv = null;
                m_fSelectedSsn = null;
                m_fSelectedSmg = null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSsmCore.fWsmCore.fWsmContainer);
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
