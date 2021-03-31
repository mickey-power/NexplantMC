/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FTreeViewBeforeMouseDownEventArgs.cs
--  Creator         : iskim
--  Create Date     : 2014.01.28
--  Description     : FAMate Core FaUIs TreeView Before Mouse Down Event Arguments Class
--  History         : Created by iskim at 2014.01.28
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win.UltraWinTree;

namespace Nexplant.MC.Core.FaUIs
{
    [Serializable]
    public class FTreeViewBeforeMouseDownEventArgs : EventArgs, IDisposable
    {
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // -- 
        private UltraTreeNode m_tNode = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FTreeViewBeforeMouseDownEventArgs(
            UltraTreeNode tNode
            )
        {
            m_tNode = tNode;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FTreeViewBeforeMouseDownEventArgs(
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

        public UltraTreeNode tNode
        {
            get
            {
                try
                {
                    return m_tNode;
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