/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOraTransactExecutor.cs
--  Creator         : kitae
--  Create Date     : 2011.03.02
--  Description     : FAMate Core FaCommon Database FOraTransactExecutor Class
--  History         : Created by kitae at 2011.03.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OracleClient;
using System.Data;

namespace Nexplant.MC.Core.FaCommon
{
    public class FOraTransactExecutor : FBaseExecutor, FITransactExecutor 
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FOraTransactExecutor(
            )
            : base()
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOraTransactExecutor(
            string connectionString            
            )
            : base(connectionString)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOraTransactExecutor(
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
            OracleConnection oraCon = null;
            OracleTransaction oraTran = null;
            OracleCommand oraCmd = null;
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
            
            using (oraCon = new OracleConnection(base.connectionString))
            {
                try
                {
                    if (base.sqlList.Count == 0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0003, "SQL List"));
                    }

                    // --

                    oraCon.Open();
                    while (true)
                    {
                        try
                        {
                            rowCount = 0;
                            oraTran = oraCon.BeginTransaction();
                            oraCmd = oraCon.CreateCommand();
                            oraCmd.Connection = oraCon;
                            oraCmd.Transaction = oraTran;
                            oraCmd.CommandTimeout = timeout;

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
                                oraCmd.CommandText = fsql.sqlEx;
                                foreach (FSqlParameter sqlPar in fsql.sqlParameterCollection)
                                {
                                    oraCmd.Parameters.Add(sqlPar.oracleParameter);
                                }
                                rowCount += oraCmd.ExecuteNonQuery();
                                oraCmd.Parameters.Clear();
                            }

                            // --

                            oraTran.Commit();
                            break;
                        }
                        catch (OracleException oraEx)
                        {
                            FDebug.writeLog(oraEx);

                            // --

                            fSqlErrors = FDbAdapter.createSqlErrors(oraEx);

                            // --

                            // ***
                            // 2013.02.26 by spike.lee
                            // 크로스 락 Check, 30회 동안 재시도 후, 실패시 데드락으로 간주                            
                            // ***
                            if (fSqlErrors.containsErrorCode(FDbErrorCode.ORA_00060) && retryCnt < 30)
                            {
                                System.Diagnostics.Debug.WriteLine("Cross-Lock!!!");

                                // --

                                if (oraTran != null)
                                {
                                    oraTran.Rollback();
                                    oraTran.Dispose();
                                    oraTran = null;
                                }
                                // --
                                if (oraCmd != null)
                                {
                                    oraCmd.Dispose();
                                    oraCmd = null;
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
                                    oraEx.Message + Environment.NewLine +
                                    "System=<" + system + ">, Module=<" + module + ">, Function=<" + function + ">, SqlCode=<" + sqlCode + ">";
                                // --
                                FDebug.throwException(new FDbException(fSqlErrorType, fSqlErrors, errorMessage, oraEx));
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
                    if (ex is FDbException || ex is OracleException)
                    {
                        try
                        {
                            if (oraTran != null)
                            {
                                // ***
                                // Rollback
                                // ***
                                oraTran.Rollback();
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
                    if (oraTran != null)
                    {
                        oraTran.Dispose();
                        oraTran = null;
                    }
                    if (oraCmd != null)
                    {
                        oraCmd.Dispose();
                        oraCmd = null;
                    }
                    if (oraCon != null)
                    {
                        if (oraCon.State != ConnectionState.Closed)
                        {
                            oraCon.Close();
                        }
                        oraCon.Dispose();
                        oraCon = null;
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
} // Namespcae end
