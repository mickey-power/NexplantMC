/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDeviceControlMessageReceivedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.07
--  Description     : FAMate Core FaSecsDriver SECS Device Control Message Received Event Arguments Class 
--  History         : Created by spike.lee at 2011.09.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    [Serializable]
    public class FSecsDeviceControlMessageReceivedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecsDriver m_fSecsDriver = null;
        private FSecsDevice m_fSecsDevice = null;
        private FSecsDeviceControlMessageReceivedLog m_fSecsDeviceControlMessageReceivedLog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsDeviceControlMessageReceivedEventArgs(            
            FEventId fEventId,
            FSecsDriver fSecsDriver,
            FSecsDevice fSecsDevice,
            FSecsDeviceControlMessageReceivedLog fSecsDeviceControlMessageReceivedLog            
            )
            : base(fEventId)
        {
            m_fSecsDriver = fSecsDriver;
            m_fSecsDevice = fSecsDevice;
            m_fSecsDeviceControlMessageReceivedLog = fSecsDeviceControlMessageReceivedLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsDeviceControlMessageReceivedEventArgs(
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
                    m_fSecsDriver = null;
                    m_fSecsDevice = null;
                    m_fSecsDeviceControlMessageReceivedLog = null;
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

        public FSecsDeviceControlMessageReceivedLog fSecsDeviceControlMessageReceivedLog
        {
            get
            {
                try
                {
                    return m_fSecsDeviceControlMessageReceivedLog;
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
