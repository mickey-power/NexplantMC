/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropServer.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.26
--  Description     : FAMate Admin Manager Server Property Source Object Class 
--  History         : Created by spike.lee at 2012.03.26
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.AdminManager
{
    public class FPropServer : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryServer = "[02] Server";
        private const string CategoryBackupServer = "[03] Backup Server";
        private const string CategoryOption = "[04] Option";

        // --

        private bool m_disposed = false;
        // --
        private string m_server = string.Empty;
        private string m_description = string.Empty;
        private FServerType m_serverType = FServerType.Real;
        private string m_serverIp = string.Empty;
        private FYesNo m_usedBackup = FYesNo.No;
        private FBackupMode m_backupMode = FBackupMode.Manual;
        private string m_backupServer = string.Empty;
        private FYesNo m_opcServerMonitoring = FYesNo.No;
        private bool m_tranEnabled = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropServer(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataTable dt,
            bool tranEnabled
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            m_tranEnabled = tranEnabled;
            // --
            init(dt);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropServer(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            bool readOnly
            )
            : this(fAdmCore, fPropGrid, null, readOnly)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropServer(
           )
        {
            myDispose(false);
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
                    
                }                
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region General

        [Category(CategoryGeneral)]
        public string Server
        {
            get
            {
                try
                {
                    return m_server;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {                   
                    m_server = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string Description
        {
            get
            {
                try
                {
                    return m_description;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    m_description = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Server

        [Category(CategoryServer)]
        public FServerType ServerType
        {
            get
            {
                try
                {
                    return m_serverType;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FServerType.Real;
            }

            set
            {
                try
                {
                    m_serverType = value;
                    // --
                    setChangedServerType();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryServer)]
        public string ServerIp
        {
            get
            {
                try
                {
                    return m_serverIp;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }

            set
            {
                try
                {
                    m_serverIp = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Backup Server

        [Category(CategoryBackupServer)]
        public FYesNo UsedBackup
        {
            get
            {
                try
                {
                    return m_usedBackup;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_usedBackup = value;
                    // --
                    setChangedUsedBackup();
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryBackupServer)]
        public FBackupMode BackupMode
        {
            get
            {
                try
                {
                    return m_backupMode;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FBackupMode.Manual;
            }

            set
            {
                try
                {
                    m_backupMode = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryBackupServer)]
        [Editor(typeof(FPropAttrBackupServerUITypeEditor), typeof(UITypeEditor))]
        public string BackupServer
        {
            get
            {
                try
                {
                    return m_backupServer;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return string.Empty;
            }

            internal set
            {
                try
                {
                    m_backupServer = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Option

        [Category(CategoryOption)]
        public FYesNo OpcServerMonitoring
        {
            get
            {
                try
                {
                    return m_opcServerMonitoring;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_opcServerMonitoring = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, this.mainObject.fWsmCore.fWsmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            DataTable dt
            )
        {
            try
            {
                if (dt != null)
                {
                    m_server = dt.Rows[0][0].ToString();
                    m_description = dt.Rows[0][1].ToString();
                    m_serverType = (FServerType)Enum.Parse(typeof(FServerType), dt.Rows[0][2].ToString());
                    m_serverIp = dt.Rows[0][3].ToString();
                    m_usedBackup = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][4].ToString());
                    m_backupMode = (FBackupMode)Enum.Parse(typeof(FBackupMode), dt.Rows[0][5].ToString());
                    m_backupServer = dt.Rows[0][6].ToString();
                    m_opcServerMonitoring = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][7].ToString());
                }

                // --

                base.fTypeDescriptor.properties["Server"].attributes.replace(new DisplayNameAttribute("Server"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                // --
                base.fTypeDescriptor.properties["ServerType"].attributes.replace(new DisplayNameAttribute("Server Type"));
                base.fTypeDescriptor.properties["ServerIp"].attributes.replace(new DisplayNameAttribute("Server IP"));
                // --
                base.fTypeDescriptor.properties["UsedBackup"].attributes.replace(new DisplayNameAttribute("Used Backup"));
                base.fTypeDescriptor.properties["BackupMode"].attributes.replace(new DisplayNameAttribute("Backup Mode"));
                base.fTypeDescriptor.properties["BackupServer"].attributes.replace(new DisplayNameAttribute("Backup Server"));
                // --
                base.fTypeDescriptor.properties["OpcServerMonitoring"].attributes.replace(new DisplayNameAttribute("OPC Server Monitoring"));

                // --

                // ***
                // 2014.09.10 by spike.lee
                // 데이터 키 정의
                // ***
                base.fTypeDescriptor.properties["Server"].attributes.replace(new ParenthesizePropertyNameAttribute(true));

                // --

                base.fTypeDescriptor.properties["Server"].attributes.replace(new DefaultValueAttribute(m_server));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                // --
                base.fTypeDescriptor.properties["ServerType"].attributes.replace(new DefaultValueAttribute(m_serverType));
                base.fTypeDescriptor.properties["ServerIp"].attributes.replace(new DefaultValueAttribute(m_serverIp));
                // --
                base.fTypeDescriptor.properties["UsedBackup"].attributes.replace(new DefaultValueAttribute(m_usedBackup));
                base.fTypeDescriptor.properties["BackupMode"].attributes.replace(new DefaultValueAttribute(m_backupMode));
                base.fTypeDescriptor.properties["BackupServer"].attributes.replace(new DefaultValueAttribute(m_backupServer));
                // --
                base.fTypeDescriptor.properties["OpcServerMonitoring"].attributes.replace(new DefaultValueAttribute(m_opcServerMonitoring));

                // --

                if (!m_tranEnabled)
                {
                    base.fTypeDescriptor.properties["Server"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["Description"].attributes.replace(new ReadOnlyAttribute(true));
                    // --                    
                    base.fTypeDescriptor.properties["ServerType"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["ServerIp"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["UsedBackup"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["BackupMode"].attributes.replace(new ReadOnlyAttribute(true));
                    base.fTypeDescriptor.properties["BackupServer"].attributes.replace(new ReadOnlyAttribute(true));
                    // --
                    base.fTypeDescriptor.properties["OpcServerMonitoring"].attributes.replace(new ReadOnlyAttribute(true));

                    // --
                    
                    base.fTypeDescriptor.properties["BackupServer"].attributes.replace(new EditorAttribute(string.Empty, typeof(UITypeEditor)));                    
                }

                // --

                setChangedServerType();
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

        private void setChangedServerType(
            )
        {
            bool browsable = false;

            try
            {
                if (m_serverType == FServerType.Virtual)
                {
                    m_serverIp = string.Empty;
                    m_usedBackup = FYesNo.No;
                    m_opcServerMonitoring = FYesNo.No;
                    browsable = false;
                }
                else
                {
                    browsable = true;
                }

                // --
                
                base.fTypeDescriptor.properties["ServerIp"].attributes.replace(new BrowsableAttribute(browsable));
                base.fTypeDescriptor.properties["UsedBackup"].attributes.replace(new BrowsableAttribute(browsable));
                base.fTypeDescriptor.properties["OpcServerMonitoring"].attributes.replace(new BrowsableAttribute(browsable));
                // --

                setChangedUsedBackup();
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

        private void setChangedUsedBackup(
            )
        {
            bool browsable = false;

            try
            {
                if (m_usedBackup == FYesNo.No)
                {
                    m_backupMode = FBackupMode.Manual;
                    m_backupServer = string.Empty;
                    browsable = false;
                }
                else
                {
                    browsable = true;
                }

                // --

                base.fTypeDescriptor.properties["BackupMode"].attributes.replace(new BrowsableAttribute(browsable));
                base.fTypeDescriptor.properties["BackupServer"].attributes.replace(new BrowsableAttribute(browsable));

                // --

                this.fPropGrid.Refresh();
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

    }   // Class end
}   // Namespace end
