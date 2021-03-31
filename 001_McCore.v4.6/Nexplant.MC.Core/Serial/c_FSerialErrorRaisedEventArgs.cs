/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialErrorRaisedEventArgs.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.10.21
--  Description     : FAMate Core FaCommon Serial Error Raised Event Arguments Class
--  History         : Created by byungyun.jeon at 2011.10.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nexplant.MC.Core.FaCommon
{
    [Serializable]
    public class FSerialErrorRaisedEventArgs : FSerialEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FISerial m_fOwnerSerial = null;
        private string m_message = string.Empty;
        private Exception m_exception = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSerialErrorRaisedEventArgs(
            FISerial fOwnerSerial,
            string message,
            Exception exception
            )
            : base (FSerialEventId.SerialErrorRaised)
        {
            m_fOwnerSerial = fOwnerSerial;
            m_message = message;
            m_exception = exception;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialErrorRaisedEventArgs(
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
                    m_exception = null;
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

        //------------------------------------------------------------------------------------------------------------------------

        public Exception exception
        {
            get
            {
                try
                {
                    return m_exception;
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
