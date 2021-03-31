/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FUserAuthorityData.cs
--  Creator         : mjkim
--  Create Date     : 2013.02.05
--  Description     : FAMate Admin Manager User Group Authority Data Class 
--  History         : Created by mjkim at 2013.02.05
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaUIs;
using System.IO;

namespace Nexplant.MC.AdminManager
{
    public class FUserAuthorityData : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FAdmCore m_fAdmCore = null;

        private FYesNo m_allAuthority = FYesNo.No;
        private Dictionary<string, FUserFunctionData> m_funDict = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FUserAuthorityData(
            FAdmCore fAdmCore
            )
        {
            m_fAdmCore = fAdmCore;
            // --
            m_funDict = new Dictionary<string, FUserFunctionData>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FUserAuthorityData(
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
                    m_funDict = new Dictionary<string, FUserFunctionData>();
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

        public FYesNo allAuthority
        {
            get
            {
                try
                {
                    return m_allAuthority;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FYesNo.No;
            }

            set
            {
                try
                {
                    m_allAuthority = value;
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

        public void add(
            FUserFunctionData fData 
            )
        {
            try
            {
                m_funDict.Add(fData.function, fData);
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

        public void clear(
            )
        {
            try
            {
                m_funDict.Clear();
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

        public bool hasFunctionAuthority(
            string key
            )
        {
            try
            {
                if (m_allAuthority == FYesNo.Yes)
                {
                    return true;
                }
                
                // --

                return m_funDict.ContainsKey(key);
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

        public bool hasTransactionAuthority(
            string key
            )
        {
            try
            {
                if (m_allAuthority == FYesNo.Yes)
                {
                    return true;
                }

                // --

                if (!m_funDict.ContainsKey(key))
                {
                    return false;
                }

                // --

                return m_funDict[key].enabledTransaction;
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
