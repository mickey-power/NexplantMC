/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FOpcDeviceDataMessageReadEventArgs.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.09.10
--  Description     : FAMate Core FaOpcDriver OPC Device Data Message Read Event Arguments Class 
--  History         : Created by jungyoul.moon at 2013.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    [Serializable]
    public class FOpcDeviceDataMessageReadEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FOpcDriver m_fOpcDriver = null;
        private FOpcDevice m_fOpcDevice = null;
        private FOpcSession m_fOpcSession = null;
        private FOpcDeviceDataMessageReadLog m_fOpcDeviceDataMessageReadLog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FOpcDeviceDataMessageReadEventArgs(            
            FEventId fEventId,
            FOpcDriver fOpcDriver,
            FOpcDevice fOpcDevice,
            FOpcSession fOpcSession,
            FOpcDeviceDataMessageReadLog fOpcDeviceDataMessageReadLog
            )
            : base(fEventId)
        {
            m_fOpcDriver = fOpcDriver;
            m_fOpcDevice = fOpcDevice;
            m_fOpcSession = fOpcSession;
            m_fOpcDeviceDataMessageReadLog = fOpcDeviceDataMessageReadLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FOpcDeviceDataMessageReadEventArgs(
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
                    m_fOpcDriver = null;
                    m_fOpcDevice = null;
                    m_fOpcSession = null;
                    m_fOpcDeviceDataMessageReadLog = null;
                }                

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FOpcDriver fOpcDriver
        {
            get
            {
                try
                {
                    return m_fOpcDriver;
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

        public FOpcDevice fOpcDevice
        {
            get
            {
                try
                {
                    return m_fOpcDevice;
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

        public FOpcSession fOpcSession
        {
            get
            {
                try
                {
                    return m_fOpcSession;
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

        public FOpcDeviceDataMessageReadLog fOpcDeviceDataMessageReadLog
        {
            get
            {
                try
                {
                    return m_fOpcDeviceDataMessageReadLog;
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
