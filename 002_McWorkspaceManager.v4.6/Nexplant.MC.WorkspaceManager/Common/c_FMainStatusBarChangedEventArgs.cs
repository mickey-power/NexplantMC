/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMainStatusBarChangedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.30
--  Description     : FAMate Workspace Manager Main Status Bar Changed Event Arguments Class 
--  History         : Created by spike.lee at 2010.12.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.WorkspaceManager
{
    [Serializable]
    public class FMainStatusBarChangedEventArgs : EventArgs, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private bool m_enabled = false;
        private string m_contents = string.Empty;
        private string m_factory = string.Empty;
        private string m_userGroup = string.Empty;
        private string m_user = string.Empty;
        private string m_version = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMainStatusBarChangedEventArgs(                        
            bool enabled,
            string contents,
            string factory,
            string userGroup,
            string user,
            string version
            )
        {
            m_enabled = enabled;
            m_contents = contents;
            m_factory = factory;
            m_userGroup = userGroup;
            m_user = user;
            m_version = version;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FMainStatusBarChangedEventArgs(
            bool enabled
            )
        {
            m_enabled = enabled;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMainStatusBarChangedEventArgs(
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

        public bool enabled
        {
            get
            {
                try
                {
                    return m_enabled;
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string contents
        {
            get
            {
                try
                {
                    return m_contents;
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

        public string factory
        {
            get
            {
                try
                {
                    return m_factory;
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

        public string userGroup
        {
            get
            {
                try
                {
                    return m_userGroup;
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

        public string user
        {
            get
            {
                try
                {
                    return m_user;
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

        public string version
        {
            get
            {
                try
                {
                    return m_version;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
