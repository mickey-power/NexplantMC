/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSQMSQSSkeleton.cs 
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
    internal class FSQMSQSSkeleton : FSQMSQSTuner
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSQMSQSSkeleton(
            FH101 fH101
            )
            : base(fH101)
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSQMSQSSkeleton(
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

        public override void SQMSQS_SetSystemList_Req(
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

        public override void SQMSQS_SetSystemSearch_Req(
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

        public override void SQMSQS_SetSystemUpdate_Req(
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

        public override void SQMSQS_SetSystemDownload_Req(
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

        public override void SQMSQS_SetSystemMigration_Req(
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

        public override void SQMSQS_SetModuleList_Req(
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

        public override void SQMSQS_SetModuleSearch_Req(
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

        public override void SQMSQS_SetModuleUpdate_Req(
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

        public override void SQMSQS_SetFunctionList_Req(
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

        public override void SQMSQS_SetFunctionSearch_Req(
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

        public override void SQMSQS_SetFunctionUpdate_Req(
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

        public override void SQMSQS_SetSqlCodeList_Req(
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

        public override void SQMSQS_SetSqlCodeSearch_Req(
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

        public override void SQMSQS_SetSqlCodeUpdate_Req(
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

        public override void SQMSQS_TolSqlCodeExecute_Req(
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

        public override void SQMSQS_TolMove_Req(
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

        public override void SQMSQS_ViwSqlServiceLogList_Req(
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

        public override void SQMSQS_ViwSqlServiceLogDownload_Req(
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
