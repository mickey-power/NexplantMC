/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpClientErrorRaisedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2011.08.23
--  Description     : FAMate Core FaCommon FTcpClient Error Raised Event Arguments Class
--  History         : Created by spike.lee at 2011.08.22
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nexplant.MC.Core.FaCommon
{
    [Serializable]
    public class FTcpClientErrorRaisedEventArgs : FSocketEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpClient m_fOwnerTcpClient = null;
        private string m_message = string.Empty;
        private Exception m_exception = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FTcpClientErrorRaisedEventArgs(
            FTcpClient fOwnerTcpClient,
            string message,
            Exception exception
            )
            : base (FSocketEventId.TcpClientErrorRaised)
        {
            m_fOwnerTcpClient = fOwnerTcpClient;
            m_message = message;
            m_exception = exception;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpClientErrorRaisedEventArgs(
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
                    m_fOwnerTcpClient = null;
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

        public FTcpClient fOwnerTcpClient
        {
            get
            {
                try
                {
                    return m_fOwnerTcpClient;
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
