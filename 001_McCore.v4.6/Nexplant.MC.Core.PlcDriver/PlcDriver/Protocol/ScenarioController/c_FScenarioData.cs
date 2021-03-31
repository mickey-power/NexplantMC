/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FScenarioData.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.07.16
--  Description     : FAMate Core FaPlcDriver Scenario Data Class 
--  History         : Created by Jeff.Kim at 2013.07.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FScenarioData : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPcdCore m_fPcdCore = null;
        private FEquipment m_fEquipment = null;
        private FScenario m_fScenario = null;
        private FIFlow m_fNextFlow = null;
        private FFunction m_fNextFunction = null;
        private FIMessageLog m_fDataMessageReceivedLog = null;
        private FMapperPerformedLog m_fMapperPerformedLog = null;
        private FStoragePerformedLog m_fStoragePerformedLog = null;
        private FEquipmentStateSetAltererPerformedLog m_fEquipmentStateSetAltererPerformedLog = null;
        private FIObjectLog m_fIObjectLog = null;
        private FTransferCollection m_fTransferCollection = null;
        private FResourceData m_fResourceData = null;
        private FRepositoryMaterial m_fRepositoryMaterial = null;
        private object m_entryPointData = null;
        private bool m_transmitterCompleted = false;    // Auto Action Completed 여부용 Flag

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FScenarioData(                
            FPcdCore fScdCore
            )
        {
            m_fPcdCore = fScdCore;
            m_fResourceData = new FResourceData();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FScenarioData(
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
                    m_fPcdCore = null;
                    m_fEquipment = null;
                    m_fScenario = null;
                    m_fNextFlow = null;
                    m_fNextFunction = null;
                    m_fDataMessageReceivedLog = null;
                    m_fMapperPerformedLog = null;
                    m_fStoragePerformedLog = null;
                    m_fEquipmentStateSetAltererPerformedLog = null;
                    m_fTransferCollection = null;
                    m_fIObjectLog = null;
                    m_fRepositoryMaterial = null;
                    // --
                    if (m_fResourceData != null)
                    {
                        m_fResourceData.Dispose();
                        m_fResourceData = null;
                    }
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

        internal FPcdCore fPcdCore
        {
            get
            {
                try
                {
                    return m_fPcdCore;
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

        public FEquipment fEquipment
        {
            get
            {
                try
                {
                    return m_fEquipment;
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

        public FScenario fScenario
        {
            get
            {
                try
                {
                    return m_fScenario;
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

        public FIFlow fNextFlow
        {
            get
            {
                try
                {
                    return m_fNextFlow;
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

        public FFunction fNextFunction
        {
            get
            {
                try
                {
                    return m_fNextFunction;
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

        public FIMessageLog fDataMessageReceivedLog
        {
            get
            {
                try
                {
                    return m_fDataMessageReceivedLog;
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

        public FStoragePerformedLog fStoragePerformedLog
        {
            get
            {
                try
                {
                    return m_fStoragePerformedLog;
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

        public FIObjectLog fIObjectLog
        {
            get
            {
                try
                {
                    return m_fIObjectLog;
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

        public FTransferCollection fTransferCollection
        {
            get
            {
                try
                {
                    return m_fTransferCollection;
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

        public FResourceData fResourceData
        {
            get
            {
                try
                {
                    return m_fResourceData;
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

        public FRepositoryMaterial fRepositoryMaterial
        {
            get
            {
                try
                {
                    return m_fRepositoryMaterial;
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

        public object entryPointData
        {
            get
            {
                try
                {
                    return m_entryPointData;
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

        public bool hasNextFlow
        {
            get
            {
                try
                {
                    return m_fNextFlow == null ? false : true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasNextFunction
        {
            get
            {
                try
                {
                    return m_fNextFunction == null ? false : true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasDataMessageReceivedLog
        {
            get
            {
                try
                {
                    return m_fDataMessageReceivedLog == null ? false : true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasMapperPerformedLog
        {
            get
            {
                try
                {
                    return m_fMapperPerformedLog == null ? false : true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasEquipmentStateSetAltererPerformedLog
        {
            get
            {
                try
                {
                    return m_fEquipmentStateSetAltererPerformedLog == null ? false : true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasStoragePerformedLog
        {
            get
            {
                try
                {
                    return m_fStoragePerformedLog == null ? false : true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasTransferCollection
        {
            get
            {
                try
                {
                    return m_fTransferCollection == null ? false : true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public bool hasRepositoryMaterial
        {
            get
            {
                try
                {
                    return m_fRepositoryMaterial == null ? false : true;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal bool transmitterCompleted
        {
            get
            {
                try
                {
                    return m_transmitterCompleted;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return false;
            }

            set
            {
                try
                {
                    m_transmitterCompleted = value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        internal void setEquipment(
            FEquipment value
            )
        {
            try
            {
                m_fEquipment = value;
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

        internal void setScenario(
            FScenario value
            )
        {
            try
            {
                m_fScenario = value;
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

        internal void setNextFlow(
            FIFlow value
            )
        {
            try
            {
                m_fNextFlow = value;
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

        internal void setNextFunction(
            FFunction value
            )
        {
            try
            {
                m_fNextFunction = value;
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

        internal void setDataMessageReceivedLog(
            FIMessageLog value
            )
        {
            try
            {
                m_fDataMessageReceivedLog = value;
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

        internal void setMapperPerformedLog(
            FMapperPerformedLog value
            )
        {
            try
            {
                m_fMapperPerformedLog = value;
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

        internal void setEquipmentStateSetAltererPerformedLog(
            FEquipmentStateSetAltererPerformedLog value
            )
        {
            try
            {
                m_fEquipmentStateSetAltererPerformedLog = value;
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

        internal void setStoragePerformedLog(
            FStoragePerformedLog value
            )
        {
            try
            {
                m_fStoragePerformedLog = value;
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

        internal void setTransferCollection(
            FTransferCollection value
            )
        {
            try
            {
                m_fTransferCollection = value;
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

        internal void setRepositoryMaterial(
            FRepositoryMaterial value
            )
        {
            try
            {
                m_fRepositoryMaterial = value;
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

        internal void setIObjectLog(
            FIObjectLog value
            )
        {
            try
            {
                m_fIObjectLog = value;
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

        internal void setEntryPointData(
            object entryPointData
            )
        {
            try
            {
                m_entryPointData = entryPointData;
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
