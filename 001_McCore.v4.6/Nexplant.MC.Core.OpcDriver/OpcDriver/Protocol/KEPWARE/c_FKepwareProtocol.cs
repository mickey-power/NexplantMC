/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FKepwareProtocol.cs
--  Creator         : spike.lee
--  Create Date     : 2015.06.23
--  Description     : FAMate Core FaOpcDriver KEPWARE Protocol Class 
--  History         : Created by spike.lee at 2015.06.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    internal class FKepwareProtocol : FBaseProtocol
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FKepware m_fKepware = null;
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FKepwareProtocol(                        
            FOcdCore fOcdCore,
            FOpcDevice fOpcDevice
            )
            : base(fOcdCore, fOpcDevice)
        {
            init();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FKepwareProtocol(
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
                    if (m_fKepware.fOpcDevice.fProtocol == FProtocol.OPCDA)
                    {
                        return FProtocolType.OPCDA;
                    }
                    else if (m_fKepware.fOpcDevice.fProtocol == FProtocol.OPCUA)
                    {
                        return FProtocolType.OPCUA;
                    }
                    return FProtocolType.KEPWARE;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FProtocolType.KEPWARE;
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
                m_fKepware = new FKepware(this);                
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
                // --

                if (m_fKepware != null)
                {
                    m_fKepware.Dispose();
                    m_fKepware = null;
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
                m_fKepware.open();                
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
                m_fKepware.close();                
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
                m_fKepware.write((FOpcSession)fSession, (FOpcMessageTransfer)fMessageTransfer);
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
                m_fKepware.read((FOpcSession)fSession, (FOpcMessageTransfer)fMessageTransfer);
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
                m_fKepware.pauseProtocol();
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
                // --
                // Modify by Jeff.Kim 2015.10.09
                // Reload 시에 수행
                m_fKepware.clearSubscription();

                // --

                m_fKepware.continueProtocol();
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

        public void refreshOpcSessionItemName(
            FOpcSession fOpcSession
            )
        {
            try
            {
                m_fKepware.refreshOpcSessionItemName(fOpcSession);
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
