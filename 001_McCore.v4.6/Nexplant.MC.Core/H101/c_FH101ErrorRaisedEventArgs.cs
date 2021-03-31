/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FH101ErrorRaisedEventArgs.cs
--  Creator         : spike.lee
--  Create Date     : 2012.12.20
--  Description     : FAMate Core FaCommon FH101 Error Raised Event Arguments Class
--  History         : Created by spike.lee at 2012.12.20
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Nexplant.MC.Core.FaCommon
{
    [Serializable]
    public class FH101ErrorRaisedEventArgs : EventArgs
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FH101 m_fOwnerH101 = null;
        private string m_message = string.Empty;
        private Exception m_exception = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FH101ErrorRaisedEventArgs(
            FH101 fOwnerH101,
            string message,
            Exception exception
            )            
        {
            m_fOwnerH101 = fOwnerH101;
            m_message = message;
            m_exception = exception;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FH101ErrorRaisedEventArgs(
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
                    m_fOwnerH101 = null;
                    m_exception = null;
                }                
                m_disposed = true;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public FH101 fOwnerH101
        {
            get
            {
                try
                {
                    return m_fOwnerH101;
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

        public string message
        {
            get
            {
                try
                {
                    return m_message;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return string.Empty;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public Exception exception
        {
            get
            {
                try
                {
                    return m_exception;
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
