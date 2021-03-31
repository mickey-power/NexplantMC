/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostDeviceVfeiReceivedEventArgs.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaPlcDriver Host Device VFEI Received Event Arguments Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    [Serializable]
    public class FHostDeviceVfeiReceivedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPlcDriver m_fPlcDriver = null;
        private FHostDevice m_fHostDevice = null;
        private FHostDeviceVfeiReceivedLog m_fHostDeviceVfeiReceivedLog = null;
        private string m_vfei = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FHostDeviceVfeiReceivedEventArgs(            
            FEventId fEventId,
            FPlcDriver fPlcDriver,
            FHostDevice fHostDevice,
            FHostDeviceVfeiReceivedLog fHostDeviceVfeiReceivedLog,
            string vfei
            )
            : base(fEventId)
        {
            m_fPlcDriver = fPlcDriver;
            m_fHostDevice = fHostDevice;
            m_fHostDeviceVfeiReceivedLog = fHostDeviceVfeiReceivedLog;
            m_vfei = vfei;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostDeviceVfeiReceivedEventArgs(
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
                    m_fHostDevice = null;
                    m_fHostDeviceVfeiReceivedLog = null;
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

        public FHostDevice fHostDevice
        {
            get
            {
                try
                {
                    return m_fHostDevice;
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

        public FHostDeviceVfeiReceivedLog fHostDeviceVfeiReceivedLog
        {
            get
            {
                try
                {
                    return m_fHostDeviceVfeiReceivedLog;
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

        public string vfei
        {
            get
            {
                try
                {
                    return m_vfei;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
