/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1BlockReceivedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.10
--  Description     : FAmate Converter FaSecs1ToHsms SECS1 Block Received Event Arguments Class
--  History         : Created by spike.lee at 2017.04.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    [Serializable]
    public class FSecs1BlockReceivedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FResultCode m_fResult = FResultCode.Success;
        private string m_errorMessage = string.Empty;
        private FSecsBlock m_fSecsBlock = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecs1BlockReceivedEventArgs(
            FSecs1ToHsms fSecs1ToHsms,
            FEventId fEventId,
            FResultCode fResult,
            string errorMessage,
            FSecsBlock fSecsBlock
            )
            : base(fSecs1ToHsms, fEventId)
        {
            m_fSecsBlock = fSecsBlock;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecs1BlockReceivedEventArgs(
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
                    m_fSecsBlock = null;
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

        public FSecsBlock fSecsBlock
        {
            get
            {
                try
                {
                    return m_fSecsBlock;
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
