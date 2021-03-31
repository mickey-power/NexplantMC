/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFlowDragEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2017.01.19
--  Description     : FAMate Core FaUIs Flow Drag Event Arguments Class
--  History         : Created by spike.lee at 2017.01.19
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs.WPF
{
    [Serializable]
    public class FFlowDragEventArgs : EventArgs, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private System.Windows.DragDropEffects m_allowedEffect = System.Windows.DragDropEffects.None;
        private System.Windows.IDataObject m_data = null;
        private FIFlowCtrl m_fRefFlowCtrl = null;
        private System.Windows.DragDropEffects m_effect = System.Windows.DragDropEffects.None;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FFlowDragEventArgs(
            System.Windows.DragDropEffects allowedEffect,
            System.Windows.IDataObject data,
            FIFlowCtrl fRefFlowCtrl
            )
        {
            m_allowedEffect = allowedEffect;
            m_effect = allowedEffect;
            m_data = data;
            m_fRefFlowCtrl = fRefFlowCtrl;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FFlowDragEventArgs(
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
                    m_fRefFlowCtrl = null;
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

        public System.Windows.DragDropEffects allowedEffect
        {
            get
            {
                try
                {
                    return m_allowedEffect;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return System.Windows.DragDropEffects.None;
            }            
        }

        //------------------------------------------------------------------------------------------------------------------------

        public System.Windows.IDataObject data
        {
            get
            {
                try
                {
                    return m_data;
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

        public FIFlowCtrl fRefFlowCtrl
        {
            get
            {
                try
                {
                    return m_fRefFlowCtrl;
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

        public System.Windows.DragDropEffects effect
        {
            get
            {
                try
                {
                    return m_effect;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return System.Windows.DragDropEffects.None;
            }

            set
            {
                try
                {
                    m_effect = value;
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
