/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelseceSession.cs
--  Creator         : spike.lee
--  Create Date     : 2013.10.24
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Session Class 
--  History         : Created by spike.lee at 2013.10.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelseceSession : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FPlcSession m_fPlcSession = null;
        private FStaticTimer m_fReadTimer = null;
        private byte[] m_oldReadBits = null;
        private byte[] m_newReadBits = null;
        private List<byte> m_readWords = null;
        private bool m_isReadCompleted = true;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelseceSession(
            FPlcSession fPlcSession
            )
        {
            m_fPlcSession = fPlcSession;
            m_fReadTimer = new FStaticTimer();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelseceSession(
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
                    m_fPlcSession = null;
                    // --
                    if (m_fReadTimer != null)
                    {
                        m_fReadTimer.Dispose();
                        m_fReadTimer = null;
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

        public FPlcSession fPlcSession
        {
            get
            {
                try
                {
                    return m_fPlcSession;
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

        public FStaticTimer fReadTimer
        {
            get
            {
                try
                {
                    return m_fReadTimer;
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

        public byte[] oldReadBits
        {
            get
            {
                try
                {
                    return m_oldReadBits;
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

        public byte[] newReadBits
        {
            get
            {
                try
                {
                    return m_newReadBits;
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

        public bool isReadCompleted
        {
            get
            {
                try
                {
                    return m_isReadCompleted;
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
                    m_isReadCompleted = value;
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

        public UInt32[] getChangedReadBits(
            byte[] newReadBits
            )
        {
            List<UInt32> chgBits = null;

            try
            {
                m_oldReadBits = m_newReadBits;
                m_newReadBits = newReadBits;
                chgBits = new List<UInt32>();

                // --

                if (m_oldReadBits == null)
                {
                    m_oldReadBits = new byte[m_newReadBits.Length];
                }

                // --

                for (int i = 0; i < m_newReadBits.Length; i++)
                {
                    if (m_oldReadBits[i] != m_newReadBits[i])
                    {
                        chgBits.Add((UInt32)((((UInt32)m_newReadBits[i]) << 31) + i));
                    }
                }

                // --

                return chgBits.ToArray();
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                chgBits = null;
            }
            return null;
        }

        //-----------------------------------------------------------------------------------------------------------------------

        public byte getReadBit(
            UInt32 address
            )
        {
            try
            {
                return m_newReadBits[address];
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

        //-----------------------------------------------------------------------------------------------------------------------

        public void setReadWords(
            List<byte> readWords
            )
        {
            try
            {
                m_readWords = readWords;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
        }

        //-----------------------------------------------------------------------------------------------------------------------

        public byte[] getReadWord(
            UInt32 address, 
            int length
            )
        {
            int binaryIndex = 0;

            try
            {
                binaryIndex = (int)address * 2;
                return m_readWords.GetRange(binaryIndex, length).ToArray();
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

        #endregion

        //-----------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
