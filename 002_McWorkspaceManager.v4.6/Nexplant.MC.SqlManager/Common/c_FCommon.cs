/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCommon.cs
--  Creator         : mj.kim
--  Create Date     : 2011.11.04
--  Description     : FAMate SQL Manager Common Function Class 
--  History         : Created by mj.kim at 2011.11.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Data;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using Nexplant.MC.H101Interface;

namespace Nexplant.MC.SqlManager
{
    public static class FCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static FXmlNode createXmlNodeIn(
            string elementName
            )
        {
            FXmlDocument fXmlDoc = null;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.appendChild(fXmlDoc.createNode(elementName));
                // --
                return fXmlDoc.fFirstChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlDoc = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FFtp createFtp(
            FSqmCore fSqmCore
            )
        {
            try
            {
                if (fSqmCore.fOption.connectionFtpUsedAnonymous)
                {
                    return new FFtp(false, fSqmCore.fOption.connectionftpIp);
                }
                return new FFtp(false, fSqmCore.fOption.connectionftpIp, fSqmCore.fOption.connectionFtpUser, fSqmCore.fOption.connectionFtpPassword);
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

        public static void validateName(
            string name,
            bool emptyError,
            FUIWizard fUIWizard
            )
        {
            char[] c = { ' ', '\\', '/', '.', ',', '\'', '"', '&', '|', '[', ']', '(', ')', ':', ';', '`', '~', '!', '@', '#', '$', '%', '^', '*', '+', '=', '\n', '\r' };

            try
            {
                if (name == string.Empty && emptyError)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0004", new object[] { "string literal" }));
                }

                if (name.IndexOfAny(c) > -1)
                {
                    FDebug.throwFException(fUIWizard.generateMessage("E0003"));
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

        //------------------------------------------------------------------------------------------------------------------------       

        public static string[] parseDataRows(
            string rows
            )
        {
            const char ROW_SEPARATOR = (char)0x1E;
            const char STX = (char)0x02;

            try
            {
                if (rows[0] == STX)
                {
                    return (rows.Substring(1, rows.Length - 2)).Split(ROW_SEPARATOR);
                }
                else
                {
                    return rows.Split(ROW_SEPARATOR);
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

        public static string[] parseDataCols(
            string cols
            )
        {
            const char COL_SEPARATOR = (char)0x1F;
            const char STX = (char)0x02;

            try
            {
                if (cols[0] == STX)
                {
                    return cols.Substring(1, cols.Length - 2).Split(COL_SEPARATOR);
                }
                else
                {
                    return cols.Split(COL_SEPARATOR);
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

        private static char[] getBindingVariable(
            string dbProvider
            )
        {
            try
            {
                if (
                    dbProvider == FDbProvider.Oracle.ToString() ||
                    dbProvider == FDbProvider.OracleEx.ToString()
                   )
                {
                    return new char[] { ':' };
                }
                else if (
                    dbProvider == FDbProvider.PostgreSql.ToString()
                    )
                {
                    return new char[] { '@' };
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return new char[] { '@' };
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static Dictionary<string, FSqlParameter> parseSqlParameter(
            string dbProvider,
            string sql
            )
        {
            Dictionary<string, FSqlParameter> fSqlParameters = null;
            string[] lineSeparator = { Environment.NewLine };
            char[] charsWordSeparator = { ' ', ',', '(', ')' };
            string key = string.Empty;
            int index = -1;

            try
            {
                fSqlParameters = new Dictionary<string, FSqlParameter>();

                foreach (string line in sql.Split(lineSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    foreach (string word in line.Split(charsWordSeparator))
                    {
                        if (word.IndexOf(FConstants.SqlCommentChars) > -1)
                        {
                            break;
                        }

                        index = word.IndexOfAny(getBindingVariable(dbProvider));
                        if (index <= -1)
                        {
                            continue;
                        }

                        key = word.Substring(index + 1);

                        if (!fSqlParameters.ContainsKey(key))
                        {
                            fSqlParameters.Add(key, new FSqlParameter(key));
                        }
                    }
                }

                return fSqlParameters;
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

        public static DataTable requestSystemList(
            FSqmCore fSqmCore,
            ref int nextRowNumber
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSys = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSystemList_In.E_SQMSQS_SetSystemList_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemList_In.A_hLanguage, FSQMSQS_SetSystemList_In.D_hLanguage, fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemList_In.A_hStep, FSQMSQS_SetSystemList_In.D_hStep, "1");
                // --
                fXmlNodeInSys = fXmlNodeIn.set_elem(FSQMSQS_SetSystemList_In.FSystem.E_System);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemList_In.FSystem.A_NextRowNumber, FSQMSQS_SetSystemList_In.FSystem.D_NextRowNumber, nextRowNumber.ToString());

                // --

                FSQMSQSCaster.SQMSQS_SetSystemList_Req(
                    fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemList_Out.A_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemList_Out.A_hStatusMessage, FSQMSQS_SetSystemList_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_SetSystemList_Out.FTable.E_Table);
                // --
                nextRowNumber = int.Parse(
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetSystemList_Out.FTable.A_NextRowNumber, FSQMSQS_SetSystemList_Out.FTable.D_NextRowNumber)
                    );

                return (
                    FDbWizard.stringToDataTable(
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetSystemList_Out.FTable.A_Columns, FSQMSQS_SetSystemList_Out.FTable.D_Columns),
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetSystemList_Out.FTable.A_Rows, FSQMSQS_SetSystemList_Out.FTable.D_Rows)
                       )
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSys = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable requestModuleList(
            FSqmCore fSqmCore,
            string system,
            ref int nextRowNumber
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMod = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetModuleList_In.E_SQMSQS_SetModuleList_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleList_In.A_hLanguage, FSQMSQS_SetModuleList_In.D_hLanguage, fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleList_In.A_hStep, FSQMSQS_SetModuleList_In.D_hStep, "1");
                // --
                fXmlNodeInMod = fXmlNodeIn.set_elem(FSQMSQS_SetModuleList_In.FModule.E_Module);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleList_In.FModule.A_System, FSQMSQS_SetModuleList_In.FModule.D_System, system);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleList_In.FModule.A_NextRowNumber, FSQMSQS_SetModuleList_In.FModule.D_NextRowNumber, nextRowNumber.ToString());

                // --

                FSQMSQSCaster.SQMSQS_SetModuleList_Req(
                    fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleList_Out.A_hStatus, FSQMSQS_SetModuleList_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleList_Out.A_hStatusMessage, FSQMSQS_SetModuleList_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_SetModuleList_Out.FTable.E_Table);
                // --
                nextRowNumber = int.Parse(
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetModuleList_Out.FTable.A_NextRowNumber, FSQMSQS_SetModuleList_Out.FTable.D_NextRowNumber)
                    );

                return (
                    FDbWizard.stringToDataTable(
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetModuleList_Out.FTable.A_Columns, FSQMSQS_SetModuleList_Out.FTable.D_Columns),
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetModuleList_Out.FTable.A_Rows, FSQMSQS_SetModuleList_Out.FTable.D_Rows)
                        )
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInMod = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable requestFunctionList(
            FSqmCore fSqmCore,
            string system,
            string module,
            ref int nextRowNumber
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetFunctionList_In.E_SQMSQS_SetFunctioneList_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetFunctionList_In.A_hLanguage, FSQMSQS_SetFunctionList_In.D_hLanguage, fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetFunctionList_In.A_hStep, FSQMSQS_SetFunctionList_In.D_hStep, "1");
                // --
                fXmlNodeInFun = fXmlNodeIn.set_elem(FSQMSQS_SetFunctionList_In.FFunction.E_Function);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionList_In.FFunction.A_System, system);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionList_In.FFunction.A_Module, module);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionList_In.FFunction.A_NextRowNumber, FSQMSQS_SetFunctionList_In.FFunction.D_NextRowNumber, nextRowNumber.ToString());

                // --

                FSQMSQSCaster.SQMSQS_SetFunctionList_Req(
                    fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetupFunctionList_Out.A_hStatus, FSQMSQS_SetupFunctionList_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetupFunctionList_Out.A_hStatusMessage, FSQMSQS_SetupFunctionList_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_SetupFunctionList_Out.FTable.E_Table);
                // --
                nextRowNumber = int.Parse(
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetupFunctionList_Out.FTable.A_NextRowNumber, FSQMSQS_SetupFunctionList_Out.FTable.D_NextRowNumber)
                    );

                return (
                    FDbWizard.stringToDataTable(
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetupFunctionList_Out.FTable.A_Columns, FSQMSQS_SetupFunctionList_Out.FTable.D_Columns),
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetupFunctionList_Out.FTable.A_Rows, FSQMSQS_SetupFunctionList_Out.FTable.D_Rows)
                        )
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInFun = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable requestSqlCodeList(
            FSqmCore fSqmCore,
            string system,
            string module,
            string function,
            ref int nextRowNumber
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSqc = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSqlCodeList_In.E_SQMSQS_SetSqlCodeList_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeList_In.A_hLanguage, FSQMSQS_SetSqlCodeList_In.D_hLanguage, fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeList_In.A_hStep, FSQMSQS_SetSqlCodeList_In.D_hStep, "1");
                // --
                fXmlNodeInSqc = fXmlNodeIn.set_elem(FSQMSQS_SetSqlCodeList_In.FSqlCode.E_SqlCode);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeList_In.FSqlCode.A_System, FSQMSQS_SetSqlCodeList_In.FSqlCode.D_System, system);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeList_In.FSqlCode.A_Module, FSQMSQS_SetSqlCodeList_In.FSqlCode.D_Module, module);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeList_In.FSqlCode.A_Function, FSQMSQS_SetSqlCodeList_In.FSqlCode.D_Function, function);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetFunctionList_In.FFunction.A_NextRowNumber, FSQMSQS_SetFunctionList_In.FFunction.D_NextRowNumber, nextRowNumber.ToString());

                // --

                FSQMSQSCaster.SQMSQS_SetSqlCodeList_Req(
                    fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSqlCodeList_Out.A_hStatus, FSQMSQS_SetSqlCodeList_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSqlCodeList_Out.A_hStatusMessage, FSQMSQS_SetSqlCodeList_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_SetupFunctionList_Out.FTable.E_Table);
                // --
                nextRowNumber = int.Parse(
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetupFunctionList_Out.FTable.A_NextRowNumber, FSQMSQS_SetupFunctionList_Out.FTable.D_NextRowNumber)
                    );

                return (
                    FDbWizard.stringToDataTable(
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetupFunctionList_Out.FTable.A_Columns, FSQMSQS_SetupFunctionList_Out.FTable.D_Columns),
                        fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetupFunctionList_Out.FTable.A_Rows, FSQMSQS_SetupFunctionList_Out.FTable.D_Rows)
                        )
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSqc = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode dataRowToSqlCodeNode(
            DataRow r
            )
        {
            FXmlNode fXmlNodeSqc = null;
            FXmlNode fXmlNodeMsq = null;
            FXmlNode fXmlNodeMsp = null;
            FXmlNode fXmlNodeOrq = null;
            FXmlNode fXmlNodeOrp = null;
            FXmlNode fXmlNodeMyq = null;
            FXmlNode fXmlNodeMyp = null;
            FXmlNode fXmlNodeMaq = null;
            FXmlNode fXmlNodeMap = null;
            FXmlNode fXmlNodePgq = null;
            FXmlNode fXmlNodePgp = null;
            string[] paraSeparator = { "," };

            try
            {
                fXmlNodeSqc = FCommon.createXmlNodeIn(FXmlTagSqlCode.E_SqlCode);
                fXmlNodeSqc.set_elemVal(FXmlTagSqlCode.A_UniqueId, FXmlTagSqlCode.D_UniqueId, r[0].ToString());
                fXmlNodeSqc.set_elemVal(FXmlTagSqlCode.A_SqlCode, FXmlTagSqlCode.D_SqlCode, r[1].ToString());
                fXmlNodeSqc.set_elemVal(FXmlTagSqlCode.A_Description, FXmlTagSqlCode.D_Description, r[2].ToString());
                fXmlNodeSqc.set_elemVal(FXmlTagSqlCode.A_UsedSqlMigration, FXmlTagSqlCode.D_UsedSqlMigration, r[3].ToString());

                // -- 

                fXmlNodeMsq = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodeMsq.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.MsSqlServer.ToString());
                fXmlNodeMsq.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, r[4].ToString());
                // --
                foreach (string p in r[5].ToString().Split(paraSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    fXmlNodeMsp = fXmlNodeMsq.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodeMsp.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, p);
                }

                // -- 

                fXmlNodeOrq = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodeOrq.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.Oracle.ToString());
                fXmlNodeOrq.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, r[6].ToString());
                // --
                foreach (string p in r[7].ToString().Split(paraSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    fXmlNodeOrp = fXmlNodeOrq.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodeOrp.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, p);
                }

                // -- 

                fXmlNodeMyq = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodeMyq.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.MySql.ToString());
                fXmlNodeMyq.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, r[8].ToString());
                // --
                foreach (string p in r[9].ToString().Split(paraSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    fXmlNodeMyp = fXmlNodeMyq.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodeMyp.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, p);
                }

                // -- 

                fXmlNodeMaq = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodeMaq.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.MariaDb.ToString());
                fXmlNodeMaq.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, r[10].ToString());
                // --
                foreach (string p in r[11].ToString().Split(paraSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    fXmlNodeMap = fXmlNodeMaq.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodeMap.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, p);
                }

                // -- 

                fXmlNodePgq = fXmlNodeSqc.add_elem(FXmlTagSqlQuery.E_SqlQuery);
                fXmlNodePgq.set_elemVal(FXmlTagSqlQuery.A_DbProvider, FXmlTagSqlQuery.D_DbProvider, FDbProvider.PostgreSql.ToString());
                fXmlNodePgq.set_elemVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery, r[12].ToString());
                // --
                foreach (string p in r[13].ToString().Split(paraSeparator, StringSplitOptions.RemoveEmptyEntries))
                {
                    fXmlNodePgp = fXmlNodePgq.add_elem(FXmlTagSqlParameter.E_SqlParameter);
                    fXmlNodePgp.set_elemVal(FXmlTagSqlParameter.A_SqlParameter, FXmlTagSqlParameter.D_SqlParameter, p);
                }

                // -- 

                return fXmlNodeSqc;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeSqc = null;
                fXmlNodeMsq = null;
                fXmlNodeMsp = null;
                fXmlNodeOrq = null;
                fXmlNodeOrp = null;
                fXmlNodeMyq = null;
                fXmlNodeMyp = null;
                fXmlNodeMaq = null;
                fXmlNodeMap = null;
                fXmlNodePgq = null;
                fXmlNodePgp = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable getSystemInfo(
            FSqmCore fSqmCore,
            string system
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSys = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;
            DataTable dt = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSystemSearch_In.E_SQMSQS_SetSystemSearch_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemSearch_In.A_hLanguage, FSQMSQS_SetSystemSearch_In.D_hLanguage, fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSystemSearch_In.A_hStep, FSQMSQS_SetSystemSearch_In.D_hStep, "1");
                // --
                fXmlNodeInSys = fXmlNodeIn.set_elem(FSQMSQS_SetSystemSearch_In.FSystem.E_System);
                fXmlNodeInSys.set_elemVal(FSQMSQS_SetSystemSearch_In.FSystem.A_System, FSQMSQS_SetSystemSearch_In.FSystem.D_System, system);

                // --

                FSQMSQSCaster.SQMSQS_SetSystemSearch_Req(
                    fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemSearch_Out.A_hStatus, FSQMSQS_SetSystemSearch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSystemSearch_Out.A_hStatusMessage, FSQMSQS_SetSystemSearch_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_SetSystemSearch_Out.FTable.E_Table);
                // --
                dt = FDbWizard.stringToDataTable(
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetSystemSearch_Out.FTable.A_Rows, FSQMSQS_SetSystemSearch_Out.FTable.D_Rows)
                    );

                // --

                return dt;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSys = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable getModuleInfo(
            FSqmCore fSqmCore,
            string system,
            string uniqueIdToString,
            string module
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInMod = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;
            DataTable dt = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetModuleSearch_In.E_SQMSQS_SetModuleSearch_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleSearch_In.A_hLanguage, FSQMSQS_SetModuleSearch_In.D_hLanguage, fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetModuleSearch_In.A_hStep, FSQMSQS_SetModuleSearch_In.D_hStep, "1");
                // --
                fXmlNodeInMod = fXmlNodeIn.set_elem(FSQMSQS_SetModuleSearch_In.FModule.E_Module);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleSearch_In.FModule.A_System, FSQMSQS_SetModuleSearch_In.FModule.D_System, system);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleSearch_In.FModule.A_UniqueId, FSQMSQS_SetModuleSearch_In.FModule.D_UniqueId, uniqueIdToString);
                fXmlNodeInMod.set_elemVal(FSQMSQS_SetModuleSearch_In.FModule.A_Module, FSQMSQS_SetModuleSearch_In.FModule.D_Module, module);

                // --

                FSQMSQSCaster.SQMSQS_SetModuleSearch_Req(
                    fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleSearch_Out.A_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetModuleSearch_Out.A_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_SetModuleSearch_Out.FTable.E_Table);
                // --
                dt = FDbWizard.stringToDataTable(
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetModuleSearch_Out.FTable.A_Columns, FSQMSQS_SetModuleSearch_Out.FTable.D_Columns),
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetModuleSearch_Out.FTable.A_Rows, FSQMSQS_SetModuleSearch_Out.FTable.D_Rows)
                    );

                // --

                return dt;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInMod = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable getFunctionInfo(
            FSqmCore fSqmCore,
            string system,
            string uniqueIdToString,
            string function
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInFun = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;
            DataTable dt = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetFunctionSearch_In.E_SQMSQS_SetFunctionSearch_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetFunctionSearch_In.A_hLanguage, FSQMSQS_SetFunctionSearch_In.D_hLanguage, fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetFunctionSearch_In.A_hStep, FSQMSQS_SetFunctionSearch_In.D_hStep, "1");
                // --
                fXmlNodeInFun = fXmlNodeIn.set_elem(FSQMSQS_SetFunctionSearch_In.FFunction.E_Function);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionSearch_In.FFunction.A_System, FSQMSQS_SetFunctionSearch_In.FFunction.D_System, system);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionSearch_In.FFunction.A_UniqueId, FSQMSQS_SetFunctionSearch_In.FFunction.D_UniqueId, uniqueIdToString);
                fXmlNodeInFun.set_elemVal(FSQMSQS_SetFunctionSearch_In.FFunction.A_Function, FSQMSQS_SetFunctionSearch_In.FFunction.D_Function, function);

                // --

                FSQMSQSCaster.SQMSQS_SetFunctionSearch_Req(
                    fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetFunctionSearch_Out.A_hStatus, FSQMSQS_SetFunctionSearch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetFunctionSearch_Out.A_hStatusMessage, FSQMSQS_SetFunctionSearch_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_SetFunctionSearch_Out.FTable.E_Table);
                // --
                dt = FDbWizard.stringToDataTable(
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetFunctionSearch_Out.FTable.A_Columns, FSQMSQS_SetFunctionSearch_Out.FTable.D_Columns),
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetFunctionSearch_Out.FTable.A_Rows, FSQMSQS_SetFunctionSearch_Out.FTable.D_Rows)
                    );

                // --

                return dt;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInFun = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable getSqlCodeInfo(
            FSqmCore fSqmCore,
            string system,
            string uniqueIdToString,
            string sqlCode
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeInSqc = null;
            FXmlNode fXmlNodeOut = null;
            FXmlNode fXmlNodeOutTbl = null;
            DataTable dt = null;

            try
            {
                fXmlNodeIn = FCommon.createXmlNodeIn(FSQMSQS_SetSqlCodeSearch_In.E_SQMSQS_SetSqlCodeSearch_In);
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeSearch_In.A_hLanguage, FSQMSQS_SetSqlCodeSearch_In.D_hLanguage, fSqmCore.fWsmOption.language.ToString());
                fXmlNodeIn.set_elemVal(FSQMSQS_SetSqlCodeSearch_In.A_hStep, FSQMSQS_SetSqlCodeSearch_In.D_hStep, "1");
                // --
                fXmlNodeInSqc = fXmlNodeIn.set_elem(FSQMSQS_SetSqlCodeSearch_In.FSqlCode.E_SqlCode);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeSearch_In.FSqlCode.A_System, FSQMSQS_SetSqlCodeSearch_In.FSqlCode.D_System, system);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeSearch_In.FSqlCode.A_UniqueId, FSQMSQS_SetSqlCodeSearch_In.FSqlCode.D_UniqueId, uniqueIdToString);
                fXmlNodeInSqc.set_elemVal(FSQMSQS_SetSqlCodeSearch_In.FSqlCode.A_SqlCode, FSQMSQS_SetSqlCodeSearch_In.FSqlCode.D_SqlCode, sqlCode);

                // --

                FSQMSQSCaster.SQMSQS_SetSqlCodeSearch_Req(
                    fSqmCore.fH101,
                    fXmlNodeIn,
                    ref fXmlNodeOut
                    );
                // --
                if (fXmlNodeOut.get_elemVal(FSQMSQS_SetSqlCodeSearch_Out.A_hStatus, FSQMSQS_SetSqlCodeSearch_Out.D_hStatus) != "0")
                {
                    FDebug.throwFException(fXmlNodeOut.get_elemVal(FSQMSQS_SetSqlCodeSearch_Out.A_hStatusMessage, FSQMSQS_SetSqlCodeSearch_Out.D_hStatusMessage));
                }

                // --

                fXmlNodeOutTbl = fXmlNodeOut.get_elem(FSQMSQS_SetSqlCodeSearch_Out.FTable.E_Table);
                // --
                dt = FDbWizard.stringToDataTable(
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetSqlCodeSearch_Out.FTable.A_Columns, FSQMSQS_SetSqlCodeSearch_Out.FTable.D_Columns),
                    fXmlNodeOutTbl.get_elemVal(FSQMSQS_SetSqlCodeSearch_Out.FTable.A_Rows, FSQMSQS_SetSqlCodeSearch_Out.FTable.D_Rows)
                    );

                // --

                return dt;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeInSqc = null;
                fXmlNodeOut = null;
                fXmlNodeOutTbl = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
