/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcDeviceErrorRaisedEventArgs.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2011.09.09
--  Description     : FAMate Core FaPlcDriver PLC Device Error Raised Event Arguments Class 
--  History         : Created by Jeff.Kim at 2011.09.09
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    [Serializable]
    public class FPlcDeviceErrorRaisedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPlcDriver m_fPlcDriver = null;
        private FPlcDevice m_fPlcDevice = null;
        private FPlcDeviceErrorRaisedLog m_fPlcDeviceErrorRaisedLog = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FPlcDeviceErrorRaisedEventArgs(            
            FEventId fEventId,
            FPlcDriver fPlcDriver,
            FPlcDevice fPlcDevice,
            FPlcDeviceErrorRaisedLog fPlcDeviceErrorRaisedLog            
            )
            : base(fEventId)
        {
            m_fPlcDriver = fPlcDriver;
            m_fPlcDevice = fPlcDevice;
            m_fPlcDeviceErrorRaisedLog = fPlcDeviceErrorRaisedLog;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcDeviceErrorRaisedEventArgs(
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
                    m_fPlcDeviceErrorRaisedLog = null;
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

        public FPlcDeviceErrorRaisedLog fPlcDeviceErrorRaisedLog
        {
            get
            {
                try
                {
                    return m_fPlcDeviceErrorRaisedLog;
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
