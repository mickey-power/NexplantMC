/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpListenerErrorRaisedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.18
--  Description     : FAMate Core FaCommon FTcpListener Error Raised Event Arguments Class
--  History         : Created by spike.lee at 2011.08.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nexplant.MC.Core.FaCommon
{
    [Serializable]
    public class FTcpListenerErrorRaisedEventArgs : FSocketEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpListener m_fOwnerTcpListener = null;
        private string m_message = string.Empty;
        private Exception m_exception = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FTcpListenerErrorRaisedEventArgs(
            FTcpListener fOwnerTcpListener,
            string message,
            Exception exception
            )
            : base (FSocketEventId.TcpListenerErrorRaised)
        {
            m_fOwnerTcpListener = fOwnerTcpListener;
            m_message = message;
            m_exception = exception;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpListenerErrorRaisedEventArgs(
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
                    m_fOwnerTcpListener = null;
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

        public FTcpListener fOwnerTcpListener
        {
            get
            {
                try
                {
                    return m_fOwnerTcpListener;
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
