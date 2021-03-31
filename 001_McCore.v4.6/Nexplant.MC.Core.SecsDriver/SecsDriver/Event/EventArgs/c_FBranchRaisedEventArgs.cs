/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBranchRaisedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2011.11.02
--  Description     : FAMate Core FaSecsDriver Branch Raised Event Arguments Class 
--  History         : Created by spike.lee at 2011.11.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    [Serializable]
    public class FBranchRaisedEventArgs : FEventArgsBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecsDriver m_fSecsDriver = null;        
        private FBranchRaisedLog m_fBranchRaisedLog = null;
        private FScenarioData m_fScenarioData = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FBranchRaisedEventArgs(            
            FEventId fEventId,
            FSecsDriver fSecsDriver,
            FBranchRaisedLog fBranchRaisedLog,
            FScenarioData fScenarioData
            )
            : base(fEventId)
        {
            m_fSecsDriver = fSecsDriver;
            m_fBranchRaisedLog = fBranchRaisedLog;
            m_fScenarioData = fScenarioData;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FBranchRaisedEventArgs(
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
                    m_fBranchRaisedLog = null;
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

        public FBranchRaisedLog fBranchRaisedLog
        {
            get
            {
                try
                {
                    return m_fBranchRaisedLog;
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
