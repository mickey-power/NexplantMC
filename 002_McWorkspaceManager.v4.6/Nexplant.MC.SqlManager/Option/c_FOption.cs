/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOption.cs
--  Creator         : mj.kim
--  Create Date     : 2011.09.23
--  Description     : FAMate SQL Manager Option Class 
--  History         : Created by mj.kim at 2011.09.23
                    : Modified by spike.lee at 2012.04.06
                        - Source Tuning
----------------------------------------------------------------------------------------------------------*/
using System;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SqlManager
{
    public class FOption : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSqmCore m_fSqmCore = null;
        // --        
        private FFormList m_fChildList = null;
        // --
        private string m_optionFileName = string.Empty;
        private FXmlDocument m_fXmlDocOpt = null;
        // --
        private string m_fontName = string.Empty;
        private float m_fontSize = 0;
        // --
        private string m_connection = string.Empty;
        private string m_connectionDescription = string.Empty;
        private string m_connectionStationConnectString = string.Empty;
        private int m_connectionStationTimeout = 0;
        private string m_connectionTuneChannelId = string.Empty;
        private string m_connectionCastChannelId = string.Empty;
        private string m_connectionFtpIp = string.Empty;
        private bool m_connectionFtpAnonymous = true;
        private string m_connectionFtpUser = string.Empty;
        private string m_connectionFtpPassword = string.Empty;
        // --
        private string m_database = string.Empty;
        private string m_databaseDescription = string.Empty;
        private FDbProvider m_fDatabaseProvider = FDbProvider.MsSqlServer;
        private string m_databaseConnectString = string.Empty;
        private string m_databasePassword = string.Empty;
        private int m_databaseTimeout = 0;
        private string m_databaseDecodingConnectString = string.Empty;
        // --
        private bool m_isConnect = false;
        // --
        private string m_recentDownloadPath = string.Empty;
        private string m_recentLogDownloadPath = string.Empty;
        private string m_recentExportPath = string.Empty;        
        // --
        private string m_downloadDatabase = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOption(
            FSqmCore fSqmCore 
            )
        {
            m_fSqmCore = fSqmCore;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOption(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
                    m_fSqmCore = null;
                }                

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FFormList fChildList
        {
            get
            {
                try
                {
                    return m_fChildList;
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

        public string fontName
        {
            get
            {
                try
                {
                    return m_fontName;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    m_fontName = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public float fontSize
        {
            get
            {
                try
                {
                    return m_fontSize;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FConstants.FontMinSize;
            }

            set
            {
                try
                {
                    m_fontSize = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string connection
        {
            get
            {
                try
                {
                    return m_connection;
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

            set
            {
                try
                {
                    m_connection = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string connectionDescription
        {
            get
            {
                try
                {
                    return m_connectionDescription;
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

            set
            {
                try
                {
                    m_connectionDescription = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string connectionStationConnectString
        {
            get
            {
                try
                {
                    return m_connectionStationConnectString;
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

            set
            {
                try
                {
                    m_connectionStationConnectString = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int connectionStationTimeout
        {
            get
            {
                try
                {
                    return m_connectionStationTimeout;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_connectionStationTimeout = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string connectionTuneChannelId
        {
            get
            {
                try
                {
                    return m_connectionTuneChannelId;
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

            set
            {
                try
                {
                    m_connectionTuneChannelId = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string connectionCastChannelId
        {
            get
            {
                try
                {
                    return m_connectionCastChannelId;
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

            set
            {
                try
                {
                    m_connectionCastChannelId = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string connectionftpIp
        {
            get
            {
                try
                {
                    return m_connectionFtpIp;
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

            set
            {
                try
                {
                    m_connectionFtpIp = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool connectionFtpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_connectionFtpAnonymous;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_connectionFtpAnonymous = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string connectionFtpUser
        {
            get
            {
                try
                {
                    return m_connectionFtpUser;
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

            set
            {
                try
                {
                    m_connectionFtpUser = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string connectionFtpPassword
        {
            get
            {
                try
                {
                    return m_connectionFtpPassword;
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

            set
            {
                try
                {
                    m_connectionFtpPassword = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }                

        //------------------------------------------------------------------------------------------------------------------------

        public string database
        {
            get
            {
                try
                {
                    return m_database;
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

            set
            {
                try
                {
                    m_database = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string databaseDescription
        {
            get
            {
                try
                {
                    return m_databaseDescription;
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

            set
            {
                try
                {
                    m_databaseDescription = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDbProvider databaseProvider
        {
            get
            {
                try
                {
                    return m_fDatabaseProvider;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDbProvider.MsSqlServer;
            }

            set
            {
                try
                {
                    m_fDatabaseProvider = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string databaseConnectString
        {
            get
            {
                try
                {
                    return m_databaseConnectString;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    m_databaseConnectString = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string databasePassword
        {
            get
            {
                try
                {
                    return m_databasePassword;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    m_databasePassword = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int databaseTimeout
        {
            get
            {
                try
                {
                    return m_databaseTimeout;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }

            set
            {
                try
                {
                    m_databaseTimeout = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string databaseDecodingConnectString
        {
            get
            {
                try
                {
                    return m_databaseDecodingConnectString;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    m_databaseDecodingConnectString = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FConnectionOption[] connectionOptionList
        {
            get
            {
                FCrypt fCrypt = null;
                FConnectionOption[] fCnoList = null;
                FConnectionOption fCno = null;
                FXmlNodeList fXmlNodeListCno = null;
                FXmlNode fXmlNodeCno = null;
                string xpath = string.Empty;

                try
                {
                    fCrypt = new FCrypt();

                    // --

                    xpath =
                        FXmlTagFAMate.E_FAMate +
                        "/" + FXmlTagSQMOption.E_SQMOption +
                        "/" + FXmlTagSQMOption.E_ConnectionOptionList +
                        "/" + FXmlTagSQMOption.E_ConnectionOption;
                    // --
                    fXmlNodeListCno = m_fXmlDocOpt.selectNodes(xpath);

                    // --

                    fCnoList = new FConnectionOption[fXmlNodeListCno.count];
                    // --
                    for (int i = 0; i < fXmlNodeListCno.count; i++)
                    {
                        fXmlNodeCno = fXmlNodeListCno[i];
                        fCno = new FConnectionOption();

                        // --

                        fCno.connection = fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_Connection, FXmlTagSQMOption.D_Connection);
                        fCno.connectionDescription = fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_ConnectionDescription, FXmlTagSQMOption.D_ConnectionDescription);
                        // --
                        fCno.connectionStationConnectString = fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_ConnectionStationConnectString, FXmlTagSQMOption.D_ConnectionStationConnectString);
                        fCno.connectionStationTimeout = int.Parse(fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_ConnectionStationTimeout, FXmlTagSQMOption.D_ConnectionStationTimeout));
                        // --
                        fCno.connectionTuneChannelId = fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_ConnectionTuneChannelId, FXmlTagSQMOption.D_ConnectionTuneChannelId);
                        fCno.connectionCastChannelId = fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_ConnectionCastChannelId, FXmlTagSQMOption.D_ConnectionCastChannelId);
                        // --
                        fCno.connectionFtpIp = fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_ConnectionFtpIp, FXmlTagSQMOption.D_ConnectionFtpIp);
                        fCno.connectionFtpUsedAnonymous = Boolean.Parse(fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_ConnectionFtpAnonymous, FXmlTagSQMOption.D_ConnectionFtpAnonymous));
                        fCno.connectionFtpUser = fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_ConnectionFtpUser, FXmlTagSQMOption.D_ConnectionFtpUser);
                        fCno.connectionFtpPassword = fCrypt.decrypt2(fXmlNodeCno.get_attrVal(FXmlTagSQMOption.A_ConnectionFtpPassword, FXmlTagSQMOption.D_ConnectionFtpPassword));

                        // --

                        fCnoList[i] = fCno;
                    }

                    // --

                    return fCnoList;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    if (fCrypt != null)
                    {
                        fCrypt.Dispose();
                        fCrypt = null;
                    }
                    // --
                    fCnoList = null;
                    fCno = null;
                    fXmlNodeListCno = null;
                    fXmlNodeCno = null;
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDatabaseOption[] databaseOptionList
        {
            get
            {
                FCrypt fCrypt = null;
                FDatabaseOption[] fDboList = null;
                FDatabaseOption fDbo = null;
                FXmlNodeList fXmlNodeListDbo = null;
                FXmlNode fXmlNodeDbo = null;
                string xpath = string.Empty;

                try
                {
                    fCrypt = new FCrypt();

                    // --

                    xpath =
                        FXmlTagFAMate.E_FAMate +
                        "/" + FXmlTagSQMOption.E_SQMOption +
                        "/" + FXmlTagSQMOption.E_DatabaseOptionList +
                        "/" + FXmlTagSQMOption.E_DatabaseOption;
                    // --
                    fXmlNodeListDbo = m_fXmlDocOpt.selectNodes(xpath);

                    // --

                    fDboList = new FDatabaseOption[fXmlNodeListDbo.count];
                    // --
                    for (int i = 0; i < fXmlNodeListDbo.count; i++)
                    {
                        fXmlNodeDbo = fXmlNodeListDbo[i];
                        fDbo = new FDatabaseOption();

                        // --

                        fDbo.database = fXmlNodeDbo.get_attrVal(FXmlTagSQMOption.A_Database, FXmlTagSQMOption.D_Database);
                        fDbo.databaseDescription = fXmlNodeDbo.get_attrVal(FXmlTagSQMOption.A_DatabaseDescription, FXmlTagSQMOption.D_DatabaseDescription);
                        // --
                        fDbo.fDatabaseProvider = (FDbProvider)Enum.Parse(typeof(FDbProvider), fXmlNodeDbo.get_attrVal(FXmlTagSQMOption.A_DatabaseProvider, FXmlTagSQMOption.D_DatabaseProvider));
                        // --
                        fDbo.databaseConnectString = fXmlNodeDbo.get_attrVal(FXmlTagSQMOption.A_DatabaseConnectString, FXmlTagSQMOption.D_DatabaseConnectString);
                        fDbo.databasePassword = fCrypt.decrypt2(fXmlNodeDbo.get_attrVal(FXmlTagSQMOption.A_DatabasePassword, FXmlTagSQMOption.D_DatabasePassword));
                        fDbo.databaseTimeout = int.Parse(fXmlNodeDbo.get_attrVal(FXmlTagSQMOption.A_DatabaseTimeout, FXmlTagSQMOption.D_DatabaseTimeout));

                        // --

                        fDboList[i] = fDbo;
                    }

                    // --

                    return fDboList;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    if (fCrypt != null)
                    {
                        fCrypt.Dispose();
                        fCrypt = null;
                    }
                    // --
                    fDboList = null;
                    fDbo = null;
                    fXmlNodeListDbo = null;
                    fXmlNodeDbo = null;
                }
                return null;
            }
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public bool isConnect
        {
            get
            {
                try
                {
                    return m_isConnect;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_isConnect = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string recentDownloadPath
        {
            get
            {
                try
                {
                    return m_recentDownloadPath;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    m_recentDownloadPath = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string recentLogDownloadPath
        {
            get
            {
                try
                {
                    return m_recentLogDownloadPath;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    m_recentLogDownloadPath = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string recentExportPath
        {
            get 
            {
                try
                {
                    return m_recentExportPath; 
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    m_recentExportPath = value; 
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string downloadDatabase
        {
            get
            {
                try
                {
                    return m_downloadDatabase;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
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
                    m_downloadDatabase = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_optionFileName = Path.Combine(m_fSqmCore.fWsmCore.optionPath, "NexplantMCSqlManager.cfg");

                // --

                m_fChildList = new FFormList(m_fSqmCore);

                // --

                if (File.Exists(m_optionFileName))
                {
                    loadOption();
                }
                else
                {
                    createOption();
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

        private void term(
            )
        {
            try
            {
                if (m_fXmlDocOpt != null)
                {
                    m_fXmlDocOpt.Dispose();
                    m_fXmlDocOpt = null;
                }

                // --

                if (m_fChildList != null)
                {
                    m_fChildList.Dispose();
                    m_fChildList = null;
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

        private void createOption(
            )
        {
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeSmo = null;
            FXmlNode fXmlNodeRco = null;
            FXmlNode fXmlNodeCol = null;
            FXmlNode fXmlNodeCno = null;
            FXmlNode fXmlNodeRdo = null;
            FXmlNode fXmlNodeDol = null;
            FXmlNode fXmlNodeDbo = null;
            string creationTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                fCrypt = new FCrypt();
                creationTime = FDataConvert.defaultNowDateTimeToString();

                // --

                m_fontName = FXmlTagSQMOption.D_FontName;
                m_fontSize = float.Parse(FXmlTagSQMOption.D_FontSize);
                // --
                m_recentDownloadPath = m_fSqmCore.fWsmCore.usrPath;
                m_recentLogDownloadPath = m_fSqmCore.fWsmCore.usrPath;
                m_recentExportPath = m_fSqmCore.fWsmCore.usrPath;

                // --

                m_connection = FXmlTagSQMOption.D_Connection;
                m_connectionDescription = FXmlTagSQMOption.D_ConnectionDescription;
                m_connectionStationConnectString = FXmlTagSQMOption.D_ConnectionStationConnectString;
                m_connectionStationTimeout = int.Parse(FXmlTagSQMOption.D_ConnectionStationTimeout);
                m_connectionTuneChannelId = FXmlTagSQMOption.D_ConnectionTuneChannelId;
                m_connectionCastChannelId = FXmlTagSQMOption.D_ConnectionCastChannelId;
                m_connectionFtpIp = FXmlTagSQMOption.D_ConnectionFtpIp;
                m_connectionFtpAnonymous = Boolean.Parse(FXmlTagSQMOption.D_ConnectionFtpAnonymous);
                m_connectionFtpUser = FXmlTagSQMOption.D_ConnectionFtpUser;
                m_connectionFtpPassword = FXmlTagSQMOption.D_ConnectionFtpPassword;

                // --

                m_database = FXmlTagSQMOption.D_Database;
                m_databaseDescription = FXmlTagSQMOption.D_DatabaseDescription;
                m_fDatabaseProvider = (FDbProvider)Enum.Parse(typeof(FDbProvider), FXmlTagSQMOption.D_DatabaseProvider);
                m_databaseConnectString = FXmlTagSQMOption.D_DatabaseConnectString;
                m_databasePassword = FXmlTagSQMOption.D_DatabasePassword;
                m_databaseTimeout = int.Parse(FXmlTagSQMOption.D_DatabaseTimeout);
                m_downloadDatabase = FXmlTagSQMOption.D_DownloadDatabase;
                m_databaseDecodingConnectString = string.Format(m_databaseConnectString, m_databasePassword);

                // --

                // ***
                // Option XML Document Create
                // ***                
                m_fXmlDocOpt = new FXmlDocument();
                m_fXmlDocOpt.preserveWhiteSpace = false;
                m_fXmlDocOpt.appendChild(m_fXmlDocOpt.createXmlDeclaration("1.0", string.Empty, string.Empty));

                // --

                // ***
                // FAMate Element Create
                // ***
                fXmlNodeFam = m_fXmlDocOpt.appendChild(m_fXmlDocOpt.createNode(FXmlTagFAMate.E_FAMate));
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileFormat, FXmlTagFAMate.D_FileFormat, "CFG");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileVersion, FXmlTagFAMate.D_FileVersion, "4.1.0.1");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileCreationTime, FXmlTagFAMate.D_FileCreationTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, creationTime);
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileDescription, FXmlTagFAMate.D_FileDescription, "Nexplant MC SQL Manager Option File");
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_UniqueIdPointer, FXmlTagFAMate.D_UniqueIdPointer, "0");

                // --

                // ***
                // SQL Manager Option Element Create
                // ***
                fXmlNodeSmo = fXmlNodeFam.appendChild(m_fXmlDocOpt.createNode(FXmlTagSQMOption.E_SQMOption));
                // --
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_FontName, FXmlTagSQMOption.D_FontName, m_fontName);
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_FontSize, FXmlTagSQMOption.D_FontSize, m_fontSize.ToString());
                // --
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_RecentDownloadPath, FXmlTagSQMOption.D_RecentDownloadPath, m_recentDownloadPath);
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_RecentLogDownloadPath, FXmlTagSQMOption.D_RecentLogDownloadPath, m_recentLogDownloadPath);
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_RecentExportPath, FXmlTagSQMOption.D_RecentExportPath, m_recentExportPath);

                // --

                // ***
                // Recent Connection Option Element Create
                // ***
                fXmlNodeRco = fXmlNodeSmo.appendChild(m_fXmlDocOpt.createNode(FXmlTagSQMOption.E_RecentConnectionOption));
                // --
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_Connection, FXmlTagSQMOption.D_Connection, m_connection);
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_ConnectionDescription, FXmlTagSQMOption.D_ConnectionDescription, m_connectionDescription);
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_ConnectionStationConnectString, FXmlTagSQMOption.D_ConnectionStationConnectString, m_connectionStationConnectString);
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_ConnectionStationTimeout, FXmlTagSQMOption.D_ConnectionStationTimeout, m_connectionStationTimeout.ToString());
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_ConnectionTuneChannelId, FXmlTagSQMOption.D_ConnectionTuneChannelId, m_connectionTuneChannelId);
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_ConnectionCastChannelId, FXmlTagSQMOption.D_ConnectionCastChannelId, m_connectionCastChannelId);
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpIp, FXmlTagSQMOption.D_ConnectionFtpIp, m_connectionFtpIp);
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpAnonymous, FXmlTagSQMOption.D_ConnectionFtpAnonymous, m_connectionFtpAnonymous);
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpUser, FXmlTagSQMOption.D_ConnectionFtpUser, m_connectionFtpUser);
                fXmlNodeRco.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpPassword, FXmlTagSQMOption.D_ConnectionFtpPassword, fCrypt.encrypt2(m_connectionFtpPassword));

                // --

                // ***
                // Connection Option List Element
                // ***
                fXmlNodeCol = fXmlNodeSmo.appendChild(m_fXmlDocOpt.createNode(FXmlTagSQMOption.E_ConnectionOptionList));
                
                // --
                
                // ***
                // Connection Option Element
                // ***
                fXmlNodeCno = fXmlNodeCol.appendChild(m_fXmlDocOpt.createNode(FXmlTagSQMOption.E_ConnectionOption));
                // --
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_Connection, m_connection);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionDescription, FXmlTagSQMOption.D_ConnectionDescription, m_connectionDescription);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionStationConnectString, FXmlTagSQMOption.D_ConnectionStationConnectString, m_connectionStationConnectString);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionStationTimeout, FXmlTagSQMOption.D_ConnectionStationTimeout, m_connectionStationTimeout.ToString());
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionTuneChannelId, FXmlTagSQMOption.D_ConnectionTuneChannelId, m_connectionTuneChannelId);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionCastChannelId, FXmlTagSQMOption.D_ConnectionCastChannelId, m_connectionCastChannelId);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpIp, FXmlTagSQMOption.D_ConnectionFtpIp, m_connectionFtpIp);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpAnonymous, FXmlTagSQMOption.D_ConnectionFtpAnonymous, m_connectionFtpAnonymous);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpUser, FXmlTagSQMOption.D_ConnectionFtpUser, m_connectionFtpUser);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpPassword, FXmlTagSQMOption.D_ConnectionFtpPassword, fCrypt.encrypt2(m_connectionFtpPassword));

                // --

                // ***
                // Recent Database Option Element Create
                // ***
                fXmlNodeRdo = fXmlNodeSmo.appendChild(m_fXmlDocOpt.createNode(FXmlTagSQMOption.E_RecentDatabaseOption));
                // --
                fXmlNodeRdo.set_attrVal(FXmlTagSQMOption.A_Database, FXmlTagSQMOption.D_Database, m_database);
                fXmlNodeRdo.set_attrVal(FXmlTagSQMOption.A_DatabaseDescription, FXmlTagSQMOption.D_DatabaseDescription, m_databaseDescription);
                fXmlNodeRdo.set_attrVal(FXmlTagSQMOption.A_DatabaseProvider, FXmlTagSQMOption.D_DatabaseProvider, m_fDatabaseProvider.ToString());
                fXmlNodeRdo.set_attrVal(FXmlTagSQMOption.A_DatabaseConnectString, FXmlTagSQMOption.D_DatabaseConnectString, m_databaseConnectString);
                fXmlNodeRdo.set_attrVal(FXmlTagSQMOption.A_DatabasePassword, FXmlTagSQMOption.D_DatabaseConnectString, fCrypt.encrypt2(m_databasePassword));
                fXmlNodeRdo.set_attrVal(FXmlTagSQMOption.A_DatabaseTimeout, FXmlTagSQMOption.D_DatabaseTimeout, m_databaseTimeout.ToString());
                fXmlNodeRdo.set_attrVal(FXmlTagSQMOption.A_DownloadDatabase, FXmlTagSQMOption.D_DownloadDatabase, m_downloadDatabase);

                // --

                // ***
                // Database Option List Element
                // ***
                fXmlNodeDol = fXmlNodeSmo.appendChild(m_fXmlDocOpt.createNode(FXmlTagSQMOption.E_DatabaseOptionList));
                
                // --
                
                // ***
                // Database Option Element
                // ***
                fXmlNodeDbo = fXmlNodeDol.appendChild(m_fXmlDocOpt.createNode(FXmlTagSQMOption.E_DatabaseOption));
                // --
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_Database, m_database);
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabaseDescription, FXmlTagSQMOption.D_DatabaseDescription, m_databaseDescription);
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabaseProvider, FXmlTagSQMOption.D_DatabaseProvider, m_fDatabaseProvider.ToString());
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabaseConnectString, FXmlTagSQMOption.D_DatabaseConnectString, m_databaseConnectString);
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabasePassword, FXmlTagSQMOption.D_DatabaseConnectString, fCrypt.encrypt2(m_databasePassword));
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabaseTimeout, FXmlTagSQMOption.D_DatabaseTimeout, m_databaseTimeout.ToString());
                                
                // --

                // ***
                // Option Save
                // ***
                dirName = Path.GetDirectoryName(m_optionFileName);
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
                m_fXmlDocOpt.save(m_optionFileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fCrypt != null)
                {
                    fCrypt.Dispose();
                    fCrypt = null;
                }
                // --
                fXmlNodeFam = null;
                fXmlNodeSmo = null;
                fXmlNodeRco = null;
                fXmlNodeCol = null;
                fXmlNodeCno = null;
                fXmlNodeRdo = null;
                fXmlNodeDol = null;
                fXmlNodeDbo = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void loadOption(
            )
        {
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeSmo = null;
            FXmlNode fXmlNodeRco = null;
            FXmlNode fXmlNodeRdo = null;

            try
            {
                fCrypt = new FCrypt();

                // --

                // ***
                // Option XML Document Load
                // *** 
                m_fXmlDocOpt = new FXmlDocument();
                m_fXmlDocOpt.preserveWhiteSpace = false;
                m_fXmlDocOpt.load(m_optionFileName);

                // --

                // ***
                // SQL Manager Option Load
                // ***
                fXmlNodeSmo = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate + "/" + FXmlTagSQMOption.E_SQMOption);

                // --

                m_fontName = fXmlNodeSmo.get_attrVal(FXmlTagSQMOption.A_FontName, FXmlTagSQMOption.D_FontName);
                m_fontSize = float.Parse(fXmlNodeSmo.get_attrVal(FXmlTagSQMOption.A_FontSize, FXmlTagSQMOption.D_FontSize));
                // --
                m_recentDownloadPath = fXmlNodeSmo.get_attrVal(FXmlTagSQMOption.A_RecentDownloadPath, FXmlTagSQMOption.D_RecentDownloadPath);
                m_recentLogDownloadPath = fXmlNodeSmo.get_attrVal(FXmlTagSQMOption.A_RecentLogDownloadPath, FXmlTagSQMOption.D_RecentLogDownloadPath);
                m_recentExportPath = fXmlNodeSmo.get_attrVal(FXmlTagSQMOption.A_RecentExportPath, FXmlTagSQMOption.D_RecentExportPath);
                // --
                if (!Directory.Exists(m_recentDownloadPath)) m_recentDownloadPath = m_fSqmCore.fWsmCore.usrPath;
                if (!Directory.Exists(m_recentLogDownloadPath)) m_recentLogDownloadPath = m_fSqmCore.fWsmCore.usrPath;
                if (!Directory.Exists(m_recentExportPath)) m_recentExportPath = m_fSqmCore.fWsmCore.usrPath;

                // --

                // ***
                // Recent Connection Option Load
                // ***
                fXmlNodeRco = fXmlNodeSmo.selectSingleNode (FXmlTagSQMOption.E_RecentConnectionOption);
                // --
                m_connection = fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_Connection, FXmlTagSQMOption.D_Connection);
                m_connectionDescription = fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_ConnectionDescription, FXmlTagSQMOption.D_ConnectionDescription);
                // --
                m_connectionStationConnectString = fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_ConnectionStationTimeout, FXmlTagSQMOption.D_ConnectionStationTimeout);
                m_connectionStationTimeout = int.Parse(fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_ConnectionStationTimeout, FXmlTagSQMOption.D_ConnectionStationTimeout));
                // --
                m_connectionTuneChannelId = fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_ConnectionTuneChannelId, FXmlTagSQMOption.D_ConnectionTuneChannelId);
                m_connectionCastChannelId = fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_ConnectionCastChannelId, FXmlTagSQMOption.D_ConnectionCastChannelId);
                // --
                m_connectionFtpIp = fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_ConnectionFtpIp, FXmlTagSQMOption.D_ConnectionFtpIp);
                m_connectionFtpAnonymous = Boolean.Parse(fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_ConnectionFtpAnonymous, FXmlTagSQMOption.D_ConnectionFtpAnonymous));
                m_connectionFtpUser = fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_ConnectionFtpUser, FXmlTagSQMOption.D_ConnectionFtpUser);
                m_connectionFtpPassword = fCrypt.decrypt2(fXmlNodeRco.get_attrVal(FXmlTagSQMOption.A_ConnectionFtpPassword, FXmlTagSQMOption.D_ConnectionFtpPassword));

                // --

                // ***
                // Recent Database Option Load
                // ***
                fXmlNodeRdo = fXmlNodeSmo.selectSingleNode(FXmlTagSQMOption.E_RecentDatabaseOption);
                // --
                m_database = fXmlNodeRdo.get_attrVal(FXmlTagSQMOption.A_Database, FXmlTagSQMOption.D_Database);
                m_databaseDescription = fXmlNodeRdo.get_attrVal(FXmlTagSQMOption.A_DatabaseDescription, FXmlTagSQMOption.D_DatabaseDescription);
                // --
                m_fDatabaseProvider = (FDbProvider)Enum.Parse(typeof(FDbProvider), fXmlNodeRdo.get_attrVal(FXmlTagSQMOption.A_DatabaseProvider, FXmlTagSQMOption.D_DatabaseProvider));
                m_databaseConnectString = fXmlNodeRdo.get_attrVal(FXmlTagSQMOption.A_DatabaseTimeout, FXmlTagSQMOption.D_DatabaseTimeout);
                m_databasePassword = fCrypt.decrypt2(fXmlNodeRdo.get_attrVal(FXmlTagSQMOption.A_DatabasePassword, FXmlTagSQMOption.D_DatabasePassword));                
                m_databaseTimeout = int.Parse(fXmlNodeRdo.get_attrVal(FXmlTagSQMOption.A_DatabaseTimeout, FXmlTagSQMOption.D_DatabaseTimeout));
                m_downloadDatabase = fXmlNodeRdo.get_attrVal(FXmlTagSQMOption.A_DownloadDatabase, FXmlTagSQMOption.D_DownloadDatabase);
                m_databaseDecodingConnectString = string.Format(m_databaseConnectString, m_databasePassword);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fCrypt != null)
                {
                    fCrypt.Dispose();
                    fCrypt = null;
                }
                // --
                fXmlNodeSmo = null;
                fXmlNodeRco = null;
                fXmlNodeRdo = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void save(
            )
        {
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeFam = null;
            FXmlNode fXmlNodeSmo = null;
            FXmlNode fXmlNodeRsv = null;
            FXmlNode fXmlNodeRdb = null;
            string updateTime = string.Empty;
            string dirName = string.Empty;

            try
            {
                if (m_fXmlDocOpt == null)
                {
                    return;
                }

                // --

                fCrypt = new FCrypt();
                updateTime = FDataConvert.defaultNowDateTimeToString();

                // --

                // ***
                // FAMate Element Set
                // ***
                fXmlNodeFam = m_fXmlDocOpt.selectSingleNode(FXmlTagFAMate.E_FAMate);
                // --
                fXmlNodeFam.set_attrVal(FXmlTagFAMate.A_FileUpdateTime, FXmlTagFAMate.D_FileUpdateTime, updateTime);

                // --

                // ***
                // SQL Manager Option Element set
                // ***
                fXmlNodeSmo = fXmlNodeFam.selectSingleNode(FXmlTagSQMOption.E_SQMOption);
                // --
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_FontName, FXmlTagSQMOption.D_FontName, m_fontName);
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_FontSize, FXmlTagSQMOption.D_FontSize, m_fontSize.ToString());
                // --
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_RecentDownloadPath, FXmlTagSQMOption.D_RecentDownloadPath, m_recentDownloadPath);
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_RecentLogDownloadPath, FXmlTagSQMOption.D_RecentLogDownloadPath, m_recentLogDownloadPath);
                fXmlNodeSmo.set_attrVal(FXmlTagSQMOption.A_RecentExportPath, FXmlTagSQMOption.D_RecentExportPath, m_recentExportPath);

                // --
                
                // ***
                // Recent Connection Option Element set
                // ***
                fXmlNodeRsv = fXmlNodeSmo.selectSingleNode(FXmlTagSQMOption.E_RecentConnectionOption);
                // --
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_Connection, FXmlTagSQMOption.D_Connection, m_connection);
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_ConnectionDescription, FXmlTagSQMOption.D_ConnectionDescription, m_connectionDescription);
                // --
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_ConnectionStationConnectString, FXmlTagSQMOption.D_ConnectionStationConnectString, m_connectionStationConnectString);
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_ConnectionStationTimeout, FXmlTagSQMOption.D_ConnectionStationTimeout, m_connectionStationTimeout.ToString());
                // --
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_ConnectionTuneChannelId, FXmlTagSQMOption.D_ConnectionTuneChannelId, m_connectionTuneChannelId);
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_ConnectionCastChannelId, FXmlTagSQMOption.D_ConnectionCastChannelId, m_connectionCastChannelId);
                // --
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpIp, FXmlTagSQMOption.D_ConnectionFtpIp, m_connectionFtpIp);
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpAnonymous, FXmlTagSQMOption.D_ConnectionFtpAnonymous, m_connectionFtpAnonymous.ToString());
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpUser, FXmlTagSQMOption.D_ConnectionFtpUser, m_connectionFtpUser);
                fXmlNodeRsv.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpPassword, FXmlTagSQMOption.D_ConnectionFtpPassword, fCrypt.encrypt2(m_connectionFtpPassword));

                // --

                // ***
                // Recent Database Option Element set
                // ***
                fXmlNodeRdb = fXmlNodeSmo.selectSingleNode(FXmlTagSQMOption.E_RecentDatabaseOption);
                // --
                fXmlNodeRdb.set_attrVal(FXmlTagSQMOption.A_Database, FXmlTagSQMOption.D_Database, m_database);
                fXmlNodeRdb.set_attrVal(FXmlTagSQMOption.A_DatabaseDescription, FXmlTagSQMOption.D_DatabaseDescription, m_databaseDescription);
                // --
                fXmlNodeRdb.set_attrVal(FXmlTagSQMOption.A_DatabaseProvider, FXmlTagSQMOption.D_DatabaseProvider, m_fDatabaseProvider.ToString());
                fXmlNodeRdb.set_attrVal(FXmlTagSQMOption.A_DatabaseConnectString, FXmlTagSQMOption.D_DatabaseConnectString, m_databaseConnectString);
                fXmlNodeRdb.set_attrVal(FXmlTagSQMOption.A_DatabaseTimeout, FXmlTagSQMOption.D_DatabaseTimeout, m_databaseTimeout.ToString());
                fXmlNodeRdb.set_attrVal(FXmlTagSQMOption.A_DatabasePassword, FXmlTagSQMOption.D_DatabasePassword, fCrypt.encrypt2(m_databasePassword));
                fXmlNodeRdb.set_attrVal(FXmlTagSQMOption.A_DownloadDatabase, FXmlTagSQMOption.D_DownloadDatabase, m_downloadDatabase);

                
                // --

                // ***
                // Option save
                // ***  
                dirName = Path.GetDirectoryName(m_optionFileName);
                if (!Directory.Exists(dirName))
                {
                    Directory.CreateDirectory(dirName);
                }
                m_fXmlDocOpt.save(m_optionFileName);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fCrypt != null)
                {
                    fCrypt.Dispose();
                    fCrypt = null;
                }
                // --                
                fXmlNodeFam = null;
                fXmlNodeSmo = null;
                fXmlNodeRsv = null;
                fXmlNodeRdb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void updateConnectionOption(
            FConnectionOption source
            )
        {
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeCno = null;
            string xpath = string.Empty;

            try
            {
                fCrypt = new FCrypt();

                // --

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagSQMOption.E_SQMOption +
                    "/" + FXmlTagSQMOption.E_ConnectionOptionList +
                    "/" + FXmlTagSQMOption.E_ConnectionOption + "[@" + FXmlTagSQMOption.A_Connection + "='" + source.connection + "']";
                // --
                fXmlNodeCno = m_fXmlDocOpt.selectSingleNode(xpath);

                // --

                if (fXmlNodeCno == null)
                {
                    xpath =
                        FXmlTagFAMate.E_FAMate +
                        "/" + FXmlTagSQMOption.E_SQMOption +
                        "/" + FXmlTagSQMOption.E_ConnectionOptionList;
                    // --
                    fXmlNodeCno = m_fXmlDocOpt.selectSingleNode(xpath).appendChild(
                        m_fXmlDocOpt.createNode(FXmlTagSQMOption.E_ConnectionOption)
                        );
                }

                // --

                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_Connection, source.connection);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionDescription, FXmlTagSQMOption.D_ConnectionDescription, source.connectionDescription);
                // --
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionStationConnectString, FXmlTagSQMOption.D_ConnectionStationConnectString, source.connectionStationConnectString);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionStationTimeout, FXmlTagSQMOption.D_ConnectionStationTimeout, source.connectionStationTimeout.ToString());
                // --
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionTuneChannelId, FXmlTagSQMOption.D_ConnectionTuneChannelId, source.connectionTuneChannelId);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionCastChannelId, FXmlTagSQMOption.D_ConnectionCastChannelId, source.connectionCastChannelId);
                // --
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpIp, FXmlTagSQMOption.D_ConnectionFtpIp, source.connectionFtpIp);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpAnonymous, FXmlTagSQMOption.D_ConnectionFtpAnonymous, source.connectionFtpUsedAnonymous.ToString());
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpUser, FXmlTagSQMOption.D_ConnectionFtpUser, source.connectionFtpUser);
                fXmlNodeCno.set_attrVal(FXmlTagSQMOption.A_ConnectionFtpPassword, FXmlTagSQMOption.D_ConnectionFtpPassword, fCrypt.encrypt2(source.connectionFtpPassword));
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fCrypt != null)
                {
                    fCrypt.Dispose();
                    fCrypt = null;
                }
                // --
                fXmlNodeCno = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void deleteConnectionOption(
            FConnectionOption source
            )
        {
            FXmlNode fXmlNodeCno = null;
            string xpath = string.Empty;

            try
            {
                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagSQMOption.E_SQMOption +
                    "/" + FXmlTagSQMOption.E_ConnectionOptionList +
                    "/" + FXmlTagSQMOption.E_ConnectionOption + "[@" + FXmlTagSQMOption.A_Connection + "='" + source.connection + "']";
                // --
                fXmlNodeCno = m_fXmlDocOpt.selectSingleNode(xpath);

                // --

                if (fXmlNodeCno != null)
                {
                    fXmlNodeCno.fParentNode.removeChild(fXmlNodeCno);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeCno = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void updateDatabaseOption(
            FDatabaseOption source
            )
        {
            FCrypt fCrypt = null;
            FXmlNode fXmlNodeDbo = null;
            string xpath = string.Empty;

            try
            {
                fCrypt = new FCrypt();

                // --

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagSQMOption.E_SQMOption +
                    "/" + FXmlTagSQMOption.E_DatabaseOptionList +
                    "/" + FXmlTagSQMOption.E_DatabaseOption + "[@" + FXmlTagSQMOption.A_Database + "='" + source.database + "']";
                // --
                fXmlNodeDbo = m_fXmlDocOpt.selectSingleNode(xpath);

                // --

                if (fXmlNodeDbo == null)
                {
                    xpath =
                        FXmlTagFAMate.E_FAMate +
                        "/" + FXmlTagSQMOption.E_SQMOption +
                        "/" + FXmlTagSQMOption.E_DatabaseOptionList;
                    // --
                    fXmlNodeDbo = m_fXmlDocOpt.selectSingleNode(xpath).appendChild(m_fXmlDocOpt.createNode(FXmlTagSQMOption.E_DatabaseOption));
                }

                // --

                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_Database, source.database);
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabaseDescription, FXmlTagSQMOption.D_DatabaseDescription, source.databaseDescription);
                // --
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabaseProvider, FXmlTagSQMOption.D_DatabaseProvider, source.fDatabaseProvider.ToString());
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabaseConnectString, FXmlTagSQMOption.D_DatabaseConnectString, source.databaseConnectString);
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabasePassword, FXmlTagSQMOption.D_DatabasePassword, fCrypt.encrypt2(source.databasePassword));
                fXmlNodeDbo.set_attrVal(FXmlTagSQMOption.A_DatabaseTimeout, FXmlTagSQMOption.D_DatabaseTimeout, source.databaseTimeout.ToString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fCrypt != null)
                {
                    fCrypt.Dispose();
                    fCrypt = null;
                }
                // --
                fXmlNodeDbo = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void deleteDatabaseOption(
            FDatabaseOption source
            )
        {
            FXmlNode fXmlNodeDbo = null;
            string xpath = string.Empty;

            try
            {
                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagSQMOption.E_SQMOption +
                    "/" + FXmlTagSQMOption.E_DatabaseOptionList +
                    "/" + FXmlTagSQMOption.E_DatabaseOption + "[@" + FXmlTagSQMOption.A_Database + "='" + source.database + "']";
                fXmlNodeDbo = m_fXmlDocOpt.selectSingleNode(xpath);

                // --
                
                if (fXmlNodeDbo != null)
                {
                    fXmlNodeDbo.fParentNode.removeChild(fXmlNodeDbo);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeDbo = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
    }   // Class end
}   // Namespace end
