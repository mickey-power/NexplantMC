/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FNetworkDrive.cs
--  Creator         : mj.kim
--  Create Date     : 2012.04.13
--  Description     : FAMate Core FaCommon NetworkDrive Class
--  History         : Created by mj.kim at 2011.04.13
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FNetworkDrive
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FNetworkDrive(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void connect2(
            string drive,
            string pass,
            string userId,
            string password
            )
        {
            FNativeAPIs.NETRESOURCE ns = new FNativeAPIs.NETRESOURCE();
            int flags = 0;

            try
            {
                ns.dwScope = 2;
                ns.dwType = FNativeAPIs.RESOURCETYPE_DISK;
                ns.dwDisplayType = 3;
                ns.dwUsage = 1;
                ns.lpRemoteName = pass;
                ns.lpLocalName = drive;

                // --

                FNativeAPIs.WNetAddConnection2A(ref ns, password, userId, flags);
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

        public static void connect(
            string drive,
            string netwokPath,
            string user,
            string password
            )
        {
            FNativeAPIs.NETRESOURCE ns = new FNativeAPIs.NETRESOURCE();
            StringBuilder sb = null;
            uint flags = 0;
            int capacity = 64;
            uint resultFlags = 0;
            int error = 0;

            try
            {
                ns.dwType = FNativeAPIs.RESOURCETYPE_DISK;
                ns.lpLocalName = drive;
                ns.lpRemoteName = netwokPath;
                ns.lpProvider = null;
                // --
                sb = new StringBuilder(capacity);

                // --

                error = FNativeAPIs.WNetUseConnection(IntPtr.Zero, ref ns, password, user, flags, sb, ref capacity, out resultFlags);
                if (error > 0)
                {
                    throw new Win32Exception(error);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                sb = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string connect(            
            string netwokPath,
            string user,
            string password
            )
        {
            FNativeAPIs.NETRESOURCE ns = new FNativeAPIs.NETRESOURCE();
            StringBuilder sb = null;
            uint flags = 0;
            int capacity = 64;
            uint resultFlags = 0;
            int error = 0;

            try
            {
                ns.dwType = FNativeAPIs.RESOURCETYPE_DISK;
                ns.lpLocalName = null;
                ns.lpRemoteName = netwokPath;
                ns.lpProvider = null;
                // --
                sb = new StringBuilder(capacity);

                // --

                error = FNativeAPIs.WNetUseConnection(IntPtr.Zero, ref ns, password, user, flags, sb, ref capacity, out resultFlags);
                if (error > 0)
                {
                    throw new Win32Exception(error);
                }

                // --

                return sb.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                sb = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void disconnect(
            string drive
            )
        {
            try
            {
                FNativeAPIs.WNetCancelConnection2A(drive, 1, 1);
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

    }   // Class end
}   // Namespace end
