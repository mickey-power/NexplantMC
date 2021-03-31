/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProcParameterCollection.cs
--  Creator         : byjeon
--  Create Date     : 2014.08.12
--  Description     : FAMate Core FaCommon Database ProcParameterCollection class
--  History         : Created by byjeon at 2014.08.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Data;

namespace Nexplant.MC.Core.FaCommon
{
    public class FProcParameterCollection :IDisposable, IEnumerable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private Dictionary<string, FProcParameter> m_fParameterDict = null;
        private List<FProcParameter> m_fParameterList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FProcParameterCollection(
            )
        {
            m_fParameterDict = new Dictionary<string, FProcParameter>();
            m_fParameterList = new List<FProcParameter>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FProcParameterCollection(
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
                    m_fParameterDict = null;
                    m_fParameterList = null;
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

        #region Properties

        public IEnumerator GetEnumerator(
            )
        {
            try
            {
                return new FProcParameterCollectionEnumerator(this);
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

        public int count
        {
            get
            {
                try
                {
                    return m_fParameterList.Count;
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

        public FProcParameter this[int i]
        {
            get
            {
                try
                {
                    if (i < 0 || i >= m_fParameterList.Count)
                    {
                        return null;
                    }
                    return m_fParameterList[i];
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

        public FProcParameter this[string name]
        {
            get
            {
                try
                {
                    if (!m_fParameterDict.ContainsKey(name))
                    {
                        return null;
                    }
                    return m_fParameterDict[name];
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

        public FProcParameter add(
            string name,
            object value,
            string aliasName = ""
            )
        {
            try
            {
                return add(name, FDbType.NVarChar, 0, value, ParameterDirection.Input, aliasName);
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

        public FProcParameter add(
            string name,
            FDbType fDbType,
            ParameterDirection direction,
            string aliasName = ""
            )
        {
            try
            {
                return add(name, fDbType, 0, null, direction, aliasName);
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
        
        public FProcParameter add(
            string name,
            FDbType fDbType,
            int size,
            ParameterDirection direction,
            string aliasName = ""
            )
        {
            try
            {
                return add(name, fDbType, size, null, direction, aliasName);
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

        public FProcParameter add(
           string name,
           FDbType fDbType,
           object value,
           ParameterDirection direction,
           string aliasName = ""
           )
        {
            try
            {
                return add(name, fDbType, 0, value, direction, aliasName);
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

        public FProcParameter add(
            string name,
            FDbType fDbType,
            int size,
            object value,
            ParameterDirection direction,
            string aliasName = ""
            )
        {
            try
            {
                if (contains(name))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "Parameter Name"));
                }

                // -- 

                using (FProcParameter fParameter = new FProcParameter(name, fDbType, size, value, direction, aliasName))
                {
                    m_fParameterDict.Add(name, fParameter);
                    m_fParameterList.Add(fParameter);
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

        public FProcParameter add(
            FProcParameter fParameter
            )
        {
            try
            {
                if (contains(fParameter.name))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "Parameter Name"));
                }

                // -- 

                m_fParameterDict.Add(fParameter.name, fParameter);
                m_fParameterList.Add(fParameter);
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

        public FProcParameter insert(
            int index, 
            FProcParameter fParameter
            )
        {
            try
            {
                if (contains(fParameter.name))
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0004, "Parameter Name"));
                }

                // -- 

                m_fParameterDict.Add(fParameter.name, fParameter);
                m_fParameterList.Insert(index, fParameter);
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

        public void clear(
            )
        {
            try
            {
                m_fParameterDict.Clear();
                m_fParameterList.Clear();
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

        public int indexOf(
            string name
            )
        {
            int index = -1;

            try
            {
                if(!contains(name))
                {
                    return -1;
                }

                // --

                for (int i = 0; i < m_fParameterList.Count; i++)
                {
                    if (name.Equals(m_fParameterList[i].name))
                    {
                        index = i;
                        break;
                    }
                }
                return index;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return -1;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool contains(
            string name
            )
        {
            try
            {
                return m_fParameterDict.ContainsKey(name);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAt(
            int index
            )
        {
            FProcParameter fParameter = null;

            try
            {
                fParameter = this[index];
                if (fParameter != null)
                {
                    m_fParameterDict.Remove(this[index].name);
                    m_fParameterList.RemoveAt(index);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fParameter = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void removeAt(
            string name
            )
        {
            int index = 0;

            try
            {
                index = indexOf(name);
                if (index >= 0)
                {
                    removeAt(index);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // Class end
} // Namespace end 
