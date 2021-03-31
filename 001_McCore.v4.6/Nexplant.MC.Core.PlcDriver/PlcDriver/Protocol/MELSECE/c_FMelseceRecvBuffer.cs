/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelseceRecvBuffer.cs
--  Creator         : spike.lee
--  Create Date     : 2013.10.23
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Receive Buffer Class 
--  History         : Created by spike.lee at 2013.10.23
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelseceRecvBuffer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FManualEvent m_fEvent = null;
        private bool m_enabled = false;
        private bool m_result = false;
        private string m_message = string.Empty;
        private List<byte> m_header = null;
        private List<byte> m_data = null;
        private int m_headerLength = 0;
        private int m_dataLength = 0;
        private int m_dataSpace = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelseceRecvBuffer(
            )
        {
            m_header = new List<byte>();
            m_data = new List<byte>();
            // --
            m_fEvent = new FManualEvent();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelseceRecvBuffer(
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
                    if (m_fEvent != null)
                    {
                        m_fEvent.Dispose();
                        m_fEvent = null;
                    }
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

        public bool enabled
        {
            get
            {
                try
                {
                    return m_enabled;
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
                    m_enabled = value;
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

        public bool result
        {
            get
            {
                try
                {
                    return m_result;
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
                    m_result = value;
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

        public string message
        {
            get
            {
                try
                {
                    return m_message;
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
                    m_message = value;
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

        public List<byte> header
        {
            get
            {
                try
                {
                    return m_header;
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

        public List<byte> data
        {
            get
            {
                try
                {
                    return m_data;
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

        public int headerLength
        {
            get
            {
                try
                {
                    return m_headerLength;
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
                    m_headerLength = value;
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

        public int dataLength
        {
            get
            {
                try
                {
                    return m_dataLength;
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
                    m_dataLength = value;
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

        public int dataSpece
        {
            get
            {
                try
                {
                    return m_dataSpace;
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
                    m_dataSpace = value;
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

        public void set(
            )
        {
            try
            {
                m_fEvent.set();
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

        public void reset(
            )
        {
            try
            {
                m_fEvent.reset();
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

        public bool wait(
            int time
            )
        {
            try
            {
                return m_fEvent.tryWait(time);
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

        public byte[] getBytes(
            )
        {
            byte[] bytes = null;

            try
            {
                bytes = new byte[m_header.Count + m_data.Count];
                Array.Copy(m_header.ToArray(), bytes, m_header.Count);
                Array.Copy(m_data.ToArray(), 0, bytes, m_header.Count, m_data.Count);
                // --
                return bytes;
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

        public void clear(
            )
        {
            try
            {
                m_enabled = false;
                // --
                m_result = false;
                m_message = string.Empty;
                // --
                m_header.Clear();
                m_data.Clear();
                // --
                m_headerLength = 0;
                m_dataLength = 0;
                m_dataSpace = 0;
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
