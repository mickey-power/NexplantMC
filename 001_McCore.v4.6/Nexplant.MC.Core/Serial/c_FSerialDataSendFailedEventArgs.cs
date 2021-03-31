/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialDataSendFailedEventArgs.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.10.21
--  Description     : FAMate Core FaCommon Serial Data Send Failed Event Arguments Class
--  History         : Created by byungyun.jeon at 2011.10.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    [Serializable]
    public class FSerialDataSendFailedEventArgs : FSerialEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FISerial m_fOwnerSerial = null;
        private FSerialSendData m_fData = null;
        private string m_message = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSerialDataSendFailedEventArgs(
            FISerial fOwnerSerial,
            FSerialSendData fData,
            string message
            ) 
            : base (FSerialEventId.SerialDataSendFailed)
        {
            m_fOwnerSerial = fOwnerSerial;
            m_fData = fData;
            m_message = message;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialDataSendFailedEventArgs(
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
                    m_fOwnerSerial = null;
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FISerial fOwnerSerial
        {
            get
            {
                try
                {
                    return m_fOwnerSerial;
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

        public FSerialSendData fData
        {
            get
            {
                try
                {
                    return m_fData;
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
                    return m_fData.data;
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
                    return m_fData.data.Length;
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

        public string message
        {
            get
            {
                try
                {
                    return m_message;
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
