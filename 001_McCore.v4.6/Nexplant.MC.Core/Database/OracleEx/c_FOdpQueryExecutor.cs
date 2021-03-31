/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOdpQueryExecutor.cs
--  Creator         : kitae
--  Create Date     : 2011.03.08
--  Description     : FAMate Core FaCommon Database FOdpQueryExecutor Class
--  History         : Created by kitae at 2011.03.08
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Nexplant.MC.Core.FaCommon
{
    public class FOdpQueryExecutor : FBaseExecutor, FIQueryExecutor
    {
        //------------------------------------------------------------------------------------------------------------------------
        
        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FOdpQueryExecutor(
            )
            : base()
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FOdpQueryExecutor(
            string connectString            
            )
            : base(connectString)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOdpQueryExecutor(
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
            OracleConnection oraCon = null;
            OracleCommand oraCmd = null;
            OracleDataAdapter oraAdt = null;
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

            using (oraCon = new OracleConnection(base.connectionString))
            {
                try
                {
                    if(base.sqlList.Count==0)
                    {
                        FDebug.throwFException(string.Format(FConstants.err_m_0003,"sql list"));
                    }

                    // --

                    oraCmd = oraCon.CreateCommand();
                    oraCmd.CommandTimeout = timeout;
                    oraCmd.Connection = oraCon;
                    oraCmd.BindByName = true;   // 2014.08.18 by spike.lee add
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
                        oraCmd.CommandText = fsql.sqlEx;                        
                        foreach (FSqlParameter sqlPar in fsql.sqlParameterCollection)
                        {
                            oraCmd.Parameters.Add(sqlPar.oracleExParameter);
                        }
                        oraAdt = new OracleDataAdapter(oraCmd);
                        oraAdt.Fill(tempDs);
                        oraCmd.Parameters.Clear();

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
                catch(OracleException oraEx)
                {
                    FDebug.writeLog(oraEx);

                    // --

                    fSqlErrors = FDbAdapter.createSqlErrors(oraEx);
                    fSqlErrorType = FDbAdapter.getSqlErrorTypeOfOracle(fSqlErrors);
                    // --
                    errorMessage =
                        oraEx.Message + Environment.NewLine +
                        "System=<" + system + ">, Module=<" + module + ">, Function=<" + function + ">, SqlCode=<" + sqlCode + ">";
                    // --
                    FDebug.throwException(new FDbException(fSqlErrorType, fSqlErrors, errorMessage, oraEx));                    
                }                
                catch(Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    if (oraAdt != null)
                    {
                        oraAdt.Dispose();
                        oraAdt = null;
                    }

                    if (oraCmd != null)
                    {
                        oraCmd.Dispose();
                        oraCmd = null;
                    }

                    if (tempDs != null)
                    {
                        tempDs.Dispose();
                        tempDs = null;
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
