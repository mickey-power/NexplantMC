/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FH101DataReceivedArgs.cs
--  Creator         : mj.kim
--  Create Date     : 2011.08.29
--  Description     : FAMate Core FaCommon Highway101 Data Received Arguments Class
--  History         : Created by mj.kim at 2011.08.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using com.miracom.transceiverx.session;
using com.miracom.transceiverx.message;
using com.miracom.transceiverx.message.former;

namespace Nexplant.MC.Core.FaCommon
{
    public class FH101DataReceivedArgs : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FH101 m_fH101 = null;
        private Message m_message = null;
        private string m_channel = string.Empty;
        private UInt32 m_tid = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FH101DataReceivedArgs(
            FH101 fH101,
            Message message,
            string channel,
            UInt32 tid
            )
        {
            m_fH101 = fH101;
            m_message = message;
            m_channel = channel;
            m_tid = tid;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FH101DataReceivedArgs(
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
                    m_fH101 = null;
                    m_message = null;
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

        public string operation
        {
            get
            {
                string value = string.Empty;

                try
                {
                    value = (string)m_message.getProperty(FH101.XGEN_TAG_SERVICE_NAME);
                    if (value == null)
                    {
                        value = (string)m_message.getProperty(FH101.XGEN_TAG_OPERATION);
                    }
                    if (value == null)
                    {
                        value = (string)m_message.getProperty("SERVICE_INFO");
                    }
                    return value;
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

        public string dataToString
        {
            get
            {
                StreamTransformer former = null;

                try
                {
                    if (m_fH101.isTrs)
                    {
                        former = new StreamTransformerImpl(m_message.getData(), "UTF-8");
                        return former.readMsgString();
                    }

                    if (m_fH101.isCompressed)
                    {
                        return F7Zip.decompress(m_message.getDataAsString());
                    }

                    return m_message.getDataAsString();
                    //return Encoding.Default.GetString(m_message.getData());
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

        public FXmlNode dataToXmlNode
        {
            get
            {
                try
                {
                    return FDataConvert.stringToXmlNode(m_fH101.isTrs, this.dataToString);
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

        public string channel
        {
            get
            {
                try
                {
                    return m_channel;
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

        public UInt32 tid
        {
            get
            {
                try
                {
                    return m_tid;
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

        public bool isRequest
        {
            get
            {
                try
                {
                    return DeliveryType.isRequest(m_message.getDeliveryMode());
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

        public bool isReply
        {
            get
            {
                try
                {
                    return DeliveryType.isReply(m_message.getDeliveryMode());
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

        public bool isUnicast
        {
            get
            {
                try
                {
                    return DeliveryType.isUnicast(m_message.getDeliveryMode());
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

        public bool isGuaranteedUnicast
        {
            get
            {
                try
                {
                    return DeliveryType.isGuaranteedUnicast(m_message.getDeliveryMode());
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

        public bool isMulticast
        {
            get
            {
                try
                {
                    return DeliveryType.isMulticast(m_message.getDeliveryMode());
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

        public bool isGuaranteedMulticast
        {
            get
            {
                try
                {
                    return DeliveryType.isGuaranteedMulticast(m_message.getDeliveryMode());
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

        public FH101DeliveryType fDeliveryType
        {
            get
            {
                try
                {
                    if (this.isRequest)
                    {
                        return FH101DeliveryType.Request;
                    }
                    else if (this.isReply)
                    {
                        return FH101DeliveryType.Reply;
                    }
                    else if (this.isUnicast)
                    {
                        return FH101DeliveryType.Unicast;
                    }
                    else if (this.isGuaranteedUnicast)
                    {
                        return FH101DeliveryType.GuaranteedUnicast;
                    }
                    else if (this.isMulticast)
                    {
                        return FH101DeliveryType.Mulitcast;
                    }
                    return FH101DeliveryType.GuaranteedMulticast;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FH101DeliveryType.Request;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void sendReply(
            string errCode,
            string errMessage
            )
        {
            Message rep = null;

            try
            {
                rep = m_message.createReply();
                rep.setProperty(FH101.XGEN_TAG_RESULT_CODE, errCode);
                rep.setProperty(FH101.XGEN_TAG_RESULT_MSG, errMessage);
                m_fH101.session.sendReply(m_message, rep);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                rep = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendReply(
            string data
            )
        {
            Message rep = null;
            StreamTransformer former = null;

            try
            {
                rep = m_message.createReply();

                // --

                if (m_fH101.isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data);
                    rep.setData(former.getBytes());
                }
                else
                {
                    if (m_fH101.isCompressed)
                    {
                        rep.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        rep.setData(data);
                    }
                }

                // --

                m_fH101.session.sendReply(m_message, rep);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                rep = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendReply(
            FXmlNode data
            )
        {
            try
            {
                sendReply(data.outerXml);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        // 삭제 대상
        public void sendReplyTrs(
            FXmlNode data
            )
        {
            StreamTransformer former = null;
            Message rep = null;
            string repData = string.Empty;

            try
            {
                rep = m_message.createReply();

                // --

                repData = data.outerXml;
                // --
                former = new StreamTransformerImpl();
                former.writeMsgString(repData);
                rep.setData(former.getBytes());

                // --

                m_fH101.session.sendReply(m_message, rep);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                rep = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end