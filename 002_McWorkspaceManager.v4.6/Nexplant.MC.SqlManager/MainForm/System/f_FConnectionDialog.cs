/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FConnectionDialog.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.23
--  Description     : FAMate SQL Manager Connection Dialog Form Class 
--  History         : Created by mj.kim at 2011.09.23
                    : Modified by spike.lee at 2012.04.06
                        - Source Tuning
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Infragistics.Win.UltraWinExplorerBar;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;


namespace Nexplant.MC.SqlManager
{
    public partial class FConnectionDialog : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FConnectionDialog(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FConnectionDialog(
            FSqmCore fSqmCore
            ) 
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
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
                    m_fSqmCore = null;
                }
            }
            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void setTitle(
            )
        {
            string caption = string.Empty;

            try
            {
                caption = m_fSqmCore.fWsmCore.fUIWizard.searchCaption(this.Text);
                this.Text = caption;
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

        protected override void changeControlCaption(
            )
        {
            try
            {
                base.changeControlCaption();
                setTitle();
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

        private void designExplorerBarOfConnection(
            )
        {
            try
            {
                exbExplorer.beginUpdate();

                // --

                exbExplorer.Groups.Add("Connection", "Connection");

                // --

                exbExplorer.endUpdate();
            }
            catch (Exception ex)
            {
                exbExplorer.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void refreshExplorerBarOfConnection(
            )
        {
            UltraExplorerBarGroup group = null;
            UltraExplorerBarItem item = null;

            try
            {
                exbExplorer.beginUpdate();

                // --
                
                group = exbExplorer.Groups["Connection"];
                group.Items.Clear();
                // --
                foreach (FConnectionOption source in m_fSqmCore.fOption.connectionOptionList)
                {
                    item = group.Items.Add(source.connection, source.connection);
                    item.Tag = source;
                }

                //--

                exbExplorer.endUpdate();

                // --

                if (group.Items.Count == 0)
                {
                    btnOk.Enabled = false;
                }
                else
                {
                    if (group.Items.Exists(m_fSqmCore.fOption.connection))
                    {
                        group.Items[m_fSqmCore.fOption.connection].Active = true;
                    }
                    // --
                    if (exbExplorer.ActiveItem == null)
                    {
                        group.Items[0].Active = true;
                    }
                    // --
                    btnOk.Enabled = true;
                }
                exbExplorer.Select();                
            }
            catch (Exception ex)
            {
                exbExplorer.endUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                group = null;
                item = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FConnectionDialog Form Event Handler

        private void FConnectionDialog_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                // ***
                // H101 Terminate
                // ***
                m_fSqmCore.termH101();

                // --

                designExplorerBarOfConnection();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fSqmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void FConnectionDialog_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshExplorerBarOfConnection();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fSqmContainer);
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
            FConnectionOption source = null;

            try
            {
                FCursor.waitCursor();

                // --

                source = (FConnectionOption)exbExplorer.ActiveItem.Tag;

                // --

                m_fSqmCore.fOption.connection = source.connection;
                m_fSqmCore.fOption.connectionDescription = source.connectionDescription;
                // --
                m_fSqmCore.fOption.connectionStationConnectString = source.connectionStationConnectString;
                m_fSqmCore.fOption.connectionStationTimeout = source.connectionStationTimeout;
                // --
                m_fSqmCore.fOption.connectionTuneChannelId = source.connectionTuneChannelId;
                m_fSqmCore.fOption.connectionCastChannelId = source.connectionCastChannelId;
                // --
                m_fSqmCore.fOption.connectionftpIp = source.connectionFtpIp;
                m_fSqmCore.fOption.connectionFtpUsedAnonymous = source.connectionFtpUsedAnonymous;
                m_fSqmCore.fOption.connectionFtpUser = source.connectionFtpUser;
                m_fSqmCore.fOption.connectionFtpPassword = source.connectionFtpPassword;

                // --

                m_fSqmCore.initH101();
                m_fSqmCore.fOption.isConnect = true;
                
                // --
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fSqmContainer);
            }
            finally
            {
                source = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnOption Control Event Handler

        private void btnOption_Click(
            object sender, 
            EventArgs e
            )
        {
            FOptionDialog fDialog = null;

            try
            {
                FCursor.waitCursor();

                // --

                fDialog = new FOptionDialog(m_fSqmCore, FOptionTab.Connection);
                // --
                if (fDialog.ShowDialog(this) == DialogResult.OK)
                {
                   // m_fSqmCore.fOption.save();
                }               

                // --

                refreshExplorerBarOfConnection();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fSqmContainer);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region exbExplorer Control Event Handler

        private void exbExplorer_ItemDoubleClick(
            object sender, 
            ItemEventArgs e
            )
        {
            FConnectionOption source = null;

            try
            {
                FCursor.waitCursor();

                // --

                source = (FConnectionOption)e.Item.Tag;

                // --

                m_fSqmCore.fOption.connection = source.connection;
                m_fSqmCore.fOption.connectionDescription = source.connectionDescription;
                // --
                m_fSqmCore.fOption.connectionStationConnectString = source.connectionStationConnectString;
                m_fSqmCore.fOption.connectionStationTimeout = source.connectionStationTimeout;
                // --
                m_fSqmCore.fOption.connectionTuneChannelId = source.connectionTuneChannelId;
                m_fSqmCore.fOption.connectionCastChannelId = source.connectionCastChannelId;
                // --
                m_fSqmCore.fOption.connectionftpIp = source.connectionFtpIp;
                m_fSqmCore.fOption.connectionFtpUsedAnonymous = source.connectionFtpUsedAnonymous;
                m_fSqmCore.fOption.connectionFtpUser = source.connectionFtpUser;
                m_fSqmCore.fOption.connectionFtpPassword = source.connectionFtpPassword;

                // --

                m_fSqmCore.initH101();
                m_fSqmCore.fOption.isConnect = true;

                // --

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fSqmContainer);
            }
            finally
            {
                source = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end