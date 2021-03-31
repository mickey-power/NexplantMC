/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSocketDataReceivedEventArgs.cs
--  Creator         : mjkim
--  Create Date     : 2020.03.03
--  Description     : FAmate Converter FaSerialToEthernet Socket Data Received Event Arguments Class
--  History         : Created by mjkim at 2020.03.03
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    [Serializable]
    public class FSocketDataReceivedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FResultCode m_fResult = FResultCode.Success;
        private string m_errorMessage = string.Empty;
        private byte[] m_bin = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSocketDataReceivedEventArgs(
            FSerialToEthernet fSerialToEthernet,
            FEventId fEventId,
            FResultCode fResult,
            string errorMessage,
            byte[] bin
            )
            : base(fSerialToEthernet, fEventId)
        {
            m_fResult = fResult;
            m_errorMessage = errorMessage;
            m_bin = bin;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSocketDataReceivedEventArgs(
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
                    m_bin = null;
                }
                m_disposed = true;
                // --
                base.myDispose(disposing);
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

        public FResultCode fResult
        {
            get
            {
                try
                {
                    return m_fResult;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FResultCode.Success;
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

        public byte[] fSocketData
        {
            get
            {
                try
                {
                    return m_bin;
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
