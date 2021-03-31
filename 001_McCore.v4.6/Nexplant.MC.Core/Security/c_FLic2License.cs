/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLic2License.cs
--  Creator         : spike.lee
--  Create Date     : 2017.08.24
--  Description     : FAmate Core FaCommon Lic2 License Class
--  History         : Created by spike.lee at 2017.08.24
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
    public class FLic2License : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string LicenceInformation = "license.information";
        private const string LicenceId = "license.id";
        private const string CustomerCompany = "customer.company";
        private const string CustomerSite = "customer.site";
        // --
        private const string ProductInformation = "product.information";
        private const string ProductTitle = "product.title";
        private const string ProductVersion = "product.version";
        // --
        private const string FAmateSecs = "famate.secs";
        private const string FAmateOpc = "famate.opc";
        private const string FAmateTcp = "famate.tcp";
        private const string FAmateAdminManager = "famate.admin.manager";
        private const string FAmateAdminService = "famate.admin.service";
        private const string FAmateS2hCvt = "famate.secs1.hsms.converter";
        // --
        private const string ProductEnabled = "product.enabled";
        private const string NetworkDeployed = "network.deployed";
        private const string ExpireIssuedCheck = "expire.issued.check";
        private const string ExpireIssuedDate = "expire.issued.date";
        private const string MacAddressCheck = "mac.address.check";
        private const string MacAddress = "mac.address";
        // --
        private const string EapRuntime = "eap.runtime";
        private const string EquipmentRuntime = "equipment.runtime";
        private const string Secs1HsmsConverterRuntime = "secs1.hsms.converter.runtime";
        private const string OpcTagRuntime = "opc.tag.runtime";
        // --
        private const string LicenseKey = "license.key";
        private const string Key = "key";       
        // --
        private const string KeyMarking = "key=";

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FLic2Info m_fLicInfo = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FLic2License(
            )
        {
            m_fLicInfo = new FLic2Info();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLic2License(
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
                    m_fLicInfo = null;
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
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public FLic2Info validate(
            string fileName
            )
        {
            StreamReader sr = null;
            string licData = string.Empty;            
            string rawData = string.Empty;
            string keyData = string.Empty;
            int index = 0;

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

                sr = new StreamReader(fileName, Encoding.Default);
                licData = sr.ReadToEnd();
                sr.Close();
                sr.Dispose();
                sr = null;
                
                // --

                index = licData.IndexOf(KeyMarking);
                if (index == -1)
                {
                    FDebug.throwFException(FConstants.err_m_0022);
                }
                
                // --
                
                rawData = licData.Substring(0, index);
                rawData = rawData.Replace("\n", "");
                rawData = rawData.Replace("\r", "");
                if (rawData == string.Empty)
                {
                    FDebug.throwFException(FConstants.err_m_0022);
                }

                // --

                keyData = FIniFile.readIniFile(LicenseKey, Key, fileName, string.Empty);
                if (keyData == string.Empty || keyData != (new FCrypt()).encrypt2(rawData))
                {
                    FDebug.throwFException(FConstants.err_m_0022);
                }

                // --

                m_fLicInfo.licenseId = FIniFile.readIniFile(LicenceInformation, LicenceId, fileName, string.Empty);
                m_fLicInfo.customerCompany = FIniFile.readIniFile(LicenceInformation, CustomerCompany, fileName, string.Empty);
                m_fLicInfo.customerSite = FIniFile.readIniFile(LicenceInformation, CustomerSite, fileName, string.Empty);
                // --
                m_fLicInfo.productTitle = FIniFile.readIniFile(ProductInformation, ProductTitle, fileName, string.Empty);
                m_fLicInfo.productVersion = FIniFile.readIniFile(ProductInformation, ProductVersion, fileName, string.Empty);
                // --
                m_fLicInfo.fLicSecs.productEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateSecs, ProductEnabled, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicSecs.networkDeployed = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateSecs, NetworkDeployed, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicSecs.expireIssuedCheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateSecs, ExpireIssuedCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicSecs.expireIssuedDate = FIniFile.readIniFile(FAmateSecs, ExpireIssuedDate, fileName, string.Empty);
                m_fLicInfo.fLicSecs.macAddresscheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateSecs, MacAddressCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicSecs.macAddress = FIniFile.readIniFile(FAmateSecs, MacAddress, fileName, string.Empty);
                // --
                m_fLicInfo.fLicOpc.productEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateOpc, ProductEnabled, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicOpc.networkDeployed = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateOpc, NetworkDeployed, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicOpc.expireIssuedCheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateOpc, ExpireIssuedCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicOpc.expireIssuedDate = FIniFile.readIniFile(FAmateOpc, ExpireIssuedDate, fileName, string.Empty);
                m_fLicInfo.fLicOpc.macAddresscheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateOpc, MacAddressCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicOpc.macAddress = FIniFile.readIniFile(FAmateOpc, MacAddress, fileName, string.Empty);
                // --
                m_fLicInfo.fLicTcp.productEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateTcp, ProductEnabled, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicTcp.networkDeployed = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateTcp, NetworkDeployed, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicTcp.expireIssuedCheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateTcp, ExpireIssuedCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicTcp.expireIssuedDate = FIniFile.readIniFile(FAmateTcp, ExpireIssuedDate, fileName, string.Empty);
                m_fLicInfo.fLicTcp.macAddresscheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateTcp, MacAddressCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicTcp.macAddress = FIniFile.readIniFile(FAmateTcp, MacAddress, fileName, string.Empty);
                // --
                m_fLicInfo.fLicAdm.productEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateAdminManager, ProductEnabled, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicAdm.networkDeployed = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateAdminManager, NetworkDeployed, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicAdm.expireIssuedCheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateAdminManager, ExpireIssuedCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicAdm.expireIssuedDate = FIniFile.readIniFile(FAmateAdminManager, ExpireIssuedDate, fileName, string.Empty);
                m_fLicInfo.fLicAdm.macAddresscheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateAdminManager, MacAddressCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicAdm.macAddress = FIniFile.readIniFile(FAmateAdminManager, MacAddress, fileName, string.Empty);
                // --
                m_fLicInfo.fLicAds.productEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateAdminService, ProductEnabled, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicAds.expireIssuedCheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateAdminService, ExpireIssuedCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicAds.expireIssuedDate = FIniFile.readIniFile(FAmateAdminService, ExpireIssuedDate, fileName, string.Empty);
                m_fLicInfo.fLicAds.macAddresscheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateAdminService, MacAddressCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicAds.macAddress = FIniFile.readIniFile(FAmateAdminService, MacAddress, fileName, string.Empty);
                m_fLicInfo.fLicAds.eapRuntime = int.Parse(FIniFile.readIniFile(FAmateAdminService, EapRuntime, fileName, "0"));
                m_fLicInfo.fLicAds.equipmentRuntime = int.Parse(FIniFile.readIniFile(FAmateAdminService, EquipmentRuntime, fileName, "0"));
                m_fLicInfo.fLicAds.secs1HsmsConverterRuntime = int.Parse(FIniFile.readIniFile(FAmateAdminService, Secs1HsmsConverterRuntime, fileName, "0"));
                m_fLicInfo.fLicAds.opcTagRuntime = int.Parse(FIniFile.readIniFile(FAmateAdminService, OpcTagRuntime, fileName, "999999"));
                // --
                m_fLicInfo.fLicS2hCvt.productEnabled = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateS2hCvt, ProductEnabled, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicS2hCvt.networkDeployed = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateS2hCvt, NetworkDeployed, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicS2hCvt.expireIssuedCheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateS2hCvt, ExpireIssuedCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicS2hCvt.expireIssuedDate = FIniFile.readIniFile(FAmateS2hCvt, ExpireIssuedDate, fileName, string.Empty);
                m_fLicInfo.fLicS2hCvt.macAddresscheck = (FYesNo)Enum.Parse(typeof(FYesNo), FIniFile.readIniFile(FAmateS2hCvt, MacAddressCheck, fileName, FYesNo.No.ToString()));
                m_fLicInfo.fLicS2hCvt.macAddress = FIniFile.readIniFile(FAmateS2hCvt, MacAddress, fileName, string.Empty);

                // --

                return m_fLicInfo;
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
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool validateMacAddress(
            string macAddressString
            )
        {
            try
            {
                foreach (string s in FUserPCInfo.MacAddressList())
                {
                    if (macAddressString.Contains(s))
                    {
                        return true;
                    }
                }
                return false;
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

        public bool validateExpireIssueDate(
            string expireDate
            )
        {
            try
            {
                if (expireDate.CompareTo(DateTime.Now.ToString("yyyyMMdd")) < 0)
                {
                    return false;
                }
                return true;
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

        public void rasieValidationError(
            string step
            )
        {
            if (step == string.Empty)
            {
                FDebug.throwFException(FConstants.err_m_0022);
            }
            FDebug.throwFException(FConstants.err_m_0022 + " [" + step + "]");
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end    
}   // Namespace end