/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FHostDeviceSelector.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.09
--  Description     : FAMate TCP Modeler Host Device Selector Form Class 
--  History         : Created by Jeff.Kim at 2013.07.09
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
    public partial class FHostDeviceSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FHostDevice m_fOldHdv = null;
        private FHostDevice m_fSelectedHdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostDeviceSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FHostDeviceSelector(
            FTcmCore fTcmCore,
            FHostDevice fOldHdv
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fOldHdv = fOldHdv;
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
                    m_fSelectedHdv = null;
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
                else
                {
                    btnOk.Enabled = false;
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

        private void selectDevice(
            )
        {
            try
            {
                m_fSelectedHdv = (FHostDevice)grdDevice.activeDataRow.Tag;
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

        #region FHostDeviceSelector Form Event Handler

        private void FHostDeviceSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designGridOfDevice();

                // --

                grdDevice.Visible = true;
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

        private void FHostDeviceSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldHdv != null)
                {
                    btnReset.Enabled = true;
                }

                // --
                
                refreshGridOfDevice();                   
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

                selectDevice();
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

                selectDevice();
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
