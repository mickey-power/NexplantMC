/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMarTransactExecutor.cs
--  Creator         : mjkim
--  Create Date     : 2013.10.01
--  Description     : FAMate Core FaCommon Database FMarTransactExecutor Class
--  History         : Created by mjkim at 2013.10.01
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace Nexplant.MC.Core.FaCommon
{
    public class FMarTransactExecutor : FBaseExecutor, FITransactExecutor
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FMarTransactExecutor(
            )
            : base()
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FMarTransactExecutor(
            string connectionString         
            )
            :base(connectionString)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMarTransactExecutor(
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

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public int execute(
            int timeout,
            bool sqlClear
            )
        {
            MySqlConnection marCon = null;
            MySqlTransaction marTran = null;
            MySqlCommand marCmd = null;
            int rowCount = 0;
            FSqlErrorCollection fSqlErrors = null;
            FSqlErrorType fSqlErrorType = FSqlErrorType.Normal;
            // --
            string system = string.Empty;
            string module = string.Empty;
            string function = string.Empty;
            string sqlCode = string.Empty;
            string errorMessage = string.Empty;

            using (marCon = new MySqlConnection(base.connectionString))
            {
                try
                {
                    if (base.sqlList.Count == 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0003, "sql_list"));
                    }

                    // --

                    marCon.Open();
                    while (true)
                    {
                        try
                        {
                            rowCount = 0;
                            marTran = marCon.BeginTransaction();
                            marCmd = marCon.CreateCommand();
                            marCmd.Connection = marCon;
                            marCmd.Transaction = marTran;
                            marCmd.CommandTimeout = timeout;

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
                                marCmd.CommandText = fsql.sqlEx;
                                foreach (FSqlParameter sqlPar in fsql.sqlParameterCollection)
                                {
                                    marCmd.Parameters.Add(sqlPar.mariaDbParameter);
                                }
                                rowCount += marCmd.ExecuteNonQuery();
                                marCmd.Parameters.Clear();
                            }

                            // --

                            marTran.Commit();                            
                            break;
                        }
                        catch (MySqlException marEx)
                        {
                            FDebug.writeLog(marEx);

                            // --

                            fSqlErrors = FDbAdapter.createSqlErrors(marEx);
                            fSqlErrorType = FDbAdapter.getSqlErrorTypeOfMariaDb(fSqlErrors);
                            // --
                            errorMessage =
                                marEx.Message + Environment.NewLine +
                                "System=<" + system + ">, Module=<" + module + ">, Function=<" + function + ">, SqlCode=<" + sqlCode + ">";
                            // --
                            FDebug.throwException(new FDbException(fSqlErrorType, fSqlErrors, errorMessage, marEx));     
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
                    if (ex is FDbException || ex is MySqlException)
                    {
                        try
                        {
                            if (marTran != null)
                            {
                                // ***
                                // Rollback
                                // ***
                                marTran.Rollback();
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
                    if (marTran != null)
                    {
                        marTran.Dispose();
                        marTran = null;
                    }

                    if (marCmd != null)
                    {
                        marCmd.Dispose();
                        marCmd = null;
                    }

                    if (marCon != null)
                    {
                        if (marCon.State != ConnectionState.Closed)
                        {
                            marCon.Close();
                        }
                        marCon.Dispose();
                        marCon = null;
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
