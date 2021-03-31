/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FMelseceLinkMapMessageWriteData.cs
--  Creator         : spike.lee
--  Create Date     : 2013.10.30
--  Description     : FAMate Core FaPlcDriver Melsec Ethernet Link Map Message Write Data Class 
--  History         : Created by spike.lee at 2013.10.30
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaPlcDriver
{
    internal class FMelseceLinkMapMessageWriteData : FMelseceLinkMapData, IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private List<FMelseceBitWriteData[]> m_fBitWriteList = null;
        private List<FMelseceWordWriteData[]> m_fWordWriteList = null;
        private FPlcMessageTransferAreaType m_fMessageAreaType = FPlcMessageTransferAreaType.Write;
        private FXmlNode m_fXmlNodePmgl = null;
        private int m_timeout = 0;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FMelseceLinkMapMessageWriteData(
            FMelseceSession fSession,
            FPlcMessageTransferAreaType fMessageAreaType,
            FXmlNode fXmlNodePmgl,
            int timeout
            ) 
            : base(fSession)            
        {
            m_fBitWriteList = new List<FMelseceBitWriteData[]>();
            m_fWordWriteList = new List<FMelseceWordWriteData[]>();
            // --
            m_fXmlNodePmgl = fXmlNodePmgl;
            m_fMessageAreaType = fMessageAreaType;
            m_timeout = timeout;
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FMelseceLinkMapMessageWriteData(
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
                    m_fBitWriteList = null;
                    m_fWordWriteList = null;
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
                    return FMelseceLinkMapDataType.MessageWrite;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FMelseceLinkMapDataType.MessageWrite;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------
        
        public List<FMelseceBitWriteData[]> fBitWriteList
        {
            get
            {
                try
                {
                    return m_fBitWriteList;
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

        public List<FMelseceWordWriteData[]> fWordWriteList
        {
            get
            {
                try
                {
                    return m_fWordWriteList;
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

        public FPlcMessageTransferAreaType fMessageAreaType
        {
            get
            {
                try
                {
                    return m_fMessageAreaType;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {

                }
                return FPlcMessageTransferAreaType.Write;
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

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
