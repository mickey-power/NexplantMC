/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFDynPropBase.cs
--  Creator         : spike.lee
--  Create Date     : 2010.12.29
--  Description     : FAMate Core FaUIs Dynamic Property Grid Customizing Source Object Base Class
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
    public abstract class FDynPropBase : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FUIWizard m_fUIWizard = null;
        private FDynPropGrid m_fPropGrid = null;
        private FDynPropGridTypeDescriptor m_fTypeDescriptor = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FDynPropBase(
            FUIWizard fUIWizard,
            FDynPropGrid fPropGrid
           )
        {
            m_fUIWizard = fUIWizard;
            m_fPropGrid = fPropGrid;
            m_fTypeDescriptor = new FDynPropGridTypeDescriptor(this, false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FDynPropBase(
            )
        {
            myDispose(false);
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
                    m_fUIWizard = null;
                    m_fPropGrid = null;                    
                    m_fTypeDescriptor = null;
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

        [Browsable(false)]
        public FUIWizard fUIWizard
        {
            get
            {
                try
                {
                    return m_fUIWizard;
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

        [Browsable(false)]
        public FDynPropGrid fPropGrid
        {
            get
            {
                try
                {
                    return m_fPropGrid;
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

        [Browsable(false)]
        public FDynPropGridTypeDescriptor fTypeDescriptor
        {
            get
            {
                try
                {
                    return m_fTypeDescriptor;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
