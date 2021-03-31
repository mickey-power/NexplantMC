/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FEventLogWriter.cs
--  Creator         : kitae
--  Create Date     : 2012.04.24
--  Description     : FAMate Core FaCommon Debug Class
--  History         : Created by kitae at 2012.04.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FEventLogWriter
    {        

        //------------------------------------------------------------------------------------------------------------------------
        
        private const int DefaultEventId = 1000;
        
        // --
        
        private static string m_logName = "FAMate";        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        #endregion

        //------------------------------------------------------------------------------------------------------------------------        

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods
        
        public static void write(
            string source,  
            string message            
            )
        {
            try
            {               
                write(source, message, EventLogEntryType.Information, DefaultEventId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void write(
            string source,
            string message,
            EventLogEntryType type            
            )
        {
            try
            {
                write(source, message, type, DefaultEventId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void write(
            string source,
            string message,
            EventLogEntryType type,
            int eventId
            )
        {
            try
            {
                if (!EventLog.SourceExists(source))
                {
                    EventLog.CreateEventSource(source, m_logName);
                }

                // --

                EventLog.WriteEntry(source, message, type, eventId);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
            }
            finally
            {

            }
        }        

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end