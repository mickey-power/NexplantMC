/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcDeviceDataMessageReadEventArgs.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.09.10
--  Description     : FAMate Core FaPlcDriver PLC Device Data Message Read Event Arguments Class 
--  History         : Created by jungyoul.moon at 2013.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    [Serializable]
    public class FPlcDeviceDataMessageReadEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPlcDriver m_fPlcDriver = null;
        private FPlcDevice m_fPlcDevice = null;
        private FPlcSession m_fPlcSession = null;
        private FPlcDeviceDataMessageReadLog m_fPlcDeviceDataMessageReadLog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FPlcDeviceDataMessageReadEventArgs(            
            FEventId fEventId,
            FPlcDriver fPlcDriver,
            FPlcDevice fPlcDevice,
            FPlcSession fPlcSession,
            FPlcDeviceDataMessageReadLog fPlcDeviceDataMessageReadLog
            )
            : base(fEventId)
        {
            m_fPlcDriver = fPlcDriver;
            m_fPlcDevice = fPlcDevice;
            m_fPlcSession = fPlcSession;
            m_fPlcDeviceDataMessageReadLog = fPlcDeviceDataMessageReadLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcDeviceDataMessageReadEventArgs(
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
                    m_fPlcDriver = null;
                    m_fPlcDevice = null;
                    m_fPlcSession = null;
                    m_fPlcDeviceDataMessageReadLog = null;
                }                

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FPlcDriver fPlcDriver
        {
            get
            {
                try
                {
                    return m_fPlcDriver;
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

        public FPlcDevice fPlcDevice
        {
            get
            {
                try
                {
                    return m_fPlcDevice;
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

        public FPlcSession fPlcSession
        {
            get
            {
                try
                {
                    return m_fPlcSession;
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

        public FPlcDeviceDataMessageReadLog fPlcDeviceDataMessageReadLog
        {
            get
            {
                try
                {
                    return m_fPlcDeviceDataMessageReadLog;
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
