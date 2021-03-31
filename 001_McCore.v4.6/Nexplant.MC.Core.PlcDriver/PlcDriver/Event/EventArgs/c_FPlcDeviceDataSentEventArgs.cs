/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPlcDeviceDataSentEventArgs.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.08.01
--  Description     : FAMate Core FaPlcDriver Plc Device Data Sent Event Arguments Class 
--  History         : Created by Jeff.Kim at 2013.08.01
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    [Serializable]
    public class FPlcDeviceDataSentEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPlcDriver m_fPlcDriver = null;
        private FPlcDevice m_fPlcDevice = null;
        private FPlcDeviceDataSentLog m_fPlcDeviceDataSentLog = null;
        private byte[] m_data = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FPlcDeviceDataSentEventArgs(            
            FEventId fEventId,
            FPlcDriver fPlcDriver,
            FPlcDevice fPlcDevice,
            FPlcDeviceDataSentLog fPlcDeviceDataSentLog,
            byte[] data
            )
            : base(fEventId)
        {
            m_fPlcDriver = fPlcDriver;
            m_fPlcDevice = fPlcDevice;
            m_fPlcDeviceDataSentLog = fPlcDeviceDataSentLog;
            m_data = data;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPlcDeviceDataSentEventArgs(
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
                    m_fPlcDeviceDataSentLog = null;
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

        public FPlcDeviceDataSentLog fPlcDeviceDataSentLog
        {
            get
            {
                try
                {
                    return m_fPlcDeviceDataSentLog;
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
