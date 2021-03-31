/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : f_FSetupOption.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.23
--  Description     : FAMate SQL Manager Option Setup Form Class 
--  History         : Created by mj.kim at 2011.09.23
                    : Modified by spike.lee at 2012.04.09
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
    public partial class FOptionDialog : Nexplant.MC.Core.FaUIs.FBaseStandardDialogForm
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;
        private FOptionTab m_fOptionTab = FOptionTab.Connection;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOptionDialog(
            )
        {
            InitializeComponent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOptionDialog(
            FSqmCore fSqmCore,
            FOptionTab fOptionTab        
            )
            : this()
        {
            base.fUIWizard = fSqmCore.fUIWizard;
            m_fSqmCore = fSqmCore;
            m_fOptionTab = fOptionTab;
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

        private void designExplorerBar(
            )
        {
            try
            {
                exbExplorer.beginUpdate();

                // --

                foreach (string s in Enum.GetNames(typeof(FOptionTab)))
                {
                    exbExplorer.Groups.Add(s, s);
                }

                // --

                if (m_fOptionTab == FOptionTab.Connection)
                {
                    exbExplorer.Groups[FOptionTab.Database.ToString()].Visible = false;
                }
                else if (m_fOptionTab == FOptionTab.Database)
                {
                    exbExplorer.Groups[FOptionTab.Connection.ToString()].Visible = false;
                }                

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

        private void refreshExplorerBar(
            )
        {
            UltraExplorerBarGroup group = null;
            UltraExplorerBarItem item = null;

            try
            {
                exbExplorer.BeginUpdate();

                // --

                group = exbExplorer.Groups[m_fOptionTab.ToString()];
                // --
                if (m_fOptionTab == FOptionTab.Connection)
                {
                    foreach (FConnectionOption source in m_fSqmCore.fOption.connectionOptionList)
                    {
                        item = group.Items.Add(source.connection, source.connection);
                        item.Tag = source;
                    }
                }
                else
                {
                    foreach (FDatabaseOption source in m_fSqmCore.fOption.databaseOptionList)
                    {
                        item = group.Items.Add(source.database, source.database);
                        item.Tag = source;
                    }
                }
                
                // --

                exbExplorer.EndUpdate();
                
                // --

                if (group.Items.Count == 0)
                {
                    if (m_fOptionTab == FOptionTab.Connection)
                    {
                        initPropOfConnectionOption();
                    }
                    else
                    {
                        initPropOfDatabaseOption();
                    }
                    btnOk.Enabled = false;
                    btnDelete.Enabled = false;
                }
                else
                {
                    if (m_fOptionTab == FOptionTab.Connection)
                    {
                        if (group.Items.Exists(m_fSqmCore.fOption.connection))
                        {
                            group.Items[m_fSqmCore.fOption.connection].Active = true;
                        }
                    }
                    else
                    {
                        if (group.Items.Exists(m_fSqmCore.fOption.database))
                        {
                            group.Items[m_fSqmCore.fOption.database].Active = true;
                        }
                    }
                    // --
                    if (exbExplorer.ActiveItem == null)
                    {
                        group.Items[0].Active = true;
                    }
                }
                exbExplorer.Select();
            }
            catch (Exception ex)
            {
                exbExplorer.EndUpdate();
                FDebug.throwException(ex);
            }
            finally
            {
                group = null;
                item = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfConnectionOption(
            )
        {
            FConnectionOption source = null;

            try
            {
                source = new FConnectionOption();

                // --

                source.connection = string.Empty;
                source.connectionDescription = string.Empty;
                // --
                source.connectionStationConnectString = string.Empty;
                source.connectionStationTimeout = 0;
                // --
                source.connectionTuneChannelId = string.Empty;
                source.connectionCastChannelId = string.Empty;
                // --
                source.connectionFtpIp = string.Empty;
                source.connectionFtpUsedAnonymous = true;
                source.connectionFtpUser = string.Empty;
                source.connectionFtpPassword = string.Empty;

                // --

                pgdProp.selectedObject = new FPropConnectionOption(m_fSqmCore, pgdProp, source);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (source != null)
                {
                    source.Dispose();
                    source = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void initPropOfDatabaseOption(
            )
        {
            FDatabaseOption source = null;

            try
            {
                source = new FDatabaseOption();

                // --

                source.database = string.Empty;
                source.databaseDescription = FXmlTagSQMOption.D_DatabaseDescription;
                // --
                source.fDatabaseProvider = (FDbProvider)Enum.Parse(typeof(FDbProvider), FXmlTagSQMOption.D_DatabaseProvider);
                source.databaseConnectString = string.Empty;
                source.databasePassword = string.Empty;
                source.databaseTimeout = 0;

                // --

                pgdProp.selectedObject = new FPropOptionDatabase(m_fSqmCore, pgdProp, source);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (source != null)
                {
                    source.Dispose();
                    source = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setPropOfConnectionOption(
            )
        {
            FConnectionOption source = null;
            FConnectionOption target = null;

            try
            {
                source = (FConnectionOption)exbExplorer.ActiveItem.Tag;
                target = new FConnectionOption();

                // --

                target.connection = source.connection;
                target.connectionDescription = source.connectionDescription;
                // --
                target.connectionStationConnectString = source.connectionStationConnectString;
                target.connectionStationTimeout = source.connectionStationTimeout;
                // --
                target.connectionTuneChannelId = source.connectionTuneChannelId;
                target.connectionCastChannelId = source.connectionCastChannelId;
                // --
                target.connectionFtpIp = source.connectionFtpIp;
                target.connectionFtpUsedAnonymous = source.connectionFtpUsedAnonymous;
                target.connectionFtpUser = source.connectionFtpUser;
                target.connectionFtpPassword = source.connectionFtpPassword;

                // --

                pgdProp.selectedObject = new FPropConnectionOption(m_fSqmCore, pgdProp, target);
                btnOk.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (source != null)
                {
                    source.Dispose();
                    source = null;
                }
                // --
                if (target != null)
                {
                    target.Dispose();
                    target = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setPropOfDatabaseOption(
            )
        {
            FDatabaseOption source = null;
            FDatabaseOption target = null;

            try
            {
                source = (FDatabaseOption)exbExplorer.ActiveItem.Tag;
                target = new FDatabaseOption();

                // --

                target.database = source.database;
                target.databaseDescription = source.databaseDescription;
                // --
                target.fDatabaseProvider = source.fDatabaseProvider;
                target.databaseConnectString = source.databaseConnectString;
                target.databasePassword = source.databasePassword;
                target.databaseTimeout = source.databaseTimeout;

                // --

                pgdProp.selectedObject = new FPropOptionDatabase(m_fSqmCore, pgdProp, target);
                btnOk.Enabled = true;
                btnDelete.Enabled = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (source != null)
                {
                    source.Dispose();
                    source = null;
                }
                // --
                if (target != null)
                {
                    target.Dispose();
                    target = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FOptionDialog Form Event Handler

        private void FOptionDialog_Load(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                designExplorerBar();
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

        private void FOptionDialog_Shown(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                refreshExplorerBar();
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
            FConnectionOption source1 = null;
            FDatabaseOption source2 = null;

            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOptionTab == FOptionTab.Connection)
                {
                    source1 = (FConnectionOption)exbExplorer.ActiveItem.Tag;

                    // --

                    m_fSqmCore.fOption.connection = source1.connection;
                    m_fSqmCore.fOption.connectionDescription = source1.connectionDescription;
                    // --
                    m_fSqmCore.fOption.connectionStationConnectString = source1.connectionStationConnectString;
                    m_fSqmCore.fOption.connectionStationTimeout = source1.connectionStationTimeout;
                    // --
                    m_fSqmCore.fOption.connectionTuneChannelId = source1.connectionTuneChannelId;
                    m_fSqmCore.fOption.connectionCastChannelId = source1.connectionCastChannelId;
                    // --
                    m_fSqmCore.fOption.connectionftpIp = source1.connectionFtpIp;
                    m_fSqmCore.fOption.connectionFtpUsedAnonymous = source1.connectionFtpUsedAnonymous;
                    m_fSqmCore.fOption.connectionFtpUser = source1.connectionFtpUser;
                    m_fSqmCore.fOption.connectionFtpPassword = source1.connectionFtpPassword;
                }
                else
                {
                    source2 = (FDatabaseOption)exbExplorer.ActiveItem.Tag;

                    // --

                    m_fSqmCore.fOption.database = source2.database;
                    m_fSqmCore.fOption.databaseDescription = source2.databaseDescription;
                    // --
                    m_fSqmCore.fOption.databaseProvider = source2.fDatabaseProvider;
                    m_fSqmCore.fOption.databaseConnectString = source2.databaseConnectString;
                    m_fSqmCore.fOption.databasePassword = source2.databasePassword;
                    m_fSqmCore.fOption.databaseTimeout = source2.databaseTimeout;
                    m_fSqmCore.fOption.databaseDecodingConnectString = string.Format(source2.databaseConnectString, source2.databasePassword);
                }

                // --
                    
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                source1 = null;
                source2 = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnUpdate Control Event Handler

        private void btnUpdate_Click(
            object sender,
            EventArgs e
            )
        {
            FConnectionOption source1 = null;
            FDatabaseOption source2 = null;
            UltraExplorerBarGroup group = null;
            UltraExplorerBarItem item = null;

            try
            {
                FCursor.waitCursor();

                // --

                exbExplorer.beginUpdate();

                // --

                if (m_fOptionTab == FOptionTab.Connection)
                {
                    source1 = ((FPropConnectionOption)pgdProp.selectedObject).source;

                    // --

                    FCommon.validateName(source1.connection, true, this.fUIWizard);

                    if (source1.connectionStationConnectString.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Station Connect String" }));
                    }

                    if (source1.connectionStationTimeout < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Station Timeout" }));
                    }

                    if (source1.connectionTuneChannelId.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Tune Channel ID" }));
                    }

                    if (source1.connectionCastChannelId.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Cast Channel ID" }));
                    }

                    if (source1.connectionFtpIp.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "FTP IP" }));
                    }

                    if (!source1.connectionFtpUsedAnonymous)
                    {
                        if (source1.connectionFtpUser.Trim() == string.Empty)
                        {
                            FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "FTP User" }));
                        }
                    }

                    // --

                    m_fSqmCore.fOption.updateConnectionOption(source1);
                    // --
                    group = exbExplorer.Groups[m_fOptionTab.ToString()];
                    if (group.Items.Exists(source1.connection))
                    {
                        item = group.Items[source1.connection];
                    }
                    else
                    {
                        item = group.Items.Add(source1.connection, source1.connection);
                    }
                    item.Tag = source1;
                }
                else
                {
                    source2 = ((FPropOptionDatabase)pgdProp.selectedObject).source;

                    // --

                    FCommon.validateName(source2.database, true, this.fUIWizard);

                    if (source2.databaseConnectString.Trim() == string.Empty)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0001", new object[] { "Database Connect String" }));
                    }

                    if (source2.databaseTimeout < 1)
                    {
                        FDebug.throwFException(fUIWizard.generateMessage("E0005", new object[] { "Database Timeout" }));
                    }

                    // --

                    m_fSqmCore.fOption.updateDatabaseOption(source2);
                    // --
                    group = exbExplorer.Groups[m_fOptionTab.ToString()];
                    if (group.Items.Exists(source2.database))
                    {
                        item = group.Items[source2.database];
                    }
                    else
                    {
                        item = group.Items.Add(source2.database, source2.database);
                    }
                    item.Tag = source2;
                }
                item.Active = true;

                // --

                exbExplorer.endUpdate();
            }
            catch (Exception ex)
            {
                exbExplorer.endUpdate(); 
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                source1 = null;
                source2 = null;
                group = null;
                item = null;

                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnClear Control Event Handler

        private void btnClear_Click(
            object sender,
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (m_fOptionTab == FOptionTab.Connection)
                {
                    initPropOfConnectionOption();
                }
                else
                {
                    initPropOfDatabaseOption();
                }
            }
            catch (Exception ex)
            {
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fWsmCore.fWsmContainer);
            }
            finally
            {
                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region btnDelete Control Event Handler

        private void btnDelete_Click(
            object sender,
            EventArgs e
            )
        {
            UltraExplorerBarGroup group = null;
            UltraExplorerBarItem item = null;
            int index = -1;

            try
            {
                FCursor.waitCursor();

                // --

                exbExplorer.beginUpdate();

                // --

                item = exbExplorer.ActiveItem;
                if (item == null)
                {
                    return;
                }

                // --

                group = item.Group;
                index = item.Index;
                // --
                if (m_fOptionTab == FOptionTab.Connection)
                {
                    m_fSqmCore.fOption.deleteConnectionOption((FConnectionOption)item.Tag);
                }
                else
                {
                    m_fSqmCore.fOption.deleteDatabaseOption((FDatabaseOption)item.Tag);
                }
                group.Items.RemoveAt(index);                

                // --

                exbExplorer.endUpdate(); 

                // --
                
                while (true)
                {
                    if (index < group.Items.Count)
                    {
                        break;
                    }

                    index--;
                }

                if (index >= 0)
                {
                    group.Items[index].Active = true;
                }

                // --

                if (group.Items.Count == 0)
                {
                    if (m_fOptionTab == FOptionTab.Connection)
                    {
                        initPropOfConnectionOption();
                    }
                    else
                    {
                        initPropOfDatabaseOption();
                    }
                    btnOk.Enabled = false;
                    btnDelete.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                exbExplorer.endUpdate(); 
                FMessageBox.showError(FConstants.ApplicationName, ex, m_fSqmCore.fSqmContainer);
            }
            finally
            {
                group = null;
                item = null;
                
                // --

                FCursor.defaultCursor();
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region exbExlorer Control Event Handler

        private void exbExplorer_ActiveItemChanged(
            object sender, 
            ItemEventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (e.Item == null)
                {
                    return;
                }

                // --

                e.Item.Checked = true;
                if (m_fOptionTab == FOptionTab.Connection)
                {
                    setPropOfConnectionOption();
                }
                else
                {
                    setPropOfDatabaseOption();
                }
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

        private void exbExplorer_Enter(
            object sender, 
            EventArgs e
            )
        {
            try
            {
                FCursor.waitCursor();

                // --

                if (exbExplorer.ActiveItem == null)
                {
                    return;
                }

                // --

                exbExplorer.ActiveItem.Checked = true;
                if (m_fOptionTab == FOptionTab.Connection)
                {
                    setPropOfConnectionOption();
                }
                else
                {
                    setPropOfDatabaseOption();
                }
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

    }   // Class end
}   // Namespace end