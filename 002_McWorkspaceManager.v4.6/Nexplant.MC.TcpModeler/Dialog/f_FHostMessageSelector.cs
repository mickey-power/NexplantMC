/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FHostMessageSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.01
--  Description     : FAMate TCP Modeler Host Message Selector Form Class 
--  History         : Created by spike.lee at 2011.08.01
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.TcpModeler
{
    public partial class FHostMessageSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FHostDevice m_fOldHdv = null;
        private FHostSession m_fOldHsn = null;
        private FHostMessageList m_fOldHml = null;
        private FHostMessage m_fOldHmg = null;
        private FHostDevice m_fSelectedHdv = null;
        private FHostSession m_fSelectedHsn = null;
        private FHostMessage m_fSelectedHmg = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostMessageSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostMessageSelector(
            FTcmCore fTcmCore,
            FHostDevice fOldHdv,
            FHostSession fOldHsn,
            FHostMessage fOldHmg
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fOldHdv = fOldHdv;
            m_fOldHsn = fOldHsn;            
            m_fOldHmg = fOldHmg;
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
                    m_fOldHdv = null;
                    m_fOldHsn = null;
                    m_fOldHml = null;
                    m_fOldHmg = null;
                    m_fSelectedHdv = null;
                    m_fSelectedHsn = null;
                    m_fSelectedHmg = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FHostDevice fSelectedDevice
        {
            get
            {
                try
                {
                    return m_fSelectedHdv;
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

        public FHostSession fSelectedSession
        {
            get
            {
                try
                {
                    return m_fSelectedHsn;
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

        public FHostMessage fSelectedMessage
        {
            get
            {
                try
                {
                    return m_fSelectedHmg;
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
                uds.Band.Columns.Add("Host Device");
                uds.Band.Columns.Add("Mode");
                uds.Band.Columns.Add("Driver");
                uds.Band.Columns.Add("Description");

                // --

                grdDevice.DisplayLayout.Bands[0].Columns["Host Device"].CellAppearance.Image = Properties.Resources.HostDevice;
                // --
                grdDevice.DisplayLayout.Bands[0].Columns["Host Device"].Width = 150;
                grdDevice.DisplayLayout.Bands[0].Columns["Mode"].Width = 70;
                grdDevice.DisplayLayout.Bands[0].Columns["Driver"].Width = 120;
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
                uds.Band.Columns.Add("Host Session");
                uds.Band.Columns.Add("Session ID");
                uds.Band.Columns.Add("Library");
                uds.Band.Columns.Add("Description");

                // --

                grdSession.DisplayLayout.Bands[0].Columns["Host Session"].CellAppearance.Image = Properties.Resources.HostSession_unlock;
                grdSession.DisplayLayout.Bands[0].Columns["Session ID"].CellAppearance.TextHAlign = HAlign.Right;
                // --
                grdSession.DisplayLayout.Bands[0].Columns["Host Session"].Width = 150;
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
                uds.Band.Columns.Add("Host Message List");                
                uds.Band.Columns.Add("Description");

                // --

                grdMessageList.DisplayLayout.Bands[0].Columns["Host Message List"].CellAppearance.Image = Properties.Resources.HostMessageList_unlock;
                // --
                grdMessageList.DisplayLayout.Bands[0].Columns["Host Message List"].Width = 150;
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
                uds.Band.Columns.Add("Host Message");
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");

                // --

                grdMessage.DisplayLayout.Bands[0].Columns["Host Message"].CellAppearance.Image = Properties.Resources.HostMessage;
                // --
                grdMessage.DisplayLayout.Bands[0].Columns["Host Message"].Width = 200;
                grdMessage.DisplayLayout.Bands[0].Columns["Name"].Width = 150;
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

                foreach (FHostDevice fHdv in m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildHostDeviceCollection)
                {
                    cellValues = new object[] {
                        fHdv.name,
                        fHdv.fDeviceMode.ToString(),
                        fHdv.driver,
                        fHdv.description
                    };
                    dataRow = grdDevice.appendDataRow(fHdv.uniqueIdToString, cellValues);
                    dataRow.Tag = fHdv;
                    FCommon.refreshGridRowOfObject(fHdv, grdDevice.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fHdv == m_fOldHdv)
                    {
                        activeDataRowKey = fHdv.uniqueIdToString;
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
            FHostDevice fHdv = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fHdv = (FHostDevice)grdDevice.activeDataRow.Tag;

                // --

                grdSession.beginUpdate(false);

                // --

                grdSession.removeAllDataRow();

                // --

                foreach (FHostSession fHsn in fHdv.fChildHostSessionCollection)
                {
                    cellValues = new object[] {
                        fHsn.name,
                        fHsn.sessionId.ToString(),
                        (fHsn.hasLibrary ? fHsn.fLibrary.name : string.Empty),
                        fHsn.description
                    };
                    dataRow = grdSession.appendDataRow(fHsn.uniqueIdToString, cellValues);
                    dataRow.Tag = fHsn;
                    FCommon.refreshGridRowOfObject(fHsn, grdSession.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fHsn == m_fOldHsn)
                    {
                        activeDataRowKey = fHsn.uniqueIdToString;
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
                fHdv = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfMessageList(
            )
        {
            FHostSession fHsn = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fHsn = (FHostSession)grdSession.activeDataRow.Tag;

                // --

                grdMessageList.beginUpdate(false);

                // --

                grdMessageList.removeAllDataRow();

                // --

                if (fHsn.hasLibrary)
                {
                    foreach (FHostMessageList fHml in fHsn.fLibrary.fChildHostMessageListCollection)
                    {
                        cellValues = new object[] {
                            fHml.name,                            
                            fHml.description
                        };
                        dataRow = grdMessageList.appendDataRow(fHml.uniqueIdToString, cellValues);
                        dataRow.Tag = fHml;
                        FCommon.refreshGridRowOfObject(fHml, grdMessageList.Rows.GetRowWithListIndex(dataRow.Index));

                        // --

                        if (fHml == m_fOldHml)
                        {
                            activeDataRowKey = fHml.uniqueIdToString;
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
                fHsn = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfMessage(
            )
        {
            FHostMessageList fHml = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fHml = (FHostMessageList)grdMessageList.activeDataRow.Tag;

                // --

                grdMessage.beginUpdate(false);

                // --

                grdMessage.removeAllDataRow();

                // --

                foreach (FHostMessage fHmg in fHml.fDescendantHostMessageCollection)
                {
                    cellValues = new object[] {
                        "[" + fHmg.command + " V" + fHmg.version.ToString() + "]",
                        fHmg.name,          
                        fHmg.description
                    };
                    dataRow = grdMessage.appendDataRow(fHmg.uniqueIdToString, cellValues);
                    dataRow.Tag = fHmg;
                    FCommon.refreshGridRowOfObject(fHmg, grdMessage.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fHmg == m_fOldHmg)
                    {
                        activeDataRowKey = fHmg.uniqueIdToString;
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
                fHml = null;
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
                m_fSelectedHdv = (FHostDevice)grdDevice.activeDataRow.Tag;
                m_fSelectedHsn = (FHostSession)grdSession.activeDataRow.Tag;
                m_fSelectedHmg = (FHostMessage)grdMessage.activeDataRow.Tag;
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

        #region FHostMessageSelector Form Event Handler

        private void FHostMessageSelector_Load(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FHostMessageSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldHmg != null)
                {
                    m_fOldHml = m_fOldHmg.fParent.fParent;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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

                m_fSelectedHdv = null;
                m_fSelectedHsn = null;
                m_fSelectedHmg = null;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fTcmCore.fWsmCore.fWsmContainer);
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
