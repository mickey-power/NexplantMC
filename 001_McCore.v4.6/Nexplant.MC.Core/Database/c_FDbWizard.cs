/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDbWizard.cs
--  Creator         : mj.kim
--  Create Date     : 2012.01.12
--  Description     : FAMate Core FaCommon Database FDbWizard Class
--  History         : Created by mj.kim at 2012.01.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Data;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FDbWizard : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const int MAX_LEN = 3145728;

        // --

        private const char ROW_SEPARATOR = (char)0x11;
        private const char COL_SEPARATOR = (char)0x12;

        // --

        private bool m_disposed = false;
        // --
        private FILicCore m_fLicCore = null;
        private string m_licenseFile = string.Empty;
        private string m_sqlCodeFileName = string.Empty;
        private string m_system = string.Empty;
        private FDbProvider m_fDbProvider = FDbProvider.MsSqlServer;
        private string m_connectString = string.Empty;
        // -- 
        private FXmlDocument m_fXmlDocSqlCode = null;
        private FXmlNode m_fXmlNodeSystem = null;
        private FLicChecker m_fLicChecker = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDbWizard(            
            string sqlCodeFileName,
            string system,
            FDbProvider fDbProvider
            )
        {
            m_sqlCodeFileName = sqlCodeFileName;
            m_system = system;
            m_fDbProvider = fDbProvider;
            // --
            init();
        }        

        //------------------------------------------------------------------------------------------------------------------------

        public FDbWizard(
            FILicCore fLicCore,
            string licFile,
            string sqlCodeFileName,
            string system,
            FDbProvider fDbProvider,
            string connectString
            )
        {
            m_fLicCore = fLicCore;
            m_licenseFile = licFile;
            m_sqlCodeFileName = sqlCodeFileName;
            m_system = system;
            m_fDbProvider = fDbProvider;
            m_connectString = connectString;
            // --
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDbWizard(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    term();
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

        public string sqlCodeFileName
        {
            get
            {
                try
                {
                    return m_sqlCodeFileName;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDbProvider fDbProvider
        {
            get
            {
                try
                {
                    return m_fDbProvider;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDbProvider.MsSqlServer;
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            string xpath = string.Empty;

            try
            {
                if (!string.IsNullOrWhiteSpace(m_licenseFile))
                {
                    m_fLicChecker = new FLicChecker(m_fLicCore, m_licenseFile, m_fDbProvider, m_connectString);
                }
                
                // --

                m_fXmlDocSqlCode = new FXmlDocument();
                m_fXmlDocSqlCode.preserveWhiteSpace = false;
                m_fXmlDocSqlCode.load(m_sqlCodeFileName);

                xpath =
                    FXmlTagFAMate.E_FAMate +
                    "/" + FXmlTagSystem.E_System + "[@" + FXmlTagSystem.A_System + "='" + m_system + "']";
                m_fXmlNodeSystem = m_fXmlDocSqlCode.selectSingleNode(xpath);
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

        private void term(
            )
        {
            try
            {
                if (m_fXmlNodeSystem != null)
                {
                    m_fXmlNodeSystem = null;
                }

                if (m_fXmlDocSqlCode != null)
                {
                    m_fXmlDocSqlCode.Dispose();
                    m_fXmlDocSqlCode = null;
                }

                if (m_fLicChecker != null)
                {
                    m_fLicChecker.Dispose();
                    m_fLicChecker = null;
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

        public FSql generateQuery(
            string module,
            string function,
            string sqlCode,
            string sqlName
            )
        {
            FSql fSql = null;
            FXmlNode fXmlNodeSql = null;
            string xpath = null;

            try
            {
                xpath = 
                    FXmlTagModule.E_Module + "[@" + FXmlTagModule.A_Module + "='" + module + "']" + 
                    "/" + FXmlTagFunction.E_Function + "[@" + FXmlTagFunction.A_Function + "='" + function + "']" +
                    "/" + FXmlTagSqlCode.E_SqlCode + "[@" + FXmlTagSqlCode.A_SqlCode + "='" + sqlCode + "']" +
                    "/" + FXmlTagSqlQuery.E_SqlQuery + "[@" + FXmlTagSqlQuery.A_DbProvider + "='" + (m_fDbProvider == FDbProvider.OracleEx ? FDbProvider.Oracle.ToString() : m_fDbProvider.ToString()) + "']";
                // --
                fXmlNodeSql = m_fXmlNodeSystem.selectSingleNode (xpath);

                // --

                if (fXmlNodeSql == null)
                {
                    FDebug.throwFException(
                        string.Format("Unexpected SQL Code! (System=<{0}>, Module=<{1}>, Function=<{2}>, SqlCode=<{3}>)", m_system, module, function, sqlCode)
                        );
                }

                // --

                if (sqlName == string.Empty)
                {
                    fSql = new FSql(m_system, module, function, sqlCode);
                }
                else
                {
                    fSql = new FSql(sqlName, m_system, module, function, sqlCode);
                }
                fSql.sql = fXmlNodeSql.get_attrVal(FXmlTagSqlQuery.A_SqlQuery, FXmlTagSqlQuery.D_SqlQuery);

                // --

                return fSql;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeSql = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSql generateQuery(
            string module,
            string function,
            string sqlCode
            )
        {
            try
            {
                 return generateQuery(module, function, sqlCode, string.Empty);
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

        public static string dataTableToColumnString(
            DataTable dt
            )
        {
            StringBuilder ret = null;

            try
            {
                ret = new StringBuilder();
                foreach (DataColumn dc in dt.Columns)
                {
                    ret.Append(dc.Caption);                    
                    ret.Append(COL_SEPARATOR);
                }                
                
                // --
                
                if (ret.Length > 0)
                {
                    ret.Remove(ret.Length - 1, 1);
                }
                return ret.ToString();
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

        //------------------------------------------------------------------------------------------------------------------------

        public static string dataTableToRowString(
            DataTable dt,          
            ref int rowCount,
            ref int nextRowNumber
            )
        {
            try
            {
                return dataTableToRowString(dt, ref rowCount, ref nextRowNumber, true);
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

        //------------------------------------------------------------------------------------------------------------------------

        public static string dataTableToRowString(
            DataTable dt,          
            ref int rowCount,
            ref int nextRowNumber,
            bool isTrim
            )
        {
            StringBuilder col = null;
            StringBuilder ret = null;
            int retNextRowNumber = 0;

            try
            {
                col = new StringBuilder();
                ret = new StringBuilder();                
                rowCount = 0;
                retNextRowNumber = -1;

                // --
                
                for (int i = nextRowNumber; i < dt.Rows.Count; i++)
                {
                    col.Clear();

                    // --

                    if (isTrim)
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            col.Append(dt.Rows[i][j].ToString().Trim());
                            col.Append(COL_SEPARATOR);                        
                        }
                    }
                    else
                    {
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            col.Append(dt.Rows[i][j].ToString());
                            col.Append(COL_SEPARATOR);                        
                        }
                    }
                    
                    // --
                    
                    if (col.Length > 0)
                    {
                        col.Remove(col.Length - 1, 1);
                    }

                    // --

                    if (ret.Length + col.Length > MAX_LEN)
                    {
                        retNextRowNumber = i;
                        break;
                    }

                    // --

                    ret.Append(col.ToString());
                    ret.Append(ROW_SEPARATOR);

                    // --

                    rowCount++;
                }

                // --

                nextRowNumber = retNextRowNumber;
                if (ret.Length > 0)
                {
                    ret.Remove(ret.Length - 1, 1);
                }                
                return ret.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                col = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static DataTable stringToDataTable(
            string columns,
            string rows
            )
        {
            DataTable dt = null;
            
            string[] rowArray = null;
            string[] colArray = null;

            try
            {
                dt = new DataTable();

                // --

                colArray = columns.Split(COL_SEPARATOR);
                foreach (string c in colArray)
                {
                    dt.Columns.Add(c);
                }

                // --

                rowArray = rows.Split(new char[] { ROW_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);                
                foreach (string r in rowArray)
                {
                    dt.Rows.Add(r.Split(COL_SEPARATOR));
                }

                // --

                return dt;
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

        public static DataTable stringToDataTable(
            string rows
            )
        {
            DataTable dt = null;
            string[] rowArray = null;
            string[] colArray = null;

            try
            {
                dt = new DataTable();

                // --

                rowArray = rows.Split(new char[] { ROW_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);                
                if (rowArray.Length == 0)
                {
                    return dt;
                }
                
                // --

                colArray = rowArray[0].Split(COL_SEPARATOR);
                for (int i = 0; i < colArray.Length; i++)
                {
                    dt.Columns.Add(i.ToString());
                }
                
                // --

                foreach (string r in rowArray)
                {
                    dt.Rows.Add(r.Split(COL_SEPARATOR));
                }

                // --

                return dt;
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

    }   // Class end
}   // Namespace end