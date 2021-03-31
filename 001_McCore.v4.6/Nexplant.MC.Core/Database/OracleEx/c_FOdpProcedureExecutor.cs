/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOdpProcedureExecutor.cs
--  Creator         : byjeon
--  Create Date     : 2014.08.12
--  Description     : FAMate Core FaCommon Database Oracle ProcedureExecutor Class
--  History         : Created by byjeon at 2014.08.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Nexplant.MC.Core.FaCommon
{
    public class FOdpProcedureExecutor : FIProcedureExecutor, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        // -- 

        private string m_connectionString = string.Empty;
        private int m_timeout = 30; // sec

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FOdpProcedureExecutor(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        public FOdpProcedureExecutor(
            string connectionString         
            )
        {
            m_connectionString = connectionString;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOdpProcedureExecutor(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {

                }
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string connectionString
        {
            get
            {
                try
                {
                    return m_connectionString;
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
                    m_connectionString = value;
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

        public int timeout
        {
            get
            {
                try
                {
                    return m_timeout;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 30;
            }

            set
            {
                try
                {
                    m_timeout = (value > 0) ? value : 30;                    
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public FDbOutputCollection execute(
            FProcedure fProcedure
            )
        {
            try
            {
                return execute(fProcedure, timeout);
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

        public FDbOutputCollection execute(
            FProcedure fProcedure,
            int timeout
            )
        {
            OracleConnection oraCon = null;            
            OracleCommand oraCmd = null;
            int retryCnt = 0;
            FSqlErrorCollection fSqlErrors = null;
            FSqlErrorType fSqlErrorType = FSqlErrorType.Normal;
            OracleDataAdapter dataAdt = null;
            FDbOutputCollection fOutputs = null;
            List<string> list = null;
            DataSet dataSet = null;
            // --
            string errorMessage = string.Empty;

            using (oraCon = new OracleConnection(connectionString))
            {
                try
                {
                    oraCon.Open();
                    while (true)
                    {
                        oraCmd = oraCon.CreateCommand();
                        oraCmd.Connection = oraCon;
                        try
                        {
                            oraCmd.CommandTimeout = timeout;
                            oraCmd.CommandType = CommandType.StoredProcedure;

                            // --

                            oraCmd.CommandText = fProcedure.command;
                            foreach (FProcParameter fParameter in fProcedure.fParameters)
                            {
                                oraCmd.Parameters.Add(fParameter.oracleExParameter);
                            }
                            oraCmd.ExecuteNonQuery();

                            // -- 

                            // ***
                            // Output
                            // ***
                            list = new List<string>();
                            fOutputs = new FDbOutputCollection();
                            foreach (FProcParameter fParameter in fProcedure.fParameters)
                            {
                                if (
                                    fParameter.direction == ParameterDirection.InputOutput ||
                                    fParameter.direction == ParameterDirection.Output
                                    )
                                {
                                    if(
                                        fParameter.fDbType == FDbType.Char ||
                                        fParameter.fDbType == FDbType.VarChar ||
                                        fParameter.fDbType == FDbType.NChar ||
                                        fParameter.fDbType == FDbType.NVarChar
                                        )
                                    {
                                        fOutputs.add(
                                            new FDbString(fParameter.aliasName, oraCmd.Parameters[fParameter.name].Value.ToString())
                                            );
                                    }
                                    else if(
                                        fParameter.fDbType == FDbType.Int16 ||
                                        fParameter.fDbType == FDbType.Int32 ||
                                        fParameter.fDbType == FDbType.Int64
                                        )
                                    {
                                        fOutputs.add(
                                            new FDbNumber(fParameter.aliasName, oraCmd.Parameters[fParameter.name].Value.ToString())
                                            );
                                    }
                                    else if (
                                        fParameter.fDbType == FDbType.Double
                                        )
                                    {
                                        fOutputs.add(
                                            new FDbNumber(fParameter.aliasName, oraCmd.Parameters[fParameter.name].Value.ToString(), 6)
                                            );
                                    }
                                    else if (
                                        fParameter.fDbType == FDbType.RefCursor
                                        )
                                    {
                                        list.Add(fParameter.name);
                                    }
                                }
                            }

                            // --

                            // ***
                            // DataSet
                            // ***
                            dataSet = new DataSet();
                            dataAdt = new OracleDataAdapter(oraCmd);
                            string sourTable;
                            for(int i = 0 ; i < list.Count ; i++)
                            {
                                sourTable = (i == 0) ? OracleDataAdapter.DefaultSourceTableName : OracleDataAdapter.DefaultSourceTableName + i;
                                dataAdt.TableMappings.Add(sourTable, fProcedure.fParameters[list[i]].aliasName);
                            }
                            dataAdt.Fill(dataSet);

                            // -- 

                            fOutputs.add(
                                new FDbDataSet(dataSet)
                                );

                            // --

                            return fOutputs;
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

                                if (oraCmd.Transaction != null)
                                {
                                    oraCmd.Transaction.Rollback();
                                }

                                // --

                                oraCmd.Dispose();
                                oraCmd = null;

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
                                    "Command=<" + fProcedure.command + ">";
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
                }                
                catch (Exception ex)
                {
                    if (ex is FDbException || ex is OracleException)
                    {
                        try
                        {
                            if (oraCmd != null && oraCmd.Transaction != null)
                            {
                                oraCmd.Transaction.Rollback();
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
                    if (oraCmd != null)
                    {
                        if (oraCmd.Transaction != null)
                        {
                            oraCmd.Transaction.Dispose();
                            oraCmd.Transaction = null;
                        }

                        // --

                        oraCmd.Dispose();
                        oraCmd = null;
                    }
                    // --
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
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end
