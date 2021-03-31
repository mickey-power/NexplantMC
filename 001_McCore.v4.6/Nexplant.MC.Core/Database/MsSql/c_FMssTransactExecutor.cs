/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMssTransactExecutor.cs
--  Creator         : kitae
--  Create Date     : 2011.03.03
--  Description     : FAMate Core FaCommon Database FMssTransactExecutor Class
--  History         : Created by kitae at 2011.03.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace Nexplant.MC.Core.FaCommon
{
    class FMssTransactExecutor : FBaseExecutor, FITransactExecutor
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Desturction
        
        internal FMssTransactExecutor(
            )
            : base()
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FMssTransactExecutor(
            string connectString            
            )
            : base(connectString)
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMssTransactExecutor(
            )
        {
            myDispose(false);
        }

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

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public int execute(
            int timeout,
            bool sqlClear
            )
        {
            SqlConnection sqlCon = null;
            SqlTransaction sqlTran = null;
            SqlCommand sqlCmd = null;
            int rowCount = 0;
            int retryCnt = 0;
            FSqlErrorCollection fSqlErrors = null;
            FSqlErrorType fSqlErrorType = FSqlErrorType.Normal;
            // --
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            string sqlCode = string.Empty;
            string errorMessage = string.Empty;
            
            using (sqlCon = new SqlConnection(base.connectionString))
            {
                try
                {
                    if (base.sqlList.Count == 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0003, "SQL List"));
                    }

                    // --

                    sqlCon.Open();
                    while (true)
                    {
                        try
                        {
                            rowCount = 0;
                            sqlTran = sqlCon.BeginTransaction();
                            sqlCmd = sqlCon.CreateCommand();
                            sqlCmd.Connection = sqlCon;
                            sqlCmd.Transaction = sqlTran;
                            sqlCmd.CommandTimeout = timeout;

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
                                sqlCmd.CommandText = fsql.sqlEx;
                                foreach (FSqlParameter sqlPar in fsql.sqlParameterCollection)
                                {
                                    sqlCmd.Parameters.Add(sqlPar.sqlParameter);
                                }
                                rowCount += sqlCmd.ExecuteNonQuery();
                                sqlCmd.Parameters.Clear();
                            }

                            // --

                            sqlTran.Commit();
                            break;
                        }
                        catch (SqlException sqlEx)
                        {
                            FDebug.writeLog(sqlEx);

                            // --

                            fSqlErrors = FDbAdapter.createSqlErrors(sqlEx);

                            // --

                            // ***
                            // 2013.02.26 by spike.lee
                            // 크로스 락 Check, 30회 동안 재시도 후, 실패시 데드락으로 간주                            
                            // ***
                            if (fSqlErrors.containsErrorCode(FDbErrorCode.SQL_01205) && retryCnt < 30)
                            {
                                System.Diagnostics.Debug.WriteLine("Cross-Lock!!!");

                                // --

                                if (sqlTran != null)
                                {
                                    sqlTran.Rollback();
                                    sqlTran.Dispose();
                                    sqlTran = null;
                                }
                                // --
                                if (sqlCmd != null)
                                {
                                    sqlCmd.Dispose();
                                    sqlCmd = null;
                                }

                                // --

                                retryCnt++;
                                System.Threading.Thread.Sleep(10);
                            }
                            else
                            {
                                fSqlErrorType = FDbAdapter.getSqlErrorTypeOfMsSqlServer(fSqlErrors);
                                // --
                                errorMessage =
                                    sqlEx.Message + Environment.NewLine +
                                    "System=<" + system + ">, Module=<" + module + ">, Function=<" + function + ">, SqlCode=<" + sqlCode + ">";
                                // --
                                FDebug.throwException(new FDbException(fSqlErrorType, fSqlErrors, errorMessage, sqlEx));                    
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

                    // --

                    if (sqlClear)
                    {
                        base.clearSql();
                    }
                    return rowCount;
                }
                catch (Exception ex)
                {
                    if (ex is FDbException || ex is SqlException)
                    {
                        try
                        {
                            if (sqlTran != null)
                            {
                                // ***
                                // Rollback
                                // ***
                                sqlTran.Rollback();
                            }
                        }
                        catch (Exception inEx)
                        {
                            FDebug.writeLog(inEx);
                        }                    
                    }

                    // --

                    FDebug.throwException(ex);
                }
                finally
                {
                    if (sqlTran != null)
                    {
                        sqlTran.Dispose();
                        sqlTran = null;
                    }

                    if (sqlCmd != null)
                    {
                        sqlCmd.Dispose();
                        sqlCmd = null;
                    }

                    if(sqlCon.State!= ConnectionState.Closed)
                    {
                        sqlCon.Close();
                    }

                    fSqlErrors = null;
                }
            }
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int execute(
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
            return 0;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int execute(
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
            return 0;

        }

        //------------------------------------------------------------------------------------------------------------------------


        public int execute(
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
            return 0;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end
