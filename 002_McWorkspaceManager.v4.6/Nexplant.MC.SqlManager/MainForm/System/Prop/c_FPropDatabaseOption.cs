/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropOptionDatabase.cs
--  Creator         : mj.kim
--  Create Date     : 2011.11.21
--  Description     : FAMate SQL Manager Option Database Property Source Object Class 
--  History         : Created by mj.kim at 2011.11.21
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
    public class FPropOptionDatabase : FDynPropCusBase<FSqmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string CategoryGeneral = "[01] General";
        private const string CategoryDatabase = "[02] Database";

        // --

        private bool m_disposed = false;      
        // --
        private FDatabaseOption m_source = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropOptionDatabase(
            FSqmCore fSqmCore,
            FDynPropGrid fPropGrid,
            FDatabaseOption source
            )
            : base(fSqmCore, fSqmCore.fUIWizard, fPropGrid)
        {
            m_source = source;
            // --
            init();   
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropOptionDatabase(
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
        public string Database
        {
            get
            {
                try
                {
                    return m_source.database;
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
                    m_source.database = value;
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
                    return m_source.databaseDescription;
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
                    m_source.databaseDescription = value;
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

        #region Database

        [Category(CategoryDatabase)]
        public FDbProvider Provider
        {
            get
            {
                try
                {
                    return m_source.fDatabaseProvider;
                }
                catch (Exception ex)
                {
                    FMessageBox.showError(FConstants.ApplicationName, ex, mainObject.fSqmContainer);
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
                    m_source.fDatabaseProvider = value;
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

        [Category(CategoryDatabase)]
        public string ConnectString
        {
            get
            {
                try
                {
                    return m_source.databaseConnectString;
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
                    m_source.databaseConnectString = value;
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

        [Category(CategoryDatabase)]
        [PasswordPropertyText(true)]
        public string Password
        {
            get
            {
                try
                {
                    return source.databasePassword;
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
                    source.databasePassword = value;
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

        [Category(CategoryDatabase)]
        public int Timeout
        {
            get
            {
                try
                {
                    return m_source.databaseTimeout;
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
                    m_source.databaseTimeout = value;                    
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
        public FDatabaseOption source
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
                base.fTypeDescriptor.properties["Database"].attributes.replace(new DisplayNameAttribute("Database"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description")); 
                // --
                base.fTypeDescriptor.properties["Provider"].attributes.replace(new DisplayNameAttribute("Provider"));
                base.fTypeDescriptor.properties["ConnectString"].attributes.replace(new DisplayNameAttribute("Connect String"));
                base.fTypeDescriptor.properties["Password"].attributes.replace(new DisplayNameAttribute("Password"));
                base.fTypeDescriptor.properties["Timeout"].attributes.replace(new DisplayNameAttribute("Timeout (ms)"));

                // --

                base.fTypeDescriptor.properties["Database"].attributes.replace(new DefaultValueAttribute(m_source.database));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_source.databaseDescription));
                // --
                base.fTypeDescriptor.properties["Provider"].attributes.replace(new DefaultValueAttribute(m_source.fDatabaseProvider));
                base.fTypeDescriptor.properties["ConnectString"].attributes.replace(new DefaultValueAttribute(m_source.databaseConnectString));
                base.fTypeDescriptor.properties["Password"].attributes.replace(new DefaultValueAttribute(m_source.databasePassword));
                base.fTypeDescriptor.properties["Timeout"].attributes.replace(new DefaultValueAttribute(m_source.databaseTimeout));
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
