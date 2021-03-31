/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FPauserAgent.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.06.18
--  Description     : FAMate Core FaSecsDriver Pauser Agent Class 
--  History         : Created by Jeff.Kim at 2013.06.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FPauserAgent : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FScdCore m_fScdCore = null;  
        // private Dictionary<string, FPauserData> m_pauserList = null;
        private List<FPauserData> m_pauserList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FPauserAgent(
            FScdCore fScdCore
            )
        {
            m_fScdCore = fScdCore;
            // m_pauserList = new Dictionary<string, FPauserData>();
            m_pauserList = new List<FPauserData>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FPauserAgent(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_fScdCore = null;
                    m_pauserList = null;
                }                
                m_disposed = true;         
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 멤버

        public void Dispose(
            )
        {
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public int count
        {
            get
            {
                try
                {
                    return m_pauserList.Count;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void executePauser(
            FPauserData fPauserData
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/*[@" + FXmlTagPAU.A_UniqueId + "='{0}']";

            // --

            FXmlNode fXmlNodePau = null;
            FXmlNode fXmlNodeFlow = null;
            FScenarioData fScenarioData = null;

            try
            {
                // ***
                // 진행할 Pauser가 삭제된경우 Return 
                // ***
                fXmlNodePau = m_fScdCore.fSecsDriver.fXmlNode.selectSingleNode(string.Format(Query, fPauserData.uniqueId));
                if (fXmlNodePau == null)
                {                                      
                    return;
                }

                // --
                
                fScenarioData = fPauserData.fScenarioData;
                
                // --

                // ***
                // 진생할 Next Flow가 존재하지 않을 경우 Return
                // ***
                if (fScenarioData.fNextFlow == null)
                {
                    return;
                }

                // --

                // ***
                // 진행할 Next Flow 가 삭제된경우 Return 
                // ***
                fXmlNodeFlow = m_fScdCore.fSecsDriver.fXmlNode.selectSingleNode(
                    string.Format(Query, ((FIObject)fScenarioData.fNextFlow).uniqueIdToString)
                    );
                if (fXmlNodeFlow == null)
                {                                      
                    return;
                }

                // --
                                
                if (fPauserData.fScenarioData.fNextFlow.fFlowType == FFlowType.SecsTransmitter)
                {   
                    FScenarioController.executeSecsTransmitter(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.HostTransmitter)
                {
                    FScenarioController.executeHostTransmitter(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.EquipmentStateSetAlterer)
                {
                    FScenarioController.executeEquipmentStateSetAlterer(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Judgement)
                {
                    FScenarioController.executeJudgement(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Mapper)
                {
                    FScenarioController.executeMapper(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Storage)
                {
                    FScenarioController.executeStorage(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Callback)
                {
                    FScenarioController.executeCallback(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Branch)
                {
                    FScenarioController.executeBranch(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Comment)
                {
                    FScenarioController.executeComment(fScenarioData);
                }
                else if (fScenarioData.fNextFlow.fFlowType == FFlowType.Pauser)
                {
                    FScenarioController.executePauser(fScenarioData);
                }                
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodePau = null;
                fXmlNodeFlow = null;
                fScenarioData = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void pushPauserData(
            FPauserRaisedLog fPauserRaisedLog,
            FScenarioData fScenarioData
            )
        {
            FPauserData data = null;

            try
            {
                data = new FPauserData(
                    fPauserRaisedLog.uniqueIdToString, 
                    fPauserRaisedLog.pauseTime, 
                    fScenarioData
                    );

                // --

                // ***
                // 2017.07.03 by spike.lee
                // 동일한 Pause 시나리오가 중복해서 발생할 경우 중복 오류가 발생함.
                // ***
                //m_pauserList.Add(
                //    fPauserRaisedLog.uniqueIdToString, 
                //    data
                //    );
                m_pauserList.Add(data);                
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

        public void checkTimeoutPauser(
            )
        {
            List<FPauserData> executedPauserList = null;

            try
            {
                if (this.count == 0)
                {
                    return;
                }

                // --

                executedPauserList = new List<FPauserData>();
                foreach (FPauserData fData in m_pauserList)
                {
                    if (fData.elasped())
                    {
                        executePauser(fData);
                        // --
                        executedPauserList.Add(fData);
                    }
                }          
      
                // --

                // 수행완료된 Pauser 는 삭제
                foreach (FPauserData fData in executedPauserList)
                {
                    m_pauserList.Remove(fData);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                executedPauserList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clear(
            )
        {
            try
            {
                m_pauserList.Clear();
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
