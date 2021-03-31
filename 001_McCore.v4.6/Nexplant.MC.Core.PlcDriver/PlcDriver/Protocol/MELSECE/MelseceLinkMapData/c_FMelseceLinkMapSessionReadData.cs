/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelseceLinkMapSessionReadData.cs
--  Creator         : spike.lee
--  Create Date     : 2013.10.24
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Link Map Session Read Data Class 
--  History         : Created by spike.lee at 2013.10.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelseceLinkMapSessionReadData : FMelseceLinkMapData, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private string m_bitDeviceCode = string.Empty;
        private UInt32 m_bitStartAddress = 0;
        private string m_wordDeviceCode = string.Empty;
        private UInt32 m_wordStartAddress = 0;
        private List<FMelseceData> m_fBitReadList = null;
        private List<FMelseceResult> m_fBitResultList = null;
        private List<FMelseceWordReadData> m_fWordReadList = null;
        private List<FMelseceWordResult> m_fWordResultList = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelseceLinkMapSessionReadData(
            FMelseceSession fSession,
            string bitDeviceCode,
            UInt32 bitStartAddress,
            string wordDeviceCode,
            UInt32 wordStartAddress
            ) 
            : base(fSession)            
        {
            m_bitDeviceCode = bitDeviceCode;
            m_bitStartAddress = bitStartAddress;
            m_wordDeviceCode = wordDeviceCode;
            m_wordStartAddress = wordStartAddress;
            // --
            m_fBitReadList = new List<FMelseceData>();
            m_fBitResultList = new List<FMelseceResult>();
            m_fWordReadList = new List<FMelseceWordReadData>();
            m_fWordResultList = new List<FMelseceWordResult>();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelseceLinkMapSessionReadData(
           )
        {
            myDispose(false);
        }

        //------------------------------------------------------------------------------------------------------------------------

        protected override void myDispose(
            bool disposing
            )
        {
            if (!m_disposed)
            {
                if (disposing)
                {

                }
                m_disposed = true;

                // --

                base.myDispose(disposing);
            }
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

        #region Properties

        public override FMelseceLinkMapDataType fType
        {
            get
            {
                try
                {
                    return FMelseceLinkMapDataType.SessionRead;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FMelseceLinkMapDataType.SessionRead;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        public string bitDeviceCode
        {
            get
            {
                try
                {
                    return m_bitDeviceCode;
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

        //------------------------------------------------------------------------------------------------------------------------

        public UInt32 bitStartAddress
        {
            get
            {
                try
                {
                    return m_bitStartAddress;
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

        public string wordDeviceCode
        {
            get
            {
                try
                {
                    return m_wordDeviceCode;
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

        //------------------------------------------------------------------------------------------------------------------------

        public UInt32 wordStartAddress
        {
            get
            {
                try
                {
                    return m_wordStartAddress;
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

        public List<FMelseceData> fBitReadList
        {
            get
            {
                try
                {
                    return m_fBitReadList;
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

        public List<FMelseceResult> fBitResultList
        {
            get
            {
                try
                {
                    return m_fBitResultList;
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

        public List<FMelseceWordReadData> fWordReadList
        {
            get
            {
                try
                {
                    return m_fWordReadList;
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

        public List<FMelseceWordResult> fWordResultList
        {
            get
            {
                try
                {
                    return m_fWordResultList;
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

        public byte[] getReadBits(
            )
        {
            List<byte> bitBytes = null;
            List<byte> wordBytes = null;
            byte[] bits = null;

            try
            {
                bitBytes = new List<byte>();
                wordBytes = new List<byte>();
                // --
                foreach (FMelseceResult fRet in m_fBitResultList)
                {
                    if (fRet.fType == FPlcResultType.Bit)
                    {
                        bitBytes.AddRange(((FMelseceBitResult)fRet).bits);
                    }
                    else if (fRet.fType == FPlcResultType.Word)
                    {
                        wordBytes.AddRange(((FMelseceWordResult)fRet).bytes);
                    }
                }

                // --

                bits = new byte[(wordBytes.Count * 8) + (bitBytes.Count)];
                // --
                for (int i = 0; i < wordBytes.Count; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        bits[(8 * i) + j] = (byte)((wordBytes[i] >> j) & 0x01);
                    }
                }
                // --
                for (int i = 0; i < bitBytes.Count; i++)
                {
                    bits[(wordBytes.Count * 8) + i] = bitBytes[i];
                }
                // --
                return bits;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                bitBytes = null;
                wordBytes = null;
            }
            return null;
        }

        //------------------------------------------------------------------------------------------------------------------------

        public List<byte> getReadWords(
            )
        {
            List<byte> wordBytes = null;

            try
            {
                wordBytes = new List<byte>();
                // --
                foreach (FMelseceWordResult fRet in m_fWordResultList)
                {
                    wordBytes.AddRange(fRet.bytes);
                }
                // --
                return wordBytes;
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

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
