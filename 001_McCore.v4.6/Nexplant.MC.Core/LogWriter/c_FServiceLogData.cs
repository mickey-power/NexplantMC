/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FServiceLogData.cs
--  Creator         : spike.lee
--  Create Date     : 2012.03.16
--  Description     : FAMate Core FaCommon Service Log Writer Class
--  History         : Created by spike.lee at 2012.03.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace Nexplant.MC.Core.FaCommon
{
    public class FServiceLogData : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --        
        DateTime m_startTime;
        StringBuilder m_log = null;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FServiceLogData(
            string serverName,
            Type type,
            string functionName
            )
        {
            m_startTime = DateTime.Now;
            m_log = new StringBuilder();

            // --

            m_log.Append("StartTime=<" + FDataConvert.defaultNowDateTimeToString() + ">" + Environment.NewLine);
            // --
            m_log.Append("ServerName=<" + serverName + ">, ");
            m_log.Append("Namespace=<" + type.Namespace + ">, ");
            m_log.Append("TypeName=<" + type.Name + ">, ");
            m_log.Append("FunctionName=<" + functionName + ">" + Environment.NewLine);
            // --
            m_log.Append(" " + Environment.NewLine);           
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FServiceLogData(
            Type type,
            string functionName
            )
        {
            m_startTime = DateTime.Now;
            m_log = new StringBuilder();

            // --

            m_log.Append("StartTime=<" + FDataConvert.defaultNowDateTimeToString() + ">" + Environment.NewLine);
            // --
            m_log.Append("Namespace=<" + type.Namespace + ">, ");
            m_log.Append("TypeName=<" + type.Name + ">, ");
            m_log.Append("FunctionName=<" + functionName + ">" + Environment.NewLine);
            // --
            m_log.Append(" " + Environment.NewLine);           
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FServiceLogData(
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

        internal DateTime startTime
        {
            get
            {
                try
                {
                    return m_startTime;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return DateTime.Now;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------        

        internal StringBuilder logData
        {
            get
            {
                try
                {
                    return m_log;
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

        public void appendLog(
            FServiceLogCategory fCategory, 
            string action, 
            string log
            )
        {
            try
            {
                if (fCategory == FServiceLogCategory.Information)
                {
                    m_log.Append("Category=<I>, ");
                }
                else if (fCategory == FServiceLogCategory.Warning)
                {
                    m_log.Append("Category=<W>, ");
                }
                else
                {
                    m_log.Append("Category=<E>, ");
                }
                m_log.Append("Action=<" + action + ">" + Environment.NewLine);

                // --

                m_log.Append("/* Addition Information */" + Environment.NewLine);
                m_log.Append(log + Environment.NewLine);
                m_log.Append(" " + Environment.NewLine);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        #endregion 

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
