/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMail.cs
--  Creator         : Jeff.Kim
--  Create Date     : 2013.05.06
--  Description     : FAMate Core FaCommon Mail class 
--  History         : Created by Jeff.Kim at 2013.05.06
----------------------------------------------------------------------------------------------------------*/

using System;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Globalization;
using System.Net.Mail;

namespace Nexplant.MC.Core.FaCommon
{
    public static class FMail
    {
        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static void sendMail(
            string server,
            string from,
            string to,
            string userId,
            string userPw,
            string subject,
            string body
            )
        {
            try
            {
                sendMail(
                    server,
                    from,
                    to,
                    userId,
                    userPw,
                    subject,
                    body,
                    false
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void sendMail(
            string server,
            string from,
            string to,
            string userId,
            string userPw,
            string subject,
            string body,
            bool isHtml
            )
        {
            try
            {
                sendMail(
                    server,
                    from,
                    new string[] { to },
                    userId,
                    userPw,
                    subject,
                    body,
                    isHtml
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void sendMail(
            string server,
            string from,
            string[] toList,
            string userId,
            string userPw,
            string subject,
            string body,
            bool isHtml
            )
        {            
            try
            {
                sendMail(
                    server, 
                    25, // DEFAULT SMTP PORT
                    from, 
                    toList, 
                    userId, 
                    userPw, 
                    subject, 
                    body,
                    isHtml
                    );
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public static void sendMail(
            string server,
            int serverPort,
            string from,
            string[] toList,
            string userId,
            string userPw,
            string subject,
            string body,
            bool isHtml
            )
        {
            const int Timeout = 30000;  // 30 sec

            MailMessage message = null;
            SmtpClient client = null;

            try
            {
                message = new MailMessage();
                message.From = new MailAddress(from);
                foreach (string to in toList)
                {
                    message.To.Add(to);
                }
                message.Subject = subject;
                message.Body = body;
                message.IsBodyHtml = isHtml;
                // --
                client = new SmtpClient(server, serverPort);
                // --
                client.UseDefaultCredentials = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.Timeout = Timeout;
                client.Credentials = new NetworkCredential(userId, userPw);
                client.Send(message);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (message != null)
                {
                    message.Dispose();
                }
                client = null;
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // class end
}   // namespace end

