/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2018 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FADMADSSkeleton.cs 
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
    internal class FADMADSSkeleton : FADMADSTuner
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FADMADSSkeleton(
            FH101 fH101
            ) : base(fH101)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FADMADSSkeleton(
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

                }

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public override void ADMADS_ComSqlQuery_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_ComEapSchemaSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_DlgEapWizardEapSchemaSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SysLogIn_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SysUserNoticeUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SysPasswordChange_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SysPasswordReset_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SysHostDriverDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetFactoryUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetNoticeUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetGcmTableUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetGcmDataUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetServerEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetEapEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetEquipmentEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetUserEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetUserGroupApplicationUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetUserGroupFunctionUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetUserGroupAuthorityUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetUserGroupAlertUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetUserGroupUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetUserUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetServerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelSheetUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetMakerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetHostDriverUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetHostDriverDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetPackageUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetComponentUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetPackageVerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetPackageVerDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelVerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelVerDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelManualUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelManualDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelStateUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelObjectNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelFunctionNameListUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelFunctionNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelParameterNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelArgumentNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetModelUserTagNameUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetComponentVerUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetComponentVerDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetCustomRemoteCommandUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetEquipmentTypeUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetEquipmentAreaUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetEquipmentLineUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetEquipmentUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetInlineEquipmentUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetEapUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetProcessEapUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapBatchModification_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapRelease_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapStart_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapStop_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapReload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapRestart_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapAbort_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapMove_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapLogLevelSetup_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapMainSwitch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnServerMainSwitch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapBackupSwitch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnServerBackupSwitch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnTransactionCertification_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapRepositoryClear_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TrnEapRepositoryRemove_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolEapSchemaSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolServerDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolPackageDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolPackageVerDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolModelDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolModelVerDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolComponentDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolComponentVerDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolEapDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolEquipmentTypeDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolEquipmentAreaDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolEquipmentLineDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolEquipmentDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolDeviceDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolEapModelDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolServerIssueEventRefresh_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolEapIssueEventRefresh_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolEquipmentIssueEventRefresh_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolEapLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolEapLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolEapLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolEapBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolEapBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolEapBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolEapBackupLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminServiceLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminServiceLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminServiceLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminServiceBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminServiceBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminServiceBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminServiceBackupLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminAgentLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminAgentLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminAgentLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminAgentBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminAgentBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminAgentBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminAgentBackupLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAlertServiceLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAlertServiceLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAlertServiceBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAlertServiceBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAlertServiceBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminAgentOptionSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolAdminAgentOptionUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_RcmEquipmentEventDefineRequest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_RcmEquipmentVersionRequest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_RcmEquipmentControlModeRequest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_RcmEquipmentCustomRequest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_RcmRemotePingTest_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_InqModelVerSchemaSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_InqModelManualDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_InqEquipmentGemStatus_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetSecs1ToHsmsEventUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_SetSecs1ToHsmsConverterUpdate_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolSecs1ToHsmsConverterDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolSecs1ToHsmsConverterDisconnectDataPush_Nrp(
            FXmlNode fXmlNodeIn
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

        public override void ADMADS_TolSecs1ToHsmsConverterLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolSecs1ToHsmsConverterLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolSecs1ToHsmsConverterLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolSecs1ToHsmsConverterBackupLogList_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolSecs1ToHsmsConverterBackupLogSearch_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolSecs1ToHsmsConverterBackupLogDownload_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        public override void ADMADS_TolSecs1ToHsmsConverterBackupLogContinue_Req(
            FXmlNode fXmlNodeIn,
            ref FXmlNode fXmlNodeOut
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
