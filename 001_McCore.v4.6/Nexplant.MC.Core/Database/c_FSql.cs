/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSql.cs
--  Creator         : kitae
--  Create Date     : 2011.02.28
--  Description     : FAMate Core FaCommon Database FSql Class
--  History         : Created by kitae at 2011.02.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nexplant.MC.Core.FaCommon
{
    public class FSql : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        private string m_name = Guid.NewGuid().ToString(); // Default Name(Key)
        private string m_system = string.Empty;
        private string m_module = string.Empty;
        private string m_function = string.Empty;
        private string m_sqlCode = string.Empty;
        private string m_sql = string.Empty;
        private string m_sqlEx = string.Empty;  // Cleanup Sql        
        private Dictionary<string, FSqlParameter> m_sqlParameterDict = null;
        private List<FSqlParameter> m_sqlParameterList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSql(
            )
        {
            m_sqlParameterDict = new Dictionary<string, FSqlParameter>();
            m_sqlParameterList = new List<FSqlParameter>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSql(
            string name
            )
            :this()
        {
            m_name = name;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public FSql(
            string name,
            string sql
            )
            :this(name)
        {
            m_sql = sql;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSql(
            string system, 
            string module, 
            string function, 
            string sqlCode
            )            
            : this()
        {
            m_system = system;
            m_module = module;
            m_function = function;
            m_sqlCode = sqlCode;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSql(
            string name,
            string system,
            string module,
            string function,
            string sqlCode
            )
            : this(system, module, function, sqlCode)
        {
            m_name = name;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSql(
            )
        {
            myDispose(false);            
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if(!m_disposed)
            {
                if(disposing)
                {
                    m_sqlParameterDict = null;
                    m_sqlParameterList = null;
                }
            }
            m_disposed = true;

        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 맴버
        
        public void Dispose(
            )
        {           
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string name
        {
            get
            {
                try
                {
                    return m_name;
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

        public string system
        {
            get
            {
                try
                {
                    return m_system;
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

        public string module
        {
            get
            {
                try
                {
                    return m_module;
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

        public string function
        {
            get
            {
                try
                {
                    return m_function;
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

        public string sqlCode
        {
            get
            {
                try
                {
                    return m_sqlCode;
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

        public string sql
        {
            get
            {
                try
                {
                    return m_sql;
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
                    m_sql = value;

                    // --

                    cleanSqlStatement();
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

        public string sqlEx
        {
            get
            {
                try
                {
                    return m_sqlEx;
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

        public FSqlParameterCollection sqlParameterCollection
        {
            get
            {
                try
                {
                    return new FSqlParameterCollection(m_sqlParameterDict, m_sqlParameterList);
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

        protected List<FSqlParameter> sqlParameterList
        {
            get
            {
                try
                {
                    return m_sqlParameterList;
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

        public void appendSqlParameter(
            FSqlParameter sqlParameter
            )
        {
            try
            {
                if(m_sqlParameterDict.ContainsKey(sqlParameter.name))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004,"same SQL Parameter"));
                }
                m_sqlParameterDict.Add(sqlParameter.name, sqlParameter);
                m_sqlParameterList.Add(sqlParameter);
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

        public void appendSqlParameter(
            string name
            )
        {
            FSqlParameter sqlPar = null;

            try
            {
                if (m_sqlParameterDict.ContainsKey(name))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "same SQL Parameter"));
                }
                sqlPar = new FSqlParameter(name);
                m_sqlParameterDict.Add(sqlPar.name, sqlPar);
                m_sqlParameterList.Add(sqlPar);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                sqlPar = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void appendSqlParameter(
            string name,
            object value
            )
        {
            FSqlParameter sqlPar = null;
            
            try
            {
                if(m_sqlParameterDict.ContainsKey(name))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004,"same SQL Parameter"));
                }
                sqlPar = new FSqlParameter(name, value);
                m_sqlParameterDict.Add(sqlPar.name, sqlPar);
                m_sqlParameterList.Add(sqlPar);
            }
            catch (Exception ex)
            {
            	FDebug.throwException(ex);
            }
            finally
            {
                sqlPar = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqlParameter removeSqlParameter(
            FSqlParameter sqlParameter
            )
        {
            try
            {
                if(!m_sqlParameterDict.ContainsValue(sqlParameter))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "SQL Parameter"));
                }
                m_sqlParameterDict.Remove(sqlParameter.name);
                m_sqlParameterList.Remove(sqlParameter);
                return sqlParameter;
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

        private void cleanSqlStatement(
            )
        {
            const string PATTERN_TEXT_BLOCK = @"('(''|[^'])*')";            // Pattern Text Block
            const string PATTERN_BREAK_TAB = @"(\t|\r?\n)";                 // Pattern Tab, Carriage Return, Line Feed
            const string PATTERN_SINGLE_COMMENT = @"(--[^\r\n]*)";          // Pattern Sing Row Comment
            const string PATTERN_MULTIPLE_COMMENT = @"(/\*[^\+].*?\*/)";    // Pattern Multi Row Comment            
            const string PATTERN_ORACLE_HINT = @"(/\*\+.*?\*/)";            // Pattern Oracle Hint
            const string PATTERN_MULTIPLE_SPACE = @"'([^']|'')*'|[ ]{2,}";  // Pattern Multiple Space (Not Include Text Block)

            // --

            MatchCollection matches = null;
            string pattern1 = string.Empty;
            string pattern2 = string.Empty;
            
            try
            {
                m_sqlEx = this.sql;

                // --
                
                // ***
                // Find TextBlock, Tab, CarriageReturn, LineFeed, SingRow & MultipleRow Comment
                // ***
                pattern1 = string.Join("|", PATTERN_TEXT_BLOCK, PATTERN_BREAK_TAB, PATTERN_SINGLE_COMMENT, PATTERN_MULTIPLE_COMMENT);

                // --

                matches = Regex.Matches(m_sqlEx, pattern1, RegexOptions.IgnoreCase | RegexOptions.Multiline);
#if(DEBUG)
                // ***
                // Pattern1 Match 결과 출력 시 사용 (속도 저하로 Debug 필요 시 사용 요망)
                // ***
                //debugMatchList("Pattern1 Matching String List", matches);
#endif
                for (int i = matches.Count - 1; i >= 0; i--)
                {
                    // ***
                    // Tab, CarriageReturn, LineFeed, SingRow & MultiRow Commnet를 Space로 변환. (Text 영역 제외)
                    // ***
                    if (!matches[i].Value.StartsWith("'") && !matches[i].Value.EndsWith("'"))
                    {
                        m_sqlEx = string.Join(" ", m_sqlEx.Substring(0, matches[i].Index), m_sqlEx.Substring(matches[i].Index + matches[i].Length));
                    }
                }

                // --

                // ***
                // Find Multi Space | Except Oracle Hint
                // ***
                pattern2 = string.Join("|", PATTERN_ORACLE_HINT, PATTERN_MULTIPLE_SPACE);

                // --

                matches = Regex.Matches(m_sqlEx, pattern2, RegexOptions.IgnoreCase | RegexOptions.Multiline);

                // --

#if(DEBUG)
                // ***
                // Pattern2 Match 결과 출력 시 사용 (속도 저하로 Debug 필요 시 사용 요망)
                // ***
                //debugMatchList("Pattern2 Matching String List", matches);    
#endif
                for (int i = matches.Count - 1; i >= 0; i--)
                {
                    // ***
                    // 복수 Space를 단일 Space로 변환. (Text 영역 제외)
                    // ***
                    if (!matches[i].Value.StartsWith("'") && !matches[i].Value.EndsWith("'"))
                    {
                        if (Regex.IsMatch(matches[i].Value, PATTERN_ORACLE_HINT, RegexOptions.IgnoreCase | RegexOptions.Multiline))
                        {
                            continue;
                        }
                        else if (Regex.IsMatch(matches[i].Value, PATTERN_MULTIPLE_SPACE, RegexOptions.IgnoreCase | RegexOptions.Multiline))
                        {
                            m_sqlEx = string.Join(" ", m_sqlEx.Substring(0, matches[i].Index), m_sqlEx.Substring(matches[i].Index + matches[i].Length));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                matches = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        #if(DEBUG)
        
        private void debugMatchList(
            string title,
            MatchCollection matches
            )
        {
            System.Diagnostics.Debug.WriteLine(string.Format("<{0}>", title));
            for (int i = 0; i < matches.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(string.Format("\tLIST[{0}] = {1}", i, ((matches[i].Value.Replace("  ", "[blank]")).Replace("\r", "\\r")).Replace("\n", "\\n")));
            }
        }

        #endif

        #endregion

        //------------------------------------------------------------------------------------------------------------------------
     
    } // Class end    
} // Namespace end