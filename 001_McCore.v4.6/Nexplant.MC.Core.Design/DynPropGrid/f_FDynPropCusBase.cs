/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFDynPropBase.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.29
--  Description     : FAMate Core FaUIs Dynamic Property Grid Source Object Base Class
--  History         : Created by spike.lee at 2010.12.29
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public abstract class FDynPropCusBase<T> : FDynPropBase
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private T m_mainObject = default(T);        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDynPropCusBase(
            T mainObject,
            FUIWizard fUIWizard,
            FDynPropGrid fPropGrid
            )
            : base(fUIWizard, fPropGrid)
        {
            m_mainObject = mainObject;            
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDynPropCusBase(
            )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    m_mainObject = default(T);                    
                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }            
        }

        #endregion        

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        [Browsable(false)]
        public T mainObject
        {
            get
            {
                try
                {
                    return m_mainObject;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return default(T);
            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
