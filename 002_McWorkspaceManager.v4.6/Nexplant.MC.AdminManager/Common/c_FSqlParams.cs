/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSqlParams.cs
--  Creator         : spike.lee
--  Create Date     : 2012.06.29
--  Description     : FAMate Admin Manager SQL Parameters Class 
--  History         : Created by spike.lee at 2012.06.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.AdminManager
{
    public class FSqlParams : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private Dictionary<string, FSqlParam> m_fParamDict = null;
        private List<FSqlParam> m_fParamList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSqlParams(
            )
        {
            m_fParamDict = new Dictionary<string, FSqlParam>();
            m_fParamList = new List<FSqlParam>();           
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSqlParams(
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
                    m_fParamDict = null;
                    m_fParamList = null;
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

        public int count
        {
            get
            {
                try
                {
                    return m_fParamList.Count;
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

        public FSqlParam this[int i]
        {
            get
            {
                try
                {
                    return m_fParamList[i];
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

        public FSqlParam this[string name]
        {
            get
            {
                try
                {
                    return m_fParamDict[name];
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

        public void add(
            FSqlParam fSqlParam
            )
        {
            try
            {
                m_fParamDict.Add(fSqlParam.name, fSqlParam);
                m_fParamList.Add(fSqlParam);
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

        public FSqlParam add(
            string name, 
            string value, 
            bool isNullValue
            )
        {
            FSqlParam fSqlParam = null;

            try
            {
                fSqlParam = new FSqlParam(name, value, isNullValue);
                m_fParamDict.Add(name, fSqlParam);
                m_fParamList.Add(fSqlParam);
                // --
                return fSqlParam;
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

        public FSqlParam add(
            string name, 
            string value
            )
        {
            FSqlParam fSqlParam = null;

            try
            {
                fSqlParam = new FSqlParam(name, value);
                m_fParamDict.Add(name, fSqlParam);
                m_fParamList.Add(fSqlParam);
                // --
                return fSqlParam;
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

        public FSqlParam add(
            string name,
            bool isNullValue
            )
        {
            FSqlParam fSqlParam = null;

            try
            {
                fSqlParam = new FSqlParam(name, isNullValue);
                m_fParamDict.Add(name, fSqlParam);
                m_fParamList.Add(fSqlParam);
                // --
                return fSqlParam;
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
                m_fParamDict.Clear();
                m_fParamList.Clear();
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

        public bool contains(
            string name
            )
        {
            try
            {
                return m_fParamDict.ContainsKey(name);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
