/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpDeviceDataSentEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2016.04.15
--  Description     : FAMate Core FaSecsDriver TCP Device Data Sent Event Arguments Class 
--  History         : Created by spike.lee at 2016.04.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    [Serializable]
    public class FTcpDeviceDataSentEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpDriver m_fTcpDriver = null;
        private FTcpDevice m_fTcpDevice = null;
        private FTcpDeviceDataSentLog m_fTcpDeviceDataSentLog = null;
        private byte[] m_data = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FTcpDeviceDataSentEventArgs(            
            FEventId fEventId,
            FTcpDriver fTcpDriver,
            FTcpDevice fTcpDevice,
            FTcpDeviceDataSentLog fTcpDeviceDataSentLog,
            byte[] data
            )
            : base(fEventId)
        {
            m_fTcpDriver = fTcpDriver;
            m_fTcpDevice = fTcpDevice;
            m_fTcpDeviceDataSentLog = fTcpDeviceDataSentLog;
            m_data = data;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpDeviceDataSentEventArgs(
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
                    m_fTcpDeviceDataSentLog = null;
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

        public FTcpDeviceDataSentLog fTcpDeviceDataSentLog
        {
            get
            {
                try
                {
                    return m_fTcpDeviceDataSentLog;
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

        public byte[] data
        {
            get
            {
                try
                {
                    return m_data;
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

        public int dataLength
        {
            get
            {
                try
                {
                    return m_data.Length;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public string dataToString(
            int columnLength
            )
        {
            try
            {
                if (columnLength < 1)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0014, "Column Length"));
                }

                // --

                return FMessageConverter.convertBinToString(m_data, columnLength);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
