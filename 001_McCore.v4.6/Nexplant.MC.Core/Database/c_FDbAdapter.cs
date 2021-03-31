/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDbAdapter.cs
--  Creator         : kitae
--  Create Date     : 2011.02.28
--  Description     : FAMate Core FaCommon Database FDbAdapter Class
--  History         : Created by kitae at 2011.02.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FDbAdapter
    {
        static private HashSet<int> m_oracleCriticalErrorCode = null;
        static private HashSet<int> m_oracleWarningErrorCode = null;
        static private HashSet<int> m_msSqlServerCriticalErrorCode = null;
        static private HashSet<int> m_msSqlServerWarningErrorCode = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FDbAdapter(
            )
        {
            m_oracleCriticalErrorCode = new HashSet<int>();
            m_oracleWarningErrorCode = new HashSet<int>();
            m_msSqlServerCriticalErrorCode = new HashSet<int>();
            m_msSqlServerWarningErrorCode = new HashSet<int>();
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties
        
        internal static HashSet<int> oracleCriticalErrorCode
        {
            get
            {
                try
                {
                    return m_oracleCriticalErrorCode;
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

        internal static HashSet<int> oracleWarningErrorCode
        {
            get
            {
                try
                {
                    return m_oracleWarningErrorCode;
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

        internal static HashSet<int> msSqlServerCriticalErrorCode
        {
            get
            {
                try
                {
                    return m_msSqlServerCriticalErrorCode;
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

        internal static HashSet<int> msSqlServerWarningErrorCode
        {
            get
            {
                try
                {
                    return m_msSqlServerWarningErrorCode;
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

        internal static FSqlErrorCollection createSqlErrors(
            SqlException sqlEx
            )
        {
            List<FSqlError> fSqlErrorList = null;

            try
            {
                fSqlErrorList = new List<FSqlError>();

                // --

                foreach (SqlError err in sqlEx.Errors)
                {
                    fSqlErrorList.Add(new FSqlError(err.Number, err.Message));
                }

                // --

                return new FSqlErrorCollection(fSqlErrorList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlErrorList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FSqlErrorCollection createSqlErrors(
            System.Data.OracleClient.OracleException oraEx
            )
        {
            List<FSqlError> fSqlErrorList = null;

            try
            {
                fSqlErrorList = new List<FSqlError>();

                // --

                fSqlErrorList.Add(new FSqlError(oraEx.Code, oraEx.Message));

                // --

                return new FSqlErrorCollection(fSqlErrorList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlErrorList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FSqlErrorCollection createSqlErrors(
            Oracle.ManagedDataAccess.Client.OracleException oraEx
            )
        {
            List<FSqlError> fSqlErrorList = null;

            try
            {
                fSqlErrorList = new List<FSqlError>();

                // --

                foreach (Oracle.ManagedDataAccess.Client.OracleError err in oraEx.Errors)
                {
                    fSqlErrorList.Add(new FSqlError(err.Number, err.Message));
                }

                // --

                return new FSqlErrorCollection(fSqlErrorList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlErrorList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FSqlErrorCollection createSqlErrors(
            MySql.Data.MySqlClient.MySqlException mysEx
            )
        {
            List<FSqlError> fSqlErrorList = null;

            try
            {
                fSqlErrorList = new List<FSqlError>();

                // --

                fSqlErrorList.Add(new FSqlError(mysEx.Number, mysEx.Message));

                // --

                return new FSqlErrorCollection(fSqlErrorList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlErrorList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FSqlErrorCollection createSqlErrors(
            Npgsql.NpgsqlException pgsEx
            )
        {
            List<FSqlError> fSqlErrorList = null;

            try
            {
                fSqlErrorList = new List<FSqlError>();

                // --

                fSqlErrorList.Add(new FSqlError(pgsEx.ErrorCode, pgsEx.Message));

                // --

                return new FSqlErrorCollection(fSqlErrorList);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fSqlErrorList = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FSqlErrorType getSqlErrorTypeOfMsSqlServer(
            FSqlErrorCollection fSqlErrors
            )
        {
            try
            {
                foreach (FSqlError ferr in fSqlErrors)
                {
                    if (m_msSqlServerCriticalErrorCode.Contains(ferr.errorCode))
                    {
                        return FSqlErrorType.Critical;
                    }
                }

                // --

                foreach (FSqlError ferr in fSqlErrors)
                {
                    if (m_msSqlServerWarningErrorCode.Contains(ferr.errorCode))
                    {
                        return FSqlErrorType.Warning;
                    }
                }

                // --

                return FSqlErrorType.Normal;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FSqlErrorType.Normal;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FSqlErrorType getSqlErrorTypeOfOracle(
            FSqlErrorCollection fSqlErrors
            )
        {
            try
            {
                foreach (FSqlError ferr in fSqlErrors)
                {
                    if (m_oracleCriticalErrorCode.Contains(ferr.errorCode))
                    {
                        return FSqlErrorType.Critical;
                    }
                }

                // --

                foreach (FSqlError ferr in fSqlErrors)
                {
                    if (m_oracleWarningErrorCode.Contains(ferr.errorCode))
                    {
                        return FSqlErrorType.Warning;
                    }
                }

                // --

                return FSqlErrorType.Normal;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FSqlErrorType.Normal;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FSqlErrorType getSqlErrorTypeOfMySql(
            FSqlErrorCollection fSqlErrors
            )
        {
            try
            {

            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FSqlErrorType.Normal;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FSqlErrorType getSqlErrorTypeOfMariaDb(
            FSqlErrorCollection fSqlErrors
            )
        {
            try
            {

            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FSqlErrorType.Normal;
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal static FSqlErrorType getSqlErrorTypeOfPostgreSql(
            FSqlErrorCollection fSqlErrors
            )
        {
            try
            {

            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FSqlErrorType.Normal;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FIQueryExecutor createQueryExecutor(
            FDbProvider fDbProvider, 
            string connectString            
            )
        {
            try
            {
                if (fDbProvider == FDbProvider.MsSqlServer)
                {
                    return (FIQueryExecutor)(new FMssQueryExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.Oracle)
                {
                    return (FIQueryExecutor)(new FOraQueryExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.OracleEx)
                {
                    return (FIQueryExecutor)(new FOdpQueryExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.MySql)
                {
                    return (FIQueryExecutor)(new FMysQueryExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.MariaDb)
                {
                    return (FIQueryExecutor)(new FMarQueryExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.PostgreSql)
                {
                    return (FIQueryExecutor)(new FPgsQueryExecutor(connectString));
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        public static FITransactExecutor createTransactExecutor(
            FDbProvider fDbProvider,
            string connectString            
            )
        {
            try
            {
                if (fDbProvider == FDbProvider.MsSqlServer)
                {
                    return (FITransactExecutor)(new FMssTransactExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.Oracle)
                {
                    return (FITransactExecutor)(new FOraTransactExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.OracleEx)
                {
                    return (FITransactExecutor)(new FOdpTransactExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.MySql)
                {
                    return (FITransactExecutor)(new FMysTransactExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.MariaDb)
                {
                    return (FITransactExecutor)(new FMarTransactExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.PostgreSql)
                {
                    return (FITransactExecutor)(new FPgsTransactExecutor(connectString));
                }
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

        //------------------------------------------------------------------------------------------------------------------------
        
        public static FIProcedureExecutor createProcedureExecutor(
            FDbProvider fDbProvider,
            string connectString
            )
        {
            try
            {
                if (fDbProvider == FDbProvider.MsSqlServer)
                {
                    throw new NotImplementedException();                    
                }
                else if (fDbProvider == FDbProvider.Oracle)
                {
                    throw new NotImplementedException();
                }
                else if (fDbProvider == FDbProvider.OracleEx)
                {
                    return (FIProcedureExecutor)(new FOdpProcedureExecutor(connectString));
                }
                else if (fDbProvider == FDbProvider.MySql)
                {
                    throw new NotImplementedException();
                }
                else if (fDbProvider == FDbProvider.MariaDb)
                {
                    throw new NotImplementedException();
                }
                else if (fDbProvider == FDbProvider.PostgreSql)
                {
                    throw new NotImplementedException();
                }
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

        //------------------------------------------------------------------------------------------------------------------------

        public static void addOracleCriticalErrorCode(
            int errorCode            
            )
        {
            try
            {
                if (m_oracleCriticalErrorCode == null)
                {
                    m_oracleCriticalErrorCode = new HashSet<int>();
                }
                m_oracleCriticalErrorCode.Add(errorCode);
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

        public static void addOracleWarningErrorCode(
            int errorCode
            )
        {
            try
            {
                if (m_oracleWarningErrorCode == null)
                {
                    m_oracleWarningErrorCode = new HashSet<int>();
                }
                m_oracleWarningErrorCode.Add(errorCode);
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

        public static void addMsSqlServerCriticalErrorCode(
            int errorCode
            )
        {
            try
            {
                if (m_msSqlServerCriticalErrorCode == null)
                {
                    m_msSqlServerCriticalErrorCode = new HashSet<int>();
                }
                m_msSqlServerCriticalErrorCode.Add(errorCode);
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

        public static void addMsSqlServerWarningErrorCode(
            int errorCode
            )
        {
            try
            {
                if (m_msSqlServerWarningErrorCode == null)
                {
                    m_msSqlServerWarningErrorCode = new HashSet<int>();
                }
                m_msSqlServerWarningErrorCode.Add(errorCode);
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

        public static string exportQueryFromMsSqlServer(
            FDbProvider fDbProvider,
            string sql
            )
        {
            string query = sql;

            try
            {
                if (fDbProvider == FDbProvider.Oracle ||
                    fDbProvider == FDbProvider.OracleEx
                    )
                {
                    query = query.Replace("@", ":");
                    query = query.Replace("ISNULL", "NVL");
                    query = query.Replace("STDEV", "STDDEV");
                    query = query.Replace("+", "||");
                }
                else if (
                    fDbProvider == FDbProvider.MySql ||
                    fDbProvider == FDbProvider.MariaDb
                    )
                {
                    query = query.Replace("ISNULL", "COALESCE");
                    query = query.Replace("STDEV", "STD");
                }
                else if (fDbProvider == FDbProvider.PostgreSql)
                {
                    query = query.Replace("ISNULL", "COALESCE");
                    query = query.Replace("STDEV", "STDDEV");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return query;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string exportQueryFromOracle(
            FDbProvider fDbProvider,
            string sql
            )
        {
            string query = sql;

            try
            {
                if (fDbProvider == FDbProvider.MsSqlServer)
                {
                    query = query.Replace(":", "@");
                    query = query.Replace("NVL", "ISNULL");
                    query = query.Replace("STDDEV", "STDEV");
                    query = query.Replace("||", "+");
                }
                else if (
                    fDbProvider == FDbProvider.MySql ||
                    fDbProvider == FDbProvider.MariaDb
                    )
                {
                    query = query.Replace(":", "@");
                    query = query.Replace("NVL", "COALESCE");
                    query = query.Replace("STDDEV", "STD");
                }
                else if (fDbProvider == FDbProvider.PostgreSql)
                {
                    query = query.Replace(":", "@");
                    query = query.Replace("NVL", "COALESCE");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return query;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string exportQueryFromMySql(
            FDbProvider fDbProvider,
            string sql
            )
        {
            string query = sql;

            try
            {
                if (fDbProvider == FDbProvider.MsSqlServer)
                {
                    query = query.Replace("COALESCE", "ISNULL");
                    query = query.Replace("STD", "STDEV");
                }
                else if (
                    fDbProvider == FDbProvider.Oracle ||
                    fDbProvider == FDbProvider.OracleEx
                    )
                {
                    query = query.Replace("@", ":");
                    query = query.Replace("COALESCE", "NVL");
                    query = query.Replace("STD", "STDDEV");
                }
                else if (fDbProvider == FDbProvider.PostgreSql)
                {
                    query = query.Replace("STD", "STDDEV");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return query;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string exportQueryFromMariaDb(
            FDbProvider fDbProvider,
            string sql
            )
        {
            string query = sql;

            try
            {
                if (fDbProvider == FDbProvider.MsSqlServer)
                {
                    query = query.Replace("COALESCE", "ISNULL");
                    query = query.Replace("STD", "STDEV");
                }
                else if (
                    fDbProvider == FDbProvider.Oracle ||
                    fDbProvider == FDbProvider.OracleEx
                    )
                {
                    query = query.Replace("@", ":");
                    query = query.Replace("COALESCE", "NVL");
                    query = query.Replace("STD", "STDDEV");
                }
                else if (fDbProvider == FDbProvider.PostgreSql)
                {
                    query = query.Replace("STD", "STDDEV");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return query;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string exportQueryFromPostgreSql(
            FDbProvider fDbProvider,
            string sql
            )
        {
            string query = sql;

            try
            {
                if (fDbProvider == FDbProvider.MsSqlServer)
                {
                    query = query.Replace("COALESCE", "ISNULL");
                    query = query.Replace("STDDEV", "STDEV");
                }
                else if (
                    fDbProvider == FDbProvider.Oracle ||
                    fDbProvider == FDbProvider.OracleEx
                    )
                {
                    query = query.Replace("@", ":");
                    query = query.Replace("COALESCE", "NVL");
                }
                else if (
                    fDbProvider == FDbProvider.MySql ||
                    fDbProvider == FDbProvider.MariaDb
                    )
                {
                    query = query.Replace("STDDEV", "STD");
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return query;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
