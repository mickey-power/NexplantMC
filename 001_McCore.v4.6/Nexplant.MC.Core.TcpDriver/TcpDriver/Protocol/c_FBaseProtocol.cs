/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseProtocol.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaTcpDriver Base Protocol Class 
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal abstract class FBaseProtocol : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcdCore m_fTcdCore = null;
        private FTcpDevice m_fTcpDevice = null;     
        private FHostDevice m_fHostDevice = null;        
        private FProtocolAgent m_fProtocolAgent = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        private FBaseProtocol(
            FTcdCore fTcdCore
            )
        {
            m_fTcdCore = fTcdCore;
            m_fProtocolAgent = fTcdCore.fProtocolAgent;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseProtocol(
            FTcdCore fTcdCore,
            FTcpDevice fTcpDevice
            )
            : this(fTcdCore)
        {
            m_fTcpDevice = fTcpDevice;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseProtocol(
            FTcdCore fTcdCore,
            FHostDevice fHostDevice
            )
            : this(fTcdCore)
        {
            m_fHostDevice = fHostDevice;   
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FBaseProtocol(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fTcdCore = null;
                    m_fProtocolAgent = null;
                    if (m_fTcpDevice != null)
                    {
                        m_fTcpDevice.term();
                        m_fTcpDevice = null;
                    }
                    if (m_fHostDevice != null)
                    {
                        m_fHostDevice.term();
                        m_fHostDevice = null;
                    }                    
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

        public abstract FProtocolType fProtocolType
        {
            get;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FTcdCore fTcdCore
        {
            get
            {
                try
                {
                    return m_fTcdCore;
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

        public FProtocolAgent fProtocolAgent
        {
            get
            {
                try
                {
                    return m_fProtocolAgent;
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

        public FHostDevice fHostDevice
        {
            get
            {
                try
                {
                    return m_fHostDevice;
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

        public FTcpDevice fTcpDevice
        {
            get
            {
                try
                {
                    return m_fTcpDevice;
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

        public abstract void open(
            );

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void close(
            );
                
        //------------------------------------------------------------------------------------------------------------------------

        public abstract void send(
            FISession fSession,
            FIMessageTransfer fMessageTransfer
            );

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void pauseProtocol(
            );

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void continueProtocol(
            );

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
