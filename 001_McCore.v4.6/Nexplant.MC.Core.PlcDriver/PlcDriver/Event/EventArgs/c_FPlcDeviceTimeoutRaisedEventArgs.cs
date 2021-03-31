/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcDeviceTimeoutRaisedEventArgs.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.25
--  Description     : FAMate Core FaPlcDriver PLC Device Timeout Raised Event Arguments Class 
--  History         : Created by Jeff.Kim at 2013.07.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    [Serializable]
    public class FPlcDeviceTimeoutRaisedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPlcDriver m_fPlcDriver = null;
        private FPlcDevice m_fPlcDevice = null;
        private FPlcDeviceTimeoutRaisedLog m_fPlcDeviceTimeoutRaisedLog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FPlcDeviceTimeoutRaisedEventArgs(            
            FEventId fEventId,
            FPlcDriver fPlcDriver,
            FPlcDevice fPlcDevice,
            FPlcDeviceTimeoutRaisedLog fPlcDeviceTimeoutRaisedLog            
            )
            : base(fEventId)
        {
            m_fPlcDriver = fPlcDriver;
            m_fPlcDevice = fPlcDevice;
            m_fPlcDeviceTimeoutRaisedLog = fPlcDeviceTimeoutRaisedLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcDeviceTimeoutRaisedEventArgs(
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
                    m_fPlcDeviceTimeoutRaisedLog = null;
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

        public FPlcDeviceTimeoutRaisedLog fPlcDeviceTimeoutRaisedLog
        {
            get
            {
                try
                {
                    return m_fPlcDeviceTimeoutRaisedLog;
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
