/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FScenarioActivatedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2011.04.20
--  Description     : FAMate Core FaUIs Scenario Activated Event Arguments Class
--  History         : Created by spike.lee at 2011.04.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using Infragistics.Win.UltraWinGrid;
using Infragistics.Win.UltraWinDataSource;

namespace Nexplant.MC.Core.FaUIs
{
    [Serializable]
    public class FScenarioActivatedEventArgs : EventArgs, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        private FGrid m_fActiveGrid = null;
        private UltraGridRow m_activeGridRow = null;
        private UltraDataRow m_activeDataRow = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FScenarioActivatedEventArgs(
            FGrid fActiveGrid,
            UltraGridRow activeGridRow,
            UltraDataRow activeDataRow
            )
        {
            m_fActiveGrid = fActiveGrid;
            m_activeGridRow = activeGridRow;
            m_activeDataRow = activeDataRow;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FScenarioActivatedEventArgs(
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

        public FGrid fActiveGrid
        {
            get
            {
                try
                {
                    return m_fActiveGrid;
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

        public UltraGridRow activeGridRow
        {
            get
            {
                try
                {
                    return m_activeGridRow;
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

        public UltraDataRow activeDataRow
        {
            get
            {
                try
                {
                    return m_activeDataRow;
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
