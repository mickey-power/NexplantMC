/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelseceRandomParam.cs
--  Creator         : spike.lee
--  Create Date     : 2013.10.31
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Random Parameter Class 
--  History         : Created by spike.lee at 2013.10.31
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelseceRandomParam : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<UInt32> m_bitAddresses = null;
        private List<byte> m_bits = null;
        private List<UInt32> m_wordAddresses = null;
        private List<byte[]> m_words = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelseceRandomParam(
            )
        {
            m_bitAddresses = new List<UInt32>();
            m_bits = new List<byte>();
            m_wordAddresses = new List<UInt32>();
            m_words = new List<byte[]>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelseceRandomParam(
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
                    m_bitAddresses = null;
                    m_bits = null;
                    m_wordAddresses = null;
                    m_words = null;
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

        public List<UInt32> bitAddresses
        {
            get
            {
                try
                {
                    return m_bitAddresses;
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

        public List<byte> bits
        {
            get
            {
                try
                {
                    return m_bits;
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

        public List<UInt32> wordAddresses
        {
            get
            {
                try
                {
                    return m_wordAddresses;
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

        public List<byte[]> words
        {
            get
            {
                try
                {
                    return m_words;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Methods

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
