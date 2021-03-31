/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseProtocol.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.02
--  Description     : FAMate Core FaSecsDriver Base Protocol Class 
--  History         : Created by spike.lee at 2011.09.02
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal abstract class FBaseProtocol : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScdCore m_fScdCore = null;
        private FProtocolAgent m_fProtocolAgent = null;
        private FSecsDevice m_fSecsDevice = null;
        private FHostDevice m_fHostDevice = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        private FBaseProtocol(
            FScdCore fScdCore
            )
        {
            m_fScdCore = fScdCore;
            m_fProtocolAgent = fScdCore.fProtocolAgent;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseProtocol(                        
            FScdCore fScdCore,
            FSecsDevice fSecsDevice
            )
            : this(fScdCore)
        {
            m_fSecsDevice = fSecsDevice;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseProtocol(
            FScdCore fScdCore,
            FHostDevice fHostDevice
            )
            : this(fScdCore)
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
                    m_fScdCore = null;
                    m_fProtocolAgent = null;
                    if (m_fSecsDevice != null)
                    {
                        m_fSecsDevice.term();
                        m_fHostDevice = null;
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

        public FScdCore fScdCore
        {
            get
            {
                try
                {
                    return m_fScdCore;
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

        public FSecsDevice fSecsDevice
        {
            get
            {
                try
                {
                    return m_fSecsDevice;
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
