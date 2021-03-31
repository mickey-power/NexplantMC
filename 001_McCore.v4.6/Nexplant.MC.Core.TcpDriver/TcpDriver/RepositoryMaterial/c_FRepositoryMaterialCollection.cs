/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FRepositoryMaterialCollection.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.10
--  Description     : FAMate Core FaTcpDriver Repository Material Collection Class 
--  History         : Created by spike.lee at 2012.01.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    public class FRepositoryMaterialCollection : FIEnumerable, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<FRepositoryMaterial> m_fRepositoryMaterialList = null;
        private Dictionary<UInt64, FRepositoryMaterial> m_fRepositoryMaterialDic = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FRepositoryMaterialCollection(                        
            )
        {
            m_fRepositoryMaterialList = new List<FRepositoryMaterial>();
            m_fRepositoryMaterialDic = new Dictionary<UInt64, FRepositoryMaterial>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FRepositoryMaterialCollection(
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
                    m_fRepositoryMaterialList = null;
                    m_fRepositoryMaterialDic = null;
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
                    return m_fRepositoryMaterialList.Count;
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

        public FRepositoryMaterial this[int i]
        {
            get
            {
                try
                {
                    if (i < this.count)
                    {
                        return m_fRepositoryMaterialList[i];
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
                return new FRepositoryMaterialCollectionEnumerator(this);
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
            FRepositoryMaterial fRepositoryMaterial
            )
        {
            const string ColumnQuery1 = "//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_PrimaryKey + "='" + FBoolean.True + "']";
            const string ColumnQuery2 = "//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_DuplicationKey + "='" + FBoolean.True + "']";
            const string ColumnQuery3 = "//" + FXmlTagCOL.E_Column + "[@" + FXmlTagCOL.A_UniqueId + "='{0}' and @" + FXmlTagCOL.A_Value + "='{1}']";

            // --

            List<FRepositoryMaterial> fDuplicateRepositoryMaterialList = null;
            FRepositoryMaterial fOldRepositoryMaterial = null;            
            FXmlNode fXmlNodeRpm1 = null;
            FXmlNode fXmlNodeRpm2 = null;
            FXmlNodeList fXmlNodeListCol = null;
            string xpath = string.Empty;
            bool isDuplicate = false;

            try
            {
                fDuplicateRepositoryMaterialList = new List<FRepositoryMaterial>();                
                fXmlNodeRpm1 = fRepositoryMaterial.fXmlNode;
                
                // --

                // ***
                // Primary Key 중복 검사
                // --
                // 2017.03.20 by spike.lee 
                // Primary Key가 없을 경우 Repository Remove되는 Bug 수정
                // ***
                fXmlNodeListCol = fXmlNodeRpm1.selectNodes(ColumnQuery1);
                // --
                if (fXmlNodeListCol.count > 0)
                {
                    for (int i = 0; i < m_fRepositoryMaterialList.Count; i++)
                    {
                        fOldRepositoryMaterial = m_fRepositoryMaterialList[i];
                        fXmlNodeRpm2 = fOldRepositoryMaterial.fXmlNode;

                        // --

                        if (fXmlNodeRpm1.get_attrVal(FXmlTagRPM.A_UniqueId, FXmlTagRPM.D_UniqueId) != fXmlNodeRpm2.get_attrVal(FXmlTagRPM.A_UniqueId, FXmlTagRPM.D_UniqueId))
                        {
                            continue;
                        }

                        // --

                        foreach (FXmlNode fXmlNodeCol in fXmlNodeListCol)
                        {
                            // ***
                            // 1개의 Column이 중복되더라도 이전 Repository Material 제거
                            // ***
                            xpath = string.Format(
                                ColumnQuery3,
                                fXmlNodeCol.get_attrVal(FXmlTagCOL.A_UniqueId, FXmlTagCOL.D_UniqueId),
                                fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value)
                                );
                            // --
                            if (fXmlNodeRpm2.containsNode(xpath))
                            {
                                fDuplicateRepositoryMaterialList.Add(fOldRepositoryMaterial);
                                System.Diagnostics.Debug.WriteLine("PrimaryKeyDuplicate");
                                break;
                            }
                        }
                    }
                }                

                // --

                // ***
                // Duplication Key 중복 검사
                // --
                // 2017.03.20 by spike.lee 
                // Duplicate Key가 없을 경우 Repository Remove되는 Bug 수정
                // ***
                fXmlNodeListCol = fXmlNodeRpm1.selectNodes(ColumnQuery2);
                // --
                if (fXmlNodeListCol.count > 0)
                {
                    for (int i = 0; i < m_fRepositoryMaterialList.Count; i++)
                    {
                        fOldRepositoryMaterial = m_fRepositoryMaterialList[i];
                        if (fDuplicateRepositoryMaterialList.Contains(fOldRepositoryMaterial))
                        {
                            continue;
                        }
                        // --
                        fXmlNodeRpm2 = fOldRepositoryMaterial.fXmlNode;

                        // --

                        if (fXmlNodeRpm1.get_attrVal(FXmlTagRPM.A_UniqueId, FXmlTagRPM.D_UniqueId) != fXmlNodeRpm2.get_attrVal(FXmlTagRPM.A_UniqueId, FXmlTagRPM.D_UniqueId))
                        {
                            continue;
                        }

                        // --

                        isDuplicate = true;
                        foreach (FXmlNode fXmlNodeCol in fXmlNodeListCol)
                        {
                            xpath = string.Format(
                                ColumnQuery3,
                                fXmlNodeCol.get_attrVal(FXmlTagCOL.A_UniqueId, FXmlTagCOL.D_UniqueId),
                                fXmlNodeCol.get_attrVal(FXmlTagCOL.A_Value, FXmlTagCOL.D_Value)
                                );
                            // --
                            if (!fXmlNodeRpm2.containsNode(xpath))
                            {
                                isDuplicate = false;
                                break;
                            }
                        }

                        // --

                        if (isDuplicate)
                        {
                            fDuplicateRepositoryMaterialList.Add(fOldRepositoryMaterial);
                        }
                    }
                }                

                // --

                foreach (FRepositoryMaterial fRpm in fDuplicateRepositoryMaterialList)
                {
                    m_fRepositoryMaterialList.Remove(fRpm);
                    m_fRepositoryMaterialDic.Remove(fRpm.rpmId);
                }

                // --

                m_fRepositoryMaterialList.Add(fRepositoryMaterial);
                m_fRepositoryMaterialDic.Add(fRepositoryMaterial.rpmId, fRepositoryMaterial);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fDuplicateRepositoryMaterialList = null;
                fOldRepositoryMaterial = null;
                fXmlNodeRpm1 = null;
                fXmlNodeRpm2 = null;
                fXmlNodeListCol = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal void remove(
            FRepositoryMaterial fRepositoryMaterial
            )
        {
            try
            {
                if (m_fRepositoryMaterialList.Contains(fRepositoryMaterial))
                {
                    m_fRepositoryMaterialList.Remove(fRepositoryMaterial);
                    m_fRepositoryMaterialDic.Remove(fRepositoryMaterial.rpmId);
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
                // ***
                // 2017.03.31 by spike.lee
                // Clear 구현
                // ***
                m_fRepositoryMaterialList.Clear();
                m_fRepositoryMaterialDic.Clear();
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

        internal bool containRepositoryMaterialByRpmId(
            UInt64 rpmId
            )
        {
            try
            {
                return m_fRepositoryMaterialDic.ContainsKey(rpmId);
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

        //------------------------------------------------------------------------------------------------------------------------

        internal FRepositoryMaterial getRepositoryMaterialByRpmId(
            UInt64 rpmId
            )
        {
            try
            {
                if (!m_fRepositoryMaterialDic.ContainsKey(rpmId))
                {
                    return null;
                }
                return m_fRepositoryMaterialDic[rpmId];
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

        internal void removeRepositoryMaterialByRpmId(
            UInt64 rpmId
            )
        {
            try
            {
                if (m_fRepositoryMaterialDic.ContainsKey(rpmId))
                {
                    m_fRepositoryMaterialList.Remove(m_fRepositoryMaterialDic[rpmId]);
                    m_fRepositoryMaterialDic.Remove(rpmId);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
