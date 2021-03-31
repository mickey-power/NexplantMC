/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2021 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTcpProtocol.cs
--  Creator         : Sunghoon.Park
--  Create Date     : 2021.03.10
--  Description     : NexplantMC Core FaTcpDriver TCP Protocol Class 
--  History         : Created by Sunghoon.Park at 2021.03.10
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FTcpProtocol : FBaseProtocol
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FTcp m_fTcp = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTcpProtocol(
            FTcdCore fTcdCore,
            FTcpDevice fTcpDevice
            )
            : base(fTcdCore, fTcpDevice)
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTcpProtocol(
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
                    return FProtocolType.TCP;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FProtocolType.TCP;
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
                m_fTcp = new FTcp(this);
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
                if (m_fTcp != null)
                {
                    m_fTcp.Dispose();
                    m_fTcp = null;
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
                m_fTcp.open();
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
                m_fTcp.close();
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
                m_fTcp.send((FTcpSession)fSession, (FTcpMessageTransfer)fMessageTransfer);
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
                m_fTcp.pauseProtocol();
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
                m_fTcp.continueProtocol();
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

    }
}
