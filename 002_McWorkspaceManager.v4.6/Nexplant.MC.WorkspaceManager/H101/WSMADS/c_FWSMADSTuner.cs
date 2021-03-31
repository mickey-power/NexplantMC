/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2014 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FWSMADSTuner.cs 
--  Creator         : jungyoul.moon
--  Create Date     : 2014.08.14
--  Description     : <Generated Class File Description>
--  History         : Created by jungyoul.moon at 2014.08.14
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.H101Interface
{
    internal abstract class FWSMADSTuner : FIH101Dispatcher, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FH101 m_fH101 = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FWSMADSTuner(
            FH101 fH101
            )
        {
            m_fH101 = fH101;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FWSMADSTuner(
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
                    m_fH101.Dispose();
                    m_fH101 = null;
                }

                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable member

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region FIH101Dispatcher member

        public Exception dispatch(
            FH101DataReceivedArgs e
            )
        {
            try
            {
                switch (e.operation)
                {
                    case "WSMADS_SysLogIn_Req":
                        recv_WSMADS_SysLogIn_Req(e);
                        break;

                    case "WSMADS_SysPasswordChange_Req":
                        recv_WSMADS_SysPasswordChange_Req(e);
                        break;

                    default:
                        if (e.isRequest)
                        {
                            e.sendReply("-23", string.Format("Unexpected Operation!(Operation:{0})", e.operation));
                        }
                        // --
                        FDebug.throwFException (
                            string.Format("Unexpected Operation!(Operation:{0})", e.operation)
                           );
                        break;
                }
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

        #region Methods

        public abstract void WSMADS_SysLogIn_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_WSMADS_SysLogIn_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                WSMADS_SysLogIn_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

                if (e.isRequest) /* Just RequestReply */
                {
                    e.sendReply(fXmlNodeOut);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeOut = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void WSMADS_SysPasswordChange_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_WSMADS_SysPasswordChange_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                WSMADS_SysPasswordChange_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

                if (e.isRequest) /* Just RequestReply */
                {
                    e.sendReply(fXmlNodeOut);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
                fXmlNodeOut = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
