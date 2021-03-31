/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FAutoTraceAgent.cs
--  Creator         : jungyoul.moon
--  Create Date     : 2013.11.18
--  Description     : FAMate Core FaPlcDriver Auto Trace Agent Class 
--  History         : Created by jungyoul.moon at 2013.11.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FAutoTraceAgent : IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPlcDriver m_fPlcDriver = null;
        private List<string> m_autoTraceKeys = null;
        private Dictionary<string, FAutoTraceData> m_autoTraceList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FAutoTraceAgent(        
            FPlcDriver fPlcDriver    
            )
        {
            m_fPlcDriver = fPlcDriver;
            m_autoTraceKeys = new List<string>();
            m_autoTraceList = new Dictionary<string, FAutoTraceData>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FAutoTraceAgent(
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
                    m_autoTraceKeys = null;
                    m_autoTraceList = null;
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
                    return m_autoTraceKeys.Count;
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

        public FAutoTraceData this[int index]
        {
            get
            {
                try
                {
                    if (index < this.count)
                    {
                        return m_autoTraceList[m_autoTraceKeys[index]];
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

        public void collectPlcAutoTraceData(
            FPlcSession fPsn
            )
        {
            const string Query =
                FXmlTagPLM.E_PlcLibraryModeling +
                "/" + FXmlTagPLG.E_PlcLibraryGroup +
                "/" + FXmlTagPLB.E_PlcLibrary + "[@" + FXmlTagPLB.A_UniqueId + "='{0}']" +
                "/" + FXmlTagPML.E_PlcMessageList +
                "/" + FXmlTagPMS.E_PlcMessages + "[@" + FXmlTagPMS.A_Direction + "='{1}']" +
                "/" + FXmlTagPMG.E_PlcMessage +
                "[@" + FXmlTagPMG.A_UsedAutoTrace + "='{2}']";

            FAutoTraceData fAutoTraceData = null;
            FXmlNodeList fXmlNodeListPmg = null;
            List<string> newAutoTraceKeys = null;
            Dictionary<string, FAutoTraceData> newAutoTraceList = null;
            // --
            string xpath = string.Empty;
            string uniqueId = string.Empty;
            int period = 0;


            try
            {
                xpath = string.Format(
                       Query,
                       fPsn.fLibrary.uniqueIdToString,
                       FEnumConverter.fromPlcDirection(FPlcDirection.Read),
                       FBoolean.True
                       );

                // --

                fXmlNodeListPmg = m_fPlcDriver.fXmlNode.selectNodes(xpath);
                if (fXmlNodeListPmg.count == 0)
                {
                    if (m_autoTraceKeys.Count > 0)
                    {
                        clear();
                    }
                    return;
                }

                // --

                newAutoTraceKeys = new List<string>();
                newAutoTraceList = new Dictionary<string, FAutoTraceData>();
                
                // --

                foreach (FXmlNode fXmlNodePmg in fXmlNodeListPmg)
                {
                    if (fXmlNodePmg.selectSingleNode(FXmlTagPBL.E_PlcBitList).fChildNodes.count == 0 &&
                        fXmlNodePmg.selectSingleNode(FXmlTagPWL.E_PlcWordList).fChildNodes.count == 0
                        )
                    {
                        continue;
                    }

                    // --

                    uniqueId = fXmlNodePmg.get_attrVal(FXmlTagPMG.A_UniqueId, FXmlTagPMG.D_UniqueId);
                    period = int.Parse(fXmlNodePmg.get_attrVal(FXmlTagPMG.A_AutoTracePeriod, FXmlTagPMG.D_AutoTracePeriod));

                    // --

                    if (m_autoTraceKeys.Contains(uniqueId))
                    {
                        fAutoTraceData = m_autoTraceList[uniqueId];

                        // --

                        newAutoTraceKeys.Add(uniqueId);
                        if (fAutoTraceData.period == period)
                        {
                            newAutoTraceList.Add(uniqueId, fAutoTraceData);
                        }
                        else
                        {
                            newAutoTraceList.Add(uniqueId, new FAutoTraceData(uniqueId, period, fXmlNodePmg));
                        }
                    }
                    else
                    {
                        newAutoTraceKeys.Add(uniqueId);
                        newAutoTraceList.Add(uniqueId, new FAutoTraceData(uniqueId, period, fXmlNodePmg));
                    }
                }

                // --

                m_autoTraceKeys = newAutoTraceKeys;
                m_autoTraceList = newAutoTraceList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fAutoTraceData = null;
                fXmlNodeListPmg = null;
                newAutoTraceKeys = null;
                newAutoTraceList = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FAutoTraceDataCollection getTimeoutAutoTraceData(
            )
        {
            FAutoTraceDataCollection collection = null;

            try
            {
                collection = new FAutoTraceDataCollection();

                // --

                foreach (FAutoTraceData fData in m_autoTraceList.Values)
                {
                    if (fData.elasped())
                    {
                        collection.add(fData);
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
                collection = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void clear(
            )
        {
            try
            {
                m_autoTraceKeys.Clear();
                m_autoTraceList.Clear();
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

    } // End Class
} // End Namespace
