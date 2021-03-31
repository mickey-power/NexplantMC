/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHostProtocol.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.15
--  Description     : FAMate Core FaPlcDriver Host Protocol Class 
--  History         : Created by Jeff.Kim at 2013.07.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FHostProtocol : FBaseProtocol
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FHost m_fHost = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHostProtocol(                        
            FPcdCore fScdCore,
            FHostDevice fHostDevice
            )
            : base(fScdCore, fHostDevice)
        {
            init();            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHostProtocol(
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
                    return FProtocolType.HOST;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FProtocolType.HOST;
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
                m_fHost = new FHost(this);
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
                if (m_fHost != null)
                {
                    m_fHost.Dispose();
                    m_fHost = null;
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
                m_fHost.open();                
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
                m_fHost.close();                
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

        public override void write(
            FISession fSession,
            FIMessageTransfer fMessageTransfer
            )
        {
            try
            {
                
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

        public override void read(
            FISession fSession,
            FIMessageTransfer fMessageTransfer
            )
        {
            try
            {

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
                m_fHost.send((FHostSession)fSession, (FHostMessageTransfer)fMessageTransfer);                
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
                m_fHost.pauseProtocol();
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
                m_fHost.continueProtocol();
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

        public void setDriverOption(
            )
        {
            try
            {
                m_fHost.setDriverOption();   
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
