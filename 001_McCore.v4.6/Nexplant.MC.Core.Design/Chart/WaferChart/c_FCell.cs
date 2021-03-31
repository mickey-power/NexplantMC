/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCell.cs
--  Creator         : byjeon
--  Create Date     : 2013.12.02
--  Description     : FAMate UI WaferChart Cell Class
--  History         : Created by byjeon at 2013.12.02
----------------------------------------------------------------------------------------------------------*/
using System;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaUIs
{
    public class FCell : IDisposable
    {
        
        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private double m_value = 0d;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCell(
            )            
        {

        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public FCell(
            double value
            )
            : this()
        {
            m_value = value;
        }

        //------------------------------------------------------------------------------------------------------------------------

         ~FCell(
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

        public double value
        {
            get
            {
                try
                {
                    return m_value;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0d;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    } // End Class
} // End Namespace