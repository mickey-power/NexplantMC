/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecs1Protocol.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.11.03
--  Description     : FAMate Core FaSecsDriver SECS1 Protocol Class 
--  History         : Created by byungyun.jeon at 2011.11.03
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FSecs1Protocol : FBaseProtocol
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSECS1 m_fSecs1 = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecs1Protocol(
            FScdCore fScdCore,
            FSecsDevice fSecsDevice
            )
            : base(fScdCore, fSecsDevice)
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecs1Protocol(
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
                    term();
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public override FProtocolType fProtocolType
        {
            get 
            {
                try
                {
                    return FProtocolType.SECS1;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FProtocolType.SECS1;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void init(
            )
        {
            try
            {
                m_fSecs1 = new FSECS1(this);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void term(
            )
        {
            try
            {
                if (m_fSecs1 != null)
                {
                    m_fSecs1.Dispose();
                    m_fSecs1 = null;
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public override void open(
            )
        {
            try
            {
                m_fSecs1.open();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override void close(
            )
        {
            try
            {
                m_fSecs1.close();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override void send(
            FISession fSession,
            FIMessageTransfer fMessageTransfer
            )
        {
            try
            {
                m_fSecs1.send((FSecsSession)fSession, (FSecsMessageTransfer)fMessageTransfer);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override void pauseProtocol(
            )
        {
            try
            {
                m_fSecs1.pauseProtocol();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public override void continueProtocol(
            )
        {
            try
            {
                m_fSecs1.continueProtocol();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
