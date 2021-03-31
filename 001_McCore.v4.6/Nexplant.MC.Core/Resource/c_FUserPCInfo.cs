/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FUserPCInfo.cs
--  Creator         : jeff.kim
--  Create Date     : 2013.01.25
--  Description     : FAMate Core FaCommon User PC Information Class
--  History         : Created by jeff.kim at 2013.01.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Management;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FUserPCInfo
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const String WORKGROUP = "SELECT WorkGroup FROM Win32_ComputerSystem";
        private const String OSVERSION = "SELECT Caption, OtherTypeDescription FROM Win32_OperatingSystem";
        private const String DNSHOSTNAME = "SELECT DNSHostName FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='TRUE'";
        private const String IPADDRESS = "SELECT IPAddress FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='TRUE'";
        private const String MACADDRESS = "SELECT MACAddress FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled='TRUE'";

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public static string ComputerName
        {
            get
            {
                try
                {
                    return Environment.MachineName;
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

        public static string UserName
        {
            get
            {
                try
                {
                    return Environment.UserName;
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


        public static string getWorkGroup(
            )
        {
            ObjectQuery objectQuery = null;
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection mos = null;

            try
            {
                // --

                objectQuery = new System.Management.ObjectQuery(WORKGROUP);
                searcher = new System.Management.ManagementObjectSearcher(objectQuery);
                mos = searcher.Get();

                // --

                foreach (System.Management.ManagementObject mo in mos)
                {
                    // ***
                    // Workgroup을 가져 올 수 없는 경우 예외 처리
                    // ***
                    return mo.Properties["Workgroup"].Value == null ? string.Empty : mo["Workgroup"].ToString();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                objectQuery = null;
                searcher = null;
                mos = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string getOSVersion(
            )
        {
            ObjectQuery objectQuery = null;
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection mos = null;
            string osVersion = string.Empty;

            try
            {
                // --

                objectQuery = new System.Management.ObjectQuery(OSVERSION);
                searcher = new System.Management.ManagementObjectSearcher(objectQuery);
                mos = searcher.Get();

                // --

                foreach (System.Management.ManagementObject mo in mos)
                {
                    osVersion = mo["Caption"].ToString();
                    if (mo["OtherTypeDescription"] != null)
                    {
                        osVersion += mo["OtherTypeDescription"].ToString();
                    }
                    return osVersion.Trim();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                objectQuery = null;
                searcher = null;
                mos = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string[] getIPAddressList(
            )
        {
            List<string> ipList = new List<string>();
            ObjectQuery objectQuery = null;
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection mos = null;

            try
            {
                // --

                objectQuery = new System.Management.ObjectQuery(IPADDRESS);
                searcher = new System.Management.ManagementObjectSearcher(objectQuery);
                mos = searcher.Get();

                // --

                foreach (System.Management.ManagementObject mo in mos)
                {
                    string[] AddressList = (string[])mo["IPAddress"];
                    foreach (string Address in AddressList)
                    {
                        //check if Address is IPv4
                        System.Net.IPAddress ipAddress;
                        if (System.Net.IPAddress.TryParse(Address, out ipAddress))
                        {
                            if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                ipList.Add(Address);
                                break;
                            }
                        }
                    }
                }
                return ipList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                ipList = null;
                objectQuery = null;
                searcher = null;
                mos = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string getIPAddress(
            )
        {
            List<string> ipList = new List<string>();
            ObjectQuery objectQuery = null;
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection mos = null;

            try
            {
                // --

                objectQuery = new System.Management.ObjectQuery(IPADDRESS);
                searcher = new System.Management.ManagementObjectSearcher(objectQuery);
                mos = searcher.Get();

                // --

                foreach (System.Management.ManagementObject mo in mos)
                {
                    string[] AddressList = (string[])mo["IPAddress"];
                    foreach (string Address in AddressList)
                    {
                        //check if Address is IPv4
                        System.Net.IPAddress ipAddress;
                        if (System.Net.IPAddress.TryParse(Address, out ipAddress))
                        {
                            if (ipAddress.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                return Address;
                            }
                        }
                    }
                }
                return "127.0.0.1";
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                ipList = null;
                objectQuery = null;
                searcher = null;
                mos = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string[] MacAddressList(
            )
        {
            List<string> macList = new List<string>();
            ObjectQuery objectQuery = null;
            ManagementObjectSearcher searcher = null;
            ManagementObjectCollection mos = null;

            try
            {
                // --

                objectQuery = new System.Management.ObjectQuery(MACADDRESS);
                searcher = new System.Management.ManagementObjectSearcher(objectQuery);
                mos = searcher.Get();

                // --

                foreach (System.Management.ManagementObject mo in mos)
                {
                    macList.Add(mo["MACAddress"] as string);
                }
                return macList.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                macList = null;
                objectQuery = null;
                searcher = null;
                mos = null;
            }
            return null;
        }


        #endregion

        //------------------------------------------------------------------------------------------------------------------------
    }
}
