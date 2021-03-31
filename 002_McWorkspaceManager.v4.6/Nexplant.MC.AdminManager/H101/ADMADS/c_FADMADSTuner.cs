/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2018 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADSTuner.cs 
--  Creator         : mjkim
--  Create Date     : 2018.05.23
--  Description     : <Generated Class File Description>
--  History         : Created by mjkim at 2018.05.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.H101Interface
{
    internal abstract class FADMADSTuner : FIH101Dispatcher, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FH101 m_fH101 = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FADMADSTuner(
            FH101 fH101
            )
        {
            m_fH101 = fH101;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FADMADSTuner(
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
                    case "ADMADS_ComSqlQuery_Req":
                        recv_ADMADS_ComSqlQuery_Req(e);
                        break;

                    case "ADMADS_ComEapSchemaSearch_Req":
                        recv_ADMADS_ComEapSchemaSearch_Req(e);
                        break;

                    case "ADMADS_DlgEapWizardEapSchemaSearch_Req":
                        recv_ADMADS_DlgEapWizardEapSchemaSearch_Req(e);
                        break;

                    case "ADMADS_SysLogIn_Req":
                        recv_ADMADS_SysLogIn_Req(e);
                        break;

                    case "ADMADS_SysUserNoticeUpdate_Req":
                        recv_ADMADS_SysUserNoticeUpdate_Req(e);
                        break;

                    case "ADMADS_SysPasswordChange_Req":
                        recv_ADMADS_SysPasswordChange_Req(e);
                        break;

                    case "ADMADS_SysPasswordReset_Req":
                        recv_ADMADS_SysPasswordReset_Req(e);
                        break;

                    case "ADMADS_SysHostDriverDownload_Req":
                        recv_ADMADS_SysHostDriverDownload_Req(e);
                        break;

                    case "ADMADS_SetFactoryUpdate_Req":
                        recv_ADMADS_SetFactoryUpdate_Req(e);
                        break;

                    case "ADMADS_SetNoticeUpdate_Req":
                        recv_ADMADS_SetNoticeUpdate_Req(e);
                        break;

                    case "ADMADS_SetGcmTableUpdate_Req":
                        recv_ADMADS_SetGcmTableUpdate_Req(e);
                        break;

                    case "ADMADS_SetGcmDataUpdate_Req":
                        recv_ADMADS_SetGcmDataUpdate_Req(e);
                        break;

                    case "ADMADS_SetServerEventUpdate_Req":
                        recv_ADMADS_SetServerEventUpdate_Req(e);
                        break;

                    case "ADMADS_SetEapEventUpdate_Req":
                        recv_ADMADS_SetEapEventUpdate_Req(e);
                        break;

                    case "ADMADS_SetEquipmentEventUpdate_Req":
                        recv_ADMADS_SetEquipmentEventUpdate_Req(e);
                        break;

                    case "ADMADS_SetUserEventUpdate_Req":
                        recv_ADMADS_SetUserEventUpdate_Req(e);
                        break;

                    case "ADMADS_SetUserGroupApplicationUpdate_Req":
                        recv_ADMADS_SetUserGroupApplicationUpdate_Req(e);
                        break;

                    case "ADMADS_SetUserGroupFunctionUpdate_Req":
                        recv_ADMADS_SetUserGroupFunctionUpdate_Req(e);
                        break;

                    case "ADMADS_SetUserGroupAuthorityUpdate_Req":
                        recv_ADMADS_SetUserGroupAuthorityUpdate_Req(e);
                        break;

                    case "ADMADS_SetUserGroupAlertUpdate_Req":
                        recv_ADMADS_SetUserGroupAlertUpdate_Req(e);
                        break;

                    case "ADMADS_SetUserGroupUpdate_Req":
                        recv_ADMADS_SetUserGroupUpdate_Req(e);
                        break;

                    case "ADMADS_SetUserUpdate_Req":
                        recv_ADMADS_SetUserUpdate_Req(e);
                        break;

                    case "ADMADS_SetServerUpdate_Req":
                        recv_ADMADS_SetServerUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelSheetUpdate_Req":
                        recv_ADMADS_SetModelSheetUpdate_Req(e);
                        break;

                    case "ADMADS_SetMakerUpdate_Req":
                        recv_ADMADS_SetMakerUpdate_Req(e);
                        break;

                    case "ADMADS_SetHostDriverUpdate_Req":
                        recv_ADMADS_SetHostDriverUpdate_Req(e);
                        break;

                    case "ADMADS_SetHostDriverDownload_Req":
                        recv_ADMADS_SetHostDriverDownload_Req(e);
                        break;

                    case "ADMADS_SetPackageUpdate_Req":
                        recv_ADMADS_SetPackageUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelUpdate_Req":
                        recv_ADMADS_SetModelUpdate_Req(e);
                        break;

                    case "ADMADS_SetComponentUpdate_Req":
                        recv_ADMADS_SetComponentUpdate_Req(e);
                        break;

                    case "ADMADS_SetPackageVerUpdate_Req":
                        recv_ADMADS_SetPackageVerUpdate_Req(e);
                        break;

                    case "ADMADS_SetPackageVerDownload_Req":
                        recv_ADMADS_SetPackageVerDownload_Req(e);
                        break;

                    case "ADMADS_SetModelVerUpdate_Req":
                        recv_ADMADS_SetModelVerUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelVerDownload_Req":
                        recv_ADMADS_SetModelVerDownload_Req(e);
                        break;

                    case "ADMADS_SetModelManualUpdate_Req":
                        recv_ADMADS_SetModelManualUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelManualDownload_Req":
                        recv_ADMADS_SetModelManualDownload_Req(e);
                        break;

                    case "ADMADS_SetModelStateUpdate_Req":
                        recv_ADMADS_SetModelStateUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelObjectNameUpdate_Req":
                        recv_ADMADS_SetModelObjectNameUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelFunctionNameListUpdate_Req":
                        recv_ADMADS_SetModelFunctionNameListUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelFunctionNameUpdate_Req":
                        recv_ADMADS_SetModelFunctionNameUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelParameterNameUpdate_Req":
                        recv_ADMADS_SetModelParameterNameUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelArgumentNameUpdate_Req":
                        recv_ADMADS_SetModelArgumentNameUpdate_Req(e);
                        break;

                    case "ADMADS_SetModelUserTagNameUpdate_Req":
                        recv_ADMADS_SetModelUserTagNameUpdate_Req(e);
                        break;

                    case "ADMADS_SetComponentVerUpdate_Req":
                        recv_ADMADS_SetComponentVerUpdate_Req(e);
                        break;

                    case "ADMADS_SetComponentVerDownload_Req":
                        recv_ADMADS_SetComponentVerDownload_Req(e);
                        break;

                    case "ADMADS_SetCustomRemoteCommandUpdate_Req":
                        recv_ADMADS_SetCustomRemoteCommandUpdate_Req(e);
                        break;

                    case "ADMADS_SetEquipmentTypeUpdate_Req":
                        recv_ADMADS_SetEquipmentTypeUpdate_Req(e);
                        break;

                    case "ADMADS_SetEquipmentAreaUpdate_Req":
                        recv_ADMADS_SetEquipmentAreaUpdate_Req(e);
                        break;

                    case "ADMADS_SetEquipmentLineUpdate_Req":
                        recv_ADMADS_SetEquipmentLineUpdate_Req(e);
                        break;

                    case "ADMADS_SetEquipmentUpdate_Req":
                        recv_ADMADS_SetEquipmentUpdate_Req(e);
                        break;

                    case "ADMADS_SetInlineEquipmentUpdate_Req":
                        recv_ADMADS_SetInlineEquipmentUpdate_Req(e);
                        break;

                    case "ADMADS_SetEapUpdate_Req":
                        recv_ADMADS_SetEapUpdate_Req(e);
                        break;

                    case "ADMADS_SetProcessEapUpdate_Req":
                        recv_ADMADS_SetProcessEapUpdate_Req(e);
                        break;

                    case "ADMADS_TrnEapBatchModification_Req":
                        recv_ADMADS_TrnEapBatchModification_Req(e);
                        break;

                    case "ADMADS_TrnEapRelease_Req":
                        recv_ADMADS_TrnEapRelease_Req(e);
                        break;

                    case "ADMADS_TrnEapStart_Req":
                        recv_ADMADS_TrnEapStart_Req(e);
                        break;

                    case "ADMADS_TrnEapStop_Req":
                        recv_ADMADS_TrnEapStop_Req(e);
                        break;

                    case "ADMADS_TrnEapReload_Req":
                        recv_ADMADS_TrnEapReload_Req(e);
                        break;

                    case "ADMADS_TrnEapRestart_Req":
                        recv_ADMADS_TrnEapRestart_Req(e);
                        break;

                    case "ADMADS_TrnEapAbort_Req":
                        recv_ADMADS_TrnEapAbort_Req(e);
                        break;

                    case "ADMADS_TrnEapMove_Req":
                        recv_ADMADS_TrnEapMove_Req(e);
                        break;

                    case "ADMADS_TrnEapLogLevelSetup_Req":
                        recv_ADMADS_TrnEapLogLevelSetup_Req(e);
                        break;

                    case "ADMADS_TrnEapMainSwitch_Req":
                        recv_ADMADS_TrnEapMainSwitch_Req(e);
                        break;

                    case "ADMADS_TrnServerMainSwitch_Req":
                        recv_ADMADS_TrnServerMainSwitch_Req(e);
                        break;

                    case "ADMADS_TrnEapBackupSwitch_Req":
                        recv_ADMADS_TrnEapBackupSwitch_Req(e);
                        break;

                    case "ADMADS_TrnServerBackupSwitch_Req":
                        recv_ADMADS_TrnServerBackupSwitch_Req(e);
                        break;

                    case "ADMADS_TrnTransactionCertification_Req":
                        recv_ADMADS_TrnTransactionCertification_Req(e);
                        break;

                    case "ADMADS_TrnEapRepositoryClear_Req":
                        recv_ADMADS_TrnEapRepositoryClear_Req(e);
                        break;

                    case "ADMADS_TrnEapRepositoryRemove_Req":
                        recv_ADMADS_TrnEapRepositoryRemove_Req(e);
                        break;

                    case "ADMADS_TolEapSchemaSearch_Req":
                        recv_ADMADS_TolEapSchemaSearch_Req(e);
                        break;

                    case "ADMADS_TolServerDataPush_Nrp":
                        recv_ADMADS_TolServerDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolPackageDataPush_Nrp":
                        recv_ADMADS_TolPackageDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolPackageVerDataPush_Nrp":
                        recv_ADMADS_TolPackageVerDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolModelDataPush_Nrp":
                        recv_ADMADS_TolModelDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolModelVerDataPush_Nrp":
                        recv_ADMADS_TolModelVerDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolComponentDataPush_Nrp":
                        recv_ADMADS_TolComponentDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolComponentVerDataPush_Nrp":
                        recv_ADMADS_TolComponentVerDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolEapDataPush_Nrp":
                        recv_ADMADS_TolEapDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolEquipmentTypeDataPush_Nrp":
                        recv_ADMADS_TolEquipmentTypeDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolEquipmentAreaDataPush_Nrp":
                        recv_ADMADS_TolEquipmentAreaDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolEquipmentLineDataPush_Nrp":
                        recv_ADMADS_TolEquipmentLineDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolEquipmentDataPush_Nrp":
                        recv_ADMADS_TolEquipmentDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolDeviceDataPush_Nrp":
                        recv_ADMADS_TolDeviceDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolEapModelDownload_Req":
                        recv_ADMADS_TolEapModelDownload_Req(e);
                        break;

                    case "ADMADS_TolServerIssueEventRefresh_Nrp":
                        recv_ADMADS_TolServerIssueEventRefresh_Nrp(e);
                        break;

                    case "ADMADS_TolEapIssueEventRefresh_Nrp":
                        recv_ADMADS_TolEapIssueEventRefresh_Nrp(e);
                        break;

                    case "ADMADS_TolEquipmentIssueEventRefresh_Nrp":
                        recv_ADMADS_TolEquipmentIssueEventRefresh_Nrp(e);
                        break;

                    case "ADMADS_TolEapLogList_Req":
                        recv_ADMADS_TolEapLogList_Req(e);
                        break;

                    case "ADMADS_TolEapLogDownload_Req":
                        recv_ADMADS_TolEapLogDownload_Req(e);
                        break;

                    case "ADMADS_TolEapLogContinue_Req":
                        recv_ADMADS_TolEapLogContinue_Req(e);
                        break;

                    case "ADMADS_TolEapBackupLogList_Req":
                        recv_ADMADS_TolEapBackupLogList_Req(e);
                        break;

                    case "ADMADS_TolEapBackupLogSearch_Req":
                        recv_ADMADS_TolEapBackupLogSearch_Req(e);
                        break;

                    case "ADMADS_TolEapBackupLogDownload_Req":
                        recv_ADMADS_TolEapBackupLogDownload_Req(e);
                        break;

                    case "ADMADS_TolEapBackupLogContinue_Req":
                        recv_ADMADS_TolEapBackupLogContinue_Req(e);
                        break;

                    case "ADMADS_TolAdminServiceLogList_Req":
                        recv_ADMADS_TolAdminServiceLogList_Req(e);
                        break;

                    case "ADMADS_TolAdminServiceLogDownload_Req":
                        recv_ADMADS_TolAdminServiceLogDownload_Req(e);
                        break;

                    case "ADMADS_TolAdminServiceLogContinue_Req":
                        recv_ADMADS_TolAdminServiceLogContinue_Req(e);
                        break;

                    case "ADMADS_TolAdminServiceBackupLogList_Req":
                        recv_ADMADS_TolAdminServiceBackupLogList_Req(e);
                        break;

                    case "ADMADS_TolAdminServiceBackupLogSearch_Req":
                        recv_ADMADS_TolAdminServiceBackupLogSearch_Req(e);
                        break;

                    case "ADMADS_TolAdminServiceBackupLogDownload_Req":
                        recv_ADMADS_TolAdminServiceBackupLogDownload_Req(e);
                        break;

                    case "ADMADS_TolAdminServiceBackupLogContinue_Req":
                        recv_ADMADS_TolAdminServiceBackupLogContinue_Req(e);
                        break;

                    case "ADMADS_TolAdminAgentLogList_Req":
                        recv_ADMADS_TolAdminAgentLogList_Req(e);
                        break;

                    case "ADMADS_TolAdminAgentLogDownload_Req":
                        recv_ADMADS_TolAdminAgentLogDownload_Req(e);
                        break;

                    case "ADMADS_TolAdminAgentLogContinue_Req":
                        recv_ADMADS_TolAdminAgentLogContinue_Req(e);
                        break;

                    case "ADMADS_TolAdminAgentBackupLogList_Req":
                        recv_ADMADS_TolAdminAgentBackupLogList_Req(e);
                        break;

                    case "ADMADS_TolAdminAgentBackupLogSearch_Req":
                        recv_ADMADS_TolAdminAgentBackupLogSearch_Req(e);
                        break;

                    case "ADMADS_TolAdminAgentBackupLogDownload_Req":
                        recv_ADMADS_TolAdminAgentBackupLogDownload_Req(e);
                        break;

                    case "ADMADS_TolAdminAgentBackupLogContinue_Req":
                        recv_ADMADS_TolAdminAgentBackupLogContinue_Req(e);
                        break;

                    case "ADMADS_TolAlertServiceLogList_Req":
                        recv_ADMADS_TolAlertServiceLogList_Req(e);
                        break;

                    case "ADMADS_TolAlertServiceLogDownload_Req":
                        recv_ADMADS_TolAlertServiceLogDownload_Req(e);
                        break;

                    case "ADMADS_TolAlertServiceBackupLogList_Req":
                        recv_ADMADS_TolAlertServiceBackupLogList_Req(e);
                        break;

                    case "ADMADS_TolAlertServiceBackupLogSearch_Req":
                        recv_ADMADS_TolAlertServiceBackupLogSearch_Req(e);
                        break;

                    case "ADMADS_TolAlertServiceBackupLogDownload_Req":
                        recv_ADMADS_TolAlertServiceBackupLogDownload_Req(e);
                        break;

                    case "ADMADS_TolAdminAgentOptionSearch_Req":
                        recv_ADMADS_TolAdminAgentOptionSearch_Req(e);
                        break;

                    case "ADMADS_TolAdminAgentOptionUpdate_Req":
                        recv_ADMADS_TolAdminAgentOptionUpdate_Req(e);
                        break;

                    case "ADMADS_RcmEquipmentEventDefineRequest_Req":
                        recv_ADMADS_RcmEquipmentEventDefineRequest_Req(e);
                        break;

                    case "ADMADS_RcmEquipmentVersionRequest_Req":
                        recv_ADMADS_RcmEquipmentVersionRequest_Req(e);
                        break;

                    case "ADMADS_RcmEquipmentControlModeRequest_Req":
                        recv_ADMADS_RcmEquipmentControlModeRequest_Req(e);
                        break;

                    case "ADMADS_RcmEquipmentCustomRequest_Req":
                        recv_ADMADS_RcmEquipmentCustomRequest_Req(e);
                        break;

                    case "ADMADS_RcmRemotePingTest_Req":
                        recv_ADMADS_RcmRemotePingTest_Req(e);
                        break;

                    case "ADMADS_InqModelVerSchemaSearch_Req":
                        recv_ADMADS_InqModelVerSchemaSearch_Req(e);
                        break;

                    case "ADMADS_InqModelManualDownload_Req":
                        recv_ADMADS_InqModelManualDownload_Req(e);
                        break;

                    case "ADMADS_InqEquipmentGemStatus_Req":
                        recv_ADMADS_InqEquipmentGemStatus_Req(e);
                        break;

                    case "ADMADS_SetSecs1ToHsmsEventUpdate_Req":
                        recv_ADMADS_SetSecs1ToHsmsEventUpdate_Req(e);
                        break;

                    case "ADMADS_SetSecs1ToHsmsConverterUpdate_Req":
                        recv_ADMADS_SetSecs1ToHsmsConverterUpdate_Req(e);
                        break;

                    case "ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp":
                        recv_ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp":
                        recv_ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp(e);
                        break;

                    case "ADMADS_TolSecs1ToHsmsConverterLogList_Req":
                        recv_ADMADS_TolSecs1ToHsmsConverterLogList_Req(e);
                        break;

                    case "ADMADS_TolSecs1ToHsmsConverterLogDownload_Req":
                        recv_ADMADS_TolSecs1ToHsmsConverterLogDownload_Req(e);
                        break;

                    case "ADMADS_TolSecs1ToHsmsConverterLogContinue_Req":
                        recv_ADMADS_TolSecs1ToHsmsConverterLogContinue_Req(e);
                        break;

                    case "ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req":
                        recv_ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req(e);
                        break;

                    case "ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req":
                        recv_ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req(e);
                        break;

                    case "ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req":
                        recv_ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req(e);
                        break;

                    case "ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req":
                        recv_ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req(e);
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

        public abstract void ADMADS_ComSqlQuery_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_ComSqlQuery_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_ComSqlQuery_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_ComEapSchemaSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_ComEapSchemaSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_ComEapSchemaSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_DlgEapWizardEapSchemaSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_DlgEapWizardEapSchemaSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_DlgEapWizardEapSchemaSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SysLogIn_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SysLogIn_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SysLogIn_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SysUserNoticeUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SysUserNoticeUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SysUserNoticeUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SysPasswordChange_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SysPasswordChange_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SysPasswordChange_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SysPasswordReset_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SysPasswordReset_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SysPasswordReset_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SysHostDriverDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SysHostDriverDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SysHostDriverDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetFactoryUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetFactoryUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetFactoryUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetNoticeUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetNoticeUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetNoticeUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetGcmTableUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetGcmTableUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetGcmTableUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetGcmDataUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetGcmDataUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetGcmDataUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetServerEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetServerEventUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetServerEventUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetEapEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetEapEventUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetEapEventUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetEquipmentEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetEquipmentEventUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetEquipmentEventUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetUserEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetUserEventUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetUserEventUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetUserGroupApplicationUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetUserGroupApplicationUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetUserGroupApplicationUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetUserGroupFunctionUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetUserGroupFunctionUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetUserGroupFunctionUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetUserGroupAuthorityUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetUserGroupAuthorityUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetUserGroupAuthorityUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetUserGroupAlertUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetUserGroupAlertUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetUserGroupAlertUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetUserGroupUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetUserGroupUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetUserGroupUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetUserUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetUserUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetUserUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetServerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetServerUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetServerUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelSheetUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelSheetUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelSheetUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetMakerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetMakerUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetMakerUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetHostDriverUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetHostDriverUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetHostDriverUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetHostDriverDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetHostDriverDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetHostDriverDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetPackageUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetPackageUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetPackageUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetComponentUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetComponentUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetComponentUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetPackageVerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetPackageVerUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetPackageVerUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetPackageVerDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetPackageVerDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetPackageVerDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelVerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelVerUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelVerUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelVerDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelVerDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelVerDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelManualUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelManualUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelManualUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelManualDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelManualDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelManualDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelStateUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelStateUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelStateUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelObjectNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelObjectNameUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelObjectNameUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelFunctionNameListUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelFunctionNameListUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelFunctionNameListUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelFunctionNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelFunctionNameUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelFunctionNameUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelParameterNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelParameterNameUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelParameterNameUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelArgumentNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelArgumentNameUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelArgumentNameUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetModelUserTagNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetModelUserTagNameUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetModelUserTagNameUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetComponentVerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetComponentVerUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetComponentVerUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetComponentVerDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetComponentVerDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetComponentVerDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetCustomRemoteCommandUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetCustomRemoteCommandUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetCustomRemoteCommandUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetEquipmentTypeUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetEquipmentTypeUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetEquipmentTypeUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetEquipmentAreaUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetEquipmentAreaUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetEquipmentAreaUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetEquipmentLineUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetEquipmentLineUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetEquipmentLineUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetEquipmentUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetEquipmentUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetEquipmentUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetInlineEquipmentUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetInlineEquipmentUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetInlineEquipmentUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetEapUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetEapUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetEapUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetProcessEapUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetProcessEapUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetProcessEapUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapBatchModification_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapBatchModification_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapBatchModification_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapRelease_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapRelease_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapRelease_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapStart_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapStart_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapStart_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapStop_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapStop_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapStop_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapReload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapReload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapReload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapRestart_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapRestart_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapRestart_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapAbort_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapAbort_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapAbort_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapMove_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapMove_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapMove_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapLogLevelSetup_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapLogLevelSetup_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapLogLevelSetup_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapMainSwitch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapMainSwitch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapMainSwitch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnServerMainSwitch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnServerMainSwitch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnServerMainSwitch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapBackupSwitch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapBackupSwitch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapBackupSwitch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnServerBackupSwitch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnServerBackupSwitch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnServerBackupSwitch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnTransactionCertification_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnTransactionCertification_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnTransactionCertification_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapRepositoryClear_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapRepositoryClear_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapRepositoryClear_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TrnEapRepositoryRemove_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TrnEapRepositoryRemove_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TrnEapRepositoryRemove_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolEapSchemaSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapSchemaSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapSchemaSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolServerDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolServerDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolServerDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolPackageDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolPackageDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolPackageDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolPackageVerDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolPackageVerDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolPackageVerDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolModelDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolModelDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolModelDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolModelVerDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolModelVerDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolModelVerDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolComponentDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolComponentDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolComponentDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolComponentVerDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolComponentVerDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolComponentVerDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolEapDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolEquipmentTypeDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEquipmentTypeDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEquipmentTypeDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolEquipmentAreaDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEquipmentAreaDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEquipmentAreaDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolEquipmentLineDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEquipmentLineDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEquipmentLineDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolEquipmentDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEquipmentDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEquipmentDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolDeviceDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolDeviceDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolDeviceDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolEapModelDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapModelDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapModelDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolServerIssueEventRefresh_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolServerIssueEventRefresh_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolServerIssueEventRefresh_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolEapIssueEventRefresh_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapIssueEventRefresh_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapIssueEventRefresh_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolEquipmentIssueEventRefresh_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEquipmentIssueEventRefresh_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEquipmentIssueEventRefresh_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolEapLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolEapLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolEapLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapLogContinue_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapLogContinue_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolEapBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapBackupLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapBackupLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolEapBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapBackupLogSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapBackupLogSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolEapBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapBackupLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapBackupLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolEapBackupLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolEapBackupLogContinue_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolEapBackupLogContinue_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminServiceLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminServiceLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminServiceLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminServiceLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminServiceLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminServiceLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminServiceLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminServiceLogContinue_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminServiceLogContinue_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminServiceBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminServiceBackupLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminServiceBackupLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminServiceBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminServiceBackupLogSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminServiceBackupLogSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminServiceBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminServiceBackupLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminServiceBackupLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminServiceBackupLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminServiceBackupLogContinue_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminServiceBackupLogContinue_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminAgentLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminAgentLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminAgentLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminAgentLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminAgentLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminAgentLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminAgentLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminAgentLogContinue_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminAgentLogContinue_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminAgentBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminAgentBackupLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminAgentBackupLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminAgentBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminAgentBackupLogSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminAgentBackupLogSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminAgentBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminAgentBackupLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminAgentBackupLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminAgentBackupLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminAgentBackupLogContinue_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminAgentBackupLogContinue_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAlertServiceLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAlertServiceLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAlertServiceLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAlertServiceLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAlertServiceLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAlertServiceLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAlertServiceBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAlertServiceBackupLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAlertServiceBackupLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAlertServiceBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAlertServiceBackupLogSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAlertServiceBackupLogSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAlertServiceBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAlertServiceBackupLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAlertServiceBackupLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminAgentOptionSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminAgentOptionSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminAgentOptionSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolAdminAgentOptionUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolAdminAgentOptionUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolAdminAgentOptionUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_RcmEquipmentEventDefineRequest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_RcmEquipmentEventDefineRequest_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_RcmEquipmentEventDefineRequest_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_RcmEquipmentVersionRequest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_RcmEquipmentVersionRequest_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_RcmEquipmentVersionRequest_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_RcmEquipmentControlModeRequest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_RcmEquipmentControlModeRequest_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_RcmEquipmentControlModeRequest_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_RcmEquipmentCustomRequest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_RcmEquipmentCustomRequest_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_RcmEquipmentCustomRequest_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_RcmRemotePingTest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_RcmRemotePingTest_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_RcmRemotePingTest_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_InqModelVerSchemaSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_InqModelVerSchemaSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_InqModelVerSchemaSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_InqModelManualDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_InqModelManualDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_InqModelManualDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_InqEquipmentGemStatus_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_InqEquipmentGemStatus_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_InqEquipmentGemStatus_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetSecs1ToHsmsEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetSecs1ToHsmsEventUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetSecs1ToHsmsEventUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_SetSecs1ToHsmsConverterUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_SetSecs1ToHsmsConverterUpdate_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_SetSecs1ToHsmsConverterUpdate_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp(
            FXmlNode fXmlNodeIn
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp(fXmlNodeIn); /* Call User Procedure */
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeIn = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public abstract void ADMADS_TolSecs1ToHsmsConverterLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolSecs1ToHsmsConverterLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolSecs1ToHsmsConverterLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolSecs1ToHsmsConverterLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolSecs1ToHsmsConverterLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolSecs1ToHsmsConverterLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolSecs1ToHsmsConverterLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolSecs1ToHsmsConverterLogContinue_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolSecs1ToHsmsConverterLogContinue_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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

        public abstract void ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
            );

        //------------------------------------------------------------------------------------------------------------------------

        private void recv_ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req(
            FH101DataReceivedArgs e
            )
        {
            FXmlNode fXmlNodeIn = null;
            FXmlNode fXmlNodeOut = null;

            try
            {
                fXmlNodeIn = e.dataToXmlNode;
                ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req(fXmlNodeIn, ref fXmlNodeOut); /* Call User Procedure */

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
