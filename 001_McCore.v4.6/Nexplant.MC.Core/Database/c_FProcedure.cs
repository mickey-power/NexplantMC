/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FProcedure.cs
--  Creator         : byjeon
--  Create Date     : 2014.08.12
--  Description     : FAMate Core FaCommon Database FProcedure Class
--  History         : Created by byjeon at 2014.08.12
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Nexplant.MC.Core.FaCommon
{
    public class FProcedure : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;

        // -- 

        private string m_command = string.Empty;
        private FProcParameterCollection m_fParameters = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FProcedure(
            )
        {
            m_fParameters = new FProcParameterCollection();
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FProcedure(
            string command
            )
            :this()
        {
            m_command = command;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        ~FProcedure(
            )
        {
            myDispose(false);            
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected virtual void myDispose(
            bool disposing
            )
        {
            if(!m_disposed)
            {
                if(disposing)
                {
                    m_fParameters = null;
                }
            }
            m_disposed = true;

        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

        #region IDisposable 맴버
        
        public void Dispose(
            )
        {           
            myDispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public string command
        {
            get
            {
                try
                {
                    return m_command;
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

            set
            {
                try
                {
                    m_command = value;
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

        public FProcParameterCollection fParameters
        {
            get
            {
                try
                {
                    return m_fParameters;
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

    } // Class end    
} // Namespace end