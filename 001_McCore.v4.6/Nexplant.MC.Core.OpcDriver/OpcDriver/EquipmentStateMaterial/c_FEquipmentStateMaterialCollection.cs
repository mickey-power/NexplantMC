/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEquipmentStateMaterialCollection.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.10
--  Description     : FAMate Core FaOpcDriver Repository Material Collection Class 
--  History         : Created by spike.lee at 2012.01.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaOpcDriver
{
    public class FEquipmentStateMaterialCollection : FIEnumerable, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<FEquipmentStateMaterial> m_fEquipmentStateMaterialList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FEquipmentStateMaterialCollection(                        
            )
        {
            m_fEquipmentStateMaterialList = new List<FEquipmentStateMaterial>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FEquipmentStateMaterialCollection(
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
                    m_fEquipmentStateMaterialList = null;
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
                    return m_fEquipmentStateMaterialList.Count;
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

        public FEquipmentStateMaterial this[int i]
        {
            get
            {
                try
                {
                    if (i < this.count)
                    {
                        return m_fEquipmentStateMaterialList[i];
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

        public IEnumerator GetEnumerator(
            )
        {
            try
            {
                return new FEquipmentStateMaterialCollectionEnumerator(this);
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

        public object item(
            int index
            )
        {
            try
            {
                return this[index];
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

        internal void add(
            FEquipmentStateMaterial fEquipmentStateMaterial
            )
        {
            // --

            List<FEquipmentStateMaterial> fDuplicateEquipmentStateMaterialList = null;
            FEquipmentStateMaterial fOldEquipmentStateMaterial = null; 
            // --
            FQueue<string> fNewQueue = null;
            List<string> newList = null;
            string stateValue = string.Empty;

            try
            {
                fDuplicateEquipmentStateMaterialList = new List<FEquipmentStateMaterial>();   
                
                // --

                // ***
                // Primary Key 중복 검사
                // ***
                // --
                for (int i = 0; i < m_fEquipmentStateMaterialList.Count; i++)
                {
                    fOldEquipmentStateMaterial = m_fEquipmentStateMaterialList[i];

                    // --

                    if (fEquipmentStateMaterial.equipmentStateMaterialKey != fOldEquipmentStateMaterial.equipmentStateMaterialKey)
                    {
                        continue;
                    }

                    // --

                    fDuplicateEquipmentStateMaterialList.Add(fOldEquipmentStateMaterial);

                    // --
                }

                // --
                stateValue = fEquipmentStateMaterial.stateValue;
                foreach (FEquipmentStateMaterial fEsm in fDuplicateEquipmentStateMaterialList)
                {
                    if (fEquipmentStateMaterial.isQueuing)
                    {
                        // --

                        fNewQueue = fEsm.stateValueQueue;
                        newList = fEsm.stateValueList;
                        if (!fEquipmentStateMaterial.isDuplication)
                        {
                            if (!fEsm.stateValueList.Contains(stateValue))
                            {
                                if (fEquipmentStateMaterial.duplicationIgnoreValue != string.Empty)
                                {
                                    foreach (string iVal in fEquipmentStateMaterial.duplicationIgnoreValue.Split(new char[] {';'}))
                                    {
                                        if (iVal == stateValue)
                                        {
                                            fNewQueue.enqueue(stateValue);
                                            newList.Add(stateValue);
                                            break;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                fNewQueue.enqueue(stateValue);
                                newList.Add(stateValue);
                            }
                        }
                        else 
                        {
                            fNewQueue.enqueue(fEquipmentStateMaterial.stateValue);
                            newList.Add(stateValue);
                        }
                        
                        // --

                        fEquipmentStateMaterial.stateValueQueue = fNewQueue;
                        fEquipmentStateMaterial.stateValueList = newList;
                    }
                    // --
                    m_fEquipmentStateMaterialList.Remove(fEsm);
                }

                // --

                m_fEquipmentStateMaterialList.Add(fEquipmentStateMaterial);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDuplicateEquipmentStateMaterialList = null;
                fOldEquipmentStateMaterial = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void remove(
            FEquipmentStateMaterial fEquipmentStateMaterial
            )
        {
            try
            {
                if (m_fEquipmentStateMaterialList.Contains(fEquipmentStateMaterial))
                {
                    m_fEquipmentStateMaterialList.Remove(fEquipmentStateMaterial);
                }
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

        internal void clear(
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
