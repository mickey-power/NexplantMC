/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelseceLinkMapMessageReadData.cs
--  Creator         : spike.lee
--  Create Date     : 2013.11.04
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Link Map Message Read Data Class 
--  History         : Created by spike.lee at 2013.11.04
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelseceLinkMapMessageReadData : FMelseceLinkMapData, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<FMelseceWordReadData[]> m_fBitReadList = null;
        private List<FMelseceWordResult> m_fBitResultList = null;
        private List<FMelseceWordReadData[]> m_fWordReadList = null;
        private List<FMelseceWordResult> m_fWordResultList = null;
        private FXmlNode m_fXmlNodePmgl = null;
        private int m_timeout = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelseceLinkMapMessageReadData(
            FMelseceSession fSession,
            FXmlNode fXmlNodePmgl,
            int timeout
            ) 
            : base(fSession)            
        {
            m_fBitReadList = new List<FMelseceWordReadData[]>();
            m_fBitResultList = new List<FMelseceWordResult>();
            m_fWordReadList = new List<FMelseceWordReadData[]>();
            m_fWordResultList = new List<FMelseceWordResult>();
            // --
            m_fXmlNodePmgl = fXmlNodePmgl;
            m_timeout = timeout;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelseceLinkMapMessageReadData(
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
                    m_fBitReadList = null;
                    m_fWordReadList = null;
                    m_fXmlNodePmgl = null;
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
                    return FMelseceLinkMapDataType.MessageRead;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FMelseceLinkMapDataType.MessageRead;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public List<FMelseceWordReadData[]> fBitReadList
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

        public List<FMelseceWordResult> fBitResultList
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

        public List<FMelseceWordReadData[]> fWordReadList
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

        //------------------------------------------------------------------------------------------------------------------------

        public FXmlNode fXmlNodePmgl
        {
            get
            {
                try
                {
                    return m_fXmlNodePmgl;
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

        public int timeout
        {
            get
            {
                try
                {
                    return m_timeout;
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

        public byte[] getReadBits(
            )
        {
            List<byte> bitBytes = null;

            try
            {
                bitBytes = new List<byte>();
                // --
                foreach (FMelseceWordResult fRet in m_fBitResultList)
                {
                    bitBytes.AddRange(fRet.bytes);
                }
                // --
                return bitBytes.ToArray();
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

        public byte[] getReadWords(
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
                return wordBytes.ToArray();
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
