/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2014 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FWSMADSCaster.cs 
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.14
--  Description     : <Generated Class File Description>
--  History         : Created by jungyoul.moon at 2014.08.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.H101Interface
{
    internal class FWSMADSCaster : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private static string m_wsmadsChannel = string.Empty;
        private static int m_wsmadsTtl = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FWSMADSCaster(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FWSMADSCaster(
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

        public static string wsmadsChannel
        {
            get
            {
                try
                {
                    return m_wsmadsChannel;
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

            set
            {
                try
                {
                    m_wsmadsChannel = value;
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

        public static int wsmadsTtl
        {
            get
            {
                try
                {
                    return m_wsmadsTtl;
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

            set
            {
                try
                {
                    m_wsmadsTtl = value;
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

        public static void WSMADS_SysLogIn_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                WSMADS_SysLogIn_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void WSMADS_SysLogIn_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_wsmadsChannel || m_wsmadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_wsmadsChannel;
                }
                ttl = (ttl <= 0 ? m_wsmadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "WSMADS",
                    "WSMADS_SysLogIn_Req",
                    fXmlNodeIn,
                    channel,
                    ttl,
                    false
                    );

                if (null == fXmlNodeOut)
                {
                    FDebug.throwFException(FH101.INVALID_MESSAGE);
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

        public static void WSMADS_SysPasswordChange_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                WSMADS_SysPasswordChange_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void WSMADS_SysPasswordChange_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_wsmadsChannel || m_wsmadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_wsmadsChannel;
                }
                ttl = (ttl <= 0 ? m_wsmadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "WSMADS",
                    "WSMADS_SysPasswordChange_Req",
                    fXmlNodeIn,
                    channel,
                    ttl,
                    false
                    );

                if (null == fXmlNodeOut)
                {
                    FDebug.throwFException(FH101.INVALID_MESSAGE);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
