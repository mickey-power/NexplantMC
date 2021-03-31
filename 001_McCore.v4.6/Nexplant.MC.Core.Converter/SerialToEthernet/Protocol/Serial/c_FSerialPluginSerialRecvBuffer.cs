/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialRecvBuffer.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.25
--  Description     : FAmate Converter FaSerialToEthernet Serial Recveived Buffer Class
--  History         : Created by mjkim at 2019.09.25
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    public class FSerialPluginRecvBuffer: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<Byte> m_data = null;
        // --
        private byte[] m_suffix = new byte[] { 0x0D, 0x0A };
        private byte[] m_bin = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSerialPluginRecvBuffer(
            )
        {
            m_data = new List<Byte>();
        }

        //------------------------------------------------------------------------------------------------------------------------
        public FSerialPluginRecvBuffer(
            byte[] suffix
            ) : this()
        {
            m_suffix = suffix;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialPluginRecvBuffer(
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
                    m_data = null;
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

        public bool isCompleted
        {
            get
            {
                int etxPtr = 0;

                try
                {
                    if (m_suffix == null)
                    {
                        return true;
                    }

                    // --

                    etxPtr = m_data.IndexOf(m_suffix[0]);
                    if (etxPtr != -1 && m_data.Count >= etxPtr + m_suffix.Length)
                    {
                        for (int i = 1; i < m_suffix.Length - 1; i++)
                        {
                            if (m_suffix[i] != (byte)m_data[etxPtr + i])
                            {
                                return false;
                            }
                        }
                        return true;
                    }
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
        }

        //------------------------------------------------------------------------------------------------------------------------

        public byte[] binData
        {
            get
            {
                try
                {
                    return m_data.ToArray();
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

        public string binToString
        {
            get
            {
                try
                {
                    return Encoding.Default.GetString(m_bin);
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
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void init(
            )
        {
            try
            {
                m_bin = null;
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

        public void clear(
            )
        {
            try
            {
                init();
                m_data.Clear();
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

        public void input(
            byte[] data
            )
        {
            try
            {
                m_data.AddRange(data);
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

        public bool parse(
            )
        {
            int etxPtr = 0;

            try
            {
                if (m_data.Count == 0)
                {
                    return false;
                }

                // --

                if (m_suffix == null)
                {
                    etxPtr = m_data.Count;
                }
                else
                {
                    etxPtr = m_data.IndexOf(m_suffix[0]);
                    // --
                    if (etxPtr == -1)
                    {
                        return false;
                    }
                    // --
                    for (int i = 1; i < m_suffix.Length - 1; i++)
                    {
                        if (m_suffix[i] != (byte)m_data[etxPtr + i])
                        {
                            return false;
                        }
                    }
                }

                // --

                m_bin = m_data.GetRange(0, etxPtr).ToArray();

                // --

                // ***
                // Etx를 포함한 데이터 제거
                // ***
                m_data.RemoveRange(0, etxPtr + (m_suffix != null ? m_suffix.Length : 0));
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
