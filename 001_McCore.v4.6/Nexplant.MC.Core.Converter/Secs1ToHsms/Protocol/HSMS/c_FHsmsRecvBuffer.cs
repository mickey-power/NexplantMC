/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FHsmsRecvBuffer.cs
--  Creator         : spike.lee
--  Create Date     : 2011.09.07
--  Description     : FAmate Converter FaSecs1ToHsms HSMS Receive Buffer Class
--  History         : Created by spike.lee at 2011.09.07
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    internal class FHsmsRecvBuffer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<byte> m_data = null;
        private bool m_isLengthComp = false;
        private bool m_isHeaderComp = false;
        private bool m_isBodyComp = false;
        private bool m_isCompleted = true;
        // --
        private UInt32 m_length = 0;
        private UInt16 m_sessionId = 0;
        private byte m_byte2 = 0;
        private byte m_byte3 = 0;
        private byte m_ptype = 0;
        private byte m_stype = 0;
        private UInt32 m_systemBytes = 0;
        private List<byte> m_body = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FHsmsRecvBuffer(            
            )                       
        {
            m_data = new List<byte>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FHsmsRecvBuffer(
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
                    m_body = null;
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
                try
                {
                    return m_isCompleted;
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

        public UInt32 length
        {
            get
            {
                try
                {
                    return m_length;
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

        //------------------------------------------------------------------------------------------------------------------------

        public UInt16 sessionId
        {
            get
            {
                try
                {
                    return m_sessionId;
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

        //------------------------------------------------------------------------------------------------------------------------

        public byte byte2
        {
            get
            {
                try
                {
                    return m_byte2;
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

        //------------------------------------------------------------------------------------------------------------------------

        public byte byte3
        {
            get
            {
                try
                {
                    return m_byte3;
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

        //------------------------------------------------------------------------------------------------------------------------

        public byte ptype
        {
            get
            {
                try
                {
                    return m_ptype;
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

        //------------------------------------------------------------------------------------------------------------------------

        public byte stype
        {
            get
            {
                try
                {
                    return m_stype;
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

        //------------------------------------------------------------------------------------------------------------------------

        public UInt32 systemBytes
        {
            get
            {
                try
                {
                    return m_systemBytes;
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

        //------------------------------------------------------------------------------------------------------------------------

        public byte[] body
        {
            get
            {
                try
                {
                    return m_body.ToArray();
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

        public byte stream
        {
            get
            {
                try
                {
                    return (byte)(m_byte2 & 0x7F);
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

        //------------------------------------------------------------------------------------------------------------------------

        public byte function
        {
            get
            {
                try
                {
                    return m_byte3;
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

        //------------------------------------------------------------------------------------------------------------------------

        public bool wbit
        {
            get
            {
                try
                {
                    return (m_byte2 & 0x80) == 0x00 ? false : true;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        public void init(
            )
        {
            try
            {
                m_isLengthComp = false;
                m_isHeaderComp = false;
                m_isBodyComp = false;
                // --
                m_length = 0;
                m_sessionId = 0;
                m_byte2 = 0;
                m_byte3 = 0;
                m_ptype = 0;
                m_stype = 0;
                m_systemBytes = 0;
                m_body = new List<byte>();
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
            try
            {
                while (m_data.Count > 0)
                {
                    if (!m_isLengthComp)
                    {
                        m_isCompleted = false;  // Not Completed
                        if (m_data.Count < 4)
                        {
                            break;
                        }
                        // --
                        m_length = FByteConverter.toUInt32(m_data.GetRange(0, 4).ToArray(), true);
                        // --
                        m_data.RemoveRange(0, 4);
                        m_isLengthComp = true;
                    }
                    else if (!m_isHeaderComp)
                    {
                        if (m_data.Count < 10)
                        {
                            break;
                        }
                        // --
                        m_sessionId = FByteConverter.toUInt16(m_data.GetRange(0, 2).ToArray(), true);                        
                        m_byte2 = m_data[2];
                        m_byte3 = m_data[3];
                        m_ptype = m_data[4];
                        m_stype = m_data[5];
                        m_systemBytes = FByteConverter.toUInt32(m_data.GetRange(6, 4).ToArray(), true);
                        // --
                        m_data.RemoveRange(0, 10);
                        m_isHeaderComp = true;
                        // --
                        // ***
                        // Header Only
                        // ***
                        if (m_length == 10)
                        {
                            m_isBodyComp = true;
                            m_isCompleted = true;   // Completed
                            return true;
                        }
                    }
                    else if (!m_isBodyComp)
                    {
                        if (m_data.Count < m_length - 10)
                        {
                            break;
                        }
                        // --
                        m_body.AddRange(m_data.GetRange(0, (int)(m_length - 10)).ToArray());
                        // --
                        m_data.RemoveRange(0, (int)(m_length - 10));
                        m_isBodyComp = true;
                        m_isCompleted = true;   // Completed
                        return true;
                    }
                }
                return false;
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
