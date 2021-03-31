/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMarQueryExecutor.cs
--  Creator         : mjkim
--  Create Date     : 2013.10.01
--  Description     : FAMate Core FaCommon Database FMarQueryExecutor Class
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
    public class FMarQueryExecutor : FBaseExecutor, FIQueryExecutor
    {
        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FMarQueryExecutor(
            )
            : base()
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FMarQueryExecutor(
            string connectString            
            )
            : base(connectString)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMarQueryExecutor(
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
            MySqlConnection marCon = null;
            MySqlCommand marCmd = null;
            MySqlDataAdapter marAdt = null;
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

            using (marCon = new MySqlConnection(base.connectionString))
            {
                try
                {
                    if(base.sqlList.Count==0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0003,"sql list"));
                    }

                    // --

                    marCmd = marCon.CreateCommand();
                    marCmd.CommandTimeout = timeout;
                    marCmd.Connection = marCon;
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
                        marCmd.CommandText = fsql.sqlEx;
                        foreach (FSqlParameter sqlPar in fsql.sqlParameterCollection)
                        {
                            marCmd.Parameters.Add(sqlPar.mariaDbParameter);
                        }
                        marAdt = new MySqlDataAdapter(marCmd);
                        marAdt.Fill(tempDs);
                        marCmd.Parameters.Clear();

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
                catch(MySqlException maEx)
                {
                    FDebug.writeLog(maEx);

                    // --

                    fSqlErrors = FDbAdapter.createSqlErrors(maEx);
                    fSqlErrorType = FDbAdapter.getSqlErrorTypeOfMariaDb(fSqlErrors);
                    // --
                    errorMessage =
                        maEx.Message + Environment.NewLine +
                        "System=<" + system + ">, Module=<" + module + ">, Function=<" + function + ">, SqlCode=<" + sqlCode + ">";
                    // --
                    FDebug.throwException(new FDbException(fSqlErrorType, fSqlErrors, errorMessage, maEx));                    
                }                
                catch(Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    if (marAdt != null)
                    {
                        marAdt.Dispose();
                        marAdt = null;
                    }

                    if (marCmd != null)
                    {
                        marCmd.Dispose();
                        marCmd = null;
                    }

                    if (tempDs != null)
                    {
                        tempDs.Dispose();
                        tempDs = null;
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
