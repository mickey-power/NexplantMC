/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FOpcMessageSelector.cs
--  Creator         : spike.lee
--  Create Date     : 2011.07.28
--  Description     : FAMate OPC Modeler OPC Message Selector Form Class 
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
using Nexplant.MC.Core.FaOpcDriver;
using Nexplant.MC.WorkspaceInterface;
using Infragistics.Win.UltraWinDataSource;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win;

namespace Nexplant.MC.OpcModeler
{
    public partial class FOpcMessageSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpmCore m_fOpmCore = null;
        private FOpcDevice m_fOldOdv = null;
        private FOpcSession m_fOldOsn = null;
        private FOpcMessageList m_fOldOml = null;
        private FOpcMessage m_fOldOmg = null;
        private FOpcDevice m_fSelectedOdv = null;
        private FOpcSession m_fSelectedOsn = null;
        private FOpcMessage m_fSelectedOmg = null;
        private int m_step = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOpcMessageSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOpcMessageSelector(
            FOpmCore fOpmCore,
            FOpcDevice fOldOdv,
            FOpcSession fOldOsn,
            FOpcMessage fOldOmg
            )
            : this()
        {
            base.fUIWizard = fOpmCore.fUIWizard;
            // --
            m_fOpmCore = fOpmCore;
            m_fOldOdv = fOldOdv;
            m_fOldOsn = fOldOsn;            
            m_fOldOmg = fOldOmg;
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
                    m_fOldOdv = null;
                    m_fOldOsn = null;
                    m_fOldOml = null;
                    m_fOldOmg = null;
                    m_fSelectedOdv = null;
                    m_fSelectedOsn = null;
                    m_fSelectedOmg = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FOpcDevice fSelectedDevice
        {
            get
            {
                try
                {
                    return m_fSelectedOdv;
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

        public FOpcSession fSelectedSession
        {
            get
            {
                try
                {
                    return m_fSelectedOsn;
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

        public FOpcMessage fSelectedMessage
        {
            get
            {
                try
                {
                    return m_fSelectedOmg;
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
                uds.Band.Columns.Add("OPC Device");
                uds.Band.Columns.Add("Mode");
                uds.Band.Columns.Add("Protocol");
                uds.Band.Columns.Add("Description");

                // --

                grdDevice.DisplayLayout.Bands[0].Columns["OPC Device"].CellAppearance.Image = Properties.Resources.OpcDevice;
                // --
                grdDevice.DisplayLayout.Bands[0].Columns["OPC Device"].Width = 150;
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
                uds.Band.Columns.Add("OPC Session");
                uds.Band.Columns.Add("Session ID");
                uds.Band.Columns.Add("Library");
                uds.Band.Columns.Add("Description");

                // --

                grdSession.DisplayLayout.Bands[0].Columns["OPC Session"].CellAppearance.Image = Properties.Resources.OpcSession_unlock;
                grdSession.DisplayLayout.Bands[0].Columns["Session ID"].CellAppearance.TextHAlign = HAlign.Right;
                // --
                grdSession.DisplayLayout.Bands[0].Columns["OPC Session"].Width = 150;
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
                uds.Band.Columns.Add("OPC Message List");                
                uds.Band.Columns.Add("Description");

                // --

                grdMessageList.DisplayLayout.Bands[0].Columns["OPC Message List"].CellAppearance.Image = Properties.Resources.OpcMessageList_unlock;
                // --
                grdMessageList.DisplayLayout.Bands[0].Columns["OPC Message List"].Width = 150;
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
                uds.Band.Columns.Add("OPC Message");
                uds.Band.Columns.Add("Description");

                // --

                grdMessage.DisplayLayout.Bands[0].Columns["OPC Message"].CellAppearance.Image = Properties.Resources.OpcMessage;
                // --
                grdMessage.DisplayLayout.Bands[0].Columns["OPC Message"].Width = 200;
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

                foreach (FOpcDevice fOdv in m_fOpmCore.fOpmFileInfo.fOpcDriver.fChildOpcDeviceCollection)
                {
                    cellValues = new object[] {
                        fOdv.name,
                        fOdv.fDeviceType.ToString(),
                        fOdv.fProtocol.ToString(),
                        fOdv.description
                    };
                    dataRow = grdDevice.appendDataRow(fOdv.uniqueIdToString, cellValues);
                    dataRow.Tag = fOdv;
                    FCommon.refreshGridRowOfObject(fOdv, grdDevice.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fOdv == m_fOldOdv)
                    {
                        activeDataRowKey = fOdv.uniqueIdToString;
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
            FOpcDevice fOdv = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fOdv = (FOpcDevice)grdDevice.activeDataRow.Tag;

                // --

                grdSession.beginUpdate(false);

                // --

                grdSession.removeAllDataRow();

                // --

                foreach (FOpcSession fOsn in fOdv.fChildOpcSessionCollection)
                {
                    cellValues = new object[] {
                        fOsn.name,
                        fOsn.sessionId.ToString(),
                        (fOsn.hasLibrary ? fOsn.fLibrary.name : string.Empty),
                        fOsn.description
                    };
                    dataRow = grdSession.appendDataRow(fOsn.uniqueIdToString, cellValues);
                    dataRow.Tag = fOsn;
                    FCommon.refreshGridRowOfObject(fOsn, grdSession.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fOsn == m_fOldOsn)
                    {
                        activeDataRowKey = fOsn.uniqueIdToString;
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
                fOdv = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfMessageList(
            )
        {
            FOpcSession fOsn = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fOsn = (FOpcSession)grdSession.activeDataRow.Tag;

                // --

                grdMessageList.beginUpdate(false);

                // --

                grdMessageList.removeAllDataRow();

                // --

                if (fOsn.hasLibrary)
                {
                    foreach (FOpcMessageList fOml in fOsn.fLibrary.fChildOpcMessageListCollection)
                    {
                        cellValues = new object[] {
                            fOml.name,                            
                            fOml.description
                        };
                        dataRow = grdMessageList.appendDataRow(fOml.uniqueIdToString, cellValues);
                        dataRow.Tag = fOml;
                        FCommon.refreshGridRowOfObject(fOml, grdMessageList.Rows.GetRowWithListIndex(dataRow.Index));

                        // --

                        if (fOml == m_fOldOml)
                        {
                            activeDataRowKey = fOml.uniqueIdToString;
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
                fOsn = null;
                dataRow = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshGridOfMessage(
            )
        {
            FOpcMessageList fOml = null;
            object[] cellValues = null;
            UltraDataRow dataRow = null;
            string activeDataRowKey = string.Empty;

            try
            {
                fOml = (FOpcMessageList)grdMessageList.activeDataRow.Tag;

                // --

                grdMessage.beginUpdate(false);

                // --

                grdMessage.removeAllDataRow();

                // --

                foreach (FOpcMessage fOmg in fOml.fDescendantOpcMessageCollection)
                {
                    cellValues = new object[] {
                        fOmg.name,
                        fOmg.description
                    };
                    dataRow = grdMessage.appendDataRow(fOmg.uniqueIdToString, cellValues);
                    dataRow.Tag = fOmg;
                    FCommon.refreshGridRowOfObject(fOmg, grdMessage.Rows.GetRowWithListIndex(dataRow.Index));

                    // --

                    if (fOmg == m_fOldOmg)
                    {
                        activeDataRowKey = fOmg.uniqueIdToString;
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
                fOml = null;
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
                m_fSelectedOdv = (FOpcDevice)grdDevice.activeDataRow.Tag;
                m_fSelectedOsn = (FOpcSession)grdSession.activeDataRow.Tag;
                m_fSelectedOmg = (FOpcMessage)grdMessage.activeDataRow.Tag;
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

        #region FOpcMessageSelector Form Event Handler

        private void FOpcMessageSelector_Load(
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FOpcMessageSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldOmg != null)
                {
                    m_fOldOml = m_fOldOmg.fParent.fParent;
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fOpmCore.fWsmCore.fWsmContainer);
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

                m_fSelectedOdv = null;
                m_fSelectedOsn = null;
                m_fSelectedOmg = null;
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

    }   // Class end
}   // Namespace end
