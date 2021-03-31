/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEquipmentStateMaterialStorage.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.06.27
--  Description     : FAMate Core FaPlcDriver Equipment State Material Storage Class 
--  History         : Created by Jeff.Kim at 2013.06.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FEquipmentStateMaterialStorage : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPcdCore m_fPcdCore = null;
        private FCodeLock m_fCodeLock = null;
        private FEquipmentStateMaterialCollection m_fEquipmentStateMaterialCollection = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FEquipmentStateMaterialStorage(                        
            FPcdCore fPcdCore
            )
        {
            m_fPcdCore = fPcdCore;
            m_fCodeLock = new FCodeLock();
            m_fEquipmentStateMaterialCollection = new FEquipmentStateMaterialCollection();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEquipmentStateMaterialStorage(
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
                    if (m_fEquipmentStateMaterialCollection != null)
                    {
                        m_fEquipmentStateMaterialCollection.Dispose();
                        m_fEquipmentStateMaterialCollection = null;
                    }

                    if (m_fCodeLock != null)
                    {
                        m_fCodeLock.Dispose();
                        m_fCodeLock = null;
                    }

                    m_fPcdCore = null;   
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

        public FEquipmentStateMaterialCollection fEquipmentStateMaterialCollection
        {
            get
            {
                try
                {
                    return m_fEquipmentStateMaterialCollection;
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

        public void add(
            FEquipmentStateMaterial fEquipmentStateMaterial
            )
        {
            try
            {
                m_fCodeLock.wait();

                // --

                m_fEquipmentStateMaterialCollection.add(fEquipmentStateMaterial);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void remove(
            FEquipmentStateMaterial fEquipmentStateMaterial
            )
        {
            try
            {
                m_fCodeLock.wait();

                // --

                m_fEquipmentStateMaterialCollection.remove(fEquipmentStateMaterial);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                m_fCodeLock.set();
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FEquipmentStateMaterial getEquipmentStateMaterial(
            string eqUniqueId,
            string estUniqueId
            )
        {
            const string EquipmentsStateQuery =
                FXmlTagSET.E_Setup +
                "/" + FXmlTagESD.E_EquipmentStateSetDefinition +
                "/" + FXmlTagESL.E_EquipmentStateSetList +
                "/" + FXmlTagESS.E_EquipmentStateSet +
                "/" + FXmlTagEST.E_EquipmentState + "[@" + FXmlTagEST.A_UniqueId + "='{0}']";
            
            // --

            FXmlNode fEstNode = null;
            FEquipmentStateMaterial fEsm = null;
            UInt64 eqId = 0;
            UInt64 estId = 0;
            string defaultState = string.Empty;
            try
            {
                m_fCodeLock.wait();

                // --

                eqId = UInt64.Parse(eqUniqueId);
                estId = UInt64.Parse(estUniqueId);
                foreach (FEquipmentStateMaterial esm in m_fEquipmentStateMaterialCollection)
                {
                    if (esm.containsEquipmentStateKey(eqId, estId))
                    {
                        fEsm = esm;
                        break;
                    }
                }

                // -- 
                // 저장된 State가 없을 경우 EquipmentStateSet의 기본값을 갔는다.
                if (fEsm == null)
                {
                    fEstNode = m_fPcdCore.fPlcDriver.fXmlNode.selectSingleNode(string.Format(EquipmentsStateQuery, estUniqueId));
                    if (fEstNode != null)
                    {
                        // --

                        defaultState = fEstNode.get_attrVal(FXmlTagEST.A_DefaultValue, FXmlTagEST.D_DefaultValue);
                        if (defaultState != FXmlTagEST.D_DefaultValue)
                        {
                            // --

                            fEsm = new FEquipmentStateMaterial(
                                this.fPcdCore,
                                defaultState);
                            fEsm.setEquipmentStateKey(eqId, estId);

                            // --

                            this.fPcdCore.fEquipmentStateMaterialStorage.add(fEsm);
                        }                        
                    }
                }

                return fEsm;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fEstNode = null;
                fEsm = null;
                m_fCodeLock.set();
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
