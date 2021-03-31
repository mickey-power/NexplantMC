/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseExecutor.cs
--  Creator         : kitae
--  Create Date     : 2011.02.28
--  Description     : FAMate Core FaCommon Database FSqlCollection Class
--  History         : Created by kitae at 2011.02.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
   public abstract class FBaseExecutor : IDisposable
    {
       //------------------------------------------------------------------------------------------------------------------------
               
       private bool m_disposed = false;
       private string m_connectionString = string.Empty;
       private int m_timeout = 30; // sec
       private Dictionary<string, FSql> m_sqlDict = null;
       private List<FSql> m_sqlList = null;     

       //------------------------------------------------------------------------------------------------------------------------
       
       #region Class Construction and Destruction
       
       internal FBaseExecutor(
           )
       {
           m_sqlDict = new Dictionary<string, FSql>();
           m_sqlList = new List<FSql>();         
       }
       
       //------------------------------------------------------------------------------------------------------------------------
       
       internal FBaseExecutor(
           string connectionString           
           )
           :this()
       {           
           m_connectionString = connectionString;
       }
       
       //------------------------------------------------------------------------------------------------------------------------

       ~FBaseExecutor(
           )
       {            
           myDispose(false);                  
       }

       //------------------------------------------------------------------------------------------------------------------------

       protected virtual void myDispose(
           bool disposing
           )
       { 
           if (!m_disposed)
           {
               if (disposing)
               {                   
                   m_sqlDict = null;
                   m_sqlList = null;                   
               }                
           }
           m_disposed = true;          
       }

       #endregion

       //------------------------------------------------------------------------------------------------------------------------

       #region IDisposable

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion 

       //------------------------------------------------------------------------------------------------------------------------

       #region Propertioes

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

        public int sqlCount
        {
            get
            {
                try
                {
                    return m_sqlList.Count;
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
                return 0;
            }

            set
            {
                try
                {
                    m_timeout = value;
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

        public FSqlCollection sqlCollection
        {
            get
            {
                try
                {
                    return new FSqlCollection(m_sqlDict, m_sqlList);
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

        protected List<FSql> sqlList
        {
            get
            {
                try
                {
                    return m_sqlList;
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
       
        public void appendSql(
            FSql sql
            )
        {
            try
            {
                if (m_sqlDict.ContainsKey((sql.name)))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "same SQL"));
                }
                m_sqlDict.Add(sql.name, sql);
                m_sqlList.Add(sql);
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

        public FSql removeSql(
            FSql sql
            )
        {
            try
            {
                if (!m_sqlDict.ContainsValue(sql))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "SQL"));
                }
                m_sqlDict.Remove(sql.name);
                m_sqlList.Remove(sql);
                return sql;
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

        public FSql removeSql(
            int index
            )
        {
            try
            {
                if (index < 0 || index >= m_sqlList.Count)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "Index"));
                }
                return removeSql(m_sqlList[index]);
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

        public FSql removeSql(
            string name
            )
        {
            try
            {
                if (!m_sqlDict.ContainsKey(name))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0003, "SQL"));
                }
                return removeSql(m_sqlDict[name]);
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

        public void clearSql(
            )
        {
            try
            {
                m_sqlDict.Clear();
                m_sqlList.Clear();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }
  
        #endregion

       //------------------------------------------------------------------------------------------------------------------------
       
    }// Class end
}// Namespace end
