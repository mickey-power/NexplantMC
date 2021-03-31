/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDeviceTelnetPacketSentEventArgs.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2012.02.08
--  Description     : FAMate Core FaSecsDriver SECS Device TELNET Packet Sent Event Arguments Class 
--  History         : Created by byungyun.jeon at 2012.02.08
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    [Serializable]
    public class FSecsDeviceTelnetPacketSentEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // -- 
        private FSecsDriver m_fSecsDriver = null;
        private FSecsDevice m_fSecsDevice = null;
        private FSecsDeviceTelnetPacketSentLog m_fSecsDeviceTelnetPacketSentLog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Contruction and Destruction

        internal FSecsDeviceTelnetPacketSentEventArgs(
            FEventId fEventId,
            FSecsDriver fSecsDriver,
            FSecsDevice fSecsDevice,
            FSecsDeviceTelnetPacketSentLog fSecsDeviceTelnetPacketSentLog
            )
            : base(fEventId)
        {
            m_fSecsDriver = fSecsDriver;
            m_fSecsDevice = fSecsDevice;
            m_fSecsDeviceTelnetPacketSentLog = fSecsDeviceTelnetPacketSentLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsDeviceTelnetPacketSentEventArgs(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fSecsDriver = null;
                    m_fSecsDevice = null;
                    m_fSecsDeviceTelnetPacketSentLog = null;
                }
                m_disposed = true;

                // -- 

                base.myDispose(disposing);
            }            
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FSecsDriver fSecsDriver
        {
            get
            {
                try
                {
                    return m_fSecsDriver;
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

        public FSecsDevice fSecsDevice
        {
            get
            {
                try
                {
                    return m_fSecsDevice;
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

        public FSecsDeviceTelnetPacketSentLog fSecsDeviceTelnetPacketSentLog
        {
            get
            {
                try
                {
                    return m_fSecsDeviceTelnetPacketSentLog;
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
