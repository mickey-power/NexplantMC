/*---------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FBlockInfo.cs
--  Creator         : byungyun.jeon
--  Create Date     : 2011.11.17
--  Description     : FAMate Core FaSecsDriver SECS-1 Block Information Class 
--  History         : Created by byungyun.jeon at 2011.11.03
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;
using System.Collections;

namespace Nexplant.MC.Core.FaSecsDriver
{
    internal class FBlockInfo : IDisposable
    {
        private bool m_disposed = false;
        // --
        private bool m_rbit = false;
        private UInt16 m_sessionId = 0;
        private bool m_wbit = false;
        private int m_stream = 0;
        private int m_function = 0;
        private bool m_ebit = false;
        private UInt16 m_blockNo = 0;
        private UInt32 m_systemBytes = 0;
        // --        
        private byte[] m_block = null;

        //------------------------------------------------------------------------------------------------------------------------
        
        #region Class Construction and Destruction

        public FBlockInfo(
            byte[] block
            )
        {
            getBlockInfo(block);
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FBlockInfo(
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
                    term();
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

        public int stream
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
        
        public int function
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

        public int length
        {
            get
            {
                try
                {
                    return m_block.Length;
                }
                catch(Exception ex)
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

        public byte[] block
        {
            get
            {
                try
                {
                    return m_block;
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
                byte blockSize = 0;

                try
                {
                    blockSize = this.block[0];
                    // --
                    return FByteConverter.toUInt16(new byte[] { block[blockSize + 1], block[blockSize + 2] }, true);
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

        public bool isCheckSum
        {
            get
            {
                int i = 0;
                UInt16 calculateValue = 0;

                try
                {
                    calculateValue = 0;
                    for (i = 1; i <= block[0]; i++)
                    {
                        calculateValue += (UInt16)block[i]; 
                    }
                    // --
                    return (calculateValue == checkSum) ? true : false;
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

        public bool isFirst
        {
            get
            {
                try
                {
                    return (this.blockNo == 0 || this.blockNo == 1) ? true : false;
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

        public bool isLast
        {
            get
            {
                try
                {
                    return this.ebit;
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

        public bool isPrimary
        {
            get
            {
                try
                {
                    return (this.function % 2 == 1) ? true : false;
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
        
        public bool isSecondary
        {
            get
            {
                try
                {
                    return (this.function % 2 == 0) ? true : false;
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

        private FBlockInfo getBlockInfo(
            byte[] block
            )
        {
            try
            {
                if (block == null)
                {
                    return null;
                }
                 
                // -- 

                m_rbit = (block[1] & 0x80) == 0 ? false : true;
                m_sessionId = FByteConverter.toUInt16(new byte[] { (byte)(block[1] & 0x7F), block[2] }, true);
                m_wbit = (block[3] & 0x80) == 0 ? false : true;
                m_stream = block[3] & 0x7F;
                m_function = block[4];
                m_ebit = (block[5] & 0x80) == 0 ? false : true;
                m_blockNo = FByteConverter.toUInt16(new byte[] { (byte)(block[5] & 0x7F), block[6] }, true);
                m_systemBytes = FByteConverter.toUInt32(new byte[] { block[7], block[8], block[9], block[10] }, true);
                m_block = block;
                
                // --

                return this;
            }
            catch(Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {

            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        private void term(
            )
        {
            try
            {

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
