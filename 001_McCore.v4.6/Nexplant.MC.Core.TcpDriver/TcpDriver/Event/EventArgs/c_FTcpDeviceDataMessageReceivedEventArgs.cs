/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpDeviceDataMessageReceivedEventArgs.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.09.10
--  Description     : FAMate Core FaTcpDriver TCP Device Data Message Received Event Arguments Class 
--  History         : Created by jungyoul.moon at 2013.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    [Serializable]
    public class FTcpDeviceDataMessageReceivedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpDriver m_fTcpDriver = null;
        private FTcpDevice m_fTcpDevice = null;
        private FTcpSession m_fTcpSession = null;
        private FTcpDeviceDataMessageReceivedLog m_fTcpDeviceDataMessageReceivedLog = null;
        private FTcpMessage m_fReplyTcpMessage = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FTcpDeviceDataMessageReceivedEventArgs(            
            FEventId fEventId,
            FTcpDriver fTcpDriver,
            FTcpDevice fTcpDevice,
            FTcpSession fTcpSession,
            FTcpDeviceDataMessageReceivedLog fTcpDeviceDataMessageReceivedLog,
            FTcpMessage fReplyTcpMessage
            )
            : base(fEventId)
        {
            m_fTcpDriver = fTcpDriver;
            m_fTcpDevice = fTcpDevice;
            m_fTcpSession = fTcpSession;
            m_fTcpDeviceDataMessageReceivedLog = fTcpDeviceDataMessageReceivedLog;
            m_fReplyTcpMessage = fReplyTcpMessage;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpDeviceDataMessageReceivedEventArgs(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fTcpDriver = null;
                    m_fTcpDevice = null;
                    m_fTcpSession = null;
                    m_fTcpDeviceDataMessageReceivedLog = null;
                    m_fReplyTcpMessage = null;
                }                

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FTcpDriver fTcpDriver
        {
            get
            {
                try
                {
                    return m_fTcpDriver;
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

        public FTcpDevice fTcpDevice
        {
            get
            {
                try
                {
                    return m_fTcpDevice;
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

        public FTcpSession fTcpSession
        {
            get
            {
                try
                {
                    return m_fTcpSession;
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

        public FTcpDeviceDataMessageReceivedLog fTcpDeviceDataMessageReceivedLog
        {
            get
            {
                try
                {
                    return m_fTcpDeviceDataMessageReceivedLog;
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

        public FTcpMessage fReplyTcpMessage
        {
            get
            {
                try
                {
                    return m_fReplyTcpMessage;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
