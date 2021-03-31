/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFDynPropGridProp.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.28
--  Description     : FAMate Core FaUIs Dynamic Property Grid Property Class
--  History         : Created by spike.lee at 2010.12.28
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Reflection;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FDynPropGridProp : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FDynPropGridAttrCollection m_dynAttrs = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDynPropGridProp(
           )
        {
            m_dynAttrs = new FDynPropGridAttrCollection();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDynPropGridProp(
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
                    m_dynAttrs = null;
                }
            }

            m_disposed = true;
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

        public FDynPropGridAttrCollection attributes
        {
            get
            {
                try
                {
                    return m_dynAttrs;
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

            set
            {
                try
                {
                    m_dynAttrs = value;
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

        //------------------------------------------------------------------------------------------------------------------------

        public Attribute this[Type type]
        {
            get
            {
                int index;

                try
                {
                    index = m_dynAttrs.indexOf(type);
                    if (index == -1)
                    {
                        return null;
                    }
                    return m_dynAttrs[index].value;
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

            set
            {
                int index;

                try
                {
                    index = m_dynAttrs.indexOf(type);
                    if (index == -1)
                    {
                        m_dynAttrs.add(value);
                    }
                    else
                    {
                        m_dynAttrs[index] = new FDynPropGridAttr(value);
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
