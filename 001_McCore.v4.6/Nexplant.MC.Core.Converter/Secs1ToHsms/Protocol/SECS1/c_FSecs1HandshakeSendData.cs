/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1HandshakeSendData.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.10
--  Description     : FAmate Converter FaSecs1ToHsms SECS1 Handshake Send Data Class
--  History         : Created by spike.lee at 2017.04.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FSecs1HandshakeSendData: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1HandshakeCode m_fHandshakeCode = FSecs1HandshakeCode.ENQ;
        private FSecsDataMessage m_fSecsDataMessage = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1HandshakeSendData(
            FSecs1HandshakeCode fHandshakeCode
            )
        {
            m_fHandshakeCode = fHandshakeCode;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecs1HandshakeSendData(
            FSecs1HandshakeCode fHandshakeCode,
            FSecsDataMessage fSecsDataMessage
            )
        {
            m_fHandshakeCode = fHandshakeCode;
            m_fSecsDataMessage = fSecsDataMessage;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecs1HandshakeSendData(
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
                    m_fSecsDataMessage = null;
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

        public FSecs1HandshakeCode fHandshakeCode
        {
            get
            {
                try
                {
                    return m_fHandshakeCode;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSecs1HandshakeCode.ENQ;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSecsDataMessage fSecsDataMessage
        {
            get
            {
                try
                {
                    return m_fSecsDataMessage;
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

        public bool hasSecsDataMesssage
        {
            get
            {
                try
                {
                    return m_fSecsDataMessage == null ? false : true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public byte[] handshakeToBytes(
            )
        {
            try
            {
                return new byte[] { (byte)m_fHandshakeCode };
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
