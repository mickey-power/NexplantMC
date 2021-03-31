/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPing.cs
--  Creator         : mj.kim
--  Create Date     : 2011.08.24
--  Description     : FAMate Core FaCommon Ping Class
--  History         : Created by mj.kim at 2011.08.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FPing
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        static FPing(
            )
        {

        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static bool send(
            string address, 
            params int[] timeouts
            )
        {
            Ping ping = null;
            PingOptions pingOpt = null;
            PingReply pingRep = null;
            byte[] buf = null;

            try
            {
                ping = new Ping();
                pingOpt = new PingOptions();
                pingOpt.DontFragment = true;
                buf = Encoding.ASCII.GetBytes("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                
                foreach (int timeout in timeouts)
                {
                    pingRep = ping.Send(address, timeout, buf, pingOpt);
                    if (pingRep.Status == IPStatus.Success)
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
                ping = null;
                pingOpt = null;
                pingRep = null;
                buf = null;
            }
            return false;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end    
}   // Namespace end
