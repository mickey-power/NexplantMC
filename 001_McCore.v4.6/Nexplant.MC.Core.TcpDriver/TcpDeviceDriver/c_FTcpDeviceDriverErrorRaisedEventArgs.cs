/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2021 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpDeviceDriverStateChangedEventArgs.cs
--  Creator         : Sunghoon.Park
--  Create Date     : 2021.03.31
--  Description     : NexplantMC Core FaTcpDriver Tcp Device Driver Error Raised Event Arguments Class 
--  History         : Created by Sunghoon.Park at 2021.03.31
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpDeviceDriverErrorRaisedEventArgs : EventArgs, IDisposable
    {
        private bool m_disposed = false;

        private FITcpDeviceDriver m_fTcpDeviceDriver = null;
        private FResultCode m_fResultCode = FResultCode.Error;
        private string m_errorMessage = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpDeviceDriverErrorRaisedEventArgs(
            FITcpDeviceDriver fTcpDeviceDriver,
            FResultCode fResultCode,
            string errorMessage
            )
        {
            m_fTcpDeviceDriver = fTcpDeviceDriver;
            m_fResultCode = fResultCode;
            m_errorMessage = errorMessage;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpDeviceDriverErrorRaisedEventArgs(
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
                    m_fTcpDeviceDriver = null;
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

        public FITcpDeviceDriver fTcpDeviceDriver
        {
            get
            {
                try
                {
                    return m_fTcpDeviceDriver;
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

        public FResultCode fResultCode
        {
            get
            {
                try
                {
                    return m_fResultCode;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FResultCode.Error;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string errorMessage
        {
            get
            {
                try
                {
                    return m_errorMessage;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion
    }
}
