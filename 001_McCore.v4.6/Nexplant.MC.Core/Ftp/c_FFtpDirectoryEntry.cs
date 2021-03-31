/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FtpDirectoryEntry.cs
--  Creator         : baehyun seo
--  Create Date     : 2011.08.22
--  Description     : FAMate Core FaCommon FFtpDirectoryEntry class 
--  History         : Created by baehyun seo at 2011.08.22
----------------------------------------------------------------------------------------------------------*/

using System;

namespace Nexplant.MC.Core.FaCommon
{
    public class FFtpDirectoryEntry : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_name;
        private string m_owner;
        private string m_flags;
        private bool m_isDirectory;
        private DateTime m_createTime;
        private Int64 m_size;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FFtpDirectoryEntry(
            )
        {
 
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        ~FFtpDirectoryEntry(
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

        public string name
        {
            get 
            {
                try
                {
                    return m_name;
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

            set 
            {
                try
                {
                    m_name = value;
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

        public string owner
        {
            get 
            {
                try
                {
                    return m_owner;
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

            set
            {
                try
                {
                    m_owner = value;
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

        public string flags
        {
            get
            {
                try
                {
                    return m_flags;
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

            set
            {
                try
                {
                    m_flags = value;
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

        public bool isDirectory
        {
            get
            {
                try
                {
                    return m_isDirectory;
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
                    m_isDirectory = value;
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

        public DateTime createTime
        {
            get
            {
                try
                {
                    return m_createTime;
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

            set
            {
                try
                {
                    m_createTime = value;
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

        public Int64 size
        {
            get 
            {
                try
                {
                    return m_size;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
 
                }
                return -1;
            }

            set
            {
                try
                {
                    m_size = value;
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

    }   //class end
}   //namespace end
