/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSQMSQSCaster.cs 
--  Creator         : TJ.Kim
--  Create Date     : 2013.10.15
--  Description     : <Generated Class File Description>
--  History         : Created by TJ.Kim at 2013.10.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.H101Interface
{
    internal class FSQMSQSCaster : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private static string m_sqmsqsChannel = string.Empty;
        private static int m_sqmsqsTtl = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSQMSQSCaster(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSQMSQSCaster(
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

        public static string sqmsqsChannel
        {
            get
            {
                try
                {
                    return m_sqmsqsChannel;
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
                    m_sqmsqsChannel = value;
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

        public static int sqmsqsTtl
        {
            get
            {
                try
                {
                    return m_sqmsqsTtl;
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
                    m_sqmsqsTtl = value;
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

        public static void SQMSQS_SetSystemList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetSystemList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetSystemList_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetSystemList_Req",
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

        public static void SQMSQS_SetSystemSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetSystemSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetSystemSearch_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetSystemSearch_Req",
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

        public static void SQMSQS_SetSystemUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetSystemUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetSystemUpdate_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetSystemUpdate_Req",
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

        public static void SQMSQS_SetSystemDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetSystemDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetSystemDownload_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetSystemDownload_Req",
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

        public static void SQMSQS_SetSystemMigration_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetSystemMigration_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetSystemMigration_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetSystemMigration_Req",
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

        public static void SQMSQS_SetModuleList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetModuleList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetModuleList_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetModuleList_Req",
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

        public static void SQMSQS_SetModuleSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetModuleSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetModuleSearch_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetModuleSearch_Req",
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

        public static void SQMSQS_SetModuleUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetModuleUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetModuleUpdate_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetModuleUpdate_Req",
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

        public static void SQMSQS_SetFunctionList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetFunctionList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetFunctionList_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetFunctionList_Req",
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

        public static void SQMSQS_SetFunctionSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetFunctionSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetFunctionSearch_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetFunctionSearch_Req",
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

        public static void SQMSQS_SetFunctionUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetFunctionUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetFunctionUpdate_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetFunctionUpdate_Req",
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

        public static void SQMSQS_SetSqlCodeList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetSqlCodeList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetSqlCodeList_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetSqlCodeList_Req",
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

        public static void SQMSQS_SetSqlCodeSearch_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetSqlCodeSearch_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetSqlCodeSearch_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetSqlCodeSearch_Req",
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

        public static void SQMSQS_SetSqlCodeUpdate_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_SetSqlCodeUpdate_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_SetSqlCodeUpdate_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_SetSqlCodeUpdate_Req",
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

        public static void SQMSQS_TolSqlCodeExecute_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_TolSqlCodeExecute_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_TolSqlCodeExecute_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_TolSqlCodeExecute_Req",
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

        public static void SQMSQS_TolMove_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_TolMove_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_TolMove_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_TolMove_Req",
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

        public static void SQMSQS_ViwSqlServiceLogList_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_ViwSqlServiceLogList_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_ViwSqlServiceLogList_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_ViwSqlServiceLogList_Req",
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

        public static void SQMSQS_ViwSqlServiceLogDownload_Req(
            FH101 instance,
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            )
        {
            try
            {
                SQMSQS_ViwSqlServiceLogDownload_Req(instance, fXmlNodeIn, ref fXmlNodeOut, "", 0);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void SQMSQS_ViwSqlServiceLogDownload_Req(
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
                    if (null == m_sqmsqsChannel || m_sqmsqsChannel.Trim().Equals(""))
                    {
                        FDebug.throwFException(FH101.INVALID_CHANNEL);
                    }
                    channel = m_sqmsqsChannel;
                }
                ttl = (ttl <= 0 ? m_sqmsqsTtl : ttl);

                fXmlNodeOut = instance.sendRequest(
                    "SQMSQS",
                    "SQMSQS_ViwSqlServiceLogDownload_Req",
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
