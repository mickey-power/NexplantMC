/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpDeviceSelector.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.09
--  Description     : FAMate TCP Modeler TCP Device Selector Form Class 
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
    public partial class FTcpDeviceSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FTcpDevice m_fOldTdv = null;
        private FTcpDevice m_fSelectedTdv = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpDeviceSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpDeviceSelector(
            FTcmCore fTcmCore,
            FTcpDevice fOldTdv
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
            m_fOldTdv = fOldTdv;
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
                    m_fSelectedTdv = null;
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
                m_fSelectedTdv = (FTcpDevice)grdDevice.activeDataRow.Tag;
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

        #region FTcpDeviceSelector Form Event Handler

        private void FTcpDeviceSelector_Load(
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

        private void FTcpDeviceSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOldTdv != null)
                {
                    btnReset.Enabled = true;
                }

                // --
                
                refreshGridOfDevice();

                // --      
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

                m_fSelectedTdv = null;
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
