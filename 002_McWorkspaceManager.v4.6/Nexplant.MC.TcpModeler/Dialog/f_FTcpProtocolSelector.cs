/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FTcpProtocolSelector.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2016.04.27
--  Description     : FAMate TCP Modeler Protocol Selector Form Class 
--  History         : Created by jungyoul.moon at 2016.04.27
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
    public partial class FTcpProtocolSelector : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcmCore m_fTcmCore = null;
        private FProtocol m_fSelectedProtocol = FProtocol.CUSTOM_001;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpProtocolSelector(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcpProtocolSelector(
            FTcmCore fTcmCore
            )
            : this()
        {
            base.fUIWizard = fTcmCore.fUIWizard;
            m_fTcmCore = fTcmCore;
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
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FProtocol fSelectedProtocol
        {
            get
            {
                try
                {
                    return m_fSelectedProtocol;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FProtocol.CUSTOM_001;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void designComboOfProtocol(
            )
        {
            UltraDataSource uds = null;

            try
            {
                uds = ucbProtocol.dataSource;
                // --
                uds.Band.Columns.Add("Protocol");

                // --

                ucbProtocol.Appearance.Image = Properties.Resources.TcpDevice;
                // --
                ucbProtocol.DisplayLayout.Bands[0].Columns["Protocol"].CellAppearance.Image = Properties.Resources.TcpDevice;
                ucbProtocol.DisplayLayout.Bands[0].Columns["Protocol"].Width = ucbProtocol.Width - 2;
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

        private void refreshComboOfProtocol(
            )
        {
            try
            {
                ucbProtocol.beginUpdate(false);
                ucbProtocol.removeAllDataRow();

                // --

                foreach (string s in Enum.GetNames(typeof(FProtocol)))
                {
                    ucbProtocol.appendDataRow(s, new object[] { s });
                }

                // --

                ucbProtocol.endUpdate(false);

                // --

                ucbProtocol.Text = FProtocol.CUSTOM_001.ToString();
            }
            catch (Exception ex)
            {
                ucbProtocol.endUpdate(false);
                FDebug.throwException(ex);
            }
            finally
            {
                
            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void selectTcpProtocol(
            )
        {
            try
            {
                m_fSelectedProtocol = (FProtocol)Enum.Parse(typeof(FProtocol), ucbProtocol.activeDataRowKey);
                // --

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

        #region FTcpProtocolSelector Form Event Handler

        private void FTcpProtocolSelector_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designComboOfProtocol();
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

        private void FTcpProtocolSelector_Shown(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshComboOfProtocol();                   
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

                selectTcpProtocol();
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
