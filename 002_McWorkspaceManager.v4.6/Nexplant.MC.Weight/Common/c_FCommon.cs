/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCommon.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.10
--  Description     : Nexplant MC Counter Common Function Class
--  History         : Created by mjkim at 2019.09.10
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using Nexplant.MC.Core.FaCommon;
using Nexplant.MC.Core.FaSecs1ToHsms;

namespace Nexplant.MC.Counter
{
    public static class FCommon
    {

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public static DialogResult showConfirmMessageBox(
            Form fParentForm, 
            string confirmMessage
            )
        {
            FConfirmMessageBox fDialog = null;

            try
            {
                fDialog = new FConfirmMessageBox(confirmMessage);
                if (fParentForm == null)
                {
                    return fDialog.ShowDialog();
                }                    
                return fDialog.ShowDialog(fParentForm);
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
            return DialogResult.No;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void showErrorMessageBox(
            Form fParentForm, 
            string errorMessage
            )
        {
            FErrorMessageBox fDialog = null;

            try
            {
                fDialog = new FErrorMessageBox(errorMessage);
                if (fParentForm == null)
                {
                    fDialog.ShowDialog();
                }
                else
                {
                    fDialog.ShowDialog(fParentForm);
                }                
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void showErrorMessageBox(
            Form fParentForm,
            Exception exception
            )
        {
            FErrorMessageBox fDialog = null;

            try
            {
                FDebug.writeLog(exception);

                // --

                fDialog = new FErrorMessageBox(exception.Message);
                if (fParentForm == null)
                {
                    fDialog.ShowDialog();
                }
                else
                {
                    fDialog.ShowDialog(fParentForm);
                }    
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                if (fDialog != null)
                {
                    fDialog.Dispose();
                    fDialog = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static FXmlNode createXmlNode(
            string elementName
            )
        {
            FXmlDocument fXmlDoc = null;

            try
            {
                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                fXmlDoc.appendChild(fXmlDoc.createNode(elementName));
                // --
                return fXmlDoc.fFirstChild;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlDoc = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string getAppLog(
            string eventId,
            FResultCode fResult,
            string errorMessage,
            string appendLog
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.Append(eventId);
                logData.Append(", Result=<" + fResult.ToString() + ">");
                if (fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + errorMessage + ">");
                }
                logData.AppendLine();
                // --
                if (appendLog != string.Empty)
                {
                    logData.AppendLine(appendLog);
                }
                logData.AppendLine();

                // --

                return logData.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string getAdminLog(
            string eventId,
            FResultCode fResult,
            string errorMessage,
            string appendLog
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.Append(eventId);
                logData.Append(", Result=<" + fResult.ToString() + ">");
                if (fResult != FResultCode.Success)
                {
                    logData.Append(", ErrorMessage=<" + errorMessage + ">");
                }
                logData.AppendLine();
                // --
                if (appendLog != string.Empty)
                {
                    logData.AppendLine(appendLog);
                }

                // --

                return logData.ToString();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                logData = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string getAdminMessageLog(
            string action,
            string command, 
            FXmlNode fXmlNode
            )
        {
            const string Columns = "Columns";
            const string Rows = "Rows";

            StringBuilder logData = new StringBuilder();
            FXmlNode fXmlNodeLog = null;
            int len = 0;

            try
            {
                fXmlNodeLog = fXmlNode.clone(true);
                // --                
                foreach (FXmlNode x in fXmlNodeLog.get_elemList("//" + Columns))
                {
                    len = x.get_val().Length;
                    x.set_val(len.ToString());
                }
                // --
                foreach (FXmlNode x in fXmlNodeLog.get_elemList("//" + Rows))
                {
                    len = x.get_val().Length;
                    x.set_val(len.ToString());
                }

                // --

                logData.AppendLine("--");
                logData.AppendLine("Action=<" + action + ">, Command=<" + command + ">");
                logData.AppendLine(fXmlNodeLog.xmlToString(true));
                // --
                return logData.ToString();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                logData = null;
                fXmlNodeLog = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string getAdminExceptionLog(
            Exception exp
            )
        {
            StringBuilder logData = new StringBuilder();

            try
            {
                logData.AppendLine("--");
                logData.AppendLine("Action=<ExceptionTrace>, Message=<" + exp.Message + ">");
                logData.AppendLine(exp.ToString());
                // --
                return logData.ToString();
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {
                logData = null;
            }
            return string.Empty;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static string[] getLocalIpList(
            )
        {
            IPHostEntry host = null;
            List<string> ipList = null;

            try
            {
                ipList = new List<string>();

                // --

                host = Dns.GetHostEntry(Dns.GetHostName());
                foreach (IPAddress ip in host.AddressList)
                {
                    if (ip.AddressFamily == AddressFamily.InterNetwork)
                    {
                        ipList.Add(ip.ToString());
                    }
                }

                // --

                if (ipList.Count == 0)
                {
                    FDebug.throwFException("Not available, please check your network seetings.");
                }

                // --

                return ipList.ToArray();
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

        //------------------------------------------------------------------------------------------------------------------------

        public static FFtp createFtp(
            FCntCore fBcrCore
            )
        {
            try
            {
                if (fBcrCore.fOption.adsFtpUsedAnonymous)
                {
                    return new FFtp(false, fBcrCore.fOption.adsFtpIp);
                }
                return new FFtp(false, fBcrCore.fOption.adsFtpIp, fBcrCore.fOption.adsFtpUser, fBcrCore.fOption.adsFtpPassword);
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

        //------------------------------------------------------------------------------------------------------------------------

        public static void deleteDirectory(
            string path
            )
        {
            try
            {
                if (path != string.Empty && Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public static void deleteFile(
            string fileName
            )
        {
            try
            {
                if (fileName != string.Empty && File.Exists(fileName))
                {
                    File.Delete(fileName);
                }
            }
            catch (Exception ex)
            {
                FDebug.writeLog(ex);
            }
            finally
            {

            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // class end
}   // namespace end
