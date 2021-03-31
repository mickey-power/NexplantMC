/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FFtp.cs
--  Creator         : taejin.kim
--  Create Date     : 2018.06.16
--  Description     : FAmate Package Ftp Class
--  History         : Created by taejin.kim at 2018.06.16
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using Nexplant.MC.Core.FaCommon;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using Renci.SshNet.Common;
using System.Threading;
using System.Linq;
using System.Text;

namespace Nexplant.MC.Core.FaCommon
{
    public class FSftp : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private const string ftpString = "ftp://";
        private const string ftpSlash = "/";
        private const int ftpDefaultPort = 22;
        // --
        private bool m_disposed = false;
        // --
        private string m_ftpFullPath = string.Empty;
        private string m_host = string.Empty;
        private int m_port = 0;
        private string m_directory = string.Empty;
        private string m_userName = string.Empty;
        private string m_password = string.Empty;
        private bool m_useSsl = false;
        // --
        private bool m_uploadPathExist = false;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSftp(            
            string ftpPath
            )
        {
            string temp = string.Empty;
            string[] tempArray = null;
            string host = string.Empty;
            int port = 0;
            int directoryIndex = 0;
            int portIndex = 0;
            
            if (ftpPath.Substring(ftpPath.Length - 1) != "/")
            {
                ftpPath += "/";
            }

            directoryIndex = ftpPath.ToLower().IndexOf(ftpString);

            if (directoryIndex != 0)
            {
                FDebug.throwFException("The ftp path does not match the format.");
            }

            temp = ftpPath.Substring(6);
            tempArray = temp.Split('/');
            // --
            portIndex = tempArray[0].IndexOf(':');
            if (portIndex == -1)
            {
                host = tempArray[0];
                port = ftpDefaultPort;
            }
            else
            {
                host = tempArray[0].Substring(0, portIndex);
                port = Convert.ToInt32(tempArray[0].Substring(portIndex + 1));
            }

            m_ftpFullPath = ftpPath;
            m_host = host;
            m_port = port;
            m_directory = temp.Substring(temp.IndexOf('/'));
            if (m_userName != string.Empty)
            {
                m_userName = "anonymous";
            }
            if (m_password != string.Empty)
            {
                m_password = "";
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public FSftp(            
            string ftpPath,
            string username,
            string password,
            bool useSsl = false
            )
            : this(ftpPath)
        {
            m_userName = username;
            m_password = password;
            m_useSsl = useSsl;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSftp(
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

        public bool uploadPathExist
        {
            get
            {
                try
                {
                    return m_uploadPathExist;
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

            set
            {
                try
                {
                    m_uploadPathExist = value;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        private void createDirectory(
            string dateDirectory
            )
        {
            SftpClient sftp = null;
            IEnumerable<SftpFile> sftpfileList = null;
            // --
            List<string> paths = null;
            string[] steps = null;

            try
            {
                sftp = new SftpClient(m_host, m_port, m_userName, m_password);



                paths = new List<string>();
                steps = m_directory.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);

                // --

                // ***
                // sftp Open 
                // ***

                sftp.Connect();

                // --
                // ***
                // sftp File Path Search
                // ***
                for (int i = 1; i <= steps.Length; i++)
                {
                    try
                    {
                        sftpfileList = sftp.ListDirectory(String.Join(ftpSlash, steps, 0, i) + ftpSlash);
                    }
                    catch (SftpPathNotFoundException spex)
                    {
                        // Not eixst remote directory
                        sftp.CreateDirectory(String.Join(ftpSlash, steps, 0, i) + ftpSlash);
                    }
                    catch (Exception ex)
                    {
                        FDebug.throwException(ex);
                    }
                }

                // --

                try
                {
                    sftp.ListDirectory(sftp.WorkingDirectory + m_directory + dateDirectory + ftpSlash);
                }
                catch (SftpPathNotFoundException spex)
                {
                    sftp.CreateDirectory(sftp.WorkingDirectory + m_directory + dateDirectory + ftpSlash);
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                sftpfileList = null;
                // --
                if (sftp != null)
                {
                    sftp.Disconnect();
                    sftp.Dispose();
                    sftp = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void uploadFile(
            string filePath,
            ref string remoteFileName
            )
        {
            FileInfo fi = null;
            string dateDirectory = string.Empty;
            // --
            SftpClient sftp = null;

            try
            {
                sftp = new SftpClient(m_host, m_port, m_userName, m_password);

                sftp.Connect();

                // --

                // Exist Check Local File 
                if (!File.Exists(filePath))
                {
                    FDebug.throwFException("File does not exist. [" + filePath + "]");
                }

                // --

                fi = new FileInfo(filePath);
                dateDirectory = fi.LastWriteTime.ToString("yyyyMMdd");

                // Exist Check Ftp Directory
                createDirectory(dateDirectory);

                // --
                

                remoteFileName = sftp.WorkingDirectory + m_directory + dateDirectory + "/" + Path.GetFileName(filePath);

                FileStream a = new FileStream(filePath, FileMode.Open);

                // Upload File
                sftp.UploadFile(a, remoteFileName, true, null);
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fi = null;
                // --
                if (sftp != null)
                {
                    sftp.Disconnect();
                    sftp.Dispose();
                    sftp = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void DownloadFile(
            string path,
            params string[] files
            )
        {            
            SftpClient sftp = null;
            string RootFileName = string.Empty;

            try
            {
                sftp = new SftpClient(m_host, m_port, m_userName, m_password);
                // --
                sftp.Connect();
                
                // --

                foreach (string fileName in files)
                {

                    RootFileName = Path.GetFileName(fileName);

                    using (Stream file1 = File.OpenWrite(path + "\\" + RootFileName))
                    {
                        sftp.DownloadFile(fileName, file1);
                    }
                    Thread.Sleep(100);
                }                        
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {   
                if (sftp != null)
                {
                    sftp.Disconnect();
                    sftp.Dispose();
                    sftp = null;
                }
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        public void DeleteFiles(
            params string[] files
            )
        {
            SftpClient sftp = null;

            try
            {
                sftp = new SftpClient(m_host, m_port, m_userName, m_password);
                // --
                sftp.Connect();

                // --

                foreach (string file in files)
                {
                    sftp.DeleteFile(file);
                    Thread.Sleep(100);
                }
            }
            catch (Exception ex)         
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sftp != null)
                {
                    sftp.Disconnect();
                    sftp.Dispose();
                    sftp = null;
                }
            }        
        }
        
        //------------------------------------------------------------------------------------------------------------------------

        public List<string> getFileList(
            string directorypath
            )
        {
            SftpClient sftp = null;
            List<SftpFile> sftpFileList = null;
            List<string> fileNameList = null;

            try
            {
                
                sftp = new SftpClient(m_host, m_port, m_userName, m_password);
                // --
                sftp.Connect();

                // --

                sftpFileList = sftp.ListDirectory(directorypath).ToList();
                if (sftpFileList != null && sftpFileList.Count > 2)
                {
                    foreach (SftpFile fsftpfile in sftpFileList)
                    {
                        fileNameList.Add(fsftpfile.FullName);
                    }
                    fileNameList.RemoveAt(1);
                    fileNameList.RemoveAt(0);
                }
                return fileNameList;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                if (sftp != null)
                {
                    sftp.Disconnect();
                    sftp.Dispose();
                    sftp = null;
                }
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public void ConnectionCheck(
            )
        {
            SftpClient sftp = null;

            try
            {
                sftp = new SftpClient(m_host, m_port, m_userName, m_password);
                // --
                sftp.Connect();
                m_uploadPathExist = true;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
                m_uploadPathExist = false;
            }
            finally
            {
                if (sftp != null)
                {
                    sftp.Disconnect();
                    sftp.Dispose();
                    sftp = null;
                }
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end