/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropConnectionOption.cs
--  Creator         : mj.kim
--  Create Date     : 2011.11.01
--  Description     : FAMate SQL Manager Connection Option Property Source Object Class 
--  History         : Created by mj.kim at 2011.11.01
                    : Modified by spike.lee at 2012.04.09
                        - Source Tuning
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Drawing.Design;
using System.Drawing;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.WorkspaceInterface;

namespace Nexplant.MC.SqlManager
{
    public class FPropConnectionOption : FDynPropCusBase<FSqmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryStation = "[02] Station";
        private const string CategoryChannelId = "[03] Channel ID";
        private const string CategoryFtp = "[04] FTP";        

        // --

        private bool m_disposed = false;      
        // --
        private FConnectionOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropConnectionOption(
            FSqmCore fSqmCore,
            FDynPropGrid fPropGrid,
            FConnectionOption source
            )
            : base(fSqmCore, fSqmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            // --
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropConnectionOption(
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
        public string Connection
        {
            get
            {
                try
                {
                    return m_source.connection;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.connection = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    return m_source.connectionDescription;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.connectionDescription = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Station

        [Category(CategoryStation)]
        public string StationConnectString
        {
            get
            {
                try
                {
                    return m_source.connectionStationConnectString;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.connectionStationConnectString = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryStation)]
        public int StationTimeout
        {
            get
            {
                try
                {
                    return m_source.connectionStationTimeout;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.connectionStationTimeout = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Channel ID

        [Category(CategoryChannelId)]
        public string TuneChannelId
        {
            get
            {
                try
                {
                    return m_source.connectionTuneChannelId;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.connectionTuneChannelId = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryChannelId)]
        public string CastChannelId
        {
            get
            {
                try
                {
                    return m_source.connectionCastChannelId;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.connectionCastChannelId = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Ftp

        [Category(CategoryFtp)]
        public string FtpIp
        {
            get
            {
                try
                {
                    return m_source.connectionFtpIp;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.connectionFtpIp = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFtp)]
        public bool FtpUsedAnonymous
        {
            get
            {
                try
                {
                    return m_source.connectionFtpUsedAnonymous;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
                return true;
            }

            set
            {
                try
                {
                    if (!value)
                    {
                        m_source.connectionFtpUser = string.Empty;
                        m_source.connectionFtpPassword = string.Empty;
                    }
                    // --
                    m_source.connectionFtpUsedAnonymous = value;
                    
                    // --
                    
                    setChangedFtpAnonymous();                    
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFtp)]
        public string FtpUser
        {
            get
            {
                try
                {
                    return m_source.connectionFtpUser;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.connectionFtpUser = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        [Category(CategoryFtp)]
        public string FtpPassword
        {
            get
            {
                try
                {
                    return m_source.connectionFtpPassword;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.connectionFtpPassword = value;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public FConnectionOption source
        {
            get
            {
                try
                {
                    return m_source;
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

        private void init(
            )
        {
            try
            {
                base.fTypeDescriptor.properties["Connection"].attributes.replace(new DisplayNameAttribute("Connection"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description")); 
                // --
                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DisplayNameAttribute("Connect String"));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DisplayNameAttribute("Timeout (ms)"));
                // --
                base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new DisplayNameAttribute("Tune"));
                base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new DisplayNameAttribute("Cast"));
                // --
                base.fTypeDescriptor.properties["FtpIp"].attributes.replace(new DisplayNameAttribute("IP"));
                base.fTypeDescriptor.properties["FtpUsedAnonymous"].attributes.replace(new DisplayNameAttribute("Used Anonymous"));
                base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new DisplayNameAttribute("User"));
                base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new DisplayNameAttribute("Password"));                               

                // --

                base.fTypeDescriptor.properties["Connection"].attributes.replace(new DefaultValueAttribute(m_source.connection));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_source.connectionDescription));
                // --
                base.fTypeDescriptor.properties["StationConnectString"].attributes.replace(new DefaultValueAttribute(m_source.connectionStationConnectString));
                base.fTypeDescriptor.properties["StationTimeout"].attributes.replace(new DefaultValueAttribute(m_source.connectionStationTimeout));
                // --
                base.fTypeDescriptor.properties["TuneChannelId"].attributes.replace(new DefaultValueAttribute(m_source.connectionTuneChannelId));
                base.fTypeDescriptor.properties["CastChannelId"].attributes.replace(new DefaultValueAttribute(m_source.connectionCastChannelId));
                // --
                base.fTypeDescriptor.properties["FtpIp"].attributes.replace(new DefaultValueAttribute(m_source.connectionFtpIp));
                base.fTypeDescriptor.properties["FtpUsedAnonymous"].attributes.replace(new DefaultValueAttribute(m_source.connectionFtpUsedAnonymous));
                base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new DefaultValueAttribute(m_source.connectionFtpUser));
                base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new DefaultValueAttribute(m_source.connectionFtpPassword));

                // --

                setChangedFtpAnonymous();                
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

        private void setChangedFtpAnonymous(
            )
        {
            try
            {
                if (m_source.connectionFtpUsedAnonymous)
                {
                    base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new BrowsableAttribute(false));
                    base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new BrowsableAttribute(false));
                }
                else
                {
                    base.fTypeDescriptor.properties["FtpUser"].attributes.replace(new BrowsableAttribute(true));
                    base.fTypeDescriptor.properties["FtpPassword"].attributes.replace(new BrowsableAttribute(true));
                }

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
