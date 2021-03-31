/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FZipEntry.cs
--  Creator         : mj.kim
--  Create Date     : 2011.08.26
--  Description     : FAMate Core FaCommon ZIP Entry Class
--  History         : Created by mj.kim at 2011.08.26
----------------------------------------------------------------------------------------------------------*/
using System;

namespace Nexplant.MC.Core.FaCommon
{
    public class FZipEntry : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_name = string.Empty;
        private DateTime m_creationTime;
        private DateTime m_lastWriteTime;
        private DateTime m_lastAccessTime;
        private long m_size = 0;
        private long m_compressedSize = 0;
        private bool m_isFile = false;

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Class Construction and Destruction

        public FZipEntry(
            string name
            )
        {
            m_name = name;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FZipEntry(
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public DateTime creationTime
        {
            get
            {
                try
                {
                    return m_creationTime;
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
                    m_creationTime = value;
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

        public DateTime lastWriteTime
        {
            get
            {
                try
                {
                    return m_lastWriteTime;
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
                    m_lastWriteTime = value;
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

        public DateTime lastAccessTime
        {
            get
            {
                try
                {
                    return m_lastAccessTime;
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
                    m_lastAccessTime = value;
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

        public long size
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
                return 0;
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

        //------------------------------------------------------------------------------------------------------------------------

        public long compressedSize
        {
            get
            {
                try
                {
                    return m_compressedSize;
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

            set
            {
                try
                {
                    m_compressedSize = value;
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

        public bool isFile
        {
            get
            {
                try
                {
                    return m_isFile;
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
                    m_isFile = value;
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

        public int compressionRatio
        {
            get
            {
                try
                {
                    if (m_size > 0 && m_size >= m_compressedSize)
                    {
                        return (int)Math.Round((1.0 - ((double)m_compressedSize / (double)m_size)) * 100.0);
                    }
                    return 0;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
