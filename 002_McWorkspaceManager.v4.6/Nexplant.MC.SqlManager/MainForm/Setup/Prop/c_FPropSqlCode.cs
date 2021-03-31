/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPropSqlCode.cs
--  Creator         : mjkim
--  Create Date     : 2011.10.12
--  Description     : FAMate SQL Manager Sql Code Property Source Object Class 
--  History         : Created by mjkim at 2011.10.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing.Design;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;

namespace Nexplant.MC.SqlManager
{
    public class FPropSqlCode : FDynPropCusBase<FSqmCore>
    {

        //------------------------------------------------------------------------------------------------------------------------        

        public delegate void FSqlQueryValueChangedEventHandler(object sender, System.Windows.Forms.PropertyValueChangedEventArgs e);
        
        // --
        private const string CategoryGeneral = "[01] General";
        private const string CategoryRelation = "[02] Relation";
        private const string CategoryMigration = "[03] Migration";
        private const string CategoryQuery = "[04] Query";

        // --

        private bool m_disposed = false;
        // --
        private string m_type = "SQL Code";
        private string m_system = string.Empty;
        private string m_module = string.Empty;
        private string m_function = string.Empty;
        private FYesNo m_usedMigration = FYesNo.Yes;
        private string m_uniqueIdToString = string.Empty;
        private string m_sqlCode = string.Empty;
        private string m_description = string.Empty;
        private string m_msSqlQuery = string.Empty;
        private string m_oracleQuery = string.Empty;
        private string m_mySqlQuery = string.Empty;
        private string m_mariaDbQuery = string.Empty;
        private string m_postgreSqlQuery = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPropSqlCode(
            FSqmCore fSqmCore,
            FDynPropGrid fPropGrid,
            string system,
            string module,
            string function,
            DataTable dt
            )
            : base(fSqmCore, fSqmCore.fUIWizard, fPropGrid)
        {
            m_system = system;
            m_module = module;
            m_function = function;
            // --
            init(dt);   
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FPropSqlCode(
            FSqmCore fSqmCore,
            FDynPropGrid fPropGrid,
            string system,
            string module,
            string function
            )
            : this(fSqmCore, fPropGrid, system, module, function, null)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPropSqlCode(
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
        public string Type
        {
            get
            {
                try
                {
                    return m_type;
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
        public string ID
        {
            get
            {
                try
                {
                    return m_uniqueIdToString;
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
        public string SqlCode
        {
            get
            {
                try
                {
                    return m_sqlCode;
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
                    FCommon.validateName(value, true, this.mainObject.fUIWizard);
                                        
                    // --

                    m_sqlCode = value;
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
                    FCommon.validateName(this.SqlCode, true, this.mainObject.fUIWizard);

                    // --

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

        #region Relation

        [Category(CategoryRelation)]
        public string System
        {
            get
            {
                try
                {
                    return m_system;
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

        [Category(CategoryRelation)]
        public string Module
        {
            get
            {
                try
                {
                    return m_module;
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

        [Category(CategoryRelation)]
        public string Function
        {
            get
            {
                try
                {
                    return m_function;
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

        #region Migration

        [Category(CategoryMigration)]
        public FYesNo UsedMigration
        {
            get
            {
                try
                {
                    return m_usedMigration;
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
                    m_usedMigration = value;
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

        #region Query

        [Category(CategoryQuery)]
        [Editor(typeof(FPropAttrSqlCodeQueryUITypeEditor), typeof(UITypeEditor))]
        public string MsSqlQuery
        {
            get
            {
                try
                {
                    return m_msSqlQuery;
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
                string sqlvalue = string.Empty;

                try
                {
                    FCommon.validateName(this.SqlCode, true, this.mainObject.fUIWizard);

                    // --
                                        
                    m_msSqlQuery = value;
                    
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

        [Category(CategoryQuery)]
        [Editor(typeof(FPropAttrSqlCodeQueryUITypeEditor), typeof(UITypeEditor))]
        public string OracleQuery
        {
            get
            {
                try
                {
                    return m_oracleQuery;
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
                    FCommon.validateName(this.SqlCode, true, this.mainObject.fUIWizard);

                    // --

                    m_oracleQuery = value;
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

        [Category(CategoryQuery)]
        [Editor(typeof(FPropAttrSqlCodeQueryUITypeEditor), typeof(UITypeEditor))]
        public string MySqlQuery
        {
            get
            {
                try
                {
                    return m_mySqlQuery;
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
                    FCommon.validateName(this.SqlCode, true, this.mainObject.fUIWizard);

                    // --

                    m_mySqlQuery = value;
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

        [Category(CategoryQuery)]
        [Editor(typeof(FPropAttrSqlCodeQueryUITypeEditor), typeof(UITypeEditor))]
        public string MariaDbQuery
        {
            get
            {
                try
                {
                    return m_mariaDbQuery;
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
                    FCommon.validateName(this.SqlCode, true, this.mainObject.fUIWizard);

                    // --

                    m_mariaDbQuery = value;
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

        [Category(CategoryQuery)]
        [Editor(typeof(FPropAttrSqlCodeQueryUITypeEditor), typeof(UITypeEditor))]
        public string PostgreSqlQuery
        {
            get
            {
                try
                {
                    return m_postgreSqlQuery;
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
                    FCommon.validateName(this.SqlCode, true, this.mainObject.fUIWizard);

                    // --

                    m_postgreSqlQuery = value;
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
                    m_uniqueIdToString = (string)dt.Rows[0][0];
                    m_sqlCode = (string)dt.Rows[0][1];
                    m_description = (string)dt.Rows[0][2];
                    m_usedMigration = (FYesNo)Enum.Parse(typeof(FYesNo), dt.Rows[0][3].ToString());
                    m_msSqlQuery = (string)dt.Rows[0][4];
                    m_oracleQuery = (string)dt.Rows[0][6];
                    m_mySqlQuery = (string)dt.Rows[0][8];
                    m_mariaDbQuery = (string)dt.Rows[0][10];
                    m_postgreSqlQuery = (string)dt.Rows[0][12];
                }

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DisplayNameAttribute("Type"));
                base.fTypeDescriptor.properties["System"].attributes.replace(new DisplayNameAttribute("System"));
                base.fTypeDescriptor.properties["Module"].attributes.replace(new DisplayNameAttribute("Module"));
                base.fTypeDescriptor.properties["Function"].attributes.replace(new DisplayNameAttribute("Function"));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DisplayNameAttribute("ID"));
                base.fTypeDescriptor.properties["SqlCode"].attributes.replace(new DisplayNameAttribute("Name"));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DisplayNameAttribute("Description"));
                base.fTypeDescriptor.properties["UsedMigration"].attributes.replace(new DisplayNameAttribute("Used"));
                base.fTypeDescriptor.properties["MsSqlQuery"].attributes.replace(new DisplayNameAttribute("Microsoft SQL Server"));
                base.fTypeDescriptor.properties["OracleQuery"].attributes.replace(new DisplayNameAttribute("Oracle Database"));
                base.fTypeDescriptor.properties["MySqlQuery"].attributes.replace(new DisplayNameAttribute("MySQL"));
                base.fTypeDescriptor.properties["MariaDbQuery"].attributes.replace(new DisplayNameAttribute("MariaDB"));
                base.fTypeDescriptor.properties["PostgreSqlQuery"].attributes.replace(new DisplayNameAttribute("PostgreSQL"));

                // --

                base.fTypeDescriptor.properties["Type"].attributes.replace(new DefaultValueAttribute(m_type));
                base.fTypeDescriptor.properties["System"].attributes.replace(new DefaultValueAttribute(m_system));
                base.fTypeDescriptor.properties["Module"].attributes.replace(new DefaultValueAttribute(m_module));
                base.fTypeDescriptor.properties["Function"].attributes.replace(new DefaultValueAttribute(m_function));
                base.fTypeDescriptor.properties["ID"].attributes.replace(new DefaultValueAttribute(m_uniqueIdToString));
                base.fTypeDescriptor.properties["SqlCode"].attributes.replace(new DefaultValueAttribute(m_sqlCode));
                base.fTypeDescriptor.properties["Description"].attributes.replace(new DefaultValueAttribute(m_description));
                base.fTypeDescriptor.properties["UsedMigration"].attributes.replace(new DefaultValueAttribute(m_usedMigration));
                base.fTypeDescriptor.properties["MsSqlQuery"].attributes.replace(new DefaultValueAttribute(m_msSqlQuery));
                base.fTypeDescriptor.properties["OracleQuery"].attributes.replace(new DefaultValueAttribute(m_oracleQuery));
                base.fTypeDescriptor.properties["MySqlQuery"].attributes.replace(new DefaultValueAttribute(m_mySqlQuery));
                base.fTypeDescriptor.properties["MariaDbQuery"].attributes.replace(new DefaultValueAttribute(m_mariaDbQuery));
                base.fTypeDescriptor.properties["PostgreSqlQuery"].attributes.replace(new DefaultValueAttribute(m_postgreSqlQuery));
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
