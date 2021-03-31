/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2017 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FSecsDataMessageTransfer.cs
--  Creator         : spike.lee
--  Create Date     : 2017.04.18
--  Description     : FAmate Converter FaSecs1ToHsms Secs Data Message Transfer Class
--  History         : Created by spike.lee at 2017.04.18
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Nexplant.MC.Core.FaCommon;

namespace Nexplant.MC.Core.FaSecs1ToHsms
{
    public class FSecsDataMessageTransfer: IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FSecs1ToHsms m_fSecs1ToHsms = null;
        private FXmlNode m_fXmlNodeSmg = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        public FSecsDataMessageTransfer(
            FSecs1ToHsms fSecs1ToHsms,
            FXmlNode fXmlNodeSmg
            )
        {
            m_fSecs1ToHsms = fSecs1ToHsms;
            m_fXmlNodeSmg = fXmlNodeSmg;
            validate();
        }

        //------------------------------------------------------------------------------------------------------------------------

        ~FSecsDataMessageTransfer(
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
                    m_fXmlNodeSmg = null;
                    m_fSecs1ToHsms = null;
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

        public FXmlNode fXmlNodeSmg
        {
            get
            {
                try
                {
                    return m_fXmlNodeSmg;
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
            string val = string.Empty;
            byte bVal = 0;
            bool blVal = false;
            UInt16 val16 = 0;
            UInt32 val32 = 0;
            FFormat fFormat;
            FXmlNodeList fXmlNodeListSit = null;

            try
            {
                // ***
                // SECS Message Validation
                // ***
                if (fXmlNodeSmg.name != FSecsTag.E_SecsMessage)
                {
                    FDebug.throwFException("The XmlNode Name of SECS Message is invalid.");
                }
                // --
                val = fXmlNodeSmg.get_attrVal(FSecsTag.A_SessionId, string.Empty);
                if (!UInt16.TryParse(val, out val16) || val16 > 32767)
                {
                    FDebug.throwFException("The Session ID of SECS Message is invalid.");
                }
                // --
                val = fXmlNodeSmg.get_attrVal(FSecsTag.A_Stream, string.Empty);
                if (!byte.TryParse(val, out bVal) || bVal < 1 || bVal > 127)
                {
                    FDebug.throwFException("The Stream of SECS Message is invalid.");
                }
                // --
                val = fXmlNodeSmg.get_attrVal(FSecsTag.A_Function, string.Empty);
                if (!byte.TryParse(val, out bVal) || bVal < 0 || bVal > 255)
                {
                    FDebug.throwFException("The Function of SECS Message is invalid.");
                }
                // --
                val = fXmlNodeSmg.get_attrVal(FSecsTag.A_WBit, string.Empty);
                if (!bool.TryParse(val, out blVal))
                {
                    FDebug.throwFException("The WBit of SECS Message is invalid.");
                }
                // --
                val = fXmlNodeSmg.get_attrVal(FSecsTag.A_SystemBytes, string.Empty);
                if (val != string.Empty)
                {
                    if (!UInt32.TryParse(val, out val32))
                    {
                        FDebug.throwFException("The SystemBytes of SECS Message is invalid.");
                    }
                }
                
                // --
                if (fXmlNodeSmg.fChildNodes.count > 1)
                {
                    FDebug.throwFException("The Child of SECS Message is invalid.");
                }
                
                // --

                // ***
                // SECS Item Validation
                // ***
                fXmlNodeListSit = fXmlNodeSmg.selectNodes("//*");
                foreach (FXmlNode fXmlNodeSit in fXmlNodeListSit)
                {
                    if (fXmlNodeSit.name != FSecsTag.E_SecsItem)
                    {
                        FDebug.throwFException("The XmlNode Name of SECS Item is invalid.");
                    }
                    // --
                    val = fXmlNodeSit.get_attrVal(FSecsTag.A_Format, string.Empty);
                    if (!Enum.TryParse<FFormat>(val, out fFormat))
                    {
                        FDebug.throwFException("The Format of SECS Item is invalid.");
                    }
                    //
                    if (fFormat != FFormat.L && fXmlNodeSit.hasChildNode)
                    {
                        FDebug.throwFException("The Format of SECS Item is invalid.");
                    }
                }
            }
            catch (Exception ex)
            {
                FDebug.throwException(ex);
            }
            finally
            {
                fXmlNodeListSit = null;
            }
        }

        //------------------------------------------------------------------------------------------------------------------------

        internal FSecsDataMessage getSecsDataMessage(
            )
        {
            try
            {
                return FSecsConverter.convertXmlToSecsDataMessage(m_fSecs1ToHsms, m_fXmlNodeSmg);
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

        public void resetSystembytes(
            )
        {
            try
            {
                m_fXmlNodeSmg.set_attrVal(FSecsTag.A_SystemBytes, m_fSecs1ToHsms.fSystemBytesPointer.uniqueId.ToString());
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
