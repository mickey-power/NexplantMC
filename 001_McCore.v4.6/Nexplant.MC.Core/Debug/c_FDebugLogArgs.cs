/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDebugLogArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2010.11.25
--  Description     : FAMate Core FaCommon Debug Log Arguments (Log Information) Class
--  History         : Created by spike.lee at 2010.11.25
                    : Modified by spike.lee at 2011.09.21
                        - 생성자 추가
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FDebugLogArgs : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FDebugLogCategory m_category = FDebugLogCategory.Information;
        private string m_action = string.Empty;
        private string m_typeNamespace = string.Empty;
        private string m_typeName = string.Empty;
        private string m_functionName = string.Empty;
        private string m_additionInfo = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDebugLogArgs(
            )
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDebugLogArgs(
            FDebugLogCategory fCategory,
            string action,
            string typeNamespace,
            string typeName,
            string funcationName
            )
        {
            m_category = fCategory;
            m_action = action;
            m_typeNamespace = typeNamespace;
            m_typeName = typeName;
            m_functionName = funcationName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FDebugLogArgs(
            FDebugLogCategory fCategory,
            string action,
            Type type,
            string functionName
            )
        {
            m_category = fCategory;
            m_action = action;
            m_typeNamespace = type.Namespace;
            m_typeName = type.Name;
            m_functionName = functionName;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDebugLogArgs(
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

        public FDebugLogCategory fCategory
        {
            get
            {
                try
                {
                    return m_category;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDebugLogCategory.Information;
            }

            set
            {
                try
                {
                    m_category = value;
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

        public string action
        {
            get
            {
                try
                {
                    return m_action;
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
                    m_action = value;
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

        public string typeNamespace
        {
            get
            {
                try
                {
                    return m_typeNamespace;
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
                    m_typeNamespace = value;
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

        public string typeName
        {
            get
            {
                try
                {
                    return m_typeName;
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
                    m_typeName = value;
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

        public string functionName
        {
            get
            {
                try
                {
                    return m_functionName;
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
                    m_functionName = value;
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

        public string additionInfo
        {
            get
            {
                try
                {
                    return m_additionInfo;
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
                    m_additionInfo = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
