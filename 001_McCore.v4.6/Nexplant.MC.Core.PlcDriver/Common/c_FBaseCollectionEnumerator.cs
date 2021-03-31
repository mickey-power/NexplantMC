/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBaseCollectionEnumerator.cs
--  Creator         : spike.lee
--  Create Date     : 2013.07.10
--  Description     : FAMate Core FaPlcDriver Base Collection Enumerator Class 
--  History         : Created by spike.lee at 2013.07.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    public abstract class FBaseCollectionEnumerator<T> : IEnumerator where T : FIEnumerable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private T m_t = default(T);
        private int m_index = -1;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FBaseCollectionEnumerator(
            T t
            )
        {
            m_t = t;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FBaseCollectionEnumerator(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
           bool disposing
           )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_t = default(T);
                }

                m_disposed = true;
            }
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
                    return m_t.item(m_index);
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
                return (++m_index < m_t.count);
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
