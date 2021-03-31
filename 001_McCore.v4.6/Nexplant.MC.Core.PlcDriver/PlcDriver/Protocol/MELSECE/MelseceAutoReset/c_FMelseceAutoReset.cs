/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelseceAutoReset.cs
--  Creator         : spike.lee
--  Create Date     : 2013.11.06
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Auto Reset Data Class 
--  History         : Created by spike.lee at 2013.11.06
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelseceAutoReset : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FMelseceSession m_fSession = null;
        private FXmlNode m_fXmlNodePmg = null;
        private FXmlNode m_fXmlNodePbt = null;
        private string m_bitDeviceCode = string.Empty;
        private UInt32 m_bitStartAddress = 0;
        private UInt32 m_bitAddress = 0;
        private string m_wordDeviceCode = string.Empty;
        private UInt32 m_wordStartAddress = 0;
        private string m_key = string.Empty;
        private long m_ticks = 0; 
        
        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelseceAutoReset(
            FMelseceSession fSession,            
            FXmlNode fXmlNodePmg,
            FXmlNode fXmlNodePbt
            )
        {
            string bit = string.Empty;

            m_fSession = fSession;
            m_fXmlNodePmg = fXmlNodePmg;
            m_fXmlNodePbt = fXmlNodePbt;
            // --
            m_bitDeviceCode = m_fXmlNodePmg.get_attrVal(FXmlTagPMGL.A_BitDeviceCode, FXmlTagPMGL.D_BitDeviceCode);
            m_bitStartAddress = UInt32.Parse(m_fXmlNodePmg.get_attrVal(FXmlTagPMGL.A_BitStartAddress, FXmlTagPMGL.D_BitStartAddress));
            m_wordDeviceCode = fXmlNodePmg.get_attrVal(FXmlTagPMGL.A_WordDeviceCode, FXmlTagPMGL.D_WordDeviceCode);
            m_wordStartAddress = UInt32.Parse(m_fXmlNodePmg.get_attrVal(FXmlTagPMGL.A_WordStartAddress, FXmlTagPMGL.D_WordStartAddress));
            // --
            m_bitAddress = UInt32.Parse(m_fXmlNodePbt.get_attrVal(FXmlTagPBTL.A_Address, FXmlTagPBTL.D_Address));
            bit = m_fXmlNodePbt.get_attrVal(FXmlTagPBTL.A_Value, FXmlTagPBTL.D_Value);
            if (bit == "0")
            {
                bit = "1";
            }
            else
            {
                bit = "0";
            }
            m_fXmlNodePbt.set_attrVal(FXmlTagPBTL.A_Value, FXmlTagPBTL.D_Value, bit);
            // --
            m_key = FMelseceAutoResetList.generateKey(m_bitDeviceCode, m_bitStartAddress, m_bitAddress);
            m_ticks = FTickCount.ticks;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelseceAutoReset(
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
                    m_fSession = null;
                    m_fXmlNodePmg = null;
                    m_fXmlNodePbt = null;
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

        public FMelseceSession fSession
        {
            get
            {
                try
                {
                    return m_fSession;
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

        public FXmlNode fXmlNodePmg
        {
            get
            {
                try
                {
                    return m_fXmlNodePmg;
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

        public FXmlNode fXmlNodePbt
        {
            get
            {
                try
                {
                    return m_fXmlNodePbt;
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

        public UInt32 bitAddress
        {
            get
            {
                try
                {
                    return m_bitAddress;
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

        public string key
        {
            get
            {
                try
                {
                    return m_key;
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

        public long ticks
        {
            get
            {
                try
                {
                    return m_ticks;
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
