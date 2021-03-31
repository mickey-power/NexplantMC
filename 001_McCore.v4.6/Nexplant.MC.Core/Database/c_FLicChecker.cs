/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FLicChecker.cs
--  Creator         : byjeon
--  Create Date     : 2013.04.22
--  Description     : FAMate Core FaCommon Database Lic Checker Class
--  History         : Created by byjeon at 2013.04.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Data;

namespace Nexplant.MC.Core.FaCommon
{
    internal class FLicChecker : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string KeySeparator = "--";
        private const string LineSeparator = "\n";
        private const string FieldSeparator = "=";
        private const int MonitoringPeriod = 1000 * 60 * 60;    // 1 hour
        
        // -- 

        private bool m_disposed = false;
        // --
        private FILicCore m_fLicCore = null;
        private string m_licFile = string.Empty;
        private FDbProvider m_fDbProvider = FDbProvider.MsSqlServer;
        private string m_connectString = string.Empty;
        // --
        private Dictionary<string, object> m_licItem = null;
        private FStaticTimer m_fTmrMonitoring = null;
        private FThread m_fThdMain = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FLicChecker(
            FILicCore fLicCore,
            string licFile,
            FDbProvider fDbProvider,
            string connectString
            )
        {
            m_fLicCore = fLicCore;
            m_licFile = licFile;
            m_fDbProvider = fDbProvider;
            m_connectString = connectString;
            // -- 
            m_licItem = new Dictionary<string, object>();
            
            // --

            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FLicChecker(
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
                    term();
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

        public List<string> productName
        {
            get
            {
                try
                {
                    return m_licItem["product.name"] as List<string>; 
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

        public string productVersion
        {
            get
            {
                try
                {
                    return m_licItem["product.version"].ToString();
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

        public string licenseType
        {
            get
            {
                try
                {
                    return m_licItem["license.type"].ToString();
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

        public string customerCompany
        {
            get
            {
                try
                {
                    return m_licItem["customer.company"].ToString();
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

        public string customerFactory
        {
            get
            {
                try
                {
                    return m_licItem["customer.factory"].ToString();
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

        public string issuedDate
        {
            get
            {
                try
                {
                    return m_licItem["issued-date"].ToString();
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

        public string expiredDate
        {
            get
            {
                try
                {
                    return m_licItem["expired-date"].ToString();
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

        public List<string> macAddresses
        {
            get
            {
                try
                {
                    return m_licItem["hardware.address"] as List<string>;
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

        public bool clientCheck
        {
            get
            {
                try
                {
                    return m_licItem["client.check"].ToString().Equals("Yes");
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
        
        public int clientUser
        {
            get
            {
                try
                {
                    return (int)m_licItem["client.user"];
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

        public int clientEap
        {
            get
            {
                try
                {
                    return (int)m_licItem["client.eap"];
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

        public string clientLimitPolicy
        {
            get
            {
                try
                {
                    return m_licItem["client.limit.policy"].ToString();
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

        public bool mobileUse
        {
            get
            {
                try
                {
                    return m_licItem["mobile.use"].ToString().Equals("Yes");
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

        public int mobileUser
        {
            get
            {
                try
                {
                    return (int)m_licItem["mobile.user"];
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

        public string mobileLimitPolicy
        {
            get
            {
                try
                {
                    return m_licItem["mobile.limit.policy"].ToString();
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

        private string applicationNamespace
        {
            get
            {
                try
                {
                    return Assembly.LoadFile(Application.ExecutablePath).EntryPoint.ReflectedType.Namespace;
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

        public void init(
            )
        {
            try
            {
                if(!File.Exists(m_licFile))
                {
                    m_fLicCore.writeLogOfLicenseFail(FConstants.err_m_0018);
                    Environment.Exit(0);
                }

                // -- 

                if (!isModified())
                {
                    m_fLicCore.writeLogOfLicenseFail(FConstants.err_m_0019);
                    Environment.Exit(0);
                }

                // -- 

                parse();

                // --

                // ***
                // validate once when this instance is created.
                // ***
                validateOnce();
                validateRegularly();

                // -- 

                m_fTmrMonitoring = new FStaticTimer();
                m_fTmrMonitoring.start(MonitoringPeriod);
                // --
                m_fThdMain = new FThread("LicCheckerThread");
                m_fThdMain.ThreadJobCalled += new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                m_fThdMain.start();
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void term(
            )
        {
            try
            {
                if (m_fThdMain != null)
                {
                    m_fThdMain.stop();
                    m_fThdMain.Dispose();
                    m_fThdMain.ThreadJobCalled -= new FThreadJobCalledEventHandler(m_fThdMain_ThreadJobCalled);
                    m_fThdMain = null;
                }

                if (m_fTmrMonitoring != null)
                {
                    m_fTmrMonitoring.Dispose();
                    m_fTmrMonitoring = null;
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

        //------------------------------------------------------------------------------------------------------------------------

        private void validateOnce(
            )
        {
            bool isValid = false;
            string message = string.Empty;

            try
            {
                // ***
                // Validation of the Service's Namespace 
                // ***
                if (!productName.Contains(applicationNamespace))
                {
                    message = string.Format(FConstants.err_m_0020, "Product Name");
                    m_fLicCore.writeLogOfLicenseFail(message);
                    Environment.Exit(0);
                }                

                // -- 

                // ***
                // Validation of the Service's Mac Address
                // ***
                isValid = false;
                foreach (string addr in FUserPCInfo.MacAddressList())
                {
                    if (macAddresses.Contains(addr))
                    {
                        isValid = true;
                        break;
                    }
                }

                if(!isValid)
                {
                    message = string.Format(FConstants.err_m_0020, "Hardware Address");
                    m_fLicCore.writeLogOfLicenseFail(message);
                    Environment.Exit(0);
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

        //------------------------------------------------------------------------------------------------------------------------

        private void validateRegularly(
            )
        {
            try
            {
                checkPeriod();
                checkEap();
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

        private void parse(            
            )
        {
            string buffer = string.Empty;
            StreamReader streamReader = null;
            // --
            string[] parts = null;
            string[] rows = null;
            string[] items = null;

            try
            {
                streamReader = new StreamReader(m_licFile);
                buffer = streamReader.ReadToEnd();
                streamReader.Close();

                // -- 

                parts = buffer.Split(new string[] { KeySeparator }, StringSplitOptions.RemoveEmptyEntries);
                //parts[1] = parts[1].Replace("\r", "");
                //parts[1] = parts[1].Replace("\n", "");
                // --                
                buffer = (new FCrypt()).decrypt2(parts[1]);

                // -- 

                rows = buffer.Split(new string[] { LineSeparator }, StringSplitOptions.RemoveEmptyEntries);                
                foreach (string row in rows)
                {
                    items = row.Split(new string[] { FieldSeparator }, StringSplitOptions.RemoveEmptyEntries);
                    match(items[0].Trim(), items[1].Trim());
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

        //------------------------------------------------------------------------------------------------------------------------

        private bool isModified(            
            )
        {
            string buffer = string.Empty;
            string[] parts = null;
            StreamReader streamReader = null;

            try
            {
                streamReader = new StreamReader(m_licFile);
                buffer = streamReader.ReadToEnd();
                streamReader.Close();

                // -- 

                parts = buffer.Split(new string[] { KeySeparator }, StringSplitOptions.RemoveEmptyEntries);
                // -- 
                parts[0] = parts[0].Replace("\r", "");
                parts[0] = parts[0].Replace("\n", "");
                // -- 
                //parts[1] = parts[1].Replace("\r", "");
                //parts[1] = parts[1].Replace("\n", "");
                parts[1] = (new FCrypt()).decrypt2(parts[1]);
                parts[1] = parts[1].Replace("\r", "");
                parts[1] = parts[1].Replace("\n", "");
                
                // -- 

                return parts[0].Equals(parts[1]);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                    streamReader = null;
                }
            }
            return false;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        private void match(
            string name,
            string value
            )
        {
            string[] values = null;

            try
            {
                if(
                    name.Equals("product.version") ||
                    name.Equals("license.type") ||
                    name.Equals("customer.company") ||
                    name.Equals("customer.factory") ||
                    name.Equals("issued-date") ||
                    name.Equals("expired-date") ||
                    name.Equals("client.check") ||
                    name.Equals("client.limit.policy") ||
                    name.Equals("mobile.limit.policy") ||
                    name.Equals("mobile.use")
                    )
                {
                    m_licItem.Add(name, value);
                }
                else if (
                    name.Equals("product.name") ||
                    name.Equals("hardware.address")
                    )
                {
                    values = value.Split(new string[] { ";", ",", " " }, StringSplitOptions.RemoveEmptyEntries);
                    m_licItem.Add(name, new List<string>(values));                    
                }
                else if (
                    name.Equals("client.user") ||
                    name.Equals("client.eap") ||
                    name.Equals("mobile.user")
                    )
                {
                    m_licItem.Add(name, int.Parse(value));                    
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

        //------------------------------------------------------------------------------------------------------------------------
        
        private void checkPeriod(
            )
        {
            string message = string.Empty;

            try
            {
                if (
                    !expiredDate.Equals("Unlimited") &&
                    DateTime.Parse(expiredDate).CompareTo(DateTime.Now) < 0
                    )
                {
                    message = string.Format(FConstants.err_m_0020, "Expired Date");
                    m_fLicCore.writeLogOfLicenseFail(message);
                    Environment.Exit(0);
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

        //------------------------------------------------------------------------------------------------------------------------

        private void checkEap(
            )
        {         
            int eapCount = 0;
            // -- 
            FSql fSql = null;
            FIQueryExecutor fqExe = null;
            DataSet ds = null;
            DataTable fraseapdef = null;
            string sql = string.Empty;
            string message = string.Empty;

            try
            {
                sql = "SELECT COUNT(EAP) EAP_COUNT FROM FRASEAPDEF WHERE DELETE_FLAG='N'";
                fqExe = FDbAdapter.createQueryExecutor(m_fDbProvider, m_connectString);
                fSql = new FSql("fraseapdef", sql);
                fqExe.appendSql(fSql);

                // -- 
                               
                ds = fqExe.execute();
                fraseapdef = ds.Tables["fraseapdef"];
                eapCount = (int)fraseapdef.Rows[0]["EAP_COUNT"];

                // -- 

                if (eapCount > clientEap)
                {
                    message = string.Format(FConstants.err_m_0020, "EAP");
                    m_fLicCore.writeLogOfLicenseFail(message);
                    Environment.Exit(0);
                }
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fqExe = null;
                fSql = null;
                ds = null;
                fraseapdef = null;                
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region m_fThdMain Object Event Handler

        private void m_fThdMain_ThreadJobCalled(
            object sender,
            FThreadEventArgs e
            )
        {
            try
            {
                // ***
                // Monitoring Timer check
                // ***
                if (!m_fTmrMonitoring.elasped(true))
                {
                    e.sleepThread(1);
                    return;
                }

                // -- 

                // ***
                // License Validation
                // ***
                validateRegularly();
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