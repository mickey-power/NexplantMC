/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLicInfo.cs
--  Creator         : spike.lee
--  Create Date     : 2014.01.14
--  Description     : FAMate Core FaCommon License Information Class
--  History         : Created by spike.lee at 2014.01.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Principal;

namespace Nexplant.MC.Core.FaCommon
{
    public class FLicInfo : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        
        private string m_licenseId = string.Empty;
        private string m_productSerial = string.Empty;
        private string m_productDemo = string.Empty;
        private string m_productTitle = string.Empty;
        private string m_customerCompany = string.Empty;
        private string m_server = string.Empty;
        private string m_clickOnce = string.Empty;
        private string m_userLimit = string.Empty;
        // --
        private string m_expireIssuedCheck = string.Empty;
        private string m_expireIssuedDate = string.Empty;
        // --        
        private string m_macAddressCheck = string.Empty;
        private HashSet<string> m_macAddressList = null;
        // --
        private string m_key = string.Empty;
        private string m_rawData = string.Empty;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLicInfo(
            )
        {
            m_macAddressList = new HashSet<string>();            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLicInfo(
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
        
        public string licenseId
        {
            get
            {
                try
                {
                    return m_licenseId;
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

            internal set
            {
                try
                {
                    m_licenseId = value;
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

        public string productSerial
        {
            get
            {
                try
                {
                    return m_productSerial;
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

            internal set
            {
                try
                {
                    m_productSerial = value;
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

        public string productDemo
        {
            get
            {
                try
                {
                    return m_productDemo;
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

            internal set
            {
                try
                {
                    m_productDemo = value;
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

        public string productTitle
        {
            get
            {
                try
                {
                    return m_productTitle;
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

            internal set
            {
                try
                {
                    m_productTitle = value;
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

        public string customerCompany
        {
            get
            {
                try
                {
                    return m_customerCompany;
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

            internal set
            {
                try
                {
                    m_customerCompany = value;
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

        public string server
        {
            get
            {
                try
                {
                    return m_server;
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

            internal set
            {
                try
                {
                    m_server = value;
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

        public string clickOnce
        {
            get
            {
                try
                {
                    return m_clickOnce;
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

            internal set
            {
                try
                {
                    m_clickOnce = value;
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

        public string userLimit
        {
            get
            {
                try
                {
                    return m_userLimit;
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

            internal set
            {
                try
                {
                    m_userLimit = value;
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

        public string expireIssuedCheck
        {
            get
            {
                try
                {
                    return m_expireIssuedCheck;
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

            internal set
            {
                try
                {
                    m_expireIssuedCheck = value;
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
        
        public string expireIssuedDate
        {
            get
            {
                try
                {
                    return m_expireIssuedDate;
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

            internal set
            {
                try
                {
                    m_expireIssuedDate = value;
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

        public string macAddressCheck
        {
            get
            {
                try
                {
                    return m_macAddressCheck;
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

            internal set
            {
                try
                {
                    m_macAddressCheck = value;
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

        public HashSet<string> macAddressList
        {
            get
            {
                try
                {
                    return m_macAddressList;
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

        public string key
        {
            get
            {
                try
                {
                    return m_key;
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

            internal set
            {
                try
                {
                    m_key = value;
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

        public string rawData
        {
            get
            {
                try
                {
                    return m_rawData;
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

            internal set
            {
                try
                {
                    m_rawData = value;
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