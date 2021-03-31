/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropServerHistory.cs
--  Creator         : mjkim
--  Create Date     : 2013.01.16
--  Description     : FAMate Admin Manager Server History Property Source Object Class 
--  History         : Created by spike.lee at 2013.01.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.AdminManager
{
    public class FPropServerHistory : FDynPropCusBase<FAdmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryEvent = "[02] Event";
        private const string CategoryState = "[03] State"; 
        private const string CategoryBackupServer = "[04] Backup Server";
        private const string CategoryOption = "[05] Option";
        private const string CategoryData = "[06] Data Field";
        private const string CategoryComment = "[07] Comments";

        // --

        private bool m_disposed = false;
        string m_tranTime = string.Empty;
        string m_server = string.Empty;
        string m_eventId = string.Empty;
        string m_serverType = string.Empty;
        string m_serverIp = string.Empty;
        string m_serverUpDown = string.Empty;
        string m_status = string.Empty;
        string m_agentUpDown = string.Empty;
        string m_usedBackup = string.Empty;
        string m_backupMode = string.Empty;
        string m_backupServer = string.Empty;
        string m_backupServerUpDown = string.Empty;
        string m_backupServerStatus = string.Empty;
        string m_backupServerAgent = string.Empty;
        string m_opcServerMonitoring = string.Empty;
        string m_opcServer = string.Empty;
        string m_userId = string.Empty;
        string m_eventHeader1 = string.Empty;
        string m_eventData1 = string.Empty;
        string m_eventHeader2 = string.Empty;
        string m_eventData2 = string.Empty;
        string m_eventHeader3 = string.Empty;
        string m_eventData3 = string.Empty;
        string m_eventHeader4 = string.Empty;
        string m_eventData4 = string.Empty;
        string m_eventHeader5 = string.Empty;
        string m_eventData5 = string.Empty;
        string m_eventHeader6 = string.Empty;
        string m_eventData6 = string.Empty;
        string m_eventHeader7 = string.Empty;
        string m_eventData7 = string.Empty;
        string m_eventHeader8 = string.Empty;
        string m_eventData8 = string.Empty;
        string m_eventHeader9 = string.Empty;
        string m_eventData9 = string.Empty;
        string m_eventHeader10 = string.Empty;
        string m_eventData10 = string.Empty;
        string m_eventHeader11 = string.Empty;
        string m_eventData11 = string.Empty;
        string m_eventHeader12 = string.Empty;
        string m_eventData12 = string.Empty;
        string m_eventHeader13 = string.Empty;
        string m_eventData13 = string.Empty;
        string m_eventHeader14 = string.Empty;
        string m_eventData14 = string.Empty;
        string m_eventHeader15 = string.Empty;
        string m_eventData15 = string.Empty;
        string m_eventHeader16 = string.Empty;
        string m_eventData16 = string.Empty;
        string m_eventHeader17 = string.Empty;
        string m_eventData17 = string.Empty;
        string m_eventHeader18 = string.Empty;
        string m_eventData18 = string.Empty;
        string m_eventHeader19 = string.Empty;
        string m_eventData19 = string.Empty;
        string m_eventHeader20 = string.Empty;
        string m_eventData20 = string.Empty;
        string m_comments = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropServerHistory(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid,
            DataRow dr
            )
            : base(fAdmCore, fAdmCore.fUIWizard, fPropGrid)
        {
            init(dr);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropServerHistory(
            FAdmCore fAdmCore,
            FDynPropGrid fPropGrid
            )
            : this(fAdmCore, fPropGrid, null)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropServerHistory(
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
        public string Time
        {
            get
            {
                try
                {
                    return m_tranTime;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string ServerType
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
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryGeneral)]
        public string UserId
        {
            get
            {
                try
                {
                    return m_userId;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Event

        [Category(CategoryEvent)]
        public string EventId
        {
            get
            {
                try
                {
                    return m_eventId;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region State

        [Category(CategoryState)]
        public string UpDown
        {
            get
            {
                try
                {
                    return m_serverUpDown;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryState)]
        public string Status
        {
            get
            {
                try
                {
                    return m_status;
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
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryState)]
        public string Agent
        {
            get
            {
                try
                {
                    return m_agentUpDown;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region BackupServer

        [Category(CategoryBackupServer)]
        public string UsedBackup
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
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryBackupServer)]
        public string BackupMode
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
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryBackupServer)]
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryBackupServer)]
        public string BackupServerUpDown
        {
            get
            {
                try
                {
                    return m_backupServerUpDown;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryBackupServer)]
        public string BackupServerStatus
        {
            get
            {
                try
                {
                    return m_backupServerStatus;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryBackupServer)]
        public string BackupServerAgent
        {
            get
            {
                try
                {
                    return m_backupServerAgent;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Option

        [Category(CategoryOption)]
        public string OpcServerMonitoring
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
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryOption)]
        public string OpcServer
        {
            get
            {
                try
                {
                    return m_opcServer;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Customizing Field

        [Category(CategoryData)]
        public string Data1
        {
            get
            {
                try
                {
                    return m_eventData1;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data2
        {
            get
            {
                try
                {
                    return m_eventData2;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data3
        {
            get
            {
                try
                {
                    return m_eventData3;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data4
        {
            get
            {
                try
                {
                    return m_eventData4;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data5
        {
            get
            {
                try
                {
                    return m_eventData5;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data6
        {
            get
            {
                try
                {
                    return m_eventData6;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data7
        {
            get
            {
                try
                {
                    return m_eventData7;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data8
        {
            get
            {
                try
                {
                    return m_eventData8;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data9
        {
            get
            {
                try
                {
                    return m_eventData9;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data10
        {
            get
            {
                try
                {
                    return m_eventData10;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data11
        {
            get
            {
                try
                {
                    return m_eventData11;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data12
        {
            get
            {
                try
                {
                    return m_eventData12;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data13
        {
            get
            {
                try
                {
                    return m_eventData13;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data14
        {
            get
            {
                try
                {
                    return m_eventData14;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data15
        {
            get
            {
                try
                {
                    return m_eventData15;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data16
        {
            get
            {
                try
                {
                    return m_eventData16;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data17
        {
            get
            {
                try
                {
                    return m_eventData17;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data18
        {
            get
            {
                try
                {
                    return m_eventData18;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data19
        {
            get
            {
                try
                {
                    return m_eventData19;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryData)]
        public string Data20
        {
            get
            {
                try
                {
                    return m_eventData20;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Comments

        [Category(CategoryComment)]
        [Editor(typeof(FPropAttrCommentViewUITypeEditor), typeof(UITypeEditor))]
        public string Comment
        {
            get
            {
                try
                {
                    return m_comments;
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            DataRow dr
            )
        {
            try
            {
                if (dr != null)
                {
                    m_tranTime            = FDataConvert.defaultDataTimeFormating(dr["TRAN_TIME"].ToString());
                    m_server              = dr["SERVER"].ToString();
                    m_eventId             = dr["EVENT_ID"].ToString();
                    m_serverType          = dr["SVR_TYPE"].ToString();
                    m_serverIp            = dr["SVR_IP"].ToString();
                    m_serverUpDown        = dr["UP_DOWN"].ToString();
                    m_status              = dr["STATUS"].ToString();
                    m_agentUpDown         = dr["ADA_UP_DOWN"].ToString();
                    m_usedBackup          = dr["B_USED"].ToString();
                    m_backupMode          = dr["B_MODE"].ToString();
                    m_backupServer        = dr["B_SERVER"].ToString();
                    m_backupServerUpDown  = dr["B_UP_DOWN"].ToString();
                    m_backupServerStatus  = dr["B_STATUS"].ToString();
                    m_backupServerAgent   = dr["B_ADA_UP_DOWN"].ToString();
                    m_opcServerMonitoring = dr["OPC_SVR_MON"].ToString();
                    m_opcServer           = dr["OPC_SVR_UP_DOWN"].ToString();
                    m_userId              = dr["TRAN_USER_ID"].ToString();
                    m_eventHeader1        = dr["EVT_H_1"].ToString();
                    m_eventData1          = dr["EVT_D_1"].ToString();
                    m_eventHeader2        = dr["EVT_H_2"].ToString();
                    m_eventData2          = dr["EVT_D_2"].ToString();
                    m_eventHeader3        = dr["EVT_H_3"].ToString();
                    m_eventData3          = dr["EVT_D_3"].ToString();
                    m_eventHeader4        = dr["EVT_H_4"].ToString();
                    m_eventData4          = dr["EVT_D_4"].ToString();
                    m_eventHeader5        = dr["EVT_H_5"].ToString();
                    m_eventData5          = dr["EVT_D_5"].ToString();
                    m_eventHeader6        = dr["EVT_H_6"].ToString();
                    m_eventData6          = dr["EVT_D_6"].ToString();
                    m_eventHeader7        = dr["EVT_H_7"].ToString();
                    m_eventData7          = dr["EVT_D_7"].ToString();
                    m_eventHeader8        = dr["EVT_H_8"].ToString();
                    m_eventData8          = dr["EVT_D_8"].ToString();
                    m_eventHeader9        = dr["EVT_H_9"].ToString();
                    m_eventData9          = dr["EVT_D_9"].ToString();
                    m_eventHeader10       = dr["EVT_H_10"].ToString();
                    m_eventData10         = dr["EVT_D_10"].ToString();
                    m_eventHeader11       = dr["EVT_H_11"].ToString();
                    m_eventData11         = dr["EVT_D_11"].ToString();
                    m_eventHeader12       = dr["EVT_H_12"].ToString();
                    m_eventData12         = dr["EVT_D_12"].ToString();
                    m_eventHeader13       = dr["EVT_H_13"].ToString();
                    m_eventData13         = dr["EVT_D_13"].ToString();
                    m_eventHeader14       = dr["EVT_H_14"].ToString();
                    m_eventData14         = dr["EVT_D_14"].ToString();
                    m_eventHeader15       = dr["EVT_H_15"].ToString();
                    m_eventData15         = dr["EVT_D_15"].ToString();
                    m_eventHeader16       = dr["EVT_H_16"].ToString();
                    m_eventData16         = dr["EVT_D_16"].ToString();
                    m_eventHeader17       = dr["EVT_H_17"].ToString();
                    m_eventData17         = dr["EVT_D_17"].ToString();
                    m_eventHeader18       = dr["EVT_H_18"].ToString();
                    m_eventData18         = dr["EVT_D_18"].ToString();
                    m_eventHeader19       = dr["EVT_H_19"].ToString();
                    m_eventData19         = dr["EVT_D_19"].ToString();
                    m_eventHeader20       = dr["EVT_H_20"].ToString();
                    m_eventData20         = dr["EVT_D_20"].ToString();
                    m_comments            = dr["TRAN_COMMENT"].ToString();
                }

                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DisplayNameAttribute("Time"));
                base.fTypeDescriptor.properties["Server"].attributes.replace(new DisplayNameAttribute("Server"));
                base.fTypeDescriptor.properties["EventId"].attributes.replace(new DisplayNameAttribute("Event"));
                base.fTypeDescriptor.properties["ServerType"].attributes.replace(new DisplayNameAttribute("Server Type"));
                base.fTypeDescriptor.properties["ServerIp"].attributes.replace(new DisplayNameAttribute("Server IP"));
                base.fTypeDescriptor.properties["UpDown"].attributes.replace(new DisplayNameAttribute("Up/Down"));
                base.fTypeDescriptor.properties["Status"].attributes.replace(new DisplayNameAttribute("Status"));
                base.fTypeDescriptor.properties["Agent"].attributes.replace(new DisplayNameAttribute("Agent"));
                base.fTypeDescriptor.properties["UsedBackup"].attributes.replace(new DisplayNameAttribute("Used Backup"));
                base.fTypeDescriptor.properties["BackupMode"].attributes.replace(new DisplayNameAttribute("Backup Mode"));
                base.fTypeDescriptor.properties["BackupServer"].attributes.replace(new DisplayNameAttribute("Backup Server"));
                base.fTypeDescriptor.properties["BackupServerUpDown"].attributes.replace(new DisplayNameAttribute("B.Server Up/Down"));
                base.fTypeDescriptor.properties["BackupServerStatus"].attributes.replace(new DisplayNameAttribute("B.Server Status"));
                base.fTypeDescriptor.properties["BackupServerAgent"].attributes.replace(new DisplayNameAttribute("B.Server Agent"));
                base.fTypeDescriptor.properties["OpcServerMonitoring"].attributes.replace(new DisplayNameAttribute("OPC Server Monitoring"));
                base.fTypeDescriptor.properties["OpcServer"].attributes.replace(new DisplayNameAttribute("OPC Server"));
                base.fTypeDescriptor.properties["UserId"].attributes.replace(new DisplayNameAttribute("User ID"));
                // --
                base.fTypeDescriptor.properties["Data1"].attributes.replace(new DisplayNameAttribute(m_eventHeader1));
                base.fTypeDescriptor.properties["Data2"].attributes.replace(new DisplayNameAttribute(m_eventHeader2));
                base.fTypeDescriptor.properties["Data3"].attributes.replace(new DisplayNameAttribute(m_eventHeader3));
                base.fTypeDescriptor.properties["Data4"].attributes.replace(new DisplayNameAttribute(m_eventHeader4));
                base.fTypeDescriptor.properties["Data5"].attributes.replace(new DisplayNameAttribute(m_eventHeader5));
                base.fTypeDescriptor.properties["Data6"].attributes.replace(new DisplayNameAttribute(m_eventHeader6));
                base.fTypeDescriptor.properties["Data7"].attributes.replace(new DisplayNameAttribute(m_eventHeader7));
                base.fTypeDescriptor.properties["Data8"].attributes.replace(new DisplayNameAttribute(m_eventHeader8));
                base.fTypeDescriptor.properties["Data9"].attributes.replace(new DisplayNameAttribute(m_eventHeader9));
                base.fTypeDescriptor.properties["Data10"].attributes.replace(new DisplayNameAttribute(m_eventHeader10));
                base.fTypeDescriptor.properties["Data11"].attributes.replace(new DisplayNameAttribute(m_eventHeader11));
                base.fTypeDescriptor.properties["Data12"].attributes.replace(new DisplayNameAttribute(m_eventHeader12));
                base.fTypeDescriptor.properties["Data13"].attributes.replace(new DisplayNameAttribute(m_eventHeader13));
                base.fTypeDescriptor.properties["Data14"].attributes.replace(new DisplayNameAttribute(m_eventHeader14));
                base.fTypeDescriptor.properties["Data15"].attributes.replace(new DisplayNameAttribute(m_eventHeader15));
                base.fTypeDescriptor.properties["Data16"].attributes.replace(new DisplayNameAttribute(m_eventHeader16));
                base.fTypeDescriptor.properties["Data17"].attributes.replace(new DisplayNameAttribute(m_eventHeader17));
                base.fTypeDescriptor.properties["Data18"].attributes.replace(new DisplayNameAttribute(m_eventHeader18));
                base.fTypeDescriptor.properties["Data19"].attributes.replace(new DisplayNameAttribute(m_eventHeader19));
                base.fTypeDescriptor.properties["Data20"].attributes.replace(new DisplayNameAttribute(m_eventHeader20));
                // --
                base.fTypeDescriptor.properties["Comment"].attributes.replace(new DisplayNameAttribute("Comment"));

                // --

                base.fTypeDescriptor.properties["Time"].attributes.replace(new DefaultValueAttribute(m_tranTime));
                base.fTypeDescriptor.properties["Server"].attributes.replace(new DefaultValueAttribute(m_server));
                base.fTypeDescriptor.properties["EventId"].attributes.replace(new DefaultValueAttribute(m_eventId));
                base.fTypeDescriptor.properties["ServerType"].attributes.replace(new DefaultValueAttribute(m_serverType));
                base.fTypeDescriptor.properties["ServerIp"].attributes.replace(new DefaultValueAttribute(m_serverIp));
                base.fTypeDescriptor.properties["UpDown"].attributes.replace(new DefaultValueAttribute(m_serverUpDown));
                base.fTypeDescriptor.properties["Status"].attributes.replace(new DefaultValueAttribute(m_status));
                base.fTypeDescriptor.properties["Agent"].attributes.replace(new DefaultValueAttribute(m_agentUpDown));
                base.fTypeDescriptor.properties["UsedBackup"].attributes.replace(new DefaultValueAttribute(m_usedBackup));
                base.fTypeDescriptor.properties["BackupMode"].attributes.replace(new DefaultValueAttribute(m_backupMode));
                base.fTypeDescriptor.properties["BackupServer"].attributes.replace(new DefaultValueAttribute(m_backupServer));
                base.fTypeDescriptor.properties["BackupServerUpDown"].attributes.replace(new DefaultValueAttribute(m_backupServerUpDown));
                base.fTypeDescriptor.properties["BackupServerStatus"].attributes.replace(new DefaultValueAttribute(m_backupServerStatus));
                base.fTypeDescriptor.properties["BackupServerAgent"].attributes.replace(new DefaultValueAttribute(m_backupServerAgent));
                base.fTypeDescriptor.properties["OpcServerMonitoring"].attributes.replace(new DefaultValueAttribute(m_opcServerMonitoring));
                base.fTypeDescriptor.properties["OpcServer"].attributes.replace(new DefaultValueAttribute(m_opcServer));
                base.fTypeDescriptor.properties["UserId"].attributes.replace(new DefaultValueAttribute(m_userId));
                // --
                base.fTypeDescriptor.properties["Data1"].attributes.replace(new DefaultValueAttribute(m_eventData1));
                base.fTypeDescriptor.properties["Data2"].attributes.replace(new DefaultValueAttribute(m_eventData2));
                base.fTypeDescriptor.properties["Data3"].attributes.replace(new DefaultValueAttribute(m_eventData3));
                base.fTypeDescriptor.properties["Data4"].attributes.replace(new DefaultValueAttribute(m_eventData4));
                base.fTypeDescriptor.properties["Data5"].attributes.replace(new DefaultValueAttribute(m_eventData5));
                base.fTypeDescriptor.properties["Data6"].attributes.replace(new DefaultValueAttribute(m_eventData6));
                base.fTypeDescriptor.properties["Data7"].attributes.replace(new DefaultValueAttribute(m_eventData7));
                base.fTypeDescriptor.properties["Data8"].attributes.replace(new DefaultValueAttribute(m_eventData8));
                base.fTypeDescriptor.properties["Data9"].attributes.replace(new DefaultValueAttribute(m_eventData9));
                base.fTypeDescriptor.properties["Data10"].attributes.replace(new DefaultValueAttribute(m_eventData10));
                base.fTypeDescriptor.properties["Data11"].attributes.replace(new DefaultValueAttribute(m_eventData11));
                base.fTypeDescriptor.properties["Data12"].attributes.replace(new DefaultValueAttribute(m_eventData12));
                base.fTypeDescriptor.properties["Data13"].attributes.replace(new DefaultValueAttribute(m_eventData13));
                base.fTypeDescriptor.properties["Data14"].attributes.replace(new DefaultValueAttribute(m_eventData14));
                base.fTypeDescriptor.properties["Data15"].attributes.replace(new DefaultValueAttribute(m_eventData15));
                base.fTypeDescriptor.properties["Data16"].attributes.replace(new DefaultValueAttribute(m_eventData16));
                base.fTypeDescriptor.properties["Data17"].attributes.replace(new DefaultValueAttribute(m_eventData17));
                base.fTypeDescriptor.properties["Data18"].attributes.replace(new DefaultValueAttribute(m_eventData18));
                base.fTypeDescriptor.properties["Data19"].attributes.replace(new DefaultValueAttribute(m_eventData19));
                base.fTypeDescriptor.properties["Data20"].attributes.replace(new DefaultValueAttribute(m_eventData20));
                // --
                base.fTypeDescriptor.properties["Comment"].attributes.replace(new DefaultValueAttribute(m_comments));

                // --

                base.fTypeDescriptor.properties["Data1"].attributes.replace(new BrowsableAttribute(m_eventHeader1 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data2"].attributes.replace(new BrowsableAttribute(m_eventHeader2 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data3"].attributes.replace(new BrowsableAttribute(m_eventHeader3 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data4"].attributes.replace(new BrowsableAttribute(m_eventHeader4 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data5"].attributes.replace(new BrowsableAttribute(m_eventHeader5 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data6"].attributes.replace(new BrowsableAttribute(m_eventHeader6 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data7"].attributes.replace(new BrowsableAttribute(m_eventHeader7 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data8"].attributes.replace(new BrowsableAttribute(m_eventHeader8 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data9"].attributes.replace(new BrowsableAttribute(m_eventHeader9 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data10"].attributes.replace(new BrowsableAttribute(m_eventHeader10 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data11"].attributes.replace(new BrowsableAttribute(m_eventHeader11 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data12"].attributes.replace(new BrowsableAttribute(m_eventHeader12 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data13"].attributes.replace(new BrowsableAttribute(m_eventHeader13 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data14"].attributes.replace(new BrowsableAttribute(m_eventHeader14 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data15"].attributes.replace(new BrowsableAttribute(m_eventHeader15 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data16"].attributes.replace(new BrowsableAttribute(m_eventHeader16 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data17"].attributes.replace(new BrowsableAttribute(m_eventHeader17 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data18"].attributes.replace(new BrowsableAttribute(m_eventHeader18 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data19"].attributes.replace(new BrowsableAttribute(m_eventHeader19 == string.Empty ? false : true));
                base.fTypeDescriptor.properties["Data20"].attributes.replace(new BrowsableAttribute(m_eventHeader20 == string.Empty ? false : true));

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
