/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseProtocol.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaPlcDriver Base Protocol Class 
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal abstract class FBaseProtocol : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPcdCore m_fPcdCore = null;                
        private FHostDevice m_fHostDevice = null;        
        private FProtocolAgent m_fProtocolAgent = null;
        private FPlcDevice m_fPlcDevice = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        private FBaseProtocol(
            FPcdCore fPcdCore
            )
        {
            m_fPcdCore = fPcdCore;
            m_fProtocolAgent = fPcdCore.fProtocolAgent;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseProtocol(
            FPcdCore fPcdCore,
            FPlcDevice fPlcDevice
            )
            : this(fPcdCore)
        {
            m_fPlcDevice = fPlcDevice;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FBaseProtocol(
            FPcdCore fPcdCore,
            FHostDevice fHostDevice
            )
            : this(fPcdCore)
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
                    m_fPcdCore = null;
                    m_fProtocolAgent = null;
                    if (m_fPlcDevice != null)
                    {
                        m_fPlcDevice.term();
                        m_fPlcDevice = null;
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

        public FPcdCore fPcdCore
        {
            get
            {
                try
                {
                    return m_fPcdCore;
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

        public FPlcDevice fPlcDevice
        {
            get
            {
                try
                {
                    return m_fPlcDevice;
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

        public abstract void write(
            FISession fSession,
            FIMessageTransfer fMessageTransfer
            );
        
        //------------------------------------------------------------------------------------------------------------------------

        public abstract void read(
            FISession fSession,
            FIMessageTransfer fMessageTransfer
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
