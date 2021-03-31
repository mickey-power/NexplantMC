/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FCustom001RecvBuffer.cs
--  Creator         : spike.lee
--  Create Date     : 2016.04.15
--  Description     : FAMate Core FaTcpDriver Custom_001 Receive Buffer Class 
--  History         : Created by spike.lee at 2016.04.15
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaTcpDriver
{
    internal class FCustom001RecvBuffer : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private ArrayList m_data = null;        
        private bool m_isCompleted = true;     
        // --
        private UInt32 m_length = 0;
        private byte[] m_bin = null;
        private string m_xml = string.Empty;
        private FXmlNode m_fXmlMsg = null;
        private bool m_isParseSuccess = false;
        private string m_errorMessage = string.Empty;
        // --
        private string m_msgId = string.Empty;
        private string m_equipId = string.Empty;        

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FCustom001RecvBuffer(            
            )
        {
            m_data = new ArrayList();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FCustom001RecvBuffer(
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
                    m_data = null;
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

        public bool isCompleted
        {
            get
            {
                try
                {
                    return m_isCompleted;
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

        public UInt32 length
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

        public byte[] bin
        {
            get
            {
                try
                {
                    return m_bin;
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

        public bool isParseSuccess
        {
            get
            {
                try
                {
                    return m_isParseSuccess;
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

        public string xml
        {
            get
            {
                try
                {
                    return m_xml;
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

        public FXmlNode fXmlMsg
        {
            get
            {
                try
                {
                    return m_fXmlMsg;
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

        public string errorMessage
        {
            get
            {
                try
                {
                    return m_errorMessage;
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

        public string msgId
        {
            get
            {
                try
                {
                    return m_msgId;
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

        public string equipId
        {
            get
            {
                try
                {
                    return m_equipId;
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

        public void init(
            )
        {
            try
            {
                m_length = 0;
                m_bin = null;
                m_xml = string.Empty;
                m_fXmlMsg = null;
                m_isParseSuccess = false;
                m_errorMessage = string.Empty;
                m_msgId = string.Empty;
                m_equipId = string.Empty;
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

        public void clear(
            )
        {
            try
            {
                init();
                m_data.Clear();
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

        public void input(
            byte[] data
            )
        {
            try
            {
                m_data.AddRange(data);              
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

        public bool parse(
            )
        {
            int etxPtr = 0;
            int index = 0;

            try
            {
                if (m_data.Count == 0)
                {
                    m_isCompleted = true;
                    return false;
                }

                // --

                etxPtr = -1;
                while (index < m_data.Count)
                {
                    etxPtr = m_data.IndexOf((byte)0x0A, index);
                    if (etxPtr == -1)
                    {
                        break;
                    }
                    // --
                    if (etxPtr + 1 < m_data.Count && (byte)m_data[etxPtr + 1] == 0x0A)
                    {
                        break;
                    }
                    index = etxPtr + 1;
                }
                // --
                if (etxPtr == -1)
                {
                    m_isCompleted = false;
                    return false;
                }

                // --

                // ***
                // 01234 5 6789
                // ABCD\n\n 
                // ***
                m_length = (UInt32)etxPtr + 2;
                m_bin = (byte[])m_data.GetRange(0, etxPtr).ToArray(typeof(byte));

                // --

                // ***
                // XML Parsing
                // ***
                m_isParseSuccess = parseBinToXml();

                // --

                // ***
                // Etx(0x0A, 0x0A)를 포함한 데이터 제거
                // ***
                m_data.RemoveRange(0, etxPtr + 2);
                m_isCompleted = true;
                return true;               
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

        //------------------------------------------------------------------------------------------------------------------------

        private bool parseBinToXml(
            )
        {
            FXmlDocument fXmlDoc = null;                        
            FXmlNode fXmlNode = null;
            string xpath = string.Empty;
            bool result = false;

            try
            {
                m_xml = Encoding.Default.GetString(m_bin);

                // --

                fXmlDoc = new FXmlDocument();
                fXmlDoc.preserveWhiteSpace = false;
                // --
                try
                {
                    fXmlDoc.loadXml(m_xml); 
                }
                catch (Exception inEx)
                {
                    m_errorMessage = inEx.Message;
                    return false;
                }

                // --

                // ***
                // Message 복사
                // ***
                m_fXmlMsg = fXmlDoc.fFirstChild.clone(true);

                // --

                // ***
                // XML 구조가 판단되었을 경우 정규화된 XML로 변경
                // ***
                m_xml = m_fXmlMsg.xmlToString(true);

                // --

                result = true;

                // --

                // ***
                // XML Element Validation
                // ***
                if (m_fXmlMsg.name != FXmlTagCustom001.E_MESSAGE)
                {
                    m_errorMessage = string.Format(FConstants.err_m_0016, "MESSAGE Element to Received Message");
                    result = false;
                }

                xpath = FXmlTagCustom001.E_HEADER + "/" + FXmlTagCustom001.E_MSG_ID;
                fXmlNode = m_fXmlMsg.selectSingleNode(xpath);
                if (fXmlNode == null)
                {
                    if (result)
                    {
                        m_errorMessage = string.Format(FConstants.err_m_0016, "MSG_ID Element to Received Message");
                        result = false;
                    }
                }
                else
                {
                    m_msgId = fXmlNode.innerText;
                }
                
                xpath = FXmlTagCustom001.E_HEADER + "/" + FXmlTagCustom001.E_EQUIP_ID;
                fXmlNode = m_fXmlMsg.selectSingleNode(xpath);
                if (fXmlNode == null)
                {
                    if (result)
                    {
                        m_errorMessage = string.Format(FConstants.err_m_0016, "EQUIP_ID Element to Received Message");
                        result = false;
                    }
                }
                else
                {
                    m_equipId = fXmlNode.innerText;
                }                

                // --

                return result;
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlDoc = null;
                fXmlNode = null;
            }
            return false;
        }

        #endregion

        //------------------------------------------------------------------------------------------------------------------------

    }   // Class end
}   // Namespace end
