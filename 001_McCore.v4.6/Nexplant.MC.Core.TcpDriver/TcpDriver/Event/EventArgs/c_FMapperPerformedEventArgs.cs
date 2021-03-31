/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMapperPerformedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2011.11.30
--  Description     : FAMate Core FaTcpDriver Mapper Performed Event Arguments Class 
--  History         : Created by spike.lee at 2011.11.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    [Serializable]
    public class FMapperPerformedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FTcpDriver m_fTcpDriver = null;
        private FMapperPerformedLog m_fMapperPerformedLog = null;
        private FScenarioData m_fScenarioData = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FMapperPerformedEventArgs(            
            FEventId fEventId,
            FTcpDriver fTcpDriver,
            FMapperPerformedLog fMapperPerformedLog,
            FScenarioData fScenarioData
            )
            : base(fEventId)
        {
            m_fTcpDriver = fTcpDriver;
            m_fMapperPerformedLog = fMapperPerformedLog;
            m_fScenarioData = fScenarioData;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMapperPerformedEventArgs(
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
                    m_fMapperPerformedLog = null;
                    m_fScenarioData = null;
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

        public FMapperPerformedLog fMapperPerformedLog
        {
            get
            {
                try
                {
                    return m_fMapperPerformedLog;
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

        public FScenarioData fScenarioData
        {
            get
            {
                try
                {
                    return m_fScenarioData;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
