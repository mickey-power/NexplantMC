/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FRepositoryMaterialSavedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2017.05.31
--  Description     : FAmate Core FaTcpDriver Repository Material Saved Event Arguments Class 
--  History         : Created by spike.lee at 2017.05.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    [Serializable]
    public class FRepositoryMaterialSavedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpDriver m_fTcpDriver = null;
        private FRepositoryMaterialStorage m_fRepositoryMaterialStorage = null;
        private FStorageAction m_fAction = FStorageAction.Create;
        private string m_rawData = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FRepositoryMaterialSavedEventArgs(            
            FEventId fEventId,
            FTcpDriver fTcpDriver,
            FRepositoryMaterialStorage fRepositoryMaterialStorage,
            FStorageAction fAction,
            string rawData
            )
            : base(fEventId)
        {
            m_fTcpDriver = fTcpDriver;
            m_fRepositoryMaterialStorage = fRepositoryMaterialStorage;
            m_fAction = fAction;
            m_rawData = rawData;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FRepositoryMaterialSavedEventArgs(
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
                    m_fTcpDriver = null;
                    m_fRepositoryMaterialStorage = null;
                }                

                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FTcpDriver fTcpDriver
        {
            get
            {
                try
                {
                    return m_fTcpDriver;
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

        public FRepositoryMaterialStorage fRepositoryMaterialStorage
        {
            get
            {
                try
                {
                    return m_fRepositoryMaterialStorage;
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

        public FStorageAction fAction
        {
            get
            {
                try
                {
                    return m_fAction;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FStorageAction.Create;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string rawData
        {
            get
            {
                try
                {
                    return m_rawData;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);   
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
