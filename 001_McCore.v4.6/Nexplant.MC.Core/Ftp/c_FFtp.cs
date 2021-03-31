/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFtp.cs
--  Creator         : baehyun seo
--  Create Date     : 2011.08.12
--  Description     : FAMate Core FaCommon Ftp class 
--  History         : Created by baehyun seo at 2011.09.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;

namespace Nexplant.MC.Core.FaCommon
{
    public class FFtp : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        delegate FFtpDirectoryEntry ParseLine(string lines);
        // --
        private const string ftpString = "ftp://";
        private const string ForwardSlash = "/"; // Root directory
        private const string BackSlash = "\\";
        // --
        private bool m_disposed = false;
        // --
        private string m_userName;
        private string m_password;
        private string m_domain;    // No trailing slash
        private string m_cwd = string.Empty;        // Leading, no trailing slash
        private char[] m_slashes = { '/', '\\' };
        // --
        // Add by Jeff.Kim 2018.04.17
        // 방화벽 문제로 Passive Mode 해제 플레그 가져감
        private bool m_isPassiveMode = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Enum

        private enum FtpDirectoryFormat
        {
            Windows,
            Unknown
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFtp(
            bool isPassiveMode,
            string urlBaseString
            )
        {
            m_isPassiveMode = isPassiveMode;
            m_userName = "anonymous";
            m_password = "";
            setUrl(urlBaseString);
        }

        //------------------------------------------------------------------------------------------------------------------------
  
        public FFtp(
            bool isPassiveMode,
            string urlBaseString,
            string username, 
            string password
            )
            : this(isPassiveMode, urlBaseString)
        {
            m_userName = username;
            m_password = password;
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        ~FFtp(
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods
        
        public void uploadFiles(
            params string[] paths
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            FileInfo info;
            FileStream instream;
            Stream outstream;
            int bufferLength;
            int bytesRead;
            byte[] buffer;

            try
            {
                foreach (string path in paths)
                {
                    ftpRequest = getRequest(Path.GetFileName(path));
                    ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    ftpRequest.UseBinary = true;

                    info = new FileInfo(path);
                    ftpRequest.ContentLength = info.Length;

                    bufferLength = 16384;
                    buffer = new byte[bufferLength];

                    using (instream = info.OpenRead())
                    {
                        using (outstream = ftpRequest.GetRequestStream())
                        {
                            bytesRead = instream.Read(buffer, 0, bufferLength);

                            while (bytesRead > 0)
                            {
                                outstream.Write(buffer, 0, bytesRead);
                                bytesRead = instream.Read(buffer, 0, bufferLength);
                            }
                            outstream.Close();
                        }
                        instream.Close();
                    }
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    ftpResponse.Close();
                }
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

        public void uploadFilesOverSSL(
            params string[] paths
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            FileInfo info;
            FileStream instream;
            Stream outstream;
            int bufferLength;
            int bytesRead;
            byte[] buffer;

            try
            {
                foreach (string path in paths)
                {
                    ftpRequest = getRequest(Path.GetFileName(path));
                    ftpRequest.Method = WebRequestMethods.Ftp.UploadFile;
                    ftpRequest.UseBinary = true;

                    info = new FileInfo(path);
                    ftpRequest.ContentLength = info.Length;

                    bufferLength = 16384;
                    buffer = new byte[bufferLength];

                    using (instream = info.OpenRead())
                    {
                        using (outstream = ftpRequest.GetRequestStream())
                        {
                            bytesRead = instream.Read(buffer, 0, bufferLength);

                            while (bytesRead > 0)
                            {
                                outstream.Write(buffer, 0, bytesRead);
                                bytesRead = instream.Read(buffer, 0, bufferLength);
                            }
                            outstream.Close();
                        }
                        instream.Close();
                    }

                    // ***
                    // Accept Certificate
                    // ***
                    ftpRequest.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptCertifications);
                    ServicePointManager.Expect100Continue = true;

                    // --
                    
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    ftpResponse.Close();
                }
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

        public void downloadFiles(
            string path,
            params string[] files
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            Stream instream;
            int buffLength;
            int bytesRead;
            byte[] buffer;

            try
            {
                foreach (string file in files)
                {
                    ftpRequest = getRequest(file);
                    ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    ftpRequest.UseBinary = true;

                    using (FileStream outstream = new FileStream(Path.Combine(path, Path.GetFileName(file)), FileMode.Create))
                    {
                        ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                        using (instream = ftpResponse.GetResponseStream())
                        {
                            buffLength = 16384;
                            buffer = new byte[buffLength];

                            bytesRead = instream.Read(buffer, 0, buffLength);

                            while (bytesRead > 0)
                            {
                                outstream.Write(buffer, 0, bytesRead);
                                bytesRead = instream.Read(buffer, 0, buffLength);
                            }
                            instream.Close();
                        }
                        outstream.Close();
                        ftpResponse.Close();
                    }
                }
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

        public void downloadFilesOverSSL(
            string path,
            params string[] files
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            Stream instream;
            int buffLength;
            int bytesRead;
            byte[] buffer;

            try
            {
                foreach (string file in files)
                {
                    ftpRequest = getRequest(file);
                    ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                    ftpRequest.UseBinary = true;

                    using (FileStream outstream = new FileStream(Path.Combine(path, file), FileMode.Create))
                    {
                        // ***
                        // Accept Certificate
                        // ***
                        ftpRequest.EnableSsl = true;
                        ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptCertifications);
                        ServicePointManager.Expect100Continue = true;

                        // --

                        ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                        using (instream = ftpResponse.GetResponseStream())
                        {
                            buffLength = 16384;
                            buffer = new byte[buffLength];

                            bytesRead = instream.Read(buffer, 0, buffLength);

                            while (bytesRead > 0)
                            {
                                outstream.Write(buffer, 0, bytesRead);
                                bytesRead = instream.Read(buffer, 0, buffLength);
                            }
                            instream.Close();
                        }
                        outstream.Close();
                        ftpResponse.Close();
                    }
                }
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

        public void downloadFiles(
            string path,
            string file,
            bool deleteFlag
            )
        {
            try
            {
                downloadFiles(path, file);
                if (deleteFlag == true)
                {
                    deleteFiles(file);
                }
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

        public void downloadFilesOverSSL(
            string path,
            string file,
            bool deleteFlag
            )
        {
            try
            {
                downloadFiles(path, file);
                if (deleteFlag == true)
                {
                    deleteFilesOverSSL(file);
                }
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

        public void deleteFiles(
            params string[] files
            )
        {
            FtpWebRequest ftpRequest = null;
            FtpWebResponse ftpResponse = null;

            try
            {
                foreach (string file in files)
                {
                    ftpRequest = getRequest(file);
                    ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    ftpResponse.Close();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (ftpResponse != null)
                {
                    ftpResponse.Close();
                    ftpResponse = null;
                }
                ftpRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void deleteFilesOverSSL(
            params string[] files
            )
        {
            FtpWebRequest ftpRequest = null;
            FtpWebResponse ftpResponse = null;

            try
            {
                foreach (string file in files)
                {
                    ftpRequest = getRequest(file);
                    ftpRequest.Method = WebRequestMethods.Ftp.DeleteFile;

                    // ***
                    // Accept Certificate
                    // ***
                    ftpRequest.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptCertifications);
                    ServicePointManager.Expect100Continue = true;

                    // --

                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    ftpResponse.Close();
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (ftpResponse != null)
                {
                    ftpResponse.Close();
                    ftpResponse = null;
                }
                ftpRequest = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void createDirectory(
            string directory
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            List<string> paths;
            string[] steps;
            int createIndex;

            try
            {
                // Get absolute directory
                directory = applyDirectory(directory);

                // Split into path components
                steps = directory.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                // Build list of full paths to each path component
                paths = new List<string>();
                for (int i = 1; i <= steps.Length; i++)
                {
                    paths.Add(ForwardSlash + String.Join(ForwardSlash, steps, 0, i));
                }

                // Find first path component that needs creating
                for (createIndex = paths.Count; createIndex > 0; createIndex--)
                {
                    if (directoryExists(paths[createIndex - 1]))
                    {
                        break;
                    }
                }

                // Created needed paths
                for (createIndex = 0; createIndex < paths.Count; createIndex++)
                {
                    ftpRequest = getRequest(paths[createIndex]);
                    ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;
                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    ftpResponse.Close();
                }
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

        public void createDirectoryOverSSL(
            string directory
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            List<string> paths;
            string[] steps;
            int createIndex;

            try
            {
                // Get absolute directory
                directory = applyDirectory(directory);

                // Split into path components
                steps = directory.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                // Build list of full paths to each path component
                paths = new List<string>();
                for (int i = 1; i <= steps.Length; i++)
                {
                    paths.Add(ForwardSlash + String.Join(ForwardSlash, steps, 0, i));
                }

                // Find first path component that needs creating
                for (createIndex = paths.Count; createIndex > 0; createIndex--)
                {
                    if (directoryExists(paths[createIndex - 1]))
                    {
                        break;
                    }
                }

                // Created needed paths
                for (createIndex = 0; createIndex < paths.Count; createIndex++)
                {
                    ftpRequest = getRequest(paths[createIndex]);
                    ftpRequest.Method = WebRequestMethods.Ftp.MakeDirectory;

                    // ***
                    // Accept Certificate
                    // ***
                    ftpRequest.EnableSsl = true;
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptCertifications);
                    ServicePointManager.Expect100Continue = true;

                    // --

                    ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                    ftpResponse.Close();
                }
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

        public void deleteDirectory(
            string directory
            ) 
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;

            try
            {
                ftpRequest = getRequest(directory);
                ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
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

        public void deleteDirectoryOverSSL(
            string directory
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;

            try
            {
                ftpRequest = getRequest(directory);
                ftpRequest.Method = WebRequestMethods.Ftp.RemoveDirectory;

                // ***
                // Accept Certificate
                // ***
                ftpRequest.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptCertifications);
                ServicePointManager.Expect100Continue = true;

                // --
                
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpResponse.Close();
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

        public FFtpDirectoryEntryCollection fFtpDirectoryEntryCollection(
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            StreamReader streamReader;
            string listing;

            try
            {
                ftpRequest = getRequest("");
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                using (ftpResponse = ftpRequest.GetResponse() as FtpWebResponse)
                {
                    streamReader = new StreamReader(ftpResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                    listing = streamReader.ReadToEnd();
                    ftpResponse.Close();
                }
                return parseDirectoryListing(listing);
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

        public FFtpDirectoryEntryCollection fFtpDirectoryEntryCollectionOverSSL(
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            StreamReader streamReader;
            string listing;

            try
            {
                ftpRequest = getRequest("");
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;

                // ***
                // Accept Certificate
                // ***
                ftpRequest.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptCertifications);
                ServicePointManager.Expect100Continue = true;

                // --

                using (ftpResponse = ftpRequest.GetResponse() as FtpWebResponse)
                {
                    streamReader = new StreamReader(ftpResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                    listing = streamReader.ReadToEnd();
                    ftpResponse.Close();
                }
                return parseDirectoryListing(listing);
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

        public FFtpDirectoryEntryCollection fFtpDirectoryEntryCollection(
           string url 
            )
        {
            try
            {
                setUrl(url);
                return fFtpDirectoryEntryCollection();
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

        public FFtpDirectoryEntryCollection fFtpDirectoryEntryCollectionOverSSL(
           string url
            )
        {
            try
            {
                setUrl(url);
                return fFtpDirectoryEntryCollectionOverSSL();
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

        private bool directoryExists(
            string directory
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            StreamReader streamReader;

            try
            {
                ftpRequest = getRequest(directory);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

                using (ftpResponse = ftpRequest.GetResponse() as FtpWebResponse)
                {
                    streamReader = new StreamReader(ftpResponse.GetResponseStream(),System.Text.Encoding.UTF8);
                    streamReader.ReadToEnd();
                    streamReader.Close();
                    ftpResponse.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
 
            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private bool directoryExistsOverSSL(
            string directory
            )
        {
            FtpWebRequest ftpRequest;
            FtpWebResponse ftpResponse;
            StreamReader streamReader;

            try
            {
                ftpRequest = getRequest(directory);
                ftpRequest.Method = WebRequestMethods.Ftp.ListDirectory;

                // ***
                // Accept Certificate
                // ***
                ftpRequest.EnableSsl = true;
                ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(AcceptCertifications);
                ServicePointManager.Expect100Continue = true;

                // --

                using (ftpResponse = ftpRequest.GetResponse() as FtpWebResponse)
                {
                    streamReader = new StreamReader(ftpResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                    streamReader.ReadToEnd();
                    streamReader.Close();
                    ftpResponse.Close();
                }
                return true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return false;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void setUrl(
            string url
            )
        {
            int pos;

            try
            {
                // Separate domain from directory
                pos = url.IndexOf("ftp://");
                pos = url.IndexOfAny(m_slashes, (pos < 0) ? 0 : pos + 3);

                if (pos < 0)
                {
                    m_domain = ftpString+url;
                    m_cwd = ForwardSlash;
                }
                else
                {
                    m_domain = url.Substring(0, pos);
                    // Normalize directory string
                    m_cwd = applyDirectory(url.Substring(pos));
                }
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

        private string getUrl(
            string directory
            )
        {
            try
            {
                if (directory.Length == 0)
                {
                    return m_domain + m_cwd;
                }
                return m_domain + applyDirectory(directory);
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

        //------------------------------------------------------------------------------------------------------------------------

        private string applyDirectory(
            string directory
            )
        {
            int pos;

            try
            {
                // Normalize directory
                directory = directory.Trim();
                directory = directory.Replace(BackSlash, ForwardSlash);
                directory = directory.TrimEnd(m_slashes);

                if (directory == "..")
                {
                    pos = m_cwd.LastIndexOf(ForwardSlash);
                    return (pos <= 0) ? ForwardSlash : m_cwd.Substring(0, pos);
                }                
                else if (m_cwd == string.Empty && directory.StartsWith(ForwardSlash))
                {
                    // Specifies complete directory path
                    return directory;
                }
                else
                {
                    // Relative to current directory
                    if (m_cwd == ForwardSlash)
                    {
                        return m_cwd + directory;
                    }
                }
                return m_cwd + ForwardSlash + directory;
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

        //------------------------------------------------------------------------------------------------------------------------

        private FtpWebRequest getRequest(
            string fileName
            )
        {
            FtpWebRequest ftpRequest;
            string url;

            try
            {
                url = getUrl(fileName);

                if (url.IndexOf(ftpString) < 0)
                {
                    url = ftpString + url;
                }

                ftpRequest = WebRequest.Create(url) as FtpWebRequest;
                ftpRequest.Credentials = new NetworkCredential(m_userName, m_password);
                ftpRequest.Proxy = null;
                ftpRequest.UsePassive = m_isPassiveMode;
                ftpRequest.KeepAlive = false;
                return ftpRequest;
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

        private FFtpDirectoryEntryCollection parseDirectoryListing(
            string listing
            )
        {
            ParseLine parseFunction;
            Dictionary<string, FFtpDirectoryEntry> entryDict;
            List<FFtpDirectoryEntry> entryList;
            FtpDirectoryFormat format;
            FFtpDirectoryEntry entry;
            string[] lines;

            try
            {
                parseFunction = null;
                entryDict = new Dictionary<string, FFtpDirectoryEntry>();
                entryList = new List<FFtpDirectoryEntry>();
                lines = listing.Split('\n');
                format = guessDirectoryFormat(lines);
               
                if (format == FtpDirectoryFormat.Windows)
                {
                    parseFunction = parseWindowsDirectoryListing;
                }

                if (parseFunction != null)
                {
                    foreach (string line in lines)
                    {
                        if (line.Length > 0)
                        {
                            entry = parseFunction(line);

                            if (entry.name != "." && entry.name != "..")
                            {
                                entryDict.Add(entry.name, entry);
                                entryList.Add(entry);
                            }
                        }
                    }
                }
                    
                return new FFtpDirectoryEntryCollection(entryDict, entryList);
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

        private FtpDirectoryFormat guessDirectoryFormat(
            string[] lines
            )
        {
            try
            {
                foreach (string s in lines)
                {
                    if (s.Length > 8 && Regex.IsMatch(s.Substring(0, 8),"[0-9][0-9]-[0-9][0-9]-[0-9][0-9]"))
                    {
                        return FtpDirectoryFormat.Windows;
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return FtpDirectoryFormat.Unknown;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private FFtpDirectoryEntry parseWindowsDirectoryListing(
            string text
            )
        {
            FFtpDirectoryEntry entry;
            DateTime dateTime;
            string dateString;
            string dateValue;
            bool result;
            int pos;

            try
            {
                entry = new FFtpDirectoryEntry();

                text = text.Trim();
                dateString = text.Substring(0, 17);
                text = text.Substring(17).Trim();

                dateValue = dateString;
                dateValue = dateValue.Substring(0, dateValue.Length - 2);
                result = DateTime.TryParseExact(dateValue, "MM-dd-yy HH:mm", null, DateTimeStyles.AllowWhiteSpaces, out dateTime);

                if (!result)
                {
                    FDebug.throwFException ("invalid format.");
                }

                dateString = dateTime.ToString("yyyy-MM-dd HH:mm:ss");
                entry.createTime = DateTime.Parse(String.Format("{0} ", dateString));

                if (text.Substring(0, 5) == "<DIR>")
                {
                    entry.isDirectory = true;
                    text = text.Substring(5).Trim();
                }
                else
                {
                    entry.isDirectory = false;
                    pos = text.IndexOf(' ');
                    entry.size = Int64.Parse(text.Substring(0, pos));
                    text = text.Substring(pos).Trim();
                }
                entry.name = text;  // Rest is name

                return entry;
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

        public static bool AcceptCertifications(
            object sender,
            X509Certificate certification,
            X509Chain chain,
            SslPolicyErrors sslPolicyErrors
            )
        {
            return true;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // class end
}   // namespace end

