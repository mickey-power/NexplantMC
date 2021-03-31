/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEquipmentStateSetAltererPerformedEventArgs.cs
--  Creator         : jeff.kim
--  Create Date     : 2013.06.21
--  Description     : FAMate Core FaSecsDriver Equipment State Set Alterer Performed Event Arguments Class 
--  History         : Created by jeff.kim at 2013.06.21
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    [Serializable]
    public class FEquipmentStateSetAltererPerformedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecsDriver m_fSecsDriver = null;
        private FEquipmentStateSetAltererPerformedLog m_fEquipmentStateSetAltererPerformedLog = null;
        private FScenarioData m_fScenarioData = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FEquipmentStateSetAltererPerformedEventArgs(            
            FEventId fEventId,
            FSecsDriver fSecsDriver,
            FEquipmentStateSetAltererPerformedLog fEquipmentStateSetAltererPerformedLog,
            FScenarioData fScenarioData
            )
            : base(fEventId)
        {
            m_fSecsDriver = fSecsDriver;
            m_fEquipmentStateSetAltererPerformedLog = fEquipmentStateSetAltererPerformedLog;
            m_fScenarioData = fScenarioData;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEquipmentStateSetAltererPerformedEventArgs(
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
                    m_fSecsDriver = null;
                    m_fEquipmentStateSetAltererPerformedLog = null;
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

        public FSecsDriver fSecsDriver
        {
            get
            {
                try
                {
                    return m_fSecsDriver;
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

        public FEquipmentStateSetAltererPerformedLog fEquipmentStateSetAltererPerformedLog
        {
            get
            {
                try
                {
                    return m_fEquipmentStateSetAltererPerformedLog;
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
