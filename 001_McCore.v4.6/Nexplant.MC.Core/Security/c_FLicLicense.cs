/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLicLicense.cs
--  Creator         : spike.lee
--  Create Date     : 2014.01.14
--  Description     : FAMate Core FaCommon Lic License Class
--  History         : Created by spike.lee at 2014.01.14
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
    public class FLicLicense : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string LicenseId = "license.id";
        private const string ProductSerial = "product.serial";
        private const string ProductDemo = "product.demo";        
        private const string ProductTitle = "product.title";
        private const string CustomerCompany = "customer.company";
        private const string Server = "server";
        private const string ClickOnce = "click.once";
        private const string UserLimit = "user.limit";
        private const string ExpireIssuedCheck = "expire.issued.check";
        private const string ExpireIssuedDate = "expire.issued.date";        
        private const string MacAddressCheck = "mac.address.check";
        private const string MacAddress = "mac.address";
        private const string Key = "key";
        // --
        private const char Separator = '=';
        
        // --

        private bool m_disposed = false;
        // --
        private FLicInfo m_fLicInfo = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLicLicense(
            )
        {
            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLicLicense(
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

        public FLicInfo fLicInfo
        {
            get
            {
                try
                {
                    return m_fLicInfo;
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

        public void validate(
            string fileName
            )
        {
            StreamReader sr = null;            
            string licData = null;
            string[] vals = null;
            int index = 0;            
            bool isValid = false;

            try
            {
                // ***
                // License File이 존재하는지 검사
                // ***
                if (!File.Exists(fileName))
                {
                    FDebug.throwFException(FConstants.err_m_0018);
                }
                
                // --

                m_fLicInfo = new FLicInfo();

                // --

                sr = new StreamReader(fileName, Encoding.Default);
                licData = sr.ReadToEnd();
                
                // --

                index = licData.IndexOf(Key);
                if (index == -1)
                {
                    FDebug.throwFException(FConstants.err_m_0022);
                }
                m_fLicInfo.rawData = licData.Substring(0, index);
                m_fLicInfo.rawData = m_fLicInfo.rawData.Replace("\n", "");
                m_fLicInfo.rawData = m_fLicInfo.rawData.Replace("\r", "");
               
                // --

                foreach (string s in licData.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (s[0] == '#')
                    {
                        continue;
                    }

                    // --

                    vals = s.Split(new char[] { Separator });
                    if (vals.Length != 2)
                    {
                        FDebug.throwFException(FConstants.err_m_0022);
                    }

                    if (vals[0] == LicenseId)
                    {
                        m_fLicInfo.licenseId = vals[1];
                    }
                    else if (vals[0] == ProductSerial)
                    {
                        m_fLicInfo.productSerial = vals[1];
                    }
                    else if (vals[0] == ProductDemo)
                    {
                        m_fLicInfo.productDemo = vals[1];
                    }
                    else if (vals[0] == ProductTitle)
                    {
                        m_fLicInfo.productTitle = vals[1];
                    }
                    else if (vals[0] == CustomerCompany)
                    {
                        m_fLicInfo.customerCompany = vals[1];
                    }
                    else if (vals[0] == Server)
                    {
                        m_fLicInfo.server = vals[1];
                    }
                    else if (vals[0] == ClickOnce)
                    {
                        m_fLicInfo.clickOnce = vals[1];
                    }
                    else if (vals[0] == UserLimit)
                    {
                        m_fLicInfo.userLimit = vals[1];
                    }
                    else if (vals[0] == ExpireIssuedCheck)
                    {
                        m_fLicInfo.expireIssuedCheck = vals[1];
                    }
                    else if (vals[0] == ExpireIssuedDate)
                    {
                        m_fLicInfo.expireIssuedDate = vals[1];
                    }
                    else if (vals[0] == MacAddressCheck)
                    {
                        m_fLicInfo.macAddressCheck = vals[1];
                    }
                    else if (vals[0] == MacAddress)
                    {
                        if (!m_fLicInfo.macAddressList.Contains(vals[1]))
                        {
                            m_fLicInfo.macAddressList.Add(vals[1]);
                        }
                    }
                    else if (vals[0] == Key)
                    {
                        m_fLicInfo.key = vals[1];
                    }
                }                

                // --

                // ***
                // License Key Validation
                // ***
                if (m_fLicInfo.key != (new FCrypt()).encrypt2(m_fLicInfo.rawData))
                {
                    FDebug.throwFException(FConstants.err_m_0022);
                }

                // ***
                // License Item Validation
                // ***
                if (
                    m_fLicInfo.server.Trim() == string.Empty || 
                    m_fLicInfo.expireIssuedCheck.Trim() == string.Empty ||
                    m_fLicInfo.macAddressCheck.Trim() == string.Empty
                    )
                {
                    FDebug.throwFException(FConstants.err_m_0022);
                }

                // --

                // ***
                // Expire Issued Data Check
                // ***
                if (m_fLicInfo.expireIssuedCheck == FYesNo.Yes.ToString())
                {
                    if (m_fLicInfo.expireIssuedDate.CompareTo(DateTime.Now.ToString("yyyyMMdd")) < 0)
                    {
                        FDebug.throwFException(FConstants.err_m_0022);
                    }
                }

                // ***
                // Mac Address Compare
                // ***                
                if (
                    m_fLicInfo.server == FYesNo.No.ToString() &&
                    m_fLicInfo.macAddressCheck == FYesNo.Yes.ToString()
                    )
                {
                    isValid = false;
                    foreach (string s in FUserPCInfo.MacAddressList())
                    {
                        if (m_fLicInfo.macAddressList.Contains(s))
                        {
                            isValid = true;
                            break;
                        }
                    }
                    // --
                    if (!isValid)
                    {
                        FDebug.throwFException(FConstants.err_m_0022);
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                    sr = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end    
}   // Namespace end