/*----------------------------------------------------------------------------------------------------------
--  상기 프로그램에 대한 저작권을 포함한 지적재산권은 (주)미라콤아이앤씨에 있으며, (주)미라콤아이앤씨가
--  명시적으로 허용하지 않은 사용, 복사, 변경, 제3자에의 공개, 배포는 엄격히 금지되며, (주)미라콤아이앤씨의
--  지적재산권 침해에 해당됩니다.
--  (Copyright ⓒ 2011 Miracom Inc. All Rights Reserved | Confidential)
--
--  Program Id      : c_FXmlComment.cs
--  Creator         : mj.kim
--  Create Date     : 2011.10.27
--  Description     : FAMate Core FaCommon XML Comment Class
--  History         : Created by spike.lee at 2011.10.27
----------------------------------------------------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace Nexplant.MC.Core.FaCommon
{
    public class FXmlComment : IDisposable
    {

        //------------------------------------------------------------------------------------------------------------------------

        private bool m_disposed = false;
        // --
        private FXmlCore m_fXmlCore = null;
        private XmlComment m_xmlComment = null;

        //------------------------------------------------------------------------------------------------------------------------

        #region Class Construction and Destruction

        internal FXmlComment(
            FXmlCore fXmlCore,
            XmlComment xmlComment
            )
        {
            m_fXmlCore = fXmlCore;
            m_xmlComment = xmlComment;
        }
        
        //------------------------------------------------------------------------------------------------------------------------       

        ~FXmlComment(
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
                    m_xmlComment = null;                    
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

        internal XmlComment baseXml
        {
            get
            {
                try
                {
                    m_fXmlCore.wait();
                    return m_xmlComment;
                }
                catch (Exception ex)
                {
                    FDebug.throwException(ex);
                }
                finally
                {
                    m_fXmlCore.set();
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
