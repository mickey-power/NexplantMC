/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsControlMessage.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.11
--  Description     : FAmate Converter FaSecs1ToHsms SECS Control Message Class
--  History         : Created by spike.lee at 2017.04.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    public class FSecsControlMessage: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        // --
        private FHsmsControlMessageType m_fType = FHsmsControlMessageType.SelectReq;
        private UInt16 m_sessionId = 0;
        private byte m_byte2 = 0;
        private byte m_byte3 = 0;
        private byte m_ptype = 0;
        private byte m_stype = 0;
        private UInt32 m_systemBytes = 0;
        private string m_reason = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsControlMessage(
            FSecs1ToHsms fSecs1ToHsms,
            FHsmsControlMessageType fType,
            UInt16 sessionId,
            byte byte2,
            byte byte3,
            byte ptype,
            byte stype,
            UInt32 systemBytes,
            string reason
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            // --
            m_fType = fType;
            m_sessionId = sessionId;
            m_byte2 = byte2;
            m_byte3 = byte3;
            m_ptype = ptype;
            m_stype = stype;
            m_systemBytes = systemBytes;
            m_reason = reason;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsControlMessage(
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
                    m_fSecs1ToHsms = null;
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

        public FHsmsControlMessageType fType
        {
            get
            {
                try
                {
                    return m_fType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FHsmsControlMessageType.SelectReq;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public int length
        {
            get
            {
                try
                {
                    return 10;
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

        public string reason
        {
            get
            {
                try
                {
                    return m_reason;
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

        internal byte[] getBinaryData(
            )
        {
            UInt32 length = 0;
            byte[] data = null;

            try
            {
                length = 10;
                data = new byte[length + 4];

                // --

                // ***
                // Length Copy
                // ***
                Buffer.BlockCopy(FByteConverter.getBytes(length, true), 0, data, 0, 4);

                // --

                // ***
                // Header Copy
                // ***
                Buffer.BlockCopy(FByteConverter.getBytes(m_sessionId, true), 0, data, 4, 2);
                data[6] = m_byte2;
                data[7] = m_byte3;
                data[8] = m_ptype;
                data[9] = m_stype;
                Buffer.BlockCopy(FByteConverter.getBytes(m_systemBytes, true), 0, data, 10, 4);

                // --

                return data;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                data = null;
            }
            return null;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
