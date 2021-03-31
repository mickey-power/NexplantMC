/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FsqlParameter.cs
--  Creator         : kitae
--  Create Date     : 2011.02.28
--  Description     : FAMate Core FaCommon Database FSqlParameter Class
--  History         : Created by kitae at 2011.02.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;
using MySql.Data.MySqlClient;
using Npgsql;

namespace Nexplant.MC.Core.FaCommon
{
    public class FSqlParameter : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private string m_name = string.Empty;
        private Type m_type = typeof(string);
        private object m_value = DBNull.Value;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSqlParameter(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqlParameter(
            string name
            )
            : this(name, DBNull.Value, typeof(System.DBNull))
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqlParameter(
            string name,
            object value
            )
            : this(name, value, value.GetType())
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqlParameter(
            string name,
            object value,
            Type type
            )
        {
            m_name = name;
            m_type = type;
            this.value = value;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSqlParameter(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {

                }
            }
            m_disposed = true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
        
        #region IDisposable

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string name
        {
            get
            {
                try
                {
                    return m_name;
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
                    m_name = value;
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

        public bool isNull
        {
            get
            {
                try
                {
                    return value == DBNull.Value ? true : false;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Type type
        {
            get
            {
                try
                {
                    return m_type;
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
                    m_type = value;
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

        public object value
        {
            get
            {
                try
                {
                    return m_value;
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
                    if (m_type == typeof(string) && (string)value == string.Empty)
                    {
                        m_value = " ";
                    }
                    else 
                    {
                        m_value = value;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal SqlParameter sqlParameter
        {
            get
            {
                SqlParameter sqlPar = null;

                try
                {
                    sqlPar = new SqlParameter();
                    sqlPar.ParameterName = m_name;
                    sqlPar.Value = m_value;
                    return sqlPar;
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

        internal System.Data.OracleClient.OracleParameter oracleParameter
        {
            get
            {
                System.Data.OracleClient.OracleParameter oraPar = null;

                try
                {
                    oraPar = new System.Data.OracleClient.OracleParameter();
                    oraPar.ParameterName = m_name;
                    oraPar.Value = m_value;
                    return oraPar;
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

        internal Oracle.ManagedDataAccess.Client.OracleParameter oracleExParameter
        {
            get
            {
                Oracle.ManagedDataAccess.Client.OracleParameter oraPar = null;

                try
                {
                    oraPar = new Oracle.ManagedDataAccess.Client.OracleParameter();
                    oraPar.ParameterName = m_name;                    
                    oraPar.Value = m_value;                   
                    return oraPar;
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

        internal MySqlParameter mySqlParameter
        {
            get
            {
                MySqlParameter mysPar = null;

                try
                {
                    mysPar = new MySqlParameter();
                    mysPar.ParameterName = m_name;
                    mysPar.Value = m_value;
                    return mysPar;
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

        internal MySqlParameter mariaDbParameter
        {
            get
            {
                MySqlParameter marPar = null;

                try
                {
                    marPar = new MySqlParameter();
                    marPar.ParameterName = m_name;
                    marPar.Value = m_value;
                    return marPar;
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

        internal NpgsqlParameter pgSqlParameter
        {
            get
            {
                NpgsqlParameter pgsPar = null;

                try
                {
                    pgsPar = new NpgsqlParameter();
                    pgsPar.ParameterName = m_name;
                    pgsPar.Value = m_value;
                    return pgsPar;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end
