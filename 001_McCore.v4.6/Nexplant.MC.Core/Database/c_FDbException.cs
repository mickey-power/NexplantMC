/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FDbException.cs
--  Creator         : kitae
--  Create Date     : 2011.03.02
--  Description     : FAMate Core FaCommon DBException Class
--  History         : Created by kitae at 2011.03.02
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FDbException : ApplicationException
    {

        //------------------------------------------------------------------------------------------------------------------------

        private int m_errorCode = 0;
        // --
        private FSqlErrorType m_fSqlErrorType = FSqlErrorType.Normal;
        private FSqlErrorCollection m_fSqlErrors = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FDbException(
            FSqlErrorType fSqlErrorType,
            FSqlErrorCollection fSqlErrors,
            string message,
            Exception innerException
            )
            : base(message, innerException)
        {
            m_fSqlErrorType = fSqlErrorType;
            m_fSqlErrors = fSqlErrors;
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public int errorCode
        {
            get
            {
                try
                {
                    return m_errorCode;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return 0;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqlErrorType fSqlErrorType
        {
            get
            {
                try
                {
                    return m_fSqlErrorType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FSqlErrorType.Normal;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSqlErrorCollection fSqlErrors
        {
            get
            {
                try
                {
                    return m_fSqlErrors;
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

    } // Class end
} // Namespace end
