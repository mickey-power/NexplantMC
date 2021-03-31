/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FWinAuth.cs
--  Creator         : mjkim
--  Create Date     : 2013.08.02
--  Description     : FAMate Core FaCommon Windows Authority Class
--  History         : Created by mjkim at 2013.08.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Management;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Security.Principal;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FWinAuth
    {
        //------------------------------------------------------------------------------------------------------------------------

        private const string CAPTION_TEXT = "Please enter the credentails for ";
        // -- 
        private const int LOGON32_LOGON_INTERACTIVE = 2;
        private const int LOGON32_LOGON_NETWORK = 3;
        // --
        private const int LOGON32_PROVIDER_DEFAULT = 0;
        private const int LOGON32_PROVIDER_WINNT50 = 3;
        private const int LOGON32_PROVIDER_WINNT40 = 2;
        private const int LOGON32_PROVIDER_WINNT35 = 1;
        // -- 
        private const int MAX_USER_NAME = 100;
        private const int MAX_PASSWORD = 100;
        private const int MAX_DOMAIN = 100;

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        private static string osName
        {
            get
            {
                ManagementObjectSearcher mos = null;

                try
                {
                    mos = new ManagementObjectSearcher("SELECT Caption FROM win32_OperatingSystem");
                    foreach (ManagementObject mo in mos.Get())
                    {
                        return mo["Caption"].ToString();
                    }
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

        private static FOsGroup osGroup
        {
            get
            {
                int index = 0;
                string currOS = osName;
                string[] xpAndBelowGroup = { "2000", "XP", "2003" };
                string[] vistaAndAboveGroup = { "Vista", "7", "2008", "8", "2012" };

                try
                {
                    foreach (string key in xpAndBelowGroup)
                    {
                        index = currOS.IndexOf(key);
                        if (index >= 0)
                        {
                            return FOsGroup.XpAndBelow;
                        }
                    }

                    foreach (string key in vistaAndAboveGroup)
                    {
                        index = currOS.IndexOf(key);
                        if (index >= 0)
                        {
                            return FOsGroup.VistaAndAbove;
                        }
                    }
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FOsGroup.UnKnown;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static bool getLocalCredentials(
            string messageText
            )
        {
            try
            {
                if (osGroup == FOsGroup.XpAndBelow)
                {
                    return getLocalCredentialsForXpAndBelow(messageText);
                }
                else if (osGroup == FOsGroup.VistaAndAbove)
                {
                    return getLocalCredentialsForVistaAndAbove(messageText);
                }
                else
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0021, osName));
                }
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

        public static bool getDomainCredentials(
            string domainName,
            string messageText
            )
        {
            try
            {
                if (osGroup == FOsGroup.XpAndBelow)
                {
                    return getDomainCredentialsForXpAndBelow(domainName, messageText);
                }
                else if (osGroup == FOsGroup.VistaAndAbove)
                {
                    return getDomainCredentialsForVistaAndAbove(domainName, messageText);
                }
                else
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0021, osName));
                }
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

        private static bool getLocalCredentialsForXpAndBelow(
            string messageText
            )
        {
            try
            {
                return getDomainCredentialsForXpAndBelow(string.Empty, messageText);
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

        private static bool getDomainCredentialsForXpAndBelow(
            string domainName,
            string messageText
            )
        {
            try
            {
                FNativeAPIs.AUTH_INFO authInfo;
                int authError = 0;
                // --
                StringBuilder usernameBuf = null;
                StringBuilder passwordBuf = null;
                StringBuilder domainBuf = null;
                bool save = false;

                try
                {
                    authInfo = new FNativeAPIs.AUTH_INFO();
                    authInfo.pszCaptionText = CAPTION_TEXT + ((string.IsNullOrWhiteSpace(domainName)) ? Environment.UserDomainName : domainName);
                    authInfo.pszMessageText = messageText;
                    authInfo.cbSize = Marshal.SizeOf(authInfo);

                    // -- 

                    usernameBuf = new StringBuilder(MAX_USER_NAME);
                    passwordBuf = new StringBuilder(MAX_PASSWORD);
                    domainBuf = new StringBuilder(MAX_DOMAIN);

                    // -- 

                    // ***
                    // CredUIPromptForCredentials
                    // ***
                    FNativeAPIs.FCredUIReturnCodes result =
                        FNativeAPIs.CredUIPromptForCredentials(
                            ref authInfo,
                            "Test",
                            IntPtr.Zero,
                            authError,
                            usernameBuf,
                            MAX_USER_NAME,
                            passwordBuf,
                            MAX_PASSWORD,
                            ref save,
                            FNativeAPIs.FCREDUI_FLAGS.INCORRECT_PASSWORD
                            );

                    if (result == FNativeAPIs.FCredUIReturnCodes.NO_ERROR)
                    {

                        StringBuilder userBuilder = new StringBuilder();
                        StringBuilder domainBuilder = new StringBuilder();

                        FNativeAPIs.FCredUIReturnCodes returnCode =
                            FNativeAPIs.CredUIParseUserName(
                                usernameBuf.ToString(),
                                userBuilder,
                                MAX_USER_NAME,
                                domainBuilder,
                                MAX_DOMAIN
                                );

                        if (returnCode == FNativeAPIs.FCredUIReturnCodes.NO_ERROR)
                        {
                            return validateUserAccount(domainBuilder.ToString(), userBuilder.ToString(), passwordBuf.ToString());
                        }
                        else if (returnCode == FNativeAPIs.FCredUIReturnCodes.ERROR_INVALID_ACCOUNT_NAME)
                        {
                            return validateUserAccount(string.Empty, userBuilder.ToString(), passwordBuf.ToString());
                        }
                        return false;
                    }
                    return false;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    usernameBuf = null;
                    passwordBuf = null;
                    domainBuf = null;
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

        private static bool getLocalCredentialsForVistaAndAbove(
            string messageText
            )
        {
            try
            {
                return getDomainCredentialsForVistaAndAbove(string.Empty, messageText);
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

        private static bool getDomainCredentialsForVistaAndAbove(
            string domainName,
            string messageText
            )
        {
            FNativeAPIs.AUTH_INFO authInfo;
            uint authPackage = 0;
            uint outAuthBufferSize;
            IntPtr outAuthBuffer;
            // --
            int maxUserName = 0;
            int maxDomain = 0;
            int maxPassword = 0;
            // -- 
            StringBuilder usernameBuf = null;
            StringBuilder passwordBuf = null;
            StringBuilder domainBuf = null;
            bool save = false;

            try
            {
                authInfo = new FNativeAPIs.AUTH_INFO();
                authInfo.pszCaptionText = CAPTION_TEXT + ((string.IsNullOrWhiteSpace(domainName)) ? Environment.UserDomainName : domainName);
                authInfo.pszMessageText = messageText;
                authInfo.cbSize = Marshal.SizeOf(authInfo);
                // -- 
                outAuthBuffer = new IntPtr();

                // -- 

                // ***
                // CredUIPromptForWindowsCredentials
                // ***
                int result =
                    FNativeAPIs.CredUIPromptForWindowsCredentials(
                        ref authInfo,
                        0,
                        ref authPackage,
                        IntPtr.Zero,
                        0,
                        out outAuthBuffer,
                        out outAuthBufferSize,
                        ref save,
                        1 /* Generic */);


                // ***
                // Unpack Authencication Information
                // ***
                if (result == 0)
                {
                    maxDomain = MAX_DOMAIN;
                    maxUserName = MAX_USER_NAME;
                    maxPassword = MAX_PASSWORD;
                    // -- 
                    usernameBuf = new StringBuilder(MAX_USER_NAME);
                    passwordBuf = new StringBuilder(MAX_PASSWORD);
                    domainBuf = new StringBuilder(MAX_DOMAIN);

                    if (FNativeAPIs.CredUnPackAuthenticationBuffer(
                                            0,
                                            outAuthBuffer,
                                            outAuthBufferSize,
                                            usernameBuf,
                                            ref maxUserName,
                                            domainBuf,
                                            ref maxDomain,
                                            passwordBuf,
                                            ref maxPassword)
                        )
                    {
                        FNativeAPIs.CoTaskMemFree(outAuthBuffer);

                        return
                            validateUserAccount(
                                domainName,
                                usernameBuf.ToString(),
                                passwordBuf.ToString()
                                );
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
                usernameBuf = null;
                passwordBuf = null;
                domainBuf = null;
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static bool validateUserAccount(
            string domainName,
            string userName,
            string password
            )
        {
            IntPtr hToken;
            IntPtr hDuplicateToken;

            try
            {
                hToken = new IntPtr(0);
                hToken = IntPtr.Zero;

                // -- 

                // ***
                // Validate Login
                // ***
                if (
                    FNativeAPIs.LogonUser(
                        userName,
                        domainName,
                        password,
                        LOGON32_LOGON_NETWORK,
                        LOGON32_PROVIDER_DEFAULT,
                        ref hToken
                    )
                )
                {
                    if (FNativeAPIs.DuplicateToken(hToken, 2, out hDuplicateToken))
                    {
                        WindowsIdentity windowsIdentity = new WindowsIdentity(hDuplicateToken);
                        WindowsImpersonationContext impersonationContext = windowsIdentity.Impersonate();

                        impersonationContext.Undo();
                    }

                    // ***
                    // Release Handles
                    // *** 
                    if (hToken != IntPtr.Zero)
                    {
                        FNativeAPIs.CloseHandle(hToken);
                    }

                    if (hDuplicateToken != IntPtr.Zero)
                    {
                        FNativeAPIs.CloseHandle(hDuplicateToken);
                    }

                    // -- 

                    return true;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end    
}   // Namespace end