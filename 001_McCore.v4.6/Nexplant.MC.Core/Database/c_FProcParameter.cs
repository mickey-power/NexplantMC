/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProcParameter.cs
--  Creator         : byjeon
--  Create Date     : 2014.08.12
--  Description     : FAMate Core FaCommon Database FProcParameter Class
--  History         : Created by byjeon at 2014.08.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Data.SqlClient;
using Oracle.ManagedDataAccess.Client;
using MySql.Data.MySqlClient;
using Npgsql;

namespace Nexplant.MC.Core.FaCommon
{
    public class FProcParameter : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        
        // -- 

        private string m_name = string.Empty;
        private object m_value = DBNull.Value;
        private FDbType m_fDbType = FDbType.NVarChar;
        private ParameterDirection m_direction = ParameterDirection.Input;
        private int m_size = 0;
        // --
        private string m_aliasName = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FProcParameter(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProcParameter(
            string name,
            object value,
            string aliasName = ""
            )
        {
            m_name = name;
            m_value = value;
            m_aliasName = aliasName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProcParameter(
            string name,
            FDbType fDbType,
            ParameterDirection direction,
            string aliasName = ""
            )
            : this(name, fDbType, 0, null, direction, aliasName)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProcParameter(
            string name,
            FDbType fDbType,
            int size,
            ParameterDirection direction,
            string aliasName = ""
            )
            : this(name, fDbType, size, null, direction, aliasName)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProcParameter(
            string name,
            FDbType fDbType,
            object value,
            ParameterDirection direction,
            string aliasName = ""
            )
            : this(name, fDbType, 0, value, direction, aliasName)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public FProcParameter(
            string name,
            FDbType fDbType,
            int size,
            object value,
            ParameterDirection direction,
            string aliasName = ""
            )
        {
            m_name = name;
            m_fDbType = fDbType;
            m_size = size;
            m_value = value;
            m_direction = direction;
            m_aliasName = aliasName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FProcParameter(
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
                    m_value = value;
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

        public FDbType fDbType
        {
            get
            {
                try
                {
                    return m_fDbType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDbType.NVarChar;
            }

            set
            {
                try
                {
                    m_fDbType = value;
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

        public ParameterDirection direction
        {
            get
            {
                try
                {
                    return m_direction;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return ParameterDirection.Input;
            }

            set
            {
                try
                {
                    m_direction = value;
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

        public int size
        {
            get
            {
                try
                {
                    return m_size;
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
                    if (value < 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0005, "Parameter Size"));
                    }
                    m_size = value;
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

        public string aliasName
        {
            get
            {
                try
                {
                    return string.IsNullOrWhiteSpace(m_aliasName) ? name : m_aliasName;
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
                    m_aliasName = value;
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
                    sqlPar.Direction = m_direction;
                    sqlPar.Size = m_size;
                    sqlPar.SqlDbType = toSqlDbType(fDbType);
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
                    oraPar.Direction = m_direction;
                    oraPar.Size = m_size;
                    oraPar.DbType = toOracleDbType(fDbType);
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
                Oracle.ManagedDataAccess.Client.OracleParameter odpPar = null;

                try
                {
                    odpPar = new Oracle.ManagedDataAccess.Client.OracleParameter();
                    odpPar.ParameterName = m_name;
                    odpPar.Value = m_value;
                    odpPar.Direction = m_direction;
                    odpPar.Size = m_size;
                    odpPar.OracleDbType = toOracleExDbType(fDbType);
                    return odpPar;
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
                    mysPar.Direction = m_direction;
                    mysPar.Size = m_size;
                    mysPar.MySqlDbType = toMySqlDbType(fDbType);
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
                    marPar.Direction = m_direction;
                    marPar.Size = m_size;
                    marPar.MySqlDbType = toMariaDbType(fDbType);
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
                    pgsPar.Direction = m_direction;
                    pgsPar.Size = m_size;
                    pgsPar.DbType = toNpgsqlDbType(fDbType);
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

        private DbType toDbType(
            FDbType fDbType
            )
        {
            DbType type = DbType.String;

            try
            {
                if (fDbType == FDbType.Int16)
                {
                    type = DbType.Int16;
                }
                else if (fDbType == FDbType.Int32)
                {
                    type = DbType.Int32;
                }
                else if (fDbType == FDbType.Int64)
                {
                    type = DbType.Int64;
                }
                else if (fDbType == FDbType.Double)
                {
                    type = DbType.Double;
                }
                else if (fDbType == FDbType.Char)
                {
                    type = DbType.AnsiStringFixedLength;
                }
                else if (fDbType == FDbType.VarChar)
                {
                    type = DbType.AnsiString;
                }
                else if (fDbType == FDbType.NChar)
                {
                    type = DbType.StringFixedLength;
                }
                else if (fDbType == FDbType.NVarChar)
                {
                    type = DbType.String;
                }
                else if (fDbType == FDbType.RefCursor)
                {
                    throw new NotSupportedException();
                }
                return type;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return type;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private SqlDbType toSqlDbType(
            FDbType fDbType
            )
        {
            SqlDbType type = SqlDbType.NVarChar;

            try
            {
                if (fDbType == FDbType.Int16)
                {
                    type = SqlDbType.SmallInt;
                }
                else if (fDbType == FDbType.Int32)
                {
                    type = SqlDbType.Int;
                }
                else if (fDbType == FDbType.Int64)
                {
                    type = SqlDbType.BigInt;
                }
                else if (fDbType == FDbType.Double)
                {
                    type = SqlDbType.Float;
                }
                else if (fDbType == FDbType.Char)
                {
                    type = SqlDbType.Char;
                }
                else if (fDbType == FDbType.VarChar)
                {
                    type = SqlDbType.VarChar;
                }
                else if (fDbType == FDbType.NChar)
                {
                    type = SqlDbType.NChar;
                }
                else if (fDbType == FDbType.NVarChar)
                {
                    type = SqlDbType.NVarChar;
                }
                else if (fDbType == FDbType.RefCursor)
                {
                    throw new NotSupportedException();
                }
                return type;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return type;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private DbType toOracleDbType(
           FDbType fDbType
           )
        {
            try
            {
                return toDbType(fDbType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return DbType.AnsiString;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private OracleDbType toOracleExDbType(
            FDbType fDbType
            )
        {
            OracleDbType type = OracleDbType.NVarchar2;

            try
            {
                if (fDbType == FDbType.Int16)
                {
                    type = OracleDbType.Int16;
                }
                else if (fDbType == FDbType.Int32)
                {
                    type = OracleDbType.Int32;
                }
                else if (fDbType == FDbType.Int64)
                {
                    type = OracleDbType.Int64;
                }
                else if (fDbType == FDbType.Double)
                {
                    type = OracleDbType.Double;
                }    
                else if (fDbType == FDbType.Char)
                {
                    type = OracleDbType.Char;
                }
                else if (fDbType == FDbType.VarChar)
                {
                    type = OracleDbType.Varchar2;
                }
                else if (fDbType == FDbType.NChar)
                {
                    type = OracleDbType.NChar;
                }
                else if (fDbType == FDbType.NVarChar)
                {
                    type = OracleDbType.NVarchar2;
                }
                else if (fDbType == FDbType.RefCursor)
                {
                    type = OracleDbType.RefCursor;
                }
                return type;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return type;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private MySqlDbType toMySqlDbType(
            FDbType fDbType
            )
        {
            MySqlDbType type = MySqlDbType.VarString;

            try
            {
                if (fDbType == FDbType.Int16)
                {
                    type = MySqlDbType.Int16;
                }
                else if (fDbType == FDbType.Int32)
                {
                    type = MySqlDbType.Int32;
                }
                else if (fDbType == FDbType.Int64)
                {
                    type = MySqlDbType.Int64;
                }
                else if (fDbType == FDbType.Double)
                {
                    type = MySqlDbType.Double;
                }
                else if (
                    fDbType == FDbType.Char ||
                    fDbType == FDbType.VarChar ||
                    fDbType == FDbType.NChar ||
                    fDbType == FDbType.NVarChar
                    )
                {
                    type = MySqlDbType.VarString;
                }
                else if (fDbType == FDbType.RefCursor)
                {
                    throw new NotSupportedException();
                }
                return type;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return type;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private MySqlDbType toMariaDbType(
            FDbType fDbType
            )
        {
            MySqlDbType type = MySqlDbType.VarString;

            try
            {
                if (fDbType == FDbType.Int16)
                {
                    type = MySqlDbType.Int16;
                }
                else if (fDbType == FDbType.Int32)
                {
                    type = MySqlDbType.Int32;
                }
                else if (fDbType == FDbType.Int64)
                {
                    type = MySqlDbType.Int64;
                }
                else if (fDbType == FDbType.Double)
                {
                    type = MySqlDbType.Double;
                }
                else if (
                    fDbType == FDbType.Char ||
                    fDbType == FDbType.VarChar ||
                    fDbType == FDbType.NChar ||
                    fDbType == FDbType.NVarChar
                    )
                {
                    type = MySqlDbType.VarString;
                }
                else if (fDbType == FDbType.RefCursor)
                {
                    throw new NotSupportedException();
                }
                return type;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return type;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private DbType toNpgsqlDbType(
            FDbType fDbType
            )
        {
            try
            {
                return toDbType(fDbType);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return DbType.AnsiString;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end
