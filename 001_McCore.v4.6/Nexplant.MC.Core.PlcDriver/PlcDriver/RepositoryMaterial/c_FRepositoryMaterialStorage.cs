/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FRepositoryMaterialStorage.cs
--  Creator         : spike.lee
--  Create Date     : 2012.01.10
--  Description     : FAMate Core FaPlcDriver Repository Material Storage Class 
--  History         : Created by spike.lee at 2012.01.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public class FRepositoryMaterialStorage : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPcdCore m_fPcdCore = null;
        private FCodeLock m_fCodeLock = null;
        private FRepositoryMaterialCollection m_fRepositoryMaterialCollection = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FRepositoryMaterialStorage(                        
            FPcdCore fPcdCore
            )
        {
            m_fPcdCore = fPcdCore;
            m_fCodeLock = new FCodeLock();
            m_fRepositoryMaterialCollection = new FRepositoryMaterialCollection();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FRepositoryMaterialStorage(
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
                    if (m_fRepositoryMaterialCollection != null)
                    {
                        m_fRepositoryMaterialCollection.Dispose();
                        m_fRepositoryMaterialCollection = null;
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

        public FRepositoryMaterialCollection fRepositoryMaterialCollection
        {
            get
            {
                try
                {
                    return m_fRepositoryMaterialCollection;
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
            FRepositoryMaterial fRepositoryMaterial
            )
        {
            try
            {
                m_fCodeLock.wait();

                // --

                m_fRepositoryMaterialCollection.add(fRepositoryMaterial);
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
            FRepositoryMaterial fRepositoryMaterial
            )
        {
            try
            {
                m_fCodeLock.wait();

                // --

                m_fRepositoryMaterialCollection.remove(fRepositoryMaterial);
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

        public void clear(
            )
        {
            try
            {
                m_fCodeLock.wait();

                // --

                // ***
                // 2017.04.03 by spike.lee
                // Remove All 구현
                // ***
                m_fRepositoryMaterialCollection.clear();
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

        public bool containRepositoryMaterialByRpmId(
            UInt64 rpmId
            )
        {
            try
            {
                return m_fRepositoryMaterialCollection.containRepositoryMaterialByRpmId(rpmId);
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

        public FRepositoryMaterial getRepositoryMaterialByRpmId(
            UInt64 rpmId
            )
        {
            try
            {
                return m_fRepositoryMaterialCollection.getRepositoryMaterialByRpmId(rpmId);
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

        public void removeRepositoryMaterialByRpmId(
            UInt64 rpmId
            )
        {
            try
            {
                m_fCodeLock.wait();

                // --

                m_fRepositoryMaterialCollection.removeRepositoryMaterialByRpmId(rpmId);
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
