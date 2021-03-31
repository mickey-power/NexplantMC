/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSQMSQSTuner.cs 
--  Creator         : TJ.Kim
--  Create Date     : 2013.10.15
--  Description     : <Generated Class File Description>
--  History         : Created by TJ.Kim at 2013.10.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.H101Interface
{
    internal abstract class FSQMSQSTuner : FIH101Dispatcher, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FH101 m_fH101 = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSQMSQSTuner(
            FH101 fH101
            )
        {
            m_fH101 = fH101;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSQMSQSTuner(
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
                    case "SQMSQS_SetSystemList_Req":
                        recv_SQMSQS_SetSystemList_Req(e);
                        break;

                    case "SQMSQS_SetSystemSearch_Req":
                        recv_SQMSQS_SetSystemSearch_Req(e);
                        break;

                    case "SQMSQS_SetSystemUpdate_Req":
                        recv_SQMSQS_SetSystemUpdate_Req(e);
                        break;

                    case "SQMSQS_SetSystemDownload_Req":
                        recv_SQMSQS_SetSystemDownload_Req(e);
                        break;

                    case "SQMSQS_SetSystemMigration_Req":
                        recv_SQMSQS_SetSystemMigration_Req(e);
                        break;

                    case "SQMSQS_SetModuleList_Req":
                        recv_SQMSQS_SetModuleList_Req(e);
                        break;

                    case "SQMSQS_SetModuleSearch_Req":
                        recv_SQMSQS_SetModuleSearch_Req(e);
                        break;

                    case "SQMSQS_SetModuleUpdate_Req":
                        recv_SQMSQS_SetModuleUpdate_Req(e);
                        break;

                    case "SQMSQS_SetFunctionList_Req":
                        recv_SQMSQS_SetFunctionList_Req(e);
                        break;

                    case "SQMSQS_SetFunctionSearch_Req":
                        recv_SQMSQS_SetFunctionSearch_Req(e);
                        break;

                    case "SQMSQS_SetFunctionUpdate_Req":
                        recv_SQMSQS_SetFunctionUpdate_Req(e);
                        break;

                    case "SQMSQS_SetSqlCodeList_Req":
                        recv_SQMSQS_SetSqlCodeList_Req(e);
                        break;

                    case "SQMSQS_SetSqlCodeSearch_Req":
                        recv_SQMSQS_SetSqlCodeSearch_Req(e);
                        break;

                    case "SQMSQS_SetSqlCodeUpdate_Req":
                        recv_SQMSQS_SetSqlCodeUpdate_Req(e);
                        break;

                    case "SQMSQS_TolSqlCodeExecute_Req":
                        recv_SQMSQS_TolSqlCodeExecute_Req(e);
                        break;

                    case "SQMSQS_TolMove_Req":
                        recv_SQMSQS_TolMove_Req(e);
                        break;

                    case "SQMSQS_ViwSqlServiceLogList_Req":
                        recv_SQMSQS_ViwSqlServiceLogList_Req(e);
                        break;

                    case "SQMSQS_ViwSqlServiceLogDownload_Req":
                        recv_SQMSQS_ViwSqlServiceLogDownload_Req(e);
                        break;

                    default:
                        if (e.isRequest)
                        {
                            e.sendReply("-23", string.Format("Unexpected Operation!(Operation:{0})", e.operation));
                        }
                        // --
                        FDebug.throwFException(
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

        public abstract void SQMSQS_SetSystemList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetSystemList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetSystemList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetSystemSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetSystemSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetSystemSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetSystemUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetSystemUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetSystemUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetSystemDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetSystemDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetSystemDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetSystemMigration_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetSystemMigration_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetSystemMigration_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetModuleList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetModuleList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetModuleList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetModuleSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetModuleSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetModuleSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetModuleUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetModuleUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetModuleUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetFunctionList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetFunctionList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetFunctionList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetFunctionSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetFunctionSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetFunctionSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetFunctionUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetFunctionUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetFunctionUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetSqlCodeList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetSqlCodeList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetSqlCodeList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetSqlCodeSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetSqlCodeSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetSqlCodeSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_SetSqlCodeUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_SetSqlCodeUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_SetSqlCodeUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_TolSqlCodeExecute_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_TolSqlCodeExecute_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_TolSqlCodeExecute_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_TolMove_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_TolMove_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_TolMove_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_ViwSqlServiceLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_ViwSqlServiceLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_ViwSqlServiceLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void SQMSQS_ViwSqlServiceLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_SQMSQS_ViwSqlServiceLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                SQMSQS_ViwSqlServiceLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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
