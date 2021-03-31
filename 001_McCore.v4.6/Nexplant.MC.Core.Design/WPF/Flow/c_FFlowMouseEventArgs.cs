/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFlowMouseEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2017.01.18
--  Description     : FAMate Core FaUIs Flow Mouse Event Arguments Class
--  History         : Created by spike.lee at 2017.01.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    [Serializable]
    public class FFlowMouseEventArgs : EventArgs, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private System.Windows.Forms.MouseButtons m_buttons = System.Windows.Forms.MouseButtons.None;
        private FIFlowCtrl m_fFlowCtrl = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FFlowMouseEventArgs(
            System.Windows.Forms.MouseButtons buttons,
            FIFlowCtrl fFlowCtrl 
            )
        {
            m_buttons = buttons;
            m_fFlowCtrl = fFlowCtrl;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFlowMouseEventArgs(
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
                    m_fFlowCtrl = null;
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

        public System.Windows.Forms.MouseButtons buttons
        {
            get
            {
                try
                {
                    return m_buttons;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return System.Windows.Forms.MouseButtons.None;
            }            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FIFlowCtrl fFlowCtrl
        {
            get
            {
                try
                {
                    return m_fFlowCtrl;
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
