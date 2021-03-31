/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2021 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpDeviceDriverStateChangedEventArgs.cs
--  Creator         : Sunghoon.Park
--  Create Date     : 2021.03.29
--  Description     : NexplantMC Core  FaTcpDriver Tcp Device Driver State Changed Event Arguments Class 
--  History         : Created by Sunghoon.Park at 2021.03.29
----------------------------------------------------------------------------------------------------------*/

using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FTcpDeviceDriverStateChangedEventArgs : EventArgs, IDisposable
    {
        private bool m_disposed = false;

        private FITcpDeviceDriver m_fTcpDeviceDriver = null;
        private FDeviceState m_fState = FDeviceState.Closed;

        //--
        private string m_localIp = string.Empty;
        private int m_localPort = 0;
        private string m_remoteIp = string.Empty;
        private int m_remotePort = 0;

        #region Class Construction and Destruction

        public FTcpDeviceDriverStateChangedEventArgs(
            FITcpDeviceDriver fTcpDeviceDriver,
            FDeviceState fState,
            string localIp,
            int localPort,
            string remoteIp,
            int remotePort
            )
        {
            m_fTcpDeviceDriver = fTcpDeviceDriver;
            m_fState = fState;
            m_localIp = localIp;
            m_localPort = localPort;
            m_remoteIp = remoteIp;
            m_remotePort = remotePort;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpDeviceDriverStateChangedEventArgs(
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

        public FDeviceState fState
        {
            get
            {
                try
                {
                    return m_fState;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FDeviceState.Closed;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string localIp
        {
            get
            {
                try
                {
                    return m_localIp;
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

        public int localPort
        {
            get
            {
                try
                {
                    return m_localPort;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string remoteIp
        {
            get
            {
                try
                {
                    return m_remoteIp;
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

        public int remotePort
        {
            get
            {
                try
                {
                    return m_remotePort;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }
}
