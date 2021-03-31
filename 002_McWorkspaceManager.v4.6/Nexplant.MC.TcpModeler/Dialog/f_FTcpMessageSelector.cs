/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpMessageSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.07.28
--  Description     : FAMate TCP Modeler TCP Message Selector Form Class 
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
using Nexplant.MC.Core.FaTcpDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.TcpModeler
{
    public partial class FTcpMessageSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FTcpDevice m_fOldTdv = null;
        private FTcpSession m_fOldTsn = null;
        private FTcpMessageList m_fOldTml = null;
        private FTcpMessage m_fOldTmg = null;
        private FTcpDevice m_fSelectedTdv = null;
        private FTcpSession m_fSelectedTsn = null;
        private FTcpMessage m_fSelectedTmg = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpMessageSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpMessageSelector(
            FTcmCore fTcmCore,
            FTcpDevice fOldTdv,
            FTcpSession fOldTsn,
            FTcpMessage fOldTmg
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            // --
            m_fTcmCore = fTcmCore;
            m_fOldTdv = fOldTdv;
            m_fOldTsn = fOldTsn;            
            m_fOldTmg = fOldTmg;
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
                    m_fOldTdv = null;
                    m_fOldTsn = null;
                    m_fOldTml = null;
                    m_fOldTmg = null;
                    m_fSelectedTdv = null;
                    m_fSelectedTsn = null;
                    m_fSelectedTmg = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FTcpDevice fSelectedDevice
        {
            get
            {
                try
                {
                    return m_fSelectedTdv;
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

        public FTcpSession fSelectedSession
        {
            get
            {
                try
                {
                    return m_fSelectedTsn;
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

        public FTcpMessage fSelectedMessage
        {
            get
            {
                try
                {
                    return m_fSelectedTmg;
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
                uds.Band.Columns.Add("TCP Device");
                uds.Band.Columns.Add("Mode");
                uds.Band.Columns.Add("Protocol");
                uds.Band.Columns.Add("Description");

                // --

                grdDevice.DisplayLayout.Bands[0].Columns["TCP Device"].CellAppearance.Image = Properties.Resources.TcpDevice;
                // --
                grdDevice.DisplayLayout.Bands[0].Columns["TCP Device"].Width = 150;
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
                uds.Band.Columns.Add("TCP Session");
                uds.Band.Columns.Add("Session ID");
                uds.Band.Columns.Add("Library");
                uds.Band.Columns.Add("Description");

                // --

                grdSession.DisplayLayout.Bands[0].Columns["TCP Session"].CellAppearance.Image = Properties.Resources.TcpSession_unlock;
                grdSession.DisplayLayout.Bands[0].Columns["Session ID"].CellAppearance.TextHAlign = HAlign.Right;
                // --
                grdSession.DisplayLayout.Bands[0].Columns["TCP Session"].Width = 150;
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
                uds.Band.Columns.Add("TCP Message List");                
                uds.Band.Columns.Add("Description");

                // --

                grdMessageList.DisplayLayout.Bands[0].Columns["TCP Message List"].CellAppearance.Image = Properties.Resources.TcpMessageList_unlock;
                // --
                grdMessageList.DisplayLayout.Bands[0].Columns["TCP Message List"].Width = 150;
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
                uds.Band.Columns.Add("TCP Message");
                uds.Band.Columns.Add("Name");
                uds.Band.Columns.Add("Description");

                // --

                grdMessage.DisplayLayout.Bands[0].Columns["TCP Message"].CellAppearance.Image = Properties.Resources.TcpMessage;
                // --
                grdMessage.DisplayLayout.Bands[0].Columns["TCP Message"].Width = 200;
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

                foreach (FTcpDevice fTdv in m_fTcmCore.fTcmFileInfo.fTcpDriver.fChildTcpDeviceCollection)
                {
                    cellValues = new object[] {
                        fTdv.name,
                        fTdv.fDeviceType.ToString(),
                        fTdv.fProtocol.ToString(),
                        fTdv.description
                    };
                    dataRow = grdDevice.appendDataRow(fTdv.uniqueIdToString, cellValues);
                    dataRow.Tag = fTdv;
                    FCommon.refreshGridRowOfObject(fTdv, grdDevice.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fTdv == m_fOldTdv)
                    {
                        activeDataRowKey = fTdv.uniqueIdToString;
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
            FTcpDevice fTdv = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fTdv = (FTcpDevice)grdDevice.activeDataRow.Tag;

                // --

                grdSession.beginUpdate(false);

                // --

                grdSession.removeAllDataRow();

                // --

                foreach (FTcpSession fTsn in fTdv.fChildTcpSessionCollection)
                {
                    cellValues = new object[] {
                        fTsn.name,
                        fTsn.sessionId.ToString(),
                        (fTsn.hasLibrary ? fTsn.fLibrary.name : string.Empty),
                        fTsn.description
                    };
                    dataRow = grdSession.appendDataRow(fTsn.uniqueIdToString, cellValues);
                    dataRow.Tag = fTsn;
                    FCommon.refreshGridRowOfObject(fTsn, grdSession.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fTsn == m_fOldTsn)
                    {
                        activeDataRowKey = fTsn.uniqueIdToString;
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
                fTdv = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfMessageList(
            )
        {
            FTcpSession fTsn = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fTsn = (FTcpSession)grdSession.activeDataRow.Tag;

                // --

                grdMessageList.beginUpdate(false);

                // --

                grdMessageList.removeAllDataRow();

                // --

                if (fTsn.hasLibrary)
                {
                    foreach (FTcpMessageList fTml in fTsn.fLibrary.fChildTcpMessageListCollection)
                    {
                        cellValues = new object[] {
                            fTml.name,                            
                            fTml.description
                        };
                        dataRow = grdMessageList.appendDataRow(fTml.uniqueIdToString, cellValues);
                        dataRow.Tag = fTml;
                        FCommon.refreshGridRowOfObject(fTml, grdMessageList.Rows.GetRowWithListIndex(dataRow.Index));

                        // --

                        if (fTml == m_fOldTml)
                        {
                            activeDataRowKey = fTml.uniqueIdToString;
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
                fTsn = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfMessage(
            )
        {
            FTcpMessageList fTml = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fTml = (FTcpMessageList)grdMessageList.activeDataRow.Tag;

                // --

                grdMessage.beginUpdate(false);

                // --

                grdMessage.removeAllDataRow();

                // --

                foreach (FTcpMessage fTmg in fTml.fDescendantTcpMessageCollection)
                {
                    cellValues = new object[] {
                        "[" + fTmg.command + " V" + fTmg.version.ToString() + "]",
                        fTmg.name,
                        fTmg.description
                    };
                    dataRow = grdMessage.appendDataRow(fTmg.uniqueIdToString, cellValues);
                    dataRow.Tag = fTmg;
                    FCommon.refreshGridRowOfObject(fTmg, grdMessage.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fTmg == m_fOldTmg)
                    {
                        activeDataRowKey = fTmg.uniqueIdToString;
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
                fTml = null;
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
                m_fSelectedTdv = (FTcpDevice)grdDevice.activeDataRow.Tag;
                m_fSelectedTsn = (FTcpSession)grdSession.activeDataRow.Tag;
                m_fSelectedTmg = (FTcpMessage)grdMessage.activeDataRow.Tag;
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

        #region FTcpMessageSelector Form Event Handler

        private void FTcpMessageSelector_Load(
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

        private void FTcpMessageSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldTmg != null)
                {
                    m_fOldTml = m_fOldTmg.fParent.fParent;
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

                m_fSelectedTdv = null;
                m_fSelectedTsn = null;
                m_fSelectedTmg = null;
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
