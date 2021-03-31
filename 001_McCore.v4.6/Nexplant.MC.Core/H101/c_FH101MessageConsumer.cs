/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FH101MessageConsumer.cs
--  Creator         : mj.kim
--  Create Date     : 2011.08.30
--  Description     : FAMate Core FaCommon Highway101 MessageConsumer Class
--  History         : Created by mj.kim at 2011.08.30
--                  : Modified by spike.lee at 2011.11.17
--                     1. Async 용 Request/Reply Method 추가
--                     2. onReply, onTimeout 구현
--                    Modified by spike.lee at 2014.03.07
--                     1. 비동기/동기 RequestReply Method 수정
--                        - RequestPool, RequestThread 제거
--                        - 내부 Thread로 비동기 구현 
                       2. Multi Thread 작업 시, Reply Message가 바뀌거나 사라지는 버그 수정                      
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Reflection;
using com.miracom.transceiverx.session;
using com.miracom.transceiverx.message;

namespace Nexplant.MC.Core.FaCommon
{
    internal class FH101MessageConsumer : MessageConsumer, IDisposable 
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FH101 m_fH101 = null;
        private Hashtable m_dispatchers = null;
        private string m_status_message = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FH101MessageConsumer(
            FH101 fH101,
            Hashtable dispatchers
            )
        {
            m_fH101 = fH101;
            m_dispatchers = dispatchers;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FH101MessageConsumer(
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
                    m_dispatchers = null;
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

        public string statusMessage
        {
            get
            {
                try
                {
                    return m_status_message;
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
                    m_status_message = value;
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

        private void requestReplyAsyncThread(
            object ar
            )
        {
            FH101RequestReplyData fData = null;

            try
            {
                fData = (FH101RequestReplyData)ar;
                procRequestReply(fData);
            }
            catch (Exception ex)
            {
                fData.message = ex.Message;
                fData.result = false;                
                fData.completed = true;
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void procRequestReply(
            FH101RequestReplyData fData
            )
        {
            try
            {
                fData.rep = m_fH101.session.sendRequest(fData.req);                
                // --
                fData.result = true;
                fData.completed = true;
            }
            catch (Exception ex)
            {
                if (ex.Message == SessionException.CHANNEL_NOTFOUND_TUNER)
                {
                    fData.message = "Not found Replier";
                }
                else if (ex.Message == SessionException.TIMEOUT)
                {
                    fData.message = "Request Reply Timeout";
                }
                else
                {
                    fData.message = ex.Message;
                }
                // --
                fData.result = false;
                fData.completed = true;
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void sendReply(            
            Message req,
            Message rep,
            string errCode,
            string errMessage
            )
        {
            try
            {
                rep.setProperty(FH101.XGEN_TAG_RESULT_CODE, errCode);
                rep.setProperty(FH101.XGEN_TAG_RESULT_MSG, errMessage);
                m_fH101.session.sendReply(req, rep);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Message requestReply(            
            Message req,            
            bool async
            )
        {
            FH101RequestReplyData fData = null;
            Thread asyncThread = null;            

            try
            {
                fData = new FH101RequestReplyData(req);

                // --

                asyncThread = new Thread(new ParameterizedThreadStart(requestReplyAsyncThread));
                asyncThread.Start(fData);
                // --
                while (!fData.completed)
                {
                    if (async)
                    {
                        System.Windows.Forms.Application.DoEvents();
                    }
                    System.Threading.Thread.Sleep(1);
                }                

                // --

                if (!fData.result)
                {
                    FDebug.throwFException(fData.message);
                }
                
                // --

                return fData.rep; 
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (fData != null)
                {
                    fData.Dispose();
                    fData = null;
                }
                asyncThread = null;
            }
            return null;
        }
        
        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region MessageConsumer 멤버

        public void onUnicast(      
            Session session, 
            Message msg
            )
        {
            FIH101Dispatcher tuner = null;
            string version = null;
            string module = null;
            UInt32 tid = 0;
            string strTid = string.Empty;            

            try
            {
                // ***
                // 2014.03.11 by spike.lee
                // 추후 Version Validation 추가
                // ***
                version = (string)msg.getProperty(FH101.XGEN_TAG_VERSION);
                //if (string.IsNullOrEmpty(version) || version != m_fH101.version)
                //{
                //    FDebug.throwFException(string.Format("Unexpected Version!(Version:{0})", version));
                //}

                // --

                module = (string)msg.getProperty(FH101.XGEN_TAG_MODULE);
                if (string.IsNullOrEmpty(module) || !m_dispatchers.ContainsKey(module))
                {
                    FDebug.throwFException(string.Format("Unexpected Module!(Module:{0})", module));
                }                                                

                // --
                
                strTid = (string)msg.getProperty(FH101.XGEN_TAG_TID);
                if (string.IsNullOrEmpty(strTid) || !UInt32.TryParse(strTid, out tid))
                {
                    tid = m_fH101.fTidPointer.uniqueId;
                }                
                
                // --

                tuner = (FIH101Dispatcher)m_dispatchers[module];
                tuner.dispatch(new FH101DataReceivedArgs(m_fH101, msg, msg.getChannel(), tid));
            }
            catch (Exception ex)
            {
                m_fH101.onH101ErrorRaised(ex);
            }
            finally
            {
                tuner = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void onMulticast(
            Session session, 
            Message msg
            )
        {
            try
            {
                onUnicast(session, msg);
            }
            catch (Exception ex)
            {
                m_fH101.onH101ErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void onGUnicast(
            Session session, 
            Message msg
            )
        {
            try
            {
                onUnicast(session, msg);
            }
            catch (Exception ex)
            {
                m_fH101.onH101ErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void onGMulticast(
            Session session,
            Message msg
            )
        {
            try
            {
                onUnicast(session, msg);
            }
            catch (Exception ex)
            {
                m_fH101.onH101ErrorRaised(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void onRequest(
            Session session, 
            Message msg
            )
        {
            FIH101Dispatcher tuner = null;
            string version = null;
            string module = null;
            UInt32 tid = 0;
            string strTid = string.Empty;            

            try
            {
                // ***
                // 2014.03.11 by spike.lee
                // 추후 Version Validation 추가
                // ***
                version = (string)msg.getProperty(FH101.XGEN_TAG_VERSION);
                //if (string.IsNullOrEmpty(version) || version != m_fH101.version)
                //{
                //    sendReply(msg, msg.createReply(), "-21", "Unexpected Version!");
                //    FDebug.throwFException(string.Format("Unexpected Version!(Version:{0})", version));
                //}

                // --

                module = (string)msg.getProperty(FH101.XGEN_TAG_MODULE);
                if (string.IsNullOrEmpty(module) || !m_dispatchers.ContainsKey(module))
                {
                    sendReply(msg, msg.createReply(), "-22", "Unexpected Module!");
                    FDebug.throwFException(string.Format("Unexpected Module!(Module:{0})", module));
                }

                // --

                strTid = (string)msg.getProperty(FH101.XGEN_TAG_TID);
                if (string.IsNullOrEmpty(strTid) || !UInt32.TryParse(strTid, out tid))
                {
                    tid = m_fH101.fTidPointer.uniqueId;
                }       

                // --

                tuner = (FIH101Dispatcher)m_dispatchers[module];
                tuner.dispatch(new FH101DataReceivedArgs(m_fH101, msg, msg.getChannel(), tid));
            }
            catch (Exception ex)
            {
                m_fH101.onH101ErrorRaised(ex);
            }
            finally
            {
                tuner = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void onReply(
            Session session, 
            Message req, 
            Message rep, 
            object hint
            )
        {
            FIH101Dispatcher tuner = null;
            string version = null;
            string module = null;
            UInt32 tid = 0;
            string strTid = string.Empty;            

            try
            {
                // ***
                // 2014.03.11 by spike.lee
                // 추후 Version Validation 추가
                // ***
                version = (string)req.getProperty(FH101.XGEN_TAG_VERSION);
                //if (string.IsNullOrEmpty(version) || version != m_fH101.version)
                //{
                //    FDebug.throwFException(string.Format("Unexpected Version!(Version:{0})", version));
                //}

                // --

                module = (string)req.getProperty(FH101.XGEN_TAG_MODULE);
                if (string.IsNullOrEmpty(module) || !m_dispatchers.ContainsKey(module))
                {
                    FDebug.throwFException(string.Format("Unexpected Module!(Module:{0})", module));                    
                }

                // --

                strTid = (string)req.getProperty(FH101.XGEN_TAG_TID);
                if (string.IsNullOrEmpty(strTid) || !UInt32.TryParse(strTid, out tid))
                {
                    tid = m_fH101.fTidPointer.uniqueId;
                }    

                // --

                tuner = (FIH101Dispatcher)m_dispatchers[module];
                tuner.dispatch(new FH101DataReceivedArgs(m_fH101, rep, req.getChannel(), tid));
            }
            catch (Exception ex)
            {
                m_fH101.onH101ErrorRaised(ex);
            }
            finally
            {
                tuner = null;
            }        
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void onTimeout(
            Session sensor, 
            Message req
            )
        {
            try
            {
                FDebug.throwFException("Request Reply Timeout");
            }
            catch (Exception ex)
            {
                m_fH101.onH101ErrorRaised(ex);
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end

