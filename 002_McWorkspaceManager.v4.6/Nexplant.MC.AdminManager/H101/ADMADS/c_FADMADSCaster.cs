/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2018 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADSCaster.cs 
--  Creator         : mjkim
--  Create Date     : 2018.05.23
--  Description     : <Generated Class File Description>
--  History         : Created by mjkim at 2018.05.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.H101Interface
{
    internal class FADMADSCaster : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private static string m_admadsChannel = string.Empty;
        private static int m_admadsTtl = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FADMADSCaster(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FADMADSCaster(
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

        public static string admadsChannel
        {
            get
            {
                try
                {
                    return m_admadsChannel;
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
                    m_admadsChannel = value;
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

        public static int admadsTtl
        {
            get
            {
                try
                {
                    return m_admadsTtl;
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
                    m_admadsTtl = value;
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

        public static void ADMADS_ComSqlQuery_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_ComSqlQuery_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_ComSqlQuery_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_ComSqlQuery_Req",
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

        public static void ADMADS_ComEapSchemaSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_ComEapSchemaSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_ComEapSchemaSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_ComEapSchemaSearch_Req",
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

        public static void ADMADS_DlgEapWizardEapSchemaSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_DlgEapWizardEapSchemaSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_DlgEapWizardEapSchemaSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_DlgEapWizardEapSchemaSearch_Req",
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

        public static void ADMADS_SysLogIn_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SysLogIn_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SysLogIn_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SysLogIn_Req",
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

        public static void ADMADS_SysUserNoticeUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SysUserNoticeUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SysUserNoticeUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SysUserNoticeUpdate_Req",
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

        public static void ADMADS_SysPasswordChange_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SysPasswordChange_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SysPasswordChange_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SysPasswordChange_Req",
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

        public static void ADMADS_SysPasswordReset_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SysPasswordReset_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SysPasswordReset_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SysPasswordReset_Req",
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

        public static void ADMADS_SysHostDriverDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SysHostDriverDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SysHostDriverDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SysHostDriverDownload_Req",
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

        public static void ADMADS_SetFactoryUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetFactoryUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetFactoryUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetFactoryUpdate_Req",
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

        public static void ADMADS_SetNoticeUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetNoticeUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetNoticeUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetNoticeUpdate_Req",
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

        public static void ADMADS_SetGcmTableUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetGcmTableUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetGcmTableUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetGcmTableUpdate_Req",
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

        public static void ADMADS_SetGcmDataUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetGcmDataUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetGcmDataUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetGcmDataUpdate_Req",
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

        public static void ADMADS_SetServerEventUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetServerEventUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetServerEventUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetServerEventUpdate_Req",
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

        public static void ADMADS_SetEapEventUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetEapEventUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetEapEventUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetEapEventUpdate_Req",
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

        public static void ADMADS_SetEquipmentEventUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetEquipmentEventUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetEquipmentEventUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetEquipmentEventUpdate_Req",
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

        public static void ADMADS_SetUserEventUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetUserEventUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetUserEventUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetUserEventUpdate_Req",
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

        public static void ADMADS_SetUserGroupApplicationUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetUserGroupApplicationUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetUserGroupApplicationUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetUserGroupApplicationUpdate_Req",
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

        public static void ADMADS_SetUserGroupFunctionUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetUserGroupFunctionUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetUserGroupFunctionUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetUserGroupFunctionUpdate_Req",
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

        public static void ADMADS_SetUserGroupAuthorityUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetUserGroupAuthorityUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetUserGroupAuthorityUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetUserGroupAuthorityUpdate_Req",
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

        public static void ADMADS_SetUserGroupAlertUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetUserGroupAlertUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetUserGroupAlertUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetUserGroupAlertUpdate_Req",
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

        public static void ADMADS_SetUserGroupUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetUserGroupUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetUserGroupUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetUserGroupUpdate_Req",
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

        public static void ADMADS_SetUserUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetUserUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetUserUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetUserUpdate_Req",
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

        public static void ADMADS_SetServerUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetServerUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetServerUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetServerUpdate_Req",
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

        public static void ADMADS_SetModelSheetUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelSheetUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelSheetUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelSheetUpdate_Req",
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

        public static void ADMADS_SetMakerUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetMakerUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetMakerUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetMakerUpdate_Req",
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

        public static void ADMADS_SetHostDriverUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetHostDriverUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetHostDriverUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetHostDriverUpdate_Req",
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

        public static void ADMADS_SetHostDriverDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetHostDriverDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetHostDriverDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetHostDriverDownload_Req",
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

        public static void ADMADS_SetPackageUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetPackageUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetPackageUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetPackageUpdate_Req",
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

        public static void ADMADS_SetModelUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelUpdate_Req",
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

        public static void ADMADS_SetComponentUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetComponentUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetComponentUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetComponentUpdate_Req",
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

        public static void ADMADS_SetPackageVerUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetPackageVerUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetPackageVerUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetPackageVerUpdate_Req",
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

        public static void ADMADS_SetPackageVerDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetPackageVerDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetPackageVerDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetPackageVerDownload_Req",
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

        public static void ADMADS_SetModelVerUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelVerUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelVerUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelVerUpdate_Req",
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

        public static void ADMADS_SetModelVerDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelVerDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelVerDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelVerDownload_Req",
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

        public static void ADMADS_SetModelManualUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelManualUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelManualUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelManualUpdate_Req",
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

        public static void ADMADS_SetModelManualDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelManualDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelManualDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelManualDownload_Req",
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

        public static void ADMADS_SetModelStateUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelStateUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelStateUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelStateUpdate_Req",
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

        public static void ADMADS_SetModelObjectNameUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelObjectNameUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelObjectNameUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelObjectNameUpdate_Req",
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

        public static void ADMADS_SetModelFunctionNameListUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelFunctionNameListUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelFunctionNameListUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelFunctionNameListUpdate_Req",
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

        public static void ADMADS_SetModelFunctionNameUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelFunctionNameUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelFunctionNameUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelFunctionNameUpdate_Req",
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

        public static void ADMADS_SetModelParameterNameUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelParameterNameUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelParameterNameUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelParameterNameUpdate_Req",
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

        public static void ADMADS_SetModelArgumentNameUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelArgumentNameUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelArgumentNameUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelArgumentNameUpdate_Req",
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

        public static void ADMADS_SetModelUserTagNameUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetModelUserTagNameUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetModelUserTagNameUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetModelUserTagNameUpdate_Req",
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

        public static void ADMADS_SetComponentVerUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetComponentVerUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetComponentVerUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetComponentVerUpdate_Req",
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

        public static void ADMADS_SetComponentVerDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetComponentVerDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetComponentVerDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetComponentVerDownload_Req",
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

        public static void ADMADS_SetCustomRemoteCommandUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetCustomRemoteCommandUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetCustomRemoteCommandUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetCustomRemoteCommandUpdate_Req",
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

        public static void ADMADS_SetEquipmentTypeUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetEquipmentTypeUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetEquipmentTypeUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetEquipmentTypeUpdate_Req",
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

        public static void ADMADS_SetEquipmentAreaUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetEquipmentAreaUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetEquipmentAreaUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetEquipmentAreaUpdate_Req",
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

        public static void ADMADS_SetEquipmentLineUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetEquipmentLineUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetEquipmentLineUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetEquipmentLineUpdate_Req",
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

        public static void ADMADS_SetEquipmentUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetEquipmentUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetEquipmentUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetEquipmentUpdate_Req",
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

        public static void ADMADS_SetInlineEquipmentUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetInlineEquipmentUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetInlineEquipmentUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetInlineEquipmentUpdate_Req",
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

        public static void ADMADS_SetEapUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetEapUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetEapUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetEapUpdate_Req",
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

        public static void ADMADS_SetProcessEapUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetProcessEapUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetProcessEapUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetProcessEapUpdate_Req",
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

        public static void ADMADS_TrnEapBatchModification_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapBatchModification_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapBatchModification_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapBatchModification_Req",
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

        public static void ADMADS_TrnEapRelease_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapRelease_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapRelease_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapRelease_Req",
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

        public static void ADMADS_TrnEapStart_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapStart_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapStart_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapStart_Req",
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

        public static void ADMADS_TrnEapStop_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapStop_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapStop_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapStop_Req",
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

        public static void ADMADS_TrnEapReload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapReload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapReload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapReload_Req",
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

        public static void ADMADS_TrnEapRestart_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapRestart_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapRestart_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapRestart_Req",
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

        public static void ADMADS_TrnEapAbort_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapAbort_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapAbort_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapAbort_Req",
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

        public static void ADMADS_TrnEapMove_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapMove_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapMove_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapMove_Req",
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

        public static void ADMADS_TrnEapLogLevelSetup_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapLogLevelSetup_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapLogLevelSetup_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapLogLevelSetup_Req",
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

        public static void ADMADS_TrnEapMainSwitch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapMainSwitch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapMainSwitch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapMainSwitch_Req",
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

        public static void ADMADS_TrnServerMainSwitch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnServerMainSwitch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnServerMainSwitch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnServerMainSwitch_Req",
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

        public static void ADMADS_TrnEapBackupSwitch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapBackupSwitch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapBackupSwitch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapBackupSwitch_Req",
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

        public static void ADMADS_TrnServerBackupSwitch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnServerBackupSwitch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnServerBackupSwitch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnServerBackupSwitch_Req",
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

        public static void ADMADS_TrnTransactionCertification_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnTransactionCertification_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnTransactionCertification_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnTransactionCertification_Req",
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

        public static void ADMADS_TrnEapRepositoryClear_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapRepositoryClear_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapRepositoryClear_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapRepositoryClear_Req",
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

        public static void ADMADS_TrnEapRepositoryRemove_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TrnEapRepositoryRemove_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TrnEapRepositoryRemove_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TrnEapRepositoryRemove_Req",
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

        public static void ADMADS_TolEapSchemaSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolEapSchemaSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolEapSchemaSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolEapSchemaSearch_Req",
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

        public static void ADMADS_TolServerDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolServerDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolServerDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolServerDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolPackageDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolPackageDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolPackageDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolPackageDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolPackageVerDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolPackageVerDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolPackageVerDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolPackageVerDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolModelDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolModelDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolModelDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolModelDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolModelVerDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolModelVerDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolModelVerDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolModelVerDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolComponentDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolComponentDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolComponentDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolComponentDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolComponentVerDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolComponentVerDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolComponentVerDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolComponentVerDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolEapDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolEapDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolEapDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolEapDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolEquipmentTypeDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolEquipmentTypeDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolEquipmentTypeDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolEquipmentTypeDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolEquipmentAreaDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolEquipmentAreaDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolEquipmentAreaDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolEquipmentAreaDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolEquipmentLineDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolEquipmentLineDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolEquipmentLineDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolEquipmentLineDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolEquipmentDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolEquipmentDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolEquipmentDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolEquipmentDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolDeviceDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolDeviceDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolDeviceDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolDeviceDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolEapModelDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolEapModelDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolEapModelDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolEapModelDownload_Req",
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

        public static void ADMADS_TolServerIssueEventRefresh_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolServerIssueEventRefresh_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolServerIssueEventRefresh_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolServerIssueEventRefresh_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolEapIssueEventRefresh_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolEapIssueEventRefresh_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolEapIssueEventRefresh_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolEapIssueEventRefresh_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolEquipmentIssueEventRefresh_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolEquipmentIssueEventRefresh_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolEquipmentIssueEventRefresh_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolEquipmentIssueEventRefresh_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolEapLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolEapLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolEapLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolEapLogList_Req",
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

        public static void ADMADS_TolEapLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolEapLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolEapLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolEapLogDownload_Req",
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

        public static void ADMADS_TolEapLogContinue_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolEapLogContinue_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolEapLogContinue_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolEapLogContinue_Req",
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

        public static void ADMADS_TolEapBackupLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolEapBackupLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolEapBackupLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolEapBackupLogList_Req",
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

        public static void ADMADS_TolEapBackupLogSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolEapBackupLogSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolEapBackupLogSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolEapBackupLogSearch_Req",
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

        public static void ADMADS_TolEapBackupLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolEapBackupLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolEapBackupLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolEapBackupLogDownload_Req",
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

        public static void ADMADS_TolEapBackupLogContinue_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolEapBackupLogContinue_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolEapBackupLogContinue_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolEapBackupLogContinue_Req",
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

        public static void ADMADS_TolAdminServiceLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminServiceLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminServiceLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminServiceLogList_Req",
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

        public static void ADMADS_TolAdminServiceLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminServiceLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminServiceLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminServiceLogDownload_Req",
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

        public static void ADMADS_TolAdminServiceLogContinue_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminServiceLogContinue_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminServiceLogContinue_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminServiceLogContinue_Req",
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

        public static void ADMADS_TolAdminServiceBackupLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminServiceBackupLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminServiceBackupLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminServiceBackupLogList_Req",
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

        public static void ADMADS_TolAdminServiceBackupLogSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminServiceBackupLogSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminServiceBackupLogSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminServiceBackupLogSearch_Req",
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

        public static void ADMADS_TolAdminServiceBackupLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminServiceBackupLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminServiceBackupLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminServiceBackupLogDownload_Req",
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

        public static void ADMADS_TolAdminServiceBackupLogContinue_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminServiceBackupLogContinue_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminServiceBackupLogContinue_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminServiceBackupLogContinue_Req",
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

        public static void ADMADS_TolAdminAgentLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminAgentLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminAgentLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminAgentLogList_Req",
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

        public static void ADMADS_TolAdminAgentLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminAgentLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminAgentLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminAgentLogDownload_Req",
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

        public static void ADMADS_TolAdminAgentLogContinue_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminAgentLogContinue_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminAgentLogContinue_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminAgentLogContinue_Req",
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

        public static void ADMADS_TolAdminAgentBackupLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminAgentBackupLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminAgentBackupLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminAgentBackupLogList_Req",
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

        public static void ADMADS_TolAdminAgentBackupLogSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminAgentBackupLogSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminAgentBackupLogSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminAgentBackupLogSearch_Req",
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

        public static void ADMADS_TolAdminAgentBackupLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminAgentBackupLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminAgentBackupLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminAgentBackupLogDownload_Req",
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

        public static void ADMADS_TolAdminAgentBackupLogContinue_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminAgentBackupLogContinue_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminAgentBackupLogContinue_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminAgentBackupLogContinue_Req",
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

        public static void ADMADS_TolAlertServiceLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAlertServiceLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAlertServiceLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAlertServiceLogList_Req",
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

        public static void ADMADS_TolAlertServiceLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAlertServiceLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAlertServiceLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAlertServiceLogDownload_Req",
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

        public static void ADMADS_TolAlertServiceBackupLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAlertServiceBackupLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAlertServiceBackupLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAlertServiceBackupLogList_Req",
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

        public static void ADMADS_TolAlertServiceBackupLogSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAlertServiceBackupLogSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAlertServiceBackupLogSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAlertServiceBackupLogSearch_Req",
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

        public static void ADMADS_TolAlertServiceBackupLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAlertServiceBackupLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAlertServiceBackupLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAlertServiceBackupLogDownload_Req",
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

        public static void ADMADS_TolAdminAgentOptionSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminAgentOptionSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminAgentOptionSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminAgentOptionSearch_Req",
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

        public static void ADMADS_TolAdminAgentOptionUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolAdminAgentOptionUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolAdminAgentOptionUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolAdminAgentOptionUpdate_Req",
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

        public static void ADMADS_RcmEquipmentEventDefineRequest_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_RcmEquipmentEventDefineRequest_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_RcmEquipmentEventDefineRequest_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_RcmEquipmentEventDefineRequest_Req",
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

        public static void ADMADS_RcmEquipmentVersionRequest_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_RcmEquipmentVersionRequest_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_RcmEquipmentVersionRequest_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_RcmEquipmentVersionRequest_Req",
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

        public static void ADMADS_RcmEquipmentControlModeRequest_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_RcmEquipmentControlModeRequest_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_RcmEquipmentControlModeRequest_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_RcmEquipmentControlModeRequest_Req",
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

        public static void ADMADS_RcmEquipmentCustomRequest_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_RcmEquipmentCustomRequest_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_RcmEquipmentCustomRequest_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_RcmEquipmentCustomRequest_Req",
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

        public static void ADMADS_RcmRemotePingTest_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_RcmRemotePingTest_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_RcmRemotePingTest_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_RcmRemotePingTest_Req",
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

        public static void ADMADS_InqModelVerSchemaSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_InqModelVerSchemaSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_InqModelVerSchemaSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_InqModelVerSchemaSearch_Req",
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

        public static void ADMADS_InqModelManualDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_InqModelManualDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_InqModelManualDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_InqModelManualDownload_Req",
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

        public static void ADMADS_InqEquipmentGemStatus_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_InqEquipmentGemStatus_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_InqEquipmentGemStatus_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_InqEquipmentGemStatus_Req",
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

        public static void ADMADS_SetSecs1ToHsmsEventUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetSecs1ToHsmsEventUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetSecs1ToHsmsEventUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetSecs1ToHsmsEventUpdate_Req",
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

        public static void ADMADS_SetSecs1ToHsmsConverterUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_SetSecs1ToHsmsConverterUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_SetSecs1ToHsmsConverterUpdate_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_SetSecs1ToHsmsConverterUpdate_Req",
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

        public static void ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn
            )
        {
            try
            {
                ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp(instance, fXmlNodeIn, "", 0);
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

        public static void ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            string channel,
            int ttl
            )
        {
            try
            {
                if (null == channel || channel.Trim().Equals(""))
                {
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                instance.sendMulticast(
                    "ADMADS",
                    "ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp",
                    fXmlNodeIn,
                    channel,
                    ttl
                    );
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

        public static void ADMADS_TolSecs1ToHsmsConverterLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolSecs1ToHsmsConverterLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolSecs1ToHsmsConverterLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolSecs1ToHsmsConverterLogList_Req",
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

        public static void ADMADS_TolSecs1ToHsmsConverterLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolSecs1ToHsmsConverterLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolSecs1ToHsmsConverterLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolSecs1ToHsmsConverterLogDownload_Req",
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

        public static void ADMADS_TolSecs1ToHsmsConverterLogContinue_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolSecs1ToHsmsConverterLogContinue_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolSecs1ToHsmsConverterLogContinue_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolSecs1ToHsmsConverterLogContinue_Req",
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

        public static void ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req",
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

        public static void ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req",
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

        public static void ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req",
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

        public static void ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
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

        public static void ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req(
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
                    if (null == m_admadsChannel || m_admadsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_admadsChannel;
                }
                ttl = (ttl <= 0 ? m_admadsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "ADMADS",
                    "ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req",
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
