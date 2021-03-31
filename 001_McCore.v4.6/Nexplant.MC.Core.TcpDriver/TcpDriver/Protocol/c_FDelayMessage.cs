/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDelayMessage.cs
--  Creator         : spike.lee
--  Create Date     : 2015.07.17
--  Description     : FAMate Core FaTcpDriver Delay Message Class 
--  History         : Created by spike.lee at 2015.07.17
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FDelayMessage : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FTcpSession m_fOpcSession = null;
        private FTcpMessageTransfer m_fOpcMessageTransfer = null;
        private int m_period = 0;
        private long m_ticks = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDelayMessage(                        
            FTcpSession fOpcSession,
            FTcpMessageTransfer fOpcMessageTransfer,
            int period
            )
        {
            m_fOpcSession = fOpcSession;
            m_fOpcMessageTransfer = fOpcMessageTransfer;
            m_period = period;
            m_ticks = FTickCount.ticks;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDelayMessage(
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
                    m_fOpcSession = null;
                    m_fOpcMessageTransfer = null;
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

        public FTcpSession fOpcSession
        {
            get
            {
                try
                {
                    return m_fOpcSession; 
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

        public FTcpMessageTransfer fOpcMessageTransfer
        {
            get
            {
                try
                {
                    return m_fOpcMessageTransfer;
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

        public bool elasped(
            )
        {
            try
            {
                if (FTickCount.timeout(m_ticks, m_period))
                {   
                    return true;
                }
                return false;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
