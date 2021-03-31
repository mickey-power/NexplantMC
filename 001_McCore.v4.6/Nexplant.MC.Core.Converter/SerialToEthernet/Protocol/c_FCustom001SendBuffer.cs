/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSerialDataTransfer.cs
--  Creator         : mjkim
--  Create Date     : 2019.09.24
--  Description     : FAmate Converter FaSerial Serial Data Message Transfer Class
--  History         : Created by mjkim at 2019.09.24
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSerialToEthernet
{
    public class FSerialPluginDataTransfer: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlNode m_fXmlNodeMsg = null;
        private string m_xml = string.Empty;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSerialPluginDataTransfer(
            )
        {

        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSerialPluginDataTransfer(
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
                    m_fXmlNodeMsg = null;
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

        public FXmlNode fMsg
        {
            get
            {
                try
                {
                    return m_fXmlNodeMsg;
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
 
        private void validate(
            )
        {
            string xpath = string.Empty;

            try
            {
                // ***
                // XML Element Validation
                // ***
                if (m_fXmlNodeMsg.name != FXmlSocketTag.E_MESSAGE)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "MESSAGE Element"));
                }

                xpath = FXmlSocketTag.E_HEADER + "/" + FXmlSocketTag.E_MSG_ID;
                if (m_fXmlNodeMsg.selectSingleNode(xpath) == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "MSG_ID Element"));
                }

                xpath = FXmlSocketTag.E_HEADER + "/" + FXmlSocketTag.E_EQUIP_ID;
                if (m_fXmlNodeMsg.selectSingleNode(xpath) == null)
                {
                    FDebug.throwFException(string.Format(FConstants.err_m_0016, "EQUIP_ID Element"));
                }
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

        public void getDataMessage(
            FXmlNode fXmlNodeMsg
            )
        {
            try
            {
                m_fXmlNodeMsg = fXmlNodeMsg;
                m_xml = m_fXmlNodeMsg.xmlToString(true);
                // --
                validate();
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

        internal byte[] getBinaryData(
            )
        {
            byte[] btEtx = new byte[] { 0x0A, 0x0A };
            ArrayList bin = null;

            try
            {
                bin = new ArrayList();
                bin.AddRange(Encoding.Default.GetBytes(m_xml));
                bin.AddRange(btEtx);
                // --
                return (byte[])bin.ToArray(typeof(byte));
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

        internal FSocketSendData getSerialData(
            )
        {
            try
            {
                return new FSocketSendData(
                    getBinaryData()
                    );
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
