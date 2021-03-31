/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FAutoCycleAgent.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaPlcDriver Auto Cycle Agent Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FAutoCycleAgent : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPlcDriver m_fPlcDriver = null;        
        private List<string> m_autoCycleKeys = null;
        private Dictionary<string, FAutoCycleData> m_autoCycleList = null;
        private HashSet<string> m_onceAutoCycleKeys = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAutoCycleAgent(        
            FPlcDriver fPlcDriver    
            )
        {
            m_fPlcDriver = fPlcDriver;
            m_autoCycleKeys = new List<string>();
            m_autoCycleList = new Dictionary<string, FAutoCycleData>();
            m_onceAutoCycleKeys = new HashSet<string>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FAutoCycleAgent(
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
                    m_fPlcDriver = null;
                    m_autoCycleKeys = null;
                    m_autoCycleList = null;
                    m_onceAutoCycleKeys = null;
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
                    return m_autoCycleKeys.Count;
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

        //------------------------------------------------------------------------------------------------------------------------

        public FAutoCycleData this[int index]
        {
            get
            {
                try
                {
                    if (index < this.count)
                    {
                        return m_autoCycleList[m_autoCycleKeys[index]];
                    }
                    return null;
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

        public void collectPlcAutoCycleData(
            FPlcDevice fPlcDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagPTN.E_PlcTransmitter +
                "[" +
                "@" + FXmlTagPTN.A_UsedAutoCycle + "='{0}' and " +
                FXmlTagPTF.E_PlcTransfer + "[@" + FXmlTagPTF.A_PlcDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListPtn = null;
            string uniqueId = string.Empty;
            int period = 0;
            FAutoCycleAction fAutoCycleAction;
            FAutoCycleData fAutoCycleData = null;
            List<string> newAutoCycleKeys = null;
            Dictionary<string, FAutoCycleData> newAutoCycleList = null;

            try
            {
                fXmlNodeListPtn = m_fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fPlcDevice.uniqueIdToString));
                if (fXmlNodeListPtn.count == 0)
                {
                    if (m_autoCycleKeys.Count > 0)
                    {
                        clear();
                    }
                    return;
                }

                // --

                newAutoCycleKeys = new List<string>();
                newAutoCycleList = new Dictionary<string, FAutoCycleData>();
                // --
                foreach (FXmlNode fXmlNodePtn in fXmlNodeListPtn)
                {
                    uniqueId = fXmlNodePtn.get_attrVal(FXmlTagPTN.A_UniqueId, FXmlTagPTN.D_UniqueId);
                    period = int.Parse(fXmlNodePtn.get_attrVal(FXmlTagPTN.A_AutoCyclePeriod, FXmlTagPTN.D_AutoCyclePeriod));
                    fAutoCycleAction = FEnumConverter.toAutoCycleAction(fXmlNodePtn.get_attrVal(FXmlTagPTN.A_AutoCycleAction, FXmlTagPTN.D_AutoCycleAction));

                    // --

                    if (m_autoCycleKeys.Contains(uniqueId))
                    {
                        fAutoCycleData = m_autoCycleList[uniqueId];

                        // --

                        if (fAutoCycleData.period == period && fAutoCycleData.fAction == fAutoCycleAction)
                        {
                            if (fAutoCycleAction == FAutoCycleAction.Once)
                            {
                                // ***
                                // Once Auto Cycle이 이미 실행되었을 경우 Skip
                                // *** 
                                if (m_onceAutoCycleKeys.Contains(uniqueId))
                                {
                                    continue;
                                }
                            }
                            // --
                            newAutoCycleKeys.Add(uniqueId);
                            newAutoCycleList.Add(uniqueId, fAutoCycleData);
                        }
                        else
                        {
                            if (fAutoCycleAction == FAutoCycleAction.Once)
                            {
                                // ***
                                // Once Auto Cycle이 이미 실행되었을 경우 Skip
                                // *** 
                                if (m_onceAutoCycleKeys.Contains(uniqueId))
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                // ***
                                // Once Auto Cycle에서 Repeat Auto Cycle로 변경되었을 경우 Once Auto Cycle 수행 해제
                                // ***
                                if (m_onceAutoCycleKeys.Contains(uniqueId))
                                {
                                    m_onceAutoCycleKeys.Remove(uniqueId);
                                }
                            }
                            // --
                            newAutoCycleKeys.Add(uniqueId);
                            newAutoCycleList.Add(uniqueId, new FAutoCycleData(uniqueId, period, fAutoCycleAction, fXmlNodePtn));
                        }
                    }
                    else
                    {
                        newAutoCycleKeys.Add(uniqueId);
                        newAutoCycleList.Add(uniqueId, new FAutoCycleData(uniqueId, period, fAutoCycleAction, fXmlNodePtn));
                    }
                }

                // --

                m_autoCycleKeys = newAutoCycleKeys;
                m_autoCycleList = newAutoCycleList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListPtn = null;
                fAutoCycleData = null;
                newAutoCycleKeys = null;
                newAutoCycleList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void collectHostAutoCycleData(
            FHostDevice fHostDevice
            )
        {
            const string Query =
                FXmlTagEQM.E_EquipmentModeling + "/" +
                FXmlTagEQP.E_Equipment + "/" +
                FXmlTagSNG.E_ScenarioGroup + "/" +
                FXmlTagSNR.E_Scenario + "/" +
                FXmlTagHTN.E_HostTransmitter +
                "[" +
                "@" + FXmlTagHTN.A_UsedAutoCycle + "='{0}' and " +
                FXmlTagHTF.E_HostTransfer + "[@" + FXmlTagHTF.A_HostDeviceId + "='{1}']" +
                "]";

            // --

            FXmlNodeList fXmlNodeListHtn = null;
            string uniqueId = string.Empty;
            int period = 0;
            FAutoCycleAction fAutoCycleAction;
            FAutoCycleData fAutoCycleData = null;
            List<string> newAutoCycleKeys = null;
            Dictionary<string, FAutoCycleData> newAutoCycleList = null;

            try
            {
                fXmlNodeListHtn = m_fPlcDriver.fXmlNode.selectNodes(string.Format(Query, FBoolean.True, fHostDevice.uniqueIdToString));
                if (fXmlNodeListHtn.count == 0)
                {
                    if (m_autoCycleKeys.Count > 0)
                    {
                        clear();
                    }
                    return;
                }

                // --

                newAutoCycleKeys = new List<string>();
                newAutoCycleList = new Dictionary<string, FAutoCycleData>();
                // --
                foreach (FXmlNode fXmlNodeHtn in fXmlNodeListHtn)
                {
                    uniqueId = fXmlNodeHtn.get_attrVal(FXmlTagHTN.A_UniqueId, FXmlTagHTN.D_UniqueId);
                    period = int.Parse(fXmlNodeHtn.get_attrVal(FXmlTagHTN.A_AutoCyclePeriod, FXmlTagHTN.D_AutoCyclePeriod));
                    fAutoCycleAction = FEnumConverter.toAutoCycleAction(fXmlNodeHtn.get_attrVal(FXmlTagHTN.A_AutoCycleAction, FXmlTagHTN.D_AutoCycleAction));

                    // --

                    if (m_autoCycleKeys.Contains(uniqueId))
                    {
                        fAutoCycleData = m_autoCycleList[uniqueId];

                        // --

                        if (fAutoCycleData.period == period && fAutoCycleData.fAction == fAutoCycleAction)
                        {
                            if (fAutoCycleAction == FAutoCycleAction.Once)
                            {
                                // ***
                                // Once Auto Cycle이 이미 실행되었을 경우 Skip
                                // *** 
                                if (m_onceAutoCycleKeys.Contains(uniqueId))
                                {
                                    continue;
                                }
                            }
                            // --
                            newAutoCycleKeys.Add(uniqueId);
                            newAutoCycleList.Add(uniqueId, fAutoCycleData);
                        }
                        else
                        {
                            if (fAutoCycleAction == FAutoCycleAction.Once)
                            {
                                // ***
                                // Once Auto Cycle이 이미 실행되었을 경우 Skip
                                // *** 
                                if (m_onceAutoCycleKeys.Contains(uniqueId))
                                {
                                    continue;
                                }
                            }
                            else
                            {
                                // ***
                                // Once Auto Cycle에서 Repeat Auto Cycle로 변경되었을 경우 Once Auto Cycle 수행 해제
                                // ***
                                if (m_onceAutoCycleKeys.Contains(uniqueId))
                                {
                                    m_onceAutoCycleKeys.Remove(uniqueId);
                                }
                            }
                            // --
                            newAutoCycleKeys.Add(uniqueId);
                            newAutoCycleList.Add(uniqueId, new FAutoCycleData(uniqueId, period, fAutoCycleAction, fXmlNodeHtn));
                        }
                    }
                    else
                    {
                        newAutoCycleKeys.Add(uniqueId);
                        newAutoCycleList.Add(uniqueId, new FAutoCycleData(uniqueId, period, fAutoCycleAction, fXmlNodeHtn));
                    }
                }

                // --

                m_autoCycleKeys = newAutoCycleKeys;
                m_autoCycleList = newAutoCycleList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListHtn = null;
                fAutoCycleData = null;
                newAutoCycleKeys = null;
                newAutoCycleList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FAutoCycleDataCollection getTimeoutAutoCycleData(
            )
        {
            FAutoCycleDataCollection collection = null;

            try
            {
                collection = new FAutoCycleDataCollection();                
                // --
                
                foreach (FAutoCycleData fData in m_autoCycleList.Values)
                {
                    if (fData.elasped())
                    {
                        collection.add(fData);
                        if (fData.fAction == FAutoCycleAction.Once)
                        {
                            m_onceAutoCycleKeys.Add(fData.uniqueId);
                        }
                    }
                }                
                // --
                return collection;
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

        //------------------------------------------------------------------------------------------------------------------------

        public void clear(
            )
        {
            try
            {
                m_autoCycleKeys.Clear();
                m_autoCycleList.Clear();
                m_onceAutoCycleKeys.Clear();
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
