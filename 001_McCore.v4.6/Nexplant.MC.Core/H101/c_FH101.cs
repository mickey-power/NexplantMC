/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FH101.cs
--  Creator         : mj.kim
--  Create Date     : 2011.08.12
--  Description     : FAMate Core FaCommon Highway101 Class
--  History         : Created by mj.kim at 2011.08.12
--                               즡즈   at 2013.05.22 function add, sendUnicast(... , bool compress)
--                  : Modified by spike.lee at 2014.03.07
--                     1. 생성자 통합
--                     2. Guaranteed Message 추가 (Unicast, Multicast)
--                     3. Message Version 설정 기능 추가
--                     4. Compressed와 TRS 옵션 통합
--                    Modified by spike.lee at 2016.06.30
--                     1. send 계열 Method Overload Tuning
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using com.miracom.transceiverx;
using com.miracom.transceiverx.session;
using com.miracom.transceiverx.message;
using com.miracom.transceiverx.message.former;

namespace Nexplant.MC.Core.FaCommon
{
    public class FH101 : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        public event FH101ErrorRaisedEventHandler H101ErrorRaised = null;
        public event FH101ConnectedEventHandler H101Connected = null;
        public event FH101DisconnectedEventHandler H101Disconnected = null;

        // --

        public const string XGEN_TAG_VERSION = "VERSION";
        public const string XGEN_TAG_INTERFACE = "INTERFACE";
        public const string XGEN_TAG_MODULE = "MODULE";
        public const string XGEN_TAG_OPERATION = "OPERATION";
        public const string XGEN_TAG_TID = "TID";
        public const string XGEN_TAG_SERVICE_NAME = "_SERVICE_NAME";
        // --
        public const string XGEN_TAG_RESULT_CODE = "RESULT_CODE";
        public const string XGEN_TAG_RESULT_MSG = "RESULT_MSG";
        // --
        public const string XGEN_DEFAULT_VERSION = "4.5";
        public const int XGEN_DEFAULT_TTL = 5000;
        public const int XGEN_DEFAULT_GUARANTEED_TTL = 86400000;
        // --
        public const string INVALID_CHANNEL = "Invalid Channel";
        public const string INVALID_MESSAGE = "Invalid Message";

        // --

        private bool m_disposed = false;
        // --
        private FIDPointer32 m_fTidPointer = null;
        private Session m_session = null;
        private Hashtable m_dispatchers = null;
        private FH101MessageConsumer m_consumer = null;
        private FH101SessionEventListener m_eventListener = null;
        // --
        private string m_sessionId = string.Empty;
        private string m_connectString = string.Empty;
        private string m_version = string.Empty;
        private int m_ttl = 0;
        private int m_guaranteedTtl = 0;
        private bool m_isCompressed = false;
        private bool m_isTrs = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FH101(
            )
        {
            m_fTidPointer = new FIDPointer32();
            // --
            m_sessionId = "local";
            m_connectString = "localhost:10101";
            m_version = XGEN_DEFAULT_VERSION;
            m_ttl = XGEN_DEFAULT_TTL;
            m_guaranteedTtl = XGEN_DEFAULT_GUARANTEED_TTL;
            m_isCompressed = true;
            m_isTrs = false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FH101(
            string sessionId,
            string connectString,
            string version,
            int ttl,
            int guaranteedTtl,
            bool isCompressed,
            bool isTrs
            )
        {
            m_fTidPointer = new FIDPointer32();
            // --
            m_sessionId = sessionId;
            m_connectString = connectString;
            m_version = version;
            m_ttl = ttl;
            m_guaranteedTtl = guaranteedTtl;
            m_isCompressed = isCompressed;
            m_isTrs = isTrs;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FH101(
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
                    term();
                    // --
                    if (m_fTidPointer != null)
                    {
                        m_fTidPointer.Dispose();
                        m_fTidPointer = null;
                    }
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

        public string sessionId
        {
            get
            {
                try
                {
                    return m_sessionId;
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

        public string connectString
        {
            get
            {
                try
                {
                    return m_connectString;
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

        public string version
        {
            get
            {
                try
                {
                    return m_version;
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

        public int ttl
        {
            get
            {
                try
                {
                    return m_ttl;
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

        public int guaranteedTtl
        {
            get
            {
                try
                {
                    return m_guaranteedTtl;
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

        public bool isCompressed
        {
            get
            {
                try
                {
                    return m_isCompressed;
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

        public bool isTrs
        {
            get
            {
                try
                {
                    return m_isTrs;
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

        public bool started
        {
            get
            {
                try
                {
                    if (m_session != null && m_session.isStarted())
                    {
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal Session session
        {
            get
            {
                try
                {
                    return m_session;
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

        internal FIDPointer32 fTidPointer
        {
            get
            {
                try
                {
                    return m_fTidPointer;
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

        public bool isConnected
        {
            get
            {
                try
                {
                    return m_session.isConnected();
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void init(
            FH101StationMode mode
            )
        {
            try
            {
                if (m_session == null)
                {
                    m_dispatchers = new Hashtable();
                    m_consumer = new FH101MessageConsumer(this, m_dispatchers);
                    m_eventListener = new FH101SessionEventListener(this);
                    // --
                    m_session = Transceiver.createSession(
                        m_sessionId,
                        (mode == FH101StationMode.Inner ? Session_Fields.SESSION_INNER_STATION_MODE : Session_Fields.SESSION_INTER_STATION_MODE) | Session_Fields.SESSION_PUSH_DELIVERY_MODE
                        );
                    m_session.addMessageConsumer(m_consumer);
                    m_session.addSessionEventListener(m_eventListener);
                    m_session.setAutoRecovery(true);
                    m_session.connect(m_connectString);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwFException(
                    ex.InnerException == null ? ex.Message : ex.InnerException.Message
                    );
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void init(
            )
        {
            try
            {
                init(FH101StationMode.Inner);
            }
            catch (Exception ex)
            {
                FDebug.throwFException(ex.Message);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void term(
            )
        {
            try
            {
                if (m_session != null)
                {
                    if (m_session.isConnected())
                    {
                        m_session.disconnect();
                    }
                    // --
                    // Modify by Jeff.Kim 2018.03.27
                    // EAI 윤제경 책임 요청으로 삭제 합니다. destroy 에서 아래 작업 수행으로 중복 수행시 문제 
                    // 발생한다고 합니다. 
                    //m_session.removeMessageConsumer(m_consumer);
                    //m_session.removeSessionEventListener(m_eventListener); 
                    m_session.destroy();
                    m_session = null;
                }

                if (m_consumer != null)
                {
                    m_consumer.Dispose();
                    m_consumer = null;
                }

                if (m_eventListener != null)
                {
                    m_eventListener.Dispose();
                    m_eventListener = null;
                }

                m_dispatchers = null;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onH101Connected(
            )
        {
            try
            {
                if (H101Connected == null)
                {
                    return;
                }

                // --

                H101Connected(this);
            }
            catch
            {

            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onH101Disconnected(
            )
        {
            try
            {
                if (H101Disconnected == null)
                {
                    return;
                }

                // --

                H101Disconnected(this);
            }
            catch
            {

            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void onH101ErrorRaised(
            Exception inEx
            )
        {
            try
            {
                if (H101ErrorRaised == null)
                {
                    return;
                }

                // --

                H101ErrorRaised(this, new FH101ErrorRaisedEventArgs(this, inEx.Message, inEx));
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void registerDispatcher(
            string module,
            object tuner
            )
        {
            try
            {
                m_dispatchers.Add(module, tuner);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void unregisterDispatcher(
            string module
            )
        {
            try
            {
                if (m_dispatchers.ContainsKey(module))
                {
                    m_dispatchers.Remove(module);
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

        public void tune(
            string channel,
            bool isMulticast,
            bool isGuaranteed
            )
        {
            try
            {
                if (isMulticast)
                {
                    if (isGuaranteed)
                    {
                        m_session.tuneGuaranteedMulticast(channel);
                    }
                    else
                    {
                        m_session.tuneMulticast(channel);
                    }
                }
                else
                {
                    if (isGuaranteed)
                    {
                        m_session.tuneGuaranteedUnicast(channel);
                    }
                    else
                    {
                        m_session.tuneUnicast(channel);
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void untune(
            string channel,
            bool isMulticast,
            bool isGuaranteed
            )
        {
            try
            {
                if (!m_session.isConnected())
                {
                    return;
                }

                // --

                if (isMulticast)
                {
                    if (isGuaranteed)
                    {
                        m_session.untuneGuaranteedMulticast(channel);
                    }
                    else
                    {
                        m_session.untuneMulticast(channel);
                    }
                }
                else
                {
                    if (isGuaranteed)
                    {
                        m_session.untuneGuaranteedUnicast(channel);
                    }
                    else
                    {
                        m_session.untuneUnicast(channel);
                    }
                }
            }
            catch
            {
                // --
                // 2018.04.06 by Jeff.Kim
                // Exception 발생시 Close 안되는 현상 방지.
                //FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------    

        private Message setProperties(
            Message req, 
            string serviceName, 
            string module, 
            string operation, 
            FXmlNode property,
            UInt32 tid
            )
        {
            string name = string.Empty;
            if (req == null) return req;

            try
            {
                req.setProperty(XGEN_TAG_VERSION, m_version);
                req.setProperty(XGEN_TAG_MODULE, module);
                req.setProperty(XGEN_TAG_INTERFACE, module);
                req.setProperty(XGEN_TAG_OPERATION, operation);
                req.setProperty(XGEN_TAG_TID, tid.ToString());
                if (serviceName != string.Empty)
                {
                    req.setProperty(XGEN_TAG_SERVICE_NAME, serviceName);
                }

                // --

                // <MESSAGE>
                //   <D N=""></D>
                //   .
                //  </MESSAGE>
                if(property != null)
                {
                    foreach (FXmlNode pItem in property.fChildNodes)
                    {
                        if (pItem.innerXml != "")
                        {
                            name = pItem.get_attrVal("N");
                            req.setProperty(name, pItem.innerXml);
                        }
                        
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

            return req;
            
        }

        //------------------------------------------------------------------------------------------------------------------------        
        // Add by Jeff.Kim 2018.04.10
        // 메세지를 특정 형식으로 변형하여 보낼경우 사용하기 위해 추가
        public void sendUnicast(
            string serviceName,
            string module,
            string operation,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, null, tid);
                
                // --

                req.setDeliveryMode(DeliveryType.UNICAST);
                req.setChannel(channel);
                req.setTTL(0 < ttl ? ttl : m_ttl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl("UTF-8");
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                    }
                }

                // --

                m_session.sendUnicast(req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendUnicast(
            string serviceName,
            string module,
            string operation,
            FXmlNode property,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, property, tid);
                
                // --

                req.setDeliveryMode(DeliveryType.UNICAST);
                req.setChannel(channel);
                req.setTTL(0 < ttl ? ttl : m_ttl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl("UTF-8");
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                        //req.setData(Encoding.Default.GetBytes(data));
                    }
                }

                // --

                m_session.sendUnicast(req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------   

        public void sendUnicast(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, null, tid);
                
                // --

                req.setDeliveryMode(DeliveryType.UNICAST);
                req.setChannel(channel);
                req.setTTL(0 < ttl ? ttl : m_ttl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl("UTF-8");
                    former.writeMsgString(data.outerXml);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data.outerXml));
                    }
                    else
                    {
                        req.setData(data.outerXml);
                    }
                }

                // --

                m_session.sendUnicast(req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendUnicast(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl
            )
        {
            try
            {
                sendUnicast(serviceName, module, operation, data, channel, ttl, this.fTidPointer.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------                

        public void sendUnicast(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            try
            {
                sendUnicast(string.Empty, module, operation, data, channel, ttl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }

            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendUnicast(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl
            )
        {
            try
            {
                sendUnicast(string.Empty, module, operation, data, channel, ttl, this.fTidPointer.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        
        // Add by Jeff.Kim 2018.04.10
        // 메세지를 특정 형식으로 변형하여 보낼경우 사용하기 위해 추가
        public void sendGuaranteedUnicast(
            string module,
            string operation,
            string data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, "", module, operation, null, tid);

                // --

                req.setDeliveryMode(DeliveryType.GUARANTEED_UNICAST);
                req.setChannel(channel);
                req.setTTL(0 < guaranteedTtl ? guaranteedTtl : m_guaranteedTtl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                    }
                }

                // --

                m_session.sendGuaranteedUnicast(channel, req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendGuaranteedUnicast(
            string module,
            string operation,
            FXmlNode property,
            string data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, "", module, operation, property, tid);

                // --

                req.setDeliveryMode(DeliveryType.GUARANTEED_UNICAST);
                req.setChannel(channel);
                req.setTTL(0 < guaranteedTtl ? guaranteedTtl : m_guaranteedTtl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                    }
                }

                // --

                m_session.sendGuaranteedUnicast(channel, req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------     

        public void sendGuaranteedUnicast(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, null, tid);

                // --

                req.setDeliveryMode(DeliveryType.GUARANTEED_UNICAST);
                req.setChannel(channel);
                req.setTTL(0 < guaranteedTtl ? guaranteedTtl : m_guaranteedTtl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data.outerXml);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data.outerXml));
                    }
                    else
                    {
                        req.setData(data.outerXml);
                    }
                }

                // --

                m_session.sendGuaranteedUnicast(channel, req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendGuaranteedUnicast(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int guaranteedTtl
            )
        {
            try
            {
                sendGuaranteedUnicast(serviceName, module, operation, data, channel, guaranteedTtl, this.fTidPointer.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendGuaranteedUnicast(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            try
            {
                sendGuaranteedUnicast(string.Empty, module, operation, data, channel, guaranteedTtl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendGuaranteedUnicast(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int guaranteedTtl
            )
        {
            try
            {
                sendGuaranteedUnicast(string.Empty, module, operation, data, channel, guaranteedTtl, this.fTidPointer.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendMulticast(
            string serviceName,
            string module,
            string operation,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, null, tid);

                // --

                req.setDeliveryMode(DeliveryType.MULTICAST);
                req.setChannel(channel);
                req.setTTL(0 < ttl ? ttl : m_ttl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                    }
                }

                // --

                m_session.sendMulticast(req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendMulticast(
            string serviceName,
            string module,
            string operation,
            FXmlNode property,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, property, tid);

                // --

                req.setDeliveryMode(DeliveryType.MULTICAST);
                req.setChannel(channel);
                req.setTTL(0 < ttl ? ttl : m_ttl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                    }
                }

                // --

                m_session.sendMulticast(req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------      

        public void sendMulticast(
            string module,
            string operation,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            try
            {
                sendMulticast(string.Empty, module, operation, data, channel, ttl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendMulticast(
            string module,
            string operation,
            FXmlNode property,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            try
            {
                sendMulticast(string.Empty, module, operation, property, data, channel, ttl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendMulticast(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            try
            {
                sendMulticast(serviceName, module, operation, data.outerXml, channel, ttl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendMulticast(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl
            )
        {
            try
            {
                sendMulticast(serviceName, module, operation, data, channel, ttl, this.fTidPointer.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendMulticast(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            try
            {
                sendMulticast(string.Empty, module, operation, data, channel, ttl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendMulticast(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl
            )
        {
            try
            {
                sendMulticast(string.Empty, module, operation, data, channel, ttl, this.fTidPointer.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendGuaranteedMulticast(
            string serviceName,
            string module,
            string operation,
            string data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, null, tid);

                // --

                req.setDeliveryMode(DeliveryType.GUARANTEED_MULTICAST);
                req.setChannel(channel);
                req.setTTL(0 < guaranteedTtl ? guaranteedTtl : m_guaranteedTtl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                    }
                }

                // --

                m_session.sendGuaranteedMulticast(channel, req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendGuaranteedMulticast(
            string serviceName,
            string module,
            string operation,
            FXmlNode property,
            string data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, property, tid);

                // --

                req.setDeliveryMode(DeliveryType.GUARANTEED_MULTICAST);
                req.setChannel(channel);
                req.setTTL(0 < guaranteedTtl ? guaranteedTtl : m_guaranteedTtl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                    }
                }

                // --

                m_session.sendGuaranteedMulticast(channel, req);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendGuaranteedMulticast(
            string module,
            string operation,
            string data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            try
            {
                sendGuaranteedMulticast(string.Empty, module, operation, data, channel, guaranteedTtl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------    

        public void sendGuaranteedMulticast(
            string module,
            string operation,
            FXmlNode property,
            string data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            try
            {
                sendGuaranteedMulticast(string.Empty, module, operation, property, data, channel, guaranteedTtl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------    

        public void sendGuaranteedMulticast(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            try
            {
                sendGuaranteedMulticast(serviceName, module, operation, data.outerXml, channel, guaranteedTtl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendGuaranteedMulticast(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int guaranteedTtl
            )
        {
            try
            {
                sendGuaranteedMulticast(serviceName, module, operation, data, channel, guaranteedTtl, this.fTidPointer.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendGuaranteedMulticast(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int guaranteedTtl,
            UInt32 tid
            )
        {
            try
            {
                sendGuaranteedMulticast(string.Empty, module, operation, data, channel, guaranteedTtl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        public void sendGuaranteedMulticast(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int guaranteedTtl
            )
        {
            try
            {
                sendGuaranteedMulticast(string.Empty, module, operation, data, channel, guaranteedTtl, this.fTidPointer.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode sendRequest(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            bool async,
            UInt32 tid
            )
        {
            Message req = null;
            Message rep = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, null, tid);

                // --

                req.setDeliveryMode(DeliveryType.REQUEST);
                req.setChannel(channel);
                req.setTTL(0 < ttl ? ttl : m_ttl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data.outerXml);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data.outerXml));
                    }
                    else
                    {
                        req.setData(data.outerXml);
                    }
                }

                // --

                rep = m_consumer.requestReply(req, async);
                if (rep.getProperty(FH101.XGEN_TAG_RESULT_CODE) != null)
                {
                    FDebug.throwFException(
                        (string)rep.getProperty(FH101.XGEN_TAG_RESULT_MSG) + "(" + (string)rep.getProperty(FH101.XGEN_TAG_RESULT_CODE) + ")"
                        );
                }

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl(rep.getData());
                    return FDataConvert.stringToXmlNode(former.readMsgString());
                }

                if (m_isCompressed)
                {
                    return FDataConvert.stringToXmlNode(F7Zip.decompress(rep.getDataAsString()));
                }
                return FDataConvert.stringToXmlNode(rep.getDataAsString());
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
                rep = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode sendRequest(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            bool async
            )
        {
            try
            {
                return sendRequest(serviceName, module, operation, data, channel, ttl, async, this.fTidPointer.uniqueId);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode sendRequest(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            bool async,
            UInt32 tid
            )
        {
            try
            {
                return sendRequest(string.Empty, module, operation, data, channel, ttl, async, tid);
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode sendRequest(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            bool async
            )
        {
            try
            {
                return sendRequest(string.Empty, module, operation, data, channel, ttl, async, this.fTidPointer.uniqueId);
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

        //------------------------------------------------------------------------------------------------------------------------

        public void sendRequestAsync(
            string serviceName,
            string module,
            string operation,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, null, tid);

                // --

                req.setDeliveryMode(DeliveryType.REQUEST);
                req.setChannel(channel);
                req.setTTL(0 < ttl ? ttl : m_ttl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                    }
                }

                // --

                m_session.sendRequestAsync(req, null);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendRequestAsync(
            string module,
            string operation,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            try
            {
                sendRequestAsync(string.Empty, module, operation, data, channel, ttl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendRequestAsync(
            string module,
            string operation,
            FXmlNode property,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            try
            {
                sendRequestAsync(string.Empty, module, operation, property, data, channel, ttl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void sendRequestAsync(
            string serviceName,
            string module,
            string operation,
            FXmlNode property,
            string data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            Message req = null;
            StreamTransformer former = null;

            try
            {
                req = m_session.createMessage();
                req = setProperties(req, serviceName, module, operation, property, tid);

                // --

                req.setDeliveryMode(DeliveryType.REQUEST);
                req.setChannel(channel);
                req.setTTL(0 < ttl ? ttl : m_ttl);

                // --

                if (m_isTrs)
                {
                    former = new StreamTransformerImpl();
                    former.writeMsgString(data);
                    req.setData(former.getBytes());
                }
                else
                {
                    if (m_isCompressed)
                    {
                        req.setData(F7Zip.compress(data));
                    }
                    else
                    {
                        req.setData(data);
                    }
                }

                // --

                m_session.sendRequestAsync(req, null);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                req = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.03.06 by spike.lee
        // HostDriver 전용
        // ***
        public void sendRequestAsync(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            try
            {
                sendRequestAsync(serviceName, module, operation, data.outerXml, channel, ttl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.03.06 by spike.lee
        // HostDriver 전용
        // ***
        public void sendRequestAsync(
            string serviceName,
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl
            )
        {
            try
            {
                sendRequestAsync(serviceName, module, operation, data, channel, ttl, this.fTidPointer.uniqueId);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.03.06 by spike.lee
        // HostDriver 전용
        // ***
        public void sendRequestAsync(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl,
            UInt32 tid
            )
        {
            try
            {
                sendRequestAsync(string.Empty, module, operation, data, channel, ttl, tid);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        // ***
        // 2014.03.06 by spike.lee
        // HostDriver 전용
        // ***
        public void sendRequestAsync(
            string module,
            string operation,
            FXmlNode data,
            string channel,
            int ttl
            )
        {
            try
            {
                sendRequestAsync(string.Empty, module, operation, data, channel, ttl, this.fTidPointer.uniqueId);
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
