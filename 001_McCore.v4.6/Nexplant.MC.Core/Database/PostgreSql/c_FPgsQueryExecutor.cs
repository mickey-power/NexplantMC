/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPgsQueryExecutor.cs
--  Creator         : mjkim
--  Create Date     : 2013.11.14
--  Description     : FAMate Core FaCommon Database FPgsQueryExecutor Class
--  History         : Created by mjkim at 2013.11.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Npgsql;

namespace Nexplant.MC.Core.FaCommon
{
    public class FPgsQueryExecutor : FBaseExecutor, FIQueryExecutor
    {
        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FPgsQueryExecutor(
            )
            : base()
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FPgsQueryExecutor(
            string connectString            
            )
            : base(connectString)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPgsQueryExecutor(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(bool disposing)
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

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public DataSet execute(
            int timeout,
            bool sqlClear
            )
        {
            NpgsqlConnection pgsCon = null;
            NpgsqlCommand pgsCmd = null;
            NpgsqlDataAdapter pgsAdt = null;
            DataSet tempDs = null;
            DataSet ds = null;
            DataTable dt = null;
            FSqlErrorCollection fSqlErrors = null;
            FSqlErrorType fSqlErrorType = FSqlErrorType.Normal;
            // --
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            string sqlCode = string.Empty;
            string errorMessage = string.Empty;

            using (pgsCon = new NpgsqlConnection(base.connectionString))
            {
                try
                {
                    if(base.sqlList.Count==0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0003,"sql list"));
                    }

                    // --

                    pgsCmd = pgsCon.CreateCommand();
                    pgsCmd.CommandTimeout = timeout;
                    pgsCmd.Connection = pgsCon;
                    ds = new DataSet();
                    tempDs = new DataSet();

                    // --

                    foreach (FSql fsql in base.sqlList)
                    {
                        system = fsql.system;
                        module = fsql.module;
                        function = fsql.function;
                        sqlCode = fsql.sqlCode;

                        // --

                        // ***
                        // 2014.02.07 Jungyoul
                        // sql -> sqlEx 변경
                        // ***
                        pgsCmd.CommandText = fsql.sqlEx;
                        foreach (FSqlParameter sqlPar in fsql.sqlParameterCollection)
                        {
                            pgsCmd.Parameters.Add(sqlPar.pgSqlParameter);
                        }
                        pgsAdt = new NpgsqlDataAdapter(pgsCmd);
                        pgsAdt.Fill(tempDs);
                        pgsCmd.Parameters.Clear();

                        // --

                        dt = tempDs.Tables[0];
                        tempDs.Tables.Remove(dt);
                        tempDs.Clear();

                        // --

                        dt.TableName = fsql.name;
                        ds.Tables.Add(dt);
                    }

                    // --

                    if (sqlClear)
                    {
                        base.clearSql();
                    }
                    return ds;
                }
                catch(NpgsqlException pgsEx)
                {
                    FDebug.writeLog(pgsEx);

                    // --

                    fSqlErrors = FDbAdapter.createSqlErrors(pgsEx);
                    fSqlErrorType = FDbAdapter.getSqlErrorTypeOfPostgreSql(fSqlErrors);
                    // --
                    errorMessage =
                        pgsEx.Message + Environment.NewLine +
                        "System=<" + system + ">, Module=<" + module + ">, Function=<" + function + ">, SqlCode=<" + sqlCode + ">";
                    // --
                    FDebug.throwException(new FDbException(fSqlErrorType, fSqlErrors, errorMessage, pgsEx));                    
                }                
                catch(Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    if (pgsAdt != null)
                    {
                        pgsAdt.Dispose();
                        pgsAdt = null;
                    }

                    if (pgsCmd != null)
                    {
                        pgsCmd.Dispose();
                        pgsCmd = null;
                    }

                    if (tempDs != null)
                    {
                        tempDs.Dispose();
                        tempDs = null;
                    }

                    if (pgsCon != null)
                    {
                        if (pgsCon.State != ConnectionState.Closed)
                        {
                            pgsCon.Close();
                        }
                        pgsCon.Dispose();
                        pgsCon = null;
                    }

                    fSqlErrors = null;
                }
                return null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public DataSet execute(
            int timeout
            )
        {
            try
            {
                return execute(timeout, true);
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

        public DataSet execute(
            bool sqlClear
            )
        {
            try
            {
                return execute(base.timeout, sqlClear);
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

        public DataSet execute(
            )
        {
            try
            {
                return execute(base.timeout, true);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end
