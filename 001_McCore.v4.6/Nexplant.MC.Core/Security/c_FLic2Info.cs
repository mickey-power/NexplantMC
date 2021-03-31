/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLic2Info.cs
--  Creator         : spike.lee
--  Create Date     : 2017.08.28
--  Description     : FAmate Core FaCommon Lic2 Info Class
--  History         : Created by spike.lee at 2017.08.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.IO;
using System.Security.Principal;

namespace Nexplant.MC.Core.FaCommon
{
    public class FLic2Info : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_licenseId = string.Empty;
        private string m_customerCompany = string.Empty;
        private string m_customerSite = string.Empty;
        private string m_productTitle = string.Empty;
        private string m_productVersion = string.Empty;
        //
        private FLic2Common m_fLicSecs = null;
        private FLic2Common m_fLicOpc = null;
        private FLic2Common m_fLicTcp = null;
        private FLic2Common m_fLicAdm = null;
        private FLic2AdminService m_fLicAds = null;
        private FLic2Common m_fLicS2hCvt = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLic2Info(
            )
        {
            m_fLicSecs = new FLic2Common();
            m_fLicOpc = new FLic2Common();
            m_fLicTcp = new FLic2Common();
            m_fLicAdm = new FLic2Common();
            m_fLicAds = new FLic2AdminService();
            m_fLicS2hCvt = new FLic2Common();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLic2Info(
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
                    m_fLicSecs = null;
                    m_fLicOpc = null;
                    m_fLicTcp = null;
                    m_fLicAdm = null;
                    m_fLicAds = null;
                    m_fLicS2hCvt = null;
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

        public string customerSite
        {
            get
            {
                try
                {
                    return m_customerSite;
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
                    m_customerSite = value;
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

        public string productVersion
        {
            get
            {
                try
                {
                    return m_productVersion;
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
                    m_productVersion = value;
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

        public FLic2Common fLicSecs
        {
            get
            {
                try
                {
                    return m_fLicSecs;
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

        public FLic2Common fLicOpc
        {
            get
            {
                try
                {
                    return m_fLicOpc;
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

        public FLic2Common fLicTcp
        {
            get
            {
                try
                {
                    return m_fLicTcp;
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

        public FLic2Common fLicAdm
        {
            get
            {
                try
                {
                    return m_fLicAdm;
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

        public FLic2AdminService fLicAds
        {
            get
            {
                try
                {
                    return m_fLicAds;
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

        public FLic2Common fLicS2hCvt
        {
            get
            {
                try
                {
                    return m_fLicS2hCvt;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end    
}   // Namespace end