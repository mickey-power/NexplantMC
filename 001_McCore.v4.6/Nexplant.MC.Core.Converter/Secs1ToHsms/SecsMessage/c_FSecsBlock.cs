/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsBlock.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.11
--  Description     : FAmate Converter FaSecs1ToHsms SECS Block Class
--  History         : Created by spike.lee at 2017.04.11
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    public class FSecsBlock: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        // --
        private byte m_length = 0;
        private List<byte> m_blockData = null;
        // --
        private bool m_rbit = false;
        private UInt16 m_sessionId = 0;
        private bool m_wbit = false;
        private byte m_stream = 0;
        private byte m_function = 0;
        private bool m_ebit = false;
        private UInt16 m_blockNo = 0;
        private UInt32 m_systemBytes = 0;
        private List<byte> m_body = null;
        private UInt16 m_checkSum = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FSecsBlock(
            FSecs1ToHsms fSecs1ToHsms,
            byte length,
            byte[] blockData,
            bool rbit,
            UInt16 sessionId,
            bool wbit,
            byte stream,
            byte function,
            bool ebit,
            UInt16 blockNo,
            UInt32 systemBytes,
            byte[] body,
            UInt16 checkSum
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            // --
            m_length = length;
            m_blockData = new List<byte>(blockData);
            // --
            m_rbit = rbit;
            m_sessionId = sessionId;
            m_wbit = wbit;
            m_stream = stream;
            m_function = function;
            m_ebit = ebit;
            m_blockNo = blockNo;
            m_systemBytes = systemBytes;
            m_body = new List<byte>(body);
            m_checkSum = checkSum;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsBlock(
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
                    m_blockData = null;
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

        public byte length
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

        public byte[] blockData
        {
            get
            {
                try
                {
                    return m_blockData.ToArray();
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

        public bool rbit
        {
            get
            {
                try
                {
                    return m_rbit;
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

        public bool wbit
        {
            get
            {
                try
                {
                    return m_wbit;
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

        public byte stream
        {
            get
            {
                try
                {
                    return m_stream;
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
                    return m_function;
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

        public bool ebit
        {
            get
            {
                try
                {
                    return m_ebit;
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

        public UInt16 blockNo
        {
            get
            {
                try
                {
                    return m_blockNo;
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

        public UInt16 checkSum
        {
            get
            {
                try
                {
                    return m_checkSum;
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
