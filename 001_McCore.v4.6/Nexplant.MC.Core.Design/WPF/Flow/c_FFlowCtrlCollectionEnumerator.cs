/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFlowCtrlCollectionEnumerator.cs
--  Creator         : byjeon
--  Create Date     : 2012.10.15
--  Description     : FAMate Core UIs Flow Control Collection Enumerator WPF Class 
--  History         : Created by byjeon at 2012.10.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    public class FFlowCtrlCollectionEnumerator : IEnumerator, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------        

        private bool m_disposed = false;
        // --
        private int m_index = -1;
        private FFlowCtrlCollection m_collection = null;

        //------------------------------------------------------------------------------------------------------------------------        

        #region Class Construction and Destruction

        public FFlowCtrlCollectionEnumerator(
            FFlowCtrlCollection collection
            )
        {
            m_collection = collection;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFlowCtrlCollectionEnumerator(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_collection = null;
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

        public object Current
        {
            get
            {
                try
                {
                    return m_collection.item(m_index);
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

        public bool MoveNext(
            )
        {
            try
            {
                return (++m_index < m_collection.count);
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

        public void Reset(
            )
        {
            try
            {
                m_index = -1;
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
